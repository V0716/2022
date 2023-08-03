Imports devDept.Eyeshot.Control
Imports devDept.Graphics
Namespace WindowsApplication1

    Partial Class Form1

        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim cancelToolBarButton1 As devDept.Eyeshot.Control.CancelToolBarButton = New devDept.Eyeshot.Control.CancelToolBarButton("Cancel", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim displayModeSettingsRendered1 As devDept.Eyeshot.Control.DisplayModeSettingsRendered = New devDept.Eyeshot.Control.DisplayModeSettingsRendered(True, devDept.Eyeshot.edgeColorMethodType.EntityColor, System.Drawing.Color.Black, 1.0F, 2.0F, devDept.Eyeshot.silhouettesDrawingType.ImageBased, False, devDept.Graphics.shadowType.Planar, Nothing, False, False, 0.3F, devDept.Graphics.realisticShadowQualityType.High)
            Dim backgroundSettings1 As devDept.Eyeshot.Control.BackgroundSettings = New devDept.Eyeshot.Control.BackgroundSettings(devDept.Graphics.backgroundStyleType.Solid, System.Drawing.Color.FromArgb((CInt(((CByte((46)))))), (CInt(((CByte((82)))))), (CInt(((CByte((103))))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.Black, 0.75, Nothing)
            Dim Camera1 As devDept.Eyeshot.Camera = New devDept.Eyeshot.Camera(New devDept.Geometry.Point3D(0R, 0R, 45.0R), 600.0R, New devDept.Geometry.Quaternion(0.086824088833465166R, 0.15038373318043533R, 0.492403876506104R, 0.85286853195244339R), devDept.Eyeshot.projectionType.Orthographic, 50.0R, 1.5R, False)
            Dim magnifyingGlassToolBarButton1 As devDept.Eyeshot.Control.MagnifyingGlassToolBarButton = New devDept.Eyeshot.Control.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomWindowToolBarButton1 As devDept.Eyeshot.Control.ZoomWindowToolBarButton = New devDept.Eyeshot.Control.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomToolBarButton1 As devDept.Eyeshot.Control.ZoomToolBarButton = New devDept.Eyeshot.Control.ZoomToolBarButton("Zoom", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim panToolBarButton1 As devDept.Eyeshot.Control.PanToolBarButton = New devDept.Eyeshot.Control.PanToolBarButton("Pan", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomFitToolBarButton1 As devDept.Eyeshot.Control.ZoomFitToolBarButton = New devDept.Eyeshot.Control.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, True, True)
            Dim toolBar1 As devDept.Eyeshot.Control.ToolBar = New devDept.Eyeshot.Control.ToolBar(devDept.Eyeshot.Control.ToolBar.positionType.HorizontalTopCenter, True, New devDept.Eyeshot.Control.ToolBarButton() {(CType((magnifyingGlassToolBarButton1), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomWindowToolBarButton1), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomToolBarButton1), devDept.Eyeshot.Control.ToolBarButton)), (CType((panToolBarButton1), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomFitToolBarButton1), devDept.Eyeshot.Control.ToolBarButton))})
            Dim grid1 As devDept.Eyeshot.Control.Grid = New devDept.Eyeshot.Control.Grid(New devDept.Geometry.Point3D(-100, -100, 0), New devDept.Geometry.Point3D(100, 100, 0), 10, New devDept.Geometry.Plane(New devDept.Geometry.Point3D(0, 0, 0), New devDept.Geometry.Vector3D(0, 0, 1)), System.Drawing.Color.FromArgb((CInt(((CByte((63)))))), (CInt(((CByte((128)))))), (CInt(((CByte((128)))))), (CInt(((CByte((128))))))), System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((0)))))), (CInt(((CByte((128)))))), (CInt(((CByte((0))))))), False, True, False, False, 10, 100, 10, System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((90)))))), (CInt(((CByte((90)))))), (CInt(((CByte((90))))))), System.Drawing.Color.Transparent, False, System.Drawing.Color.FromArgb((CInt(((CByte((12)))))), (CInt(((CByte((0)))))), (CInt(((CByte((0)))))), (CInt(((CByte((255))))))))
            Dim rotateSettings1 As devDept.Eyeshot.Control.RotateSettings = New devDept.Eyeshot.Control.RotateSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.None), 10, True, 1, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, New devDept.Geometry.Point3D(0, 0, 0), False)
            Dim zoomSettings1 As devDept.Eyeshot.Control.ZoomSettings = New devDept.Eyeshot.Control.ZoomSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Shift), 25, True, devDept.Eyeshot.zoomStyleType.AtCursorLocation, False, 1, System.Drawing.Color.DeepSkyBlue, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, False, 10, True)
            Dim panSettings1 As devDept.Eyeshot.Control.PanSettings = New devDept.Eyeshot.Control.PanSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl), 25, True)
            Dim navigationSettings1 As devDept.Eyeshot.Control.NavigationSettings = New devDept.Eyeshot.Control.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Left, devDept.Eyeshot.Control.modifierKeys.None), New devDept.Geometry.Point3D(-1000, -1000, -1000), New devDept.Geometry.Point3D(1000, 1000, 1000), 8, 50, 50)

            Dim coordinateSystemIcon1 As devDept.Eyeshot.Control.CoordinateSystemIcon = New devDept.Eyeshot.Control.CoordinateSystemIcon(System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black, System.Drawing.Color.FromArgb((CInt(((CByte((80)))))), (CInt(((CByte((80)))))), (CInt(((CByte((80))))))), System.Drawing.Color.FromArgb((CInt(((CByte((80)))))), (CInt(((CByte((80)))))), (CInt(((CByte((80))))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", True, devDept.Eyeshot.Control.coordinateSystemPositionType.BottomLeft, 37, False)
            Dim legend1 As devDept.Eyeshot.Control.Legend = New devDept.Eyeshot.Control.Legend(0, 100, "Title", "Subtitle", New System.Drawing.Point(24, 24), New System.Drawing.Size(10, 30), True, False, False, "{0:0.##}", System.Drawing.Color.Transparent, System.Drawing.Color.Black, System.Drawing.Color.Black, New System.Drawing.Color() {System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((0)))))), (CInt(((CByte((255))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((63)))))), (CInt(((CByte((255))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((127)))))), (CInt(((CByte((255))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((191)))))), (CInt(((CByte((255))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((255)))))), (CInt(((CByte((255))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((255)))))), (CInt(((CByte((191))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((255)))))), (CInt(((CByte((127))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((255)))))), (CInt(((CByte((63))))))), System.Drawing.Color.FromArgb((CInt(((CByte((0)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((63)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((191)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((255)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((255)))))), (CInt(((CByte((191)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((255)))))), (CInt(((CByte((127)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((255)))))), (CInt(((CByte((63)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((255)))))), (CInt(((CByte((0)))))), (CInt(((CByte((0)))))))}, False, False)
            Dim originSymbol1 As devDept.Eyeshot.Control.OriginSymbol = New devDept.Eyeshot.Control.OriginSymbol(10, devDept.Eyeshot.Control.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", True, Nothing, False)
            Dim viewCubeIcon1 As devDept.Eyeshot.Control.ViewCubeIcon = New devDept.Eyeshot.Control.ViewCubeIcon(devDept.Eyeshot.Control.coordinateSystemPositionType.TopRight, True, System.Drawing.Color.DodgerBlue, True, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), "S"c, "N"c, "W"c, "E"c, True, System.Drawing.Color.White, System.Drawing.Color.Black, 120, True, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False)
            Dim viewport1 As devDept.Eyeshot.Control.Viewport = New devDept.Eyeshot.Control.Viewport(New System.Drawing.Point(0, 0), New System.Drawing.Size(278, 399), backgroundSettings1, Camera1, New devDept.Eyeshot.Control.ToolBar() {toolBar1},New devDept.Eyeshot.Control.Legend() {legend1}, Histogram.GetDefaultHistogramUI(),devDept.Eyeshot.displayType.Rendered, True, False, False, False, New devDept.Eyeshot.Control.Grid() {grid1}, New devDept.Eyeshot.Control.OriginSymbol() {originSymbol1},False, rotateSettings1, zoomSettings1, panSettings1, navigationSettings1, coordinateSystemIcon1, viewCubeIcon1, devDept.Eyeshot.viewType.Trimetric)
            Dim cancelToolBarButton2 As devDept.Eyeshot.Control.CancelToolBarButton = New devDept.Eyeshot.Control.CancelToolBarButton("Cancel", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim displayModeSettingsRendered2 As devDept.Eyeshot.Control.DisplayModeSettingsRendered = New devDept.Eyeshot.Control.DisplayModeSettingsRendered(True, devDept.Eyeshot.edgeColorMethodType.EntityColor, System.Drawing.Color.Black, 1.0F, 2.0F, devDept.Eyeshot.silhouettesDrawingType.ImageBased, False, devDept.Graphics.shadowType.Planar, Nothing, False, False, 0.3F, devDept.Graphics.realisticShadowQualityType.High)
            Dim backgroundSettings2 As devDept.Eyeshot.Control.BackgroundSettings = New devDept.Eyeshot.Control.BackgroundSettings(devDept.Graphics.backgroundStyleType.Solid, System.Drawing.Color.FromArgb((CInt(((CByte((46)))))), (CInt(((CByte((82)))))), (CInt(((CByte((103))))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.Black, 0.75, Nothing)
            Dim Camera2 As devDept.Eyeshot.Camera = New devDept.Eyeshot.Camera(New devDept.Geometry.Point3D(0R, 0R, 45.0R), 600.0R, New devDept.Geometry.Quaternion(0.086824088833465166R, 0.15038373318043533R, 0.492403876506104R, 0.85286853195244339R), devDept.Eyeshot.projectionType.Orthographic, 50.0R, 1.5R, False)
            Dim magnifyingGlassToolBarButton2 As devDept.Eyeshot.Control.MagnifyingGlassToolBarButton = New devDept.Eyeshot.Control.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomWindowToolBarButton2 As devDept.Eyeshot.Control.ZoomWindowToolBarButton = New devDept.Eyeshot.Control.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomToolBarButton2 As devDept.Eyeshot.Control.ZoomToolBarButton = New devDept.Eyeshot.Control.ZoomToolBarButton("Zoom", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim panToolBarButton2 As devDept.Eyeshot.Control.PanToolBarButton = New devDept.Eyeshot.Control.PanToolBarButton("Pan", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, True, True)
            Dim zoomFitToolBarButton2 As devDept.Eyeshot.Control.ZoomFitToolBarButton = New devDept.Eyeshot.Control.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, True, True)
            Dim toolBar2 As devDept.Eyeshot.Control.ToolBar = New devDept.Eyeshot.Control.ToolBar(devDept.Eyeshot.Control.ToolBar.positionType.HorizontalTopCenter, True, New devDept.Eyeshot.Control.ToolBarButton() {(CType((magnifyingGlassToolBarButton2), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomWindowToolBarButton2), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomToolBarButton2), devDept.Eyeshot.Control.ToolBarButton)), (CType((panToolBarButton2), devDept.Eyeshot.Control.ToolBarButton)), (CType((zoomFitToolBarButton2), devDept.Eyeshot.Control.ToolBarButton))})
            Dim grid2 As devDept.Eyeshot.Control.Grid = New devDept.Eyeshot.Control.Grid(New devDept.Geometry.Point3D(-100, -100, 0), New devDept.Geometry.Point3D(100, 100, 0), 10, New devDept.Geometry.Plane(New devDept.Geometry.Point3D(0, 0, 0), New devDept.Geometry.Vector3D(0, 0, 1)), System.Drawing.Color.FromArgb((CInt(((CByte((63)))))), (CInt(((CByte((128)))))), (CInt(((CByte((128)))))), (CInt(((CByte((128))))))), System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((255)))))), (CInt(((CByte((0)))))), (CInt(((CByte((0))))))), System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((0)))))), (CInt(((CByte((128)))))), (CInt(((CByte((0))))))), False, True, False, False, 10, 100, 10, System.Drawing.Color.FromArgb((CInt(((CByte((127)))))), (CInt(((CByte((90)))))), (CInt(((CByte((90)))))), (CInt(((CByte((90))))))), System.Drawing.Color.Transparent, False, System.Drawing.Color.FromArgb((CInt(((CByte((12)))))), (CInt(((CByte((0)))))), (CInt(((CByte((0)))))), (CInt(((CByte((255))))))))
            Dim rotateSettings2 As devDept.Eyeshot.Control.RotateSettings = New devDept.Eyeshot.Control.RotateSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.None), 10, True, 1, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, New devDept.Geometry.Point3D(0, 0, 0), False)
            Dim zoomSettings2 As devDept.Eyeshot.Control.ZoomSettings = New devDept.Eyeshot.Control.ZoomSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Shift), 25, True, devDept.Eyeshot.zoomStyleType.AtCursorLocation, False, 1, System.Drawing.Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, False, 10, True)
            Dim panSettings2 As devDept.Eyeshot.Control.PanSettings = New devDept.Eyeshot.Control.PanSettings(New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl), 25, True)
            Dim navigationSettings2 As devDept.Eyeshot.Control.NavigationSettings = New devDept.Eyeshot.Control.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, New devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Left, devDept.Eyeshot.Control.modifierKeys.None), New devDept.Geometry.Point3D(-1000, -1000, -1000), New devDept.Geometry.Point3D(1000, 1000, 1000), 8, 50, 50)

            Dim coordinateSystemIcon2 As devDept.Eyeshot.Control.CoordinateSystemIcon = New devDept.Eyeshot.Control.CoordinateSystemIcon(System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black, System.Drawing.Color.FromArgb((CInt(((CByte((80)))))), (CInt(((CByte((80)))))), (CInt(((CByte((80))))))), System.Drawing.Color.FromArgb((CInt(((CByte((80)))))), (CInt(((CByte((80)))))), (CInt(((CByte((80))))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", True, devDept.Eyeshot.Control.coordinateSystemPositionType.BottomLeft, 37, False)
            Dim originSymbol2 As devDept.Eyeshot.Control.OriginSymbol = New devDept.Eyeshot.Control.OriginSymbol(10, devDept.Eyeshot.Control.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", True, Nothing, False)
            Dim viewCubeIcon2 As devDept.Eyeshot.Control.ViewCubeIcon = New devDept.Eyeshot.Control.ViewCubeIcon(devDept.Eyeshot.Control.coordinateSystemPositionType.TopRight, True, System.Drawing.Color.DodgerBlue, True, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), System.Drawing.Color.FromArgb((CInt(((CByte((240)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77)))))), (CInt(((CByte((77))))))), "S"c, "N"c, "W"c, "E"c, True, System.Drawing.Color.White, System.Drawing.Color.Black, 120, True, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False)
            Dim viewport2 As devDept.Eyeshot.Control.Viewport = New devDept.Eyeshot.Control.Viewport(New System.Drawing.Point(0, 0), New System.Drawing.Size(278, 399), backgroundSettings2, Camera2, New devDept.Eyeshot.Control.ToolBar() {toolBar2}, New devDept.Eyeshot.Control.Legend(-1){}, Histogram.GetDefaultHistogramUI(), devDept.Eyeshot.displayType.Rendered, True, False, False, False, New devDept.Eyeshot.Control.Grid() {grid2}, New devDept.Eyeshot.Control.OriginSymbol() {originSymbol2},False, rotateSettings2, zoomSettings2, panSettings2, navigationSettings2, coordinateSystemIcon2, viewCubeIcon2, devDept.Eyeshot.viewType.Trimetric)
            Me.design1 = New devDept.Eyeshot.Control.Design()
            Me.design2 = New devDept.Eyeshot.Control.Design()
            Me.beforeButton = New System.Windows.Forms.Button()
            Me.afterButton = New System.Windows.Forms.Button()
            Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.beforePathLabel = New System.Windows.Forms.Label()
            Me.afterPathLabel = New System.Windows.Forms.Label()
            CType((Me.design1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.design2), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.splitContainer1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainer1.Panel1.SuspendLayout()
            Me.splitContainer1.Panel2.SuspendLayout()
            Me.splitContainer1.SuspendLayout()
            Me.SuspendLayout()
            '
            ' design1
            '
            Me.design1.Anchor = (CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
            Me.design1.Cursor = System.Windows.Forms.Cursors.[Default]
            Me.design1.Location = New System.Drawing.Point(0, 26)
            Me.design1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
            Me.design1.MinimumSize = New System.Drawing.Size(8, 8)
            Me.design1.Name = "design1"
            Me.design1.Size = New System.Drawing.Size(278, 399)
            Me.design1.TabIndex = 0
            Me.design1.Viewports.Add(viewport1)
            '
            ' design2
            '
            Me.design2.Anchor = (CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
            Me.design2.Cursor = System.Windows.Forms.Cursors.[Default]
            Me.design2.Location = New System.Drawing.Point(0, 26)
            Me.design2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
            Me.design2.MinimumSize = New System.Drawing.Size(8, 8)
            Me.design2.Name = "design2"
            Me.design2.Size = New System.Drawing.Size(278, 399)
            Me.design2.TabIndex = 2
            Me.design2.Text = "design2"
            Me.design2.Viewports.Add(viewport2)
            '
            ' beforeButton
            '
            Me.beforeButton.Location = New System.Drawing.Point(0, 0)
            Me.beforeButton.Name = "beforeButton"
            Me.beforeButton.Size = New System.Drawing.Size(75, 23)
            Me.beforeButton.TabIndex = 3
            Me.beforeButton.Text = "Before..."
            Me.beforeButton.UseVisualStyleBackColor = True
            '
            ' afterButton
            '
            Me.afterButton.Location = New System.Drawing.Point(0, 0)
            Me.afterButton.Name = "afterButton"
            Me.afterButton.Size = New System.Drawing.Size(75, 23)
            Me.afterButton.TabIndex = 4
            Me.afterButton.Text = "After..."
            Me.afterButton.UseVisualStyleBackColor = True
            '
            ' splitContainer1
            '
            Me.splitContainer1.Anchor = (CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
            Me.splitContainer1.Location = New System.Drawing.Point(12, 12)
            Me.splitContainer1.Name = "splitContainer1"
            Me.splitContainer1.Panel1.Controls.Add(Me.beforePathLabel)
            Me.splitContainer1.Panel1.Controls.Add(Me.design1)
            Me.splitContainer1.Panel1.Controls.Add(Me.beforeButton)
            Me.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.splitContainer1.Panel2.Controls.Add(Me.afterPathLabel)
            Me.splitContainer1.Panel2.Controls.Add(Me.design2)
            Me.splitContainer1.Panel2.Controls.Add(Me.afterButton)
            Me.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.splitContainer1.Size = New System.Drawing.Size(562, 425)
            Me.splitContainer1.SplitterDistance = 278
            Me.splitContainer1.SplitterWidth = 8
            Me.splitContainer1.TabIndex = 5
            '
            ' beforePathLabel
            '
            Me.beforePathLabel.AutoSize = True
            Me.beforePathLabel.Location = New System.Drawing.Point(80, 5)
            Me.beforePathLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.beforePathLabel.Name = "beforePathLabel"
            Me.beforePathLabel.Size = New System.Drawing.Size(28, 13)
            Me.beforePathLabel.TabIndex = 4
            Me.beforePathLabel.Text = ".  .  ."
            '
            ' afterPathLabel
            '
            Me.afterPathLabel.AutoSize = True
            Me.afterPathLabel.Location = New System.Drawing.Point(80, 5)
            Me.afterPathLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.afterPathLabel.Name = "afterPathLabel"
            Me.afterPathLabel.Size = New System.Drawing.Size(28, 13)
            Me.afterPathLabel.TabIndex = 5
            Me.afterPathLabel.Text = ".  .  ."
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(586, 449)
            Me.Controls.Add(Me.splitContainer1)
            Me.Name = "Form1"
            Me.Text = "Compare DWG"
            CType((Me.design1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.design2), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainer1.Panel1.ResumeLayout(False)
            Me.splitContainer1.Panel1.PerformLayout()
            Me.splitContainer1.Panel2.ResumeLayout(False)
            Me.splitContainer1.Panel2.PerformLayout()
            CType((Me.splitContainer1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainer1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private WithEvents design1 As devDept.Eyeshot.Control.Design

        Private WithEvents design2 As devDept.Eyeshot.Control.Design

        Private WithEvents beforeButton As System.Windows.Forms.Button

        Private WithEvents afterButton As System.Windows.Forms.Button

        Private splitContainer1 As System.Windows.Forms.SplitContainer

        Private beforePathLabel As System.Windows.Forms.Label

        Private afterPathLabel As System.Windows.Forms.Label
    End Class
End Namespace
