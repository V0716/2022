Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports devDept.CustomControls
Imports devDept.CustomControls.Controls.Drafting
Imports devDept.Graphics

Partial Public Class Form1
    Inherits System.Windows.Forms.Form
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DisplayModeSettingsRendered1 As devDept.Eyeshot.Control.DisplayModeSettingsRendered = New devDept.Eyeshot.Control.DisplayModeSettingsRendered(True, devDept.Eyeshot.edgeColorMethodType.SingleColor, System.Drawing.Color.Black, 1.0!, 2.0!, devDept.Eyeshot.silhouettesDrawingType.ImageBased, False, devDept.Graphics.shadowType.Planar, Nothing, False, False, 0.3!, devDept.Graphics.realisticShadowQualityType.High)
        Dim BackgroundSettings1 As devDept.Eyeshot.Control.BackgroundSettings = New devDept.Eyeshot.Control.BackgroundSettings(devDept.Graphics.backgroundStyleType.Solid, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Black, 0.75R, Nothing, devDept.Eyeshot.colorThemeType.[Auto], 0.3R)
        Dim Camera1 As devDept.Eyeshot.Camera = New devDept.Eyeshot.Camera(New devDept.Geometry.Point3D(0R, 0R, 45.0R), 600.0R, New devDept.Geometry.Quaternion(0.086824088833465166R, 0.15038373318043533R, 0.492403876506104R, 0.85286853195244339R), devDept.Eyeshot.projectionType.Orthographic, 50.0R, 1.5R, False)
        Dim HomeToolBarButton1 As devDept.Eyeshot.Control.HomeToolBarButton = New devDept.Eyeshot.Control.HomeToolBarButton("Home", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, True, True)
        Dim MagnifyingGlassToolBarButton1 As devDept.Eyeshot.Control.MagnifyingGlassToolBarButton = New devDept.Eyeshot.Control.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
        Dim ZoomWindowToolBarButton1 As devDept.Eyeshot.Control.ZoomWindowToolBarButton = New devDept.Eyeshot.Control.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
        Dim ZoomToolBarButton1 As devDept.Eyeshot.Control.ZoomToolBarButton = New devDept.Eyeshot.Control.ZoomToolBarButton("Zoom", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
        Dim PanToolBarButton1 As devDept.Eyeshot.Control.PanToolBarButton = New devDept.Eyeshot.Control.PanToolBarButton("Pan", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
        Dim RotateToolBarButton1 As devDept.Eyeshot.Control.RotateToolBarButton = New devDept.Eyeshot.Control.RotateToolBarButton("Rotate", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
        Dim ZoomFitToolBarButton1 As devDept.Eyeshot.Control.ZoomFitToolBarButton = New devDept.Eyeshot.Control.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, True, True)
        Dim ToolBar1 As devDept.Eyeshot.Control.ToolBar = New devDept.Eyeshot.Control.ToolBar(devDept.Eyeshot.Control.ToolBar.positionType.HorizontalTopCenter, True, New devDept.Eyeshot.Control.ToolBarButton() {CType(HomeToolBarButton1, devDept.Eyeshot.Control.HomeToolBarButton), CType(MagnifyingGlassToolBarButton1, devDept.Eyeshot.Control.ToolBarButton), CType(ZoomWindowToolBarButton1, devDept.Eyeshot.Control.ZoomWindowToolBarButton), CType(ZoomToolBarButton1, devDept.Eyeshot.Control.ZoomToolBarButton), CType(PanToolBarButton1, devDept.Eyeshot.Control.PanToolBarButton), CType(RotateToolBarButton1, devDept.Eyeshot.Control.RotateToolBarButton), CType(ZoomFitToolBarButton1, devDept.Eyeshot.Control.ZoomFitToolBarButton)})
        Dim Grid1 As devDept.Eyeshot.Control.Grid = New devDept.Eyeshot.Control.Grid(New devDept.Geometry.Point2D(-100.0R, -100.0R), New devDept.Geometry.Point2D(100.0R, 100.0R), 10.0R, New devDept.Geometry.Plane(New devDept.Geometry.Point3D(0R, 0R, 0R), New devDept.Geometry.Vector3D(0R, 0R, 1.0R)), System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer)), False, True, False, False, 10, 100, 10, System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer)), System.Drawing.Color.Transparent, False, System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer)))
        Dim OriginSymbol1 As devDept.Eyeshot.Control.OriginSymbol = New devDept.Eyeshot.Control.OriginSymbol(10, devDept.Eyeshot.Control.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", True, Nothing, False)
        Dim RotateSettings1 As devDept.Eyeshot.Control.RotateSettings = New devDept.Eyeshot.Control.RotateSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.None), 10.0R, True, 1.0R, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, New devDept.Geometry.Point3D(0R, 0R, 0R), False)
        Dim ZoomSettings1 As devDept.Eyeshot.Control.ZoomSettings = New devDept.Eyeshot.Control.ZoomSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Shift), 25, True, devDept.Eyeshot.zoomStyleType.AtCursorLocation, False, 1.0R, System.Drawing.Color.DeepSkyBlue, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, False, 10, True)
        Dim PanSettings1 As devDept.Eyeshot.Control.PanSettings = New devDept.Eyeshot.Control.PanSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl), 25, True)
        Dim NavigationSettings1 As devDept.Eyeshot.Control.NavigationSettings = New devDept.Eyeshot.Control.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Left, devDept.Eyeshot.Control.modifierKeys.None), New devDept.Geometry.Point3D(-1000.0R, -1000.0R, -1000.0R), New devDept.Geometry.Point3D(1000.0R, 1000.0R, 1000.0R), 8.0R, 50.0R, 50.0R)
        Dim Viewport1 As devDept.Eyeshot.Control.Viewport = New devDept.Eyeshot.Control.Viewport(New System.Drawing.Point(0, 0), New System.Drawing.Size(639, 495), BackgroundSettings1, Camera1, New devDept.Eyeshot.Control.ToolBar() {ToolBar1}, devDept.Eyeshot.displayType.Wireframe, True, False, False, False, New devDept.Eyeshot.Control.Grid() {Grid1}, New devDept.Eyeshot.Control.OriginSymbol() {OriginSymbol1}, False, RotateSettings1, ZoomSettings1, PanSettings1, NavigationSettings1, devDept.Eyeshot.viewType.Top)
        Dim CoordinateSystemIcon1 As devDept.Eyeshot.Control.CoordinateSystemIcon = New devDept.Eyeshot.Control.CoordinateSystemIcon(System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer)), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", True, devDept.Eyeshot.Control.coordinateSystemPositionType.BottomLeft, 37, False)
        Dim ViewCubeIcon1 As devDept.Eyeshot.Control.ViewCubeIcon = New devDept.Eyeshot.Control.ViewCubeIcon(devDept.Eyeshot.Control.coordinateSystemPositionType.TopRight, False, System.Drawing.Color.DodgerBlue, True, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(77, Byte), Integer)), Global.Microsoft.VisualBasic.ChrW(83), Global.Microsoft.VisualBasic.ChrW(78), Global.Microsoft.VisualBasic.ChrW(87), Global.Microsoft.VisualBasic.ChrW(69), True, System.Drawing.Color.White, System.Drawing.Color.Black, 120, True, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.printPreviewButton = New System.Windows.Forms.Button()
        Me.invertSelectionButton = New System.Windows.Forms.Button()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.showVerticesButton = New System.Windows.Forms.CheckBox()
        Me.showExtentsButton = New System.Windows.Forms.CheckBox()
        Me.showOriginButton = New System.Windows.Forms.CheckBox()
        Me.printButton = New System.Windows.Forms.Button()
        Me.pageSetupButton = New System.Windows.Forms.Button()
        Me.websiteButton = New System.Windows.Forms.Button()
        Me.mainStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.springToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.readWriteProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.rendererVersionStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.selectedCountStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.addedCountStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.removedCountStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.shadingLabel = New System.Windows.Forms.Label()
        Me.hideShowLabel = New System.Windows.Forms.Label()
        Me.selectionLabel = New System.Windows.Forms.Label()
        Me.editingLabel = New System.Windows.Forms.Label()
        Me.tableTabControl = New devDept.CustomControls.TableTabControl()
        Me.pickVertexButton = New System.Windows.Forms.CheckBox()
        Me.inspectionLabel = New System.Windows.Forms.Label()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.showGridButton = New System.Windows.Forms.CheckBox()
        Me.dumpButton = New System.Windows.Forms.Button()
        Me.vectorSaveButton = New System.Windows.Forms.Button()
        Me.vectorCopyToClipbardButton = New System.Windows.Forms.Button()
        Me.zoomSelButton = New System.Windows.Forms.Button()
        Me.vectorLabel = New System.Windows.Forms.Label()
        Me.miscLabel = New System.Windows.Forms.Label()
        Me.explodeButton = New System.Windows.Forms.Button()
        Me.areaButton = New System.Windows.Forms.Button()
        Me.groupButton = New System.Windows.Forms.Button()
        Me.selectionComboBox = New System.Windows.Forms.ComboBox()
        Me.clearSelectionButton = New System.Windows.Forms.Button()
        Me.selectCheckBox = New System.Windows.Forms.CheckBox()
        Me.lineButton = New System.Windows.Forms.Button()
        Me.arcButton = New System.Windows.Forms.Button()
        Me.circleButton = New System.Windows.Forms.Button()
        Me.splineButton = New System.Windows.Forms.Button()
        Me.plineButton = New System.Windows.Forms.Button()
        Me.pointButton = New System.Windows.Forms.Button()
        Me.objectSnapCheckBox = New System.Windows.Forms.CheckBox()
        Me.gridSnapCheckBox = New System.Windows.Forms.CheckBox()
        Me.LinearDimButton = New System.Windows.Forms.Button()
        Me.RadialDimButton = New System.Windows.Forms.Button()
        Me.DiametricDimButton = New System.Windows.Forms.Button()
        Me.dimLabel = New System.Windows.Forms.Label()
        Me.ellipseButton = New System.Windows.Forms.Button()
        Me.alignedDimButton = New System.Windows.Forms.Button()
        Me.ellipticalArcButton = New System.Windows.Forms.Button()
        Me.snappingLabel = New System.Windows.Forms.Label()
        Me.angularDimButton = New System.Windows.Forms.Button()
        Me.compositeCurveButton = New System.Windows.Forms.Button()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.design1 = New Drafting2D()
        Me.endRadioButton = New System.Windows.Forms.RadioButton()
        Me.midRadioButton = New System.Windows.Forms.RadioButton()
        Me.cenRadioButton = New System.Windows.Forms.RadioButton()
        Me.pointRadioButton = New System.Windows.Forms.RadioButton()
        Me.quadRadioButton = New System.Windows.Forms.RadioButton()
        Me.snapPanel = New System.Windows.Forms.Panel()
        Me.mirrorButton = New System.Windows.Forms.Button()
        Me.offsetButton = New System.Windows.Forms.Button()
        Me.trimButton = New System.Windows.Forms.Button()
        Me.extendButton = New System.Windows.Forms.Button()
        Me.filletButton = New System.Windows.Forms.Button()
        Me.chamferButton = New System.Windows.Forms.Button()
        Me.filletTextBox = New System.Windows.Forms.TextBox()
        Me.fillRadLabel = New System.Windows.Forms.Label()
        Me.textButton = New System.Windows.Forms.Button()
        Me.showCurveDirectionButton = New System.Windows.Forms.CheckBox()
        Me.ordinateVerticalButton = New System.Windows.Forms.Button()
        Me.ordinateHorizontalButton = New System.Windows.Forms.Button()
        Me.leaderButton = New System.Windows.Forms.Button()
        Me.moveButton = New System.Windows.Forms.Button()
        Me.rotateButton = New System.Windows.Forms.Button()
        Me.scaleButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.openButton = New System.Windows.Forms.Button()
        Me.importButton = New System.Windows.Forms.Button()
        Me.exportButton = New System.Windows.Forms.Button()
        Me.turboButton = New System.Windows.Forms.CheckBox()
        Me.tangentsButton = New System.Windows.Forms.Button()
        Me.hatchButton = New System.Windows.Forms.Button()
        Me.statusStrip1.SuspendLayout()
        CType(Me.design1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.snapPanel.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' printPreviewButton
        ' 
        Me.printPreviewButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.printPreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.printPreviewButton.Location = New System.Drawing.Point(683, 597)
        Me.printPreviewButton.Name = "printPreviewButton"
        Me.printPreviewButton.Size = New System.Drawing.Size(79, 22)
        Me.printPreviewButton.TabIndex = 1
        Me.printPreviewButton.Text = "Print Preview"
        Me.printPreviewButton.UseVisualStyleBackColor = False
        ' 
        ' invertSelectionButton
        ' 
        Me.invertSelectionButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.invertSelectionButton.Location = New System.Drawing.Point(519, 357)
        Me.invertSelectionButton.Name = "invertSelectionButton"
        Me.invertSelectionButton.Size = New System.Drawing.Size(78, 22)
        Me.invertSelectionButton.TabIndex = 24
        Me.invertSelectionButton.Text = "Invert"
        Me.invertSelectionButton.UseVisualStyleBackColor = True
        ' 
        ' deleteButton
        ' 
        Me.deleteButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.deleteButton.Location = New System.Drawing.Point(519, 407)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(78, 22)
        Me.deleteButton.TabIndex = 26
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
        ' 
        ' showVerticesButton
        ' 
        Me.showVerticesButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.showVerticesButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.showVerticesButton.Location = New System.Drawing.Point(683, 289)
        Me.showVerticesButton.Name = "showVerticesButton"
        Me.showVerticesButton.Size = New System.Drawing.Size(78, 22)
        Me.showVerticesButton.TabIndex = 29
        Me.showVerticesButton.Text = "Vertices"
        Me.showVerticesButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.showVerticesButton.UseVisualStyleBackColor = True
        ' 
        ' showExtentsButton
        ' 
        Me.showExtentsButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.showExtentsButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.showExtentsButton.Location = New System.Drawing.Point(601, 289)
        Me.showExtentsButton.Name = "showExtentsButton"
        Me.showExtentsButton.Size = New System.Drawing.Size(78, 22)
        Me.showExtentsButton.TabIndex = 28
        Me.showExtentsButton.Text = "Extents"
        Me.showExtentsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.showExtentsButton.UseVisualStyleBackColor = True
        ' 
        ' showOriginButton
        ' 
        Me.showOriginButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.showOriginButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.showOriginButton.Checked = True
        Me.showOriginButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showOriginButton.Location = New System.Drawing.Point(519, 289)
        Me.showOriginButton.Name = "showOriginButton"
        Me.showOriginButton.Size = New System.Drawing.Size(78, 22)
        Me.showOriginButton.TabIndex = 27
        Me.showOriginButton.Text = "Origin"
        Me.showOriginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.showOriginButton.UseVisualStyleBackColor = True
        ' 
        ' printButton
        ' 
        Me.printButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.printButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.printButton.Location = New System.Drawing.Point(766, 597)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(77, 22)
        Me.printButton.TabIndex = 32
        Me.printButton.Text = "Print"
        Me.printButton.UseVisualStyleBackColor = False
        ' 
        ' pageSetupButton
        ' 
        Me.pageSetupButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.pageSetupButton.Location = New System.Drawing.Point(519, 622)
        Me.pageSetupButton.Name = "pageSetupButton"
        Me.pageSetupButton.Size = New System.Drawing.Size(78, 22)
        Me.pageSetupButton.TabIndex = 33
        Me.pageSetupButton.Text = "Page Setup"
        Me.pageSetupButton.UseVisualStyleBackColor = True
        ' 
        ' websiteButton
        ' 
        Me.websiteButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.websiteButton.Location = New System.Drawing.Point(520, 698)
        Me.websiteButton.Name = "websiteButton"
        Me.websiteButton.Size = New System.Drawing.Size(78, 22)
        Me.websiteButton.TabIndex = 38
        Me.websiteButton.Text = "Website"
        Me.websiteButton.UseVisualStyleBackColor = True
        ' 
        ' mainStatusLabel
        ' 
        Me.mainStatusLabel.Name = "mainStatusLabel"
        Me.mainStatusLabel.Size = New System.Drawing.Size(552, 20)
        Me.mainStatusLabel.Text = "Middle Mouse Button = Rotate, Ctrl + Middle = Pan, Shift + Middle = Zoom, Mouse W" & "heel = Zoom +/-"
        ' 
        ' springToolStripStatusLabel
        ' 
        Me.springToolStripStatusLabel.Name = "springToolStripStatusLabel"
        Me.springToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.springToolStripStatusLabel.Size = New System.Drawing.Size(11, 20)
        Me.springToolStripStatusLabel.Spring = True
        ' 
        ' readWriteProgressBar
        ' 
        Me.readWriteProgressBar.Name = "readWriteProgressBar"
        Me.readWriteProgressBar.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.readWriteProgressBar.Size = New System.Drawing.Size(105, 19)
        Me.readWriteProgressBar.Visible = False
        ' 
        ' rendererVersionStatusLabel
        ' 
        Me.rendererVersionStatusLabel.AutoSize = False
        Me.rendererVersionStatusLabel.AutoToolTip = True
        Me.rendererVersionStatusLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rendererVersionStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                                                            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                                                           Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.rendererVersionStatusLabel.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.rendererVersionStatusLabel.Name = "rendererVersionStatusLabel"
        Me.rendererVersionStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.rendererVersionStatusLabel.Size = New System.Drawing.Size(64, 20)
        Me.rendererVersionStatusLabel.Text = "1.0"
        Me.rendererVersionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rendererVersionStatusLabel.ToolTipText = "Renderer Version"
        ' 
        ' selectedCountStatusLabel
        ' 
        Me.selectedCountStatusLabel.AutoSize = False
        Me.selectedCountStatusLabel.AutoToolTip = True
        Me.selectedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.selectedCountStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                                                          Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                                                         Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.selectedCountStatusLabel.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.selectedCountStatusLabel.Name = "selectedCountStatusLabel"
        Me.selectedCountStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.selectedCountStatusLabel.Size = New System.Drawing.Size(64, 20)
        Me.selectedCountStatusLabel.Text = "0"
        Me.selectedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.selectedCountStatusLabel.ToolTipText = "Selected count"
        ' 
        ' addedCountStatusLabel
        ' 
        Me.addedCountStatusLabel.AutoSize = False
        Me.addedCountStatusLabel.AutoToolTip = True
        Me.addedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.addedCountStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                                                       Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                                                      Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.addedCountStatusLabel.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.addedCountStatusLabel.Name = "addedCountStatusLabel"
        Me.addedCountStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.addedCountStatusLabel.Size = New System.Drawing.Size(64, 20)
        Me.addedCountStatusLabel.Text = "0"
        Me.addedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.addedCountStatusLabel.ToolTipText = "Added to selection count"
        ' 
        ' removedCountStatusLabel
        ' 
        Me.removedCountStatusLabel.AutoSize = False
        Me.removedCountStatusLabel.AutoToolTip = True
        Me.removedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.removedCountStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                                                         Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                                                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.removedCountStatusLabel.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.removedCountStatusLabel.Name = "removedCountStatusLabel"
        Me.removedCountStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.removedCountStatusLabel.Size = New System.Drawing.Size(64, 20)
        Me.removedCountStatusLabel.Text = "0"
        Me.removedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.removedCountStatusLabel.ToolTipText = "Removed from selection count"
        ' 
        ' shadingLabel
        ' 
        Me.shadingLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.shadingLabel.AutoSize = True
        Me.shadingLabel.Location = New System.Drawing.Point(519, 11)
        Me.shadingLabel.Name = "shadingLabel"
        Me.shadingLabel.Size = New System.Drawing.Size(44, 13)
        Me.shadingLabel.TabIndex = 54
        Me.shadingLabel.Text = "Drafting"
        ' 
        ' hideShowLabel
        ' 
        Me.hideShowLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.hideShowLabel.AutoSize = True
        Me.hideShowLabel.Location = New System.Drawing.Point(519, 273)
        Me.hideShowLabel.Name = "hideShowLabel"
        Me.hideShowLabel.Size = New System.Drawing.Size(61, 13)
        Me.hideShowLabel.TabIndex = 58
        Me.hideShowLabel.Text = "Hide/Show"
        ' 
        ' selectionLabel
        ' 
        Me.selectionLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.selectionLabel.AutoSize = True
        Me.selectionLabel.Location = New System.Drawing.Point(519, 314)
        Me.selectionLabel.Name = "selectionLabel"
        Me.selectionLabel.Size = New System.Drawing.Size(51, 13)
        Me.selectionLabel.TabIndex = 59
        Me.selectionLabel.Text = "Selection"
        ' 
        ' editingLabel
        ' 
        Me.editingLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.editingLabel.AutoSize = True
        Me.editingLabel.Location = New System.Drawing.Point(518, 391)
        Me.editingLabel.Name = "editingLabel"
        Me.editingLabel.Size = New System.Drawing.Size(39, 13)
        Me.editingLabel.TabIndex = 60
        Me.editingLabel.Text = "Editing"
        ' 
        ' tableTabControl
        ' 
        Me.tableTabControl.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.tableTabControl.Location = New System.Drawing.Point(12, 713)
        Me.tableTabControl.Margin = New System.Windows.Forms.Padding(0)
        Me.tableTabControl.Name = "tableTabControl"
        Me.tableTabControl.SelectedIndex = 0
        Me.tableTabControl.Size = New System.Drawing.Size(501, 143)
        Me.tableTabControl.TabIndex = 170
        ' 
        ' pickVertexButton
        ' 
        Me.pickVertexButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.pickVertexButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.pickVertexButton.Location = New System.Drawing.Point(519, 551)
        Me.pickVertexButton.Name = "pickVertexButton"
        Me.pickVertexButton.Size = New System.Drawing.Size(78, 22)
        Me.pickVertexButton.TabIndex = 76
        Me.pickVertexButton.Text = "Pick Vertex"
        Me.pickVertexButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.pickVertexButton.UseVisualStyleBackColor = True
        ' 
        ' inspectionLabel
        ' 
        Me.inspectionLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.inspectionLabel.AutoSize = True
        Me.inspectionLabel.Location = New System.Drawing.Point(519, 534)
        Me.inspectionLabel.Name = "inspectionLabel"
        Me.inspectionLabel.Size = New System.Drawing.Size(142, 13)
        Me.inspectionLabel.TabIndex = 75
        Me.inspectionLabel.Text = "Inspection / Mass Properties"
        ' 
        ' imageList1
        ' 
        Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        ' 
        ' showGridButton
        ' 
        Me.showGridButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.showGridButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.showGridButton.Checked = True
        Me.showGridButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showGridButton.Location = New System.Drawing.Point(765, 289)
        Me.showGridButton.Name = "showGridButton"
        Me.showGridButton.Size = New System.Drawing.Size(78, 22)
        Me.showGridButton.TabIndex = 79
        Me.showGridButton.Text = "Grid"
        Me.showGridButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.showGridButton.UseVisualStyleBackColor = True
        ' 
        ' dumpButton
        ' 
        Me.dumpButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.dumpButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dumpButton.Location = New System.Drawing.Point(683, 551)
        Me.dumpButton.Name = "dumpButton"
        Me.dumpButton.Size = New System.Drawing.Size(79, 22)
        Me.dumpButton.TabIndex = 84
        Me.dumpButton.Text = "Dump"
        Me.dumpButton.UseVisualStyleBackColor = False
        ' 
        ' vectorSaveButton
        ' 
        Me.vectorSaveButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.vectorSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.vectorSaveButton.Location = New System.Drawing.Point(601, 597)
        Me.vectorSaveButton.Name = "vectorSaveButton"
        Me.vectorSaveButton.Size = New System.Drawing.Size(78, 22)
        Me.vectorSaveButton.TabIndex = 86
        Me.vectorSaveButton.Text = "Save"
        Me.vectorSaveButton.UseVisualStyleBackColor = False
        ' 
        ' vectorCopyToClipbardButton
        ' 
        Me.vectorCopyToClipbardButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.vectorCopyToClipbardButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.vectorCopyToClipbardButton.Location = New System.Drawing.Point(519, 597)
        Me.vectorCopyToClipbardButton.Name = "vectorCopyToClipbardButton"
        Me.vectorCopyToClipbardButton.Size = New System.Drawing.Size(78, 22)
        Me.vectorCopyToClipbardButton.TabIndex = 85
        Me.vectorCopyToClipbardButton.Text = "Copy"
        Me.vectorCopyToClipbardButton.UseVisualStyleBackColor = False
        ' 
        ' zoomSelButton
        ' 
        Me.zoomSelButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.zoomSelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.zoomSelButton.Location = New System.Drawing.Point(582, 202)
        Me.zoomSelButton.Name = "zoomSelButton"
        Me.zoomSelButton.Size = New System.Drawing.Size(78, 22)
        Me.zoomSelButton.TabIndex = 82
        Me.zoomSelButton.Text = "Zoom Sel."
        Me.zoomSelButton.UseVisualStyleBackColor = False
        ' 
        ' vectorLabel
        ' 
        Me.vectorLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.vectorLabel.AutoSize = True
        Me.vectorLabel.Location = New System.Drawing.Point(519, 581)
        Me.vectorLabel.Name = "vectorLabel"
        Me.vectorLabel.Size = New System.Drawing.Size(38, 13)
        Me.vectorLabel.TabIndex = 92
        Me.vectorLabel.Text = "Vector"
        ' 
        ' miscLabel
        ' 
        Me.miscLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.miscLabel.AutoSize = True
        Me.miscLabel.Location = New System.Drawing.Point(519, 653)
        Me.miscLabel.Name = "miscLabel"
        Me.miscLabel.Size = New System.Drawing.Size(74, 13)
        Me.miscLabel.TabIndex = 93
        Me.miscLabel.Text = "Miscellaneous"
        ' 
        ' explodeButton
        ' 
        Me.explodeButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.explodeButton.Location = New System.Drawing.Point(601, 407)
        Me.explodeButton.Name = "explodeButton"
        Me.explodeButton.Size = New System.Drawing.Size(78, 22)
        Me.explodeButton.TabIndex = 95
        Me.explodeButton.Text = "Explode"
        Me.explodeButton.UseVisualStyleBackColor = True
        ' 
        ' areaButton
        ' 
        Me.areaButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.areaButton.Location = New System.Drawing.Point(601, 551)
        Me.areaButton.Name = "areaButton"
        Me.areaButton.Size = New System.Drawing.Size(78, 22)
        Me.areaButton.TabIndex = 102
        Me.areaButton.Text = "Area"
        Me.areaButton.UseVisualStyleBackColor = True
        ' 
        ' groupButton
        ' 
        Me.groupButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.groupButton.Location = New System.Drawing.Point(601, 357)
        Me.groupButton.Name = "groupButton"
        Me.groupButton.Size = New System.Drawing.Size(78, 22)
        Me.groupButton.TabIndex = 104
        Me.groupButton.Text = "Group"
        Me.groupButton.UseVisualStyleBackColor = True
        ' 
        ' selectionComboBox
        ' 
        Me.selectionComboBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.selectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectionComboBox.Items.AddRange(New Object() {"by Pick", "by Box", "by Polygon", "by Box Enclosed", "by Polygon Enclosed", "Visible by Pick Dynamic"})
        Me.selectionComboBox.Location = New System.Drawing.Point(520, 331)
        Me.selectionComboBox.Name = "selectionComboBox"
        Me.selectionComboBox.Size = New System.Drawing.Size(158, 21)
        Me.selectionComboBox.TabIndex = 120
        ' 
        ' clearSelectionButton
        ' 
        Me.clearSelectionButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.clearSelectionButton.Location = New System.Drawing.Point(765, 330)
        Me.clearSelectionButton.Name = "clearSelectionButton"
        Me.clearSelectionButton.Size = New System.Drawing.Size(78, 22)
        Me.clearSelectionButton.TabIndex = 23
        Me.clearSelectionButton.Text = "Clear"
        Me.clearSelectionButton.UseVisualStyleBackColor = True
        ' 
        ' selectCheckBox
        ' 
        Me.selectCheckBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.selectCheckBox.Appearance = System.Windows.Forms.Appearance.Button
        Me.selectCheckBox.Location = New System.Drawing.Point(683, 330)
        Me.selectCheckBox.Name = "selectCheckBox"
        Me.selectCheckBox.Size = New System.Drawing.Size(78, 22)
        Me.selectCheckBox.TabIndex = 121
        Me.selectCheckBox.Text = "Select"
        Me.selectCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.selectCheckBox.UseVisualStyleBackColor = True
        ' 
        ' lineButton
        ' 
        Me.lineButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.lineButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lineButton.Location = New System.Drawing.Point(600, 28)
        Me.lineButton.Name = "lineButton"
        Me.lineButton.Size = New System.Drawing.Size(78, 22)
        Me.lineButton.TabIndex = 122
        Me.lineButton.Text = "Line"
        Me.lineButton.UseVisualStyleBackColor = True
        ' 
        ' arcButton
        ' 
        Me.arcButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.arcButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.arcButton.Location = New System.Drawing.Point(519, 55)
        Me.arcButton.Name = "arcButton"
        Me.arcButton.Size = New System.Drawing.Size(78, 22)
        Me.arcButton.TabIndex = 123
        Me.arcButton.Text = "Arc"
        Me.arcButton.UseVisualStyleBackColor = True
        ' 
        ' circleButton
        ' 
        Me.circleButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.circleButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.circleButton.Location = New System.Drawing.Point(764, 28)
        Me.circleButton.Name = "circleButton"
        Me.circleButton.Size = New System.Drawing.Size(78, 22)
        Me.circleButton.TabIndex = 124
        Me.circleButton.Text = "Circle"
        Me.circleButton.UseVisualStyleBackColor = True
        ' 
        ' splineButton
        ' 
        Me.splineButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.splineButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.splineButton.Location = New System.Drawing.Point(600, 55)
        Me.splineButton.Name = "splineButton"
        Me.splineButton.Size = New System.Drawing.Size(78, 22)
        Me.splineButton.TabIndex = 125
        Me.splineButton.Text = "Spline"
        Me.splineButton.UseVisualStyleBackColor = True
        ' 
        ' plineButton
        ' 
        Me.plineButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.plineButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.plineButton.Location = New System.Drawing.Point(683, 28)
        Me.plineButton.Name = "plineButton"
        Me.plineButton.Size = New System.Drawing.Size(78, 22)
        Me.plineButton.TabIndex = 126
        Me.plineButton.Text = "PolyLine"
        Me.plineButton.UseVisualStyleBackColor = True
        ' 
        ' pointButton
        ' 
        Me.pointButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.pointButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pointButton.Location = New System.Drawing.Point(519, 28)
        Me.pointButton.Name = "pointButton"
        Me.pointButton.Size = New System.Drawing.Size(78, 22)
        Me.pointButton.TabIndex = 127
        Me.pointButton.Text = "Points"
        Me.pointButton.UseVisualStyleBackColor = True
        ' 
        ' objectSnapCheckBox
        ' 
        Me.objectSnapCheckBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.objectSnapCheckBox.Appearance = System.Windows.Forms.Appearance.Button
        Me.objectSnapCheckBox.Location = New System.Drawing.Point(519, 211)
        Me.objectSnapCheckBox.Name = "objectSnapCheckBox"
        Me.objectSnapCheckBox.Size = New System.Drawing.Size(78, 22)
        Me.objectSnapCheckBox.TabIndex = 128
        Me.objectSnapCheckBox.Text = "Object Snap"
        Me.objectSnapCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.objectSnapCheckBox.UseVisualStyleBackColor = True
        ' 
        ' gridSnapCheckBox
        ' 
        Me.gridSnapCheckBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.gridSnapCheckBox.Appearance = System.Windows.Forms.Appearance.Button
        Me.gridSnapCheckBox.Location = New System.Drawing.Point(599, 211)
        Me.gridSnapCheckBox.Name = "gridSnapCheckBox"
        Me.gridSnapCheckBox.Size = New System.Drawing.Size(78, 22)
        Me.gridSnapCheckBox.TabIndex = 129
        Me.gridSnapCheckBox.Text = "Grid Snap"
        Me.gridSnapCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gridSnapCheckBox.UseVisualStyleBackColor = True
        ' 
        ' LinearDimButton
        ' 
        Me.LinearDimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.LinearDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinearDimButton.Location = New System.Drawing.Point(520, 133)
        Me.LinearDimButton.Name = "LinearDimButton"
        Me.LinearDimButton.Size = New System.Drawing.Size(78, 22)
        Me.LinearDimButton.TabIndex = 0
        Me.LinearDimButton.Text = "Linear"
        Me.LinearDimButton.UseVisualStyleBackColor = True
        ' 
        ' RadialDimButton
        ' 
        Me.RadialDimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.RadialDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RadialDimButton.Location = New System.Drawing.Point(683, 133)
        Me.RadialDimButton.Name = "RadialDimButton"
        Me.RadialDimButton.Size = New System.Drawing.Size(78, 22)
        Me.RadialDimButton.TabIndex = 1
        Me.RadialDimButton.Text = "Radial"
        Me.RadialDimButton.UseVisualStyleBackColor = True
        ' 
        ' DiametricDimButton
        ' 
        Me.DiametricDimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.DiametricDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DiametricDimButton.Location = New System.Drawing.Point(764, 133)
        Me.DiametricDimButton.Name = "DiametricDimButton"
        Me.DiametricDimButton.Size = New System.Drawing.Size(78, 22)
        Me.DiametricDimButton.TabIndex = 2
        Me.DiametricDimButton.Text = "Diametric"
        Me.DiametricDimButton.UseVisualStyleBackColor = True
        ' 
        ' dimLabel
        ' 
        Me.dimLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.dimLabel.AutoSize = True
        Me.dimLabel.Location = New System.Drawing.Point(519, 113)
        Me.dimLabel.Name = "dimLabel"
        Me.dimLabel.Size = New System.Drawing.Size(70, 13)
        Me.dimLabel.TabIndex = 131
        Me.dimLabel.Text = "Dimensioning"
        ' 
        ' ellipseButton
        ' 
        Me.ellipseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.ellipseButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ellipseButton.Location = New System.Drawing.Point(683, 55)
        Me.ellipseButton.Name = "ellipseButton"
        Me.ellipseButton.Size = New System.Drawing.Size(78, 22)
        Me.ellipseButton.TabIndex = 132
        Me.ellipseButton.Text = "Ellipse"
        Me.ellipseButton.UseVisualStyleBackColor = True
        ' 
        ' alignedDimButton
        ' 
        Me.alignedDimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.alignedDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.alignedDimButton.Location = New System.Drawing.Point(601, 133)
        Me.alignedDimButton.Name = "alignedDimButton"
        Me.alignedDimButton.Size = New System.Drawing.Size(78, 22)
        Me.alignedDimButton.TabIndex = 133
        Me.alignedDimButton.Text = "Aligned"
        Me.alignedDimButton.UseVisualStyleBackColor = True
        ' 
        ' ellipticalArcButton
        ' 
        Me.ellipticalArcButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.ellipticalArcButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ellipticalArcButton.Location = New System.Drawing.Point(764, 55)
        Me.ellipticalArcButton.Name = "ellipticalArcButton"
        Me.ellipticalArcButton.Size = New System.Drawing.Size(78, 22)
        Me.ellipticalArcButton.TabIndex = 134
        Me.ellipticalArcButton.Text = "EllipticalArc"
        Me.ellipticalArcButton.UseVisualStyleBackColor = True
        ' 
        ' snappingLabel
        ' 
        Me.snappingLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.snappingLabel.AutoSize = True
        Me.snappingLabel.Location = New System.Drawing.Point(519, 192)
        Me.snappingLabel.Name = "snappingLabel"
        Me.snappingLabel.Size = New System.Drawing.Size(52, 13)
        Me.snappingLabel.TabIndex = 135
        Me.snappingLabel.Text = "Snapping"
        ' 
        ' angularDimButton
        ' 
        Me.angularDimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.angularDimButton.Location = New System.Drawing.Point(520, 161)
        Me.angularDimButton.Name = "angularDimButton"
        Me.angularDimButton.Size = New System.Drawing.Size(78, 22)
        Me.angularDimButton.TabIndex = 136
        Me.angularDimButton.Text = "Angular"
        Me.angularDimButton.UseVisualStyleBackColor = True
        ' 
        ' compositeCurveButton
        ' 
        Me.compositeCurveButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.compositeCurveButton.Location = New System.Drawing.Point(519, 82)
        Me.compositeCurveButton.Name = "compositeCurveButton"
        Me.compositeCurveButton.Size = New System.Drawing.Size(78, 22)
        Me.compositeCurveButton.TabIndex = 137
        Me.compositeCurveButton.Text = "Composite"
        Me.compositeCurveButton.UseVisualStyleBackColor = True
        ' 
        ' statusStrip1
        ' 
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mainStatusLabel, Me.springToolStripStatusLabel, Me.readWriteProgressBar, Me.rendererVersionStatusLabel, Me.selectedCountStatusLabel, Me.addedCountStatusLabel, Me.removedCountStatusLabel})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 872)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.ShowItemToolTips = True
        Me.statusStrip1.Size = New System.Drawing.Size(854, 25)
        Me.statusStrip1.TabIndex = 53
        Me.statusStrip1.Text = "statusStrip1"
        ' 
        ' design1
        ' 
        Me.design1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.design1.Cursor = System.Windows.Forms.Cursors.Default
        Me.design1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.design1.GridSnapEnabled = False
        Me.design1.Location = New System.Drawing.Point(9, 6)
        Me.design1.MinimumSize = New System.Drawing.Size(8, 8)
        Me.design1.Name = "design1"
        Me.design1.ObjectSnapEnabled = False
        Me.design1.Rendered = DisplayModeSettingsRendered1
        Me.design1.Size = New System.Drawing.Size(501, 699)
        Me.design1.TabIndex = 0
        OriginSymbol1.LabelFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
        CoordinateSystemIcon1.LabelFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
        Viewport1.CoordinateSystemIcon = CoordinateSystemIcon1
        ViewCubeIcon1.Font = Nothing
        ViewCubeIcon1.InitialRotation = New devDept.Geometry.Quaternion(0R, 0R, 0R, 1.0R)
        Viewport1.ViewCubeIcon = ViewCubeIcon1
        Me.design1.Viewports.Add(Viewport1)
        Me.design1.ActiveViewport.Camera.ProjectionMode = devDept.Eyeshot.projectionType.Orthographic
        Me.design1.WaitingForSelection = False
        ' 
        ' endRadioButton
        ' 
        Me.endRadioButton.AutoSize = True
        Me.endRadioButton.Checked = True
        Me.endRadioButton.Location = New System.Drawing.Point(6, 6)
        Me.endRadioButton.Name = "endRadioButton"
        Me.endRadioButton.Size = New System.Drawing.Size(44, 17)
        Me.endRadioButton.TabIndex = 138
        Me.endRadioButton.TabStop = True
        Me.endRadioButton.Text = "End"
        Me.endRadioButton.UseVisualStyleBackColor = True
        ' 
        ' midRadioButton
        ' 
        Me.midRadioButton.AutoSize = True
        Me.midRadioButton.Location = New System.Drawing.Point(55, 6)
        Me.midRadioButton.Name = "midRadioButton"
        Me.midRadioButton.Size = New System.Drawing.Size(42, 17)
        Me.midRadioButton.TabIndex = 139
        Me.midRadioButton.Text = "Mid"
        Me.midRadioButton.UseVisualStyleBackColor = True
        ' 
        ' cenRadioButton
        ' 
        Me.cenRadioButton.AutoSize = True
        Me.cenRadioButton.Location = New System.Drawing.Point(102, 6)
        Me.cenRadioButton.Name = "cenRadioButton"
        Me.cenRadioButton.Size = New System.Drawing.Size(44, 17)
        Me.cenRadioButton.TabIndex = 140
        Me.cenRadioButton.Text = "Cen"
        Me.cenRadioButton.UseVisualStyleBackColor = True
        ' 
        ' pointRadioButton
        ' 
        Me.pointRadioButton.AutoSize = True
        Me.pointRadioButton.Location = New System.Drawing.Point(209, 6)
        Me.pointRadioButton.Name = "pointRadioButton"
        Me.pointRadioButton.Size = New System.Drawing.Size(49, 17)
        Me.pointRadioButton.TabIndex = 141
        Me.pointRadioButton.Text = "Point"
        Me.pointRadioButton.UseVisualStyleBackColor = True
        ' 
        ' quadRadioButton
        ' 
        Me.quadRadioButton.AutoSize = True
        Me.quadRadioButton.Location = New System.Drawing.Point(152, 6)
        Me.quadRadioButton.Name = "quadRadioButton"
        Me.quadRadioButton.Size = New System.Drawing.Size(51, 17)
        Me.quadRadioButton.TabIndex = 142
        Me.quadRadioButton.Text = "Quad"
        Me.quadRadioButton.UseVisualStyleBackColor = True
        ' 
        ' snapPanel
        ' 
        Me.snapPanel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.snapPanel.Controls.Add(Me.quadRadioButton)
        Me.snapPanel.Controls.Add(Me.pointRadioButton)
        Me.snapPanel.Controls.Add(Me.cenRadioButton)
        Me.snapPanel.Controls.Add(Me.midRadioButton)
        Me.snapPanel.Controls.Add(Me.endRadioButton)
        Me.snapPanel.Enabled = False
        Me.snapPanel.Location = New System.Drawing.Point(520, 235)
        Me.snapPanel.Name = "snapPanel"
        Me.snapPanel.Size = New System.Drawing.Size(276, 30)
        Me.snapPanel.TabIndex = 143
        ' 
        ' mirrorButton
        ' 
        Me.mirrorButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.mirrorButton.Location = New System.Drawing.Point(684, 407)
        Me.mirrorButton.Name = "mirrorButton"
        Me.mirrorButton.Size = New System.Drawing.Size(78, 22)
        Me.mirrorButton.TabIndex = 144
        Me.mirrorButton.Text = "Mirror"
        Me.mirrorButton.UseVisualStyleBackColor = True
        ' 
        ' offsetButton
        ' 
        Me.offsetButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.offsetButton.Location = New System.Drawing.Point(766, 407)
        Me.offsetButton.Name = "offsetButton"
        Me.offsetButton.Size = New System.Drawing.Size(78, 22)
        Me.offsetButton.TabIndex = 145
        Me.offsetButton.Text = "Offset"
        Me.offsetButton.UseVisualStyleBackColor = True
        ' 
        ' trimButton
        ' 
        Me.trimButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.trimButton.Location = New System.Drawing.Point(520, 435)
        Me.trimButton.Name = "trimButton"
        Me.trimButton.Size = New System.Drawing.Size(78, 22)
        Me.trimButton.TabIndex = 146
        Me.trimButton.Text = "Trim"
        Me.trimButton.UseVisualStyleBackColor = True
        ' 
        ' extendButton
        ' 
        Me.extendButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.extendButton.Location = New System.Drawing.Point(601, 435)
        Me.extendButton.Name = "extendButton"
        Me.extendButton.Size = New System.Drawing.Size(78, 22)
        Me.extendButton.TabIndex = 147
        Me.extendButton.Text = "Extend"
        Me.extendButton.UseVisualStyleBackColor = True
        ' 
        ' filletButton
        ' 
        Me.filletButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.filletButton.Location = New System.Drawing.Point(684, 435)
        Me.filletButton.Name = "filletButton"
        Me.filletButton.Size = New System.Drawing.Size(78, 22)
        Me.filletButton.TabIndex = 148
        Me.filletButton.Text = "Fillet"
        Me.filletButton.UseVisualStyleBackColor = True
        ' 
        ' chamferButton
        ' 
        Me.chamferButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.chamferButton.Location = New System.Drawing.Point(766, 435)
        Me.chamferButton.Name = "chamferButton"
        Me.chamferButton.Size = New System.Drawing.Size(78, 22)
        Me.chamferButton.TabIndex = 149
        Me.chamferButton.Text = "Chamfer"
        Me.chamferButton.UseVisualStyleBackColor = True
        ' 
        ' filletTextBox
        ' 
        Me.filletTextBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.filletTextBox.Location = New System.Drawing.Point(684, 502)
        Me.filletTextBox.Name = "filletTextBox"
        Me.filletTextBox.Size = New System.Drawing.Size(76, 20)
        Me.filletTextBox.TabIndex = 155
        Me.filletTextBox.Text = "10.0"
        ' 
        ' fillRadLabel
        ' 
        Me.fillRadLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.fillRadLabel.AutoSize = True
        Me.fillRadLabel.Location = New System.Drawing.Point(519, 505)
        Me.fillRadLabel.Name = "fillRadLabel"
        Me.fillRadLabel.Size = New System.Drawing.Size(159, 13)
        Me.fillRadLabel.TabIndex = 156
        Me.fillRadLabel.Text = "Fillet Radius / Chamfer Distance"
        ' 
        ' textButton
        ' 
        Me.textButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.textButton.Location = New System.Drawing.Point(600, 82)
        Me.textButton.Name = "textButton"
        Me.textButton.Size = New System.Drawing.Size(78, 22)
        Me.textButton.TabIndex = 157
        Me.textButton.Text = "Text"
        Me.textButton.UseVisualStyleBackColor = True
        ' 
        ' showCurveDirectionButton
        ' 
        Me.showCurveDirectionButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.showCurveDirectionButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.showCurveDirectionButton.Location = New System.Drawing.Point(766, 551)
        Me.showCurveDirectionButton.Name = "showCurveDirectionButton"
        Me.showCurveDirectionButton.Size = New System.Drawing.Size(76, 22)
        Me.showCurveDirectionButton.TabIndex = 158
        Me.showCurveDirectionButton.Text = "Show Dir."
        Me.showCurveDirectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.showCurveDirectionButton.UseVisualStyleBackColor = True
        ' 
        ' ordinateVerticalButton
        ' 
        Me.ordinateVerticalButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.ordinateVerticalButton.Location = New System.Drawing.Point(683, 161)
        Me.ordinateVerticalButton.Name = "ordinateVerticalButton"
        Me.ordinateVerticalButton.Size = New System.Drawing.Size(78, 22)
        Me.ordinateVerticalButton.TabIndex = 159
        Me.ordinateVerticalButton.Text = "Ordinate V."
        Me.ordinateVerticalButton.UseVisualStyleBackColor = True
        ' 
        ' ordinateHorizontalButton
        ' 
        Me.ordinateHorizontalButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.ordinateHorizontalButton.Location = New System.Drawing.Point(601, 161)
        Me.ordinateHorizontalButton.Name = "ordinateHorizontalButton"
        Me.ordinateHorizontalButton.Size = New System.Drawing.Size(78, 22)
        Me.ordinateHorizontalButton.TabIndex = 160
        Me.ordinateHorizontalButton.Text = "Ordinate H."
        Me.ordinateHorizontalButton.UseVisualStyleBackColor = True
        ' 
        ' leaderButton
        ' 
        Me.leaderButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.leaderButton.Location = New System.Drawing.Point(764, 161)
        Me.leaderButton.Name = "leaderButton"
        Me.leaderButton.Size = New System.Drawing.Size(78, 22)
        Me.leaderButton.TabIndex = 161
        Me.leaderButton.Text = "Leader"
        Me.leaderButton.UseVisualStyleBackColor = True
        ' 
        ' moveButton
        ' 
        Me.moveButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.moveButton.Location = New System.Drawing.Point(520, 463)
        Me.moveButton.Name = "moveButton"
        Me.moveButton.Size = New System.Drawing.Size(78, 22)
        Me.moveButton.TabIndex = 162
        Me.moveButton.Text = "Move"
        Me.moveButton.UseVisualStyleBackColor = True
        ' 
        ' rotateButton
        ' 
        Me.rotateButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.rotateButton.Location = New System.Drawing.Point(601, 463)
        Me.rotateButton.Name = "rotateButton"
        Me.rotateButton.Size = New System.Drawing.Size(78, 22)
        Me.rotateButton.TabIndex = 163
        Me.rotateButton.Text = "Rotate"
        Me.rotateButton.UseVisualStyleBackColor = True
        ' 
        ' scaleButton
        ' 
        Me.scaleButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.scaleButton.Location = New System.Drawing.Point(684, 463)
        Me.scaleButton.Name = "scaleButton"
        Me.scaleButton.Size = New System.Drawing.Size(78, 22)
        Me.scaleButton.TabIndex = 164
        Me.scaleButton.Text = "Scale"
        Me.scaleButton.UseVisualStyleBackColor = True
        ' 
        ' saveButton
        ' 
        Me.saveButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.saveButton.Location = New System.Drawing.Point(602, 670)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(78, 22)
        Me.saveButton.TabIndex = 167
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        ' 
        ' openButton
        ' 
        Me.openButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.openButton.Location = New System.Drawing.Point(520, 670)
        Me.openButton.Name = "openButton"
        Me.openButton.Size = New System.Drawing.Size(78, 22)
        Me.openButton.TabIndex = 166
        Me.openButton.Text = "Open"
        Me.openButton.UseVisualStyleBackColor = True
        ' 
        ' importButton
        ' 
        Me.importButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.importButton.Location = New System.Drawing.Point(684, 670)
        Me.importButton.Name = "importButton"
        Me.importButton.Size = New System.Drawing.Size(78, 22)
        Me.importButton.TabIndex = 165
        Me.importButton.Text = "Import"
        Me.importButton.UseVisualStyleBackColor = True
        ' 
        ' exportButton
        ' 
        Me.exportButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.exportButton.Location = New System.Drawing.Point(766, 670)
        Me.exportButton.Name = "exportButton"
        Me.exportButton.Size = New System.Drawing.Size(76, 22)
        Me.exportButton.TabIndex = 168
        Me.exportButton.Text = "Export"
        Me.exportButton.UseVisualStyleBackColor = True
        ' 
        ' turboButton
        ' 
        Me.turboButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.turboButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.turboButton.Checked = False
        Me.turboButton.Location = New System.Drawing.Point(601, 698)
        Me.turboButton.Name = "turboButton"
        Me.turboButton.Size = New System.Drawing.Size(78, 22)
        Me.turboButton.TabIndex = 140
        Me.turboButton.Text = "Turbo"
        Me.turboButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.turboButton.UseVisualStyleBackColor = True
        ' 
        ' tangentsButton
        ' 
        Me.tangentsButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.tangentsButton.Location = New System.Drawing.Point(682, 82)
        Me.tangentsButton.Name = "tangentsButton"
        Me.tangentsButton.Size = New System.Drawing.Size(78, 22)
        Me.tangentsButton.TabIndex = 169
        Me.tangentsButton.Text = "Tangents"
        Me.tangentsButton.UseVisualStyleBackColor = True
        ' 
        ' hatchButton
        ' 
        Me.hatchButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
        Me.hatchButton.Location = New System.Drawing.Point(764, 82)
        Me.hatchButton.Name = "hatchButton"
        Me.hatchButton.Size = New System.Drawing.Size(78, 22)
        Me.hatchButton.TabIndex = 104
        Me.hatchButton.Text = "Hatch"
        Me.hatchButton.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(854, 897)
        Me.Controls.Add(Me.hatchButton)
        Me.Controls.Add(Me.tangentsButton)
        Me.Controls.Add(Me.exportButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.openButton)
        Me.Controls.Add(Me.importButton)
        Me.Controls.Add(Me.scaleButton)
        Me.Controls.Add(Me.rotateButton)
        Me.Controls.Add(Me.moveButton)
        Me.Controls.Add(Me.leaderButton)
        Me.Controls.Add(Me.ordinateHorizontalButton)
        Me.Controls.Add(Me.ordinateVerticalButton)
        Me.Controls.Add(Me.showCurveDirectionButton)
        Me.Controls.Add(Me.textButton)
        Me.Controls.Add(Me.fillRadLabel)
        Me.Controls.Add(Me.filletTextBox)
        Me.Controls.Add(Me.chamferButton)
        Me.Controls.Add(Me.filletButton)
        Me.Controls.Add(Me.extendButton)
        Me.Controls.Add(Me.trimButton)
        Me.Controls.Add(Me.offsetButton)
        Me.Controls.Add(Me.mirrorButton)
        Me.Controls.Add(Me.snapPanel)
        Me.Controls.Add(Me.compositeCurveButton)
        Me.Controls.Add(Me.angularDimButton)
        Me.Controls.Add(Me.snappingLabel)
        Me.Controls.Add(Me.gridSnapCheckBox)
        Me.Controls.Add(Me.ellipticalArcButton)
        Me.Controls.Add(Me.objectSnapCheckBox)
        Me.Controls.Add(Me.alignedDimButton)
        Me.Controls.Add(Me.ellipseButton)
        Me.Controls.Add(Me.dimLabel)
        Me.Controls.Add(Me.DiametricDimButton)
        Me.Controls.Add(Me.RadialDimButton)
        Me.Controls.Add(Me.LinearDimButton)
        Me.Controls.Add(Me.pointButton)
        Me.Controls.Add(Me.plineButton)
        Me.Controls.Add(Me.splineButton)
        Me.Controls.Add(Me.circleButton)
        Me.Controls.Add(Me.arcButton)
        Me.Controls.Add(Me.lineButton)
        Me.Controls.Add(Me.selectCheckBox)
        Me.Controls.Add(Me.selectionComboBox)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.tableTabControl)
        Me.Controls.Add(Me.design1)
        Me.Controls.Add(Me.groupButton)
        Me.Controls.Add(Me.explodeButton)
        Me.Controls.Add(Me.miscLabel)
        Me.Controls.Add(Me.vectorLabel)
        Me.Controls.Add(Me.vectorSaveButton)
        Me.Controls.Add(Me.vectorCopyToClipbardButton)
        Me.Controls.Add(Me.dumpButton)
        Me.Controls.Add(Me.showGridButton)
        Me.Controls.Add(Me.pickVertexButton)
        Me.Controls.Add(Me.inspectionLabel)
        Me.Controls.Add(Me.editingLabel)
        Me.Controls.Add(Me.selectionLabel)
        Me.Controls.Add(Me.hideShowLabel)
        Me.Controls.Add(Me.shadingLabel)
        Me.Controls.Add(Me.websiteButton)
        Me.Controls.Add(Me.turboButton)
        Me.Controls.Add(Me.pageSetupButton)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.showVerticesButton)
        Me.Controls.Add(Me.showExtentsButton)
        Me.Controls.Add(Me.showOriginButton)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.invertSelectionButton)
        Me.Controls.Add(Me.clearSelectionButton)
        Me.Controls.Add(Me.printPreviewButton)
        Me.Controls.Add(Me.areaButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Drafting Demo"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        CType(Me.design1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.snapPanel.ResumeLayout(False)
        Me.snapPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents design1 As Drafting2D
    Private WithEvents printPreviewButton As System.Windows.Forms.Button
    Private WithEvents invertSelectionButton As System.Windows.Forms.Button
    Private WithEvents deleteButton As System.Windows.Forms.Button
    Private WithEvents showVerticesButton As System.Windows.Forms.CheckBox
    Private WithEvents showExtentsButton As System.Windows.Forms.CheckBox
    Private WithEvents showOriginButton As System.Windows.Forms.CheckBox
    Private WithEvents printButton As System.Windows.Forms.Button
    Private WithEvents pageSetupButton As System.Windows.Forms.Button
    Private WithEvents websiteButton As System.Windows.Forms.Button
    Private mainStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private springToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private readWriteProgressBar As System.Windows.Forms.ToolStripProgressBar
    Public selectedCountStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Public addedCountStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Public removedCountStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private shadingLabel As System.Windows.Forms.Label
    Private hideShowLabel As System.Windows.Forms.Label
    Private selectionLabel As System.Windows.Forms.Label
    Private editingLabel As System.Windows.Forms.Label
    Private tableTabControl As TableTabControl
    Private WithEvents pickVertexButton As System.Windows.Forms.CheckBox
    Private inspectionLabel As System.Windows.Forms.Label
    Public rendererVersionStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents showGridButton As System.Windows.Forms.CheckBox
    Private WithEvents dumpButton As System.Windows.Forms.Button
    Private WithEvents vectorSaveButton As System.Windows.Forms.Button
    Private WithEvents vectorCopyToClipbardButton As System.Windows.Forms.Button
    Private zoomSelButton As System.Windows.Forms.Button
    Private vectorLabel As System.Windows.Forms.Label
    Private miscLabel As System.Windows.Forms.Label
    Private WithEvents explodeButton As System.Windows.Forms.Button
    Private WithEvents areaButton As System.Windows.Forms.Button
    Private WithEvents groupButton As System.Windows.Forms.Button
    Private WithEvents selectionComboBox As System.Windows.Forms.ComboBox
    Private WithEvents clearSelectionButton As System.Windows.Forms.Button
    Private WithEvents selectCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents lineButton As System.Windows.Forms.Button
    Private WithEvents arcButton As System.Windows.Forms.Button
    Private WithEvents circleButton As System.Windows.Forms.Button
    Private WithEvents splineButton As System.Windows.Forms.Button
    Private WithEvents plineButton As System.Windows.Forms.Button
    Private WithEvents pointButton As System.Windows.Forms.Button
    Private WithEvents objectSnapCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents gridSnapCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents LinearDimButton As System.Windows.Forms.Button
    Private WithEvents RadialDimButton As System.Windows.Forms.Button
    Private WithEvents DiametricDimButton As System.Windows.Forms.Button
    Private dimLabel As System.Windows.Forms.Label
    Private WithEvents ellipseButton As System.Windows.Forms.Button
    Private WithEvents alignedDimButton As System.Windows.Forms.Button
    Private WithEvents ellipticalArcButton As System.Windows.Forms.Button
    Private imageList1 As System.Windows.Forms.ImageList
    Private snappingLabel As System.Windows.Forms.Label
    Private WithEvents angularDimButton As System.Windows.Forms.Button
    Private WithEvents compositeCurveButton As System.Windows.Forms.Button
    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private endRadioButton As System.Windows.Forms.RadioButton
    Private midRadioButton As System.Windows.Forms.RadioButton
    Private cenRadioButton As System.Windows.Forms.RadioButton
    Private pointRadioButton As System.Windows.Forms.RadioButton
    Private quadRadioButton As System.Windows.Forms.RadioButton
    Private snapPanel As System.Windows.Forms.Panel
    Private WithEvents mirrorButton As System.Windows.Forms.Button
    Private WithEvents offsetButton As System.Windows.Forms.Button
    Private WithEvents trimButton As System.Windows.Forms.Button
    Private WithEvents extendButton As System.Windows.Forms.Button
    Private WithEvents filletButton As System.Windows.Forms.Button
    Private WithEvents chamferButton As System.Windows.Forms.Button
    Private WithEvents filletTextBox As System.Windows.Forms.TextBox
    Private fillRadLabel As System.Windows.Forms.Label
    Private WithEvents textButton As System.Windows.Forms.Button
    Private WithEvents showCurveDirectionButton As System.Windows.Forms.CheckBox
    Private WithEvents ordinateVerticalButton As System.Windows.Forms.Button
    Private WithEvents ordinateHorizontalButton As System.Windows.Forms.Button
    Private WithEvents leaderButton As System.Windows.Forms.Button
    Private WithEvents moveButton As System.Windows.Forms.Button
    Private WithEvents rotateButton As System.Windows.Forms.Button
    Private WithEvents scaleButton As System.Windows.Forms.Button
    Private WithEvents saveButton As System.Windows.Forms.Button
    Private WithEvents openButton As System.Windows.Forms.Button
    Private WithEvents importButton As System.Windows.Forms.Button
    Private WithEvents exportButton As System.Windows.Forms.Button
    Private WithEvents turboButton As System.Windows.Forms.CheckBox
    Private WithEvents tangentsButton As System.Windows.Forms.Button
    Private WithEvents hatchButton As System.Windows.Forms.Button
End Class
