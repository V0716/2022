Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Drawing
Imports devDept.Eyeshot
Imports devDept.Eyeshot.Control

Imports devDept.Geometry
Imports devDept.Eyeshot.Entities
Imports devDept.Graphics


	'
	' Contains methods required for dimensioning different entities.
	' Linear, aligned, radial and diametric dimensioning is supported as of now.
	'
	Partial Friend Class MyDesignUI

		Public PreviewParams As DimensionPreviewDrawParams
		' Draws preview of horizontal/vertical dimension for a line
		Private Sub DrawInteractiveLinearDim()
			' We need to have two reference points selected, might be snapped vertices
			If points.Count < 2 Then
				Return
			End If

		    drawingPlane = DrawLinearDimPreview( Plane.XY, points(0), points(1), mouseLocation, PreviewParams).Plane
		End Sub

		' Draws preview of aligned dimension
		Private Sub DrawInteractiveAlignedDim()
			' We need to have two reference points selected, might be snapped vertices
			If points.Count < 2 Then
				Return
			End If

		    drawingPlane =DrawLinearDimPreview(Plane.XY, new Line(points(0), points(1)), mouseLocation, PreviewParams).Plane
		End Sub

		' Draws preview of ordinate dimension
		Private Sub DrawInteractiveOrdinateDim()
			' We need to have at least one point.
			If points.Count < 1 Then
				Return
			End If

		    DrawOrdinateDimPreview( Plane.XY,points(0), 3.0, 0.625, drawingOrdinateDimVertical , mouseLocation, PreviewParams)
		End Sub

		' Draws preview of radial/diametric dimension with text like R5.25, Ø12.62
		Private Sub DrawInteractiveDiametricDim()
			If selEntityIndex <> -1 Then
				Dim entity As Entity = Me.Entities(selEntityIndex)
				If TypeOf entity Is Circle Then 'arc is a circle
					Dim cicularEntity As Circle = TryCast(entity, Circle)
				    If drawingRadialDim
				        DrawRadialDimPreview(Plane.XY,cicularEntity, mouseLocation, PreviewParams)
        		    Else
            		    DrawDiametricDimPreview(cicularEntity,mouseLocation,PreviewParams)
				    End If
				End If
			End If
		End Sub

		' Draws preview of radial/diametric dimension with text like R5.25, Ø12.62
		Private Sub DrawInteractiveAngularDim()
			If selEntityIndex <> -1 Then
				Dim entity As Entity = Entities(selEntityIndex)

				If TypeOf entity Is Arc AndAlso Not drawingAngularDimFromLines Then
					Dim selectedArc As Arc = TryCast(entity, Arc)
				    DrawAngularDimPreview(selectedArc, mouseLocation, PreviewParams)
				End If
			ElseIf drawingAngularDimFromLines AndAlso secondLine IsNot Nothing Then
			    _dimension = DrawAngularDimPreview( Plane.XY, firstLine, secondLine, mouseLocation, PreviewParams)
			End If
		End Sub

		#Region "Dimensioning Flags"

		Public drawingLinearDim As Boolean

		Public drawingAlignedDim As Boolean

		Public drawingRadialDim As Boolean

		Public drawingDiametricDim As Boolean

		Public drawingAngularDim As Boolean

		Public drawingAngularDimFromLines As Boolean

		Public drawingOrdinateDim As Boolean
		Public drawingOrdinateDimVertical As Boolean

		Public drawingQuadrantPoint As Boolean

		Public dimTextHeight As Double = 2.5

		#End Region
	End Class

