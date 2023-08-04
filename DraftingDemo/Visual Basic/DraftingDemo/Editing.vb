Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Drawing

Imports devDept.Geometry
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot
Imports devDept.Geometry.Entities
Imports devDept.Graphics
Imports devDept.LicenseManager

Imports Font = System.Drawing.Font

'
' Methods required to edit different entities interactively like offset, mirror, extend, trim, rotate etc.
'
Partial Friend Class MyDesignUI
		''' <summary>
		''' Tries to extend entity upto the selected boundary entity. For a short boundary line, it tries to extend selected
		''' entity upto elongated line.
		''' </summary>
		Private Sub ExtendEntity()
			If firstSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					firstSelectedEntity = Entities(selEntityIndex)
					selEntityIndex = -1
					Return
				End If
			ElseIf secondSelectedEntity Is Nothing Then
				DrawSelectionMark(mouseLocation)

				RenderContext.EnableXOR(False)

				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select entity to extend", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
			End If

			If secondSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					secondSelectedEntity = Entities(selEntityIndex)
				End If
			End If

			If firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
				If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
					Dim boundary As ICurve = TryCast(firstSelectedEntity, ICurve)
					Dim curve As ICurve = TryCast(secondSelectedEntity, ICurve)

					ScreenToPlane(mouseLocation, Plane.XY, mouseposs)
					' Check which end of curve is near to boundary
					Dim t1 As Double = Nothing, t2 As Double = Nothing
					Dim tol As Double = 0.5
					boundary.ClosestPointTo(curve.StartPoint, t1)
					boundary.ClosestPointTo(curve.EndPoint, t2)

					Dim projStartPt As Point3D = boundary.PointAt(t1)
					Dim projEndPt As Point3D = boundary.PointAt(t2)

					Dim curveStartDistance, curveEndDistance As Double

					Dim tempC As ICurve = Nothing

					If TypeOf curve Is Arc Then
						Dim arc As Arc = DirectCast(curve, Arc)
						tempC = New Circle(arc.Center, arc.Radius)
					ElseIf TypeOf curve Is Ellipse Then
						Dim el As Ellipse = DirectCast(curve, Ellipse)
						tempC = New Ellipse(el.Center, el.RadiusX, el.RadiusY)
					End If

					If tempC IsNot Nothing AndAlso (tempC.IntersectWith(boundary).Length > 1 OrElse (tempC.IntersectWith( GetExtendedBoundary(boundary)).Length > 1)) Then
						curveStartDistance = curve.StartPoint.DistanceTo(mouseposs)
						curveEndDistance = curve.EndPoint.DistanceTo(mouseposs)
					Else
						curveStartDistance = curve.StartPoint.DistanceTo(projStartPt)
						curveEndDistance = curve.EndPoint.DistanceTo(projEndPt)
					End If

					Dim csdx As Double = Math.Abs(curve.StartPoint.X - projStartPt.X), csdy As Double = Math.Abs(curve.StartPoint.Y - projStartPt.Y), cedx As Double = Math.Abs(curve.EndPoint.X - projEndPt.X), cedy As Double = Math.Abs(curve.EndPoint.Y - projEndPt.Y)

					Dim success As Boolean = False

					Dim nearStart? As Boolean = Nothing

					If curveStartDistance < curveEndDistance AndAlso csdx > tol AndAlso csdy > tol Then
						nearStart = True
					ElseIf cedx > tol AndAlso cedy > tol Then
						nearStart = False
					ElseIf csdx > tol AndAlso csdy > tol Then
						nearStart = True
					End If

					If nearStart.HasValue Then
						If TypeOf curve Is Line Then
							success = ExtendLine(curve, boundary, nearStart.Value)
						ElseIf TypeOf curve Is LinearPath Then
							success = ExtendPolyLine(curve, boundary, nearStart.Value)
						ElseIf TypeOf curve Is Arc Then
							success = ExtendCircularArc(curve, boundary, nearStart.Value)
						ElseIf TypeOf curve Is EllipticalArc Then
							success = ExtendEllipticalArc(curve, boundary, nearStart.Value)
						ElseIf ProductEdition <> licenseType.Pro AndAlso TypeOf curve Is Curve Then
							success = ExtendSpline(curve, boundary, nearStart.Value)
						End If
					End If
					If success Then
						AddAndRefresh(secondSelectedEntity, secondSelectedEntity.LayerName)
						Entities.Regen()
					End If
				End If
				ClearAllPreviousCommandData()
			End If
		End Sub

		''' <summary>
		''' Creates an elongated boundary when it is line.
		''' </summary>
		Private Function GetExtendedBoundary(ByVal boundary As ICurve) As ICurve
			If TypeOf boundary Is Line Then
				Dim tempLine As New Line(boundary.StartPoint, boundary.EndPoint)
				Dim dir1 As New Vector3D(tempLine.StartPoint, tempLine.EndPoint)
				dir1.Normalize()
				tempLine.EndPoint = tempLine.EndPoint + dir1 * extensionLength

				Dim dir2 As New Vector3D(tempLine.EndPoint, tempLine.StartPoint)
				dir2.Normalize()
				tempLine.StartPoint = tempLine.StartPoint + dir2 * extensionLength

				boundary = tempLine
			End If
			Return boundary
		End Function

		''' <summary>
		''' Returns closes point from given input point for provided point list.
		''' </summary>
		Private Function GetClosestPoint(ByVal point3D As Point3D, ByVal intersetionPoints() As Point3D) As Point3D
			Dim minsquaredDist As Double = Double.MaxValue
			Dim result As Point3D = Nothing

			For Each pt As Point3D In intersetionPoints
			    Dim distSquared As Double = devDept.Geometry.Point3D.DistanceSquared(point3D, pt)
				If distSquared < minsquaredDist AndAlso Not point3D.Equals(pt) Then
					minsquaredDist = distSquared
					result = pt
				End If
			Next pt
			Return result
		End Function

		#Region "Extend Methods"
		' Extends input line upto the provided boundary.
		Private Function ExtendLine(ByVal lineCurve As ICurve, ByVal boundary As ICurve, ByVal nearStart As Boolean) As Boolean
			If ProductEdition = licenseType.Pro Then Return False
		    Dim line As Line = TryCast(lineCurve, Line)

			' Create temp line which will intersect boundary curve depending on which end to extend
			Dim tempLine As Line = Nothing
			Dim direction As Vector3D = Nothing
			If nearStart Then
				tempLine = New Line(line.StartPoint, line.StartPoint)
				direction = New Vector3D(line.EndPoint, line.StartPoint)
			Else
				tempLine = New Line(line.EndPoint, line.EndPoint)
				direction = New Vector3D(line.StartPoint, line.EndPoint)
			End If
			direction.Normalize()
			tempLine.EndPoint = tempLine.EndPoint + direction * extensionLength
			' Get intersection points for input line and boundary
			' If not intersecting and boundary is line, we can try with extended boundary
			Dim intersetionPoints() As Point3D = UtilityEx.Intersection(boundary, tempLine)
			If intersetionPoints.Length = 0 Then
				If TypeOf boundary Is Line Then
					intersetionPoints = UtilityEx.Intersection(GetExtendedBoundary(boundary), tempLine)

				ElseIf TypeOf boundary Is EllipticalArc Then
					Dim el As EllipticalArc = DirectCast(boundary, EllipticalArc)
					intersetionPoints = UtilityEx.Intersection(New Ellipse(el.Center, el.RadiusX, el.RadiusY), tempLine)

				ElseIf TypeOf boundary Is Arc Then
					Dim arc As Arc = DirectCast(boundary, Arc)
					intersetionPoints = UtilityEx.Intersection(New Circle(arc.Center, arc.Radius), tempLine)
				End If
			End If

			' Modify line start/end point as closest intersection point
			If intersetionPoints.Length > 0 Then
				If nearStart Then
					line.StartPoint = GetClosestPoint(line.StartPoint, intersetionPoints)
				Else
					line.EndPoint = GetClosestPoint(line.EndPoint, intersetionPoints)
				End If

				AddAndRefresh(line, DirectCast(lineCurve, Entity).LayerName)
				Return True
			End If
			Return False
		End Function

		' Method for polyline extension
		Private Function ExtendPolyLine(ByVal lineCurve As ICurve, ByVal boundary As ICurve, ByVal nearStart As Boolean) As Boolean
		    If ProductEdition = licenseType.Pro Then Return False
		    Dim line As LinearPath = TryCast(secondSelectedEntity, LinearPath)
			Dim tempVertices() As Point3D = line.Vertices

			' create temp line with proper direction
			Dim tempLine As New Line(line.StartPoint, line.StartPoint)
			Dim direction As New Vector3D(line.Vertices(1), line.StartPoint)

			If Not nearStart Then
				tempLine = New Line(line.EndPoint, line.EndPoint)
				direction = New Vector3D(line.Vertices(line.Vertices.Length - 2), line.EndPoint)
			End If

			direction.Normalize()
			tempLine.EndPoint = tempLine.EndPoint + direction * extensionLength
			Dim intersetionPoints() As Point3D = UtilityEx.Intersection(boundary, tempLine)
			If intersetionPoints.Length = 0 Then
				intersetionPoints = UtilityEx.Intersection(GetExtendedBoundary(boundary), tempLine)
			End If

			If intersetionPoints.Length > 0 Then
				If nearStart Then
					tempVertices(0) = GetClosestPoint(line.StartPoint, intersetionPoints)
				Else
					tempVertices(tempVertices.Length - 1) = GetClosestPoint(line.EndPoint, intersetionPoints)
				End If

				line.Vertices = tempVertices
				AddAndRefresh(line, DirectCast(lineCurve, Entity).LayerName)
				Return True
			End If
			Return False
		End Function

		' Method for arc extension
		Private Function ExtendCircularArc(ByVal arcCurve As ICurve, ByVal boundary As ICurve, ByVal nearStart As Boolean) As Boolean
		    If ProductEdition = licenseType.Pro Then Return False
			Dim selCircularArc As Arc = TryCast(arcCurve, Arc)
			Dim tempCircle As New Circle(selCircularArc.Plane, selCircularArc.Center, selCircularArc.Radius)
			Dim intersetionPoints() As Point3D = UtilityEx.Intersection(boundary, tempCircle)
			If intersetionPoints.Length = 0 Then
				intersetionPoints = UtilityEx.Intersection(GetExtendedBoundary(boundary), tempCircle)
			End If

			If intersetionPoints.Length > 0 Then
				If nearStart Then
					Dim intPoint As Point3D = GetClosestPoint(selCircularArc.StartPoint, intersetionPoints)
					Dim xAxis As New Vector3D(selCircularArc.Center, selCircularArc.EndPoint)
					xAxis.Normalize()
					Dim yAxis As Vector3D = Vector3D.Cross(Vector3D.AxisZ, xAxis)
					yAxis.Normalize()
					Dim arcPlane As New Plane(selCircularArc.Center, xAxis, yAxis)

					Dim v1 As New Vector2D(selCircularArc.Center, selCircularArc.EndPoint)
					v1.Normalize()
					Dim v2 As New Vector2D(selCircularArc.Center, intPoint)
					v2.Normalize()

					Dim arcSpan As Double = Vector2D.SignedAngleBetween(v1, v2)
					Entities.Remove(secondSelectedEntity)
					secondSelectedEntity = New Arc(arcPlane, arcPlane.Origin, selCircularArc.Radius, 0, arcSpan)
				Else
					Dim intPoint As Point3D = GetClosestPoint(selCircularArc.EndPoint, intersetionPoints)

					'plane
					Dim xAxis As New Vector3D(selCircularArc.Center, selCircularArc.StartPoint)
					xAxis.Normalize()
					Dim yAxis As Vector3D = Vector3D.Cross(Vector3D.AxisZ, xAxis)
					yAxis.Normalize()
					Dim arcPlane As New Plane(selCircularArc.Center, xAxis, yAxis)

					Dim v1 As New Vector2D(selCircularArc.Center, selCircularArc.StartPoint)
					v1.Normalize()
					Dim v2 As New Vector2D(selCircularArc.Center, intPoint)
					v2.Normalize()

					Dim arcSpan As Double = Vector2D.SignedAngleBetween(v1, v2)
					Entities.Remove(secondSelectedEntity)
					secondSelectedEntity = New Arc(arcPlane, arcPlane.Origin, selCircularArc.Radius, 0, arcSpan)
				End If
				Return True
			End If
			Return False
		End Function

		' Method for elliptical arc extension
		Private Function ExtendEllipticalArc(ByVal ellipticalArcCurve As ICurve, ByVal boundary As ICurve, ByVal start As Boolean) As Boolean
		    If ProductEdition = licenseType.Pro Then Return False
		    Dim selEllipseArc As EllipticalArc = TryCast(ellipticalArcCurve, EllipticalArc)
			Dim tempEllipse As New Ellipse(selEllipseArc.Plane, selEllipseArc.Center, selEllipseArc.RadiusX, selEllipseArc.RadiusY)
			Dim intersetionPoints() As Point3D = UtilityEx.Intersection(boundary, tempEllipse)
			If intersetionPoints.Length = 0 Then
				intersetionPoints = UtilityEx.Intersection(GetExtendedBoundary(boundary), tempEllipse)
			End If

			Dim newArc As EllipticalArc = Nothing

			If intersetionPoints.Length > 0 Then
				Dim arcPlane As Plane = selEllipseArc.Plane
				If start Then
					Dim intPoint As Point3D = GetClosestPoint(selEllipseArc.StartPoint, intersetionPoints)

					newArc = New EllipticalArc(arcPlane, selEllipseArc.Center, selEllipseArc.RadiusX, selEllipseArc.RadiusY, selEllipseArc.EndPoint, intPoint, False)
					' If start point is not on the new arc, flip needed
					Dim t As Double = Nothing
					newArc.ClosestPointTo(selEllipseArc.StartPoint, t)
					Dim projPt As Point3D = newArc.PointAt(t)
					If projPt.DistanceTo(selEllipseArc.StartPoint) > 0.1 Then
						newArc = New EllipticalArc(arcPlane, selEllipseArc.Center, selEllipseArc.RadiusX, selEllipseArc.RadiusY, selEllipseArc.EndPoint, intPoint, True)
					End If
					AddAndRefresh(newArc, DirectCast(ellipticalArcCurve, Entity).LayerName)
				Else
					Dim intPoint As Point3D = GetClosestPoint(selEllipseArc.EndPoint, intersetionPoints)
					newArc = New EllipticalArc(arcPlane, selEllipseArc.Center, selEllipseArc.RadiusX, selEllipseArc.RadiusY, selEllipseArc.StartPoint, intPoint, False)

					' If end point is not on the new arc, flip needed
					Dim t As Double = Nothing
					newArc.ClosestPointTo(selEllipseArc.EndPoint, t)
					Dim projPt As Point3D = newArc.PointAt(t)
					If projPt.DistanceTo(selEllipseArc.EndPoint) > 0.1 Then
						newArc = New EllipticalArc(arcPlane, selEllipseArc.Center, selEllipseArc.RadiusX, selEllipseArc.RadiusY, selEllipseArc.StartPoint, intPoint, True)
					End If
				End If
				If newArc IsNot Nothing Then
					Entities.Remove(secondSelectedEntity)
					secondSelectedEntity = newArc
					Return True
				End If
			End If
			Return False
		End Function

		' Method for spline extension
		Private Function ExtendSpline(ByVal curve As ICurve, ByVal boundary As ICurve, ByVal nearStart As Boolean) As Boolean
		    If ProductEdition = licenseType.Pro Then Return False
			Dim originalSpline As Curve = TryCast(curve, Curve)

			Dim tempLine As Line = Nothing
			Dim direction As Vector3D = Nothing
			If nearStart Then
				tempLine = New Line(curve.StartPoint, curve.StartPoint)
				direction = curve.StartTangent
				direction.Normalize()
				direction.Negate()
				tempLine.EndPoint = tempLine.EndPoint + direction * extensionLength
			Else
				tempLine = New Line(curve.EndPoint, curve.EndPoint)
				direction = curve.EndTangent
				direction.Normalize()
				tempLine.EndPoint = tempLine.EndPoint + direction * extensionLength
			End If

			Dim intersetionPoints() As Point3D = UtilityEx.Intersection(boundary, tempLine)
			If intersetionPoints.Length = 0 Then
				intersetionPoints = UtilityEx.Intersection(GetExtendedBoundary(boundary), tempLine)
			End If

			If intersetionPoints.Length > 0 Then
				Dim ctrlPoints As List(Of Point4D) = originalSpline.ControlPoints.ToList()
				Dim newCtrlPoints As New List(Of Point3D)()
				If nearStart Then
					newCtrlPoints.Add(GetClosestPoint(curve.StartPoint, intersetionPoints))
					For Each ctrlPt As Point4D In ctrlPoints
						Dim point As New Point3D(ctrlPt.X, ctrlPt.Y, ctrlPt.Z)
						If Not point.Equals(originalSpline.StartPoint) Then
							newCtrlPoints.Add(point)
						End If
					Next ctrlPt
				Else
					For Each ctrlPt As Point4D In ctrlPoints
						Dim point As New Point3D(ctrlPt.X, ctrlPt.Y, ctrlPt.Z)
						If Not point.Equals(originalSpline.EndPoint) Then
							newCtrlPoints.Add(point)
						End If
					Next ctrlPt
					newCtrlPoints.Add(GetClosestPoint(curve.EndPoint, intersetionPoints))
				End If

				Dim newCurve As New Curve(originalSpline.Degree, newCtrlPoints)
				If newCurve IsNot Nothing Then
					Entities.Remove(secondSelectedEntity)
					secondSelectedEntity = newCurve
					Return True
				End If
			End If
			Return False
		End Function
		#End Region

		''' <summary>
		''' Trims selected entity by the cutting entity. Removes portion of the curve near mouse click.
		''' </summary>
		Private Sub TrimEntity()
			If firstSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					firstSelectedEntity = Entities(selEntityIndex)
					selEntityIndex = -1
					Return
				End If
			ElseIf secondSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					secondSelectedEntity = Entities(selEntityIndex)
				Else
					DrawSelectionMark(mouseLocation)
					RenderContext.EnableXOR(False)
					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select entity to be trimmed", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
				End If
			End If
		    
		    If ProductEdition = licenseType.Pro Then Return

			If firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
				If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
					Dim trimmingCurve As ICurve = TryCast(firstSelectedEntity, ICurve)
					Dim curve As ICurve = TryCast(secondSelectedEntity, ICurve)
					Dim intersetionPoints() As Point3D = UtilityEx.Intersection(trimmingCurve, curve)
					If intersetionPoints.Length > 0 AndAlso points.Count > 0 Then
						Dim parameters As New List(Of Double)()
						For i As Integer = 0 To intersetionPoints.Length - 1
							Dim intersetionPoint = intersetionPoints(i)
							Dim t As Double = CType(intersetionPoint, InterPoint).s
							parameters.Add(t)
						Next i

						Dim distSelected As Double = 1

						Dim trimmedCurves() As ICurve = Nothing
						If parameters IsNot Nothing Then
							parameters.Sort()
							Dim u As Double = Nothing
							curve.ClosestPointTo(points(0), u)
							distSelected = Point3D.Distance(points(0), curve.PointAt(u))
							distSelected += distSelected / 1e3

							If u <= parameters(0) Then
								curve.SplitBy(New Point3D() { curve.PointAt(parameters(0)) }, trimmedCurves)
							ElseIf u > parameters(parameters.Count - 1) Then
								curve.SplitBy(New Point3D() { curve.PointAt(parameters(parameters.Count - 1)) }, trimmedCurves)
							Else
								For i As Integer = 0 To parameters.Count - 2
									If u > parameters(i) AndAlso u <= parameters(i + 1) Then
										curve.SplitBy(New Point3D() { curve.PointAt(parameters(i)), curve.PointAt(parameters(i + 1)) }, trimmedCurves)
									End If
								Next i
							End If
						End If

						Dim success As Boolean = False
						'Decide which portion of curve to be deleted
						For i As Integer = 0 To trimmedCurves.Length - 1
							Dim trimmedCurve As ICurve = trimmedCurves(i)
							Dim t As Double = Nothing

						    trimmedCurve.ClosestPointTo(points(0), t)

						    If True Then
						        If (t < trimmedCurve.Domain.t0 OrElse t > trimmedCurve.Domain.t1) OrElse Point3D.Distance(points(0), trimmedCurve.PointAt(t)) > distSelected Then
						            AddAndRefresh(DirectCast(trimmedCurve, Entity), secondSelectedEntity.LayerName)
						            success = True
						        End If
						    End If
						Next


						' Delete original entity to be trimmed
						If success Then
							Entities.Remove(secondSelectedEntity)
						End If
					End If
					ClearAllPreviousCommandData()
				End If
			End If
		End Sub

		Private Sub Extender()
			If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
				
		        Dim boundary = DirectCast(firstSelectedEntity, ICurve)
		        Dim curve = DirectCast(secondSelectedEntity, ICurve)

		        ScreenToPlane(mouseLocation, Plane.XY, mouseposs)

				Dim t1 As Double = Nothing, t2 As Double = Nothing, tol As Double = 0.5

				' Check which end of curve is near to boundary
				boundary.ClosestPointTo(curve.StartPoint, t1)
				boundary.ClosestPointTo(curve.EndPoint, t2)

				Dim projStartPt As Point3D = boundary.PointAt(t1), projEndPt As Point3D = boundary.PointAt(t2)

				Dim curveStartDistance, curveEndDistance As Double

				Dim tempC As ICurve = Nothing, tempB As ICurve = Nothing

				If TypeOf curve Is Arc Then
					Dim arcC As Arc = CType(curve, Arc)
					tempC = New Circle(arcC.Center, arcC.Radius)

				ElseIf TypeOf curve Is Ellipse Then
					Dim elC As Ellipse = CType(curve, Ellipse)
					tempC = New Ellipse(elC.Center, elC.RadiusX, elC.RadiusY)

				ElseIf TypeOf curve Is Line Then
					Dim liC As Line = CType(curve, Line)
					tempC = GetExtendedBoundary(liC)

				End If

				If TypeOf boundary Is Arc Then
					Dim arcB As Arc = CType(boundary, Arc)
					tempB = New Circle(arcB.Center, arcB.Radius)

				ElseIf TypeOf boundary Is Ellipse Then
					Dim elB As Ellipse = CType(boundary, Ellipse)
					tempB = New Ellipse(elB.Center, elB.RadiusX, elB.RadiusY)

				ElseIf TypeOf boundary Is Line Then
					Dim [liB] As Line = CType(boundary, Line)
					tempB = GetExtendedBoundary([liB])

				End If

				If tempC IsNot Nothing AndAlso tempB IsNot Nothing AndAlso tempC.IntersectWith(tempB).Length > 1 Then
					curveStartDistance = curve.StartPoint.DistanceTo(mouseposs)
					curveEndDistance = curve.EndPoint.DistanceTo(mouseposs)
				Else
					curveStartDistance = curve.StartPoint.DistanceTo(projStartPt)
					curveEndDistance = curve.EndPoint.DistanceTo(projEndPt)
				End If

				Dim csdx As Double = Math.Abs(curve.StartPoint.X - projStartPt.X), csdy As Double = Math.Abs(curve.StartPoint.Y - projStartPt.Y), cedx As Double = Math.Abs(curve.EndPoint.X - projEndPt.X), cedy As Double = Math.Abs(curve.EndPoint.Y - projEndPt.Y)

				Dim success As Boolean = False

				Dim nearStart? As Boolean = Nothing

				If curveStartDistance < curveEndDistance AndAlso csdx > tol AndAlso csdy > tol Then
					nearStart = True
				ElseIf cedx > tol AndAlso cedy > tol Then
					nearStart = False
				ElseIf csdx > tol AndAlso csdy > tol Then
					nearStart = True
				End If

				If nearStart.HasValue Then
					If TypeOf curve Is Line Then
						success = ExtendLine(curve, boundary, nearStart.Value)
					ElseIf TypeOf curve Is LinearPath Then
						success = ExtendPolyLine(curve, boundary, nearStart.Value)
					ElseIf TypeOf curve Is Arc Then
						success = ExtendCircularArc(curve, boundary, nearStart.Value)
					ElseIf TypeOf curve Is EllipticalArc Then
						success = ExtendEllipticalArc(curve, boundary, nearStart.Value)
					ElseIf ProductEdition <> licenseType.Pro AndAlso TypeOf curve Is Curve Then
						success = ExtendSpline(curve, boundary, nearStart.Value)
					End If
				End If

				If success Then
					Entities.Remove(secondSelectedEntity)
					Entities.Regen()
				End If
			End If
		End Sub

		Private Function CloneICurve(ByVal curve As ICurve) As ICurve
			If TypeOf curve Is ICloneable Then
				Dim cloneable As ICloneable = DirectCast(curve, ICloneable)
				Return DirectCast(cloneable.Clone(), ICurve)
			End If

			Throw New Exception("Curve cannot be cloned!")
		End Function

		''' <summary>
		''' Tries to fit chamfer line between selected curves. Chamfer distance is provided through user input box.
		''' </summary>
		Private Sub CreateChamferEntity()
			If firstSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					firstSelectedEntity = Entities(selEntityIndex)
					selEntityIndex = -1
					ScreenToPlane(mouseLocation, Plane.XY, mouseposf)
					Return
				End If
			ElseIf secondSelectedEntity Is Nothing Then
				DrawSelectionMark(mouseLocation)
				RenderContext.EnableXOR(False)
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second curve", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
			End If

			If secondSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					secondSelectedEntity = Entities(selEntityIndex)
				End If
			End If
			If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
				If firstSelectedEntity.Equals(secondSelectedEntity) Then
					ClearAllPreviousCommandData()
					Return
				End If
                
			    If ProductEdition <> licenseType.Pro Then
				    firstSelectedEntity = ConvertToArc(firstSelectedEntity)
				    secondSelectedEntity = ConvertToArc(secondSelectedEntity)

				    ScreenToPlane(mouseLocation, Plane.XY, mouseposs)
				    Dim distance As Double = filletRadius

				    Dim l1 As ICurve = DirectCast(firstSelectedEntity.Clone(), ICurve), l2 As ICurve = DirectCast(secondSelectedEntity.Clone(), ICurve)

				    Dim sp1 As ICurve = Nothing, sp2 As ICurve = Nothing, tempF As ICurve = Nothing, tempS As ICurve = Nothing

				    If TypeOf firstSelectedEntity Is Arc Then
					    Dim aF As Arc = CType(firstSelectedEntity, Arc)
					    tempF = New Circle(aF.Center, aF.Radius)
				    ElseIf TypeOf firstSelectedEntity Is Line Then
					    Dim lF As Line = CType(firstSelectedEntity, Line)
					    tempF = GetExtendedBoundary(lF)
				    ElseIf TypeOf firstSelectedEntity Is EllipticalArc Then
					    Dim ef As EllipticalArc = CType(firstSelectedEntity, EllipticalArc)
					    tempF = New Ellipse(ef.Center, ef.RadiusX, ef.RadiusY)
				    End If
				    If TypeOf secondSelectedEntity Is Arc Then
					    Dim [aS] As Arc = CType(secondSelectedEntity, Arc)
					    tempS = New Circle([aS].Center, [aS].Radius)
				    ElseIf TypeOf secondSelectedEntity Is Line Then
					    Dim lS As Line = CType(secondSelectedEntity, Line)
					    tempS = GetExtendedBoundary(lS)
				    ElseIf TypeOf secondSelectedEntity Is EllipticalArc Then
					    Dim es As EllipticalArc = CType(secondSelectedEntity, EllipticalArc)
					    tempS = New Ellipse(es.Center, es.RadiusX, es.RadiusY)
				    End If

				    Dim e1 As ICurve = l1, e2 As ICurve = l2

				    If UtilityEx.Intersection(DirectCast(firstSelectedEntity, ICurve), DirectCast(secondSelectedEntity, ICurve)).Length > 1 OrElse tempF IsNot Nothing AndAlso tempS IsNot Nothing AndAlso UtilityEx.Intersection(tempF, tempS).Length > 1 Then
					    GetRightSide(l1, l2, e1, e2, sp1, sp2)
				    End If

				    Dim firstEntities() As ICurve = { CloneICurve(e1), CloneICurve(e1), CloneICurve(e1), CloneICurve(e1), Nothing, Nothing, Nothing, Nothing }, secondEntities() As ICurve = { CloneICurve(e2), CloneICurve(e2), CloneICurve(e2), CloneICurve(e2), Nothing, Nothing, Nothing, Nothing }

				    Dim chamfers(7) As Line

				    Dim f As ICurve = TryCast(firstSelectedEntity, ICurve), s As ICurve = TryCast(secondSelectedEntity, ICurve)

				    Dim distance1S As Double = Point3D.Distance(mouseposf, f.StartPoint), distance1E As Double = Point3D.Distance(mouseposs, f.EndPoint)

				    If distance1E < distance1S AndAlso (TypeOf s Is Arc OrElse TypeOf s Is EllipticalArc) Then
					    f.Reverse()
				    End If

				    Dim distance2S As Double = Point3D.Distance(mouseposf, s.StartPoint), distance2E As Double = Point3D.Distance(mouseposs, s.EndPoint)

				    If distance2E < distance2S AndAlso (TypeOf s Is Arc OrElse TypeOf s Is EllipticalArc) Then
					    s.Reverse()
				    End If

				    For i As Integer = 4 To firstEntities.Length - 1
					    firstEntities(i) = CloneICurve(e1)
				    Next i

				    For i As Integer = 4 To secondEntities.Length - 1
					    secondEntities(i) = CloneICurve(e2)
				    Next i

				    Curve.Chamfer(firstEntities(0), secondEntities(0), distance, False, False, True, True, chamfers(0))
				    Curve.Chamfer(firstEntities(1), secondEntities(1), distance, False, True, True, True, chamfers(1))
				    Curve.Chamfer(firstEntities(2), secondEntities(2), distance, True, False, True, True, chamfers(2))
				    Curve.Chamfer(firstEntities(3), secondEntities(3), distance, True, True, True, True, chamfers(3))
				    Curve.Chamfer(firstEntities(4), secondEntities(4), distance, False, False, True, True, chamfers(4))
				    Curve.Chamfer(firstEntities(5), secondEntities(5), distance, False, True, True, True, chamfers(5))
				    Curve.Chamfer(firstEntities(6), secondEntities(6), distance, True, False, True, True, chamfers(6))
				    Curve.Chamfer(firstEntities(7), secondEntities(7), distance, True, True, True, True, chamfers(7))

				    Dim index As Integer = MinDistIndex(chamfers)

				    If index >= 0 Then
					    Entities.Remove(firstSelectedEntity)
					    Entities.Remove(secondSelectedEntity)

					    Dim flip As Boolean = TypeOf firstEntities(index) Is EllipticalArc AndAlso DirectCast(firstEntities(index), EllipticalArc).Center.X > mouseposf.X

					    Dim original As ICurve = Fuse(firstEntities(index), sp1, flip)

					    If original IsNot Nothing Then
						    firstEntities(index) = original
					    End If

					    flip = TypeOf secondEntities(index) Is EllipticalArc AndAlso DirectCast(secondEntities(index), EllipticalArc).Center.X > mouseposs.X
					    original = Fuse(secondEntities(index), sp2, flip)

					    If original IsNot Nothing Then
						    secondEntities(index) = original
					    End If

					    AddAndRefresh(If(Not IsClosed(firstSelectedEntity), DirectCast(firstEntities(index), Entity), firstSelectedEntity), ActiveLayerName)

					    AddAndRefresh(If(Not IsClosed(secondSelectedEntity), DirectCast(secondEntities(index), Entity), secondSelectedEntity), ActiveLayerName)

					    AddAndRefresh(chamfers(index), ActiveLayerName)
				    ElseIf Not f.StartPoint.Equals(s.StartPoint) AndAlso Not f.StartPoint.Equals(s.EndPoint) AndAlso Not s.StartPoint.Equals(f.EndPoint) AndAlso Not s.EndPoint.Equals(f.EndPoint) Then
					    If (TypeOf secondSelectedEntity Is Arc OrElse TypeOf secondSelectedEntity Is EllipticalArc) AndAlso TypeOf firstSelectedEntity Is Line Then
						    If Not IsClosed(secondSelectedEntity) Then
							    Extender()
						    End If

						    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

						    Extender()

						    Utility.Swap(firstSelectedEntity, secondSelectedEntity)
					    Else
						    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

						    Extender()

						    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

						    Extender()

						    If distance1E < distance1S AndAlso (TypeOf f Is Arc OrElse TypeOf s Is Arc) Then
							    f.Reverse()
						    End If

						    If distance2E < distance2S AndAlso (TypeOf f Is Arc OrElse TypeOf s Is Arc) Then
							    s.Reverse()
						    End If
					    End If

					    If distance > 0 Then
						    l1 = DirectCast(firstSelectedEntity.Clone(), ICurve)
						    l2 = DirectCast(secondSelectedEntity.Clone(), ICurve)

						    e1 = l1
						    e2 = l2

						    If UtilityEx.Intersection(DirectCast(firstSelectedEntity, ICurve), DirectCast(secondSelectedEntity, ICurve)).Length > 1 OrElse tempF IsNot Nothing AndAlso tempS IsNot Nothing AndAlso UtilityEx.Intersection(tempF, tempS).Length > 1 Then
							    GetRightSide(l1, l2, e1, e2, sp1, sp2)
						    End If

						    For i As Integer = 0 To firstEntities.Length - 1
							    firstEntities(i) = CloneICurve(e1)
						    Next i

						    For i As Integer = 0 To secondEntities.Length - 1
							    secondEntities(i) = CloneICurve(e2)
						    Next i

						    Curve.Chamfer(firstEntities(0), secondEntities(0), distance, False, False, True, True, chamfers(0))
						    Curve.Chamfer(firstEntities(1), secondEntities(1), distance, False, True, True, True, chamfers(1))
						    Curve.Chamfer(firstEntities(2), secondEntities(2), distance, True, False, True, True, chamfers(2))
						    Curve.Chamfer(firstEntities(3), secondEntities(3), distance, True, True, True, True, chamfers(3))
						    Curve.Chamfer(firstEntities(4), secondEntities(4), distance, False, False, True, True, chamfers(4))
						    Curve.Chamfer(firstEntities(5), secondEntities(5), distance, False, True, True, True, chamfers(5))
						    Curve.Chamfer(firstEntities(6), secondEntities(6), distance, True, False, True, True, chamfers(6))
						    Curve.Chamfer(firstEntities(7), secondEntities(7), distance, True, True, True, True, chamfers(7))

						    index = MinDistIndex(chamfers)

						    If index >= 0 Then
							    Entities.Remove(secondSelectedEntity)
							    Entities.Remove(firstSelectedEntity)

							    Dim original As ICurve = Fuse(firstEntities(index), sp1)

							    If original IsNot Nothing Then
								    firstEntities(index) = original
							    End If

							    original = Fuse(secondEntities(index), sp2)

							    If original IsNot Nothing Then
								    secondEntities(index) = original
							    End If

							    AddAndRefresh(If(Not IsClosed(firstSelectedEntity), DirectCast(firstEntities(index), Entity), firstSelectedEntity), ActiveLayerName)

							    AddAndRefresh(If(Not IsClosed(secondSelectedEntity), DirectCast(secondEntities(index), Entity), secondSelectedEntity), ActiveLayerName)

							    AddAndRefresh(chamfers(index), ActiveLayerName)
						    Else
							    AddAndRefresh(firstSelectedEntity, ActiveLayerName)
							    AddAndRefresh(secondSelectedEntity, ActiveLayerName)
						    End If
					    End If

				    End If
			    End If
				ClearAllPreviousCommandData()
			End If
		End Sub

		''' <summary>
		''' Fuses together two entities with a point in common.
		''' </summary>
		Private Function Fuse(ByVal curve1 As ICurve, ByVal curve2 As ICurve, Optional ByVal flip As Boolean = True) As ICurve
			If TypeOf curve2 Is Line Then
				If curve2.StartPoint.Equals(curve1.StartPoint) Then
					Return New Line(curve2.EndPoint, curve1.EndPoint)
				End If

				If curve2.StartPoint.Equals(curve1.EndPoint) Then
					Return New Line(curve2.EndPoint, curve1.StartPoint)
				End If

				If curve2.EndPoint.Equals(curve1.StartPoint) Then
					Return New Line(curve2.StartPoint, curve1.EndPoint)
				End If

				If curve2.EndPoint.Equals(curve1.EndPoint) Then
					Return New Line(curve2.StartPoint, curve1.StartPoint)
				End If
			ElseIf TypeOf curve2 Is Arc Then
				Dim arc As Arc = DirectCast(curve2, Arc)
				If curve2.StartPoint.Equals(curve1.StartPoint) Then
					Return New Arc(arc.Center, curve2.EndPoint, curve1.EndPoint)
				End If

				If curve2.StartPoint.Equals(curve1.EndPoint) Then
					Return New Arc(arc.Center, curve2.EndPoint, curve1.StartPoint)
				End If

				If curve2.EndPoint.Equals(curve1.StartPoint) Then
					Return New Arc(arc.Center, curve2.StartPoint, curve1.EndPoint)
				End If

				If curve2.EndPoint.Equals(curve1.EndPoint) Then
					Return New Arc(arc.Center, curve2.StartPoint, curve1.StartPoint)
				End If
			ElseIf TypeOf curve2 Is EllipticalArc Then
				Dim eArc As EllipticalArc = DirectCast(curve2, EllipticalArc)
				If curve2.StartPoint.Equals(curve1.StartPoint) Then
					Return New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, curve2.EndPoint, curve1.EndPoint, flip)
				End If

				If curve2.StartPoint.Equals(curve1.EndPoint) Then
					Return New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, curve2.EndPoint, curve1.StartPoint, flip)
				End If

				If curve2.EndPoint.Equals(curve1.StartPoint) Then
					Return New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, curve2.StartPoint, curve1.EndPoint, flip)
				End If

				If curve2.EndPoint.Equals(curve1.EndPoint) Then
					Return New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, curve2.StartPoint, curve1.StartPoint, flip)
				End If
			End If

			Return Nothing
		End Function

		Private Shared Sub GetSides(ByVal point As Point3D, ByVal curve As ICurve, ByRef s1 As ICurve, ByRef s2 As ICurve)
			If TypeOf curve Is Line Then
				Dim line As Line = DirectCast(curve, Line)
				s2 = If(point.Equals(curve.StartPoint), New Line(line.MidPoint, curve.EndPoint), New Line(curve.StartPoint, line.MidPoint))

				s1 = New Line(point, line.MidPoint)

			ElseIf TypeOf curve Is Arc AndAlso Not IsClosed(DirectCast(curve, Arc)) Then
				Dim arc = DirectCast(curve, Arc)
				s2 = If(point.Equals(curve.StartPoint), New Arc(arc.Center, arc.MidPoint, curve.EndPoint), New Arc(arc.Center, curve.StartPoint, arc.MidPoint))

				s1 = New Arc(arc.Center, point, arc.MidPoint)

			ElseIf TypeOf curve Is EllipticalArc AndAlso Not IsClosed(DirectCast(curve, EllipticalArc)) Then
				Dim eArc = DirectCast(curve, EllipticalArc)
			    Dim p As Point3D = eArc.PointAt(eArc.Domain.Mid)

				If point.Equals(curve.StartPoint) Then
					s2 = New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, p, curve.EndPoint, False)
					s1 = New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, point, p, False)
				Else
					s2 = New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, curve.StartPoint, p, False)
					s1 = New EllipticalArc(eArc.Plane, eArc.Center, eArc.RadiusX, eArc.RadiusY, p, point, False)
				End If
			
			Else
				s1 = Nothing
				s2 = Nothing
			
			End If
		End Sub

		''' <summary>
		''' Cut the entities in half for chamfer creation purposes.
		''' Returns the entities in side1 and side2 and their cut part in special1 and special2.
		''' </summary>
		Private Sub GetRightSide(ByVal e1 As ICurve, ByVal e2 As ICurve, ByRef side1 As ICurve, ByRef side2 As ICurve, ByRef special1 As ICurve, ByRef special2 As ICurve)
			Dim l1 As ICurve = e1
			Dim l2 As ICurve = e2

			Dim f1 As Point3D = GetClosestPoint(mouseposf, { l1.StartPoint, l1.EndPoint }), s1 As Point3D = GetClosestPoint(mouseposs, { l2.StartPoint, l2.EndPoint })

			Dim sp1 As ICurve = Nothing
			GetSides(f1, l1, l1, sp1)
			Dim sp2 As ICurve = Nothing
			GetSides(s1, l2, l2, sp2)

			side1 = If(l1, e1)
			side2 = If(l2, e2)

			special1 = sp1
			special2 = sp2
		End Sub

		''' <summary>
		''' If the given curve is a circle or an ellipse, remove the curve from entities and
		''' convert the curve to an arc or an elliptical arc.
		''' </summary>
		Private Function ConvertToArc(ByVal entity As Entity) As Entity
            If TypeOf entity Is Circle AndAlso Not (TypeOf entity Is Arc) Then
				Entities.Remove(entity)
				dim circle = DirectCast(entity, Circle)
				entity = New Arc(circle.Center, circle.Radius, Math.PI * 2)

            ElseIf TypeOf entity Is Ellipse AndAlso Not (TypeOf entity Is EllipticalArc) Then
				Entities.Remove(entity)
				Dim ell = DirectCast(entity, Ellipse)
                entity = New EllipticalArc(ell.Center, ell.RadiusX, ell.RadiusY, 2 * Math.PI)
			
            End If

			Return entity
		End Function

		''' <summary>
		''' Return true if the given entity is an arc or an elliptical arc
		''' with a 360 degrees angle (equivalent to a circle)
		''' </summary>
		Private Shared Function IsClosed(ByVal entity As Entity) As Boolean
            Return TypeOf entity Is Arc AndAlso DirectCast(entity, Arc).AngleInRadians = Utility.TWO_PI OrElse TypeOf entity Is EllipticalArc AndAlso DirectCast(entity, EllipticalArc).AngleInRadians = Utility.TWO_PI
		End Function

		Private Function MinDistIndex(Of T As ICurve)(ByVal curves() As T) As Integer
			Dim dist As Double = Double.MaxValue
			Dim index As Integer = -1

			For i As Integer = 0 To curves.Length - 1
				Dim curve As ICurve = curves(i)

				If curve Is Nothing Then
				    Continue For
				End If

				Dim midPoint As Point3D = curve.PointAt(curve.Domain.Mid)

				Dim tempDist As Double = Point3D.Distance(mouseposf, midPoint) + Point3D.Distance(mouseposs, midPoint)

				If tempDist < dist Then
					dist = tempDist
					index = i
				End If
			Next i

			Return index
		End Function

		''' <summary>
		''' Tries to fit fillet arc between two selected curves. Fillet radius is given from user input box.
		''' </summary>
		Private Sub CreateFilletEntity()
			If firstSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					firstSelectedEntity = Entities(selEntityIndex)
					selEntityIndex = -1
					ScreenToPlane(mouseLocation, Plane.XY, mouseposf)
					Return
				End If
			ElseIf secondSelectedEntity Is Nothing Then
				DrawSelectionMark(mouseLocation)
				RenderContext.EnableXOR(False)
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second curve", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
			End If

			If secondSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					secondSelectedEntity = Entities(selEntityIndex)
				End If
			End If

			If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
				If TypeOf firstSelectedEntity Is Line AndAlso TypeOf secondSelectedEntity Is Line Then
					Dim l1 As Line = TryCast(firstSelectedEntity, Line)
					Dim l2 As Line = TryCast(secondSelectedEntity, Line)

					If Vector3D.AreParallel(l1.Direction, l2.Direction) Then
						ClearAllPreviousCommandData()
						Return
					End If
				End If

                If ProductEdition <> licenseType.Pro Then
				    Try
					    If firstSelectedEntity.Equals(secondSelectedEntity) Then
						    ClearAllPreviousCommandData()
						    Return
					    End If

					    ScreenToPlane(mouseLocation, Plane.XY, mouseposs)

					    firstSelectedEntity = ConvertToArc(firstSelectedEntity)
					    secondSelectedEntity = ConvertToArc(secondSelectedEntity)

					    Dim l1 As ICurve = DirectCast(firstSelectedEntity.Clone(), ICurve), l2 As ICurve = DirectCast(secondSelectedEntity.Clone(), ICurve)

					    Dim sp1 As ICurve = Nothing, sp2 As ICurve = Nothing, tempF As ICurve = Nothing, tempS As ICurve = Nothing

					    If TypeOf firstSelectedEntity Is Arc Then
						    Dim aF As Arc = CType(firstSelectedEntity, Arc)
						    tempF = New Circle(aF.Center, aF.Radius)
					    ElseIf TypeOf firstSelectedEntity Is Line Then
						    Dim lF As Line = CType(firstSelectedEntity, Line)
						    tempF = GetExtendedBoundary(lF)
					    ElseIf TypeOf secondSelectedEntity Is EllipticalArc Then
						    Dim eF As EllipticalArc = CType(secondSelectedEntity, EllipticalArc)
						    tempF = New Ellipse(eF.Center, eF.RadiusX, eF.RadiusY)
					    End If

					    If TypeOf secondSelectedEntity Is Arc Then
						    Dim [aS] As Arc = CType(secondSelectedEntity, Arc)
						    tempS = New Circle([aS].Center, [aS].Radius)
					    ElseIf TypeOf secondSelectedEntity Is Line Then
						    Dim lS As Line = CType(secondSelectedEntity, Line)
						    tempS = GetExtendedBoundary(lS)
					    ElseIf TypeOf secondSelectedEntity Is EllipticalArc Then
						    Dim eS As EllipticalArc = CType(secondSelectedEntity, EllipticalArc)
						    tempS = New Ellipse(eS.Center, eS.RadiusX, eS.RadiusY)
					    End If

					    Dim c1 As ICurve = l1, c2 As ICurve = l2

					    If UtilityEx.Intersection(DirectCast(firstSelectedEntity, ICurve), DirectCast(secondSelectedEntity, ICurve)).Length > 1 OrElse (tempF IsNot Nothing AndAlso tempS IsNot Nothing AndAlso UtilityEx.Intersection(tempF, tempS).Length > 1) Then
						    GetRightSide(l1, l2, c1, c2, sp1, sp2)
					    End If

					    Dim firstEntities() As ICurve = { CloneICurve(c1), CloneICurve(c1), CloneICurve(c1), CloneICurve(c1), Nothing, Nothing, Nothing, Nothing }, secondEntities() As ICurve = { CloneICurve(c2), CloneICurve(c2), CloneICurve(c2), CloneICurve(c2), Nothing, Nothing, Nothing, Nothing }

					    Dim fillets(7) As Arc

					    Dim f As ICurve = TryCast(firstSelectedEntity, ICurve)
					    Dim s As ICurve = TryCast(secondSelectedEntity, ICurve)

					    Dim distance1S As Double = Point3D.Distance(mouseposf, f.StartPoint), distance1E As Double = Point3D.Distance(mouseposs, f.EndPoint)

					    If distance1E < distance1S AndAlso (TypeOf s Is Arc OrElse TypeOf s Is EllipticalArc) Then
						    f.Reverse()
					    End If

					    Dim distance2S As Double = Point3D.Distance(mouseposf, s.StartPoint), distance2E As Double = Point3D.Distance(mouseposs, s.EndPoint)

					    If distance2E < distance2S AndAlso (TypeOf s Is Arc OrElse TypeOf s Is EllipticalArc) Then
						    s.Reverse()
					    End If

					    For i As Integer = 4 To firstEntities.Length - 1
						    firstEntities(i) = CloneICurve(c1)
					    Next i

					    For i As Integer = 4 To secondEntities.Length - 1
						    secondEntities(i) = CloneICurve(c2)
					    Next i

					    Curve.Fillet(firstEntities(0), secondEntities(0), filletRadius, False, False, True, True, fillets(0))
					    Curve.Fillet(firstEntities(1), secondEntities(1), filletRadius, False, True, True, True, fillets(1))
					    Curve.Fillet(firstEntities(2), secondEntities(2), filletRadius, True, False, True, True, fillets(2))
					    Curve.Fillet(firstEntities(3), secondEntities(3), filletRadius, True, True, True, True, fillets(3))
					    Curve.Fillet(firstEntities(4), secondEntities(4), filletRadius, False, False, True, True, fillets(4))
					    Curve.Fillet(firstEntities(5), secondEntities(5), filletRadius, False, True, True, True, fillets(5))
					    Curve.Fillet(firstEntities(6), secondEntities(6), filletRadius, True, False, True, True, fillets(6))
					    Curve.Fillet(firstEntities(7), secondEntities(7), filletRadius, True, True, True, True, fillets(7))

					    Dim index As Integer = MinDistIndex(fillets)

					    If index >= 0 Then

						    Entities.Remove(firstSelectedEntity)
						    Entities.Remove(secondSelectedEntity)

					        Dim curve1  = firstEntities(index)

					        Dim flip As Boolean = TypeOf curve1 Is EllipticalArc AndAlso DirectCast(curve1, EllipticalArc).Center.X > mouseposf.X
						    Dim original As ICurve = Fuse(curve1, sp1, flip)

						    If original IsNot Nothing Then
							    firstEntities(index) = original
						    End If

					        Dim curve2  = secondEntities(index)

					        flip = TypeOf curve2 Is EllipticalArc AndAlso DirectCast(curve2, EllipticalArc).Center.X > mouseposs.X
						    original = Fuse(curve2, sp2, flip)

						    If original IsNot Nothing Then
							    secondEntities(index) = original
						    End If

						    AddAndRefresh(If(Not IsClosed(firstSelectedEntity), DirectCast(firstEntities(index), Entity), firstSelectedEntity), ActiveLayerName)

						    AddAndRefresh(If(Not IsClosed(secondSelectedEntity), DirectCast(secondEntities(index), Entity), secondSelectedEntity), ActiveLayerName)

						    AddAndRefresh(fillets(index), ActiveLayerName)
					    
					    ElseIf Not f.StartPoint.Equals(s.StartPoint) AndAlso Not f.StartPoint.Equals(s.EndPoint) AndAlso Not s.StartPoint.Equals(f.EndPoint) AndAlso Not s.EndPoint.Equals(f.EndPoint) Then
					    
					        If (TypeOf secondSelectedEntity Is Arc OrElse TypeOf secondSelectedEntity Is EllipticalArc) AndAlso TypeOf firstSelectedEntity Is Line Then
							    If Not IsClosed(secondSelectedEntity) Then
								    Extender()
							    End If

							    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

							    Extender()

							    Utility.Swap(firstSelectedEntity, secondSelectedEntity)
						    Else
							    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

							    Extender()

							    Utility.Swap(firstSelectedEntity, secondSelectedEntity)

							    Extender()

							    If distance1E < distance1S AndAlso (TypeOf f Is Arc OrElse TypeOf s Is Arc) Then
								    f.Reverse()
							    End If

							    If distance2E < distance2S AndAlso (TypeOf f Is Arc OrElse TypeOf s Is Arc) Then
								    s.Reverse()
							    End If
						    End If
						    
					        If filletRadius > 0 Then
							    l1 = DirectCast(firstSelectedEntity.Clone(), ICurve)
							    l2 = DirectCast(secondSelectedEntity.Clone(), ICurve)

							    c1 = l1
							    c2 = l2

							    If UtilityEx.Intersection(DirectCast(firstSelectedEntity, ICurve), DirectCast(secondSelectedEntity, ICurve)).Length > 1 OrElse (tempF IsNot Nothing AndAlso tempS IsNot Nothing AndAlso UtilityEx.Intersection(tempF, tempS).Length > 1) Then
								    GetRightSide(l1, l2, c1, c2, sp1, sp2)
							    End If

							    For i As Integer = 0 To firstEntities.Length - 1
								    firstEntities(i) = CloneICurve(c1)
							    Next i

							    For i As Integer = 0 To secondEntities.Length - 1
								    secondEntities(i) = CloneICurve(c2)
							    Next i

							    Curve.Fillet(firstEntities(0), secondEntities(0), filletRadius, False, False, True, True, fillets(0))
							    Curve.Fillet(firstEntities(1), secondEntities(1), filletRadius, False, True, True, True, fillets(1))
							    Curve.Fillet(firstEntities(2), secondEntities(2), filletRadius, True, False, True, True, fillets(2))
							    Curve.Fillet(firstEntities(3), secondEntities(3), filletRadius, True, True, True, True, fillets(3))
							    Curve.Fillet(firstEntities(4), secondEntities(4), filletRadius, False, False, True, True, fillets(4))
							    Curve.Fillet(firstEntities(5), secondEntities(5), filletRadius, False, True, True, True, fillets(5))
							    Curve.Fillet(firstEntities(6), secondEntities(6), filletRadius, True, False, True, True, fillets(6))
							    Curve.Fillet(firstEntities(7), secondEntities(7), filletRadius, True, True, True, True, fillets(7))

							    index = MinDistIndex(fillets)

							    If index >= 0 Then
								    Entities.Remove(secondSelectedEntity)
								    Entities.Remove(firstSelectedEntity)

								    Dim original As ICurve = Fuse(firstEntities(index), sp1)

								    If original IsNot Nothing Then
									    firstEntities(index) = original
								    End If

								    original = Fuse(secondEntities(index), sp2)

								    If original IsNot Nothing Then
									    secondEntities(index) = original
								    End If

								    AddAndRefresh(If(Not IsClosed(firstSelectedEntity), DirectCast(firstEntities(index), Entity), firstSelectedEntity), ActiveLayerName)

								    AddAndRefresh(If(Not IsClosed(secondSelectedEntity), DirectCast(secondEntities(index), Entity), secondSelectedEntity), ActiveLayerName)

								    AddAndRefresh(fillets(index), ActiveLayerName)
							    Else
								    AddAndRefresh(firstSelectedEntity, ActiveLayerName)
								    AddAndRefresh(secondSelectedEntity, ActiveLayerName)
							    End If
						    End If

					    End If
				    Catch
					    ' error while creating fillet, abort
				    End Try
                End If
				ClearAllPreviousCommandData()
			End If
		End Sub

		''' <summary>
		''' Creates mirror image of the selected entity for given mirror axis. Mirror axis is formed by selection two points.
		''' </summary>
		Private Sub CreateMirrorEntity()
			' We need to have two reference points selected, might be snapped vertices
			If points.Count < 2 Then
				'If entity is selected, ask user to select mirror line
				RenderContext.EnableXOR(False)
				If points.Count = 0 AndAlso Not WaitingForSelection Then
					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Start of mirror plane", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
				ElseIf points.Count = 1 Then
					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "End of mirror plane", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
				End If
				DrawInteractiveLines()
			Else
				If points(1).X < points(0).X OrElse points(1).Y < points(0).Y Then
					Dim p0 As Point3D = points(0)
					Dim p1 As Point3D = points(1)

					Utility.Swap(p0, p1)

					points(0) = p0
					points(1) = p1
				End If

				Dim axisX As New Vector3D(points(0), points(1))
				Dim mirrorPlane As New Plane(points(0), axisX, Vector3D.AxisZ)

				Dim mirrorEntity As Entity = DirectCast(selEntity.Clone(), Entity)
				Dim mirror As New Mirror(mirrorPlane)
				mirrorEntity.TransformBy(mirror)
				AddAndRefresh(mirrorEntity, ActiveLayerName)

				ClearAllPreviousCommandData()
			End If
		End Sub
	
        ''' <summary>
        ''' Tries to create offset entity for selected entity at the selected location (offset distance) and side.
        ''' </summary>
        Private Sub CreateOffsetEntity()
            If selEntity IsNot Nothing AndAlso TypeOf selEntity Is ICurve Then
				If ProductEdition = licenseType.Pro AndAlso TypeOf selEntity Is Ellipse OrElse TypeOf selEntity Is EllipticalArc Then
					Return
				End If
                If points.Count = 0 Then
                    RenderContext.EnableXOR(False)
                    DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Side to offset", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
                    Return
                End If

                Dim selCurve As ICurve = TryCast(selEntity, ICurve)
                Dim t As Double = Nothing
                Dim success As Boolean = selCurve.Project(points(0), t)
                Dim projectedPt As Point3D = selCurve.PointAt(t)
                Dim offsetDist As Double = projectedPt.DistanceTo(points(0))

                Dim offsetCurve As ICurve = selCurve.Offset(offsetDist, Vector3D.AxisZ, 0.01, True)
                success = offsetCurve.Project(points(0), t)
                projectedPt = offsetCurve.PointAt(t)
                If projectedPt.DistanceTo(points(0)) > 1e-3 Then
                    offsetCurve = selCurve.Offset(-offsetDist, Vector3D.AxisZ, 0.01, True)
                End If

                AddAndRefresh(DirectCast(offsetCurve, Entity), ActiveLayerName)
            End If
        End Sub
		''' <summary>
		''' Creates lines or circles tangent to two circles.
		''' </summary>
		Private Sub CreateTangentEntity()


			If firstSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					firstSelectedEntity = Entities(selEntityIndex)
					selEntityIndex = -1
					Return
				End If
			ElseIf secondSelectedEntity Is Nothing Then
				DrawSelectionMark(mouseLocation)
				RenderContext.EnableXOR(False)
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second circle", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
			End If

			If secondSelectedEntity Is Nothing Then
				If selEntityIndex <> -1 Then
					secondSelectedEntity = Entities(selEntityIndex)
				End If
			End If

			If TypeOf firstSelectedEntity Is ICurve AndAlso TypeOf secondSelectedEntity Is ICurve Then
				If TypeOf firstSelectedEntity Is Circle AndAlso TypeOf secondSelectedEntity Is Circle Then
				    Dim c1 As Circle = (DirectCast(firstSelectedEntity, Circle))
				    Dim c2 As Circle = (DirectCast(secondSelectedEntity, Circle))


					Try
						If Me.lineTangents Then
							Dim res() As Line = Utility.GetLinesTangentToTwoCircles(c1, c2)
							For Each gLine As Line In res
								AddAndRefresh(gLine, ActiveLayerName)
							Next gLine

						ElseIf Me.circleTangents Then

							Dim res() As Circle = Utility.GetCirclesTangentToTwoCircles(c1, c2, Me.tangentsRadius, Me.trimTangent, Me.flipTangent)
							For Each gCircle As Circle In res
							    AddAndRefresh(gCircle, ActiveLayerName)
							Next gCircle

						Else
							Return
						End If
					Catch
					End Try

				End If
				ClearAllPreviousCommandData()
			End If

		End Sub
		Private Sub DrawCurveOrBlockRef(ByVal tempEntity As Entity)
			If TypeOf tempEntity Is ICurve Then
				Draw(TryCast(tempEntity, ICurve))
			ElseIf TypeOf tempEntity Is LinearDim Then
				Dim [dim] = CType(tempEntity, LinearDim)

				'Draw text
				Draw(New Line([dim].Vertices(6), [dim].Vertices(7)))
				Draw(New Line([dim].Vertices(7), [dim].Vertices(8)))
				Draw(New Line([dim].Vertices(8), [dim].Vertices(9)))
				Draw(New Line([dim].Vertices(9), [dim].Vertices(6)))

				'Draw lines
				Draw(New Line([dim].Vertices(0), [dim].Vertices(1)))
				Draw(New Line([dim].Vertices(2), [dim].Vertices(3)))
				Draw(New Line([dim].Vertices(4), [dim].Vertices(5)))
			ElseIf TypeOf tempEntity Is RadialDim Then
				Dim [dim] = CType(tempEntity, RadialDim)

				'Draw text
				Draw(New Line([dim].Vertices(6), [dim].Vertices(7)))
				Draw(New Line([dim].Vertices(7), [dim].Vertices(8)))
				Draw(New Line([dim].Vertices(8), [dim].Vertices(9)))
				Draw(New Line([dim].Vertices(9), [dim].Vertices(6)))

				Draw(New Line([dim].Vertices(0), [dim].Vertices(5)))
			ElseIf TypeOf tempEntity Is AngularDim Then
				Dim [dim] = CType(tempEntity, AngularDim)

				'Draw text
				Draw(New Line([dim].Vertices(4), [dim].Vertices(5)))
				Draw(New Line([dim].Vertices(5), [dim].Vertices(6)))
				Draw(New Line([dim].Vertices(6), [dim].Vertices(7)))
				Draw(New Line([dim].Vertices(7), [dim].Vertices(4)))

				Draw(New Line([dim].Vertices(0), [dim].Vertices(1)))
				Draw(New Line([dim].Vertices(2), [dim].Vertices(3)))
				Draw([dim].UnderlyingArc)
			ElseIf TypeOf tempEntity Is OrdinateDim Then
				Dim [dim] = CType(tempEntity, OrdinateDim)

				'Draw text
				Draw(New Line([dim].Vertices(4), [dim].Vertices(5)))
				Draw(New Line([dim].Vertices(5), [dim].Vertices(6)))
				Draw(New Line([dim].Vertices(6), [dim].Vertices(7)))
				Draw(New Line([dim].Vertices(7), [dim].Vertices(4)))

				Draw(New Line([dim].Vertices(0), [dim].Vertices(1)))
				Draw(New Line([dim].Vertices(1), [dim].Vertices(2)))
				Draw(New Line([dim].Vertices(2), [dim].Vertices(3)))
			ElseIf TypeOf tempEntity Is Text Then
				Dim txt = CType(tempEntity, Text)

				Draw(New Line(txt.Vertices(0), txt.Vertices(1)))
				Draw(New Line(txt.Vertices(1), txt.Vertices(2)))
				Draw(New Line(txt.Vertices(2), txt.Vertices(3)))
				Draw(New Line(txt.Vertices(3), txt.Vertices(0)))
			ElseIf TypeOf tempEntity Is BlockReference Then
				Dim br As BlockReference = CType(tempEntity, BlockReference)

				Dim entList() As Entity = br.Explode(Me.Blocks)

				For Each item As Entity In entList
					Dim curve As ICurve = TryCast(item, ICurve)
					If curve IsNot Nothing Then
						Draw(curve)
					End If
				Next item


			ElseIf TypeOf tempEntity Is Leader Then
				Dim leader = CType(tempEntity, Leader)

				Draw(New Line(leader.Vertices(0), leader.Vertices(1)))
				Draw(New Line(leader.Vertices(1), leader.Vertices(2)))
			End If
		End Sub

		''' <summary>
		''' Translates selected entity for given movement. User needs to select base point and new location.
		''' </summary>
		Private Sub MoveEntity()
			If points.Count = 0 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select base point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)
				Return
			ElseIf points.Count = 1 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)

				' Show temp entity for current movement state
				For Each ent As Entity In Me.SelEntities
					Dim tempEntity As Entity = DirectCast(ent.Clone(), Entity)
					Dim tempMovement As New Vector3D(points(0), current)
					tempEntity.Translate(tempMovement)

					If TypeOf tempEntity Is Text Then
						tempEntity.Regen(New RegenParams(0))
					End If

					DrawCurveOrBlockRef(tempEntity)
				Next ent
			End If
		End Sub

		''' <summary>
		''' Scales selected entities for given scale factor and base point. Base point and scale factor is interactively provided
		''' by selecting reference points.
		''' </summary>
		Private Sub ScaleEntity()
			Dim worldToScreenVertices = New List(Of Point3D)()
			For Each v In points
				worldToScreenVertices.Add(WorldToScreen(v))
			Next v

			RenderContext.DrawLineStrip(worldToScreenVertices.ToArray())

			If ActionMode = actionType.None AndAlso worldToScreenVertices.Count() > 0 Then
				RenderContext.DrawLineStrip(New Point3D() { WorldToScreen(points.First()), WorldToScreen(current) })
			End If

			If points.Count = 0 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select origin", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)
			ElseIf points.Count = 1 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select first reference point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)
			ElseIf points.Count = 2 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second reference point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)

				scaleFactor = points(0).DistanceTo(current) / points(0).DistanceTo(points(1))

				' Show temp entities for current scale state
				For Each ent As Entity In Me.SelEntities
					Dim tempEntity As Entity = DirectCast(ent.Clone(), Entity)
					tempEntity.Scale(points(0),If(scaleFactor = 0, 1, scaleFactor))

					If TypeOf tempEntity Is Text Then
						tempEntity.Regen(New RegenParams(0))
					End If

					DrawCurveOrBlockRef(tempEntity)
				Next ent
			End If
		End Sub

		''' <summary>
		''' Rotates selected entities by given angle about given center of rotation. Angle is computed similar to drawing arc.
		''' </summary>
		Public Sub RotateEntity()
			DrawInteractiveArc()
			If points.Count = 0 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select center of rotation", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)
			ElseIf points.Count = 1 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select first reference point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)
			ElseIf points.Count = 2 Then
				DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second reference point", New Font("Tahoma", 8.25F), Color.Black, ContentAlignment.BottomLeft)

				' Show temp entities for current rotation state
				For Each ent As Entity In Me.SelEntities
					Dim tempEntity As Entity = DirectCast(ent.Clone(), Entity)
					tempEntity.Rotate(arcSpanAngle, Vector3D.AxisZ, points(0))

					If TypeOf tempEntity Is Text Then
						tempEntity.Regen(New RegenParams(0))
					End If

					DrawCurveOrBlockRef(tempEntity)
				Next ent
			End If
		End Sub

		Private secondSelectedEntity As Entity = Nothing
		Private firstSelectedEntity As Entity = Nothing

		Private mouseposf As Point3D
		Private mouseposs As Point3D

		Public lineTangents As Boolean
		Public circleTangents As Boolean

		Public tangentsRadius As Double = 10.0
		Public filletRadius As Double = 10.0
		Public rotationAngle As Double = 45.0
		Public scaleFactor As Double = 1.5
		Private extensionLength As Double = 500

		#Region "Flags indicating current editing mode"

		Public doingMirror As Boolean
		Public doingOffset As Boolean
		Public doingFillet As Boolean
		Public doingChamfer As Boolean
		Public doingTrim As Boolean
		Public doingTangents As Boolean
		Public doingMove As Boolean
		Public doingRotate As Boolean
		Public doingScale As Boolean
		Public doingExtend As Boolean
		Public editingMode As Boolean

		#End Region

		Public flipTangent As Boolean
		Public trimTangent As Boolean
	End Class

