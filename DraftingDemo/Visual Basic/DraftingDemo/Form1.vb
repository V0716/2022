Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports devDept.Eyeshot
Imports devDept.Graphics
Imports devDept.Geometry
Imports devDept.Eyeshot.Entities
Imports devDept.Eyeshot.Control.Labels
Imports System.Text
Imports System.Collections.Generic
Imports System.IO

Imports devDept.Eyeshot.Translators
Imports devDept.Serialization
Imports devDept.CustomControls
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles
Imports devDept.CustomControls.Controls.Drafting
Imports devDept.Eyeshot.Control
Imports devDept.LicenseManager
Imports MouseEventArgs = System.Windows.Forms.MouseEventArgs

Partial Public Class Form1
    Inherits Form

    Private _logoPdf As Bitmap
    Private tangentsForm As TangentsForm
    Private _brJittering As BlockReference

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        ' Event handlers
        AddHandler tableTabControl.LayerListView.SelectedIndexChanged, AddressOf SelectedIndexChanged
        AddHandler design1.SelectionChanged, AddressOf design1_SelectionChanged
        AddHandler design1.WorkCompleted, AddressOf design1_WorkCompleted
        AddHandler design1.WorkCancelled, AddressOf design1_WorkCancelled
        AddHandler design1.WorkFailed, AddressOf design1_WorkFailed
        AddHandler design1.CameraMoveBegin, AddressOf design1_CameraMoveBegin

        AddHandler endRadioButton.CheckedChanged, AddressOf radioButtons_CheckedChanged
        AddHandler midRadioButton.CheckedChanged, AddressOf radioButtons_CheckedChanged
        AddHandler cenRadioButton.CheckedChanged, AddressOf radioButtons_CheckedChanged
        AddHandler pointRadioButton.CheckedChanged, AddressOf radioButtons_CheckedChanged
        AddHandler quadRadioButton.CheckedChanged, AddressOf radioButtons_CheckedChanged

        If ProductEdition = licenseType.Pro Then
            extendButton.Enabled = False
            trimButton.Enabled = False
            filletButton.Enabled = False
            chamferButton.Enabled = False
            splineButton.Enabled = False
        End If

    End Sub

#If SETUP Then
    Private ReadOnly _helper As BitnessAgnostic = New BitnessAgnostic()
#End If

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        AddDashdotsHatchPattern()

        design1.Layers.First().LineWeight = 2
        design1.Layers.First().Color = design1.DrawingColor
        design1.Layers.TryAdd(New Layer("Dimensions", Color.DarkCyan))
        design1.Layers(1).LineWeight = 0.15F
        design1.Layers.TryAdd(New Layer("Reference geometry", Color.Red))
        tableTabControl.Workspace = design1
        design1.ActiveLayerName = design1.Layers.First().Name
        design1.DimensionLayerName = design1.Layers(1).Name

        selectionComboBox.SelectedIndex = 0

        rendererVersionStatusLabel.Text = design1.RendererVersion.ToString()

        design1.SetView(viewType.Top)
        design1.ActiveViewport.Rotate.Enabled = False

        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnResizeBegin(e As EventArgs)
        MyBase.OnResizeBegin(e)

        ' speed up the resize of the control
        design1.ResizeBegin()
    End Sub

    Protected Overrides Sub OnShown(ByVal e As EventArgs)
        design1.Focus()

        EnableControls(True)

        _logoPdf = New Bitmap("../../../../../../dataset/Assets/Pictures/Logo_big.png")

        Dim ra As New ReadAutodesk("../../../../../../dataset/Assets/Misc/app8.dwg")
        design1.StartWork(ra)

        MyBase.OnShown(e)
    End Sub

    Private Sub AddDashdotsHatchPattern()

        ' creates an Hatch Pattern
        Dim dashDotHatchPattern As String = "DASHDOTS"
        Dim hpl = New HatchPatternLine(0, Point2D.Origin, 0, 1, New Single() {5, -1.5F, 0, -1.5F})
        Dim hpl2 = New HatchPatternLine(Utility.PI_2, Point2D.Origin, 0, 1, New Single() {5, -1.5F, 0, -1.5F})
        design1.HatchPatterns.Add(New HatchPattern(dashDotHatchPattern, New HatchPatternLine() {hpl, hpl2}))
    End Sub
#Region "Hide/Show"

    Private Sub showOriginButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showOriginButton.CheckedChanged
        If (design1.Viewports.Count > 0) Then ' This is needed in VB only because the handlers are called during components initialization
            design1.ActiveViewport.OriginSymbol.Visible = showOriginButton.Checked
            design1.Invalidate()
        End If
    End Sub

    Private Sub showExtentsButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showExtentsButton.CheckedChanged
        design1.BoundingBox.Visible = showExtentsButton.Checked
        design1.Invalidate()
    End Sub

    Private Sub showVerticesButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showVerticesButton.CheckedChanged
        design1.ActiveViewport.ShowVertices = showVerticesButton.Checked
        design1.Invalidate()
    End Sub

    Private Sub showGridButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showGridButton.CheckedChanged
        If (design1.Viewports.Count > 0) Then ' This is needed in VB only because the handlers are called during components initialization
            design1.ActiveViewport.Grid.Visible = showGridButton.Checked
            design1.Invalidate()
        End If
    End Sub

#End Region

#Region "Selection "

    Private Sub selectionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles selectionComboBox.SelectedIndexChanged
        groupButton.Enabled = True

        If selectCheckBox.Checked Then

            Selection()
        End If
    End Sub

    Private Sub selectCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles selectCheckBox.CheckedChanged
        groupButton.Enabled = True

        If selectCheckBox.Checked Then
            ClearPreviousSelection()
            Selection()
        Else
            design1.ActionMode = actionType.None
        End If
    End Sub

    Private Sub Selection()
        Select Case selectionComboBox.SelectedIndex
            Case 0 ' by pick
                design1.ActionMode = actionType.SelectByPick

            Case 1 ' by box
                design1.ActionMode = actionType.SelectByBox

            Case 2 ' by poly
                design1.ActionMode = actionType.SelectByPolygon

            Case 3 ' by box enclosed
                design1.ActionMode = actionType.SelectByBoxEnclosed

            Case 4 ' by poly enclosed
                design1.ActionMode = actionType.SelectByPolygonEnclosed

            Case 5 ' visible by pick dynamic
                design1.ActionMode = actionType.SelectVisibleByPickDynamic

            Case Else
                design1.ActionMode = actionType.None
        End Select
    End Sub

    Private Sub clearSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearSelectionButton.Click
        If design1.ActionMode = actionType.SelectVisibleByPickLabel Then

            design1.Viewports(0).Labels.ClearSelection()

        Else

            design1.Entities.ClearSelection()
        End If

        design1.Invalidate()
    End Sub

    Private Sub invertSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles invertSelectionButton.Click
        If design1.ActionMode = actionType.SelectVisibleByPickLabel Then

            design1.Viewports(0).Labels.InvertSelection()

        Else

            design1.Entities.InvertSelection()
        End If

        design1.Invalidate()
    End Sub

    Private Sub groupButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles groupButton.Click
        design1.CurrentBlock.GroupSelection()
    End Sub

#End Region

#Region "Editing"

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteButton.Click
        design1.Entities.DeleteSelected()
        design1.Invalidate()
    End Sub

    Private Sub explodeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles explodeButton.Click

        For i As Integer = design1.Entities.Count - 1 To 0 Step -1

            Dim ent As Entity = design1.Entities(i)

            If ent.Selected Then
                If TypeOf ent Is BlockReference Then

                    design1.Entities.RemoveAt(i)

                    Dim br As BlockReference = CType(ent, BlockReference)

                    Dim entList() As Entity = design1.Entities.Explode(br)

                    design1.Entities.AddRange(entList)


                ElseIf TypeOf ent Is CompositeCurve Then

                    design1.Entities.RemoveAt(i)

                    Dim cc As CompositeCurve = CType(ent, CompositeCurve)

                    design1.Entities.AddRange(cc.Explode())

                ElseIf TypeOf ent Is Hatch Then

                    design1.Entities.RemoveAt(i)

                    Dim ht As Hatch = CType(ent, Hatch)

                    Dim entlist As Entity() = ht.Explode()

                    design1.Entities.AddRange(entlist)

                ElseIf ent.GroupIndex > -1 Then
                    design1.CurrentBlock.Ungroup(ent.GroupIndex)
                End If
            End If
        Next i

        design1.Invalidate()
    End Sub

    Private Sub trimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles trimButton.Click
        ClearPreviousSelection()
        design1.doingTrim = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub extendButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles extendButton.Click
        ClearPreviousSelection()
        design1.doingExtend = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub offsetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles offsetButton.Click
        ClearPreviousSelection()
        design1.doingOffset = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub mirrorButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mirrorButton.Click
        ClearPreviousSelection()
        design1.doingMirror = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub filletButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles filletButton.Click
        ClearPreviousSelection()
        design1.doingFillet = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub chamferButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chamferButton.Click
        ClearPreviousSelection()
        design1.doingChamfer = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub moveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles moveButton.Click
        design1.SelEntities.Clear()

        For i As Integer = design1.Entities.Count - 1 To 0 Step -1
            Dim ent As Entity = design1.Entities(i)
            If ent.Selected AndAlso (TypeOf ent Is ICurve OrElse TypeOf ent Is BlockReference OrElse TypeOf ent Is Text OrElse TypeOf ent Is Leader) Then
                design1.SelEntities.Add(ent)
            End If
        Next i

        If design1.SelEntities.Count = 0 Then
            Return
        End If

        ClearPreviousSelection()
        design1.doingMove = True
        For Each curve As Entity In design1.SelEntities
            curve.Selected = True
        Next curve
        Cursor.Hide()
    End Sub

    Private Sub rotateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rotateButton.Click
        design1.SelEntities.Clear()

        For i As Integer = design1.Entities.Count - 1 To 0 Step -1
            Dim ent As Entity = design1.Entities(i)
            If ent.Selected AndAlso (TypeOf ent Is ICurve OrElse TypeOf ent Is BlockReference OrElse TypeOf ent Is Text OrElse TypeOf ent Is Leader) Then
                design1.SelEntities.Add(ent)
            End If
        Next i

        If design1.SelEntities.Count = 0 Then
            Return
        End If

        ClearPreviousSelection()
        design1.doingRotate = True
        For Each curve As Entity In design1.SelEntities
            curve.Selected = True
        Next curve

        Cursor.Hide()
    End Sub

    Private Sub scaleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles scaleButton.Click
        design1.SelEntities.Clear()

        For i As Integer = design1.Entities.Count - 1 To 0 Step -1
            Dim ent As Entity = design1.Entities(i)
            If ent.Selected AndAlso (TypeOf ent Is ICurve OrElse TypeOf ent Is BlockReference OrElse TypeOf ent Is Text OrElse TypeOf ent Is Leader) Then
                design1.SelEntities.Add(ent)
            End If
        Next i

        If design1.SelEntities.Count = 0 Then
            Return
        End If

        ClearPreviousSelection()
        design1.doingScale = True
        For Each curve As Entity In design1.SelEntities
            curve.Selected = True
        Next curve

        Cursor.Hide()
    End Sub

    Private Sub tangentsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tangentsButton.Click
        tangentsForm = New TangentsForm()
        tangentsForm.StartPosition = FormStartPosition.CenterParent
        tangentsForm.FormBorderStyle = FormBorderStyle.FixedDialog

        If tangentsForm.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            design1.lineTangents = tangentsForm.LineTangents

            design1.circleTangents = tangentsForm.CircleTangents

            design1.tangentsRadius = tangentsForm.TangentRadius

            design1.trimTangent = tangentsForm.TrimTangents

            design1.flipTangent = tangentsForm.FlipTangents

            ClearPreviousSelection()

            design1.doingTangents = True

            design1.WaitingForSelection = True

            Cursor.Hide()
        End If


    End Sub

    Private Sub hatchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles hatchButton.Click
        Dim selectedCurveList As List(Of ICurve) = New List(Of ICurve)()

        For i As Integer = 0 To design1.Entities.Count - 1
            Dim ent As Entity = design1.Entities(i)
            If ent.Selected And TypeOf ent Is ICurve Then
                Dim selCurve As ICurve = CType(ent, ICurve)
                If selCurve.IsClosed Then
                    selectedCurveList.Add(selCurve)
                End If
            End If
        Next

        If selectedCurveList.Count > 0 Then
            Dim dotsHatch As Hatch = New Hatch(design1.HatchPatterns(0).Name, selectedCurveList, Plane.XY) With {.PatternAngle = Utility.QUARTER_PI}
            design1.Entities.Add(dotsHatch, design1.ActiveLayerName)
            design1.Entities.ClearSelection()
            design1.Invalidate()
        Else
            MessageBox.Show("Please, select at least one closed curve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub
#End Region

#Region "Inspection"

    Private inspectVertex As Boolean

    Private Sub pickVertexButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pickVertexButton.Click

        design1.ActionMode = actionType.None
        selectCheckBox.Checked = False

        inspectVertex = False

        If pickVertexButton.Checked Then
            inspectVertex = True

            mainStatusLabel.Text = "Click on the entity to retrieve the 3D coordinates"

        Else
            mainStatusLabel.Text = ""
        End If
    End Sub

    Private Sub viewport1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles design1.MouseClick

        ' Checks that we are not using left mouse button for ZPR
        If design1.ActionMode = actionType.None Then

            selectCheckBox.Checked = False
            Dim closest As Point3D = Nothing

            If inspectVertex Then

                If design1.FindClosestVertex(e.Location, 50, closest) <> -1 Then

                    design1.ActiveViewport.Labels.Add(New devDept.Eyeshot.Control.Labels.LeaderAndText(closest, closest.ToString(), New System.Drawing.Font("Tahoma", 8.25F), design1.DrawingColor, New Vector2D(0, 50)))
                End If

            End If

            design1.Invalidate()

        End If


    End Sub

    Private Sub dumpButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dumpButton.Click
        For i As Integer = 0 To design1.Entities.Count - 1
            If design1.Entities(i).Selected Then
                Dim details As String = "Entity ID = " & i & System.Environment.NewLine & "----------------------" & System.Environment.NewLine & design1.Entities(i).Dump()

                Dim rf As New DetailsForm()

                rf.Text = "Dump"

                rf.contentTextBox.Text = details

                rf.Show()

                Exit For
            End If
        Next i
    End Sub

    Private Sub areaButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles areaButton.Click

        Dim ap As New AreaProperties()

        Dim count As Integer = 0

        For i As Integer = 0 To design1.Entities.Count - 1

            Dim ent As Entity = design1.Entities(i)

            If ent.Selected Then
                Dim itfCurve As ICurve = DirectCast(ent, ICurve)

                If itfCurve.IsClosed Then

                    ap.Add(ent.Vertices)
                End If

                count += 1
            End If

        Next i


        Dim myText As New StringBuilder()
        myText.AppendLine(count & " entity(ies) selected")
        myText.AppendLine("---------------------")

        If ap.Centroid IsNot Nothing Then

            Dim x As Double = Nothing, y As Double = Nothing, z As Double = Nothing
            Dim xx As Double = Nothing, yy As Double = Nothing, zz As Double = Nothing, xy As Double = Nothing, zx As Double = Nothing, yz As Double = Nothing
            Dim world As MomentOfInertia = Nothing, centroid As MomentOfInertia = Nothing

            ap.GetResults(ap.Area, ap.Centroid, x, y, z, xx, yy, zz, xy, zx, yz, world, centroid)

            myText.AppendLine("Cumulative area: " & ap.Area & " square " & design1.CurrentBlock.Units.ToString().ToLower())
            myText.AppendLine("Cumulative centroid: " & ap.Centroid.ToString())
            myText.AppendLine("Cumulative area moments:")
            myText.AppendLine(" First moments")
            myText.AppendLine("  x: " & x.ToString("g6"))
            myText.AppendLine("  y: " & y.ToString("g6"))
            myText.AppendLine("  z: " & z.ToString("g6"))
            myText.AppendLine(" Second moments")
            myText.AppendLine("  xx: " & xx.ToString("g6"))
            myText.AppendLine("  yy: " & yy.ToString("g6"))
            myText.AppendLine("  zz: " & zz.ToString("g6"))
            myText.AppendLine(" Product moments")
            myText.AppendLine("  xy: " & xx.ToString("g6"))
            myText.AppendLine("  yz: " & yy.ToString("g6"))
            myText.AppendLine("  zx: " & zz.ToString("g6"))
            myText.AppendLine(" Area Moments of Inertia about World Coordinate Axes")
            myText.AppendLine("  Ix: " & world.Ix.ToString("g6"))
            myText.AppendLine("  Iy: " & world.Iy.ToString("g6"))
            myText.AppendLine("  Iz: " & world.Iz.ToString("g6"))
            myText.AppendLine(" Area Radii of Gyration about World Coordinate Axes")
            myText.AppendLine("  Rx: " & world.Rx.ToString("g6"))
            myText.AppendLine("  Ry: " & world.Ry.ToString("g6"))
            myText.AppendLine("  Rz: " & world.Rz.ToString("g6"))
            myText.AppendLine(" Area Moments of Inertia about Centroid Coordinate Axes:")
            myText.AppendLine("  Ix: " & centroid.Ix.ToString("g6"))
            myText.AppendLine("  Iy: " & centroid.Iy.ToString("g6"))
            myText.AppendLine("  Iz: " & centroid.Iz.ToString("g6"))
            myText.AppendLine(" Area Radii of Gyration about Centroid Coordinate Axes")
            myText.AppendLine("  Rx: " & centroid.Rx.ToString("g6"))
            myText.AppendLine("  Ry: " & centroid.Ry.ToString("g6"))
            myText.AppendLine("  Rz: " & centroid.Rz.ToString("g6"))

        End If

        Dim rf As New DetailsForm()

        rf.Text = "Area Properties"

        rf.contentTextBox.Text = myText.ToString()

        rf.Show()
    End Sub

#End Region

#Region "Read/Write"

    Private _yAxisUp As Boolean = False
    Private _jittering As Boolean = False
    Private _insertAsBlock As Boolean = False

    Private Sub OpenButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openButton.Click
        _yAxisUp = False
        _jittering = False
        Dim readFile As ReadFile = ImportExportHelper.ShowOpenDialog(_insertAsBlock, True)
        If readFile Is Nothing Then Return

        If Not _insertAsBlock Then
            design1.Clear()
            AddDashdotsHatchPattern()
        End If

        EnableControls(False)
        design1.StartWork(readFile)
    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveButton.Click
        Dim writeFile As WriteFile = ImportExportHelper.ShowSaveDialog(design1)
        If writeFile IsNot Nothing Then
            design1.StartWork(writeFile)
            EnableControls(False)
        End If
    End Sub

    Private Sub importButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles importButton.Click
        Dim fileName As String = Nothing
        ImportExportHelper.ShowImportDialog(importFormats.Autodesk, fileName, _yAxisUp, _jittering, _insertAsBlock)
        If fileName IsNot Nothing Then
            Dim rfa As ReadFileAsync = GetReader(fileName)
            If Not _insertAsBlock Then
                design1.Clear()
                AddDashdotsHatchPattern()
            End If
            EnableControls(False)
            If (rfa IsNot Nothing) Then
                design1.StartWork(rfa)
            End If
        End If
    End Sub

    Private Function GetReader(ByVal fileName As String) As ReadFileAsync
        Dim ext As String = Path.GetExtension(fileName)

        If Not String.IsNullOrEmpty(ext) Then
            ext = ext.TrimStart("."c).ToLower()

            Select Case ext
                Case "dwg", "dxf"
                    Dim ra As ReadAutodesk = New ReadAutodesk(fileName)
                    Return ra
                Case "dwf", "dwfx"
                    Dim rd As ReadDWF = New ReadDWF(fileName)
                    Return rd
            End Select
        End If

        Return ImportExportHelper.GetImportReader(fileName)
    End Function

    Private Sub exportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exportButton.Click
        Dim fileName As String = Nothing
        ImportExportHelper.ShowExportDialog(design1, exportFormats.Autodesk, fileName)
        If Not String.IsNullOrEmpty(fileName) Then
            Dim wfa As WriteFileAsync = GetWriter(design1, fileName)
            If wfa IsNot Nothing Then
                EnableControls(False)
                design1.startWork(wfa)
            End If
        End If
    End Sub

    Public Function GetWriter(ByVal design As Design, ByVal fileName As String) As WriteFileAsync
        Dim wfa As WriteFileAsync = Nothing
        Dim ext As String = Path.GetExtension(fileName)

        If ext IsNot Nothing Then
            ext = ext.TrimStart("."c).ToLower()

            Select Case ext
                Case "dxf", "dwg"
                    Dim dataParams As WriteParams = New WriteAutodeskParams(design.Document, Nothing, False, False, 1.0R, Not design.IsOpenRootLevel)
                    wfa = New WriteAutodesk(CType(dataParams, WriteAutodeskParams), fileName)
                Case "pdf"
                    Dim writeParams = New Write3DPdfParams(design1.Document, New Size(842, 595), New Rectangle(20, 40, 802, 495), False, Not design.IsOpenRootLevel) With
                    {
                        .ViewBorderWidth = 0,
                        .BackGroundColor = design.ActiveViewport.Background.TopColor
                    }
                    wfa = New MyWrite3DPDF(writeParams, fileName, _logoPdf)
                Case Else
                    wfa = ImportExportHelper.GetExportWriter(fileName, design)
            End Select
        End If

        Return wfa
    End Function

    Private Sub EnableControls(ByVal status As Boolean)
        For Each control As Control In Controls
            If TypeOf control Is Design = False Then
                control.Enabled = status
            End If
        Next control

        If ProductEdition = licenseType.Pro Then
            extendButton.Enabled = False
            trimButton.Enabled = False
            filletButton.Enabled = False
            chamferButton.Enabled = False
            splineButton.Enabled = False
        End If
    End Sub
#End Region

#Region "Event handlers"
    Private _skipZoomFit As Boolean

    Private Sub design1_WorkCompleted(ByVal sender As Object, ByVal e As devDept.WorkCompletedEventArgs)
        ' checks the WorkUnit type, more than one can be present in the same application 
        If TypeOf e.WorkUnit Is ReadFileAsync Then
            _brJittering = Nothing
            Dim rfa As ReadFileAsync = CType(e.WorkUnit, ReadFileAsync)

            Dim rf As ReadFile = TryCast(e.WorkUnit, ReadFile)
            If rf IsNot Nothing Then
                _skipZoomFit = rf.Camera IsNot Nothing
            Else
                _skipZoomFit = False
            End If

            If rfa.Entities IsNot Nothing AndAlso _yAxisUp Then
                rfa.RotateEverythingAroundX()
            End If

            If _insertAsBlock Then
                _brJittering = ImportExportHelper.InsertAsBlock(design1, rfa, New RegenOptions() With {
                                 .Async = True
                                 })
                _skipZoomFit = False

            Else
                rfa.AddTo(design1)
            End If

            If _jittering AndAlso _insertAsBlock Then
                design1.RemoveJittering(_brJittering)
            ElseIf _jittering Then
                design1.Entities.SelectAll()
                design1.RemoveJittering()
            End If

            If TypeOf rfa Is ReadPDF Then
                Dim readPdf = TryCast(rfa, ReadPDF)

                For Each ent In readPdf.Pages(0).Entities
                    If ent.Color.ToArgb().Equals(CType(design1.ActiveViewport.Background,devDept.Eyeshot.Control.BackGroundSettings).TopColor.ToArgb()) Then ent.Color = Color.White
                Next
            End If

            tableTabControl.Sync()
            If Path.GetFileName(rfa.FileName) = "app8.dwg" Then
                For Each ent As Entity In design1.Entities
                    ent.Translate(-170, -400)
                Next
                design1.Entities.Regen()
                design1.ActiveViewport.Camera.Target = New Point3D(60, 2.5, 0)
                design1.ActiveViewport.Camera.ZoomFactor = 2
                _skipZoomFit = True
            End If

            design1.Layers(0).LineWeight = 2
            design1.Layers(0).Color = design1.DrawingColor
            design1.Layers.TryAdd(New Layer("Dimensions", Color.ForestGreen))
            design1.Layers.TryAdd(New Layer("Reference geometry", Color.Red))
            tableTabControl.Sync()

            If Not _skipZoomFit Then
                design1.SetView(viewType.Top, True, False)
            End If
        End If

        If Not String.IsNullOrEmpty(e.WorkUnit.Log) Then tableTabControl.ShowLog($"{e.WorkUnit.[GetType]().Name} log", e.WorkUnit.Log)

        EnableControls(True)
    End Sub

    Private Sub design1_WorkFailed(ByVal sender As Object, ByVal e As devDept.WorkFailedEventArgs)
        If TypeOf e.Exception Is OutOfMemoryException Then
            MessageBox.Show("This demo relies on OpenDesign libraries for DWG/DXF export and it is currently compiled against x86. Using the x64 version, this problem will disappear.", "Out of Memory", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
        EnableControls(True)
    End Sub

    Private Sub design1_WorkCancelled(ByVal sender As Object, ByVal e As EventArgs)
        EnableControls(True)
    End Sub

    Private Sub design1_CameraMoveBegin(ByVal sender As Object, ByVal e As devDept.Eyeshot.Control.CameraMoveEventArgs)
        ' refresh FastZPR button according to FastZPR enable status.
        UpdateTurboButton()
    End Sub

    Private _maxComplexity As Integer = 30000
    Private Sub turboButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles turboButton.CheckedChanged
        If turboButton.CheckState = CheckState.Unchecked Then
            _maxComplexity = design1.Turbo.MaxComplexity
            design1.Turbo.MaxComplexity = Integer.MaxValue
        Else
            design1.Turbo.MaxComplexity = _maxComplexity
        End If

        design1.UpdateBoundingBox()
        UpdateTurboButton()
        design1.Invalidate()
    End Sub

    Private Sub UpdateTurboButton()
        If design1.Turbo.Enabled Then
            Me.turboButton.BackColor = System.Drawing.Color.LightGreen
            turboButton.UseVisualStyleBackColor = False
        Else
            Me.turboButton.BackColor = System.Drawing.Color.Black
            turboButton.UseVisualStyleBackColor = True
        End If
    End Sub

    Private Sub websiteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles websiteButton.Click
        System.Diagnostics.Process.Start("www.devdept.com")
    End Sub

    Private Sub design1_SelectionChanged(ByVal sender As Object, ByVal e As devDept.Eyeshot.Control.SelectionChangedEventArgs)

        Dim count As Integer = 0

        ' counts selected entities
        For Each ent As Entity In design1.Entities

            If ent.Selected Then

                count += 1
            End If
        Next ent

        ' updates count on the status bar
        selectedCountStatusLabel.Text = count.ToString()
        addedCountStatusLabel.Text = e.AddedItems.Count.ToString()
        removedCountStatusLabel.Text = e.RemovedItems.Count.ToString()

    End Sub
    Private Sub radioButtons_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        If endRadioButton.Checked Then

            design1.ActiveObjectSnap = devDept.CustomControls.Controls.Drafting.objectSnapType.End

        ElseIf midRadioButton.Checked Then

            design1.ActiveObjectSnap = devDept.CustomControls.Controls.Drafting.objectSnapType.Mid

        ElseIf cenRadioButton.Checked Then

            design1.ActiveObjectSnap = devDept.CustomControls.Controls.Drafting.objectSnapType.Center

        ElseIf quadRadioButton.Checked Then

            design1.ActiveObjectSnap = devDept.CustomControls.Controls.Drafting.objectSnapType.Quad

        ElseIf pointRadioButton.Checked Then

            design1.ActiveObjectSnap = devDept.CustomControls.Controls.Drafting.objectSnapType.Point
        End If

    End Sub

    Private Sub filletTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles filletTextBox.TextChanged
        If design1 Is Nothing Then
            Return
        End If

        Dim val As Double = Nothing
        If Double.TryParse(filletTextBox.Text, val) Then
            design1.filletRadius = val
        End If
    End Sub

    Private Sub showCurveDirectionButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showCurveDirectionButton.CheckedChanged
        design1.ShowCurveDirection = showCurveDirectionButton.Checked
        design1.Invalidate()
    End Sub

#End Region

#Region "Imaging"

    Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printButton.Click
        design1.Print()
    End Sub

    Private Sub printPreviewButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printPreviewButton.Click
        design1.PrintPreview(New Size(500, 400))
    End Sub

    Private Sub pageSetupButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pageSetupButton.Click
        design1.PageSetup()
    End Sub

    Private Sub vectorCopyToClipbardButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vectorCopyToClipbardButton.Click
        design1.CopyToClipboardVector(False)

        'set capture property to false, otherwise the first mouse click is skipped
        vectorCopyToClipbardButton.Capture = False
    End Sub

    Private Sub vectorSaveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vectorSaveButton.Click
        Dim mySaveFileDialog As New SaveFileDialog()

        mySaveFileDialog.Filter = "Enhanced Windows Metafile (*.emf)|*.emf"
        mySaveFileDialog.RestoreDirectory = True

        If mySaveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' To save as dxf/dwg, see the class HiddenLinesViewOnFileAutodesk available in x86 and x64 dlls
            design1.WriteToFileVector(False, mySaveFileDialog.FileName)

            'set capture property to false, otherwise the first mouse click is skipped
            vectorSaveButton.Capture = False
        End If
    End Sub

#End Region

#Region "Drafting"

    Private Sub pointButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pointButton.Click
        ClearPreviousSelection()
        design1.drawingPoints = True

    End Sub

    Private Sub textButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles textButton.Click
        ClearPreviousSelection()
        design1.drawingText = True
    End Sub

    Private Sub leaderButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles leaderButton.Click
        ClearPreviousSelection()
        design1.drawingLeader = True
    End Sub

    Private Sub lineButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lineButton.Click
        ClearPreviousSelection()
        design1.drawingLine = True
    End Sub

    Private Sub poliLineButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles plineButton.Click
        ClearPreviousSelection()
        design1.drawingPolyLine = True
    End Sub

    Private Sub arcButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles arcButton.Click
        ClearPreviousSelection()
        design1.drawingArc = True
    End Sub

    Private Sub circleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles circleButton.Click
        ClearPreviousSelection()
        design1.drawingCircle = True
    End Sub

    Private Sub splineButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles splineButton.Click
        ClearPreviousSelection()
        design1.drawingCurve = True
    End Sub

    Private Sub ellipseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ellipseButton.Click
        ClearPreviousSelection()
        design1.drawingEllipse = True
    End Sub

    Private Sub ellipticalArcButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ellipticalArcButton.Click
        ClearPreviousSelection()
        design1.drawingEllipticalArc = True
    End Sub

    Private Sub compositeCurveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles compositeCurveButton.Click
        design1.CreateCompositeCurve()
    End Sub

    Private Sub objectSnapCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles objectSnapCheckBox.CheckedChanged
        If objectSnapCheckBox.Checked Then
            design1.ObjectSnapEnabled = True
            snapPanel.Enabled = True
        Else
            design1.ObjectSnapEnabled = False
            snapPanel.Enabled = False
        End If
    End Sub

    Private Sub gridSnapCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gridSnapCheckBox.CheckedChanged
        If gridSnapCheckBox.Checked Then
            design1.GridSnapEnabled = True
        Else
            design1.GridSnapEnabled = False
        End If
    End Sub

    Private Sub linearDimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinearDimButton.Click
        ClearPreviousSelection()
        design1.drawingLinearDim = True
    End Sub

    Private Sub ordinateVerticalButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ordinateVerticalButton.Click
        ClearPreviousSelection()
        design1.drawingOrdinateDim = True
        design1.drawingOrdinateDimVertical = True
    End Sub

    Private Sub ordinateHorizontalButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ordinateHorizontalButton.Click
        ClearPreviousSelection()
        design1.drawingOrdinateDim = True
        design1.drawingOrdinateDimVertical = False
    End Sub

    Private Sub radialDimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadialDimButton.Click
        ClearPreviousSelection()
        design1.drawingRadialDim = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub diametricDimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DiametricDimButton.Click
        ClearPreviousSelection()
        design1.drawingDiametricDim = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub alignedDimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles alignedDimButton.Click
        ClearPreviousSelection()
        design1.drawingAlignedDim = True
    End Sub

    Private Sub angularDimButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles angularDimButton.Click
        ClearPreviousSelection()
        design1.drawingAngularDim = True
        design1.WaitingForSelection = True
        Cursor.Hide()
    End Sub

    Private Sub ClearPreviousSelection()
        design1.SetView(viewType.Top, False, True)
        design1.ClearAllPreviousCommandData()
    End Sub

#End Region

#Region "Layers"

    Private Sub CreateLayerBitmap(ByVal color As Color)
        Dim bmp As New Bitmap(16, 16)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(color), 2, 2, 12, 12)
            g.DrawRectangle(Pens.Black, 2, 2, 12, 12)
        End Using
        imageList1.Images.Add(bmp)
    End Sub

    Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If tableTabControl.LayerListView.SelectedItems.Count > 0 Then
            design1.ActiveLayerName = tableTabControl.LayerListView.SelectedItem.Text
        Else ' nothing selected? we force layer zero
            design1.ActiveLayerName = design1.Layers(0).Name
        End If
    End Sub

#End Region

End Class

Public Class MyWrite3DPDF
    Inherits Write3DPDF

    Private _logo As Bitmap

    Public Sub New(ByVal writeParams As Write3DPdfParams, ByVal fileName As String, ByVal logo As Bitmap)
        MyBase.New(writeParams, fileName)
        _logo = logo
    End Sub

    Public Sub New(ByVal writeParams As Write3DPdfParams, ByVal stream As IO.Stream, ByVal logo As Bitmap)
        MyBase.New(writeParams, stream)
        _logo = logo
    End Sub

    Protected Overrides Sub BuildDocument()
        ' Add a page
        Dim pageIndex As Integer = AddPage(paperSize.Width, paperSize.Height)

        ' Add the 3D view of the model
        AddDesign(pageIndex, viewRect, backGroundColor, transparentBackground, borderWidth, toolbarVisibility, renderingMode, "Default", "Default")

        ' Add frame and line
        AddFrame(pageIndex, New Point2D(20, 20), New Point2D(822, 575), Color.Black)
        AddLine(pageIndex, New Point2D(20, 40), New Point2D(822, 40), Color.Black)
        AddLine(pageIndex, New Point2D(20, 535), New Point2D(822, 535), Color.Black)

        ' Add logo
        AddImage(pageIndex, _logo, New Rectangle(30, 543, 88, 20))

        ' Add header text
        AddText(pageIndex, System.IO.Path.GetFileNameWithoutExtension(FileName), New Rectangle(390, 548, 80, 20), Color.Black, standardFontsType.HelveticaBold, 15)

        ' Add footer text
        AddText(pageIndex, "Generated by a .NET application based on Eyeshot, from devDept Software S.r.l. (www.devdept.com)", New Rectangle(30, 27, 80, 10), Color.Black, standardFontsType.Helvetica, 10)
        AddText(pageIndex, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"), New Rectangle(720, 27, 80, 10), Color.Black, standardFontsType.Helvetica, 10)
    End Sub
End Class

''' <summary>
''' Represents a vertex type from model like center, mid point, etc.
''' </summary>
Public Enum objectSnapType
    None
    Point
    [End]
    Mid
    Center
    Quad
End Enum

