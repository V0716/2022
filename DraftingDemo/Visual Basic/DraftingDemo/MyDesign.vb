Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Diagnostics
Imports System.Collections

Imports devDept.Eyeshot
Imports devDept.Graphics
Imports devDept.Geometry
Imports devDept.Eyeshot.Entities
Imports System.Windows.Forms
Imports devDept.Geometry.Entities
Imports devDept.LicenseManager
Imports Font = System.Drawing.Font

Class MyDesign
    Inherits Design

    Private ReadOnly Property _designUI As MyDesignUI
        Get
            Return CType(workspaceUI, MyDesignUI)
        End Get
    End Property

    Protected Overrides Sub DrawOverlay(ByVal data As DrawSceneParams)
        _designUI.DrawOverlay(data)
        MyBase.DrawOverlay(data)
    End Sub
End Class
'
' This is Design which will extend behaviour required for a drafting application.
'
Partial Friend Class MyDesignUI
		Inherits devDept.Eyeshot.Control.Design(Of MyDesign)

	    Public Sub New()
		    PreviewParams = New DimensionPreviewDrawParams(dimTextHeight, Color.Yellow)
			PreviewParams.WidthFactor = 0.9
		End Sub

		Private firstClick As Boolean = True

		' Active layer index
		Public ActiveLayerName As String
		Public DimensionLayerName As String	
		' Always draw on XY plane, view is always topview
	Private plane As Plane = devDept.Geometry.Plane.XY
	
		' Current selection/position
		Private current As Point3D

		' List of selected or picked points with left mouse button 
		Private points As New List(Of Point3D)()

		Public SelEntities As New List(Of Entity)()

		' Current mouse position
		Private mouseLocation As System.Drawing.Point

		' Selected entity, store on LMB click
		Private selEntityIndex As Integer
		Private selEntity As Entity = Nothing

		' Current drawing plane and extension points required while dimensioning
		Private drawingPlane As Plane
		Private extPt1 As Point3D
		Private extPt2 As Point3D

		' Current arc radius
		Private radius, radiusY As Double
		' Current arc span angle
		Private arcSpanAngle As Double

		' Entities for angularDim with lines
		Public FirstLine As Line = Nothing
		Public SecondLine As Line = Nothing
		Public QuadrantPoint As Point3D = Nothing

		'Threshold to unerstand if polyline or curve has to be closed or not
		Private Const magnetRange As Integer = 3

		'Label to show wich operation is currently selected
		Private activeOperationLabel As String = ""

		'label to show how to exit from a command (visible just in case an operation is currently selected)
		Private rmb As String = "  RMB to exit."

		Public Shared DrawingColor As Color = Color.White

        Private Shared Function AreParallel(l1 As Line, l2 As Line) As Boolean
            Dim d1 As Vector3D = l1.Direction
            d1.Normalize()
            Dim d2 As Vector3D = l2.Direction
            d2.Normalize()
            Return Vector3D.AreParallel(d1, d2)
        End Function

		Protected Overrides Sub OnMouseDown(ByVal e As Windows.Forms.MouseEventArgs)
			Me.selEntityIndex = GetEntityUnderMouseCursor(e.Location)

			If waitingForSelection Then
				If Me.selEntityIndex <> -1 Then
					If selEntity Is Nothing OrElse drawingAngularDim Then
						Me.selEntity = Me.Entities(selEntityIndex)
						If activeOperationLabel <> "" Then
							Me.selEntity.Selected = True
						End If
					End If

					' drawingAngularDim from lines needs more than one selection
					If Not drawingAngularDim OrElse TypeOf Me.Entities(selEntityIndex) Is Arc Then
						waitingForSelection = False
					End If
				End If

			End If
			Cursor.Show()

			If ActiveViewport.ToolBar.Contains(e.Location) Then
				MyBase.OnMouseDown(e)

				Return
			End If

'			#Region "Handle LMB Clicks "
			If ActionMode = actionType.None AndAlso e.Button = MouseButtons.Left Then
				' we need to skip adding points for entity selection click
				editingMode = doingOffset OrElse doingMirror OrElse doingExtend OrElse doingTrim OrElse doingFillet OrElse doingChamfer OrElse doingTangents

				ScreenToPlane(e.Location, plane, current)

                If objectSnapEnabled AndAlso mySnapPoint IsNot Nothing Then
                    If Not (editingMode AndAlso firstClick) Then
                        points.Add(mySnapPoint)
                    End If
                ElseIf IsPolygonClosed() Then 'control needed to close curve and polyline when cursor is near the starting point of polyline or curve
                    'if the distance from current point and first point stored is less than given threshold
                    points.Add(DirectCast(points(0).Clone(), Point3D)) 'the point to add to points is the first point stored.
                    current = DirectCast(points(0).Clone(), Point3D)
                ElseIf gridSnapEnabled Then
                    If Not (editingMode AndAlso firstClick) Then
                        SnapToGrid(current)
                        points.Add(current)
                    End If
                Else
                    If Not (editingMode AndAlso firstClick) Then
						points.Add(current)
					End If
				End If
				firstClick = False

				' If drawing points, create and add new point entity on each LMB click
				If drawingPoints Then
					Dim point As devDept.Eyeshot.Entities.Point

                    If objectSnapEnabled AndAlso mySnapPoint IsNot Nothing Then
                        point = New devDept.Eyeshot.Entities.Point(snap)
                    Else
                        point = New devDept.Eyeshot.Entities.Point(current)
					End If

					AddAndRefresh(point, ActiveLayerName)
				ElseIf drawingText Then
					Dim myText As devDept.Eyeshot.Entities.Text = New Text(current, "Sample Text", 5)
					AddAndRefresh(myText, ActiveLayerName)
				ElseIf drawingLeader Then
					If points.Count = 3 Then
						Dim leader As New Leader(devDept.Geometry.Plane.XY, points)
						leader.ArrowheadSize = 3
					AddAndRefresh(leader, DimensionLayerName)

					Dim myText As devDept.Eyeshot.Entities.Text = New Text(DirectCast(current.Clone(), Point3D), "Sample Text", leader.ArrowheadSize)
					AddAndRefresh(myText, DimensionLayerName)

					drawingLeader = False
					End If
				' If LINE drawing is finished, create and add line entity to model
				ElseIf drawingLine AndAlso points.Count = 2 Then
					Dim line As New Line(points(0), points(1))
					AddAndRefresh(line, ActiveLayerName)
					drawingLine = False
				' If CIRCLE drawing is finished, create and add a circle entity to model
				ElseIf drawingCircle AndAlso points.Count = 2 Then
					Dim circle As New Circle(drawingPlane, drawingPlane.Origin, radius)
					AddAndRefresh(circle, ActiveLayerName)

					drawingCircle = False
				' If ARC drawing is finished, create and add an arc entity to model
				' Input - Center and two end points
				ElseIf drawingArc AndAlso points.Count = 3 Then
					Dim arc As New Arc(drawingPlane, drawingPlane.Origin, radius, 0, arcSpanAngle)
					AddAndRefresh(arc, ActiveLayerName)

					drawingArc = False
				' If drawing ellipse, create and add ellipse entity to model
				' Inputs - Ellipse center, End of first axis, End of second axis
				ElseIf drawingEllipse AndAlso points.Count = 3 Then
					Dim ellipse As New Ellipse(drawingPlane, drawingPlane.Origin, radius, radiusY)
					AddAndRefresh(ellipse, ActiveLayerName)

					drawingEllipse = False
				' If EllipticalArc drawing is finished, create and add EllipticalArc entity to model
				' Input - Ellipse center, End of first axis, End of second axis, end point
				ElseIf drawingEllipticalArc AndAlso points.Count = 4 Then
					Dim ellipticalArc As New EllipticalArc(drawingPlane, drawingPlane.Origin, radius, radiusY, 0, arcSpanAngle, True)
					AddAndRefresh(ellipticalArc, ActiveLayerName)

					drawingEllipticalArc = False
				ElseIf drawingLinearDim AndAlso points.Count = 3 Then
					Dim linearDim As New LinearDim(drawingPlane, points(0), points(1), current, dimTextHeight)
				AddAndRefresh(linearDim, DimensionLayerName)

				drawingLinearDim = False
				ElseIf drawingAlignedDim AndAlso points.Count = 3 Then
					Dim alignedDim As New LinearDim(drawingPlane, points(0), points(1), current, dimTextHeight)
				AddAndRefresh(alignedDim, DimensionLayerName)

				drawingAlignedDim = False
				ElseIf drawingOrdinateDim AndAlso points.Count = 2 Then
					Dim ordinateDim As New OrdinateDim(devDept.Geometry.Plane.XY, points(0), points(1), drawingOrdinateDimVertical, dimTextHeight)
				AddAndRefresh(ordinateDim, DimensionLayerName)

				drawingOrdinateDim = False
				ElseIf (drawingRadialDim OrElse drawingDiametricDim) AndAlso points.Count = 2 Then

					If TypeOf selEntity Is Circle Then
						Dim circle As Circle = TryCast(selEntity, Circle)

						' ensures that radialDim plane has always the correct normal
						Dim orientedCircle As New Circle(devDept.Geometry.Plane.XY, circle.Center, circle.Radius)

						If drawingRadialDim Then
							Dim radialDim As New RadialDim(orientedCircle, points(points.Count - 1), dimTextHeight)
						AddAndRefresh(radialDim, DimensionLayerName)
						drawingRadialDim = False
						Else
							Dim diametricDim As New DiametricDim(orientedCircle, points(points.Count - 1), dimTextHeight)
						AddAndRefresh(diametricDim, DimensionLayerName)
						drawingDiametricDim = False
						End If
					End If
				ElseIf drawingAngularDim Then
					If Not drawingAngularDimFromLines Then
						If TypeOf selEntity Is Arc AndAlso points.Count = 2 AndAlso Not drawingQuadrantPoint Then
							Dim arc As Arc = TryCast(selEntity, Arc)
							Dim myPlane As Plane = DirectCast(arc.Plane.Clone(), Plane)
							Dim startPoint As Point3D = arc.StartPoint
							Dim endPoint As Point3D = arc.EndPoint

							' checks if the Arc is clockwise                            
							If Utility.IsOrientedClockwise(arc.Vertices) Then
								myPlane.Flip()
								startPoint = arc.EndPoint
								endPoint = arc.StartPoint
							End If

							Dim angularDim As New AngularDim(myPlane, startPoint, endPoint, points(points.Count - 1), dimTextHeight)

						AddAndRefresh(angularDim, DimensionLayerName)
						drawingAngularDim = False
						End If
					End If

					' If it's not time to set quadrantPoint, adds the lines for angular dim
					If TypeOf selEntity Is Line AndAlso Not drawingQuadrantPoint AndAlso QuadrantPoint Is Nothing Then
						Dim selectedLine As Line = CType(selEntity, Line)

						If FirstLine Is Nothing Then
							FirstLine = selectedLine
						ElseIf SecondLine Is Nothing AndAlso Not ReferenceEquals(FirstLine, selectedLine)  AndAlso Not AreParallel(firstLine, selectedLine) Then
							SecondLine = selectedLine
							drawingQuadrantPoint = True
							' resets points to get only the quadrant point and text position point
							points.Clear()
						End If

						drawingAngularDimFromLines = True
					ElseIf drawingQuadrantPoint Then
						ScreenToPlane(e.Location, plane, QuadrantPoint)
						drawingQuadrantPoint = False
					'if all parameters are present, gets angular dim
					ElseIf points.Count = 2 AndAlso QuadrantPoint IsNot Nothing Then
                        AddAndRefresh(_dimension, DimensionLayerName)

					    drawingAngularDim = False
						drawingAngularDimFromLines = False
					End If
				ElseIf doingOffset AndAlso points.Count = 1 Then
					CreateOffsetEntity()
					ClearAllPreviousCommandData()
				ElseIf doingMirror AndAlso points.Count = 2 AndAlso selEntity IsNot Nothing Then
					CreateMirrorEntity()
					ClearAllPreviousCommandData()
				ElseIf doingExtend AndAlso firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
					ExtendEntity()
					ClearAllPreviousCommandData()
				ElseIf doingTrim AndAlso firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
					TrimEntity()
					ClearAllPreviousCommandData()
				ElseIf doingFillet AndAlso firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
					CreateFilletEntity()
					ClearAllPreviousCommandData()
				ElseIf doingChamfer AndAlso firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
					CreateChamferEntity()
					ClearAllPreviousCommandData()
				ElseIf doingTangents AndAlso firstSelectedEntity IsNot Nothing AndAlso secondSelectedEntity IsNot Nothing Then
					CreateTangentEntity()
					ClearAllPreviousCommandData()
				ElseIf doingMove AndAlso points.Count = 2 Then
					If points.Count = 2 Then
						For Each ent As Entity In Me.SelEntities
							Dim movement As New Vector3D(points(0), points(1))
							ent.Translate(movement)
						Next ent

						Entities.Regen()
						ClearAllPreviousCommandData()
					End If
				ElseIf doingRotate Then
					If points.Count = 3 Then
						For Each ent As Entity In Me.SelEntities
							ent.Rotate(arcSpanAngle, Vector3D.AxisZ, points(0))
						Next ent

						Entities.Regen()
						ClearAllPreviousCommandData()
					End If
				ElseIf doingScale Then
					If points.Count = 3 Then
						For Each ent As Entity In Me.SelEntities
							ent.Scale(points(0), scaleFactor)
						Next ent

						Entities.Regen()
						ClearAllPreviousCommandData()
					End If
				End If
'			#End Region

'			#Region "Handle RMB Clicks"
			ElseIf e.Button = MouseButtons.Right Then
				ScreenToPlane(e.Location, plane, current)

				If drawingPoints Then
					points.Clear()
					drawingPoints = False
				ElseIf drawingText Then
					drawingText = False
				ElseIf drawingLeader Then
					drawingLeader = False
				' If drawing polyline, create and add LinearPath entity to model
				ElseIf drawingPolyLine Then
					Dim lp As New LinearPath(points)
					AddAndRefresh(lp, ActiveLayerName)

					drawingPolyLine = False
				' If drawing spline, create and add curve entity to model
				ElseIf drawingCurve Then
				    If ProductEdition <> licenseType.Pro Then
					    Dim curve As Curve = devDept.Eyeshot.Entities.Curve.CubicSplineInterpolation(points)
					    AddAndRefresh(curve, ActiveLayerName)
                    End If
					drawingCurve = False
				Else
					ClearAllPreviousCommandData()
				End If
			End If
'			#End Region

			MyBase.OnMouseDown(e)
		End Sub

		
		Private currentlySnapping As Boolean = False
		Private snapPoints() As SnapPoint

		Private cursorOutside As Boolean

		Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
			cursorOutside = True
			MyBase.OnMouseLeave(e)

			Invalidate()

		End Sub

		Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
			cursorOutside = False
			MyBase.OnMouseEnter(e)
		End Sub

		Private _dimension As Dimension
		Protected Overrides Sub OnMouseMove(ByVal e As Windows.Forms.MouseEventArgs)
			' save the current mouse position
			mouseLocation = e.Location

			' If ObjectSnap is ON, we need to find closest vertex (if any)
			If objectSnapEnabled Then
                Me.mySnapPoint = Nothing
                snapPoints = GetSnapPoints(mouseLocation)
			End If

			' if start is valid and actionMode is None and it's not in the toolbar area
			If current Is Nothing OrElse ActionMode <> actionType.None OrElse ActiveViewport.ToolBar.Contains(mouseLocation) Then
				MyBase.OnMouseMove(e)

				Return
			End If

			' paint the viewport surface
			PaintBackBuffer()

			' consolidates the drawing
			SwapBuffers()

			If drawingPoints Then
				activeOperationLabel = "Points: "
			ElseIf drawingText Then
				activeOperationLabel = "Text: "
			ElseIf drawingLeader Then
				activeOperationLabel = "Leader: "
			ElseIf drawingLine Then
				activeOperationLabel = "Line: "
			ElseIf drawingEllipse Then
				activeOperationLabel = "Ellipse: "
			ElseIf drawingEllipticalArc Then
				activeOperationLabel = "EllipticalArc: "
			ElseIf drawingCircle Then
				activeOperationLabel = "Circle: "
			ElseIf drawingArc Then
				activeOperationLabel = "Arc: "
			ElseIf drawingPolyLine Then
				activeOperationLabel = "Polyline: "
			ElseIf drawingCurve Then
				activeOperationLabel = "Spline: "
			ElseIf doingMirror Then
				activeOperationLabel = "Mirror: "
			ElseIf doingOffset Then
				activeOperationLabel = "Offset: "
			ElseIf doingTrim Then
				activeOperationLabel = "Trim: "
			ElseIf doingExtend Then
				activeOperationLabel = "Extend: "
			ElseIf doingFillet Then
				activeOperationLabel = "Fillet: "
			ElseIf doingChamfer Then
				activeOperationLabel = "Chamfer: "
			ElseIf doingTangents Then
				activeOperationLabel = "Tangents: "
			ElseIf doingMove Then
				activeOperationLabel = "Move: "
			ElseIf doingRotate Then
				activeOperationLabel = "Rotate: "
			ElseIf doingScale Then
				activeOperationLabel = "Scale: "
			Else
				activeOperationLabel = ""
			End If

			MyBase.OnMouseMove(e)

		End Sub

		Private snap As SnapPoint

		friend Sub DrawOverlay(ByVal myParams As Design.DrawSceneParams)
		    If IsDesignMode() Then
		        Return
            End If

		    ScreenToPlane(mouseLocation, plane, current)

			currentlySnapping = False

			' If ObjectSnap is ON, we need to find closest vertex (if any)
			If objectSnapEnabled AndAlso snapPoints IsNot Nothing AndAlso snapPoints.Length > 0 Then
				snap = FindClosestPoint(snapPoints)
				current = snap
				currentlySnapping = True
			End If

			' set GL for interactive draw or elastic line 
			RenderContext.SetLineSize(1)

			RenderContext.EnableXOR(True)

			RenderContext.SetState(depthStencilStateType.DepthTestOff)

			If Not (currentlySnapping) AndAlso Not (waitingForSelection) AndAlso ActionMode = actionType.None AndAlso Not (doingExtend OrElse doingTrim OrElse doingFillet OrElse doingChamfer OrElse doingTangents OrElse drawingOrdinateDim) AndAlso Not ObjectManipulator.Visible Then
				If Not cursorOutside Then
					DrawPositionMark(current)
				End If
			End If

			If drawingLine OrElse drawingPolyLine Then
				DrawInteractiveLines()
			ElseIf drawingCircle AndAlso points.Count > 0 Then
				If ActionMode = actionType.None AndAlso Not ActiveViewport.ToolBar.Contains(mouseLocation) Then
					DrawInteractiveCircle()
				End If
			ElseIf drawingArc AndAlso points.Count > 0 Then
				If ActionMode = actionType.None AndAlso Not ActiveViewport.ToolBar.Contains(mouseLocation) Then
					DrawInteractiveArc()
				End If
			ElseIf drawingEllipse AndAlso points.Count > 0 Then
				DrawInteractiveEllipse()
			ElseIf drawingEllipticalArc AndAlso points.Count > 0 Then
				DrawInteractiveEllipticalArc()
			ElseIf drawingCurve Then
				DrawInteractiveCurve()
			ElseIf drawingLeader Then
				DrawInteractiveLeader()
			ElseIf drawingLinearDim OrElse drawingAlignedDim Then
				If points.Count < 2 Then
					If Not cursorOutside Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)
						Dim myText As String = "Select the first point"
						If Not firstClick Then
							myText = "Select the second point"
						End If

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, myText, New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					End If
				Else
					If drawingLinearDim Then
						DrawInteractiveLinearDim()
					ElseIf drawingAlignedDim Then
						DrawInteractiveAlignedDim()
					End If
				End If
			ElseIf drawingOrdinateDim Then
				If Not cursorOutside Then
					If points.Count = 1 Then
						DrawPositionMark(current, 5)
						DrawInteractiveOrdinateDim()
					Else
						DrawPositionMark(current)
						RenderContext.EnableXOR(False)

						Dim myText As String = "Select the definition point"
						If Not firstClick Then
							myText = "Select the leader end point"
						End If

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, myText, New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					End If


				End If
			ElseIf drawingRadialDim OrElse drawingDiametricDim Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)

					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select Arc or Circle", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)

				End If
				DrawInteractiveDiametricDim()
			ElseIf drawingAngularDim Then
				If waitingForSelection Then
					If Not drawingAngularDimFromLines Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select Arc or Line", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					ElseIf QuadrantPoint Is Nothing AndAlso Not drawingQuadrantPoint Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select second Line", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					ElseIf drawingQuadrantPoint Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select a quadrant", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					ElseIf QuadrantPoint IsNot Nothing Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select text position", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					End If
				End If
				DrawInteractiveAngularDim()
			ElseIf doingMirror Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)

					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select entity to mirror", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)
				End If

				CreateMirrorEntity()
			ElseIf doingOffset Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)

					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select entity to offset", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)
				End If
				CreateOffsetEntity()
			ElseIf doingMove Then
				MoveEntity()
			ElseIf doingScale Then
				ScaleEntity()
			ElseIf doingRotate Then
				RotateEntity()
			ElseIf doingFillet Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)

					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select first curve", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)
				End If
				CreateFilletEntity()
			ElseIf doingTangents Then
				If waitingForSelection Then
					If True Then
						DrawSelectionMark(mouseLocation)

						RenderContext.EnableXOR(False)

						DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select first circle", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

						RenderContext.EnableXOR(True)
					End If

				End If
				CreateTangentEntity()
			ElseIf doingChamfer Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)
					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select first curve", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)
				End If
				CreateChamferEntity()
			ElseIf doingExtend Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)
					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select boundary entity", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)

					RenderContext.EnableXOR(True)
				End If
				ExtendEntity()
			ElseIf doingTrim Then
				If waitingForSelection Then
					DrawSelectionMark(mouseLocation)
					RenderContext.EnableXOR(False)

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, "Select trimming entity", New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
					RenderContext.EnableXOR(True)
				End If
				TrimEntity()
			End If

			' disables draw inverted
			RenderContext.EnableXOR(False)


			' text drawing
			If Not (drawingDiametricDim OrElse drawingAlignedDim OrElse drawingLinearDim OrElse drawingOrdinateDim OrElse drawingLeader OrElse drawingRadialDim OrElse drawingAngularDim OrElse doingMirror OrElse doingOffset OrElse doingExtend OrElse doingTrim OrElse doingTangents OrElse doingFillet OrElse doingChamfer OrElse doingMove OrElse doingScale OrElse doingRotate) AndAlso ActionMode = actionType.None Then
				If Not (drawingEllipticalArc AndAlso points.Count >= 3) AndAlso Not cursorOutside Then
					'label on mouse
					Dim exitCommand As String = ""
					If drawingCurve OrElse drawingPolyLine OrElse drawingPoints Then
						exitCommand = rmb
					Else
						exitCommand = ""
					End If

					DrawText(mouseLocation.X, Height - mouseLocation.Y + 10, activeOperationLabel & "X = " & current.X.ToString("f2") & ", " & "Y = " & current.Y.ToString("f2") & exitCommand, New Font("Tahoma", 8.25F), DrawingColor, ContentAlignment.BottomLeft)
				End If
			End If

		End Sub

		''' <summary>
		''' This function gets all the curve entities selected on the screen and create a composite curve as single entity
		''' </summary>
		Public Sub CreateCompositeCurve()
			'list of selected curve
			Dim selectedCurveList As New List(Of ICurve)()

			'for goes backward: in this way we can remove enties at the same time we found it selected
			For i As Integer = Me.Entities.Count - 1 To 0 Step -1
				Dim ent As Entity = Me.Entities(i)

				If ent.Selected AndAlso TypeOf ent Is ICurve AndAlso TypeOf ent Is CompositeCurve = False Then
					selectedCurveList.Add(DirectCast(ent, ICurve))
					'remove the entity we use to create composite curve, in this way we can display only composite curve and not single curves
					Me.Entities.RemoveAt(i)
				End If
			Next i

			If selectedCurveList.Count > 0 Then
				Dim compositeCurve As New CompositeCurve(selectedCurveList)

				AddAndRefresh(compositeCurve, ActiveLayerName)
			End If
		End Sub

		''' <summary>
		''' Clears all previous selections, snapping information etc.
		''' </summary>
		Friend Sub ClearAllPreviousCommandData()
			points.Clear()
			selEntity = Nothing
			selEntityIndex = -1
            mySnapPoint = Nothing
            drawingArc = False
			drawingCircle = False
			drawingCurve = False
			drawingEllipse = False
			drawingEllipticalArc = False
			drawingLine = False
			drawingLinearDim = False
			drawingOrdinateDim = False
			drawingPoints = False
			drawingText = False
			drawingLeader = False
			drawingPolyLine = False
			drawingRadialDim = False
			drawingAlignedDim = False
			drawingQuadrantPoint = False
			drawingAngularDim = False
			drawingAngularDimFromLines = False

			firstClick = True
			doingMirror = False
			doingOffset = False
			doingTrim = False
			doingExtend = False
			doingChamfer = False
			doingMove = False
			doingScale = False
			doingRotate = False
			doingFillet = False
			doingTangents = False
			firstSelectedEntity = Nothing
			secondSelectedEntity = Nothing

			FirstLine = Nothing
			SecondLine = Nothing
			QuadrantPoint = Nothing

			activeOperationLabel = ""
			ActionMode = actionType.None
			Entities.ClearSelection()
			ObjectManipulator.Cancel()
		End Sub
	End Class

