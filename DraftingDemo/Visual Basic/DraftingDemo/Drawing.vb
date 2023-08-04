Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing

Imports devDept.Geometry
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot
Imports devDept.Graphics
Imports devDept.LicenseManager


	'
	' Contains all methods required to draw different entities interactively
	'
	Partial Friend Class MyDesignUI
		' Draws interactive/elastic lines as per user clicks on mouse move
		Private Sub DrawInteractiveLines()
			If points.Count = 0 Then
				Return
			End If

			Dim screenPts() As Point2D = GetScreenVertices(points)

			RenderContext.DrawLineStrip(screenPts)

			If ActionMode = actionType.None AndAlso Not ActiveViewport.ToolBar.Contains(mouseLocation) AndAlso points.Count > 0 Then
				' Draw elastic line
				RenderContext.DrawLine(screenPts(screenPts.Length - 1), WorldToScreen(current))
			End If
		End Sub

		Private Function GetScreenVertices(ByVal vertices As IList(Of Point3D)) As Point2D()
			Dim screenPts(vertices.Count - 1) As Point2D

			For i As Integer = 0 To vertices.Count - 1
				screenPts(i) = WorldToScreen(vertices(i))
			Next i
			Return screenPts
		End Function

		' Draws interactive circle (rubber-band) on mouse move with fixed center
		Private Sub DrawInteractiveCircle()
			radius = points(0).DistanceTo(current)

			If radius > 1e-3 Then
				drawingPlane = GetPlane(current)

				DrawPositionMark(points(0))

				Dim tempCircle As New Circle(drawingPlane, points(0), radius)

				Draw(tempCircle)
			End If

		End Sub

		' Draws interactive leader
		Private Sub DrawInteractiveLeader()
			RenderContext.EnableXOR(False)

			Dim text_Renamed As String
			If points.Count = 0 Then
				text_Renamed = "Select the first point"
			ElseIf points.Count = 1 Then
				text_Renamed = "Select the second point"
			Else
				text_Renamed = "Select the third point"
			End If

			DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, text_Renamed, New System.Drawing.Font("Tahoma", 8.25F), DrawingColor, devDept.Eyeshot.ContentAlignment.BottomLeft)

			RenderContext.EnableXOR(True)

			DrawInteractiveLines()
		End Sub

		Private Function GetPlane(ByVal [next] As Point3D) As Plane
			Dim xAxis As New Vector3D(points(0), [next])
			xAxis.Normalize()
			Dim yAxis As Vector3D = Vector3D.Cross(Vector3D.AxisZ, xAxis)
			yAxis.Normalize()

			Dim plane As New Plane(points(0), xAxis, yAxis)

			Return plane
		End Function

		' Draws interactive arc with selected center point position and two end points
		Private Sub DrawInteractiveArc()
			Dim screenPts() As Point2D = GetScreenVertices(points)

			RenderContext.DrawLineStrip(screenPts)

			If ActionMode = actionType.None AndAlso Not ActiveViewport.ToolBar.Contains(mouseLocation) AndAlso points.Count > 0 Then
				' Draw elastic line
				RenderContext.DrawLine(WorldToScreen(points(0)), WorldToScreen(current))

				'draw three point arc
				If points.Count = 2 Then

					radius = points(0).DistanceTo(points(1))

					If radius > 1e-3 Then
						drawingPlane = GetPlane(points(1))

						Dim v1 As New Vector2D(points(0), points(1))
						v1.Normalize()
						Dim v2 As New Vector2D(points(0), current)
						v2.Normalize()

						arcSpanAngle = Vector2D.SignedAngleBetween(v1, v2)

						If Math.Abs(arcSpanAngle) > 1e-3 Then

							Dim tempArc As New Arc(drawingPlane, drawingPlane.Origin, radius, 0, arcSpanAngle)

							Draw(tempArc)

						End If

					End If
				End If

			End If
		End Sub

		' Draws interactive ellipse on mouse move with fixed center and given axis ends
		' Inputs - Ellipse center, End of first axis, End of second axis
		Private Sub DrawInteractiveEllipse()

			If drawingEllipticalArc AndAlso points.Count > 2 Then
				Return
			End If

			If points.Count = 1 Then
				' Draw elastic line
				RenderContext.DrawLine(WorldToScreen(points(0)), WorldToScreen(current))
			End If

			If points.Count < 2 Then
				Return
			End If

			radius = points(0).DistanceTo(points(1))
			radiusY = current.DistanceTo(New Segment2D(points(0), points(1)))

			If radius > 1e-3 AndAlso radiusY > 1e-3 Then
				drawingPlane = GetPlane(points(1))

				DrawPositionMark(points(0))

				Dim tempEllipse As New Ellipse(drawingPlane, drawingPlane.Origin, radius, radiusY)

				Draw(tempEllipse)
			End If

		End Sub

		Private Sub Draw(ByVal theCurve As ICurve)
			If TypeOf theCurve Is CompositeCurve Then
				Dim compositeCurve As CompositeCurve = TryCast(theCurve, CompositeCurve)
				Dim explodedCurves() As Entity = compositeCurve.Explode()
				For Each ent As Entity In explodedCurves

					DrawScreenCurve(DirectCast(ent, ICurve))
				Next ent
			Else
				DrawScreenCurve(theCurve)
			End If
		End Sub

		Private Sub DrawScreenCurve(ByVal curve As ICurve)
				Const subd As Integer = 100

			Dim pts(subd) As Point3D

				For i As Integer = 0 To subd
				pts(i) = WorldToScreen(curve.PointAt(curve.Domain.ParameterAt(CDbl(i)/subd)))
				Next i

			RenderContext.DrawLineStrip(pts)
		End Sub

		' Draws interactive elliptical arc 
		' Inputs - Ellipse center, End of first axis, End of second axis, Start and End point
		Private Sub DrawInteractiveEllipticalArc()
			Dim center As Point3D = points(0)

			If points.Count <= 3 Then
				DrawInteractiveEllipse()
			End If

			ScreenToPlane(mouseLocation, plane, current)

			If points.Count = 3 Then ' ellipse completed, ask user to select start point

				'start position line
				RenderContext.DrawLine(WorldToScreen(center), WorldToScreen(points(1)))

				'current position line
				RenderContext.DrawLine(WorldToScreen(center), WorldToScreen(current))

				'arc portion
				radius = center.DistanceTo(points(1))
				radiusY = points(2).DistanceTo(New Segment2D(center, points(1)))

				If radius > 1e-3 AndAlso radiusY > 1e-3 Then
					DrawPositionMark(points(0))

					drawingPlane = GetPlane(points(1))

					Dim v1 As New Vector2D(center, points(1))
					v1.Normalize()
					Dim v2 As New Vector2D(center, current)
					v2.Normalize()

					arcSpanAngle = Vector2D.SignedAngleBetween(v1, v2)

					If Math.Abs(arcSpanAngle) > 1e-3 Then
						Dim tempArc As New EllipticalArc(drawingPlane, drawingPlane.Origin, radius, radiusY, 0, arcSpanAngle, True)

						Draw(tempArc)
					End If
				End If
			End If
		End Sub

		' Draws interactive/elastic spline curve interpolated from selected points
		Private Sub DrawInteractiveCurve()
            If ProductEdition = licenseType.Pro Then Return
			Dim plusOne As New List(Of Point3D)(points)

			plusOne.Add(GetSnappedPoint(mouseLocation, plane, points, 0))

			' Cubic interpolation needs at least 3 points
			If points.Count > 1 Then
				Dim tempCurve As Curve = Curve.CubicSplineInterpolation(plusOne)

				Draw(tempCurve)
			Else

				RenderContext.DrawLineStrip(GetScreenVertices(plusOne))
			End If
		End Sub

		Private Function GetSnappedPoint(ByVal mousePos As System.Drawing.Point, ByVal plane As Plane, ByVal pts As IList(Of Point3D), ByVal indexToCompare As Integer) As Point3D
			' if the mouse in within 10 pixels of the first curve point, return the first point
			If pts.Count > 0 Then
				Dim ptToSnap As Point3D = pts(indexToCompare)
				Dim ptSnapScreen As Point3D = WorldToScreen(ptToSnap)

				Dim current As New Point2D(mousePos.X, Height - mousePos.Y)

				If Point2D.Distance(current, ptSnapScreen) < 10 Then
					Return DirectCast(ptToSnap.Clone(), Point3D)
				End If
			End If

			Dim pt As Point3D = Nothing
			ScreenToPlane(mousePos, plane, pt)
			Return pt
		End Function

		'Checks if polyline or curve can be closed polygon
		Public Function IsPolygonClosed() As Boolean
			If points.Count > 0 AndAlso (drawingCurve OrElse drawingPolyLine) AndAlso (points(0).DistanceTo(current) < magnetRange) Then
				Return True
			End If

			Return False
		End Function

		'Draws pickbox at current mouse location
		Public Sub DrawSelectionMark(ByVal current As System.Drawing.Point)

			Dim size_Renamed As Double = PickBoxSize
			Dim dim1 As Double = current.X + (size_Renamed/2)
			Dim dim2 As Double = Height-current.Y + (size_Renamed/2)
			Dim dim3 As Double = current.X - (size_Renamed/2)
			Dim dim4 As Double = Height-current.Y - (size_Renamed/2)

			Dim topLeftVertex As New Point3D(dim3, dim2)
			Dim topRightVertex As New Point3D(dim1, dim2)
			Dim bottomRightVertex As New Point3D(dim1, dim4)
			Dim bottomLeftVertex As New Point3D(dim3, dim4)

			RenderContext.DrawLines(New Point3D() { bottomLeftVertex, bottomRightVertex, bottomRightVertex, topRightVertex, topRightVertex, topLeftVertex, topLeftVertex, bottomLeftVertex })


			RenderContext.SetLineSize(1)
		End Sub

		' Draws a plus sign (+) at current mouse location
		Private Sub DrawPositionMark(ByVal current As Point3D, Optional ByVal crossSide As Double = 20.0)
			If drawingAlignedDim OrElse drawingAngularDim OrElse drawingAngularDimFromLines OrElse drawingDiametricDim OrElse drawingLinearDim OrElse drawingOrdinateDim OrElse drawingOrdinateDimVertical OrElse drawingRadialDim Then
				Return
			End If

		    If IsPolygonClosed() Then
				current = points(0)
			End If

			If gridSnapEnabled Then
				If SnapToGrid(current) Then
					RenderContext.SetLineSize(4)
				End If
			End If

			Dim currentScreen As Point3D = WorldToScreen(current)

			' Compute the direction on screen of the horizontal line

			Dim left_Renamed As Point2D = WorldToScreen(current.X - 1, current.Y, 0)
			Dim dirHorizontal As Vector2D = Vector2D.Subtract(left_Renamed, currentScreen)
			dirHorizontal.Normalize()

			' Compute the position on screen of the line endpoints
			left_Renamed = currentScreen + dirHorizontal*crossSide

			Dim right_Renamed As Point2D = currentScreen - dirHorizontal * crossSide

			RenderContext.DrawLine(left_Renamed, right_Renamed)

			' Compute the direction on screen of the vertical line

			Dim bottom_Renamed As Point2D = WorldToScreen(current.X, current.Y - 1, 0)
			Dim dirVertical As Vector2D = Vector2D.Subtract(bottom_Renamed, currentScreen)
			dirVertical.Normalize()

			' Compute the position on screen of the line endpoints
			bottom_Renamed = currentScreen + dirVertical * crossSide

			Dim top_Renamed As Point2D = currentScreen - dirVertical * crossSide

			RenderContext.DrawLine(bottom_Renamed, top_Renamed)

			RenderContext.SetLineSize(1)
		End Sub

		#Region "Flags indicating current drawing mode"

		Public drawingPoints As Boolean

		Public drawingText As Boolean

		Public drawingLeader As Boolean

		Public drawingEllipse As Boolean

		Public drawingEllipticalArc As Boolean

		Public drawingLine As Boolean

		Public drawingCurve As Boolean

		Public drawingCircle As Boolean

		Public drawingArc As Boolean

		Public drawingPolyLine As Boolean

		#End Region
	End Class

