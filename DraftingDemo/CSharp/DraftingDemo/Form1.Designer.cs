using System.Collections.ObjectModel;
using devDept.CustomControls;
using devDept.Graphics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot;
using  devDept.CustomControls.Controls.Drafting;

namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            devDept.Eyeshot.Control.DisplayModeSettingsRendered displayModeSettingsRendered1 = new devDept.Eyeshot.Control.DisplayModeSettingsRendered(true, devDept.Eyeshot.edgeColorMethodType.SingleColor, System.Drawing.Color.Black, 1F, 2F, devDept.Eyeshot.silhouettesDrawingType.ImageBased, false, devDept.Graphics.shadowType.Planar, null, false, false, 0.3F, devDept.Graphics.realisticShadowQualityType.High);
            devDept.Eyeshot.Control.BackgroundSettings backgroundSettings1 = new devDept.Eyeshot.Control.BackgroundSettings(devDept.Graphics.backgroundStyleType.Solid, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Black, 0.75D, null, devDept.Eyeshot.colorThemeType.Auto, 0.3D);
            devDept.Eyeshot.Camera camera1 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 600D, new devDept.Geometry.Quaternion(0.086824088833465166D, 0.15038373318043533D, 0.492403876506104D, 0.85286853195244339D), devDept.Eyeshot.projectionType.Orthographic, 50D, 1.5D, false);
            devDept.Eyeshot.Control.HomeToolBarButton homeToolBarButton1 = new devDept.Eyeshot.Control.HomeToolBarButton("Home", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.Control.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton1 = new devDept.Eyeshot.Control.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomWindowToolBarButton zoomWindowToolBarButton1 = new devDept.Eyeshot.Control.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomToolBarButton zoomToolBarButton1 = new devDept.Eyeshot.Control.ZoomToolBarButton("Zoom", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.PanToolBarButton panToolBarButton1 = new devDept.Eyeshot.Control.PanToolBarButton("Pan", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.RotateToolBarButton rotateToolBarButton1 = new devDept.Eyeshot.Control.RotateToolBarButton("Rotate", devDept.Eyeshot.Control.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.Control.ZoomFitToolBarButton zoomFitToolBarButton1 = new devDept.Eyeshot.Control.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.Control.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.Control.ToolBar toolBar1 = new devDept.Eyeshot.Control.ToolBar(devDept.Eyeshot.Control.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.Control.ToolBarButton[] {
            homeToolBarButton1,
            magnifyingGlassToolBarButton1,
            zoomWindowToolBarButton1,
            zoomToolBarButton1,
            panToolBarButton1,
            rotateToolBarButton1,
            zoomFitToolBarButton1});
            devDept.Eyeshot.Control.Grid grid1 = new devDept.Eyeshot.Control.Grid(new devDept.Geometry.Point2D(-100D, -100D), new devDept.Geometry.Point2D(100D, 100D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 0D, 1D)), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32))))), false, true, false, false, 10, 100, 10, System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90))))), System.Drawing.Color.Transparent, false, System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            devDept.Eyeshot.Control.OriginSymbol originSymbol1 = new devDept.Eyeshot.Control.OriginSymbol(10, devDept.Eyeshot.Control.originSymbolStyleType.Ball, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.Control.RotateSettings rotateSettings1 = new devDept.Eyeshot.Control.RotateSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.Control.ZoomSettings zoomSettings1 = new devDept.Eyeshot.Control.ZoomSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, System.Drawing.Color.DeepSkyBlue, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.Control.PanSettings panSettings1 = new devDept.Eyeshot.Control.PanSettings(new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.Control.NavigationSettings navigationSettings1 = new devDept.Eyeshot.Control.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.Control.MouseButton(devDept.Eyeshot.Control.mouseButtonsZPR.Left, devDept.Eyeshot.Control.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.Control.Viewport viewport1 = new devDept.Eyeshot.Control.Viewport(new System.Drawing.Point(0, 0), new System.Drawing.Size(639, 495), backgroundSettings1, camera1, new devDept.Eyeshot.Control.ToolBar[] {
                toolBar1}, devDept.Eyeshot.displayType.Wireframe, true, false, false, false, new devDept.Eyeshot.Control.Grid[] {
                grid1}, new devDept.Eyeshot.Control.OriginSymbol[] {
                originSymbol1}, false, rotateSettings1, zoomSettings1, panSettings1, navigationSettings1, devDept.Eyeshot.viewType.Top);
            devDept.Eyeshot.Control.CoordinateSystemIcon coordinateSystemIcon1 = new devDept.Eyeshot.Control.CoordinateSystemIcon(System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black,System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.Control.coordinateSystemPositionType.BottomLeft, 37, false);
            devDept.Eyeshot.Control.ViewCubeIcon viewCubeIcon1 = new devDept.Eyeshot.Control.ViewCubeIcon(devDept.Eyeshot.Control.coordinateSystemPositionType.TopRight, false, System.Drawing.Color.DodgerBlue, true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), 'S', 'N', 'W', 'E', true, null, System.Drawing.Color.White, System.Drawing.Color.Black, 120, true, true, null, null, null, null, null, null, false, null, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.invertSelectionButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.showVerticesButton = new System.Windows.Forms.CheckBox();
            this.showExtentsButton = new System.Windows.Forms.CheckBox();
            this.showOriginButton = new System.Windows.Forms.CheckBox();
            this.printButton = new System.Windows.Forms.Button();
            this.pageSetupButton = new System.Windows.Forms.Button();
            this.websiteButton = new System.Windows.Forms.Button();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.springToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.readWriteProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.rendererVersionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.addedCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.removedCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.shadingLabel = new System.Windows.Forms.Label();
            this.hideShowLabel = new System.Windows.Forms.Label();
            this.selectionLabel = new System.Windows.Forms.Label();
            this.editingLabel = new System.Windows.Forms.Label();
            this.tableTabControl = new devDept.CustomControls.TableTabControl();
            this.pickVertexButton = new System.Windows.Forms.CheckBox();
            this.inspectionLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.showGridButton = new System.Windows.Forms.CheckBox();
            this.dumpButton = new System.Windows.Forms.Button();
            this.vectorSaveButton = new System.Windows.Forms.Button();
            this.vectorCopyToClipbardButton = new System.Windows.Forms.Button();
            this.zoomSelButton = new System.Windows.Forms.Button();
            this.vectorLabel = new System.Windows.Forms.Label();
            this.miscLabel = new System.Windows.Forms.Label();
            this.explodeButton = new System.Windows.Forms.Button();
            this.areaButton = new System.Windows.Forms.Button();
            this.groupButton = new System.Windows.Forms.Button();
            this.selectionComboBox = new System.Windows.Forms.ComboBox();
            this.clearSelectionButton = new System.Windows.Forms.Button();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.lineButton = new System.Windows.Forms.Button();
            this.arcButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.splineButton = new System.Windows.Forms.Button();
            this.plineButton = new System.Windows.Forms.Button();
            this.pointButton = new System.Windows.Forms.Button();
            this.objectSnapCheckBox = new System.Windows.Forms.CheckBox();
            this.gridSnapCheckBox = new System.Windows.Forms.CheckBox();
            this.LinearDimButton = new System.Windows.Forms.Button();
            this.RadialDimButton = new System.Windows.Forms.Button();
            this.DiametricDimButton = new System.Windows.Forms.Button();
            this.dimLabel = new System.Windows.Forms.Label();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.alignedDimButton = new System.Windows.Forms.Button();
            this.ellipticalArcButton = new System.Windows.Forms.Button();
            this.snappingLabel = new System.Windows.Forms.Label();
            this.angularDimButton = new System.Windows.Forms.Button();
            this.compositeCurveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.design1 = new Drafting2D();
            this.endRadioButton = new System.Windows.Forms.RadioButton();
            this.midRadioButton = new System.Windows.Forms.RadioButton();
            this.cenRadioButton = new System.Windows.Forms.RadioButton();
            this.pointRadioButton = new System.Windows.Forms.RadioButton();
            this.quadRadioButton = new System.Windows.Forms.RadioButton();
            this.snapPanel = new System.Windows.Forms.Panel();
            this.mirrorButton = new System.Windows.Forms.Button();
            this.offsetButton = new System.Windows.Forms.Button();
            this.trimButton = new System.Windows.Forms.Button();
            this.extendButton = new System.Windows.Forms.Button();
            this.filletButton = new System.Windows.Forms.Button();
            this.chamferButton = new System.Windows.Forms.Button();
            this.filletTextBox = new System.Windows.Forms.TextBox();
            this.fillRadLabel = new System.Windows.Forms.Label();
            this.textButton = new System.Windows.Forms.Button();
            this.showCurveDirectionButton = new System.Windows.Forms.CheckBox();
            this.ordinateVerticalButton = new System.Windows.Forms.Button();
            this.ordinateHorizontalButton = new System.Windows.Forms.Button();
            this.leaderButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.rotateButton = new System.Windows.Forms.Button();
            this.scaleButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.turboButton = new System.Windows.Forms.CheckBox();
            this.tangentsButton = new System.Windows.Forms.Button();
            this.hatchButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.design1)).BeginInit();
            this.snapPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.printPreviewButton.Location = new System.Drawing.Point(683, 597);
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(79, 22);
            this.printPreviewButton.TabIndex = 1;
            this.printPreviewButton.Text = "Print Preview";
            this.printPreviewButton.UseVisualStyleBackColor = false;
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            // 
            // invertSelectionButton
            // 
            this.invertSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invertSelectionButton.Location = new System.Drawing.Point(519, 357);
            this.invertSelectionButton.Name = "invertSelectionButton";
            this.invertSelectionButton.Size = new System.Drawing.Size(78, 22);
            this.invertSelectionButton.TabIndex = 24;
            this.invertSelectionButton.Text = "Invert";
            this.invertSelectionButton.UseVisualStyleBackColor = true;
            this.invertSelectionButton.Click += new System.EventHandler(this.invertSelectionButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(519, 407);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(78, 22);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // showVerticesButton
            // 
            this.showVerticesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showVerticesButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showVerticesButton.Location = new System.Drawing.Point(683, 289);
            this.showVerticesButton.Name = "showVerticesButton";
            this.showVerticesButton.Size = new System.Drawing.Size(78, 22);
            this.showVerticesButton.TabIndex = 29;
            this.showVerticesButton.Text = "Vertices";
            this.showVerticesButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showVerticesButton.UseVisualStyleBackColor = true;
            this.showVerticesButton.CheckedChanged += new System.EventHandler(this.showVerticesButton_CheckedChanged);
            // 
            // showExtentsButton
            // 
            this.showExtentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showExtentsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showExtentsButton.Location = new System.Drawing.Point(601, 289);
            this.showExtentsButton.Name = "showExtentsButton";
            this.showExtentsButton.Size = new System.Drawing.Size(78, 22);
            this.showExtentsButton.TabIndex = 28;
            this.showExtentsButton.Text = "Extents";
            this.showExtentsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showExtentsButton.UseVisualStyleBackColor = true;
            this.showExtentsButton.CheckedChanged += new System.EventHandler(this.showExtentsButton_CheckedChanged);
            // 
            // showOriginButton
            // 
            this.showOriginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showOriginButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showOriginButton.Checked = true;
            this.showOriginButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginButton.Location = new System.Drawing.Point(519, 289);
            this.showOriginButton.Name = "showOriginButton";
            this.showOriginButton.Size = new System.Drawing.Size(78, 22);
            this.showOriginButton.TabIndex = 27;
            this.showOriginButton.Text = "Origin";
            this.showOriginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showOriginButton.UseVisualStyleBackColor = true;
            this.showOriginButton.CheckedChanged += new System.EventHandler(this.showOriginButton_CheckedChanged);
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.printButton.Location = new System.Drawing.Point(766, 597);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(77, 22);
            this.printButton.TabIndex = 32;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // pageSetupButton
            // 
            this.pageSetupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSetupButton.Location = new System.Drawing.Point(519, 622);
            this.pageSetupButton.Name = "pageSetupButton";
            this.pageSetupButton.Size = new System.Drawing.Size(78, 22);
            this.pageSetupButton.TabIndex = 33;
            this.pageSetupButton.Text = "Page Setup";
            this.pageSetupButton.UseVisualStyleBackColor = true;
            this.pageSetupButton.Click += new System.EventHandler(this.pageSetupButton_Click);
            // 
            // websiteButton
            // 
            this.websiteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.websiteButton.Location = new System.Drawing.Point(520, 698);
            this.websiteButton.Name = "websiteButton";
            this.websiteButton.Size = new System.Drawing.Size(78, 22);
            this.websiteButton.TabIndex = 38;
            this.websiteButton.Text = "Website";
            this.websiteButton.UseVisualStyleBackColor = true;
            this.websiteButton.Click += new System.EventHandler(this.websiteButton_Click);
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(552, 20);
            this.mainStatusLabel.Text = "Middle Mouse Button = Rotate, Ctrl + Middle = Pan, Shift + Middle = Zoom, Mouse W" +
    "heel = Zoom +/-";
            // 
            // springToolStripStatusLabel
            // 
            this.springToolStripStatusLabel.Name = "springToolStripStatusLabel";
            this.springToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.springToolStripStatusLabel.Size = new System.Drawing.Size(11, 20);
            this.springToolStripStatusLabel.Spring = true;
            // 
            // readWriteProgressBar
            // 
            this.readWriteProgressBar.Name = "readWriteProgressBar";
            this.readWriteProgressBar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.readWriteProgressBar.Size = new System.Drawing.Size(105, 19);
            this.readWriteProgressBar.Visible = false;
            // 
            // rendererVersionStatusLabel
            // 
            this.rendererVersionStatusLabel.AutoSize = false;
            this.rendererVersionStatusLabel.AutoToolTip = true;
            this.rendererVersionStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rendererVersionStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.rendererVersionStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.rendererVersionStatusLabel.Name = "rendererVersionStatusLabel";
            this.rendererVersionStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.rendererVersionStatusLabel.Size = new System.Drawing.Size(64, 20);
            this.rendererVersionStatusLabel.Text = "1.0";
            this.rendererVersionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rendererVersionStatusLabel.ToolTipText = "Renderer Version";
            // 
            // selectedCountStatusLabel
            // 
            this.selectedCountStatusLabel.AutoSize = false;
            this.selectedCountStatusLabel.AutoToolTip = true;
            this.selectedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.selectedCountStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.selectedCountStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.selectedCountStatusLabel.Name = "selectedCountStatusLabel";
            this.selectedCountStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.selectedCountStatusLabel.Size = new System.Drawing.Size(64, 20);
            this.selectedCountStatusLabel.Text = "0";
            this.selectedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectedCountStatusLabel.ToolTipText = "Selected count";
            // 
            // addedCountStatusLabel
            // 
            this.addedCountStatusLabel.AutoSize = false;
            this.addedCountStatusLabel.AutoToolTip = true;
            this.addedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(239)))), ((int)(((byte)(245)))));
            this.addedCountStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.addedCountStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.addedCountStatusLabel.Name = "addedCountStatusLabel";
            this.addedCountStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.addedCountStatusLabel.Size = new System.Drawing.Size(64, 20);
            this.addedCountStatusLabel.Text = "0";
            this.addedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addedCountStatusLabel.ToolTipText = "Added to selection count";
            // 
            // removedCountStatusLabel
            // 
            this.removedCountStatusLabel.AutoSize = false;
            this.removedCountStatusLabel.AutoToolTip = true;
            this.removedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(169)))), ((int)(((byte)(175)))));
            this.removedCountStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.removedCountStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.removedCountStatusLabel.Name = "removedCountStatusLabel";
            this.removedCountStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.removedCountStatusLabel.Size = new System.Drawing.Size(64, 20);
            this.removedCountStatusLabel.Text = "0";
            this.removedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removedCountStatusLabel.ToolTipText = "Removed from selection count";
            // 
            // shadingLabel
            // 
            this.shadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shadingLabel.AutoSize = true;
            this.shadingLabel.Location = new System.Drawing.Point(519, 11);
            this.shadingLabel.Name = "shadingLabel";
            this.shadingLabel.Size = new System.Drawing.Size(44, 13);
            this.shadingLabel.TabIndex = 54;
            this.shadingLabel.Text = "Drafting";
            // 
            // hideShowLabel
            // 
            this.hideShowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideShowLabel.AutoSize = true;
            this.hideShowLabel.Location = new System.Drawing.Point(519, 273);
            this.hideShowLabel.Name = "hideShowLabel";
            this.hideShowLabel.Size = new System.Drawing.Size(61, 13);
            this.hideShowLabel.TabIndex = 58;
            this.hideShowLabel.Text = "Hide/Show";
            // 
            // selectionLabel
            // 
            this.selectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionLabel.AutoSize = true;
            this.selectionLabel.Location = new System.Drawing.Point(519, 314);
            this.selectionLabel.Name = "selectionLabel";
            this.selectionLabel.Size = new System.Drawing.Size(51, 13);
            this.selectionLabel.TabIndex = 59;
            this.selectionLabel.Text = "Selection";
            // 
            // editingLabel
            // 
            this.editingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editingLabel.AutoSize = true;
            this.editingLabel.Location = new System.Drawing.Point(518, 391);
            this.editingLabel.Name = "editingLabel";
            this.editingLabel.Size = new System.Drawing.Size(39, 13);
            this.editingLabel.TabIndex = 60;
            this.editingLabel.Text = "Editing";
            // 
            // tableTabControl
            // 
            this.tableTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTabControl.Location = new System.Drawing.Point(12, 713);
            this.tableTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tableTabControl.Name = "tableTabControl";
            this.tableTabControl.SelectedIndex = 0;
            this.tableTabControl.Size = new System.Drawing.Size(501, 143);
            this.tableTabControl.TabIndex = 170;
            // 
            // pickVertexButton
            // 
            this.pickVertexButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickVertexButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pickVertexButton.Location = new System.Drawing.Point(519, 551);
            this.pickVertexButton.Name = "pickVertexButton";
            this.pickVertexButton.Size = new System.Drawing.Size(78, 22);
            this.pickVertexButton.TabIndex = 76;
            this.pickVertexButton.Text = "Pick Vertex";
            this.pickVertexButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pickVertexButton.UseVisualStyleBackColor = true;
            this.pickVertexButton.Click += new System.EventHandler(this.pickVertexButton_Click);
            // 
            // inspectionLabel
            // 
            this.inspectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectionLabel.AutoSize = true;
            this.inspectionLabel.Location = new System.Drawing.Point(519, 534);
            this.inspectionLabel.Name = "inspectionLabel";
            this.inspectionLabel.Size = new System.Drawing.Size(142, 13);
            this.inspectionLabel.TabIndex = 75;
            this.inspectionLabel.Text = "Inspection / Mass Properties";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // showGridButton
            // 
            this.showGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showGridButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showGridButton.Checked = true;
            this.showGridButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridButton.Location = new System.Drawing.Point(765, 289);
            this.showGridButton.Name = "showGridButton";
            this.showGridButton.Size = new System.Drawing.Size(78, 22);
            this.showGridButton.TabIndex = 79;
            this.showGridButton.Text = "Grid";
            this.showGridButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showGridButton.UseVisualStyleBackColor = true;
            this.showGridButton.CheckedChanged += new System.EventHandler(this.showGridButton_CheckedChanged);
            // 
            // dumpButton
            // 
            this.dumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dumpButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dumpButton.Location = new System.Drawing.Point(683, 551);
            this.dumpButton.Name = "dumpButton";
            this.dumpButton.Size = new System.Drawing.Size(79, 22);
            this.dumpButton.TabIndex = 84;
            this.dumpButton.Text = "Dump";
            this.dumpButton.UseVisualStyleBackColor = false;
            this.dumpButton.Click += new System.EventHandler(this.dumpButton_Click);
            // 
            // vectorSaveButton
            // 
            this.vectorSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vectorSaveButton.Location = new System.Drawing.Point(601, 597);
            this.vectorSaveButton.Name = "vectorSaveButton";
            this.vectorSaveButton.Size = new System.Drawing.Size(78, 22);
            this.vectorSaveButton.TabIndex = 86;
            this.vectorSaveButton.Text = "Save";
            this.vectorSaveButton.UseVisualStyleBackColor = false;
            this.vectorSaveButton.Click += new System.EventHandler(this.vectorSaveButton_Click);
            // 
            // vectorCopyToClipbardButton
            // 
            this.vectorCopyToClipbardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorCopyToClipbardButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vectorCopyToClipbardButton.Location = new System.Drawing.Point(519, 597);
            this.vectorCopyToClipbardButton.Name = "vectorCopyToClipbardButton";
            this.vectorCopyToClipbardButton.Size = new System.Drawing.Size(78, 22);
            this.vectorCopyToClipbardButton.TabIndex = 85;
            this.vectorCopyToClipbardButton.Text = "Copy";
            this.vectorCopyToClipbardButton.UseVisualStyleBackColor = false;
            this.vectorCopyToClipbardButton.Click += new System.EventHandler(this.vectorCopyToClipbardButton_Click);
            // 
            // zoomSelButton
            // 
            this.zoomSelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomSelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.zoomSelButton.Location = new System.Drawing.Point(582, 202);
            this.zoomSelButton.Name = "zoomSelButton";
            this.zoomSelButton.Size = new System.Drawing.Size(78, 22);
            this.zoomSelButton.TabIndex = 82;
            this.zoomSelButton.Text = "Zoom Sel.";
            this.zoomSelButton.UseVisualStyleBackColor = false;
            // 
            // vectorLabel
            // 
            this.vectorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorLabel.AutoSize = true;
            this.vectorLabel.Location = new System.Drawing.Point(519, 581);
            this.vectorLabel.Name = "vectorLabel";
            this.vectorLabel.Size = new System.Drawing.Size(38, 13);
            this.vectorLabel.TabIndex = 92;
            this.vectorLabel.Text = "Vector";
            // 
            // miscLabel
            // 
            this.miscLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miscLabel.AutoSize = true;
            this.miscLabel.Location = new System.Drawing.Point(519, 653);
            this.miscLabel.Name = "miscLabel";
            this.miscLabel.Size = new System.Drawing.Size(74, 13);
            this.miscLabel.TabIndex = 93;
            this.miscLabel.Text = "Miscellaneous";
            // 
            // explodeButton
            // 
            this.explodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.explodeButton.Location = new System.Drawing.Point(601, 407);
            this.explodeButton.Name = "explodeButton";
            this.explodeButton.Size = new System.Drawing.Size(78, 22);
            this.explodeButton.TabIndex = 95;
            this.explodeButton.Text = "Explode";
            this.explodeButton.UseVisualStyleBackColor = true;
            this.explodeButton.Click += new System.EventHandler(this.explodeButton_Click);
            // 
            // areaButton
            // 
            this.areaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.areaButton.Location = new System.Drawing.Point(601, 551);
            this.areaButton.Name = "areaButton";
            this.areaButton.Size = new System.Drawing.Size(78, 22);
            this.areaButton.TabIndex = 102;
            this.areaButton.Text = "Area";
            this.areaButton.UseVisualStyleBackColor = true;
            this.areaButton.Click += new System.EventHandler(this.areaButton_Click);
            // 
            // groupButton
            // 
            this.groupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupButton.Location = new System.Drawing.Point(601, 357);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(78, 22);
            this.groupButton.TabIndex = 104;
            this.groupButton.Text = "Group";
            this.groupButton.UseVisualStyleBackColor = true;
            this.groupButton.Click += new System.EventHandler(this.groupButton_Click);
            // 
            // selectionComboBox
            // 
            this.selectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionComboBox.Items.AddRange(new object[] {
            "by Pick",
            "by Box",
            "by Polygon",
            "by Box Enclosed",
            "by Polygon Enclosed",
            "Visible by Pick Dynamic"});
            this.selectionComboBox.Location = new System.Drawing.Point(520, 331);
            this.selectionComboBox.Name = "selectionComboBox";
            this.selectionComboBox.Size = new System.Drawing.Size(158, 21);
            this.selectionComboBox.TabIndex = 120;
            this.selectionComboBox.SelectedIndexChanged += new System.EventHandler(this.selectionComboBox_SelectedIndexChanged);
            // 
            // clearSelectionButton
            // 
            this.clearSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearSelectionButton.Location = new System.Drawing.Point(765, 330);
            this.clearSelectionButton.Name = "clearSelectionButton";
            this.clearSelectionButton.Size = new System.Drawing.Size(78, 22);
            this.clearSelectionButton.TabIndex = 23;
            this.clearSelectionButton.Text = "Clear";
            this.clearSelectionButton.UseVisualStyleBackColor = true;
            this.clearSelectionButton.Click += new System.EventHandler(this.clearSelectionButton_Click);
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectCheckBox.Location = new System.Drawing.Point(683, 330);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(78, 22);
            this.selectCheckBox.TabIndex = 121;
            this.selectCheckBox.Text = "Select";
            this.selectCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // lineButton
            // 
            this.lineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lineButton.Location = new System.Drawing.Point(600, 28);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(78, 22);
            this.lineButton.TabIndex = 122;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // arcButton
            // 
            this.arcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arcButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.arcButton.Location = new System.Drawing.Point(519, 55);
            this.arcButton.Name = "arcButton";
            this.arcButton.Size = new System.Drawing.Size(78, 22);
            this.arcButton.TabIndex = 123;
            this.arcButton.Text = "Arc";
            this.arcButton.UseVisualStyleBackColor = true;
            this.arcButton.Click += new System.EventHandler(this.arcButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circleButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.circleButton.Location = new System.Drawing.Point(764, 28);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(78, 22);
            this.circleButton.TabIndex = 124;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // splineButton
            // 
            this.splineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.splineButton.Location = new System.Drawing.Point(600, 55);
            this.splineButton.Name = "splineButton";
            this.splineButton.Size = new System.Drawing.Size(78, 22);
            this.splineButton.TabIndex = 125;
            this.splineButton.Text = "Spline";
            this.splineButton.UseVisualStyleBackColor = true;
            this.splineButton.Click += new System.EventHandler(this.splineButton_Click);
            // 
            // plineButton
            // 
            this.plineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plineButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.plineButton.Location = new System.Drawing.Point(683, 28);
            this.plineButton.Name = "plineButton";
            this.plineButton.Size = new System.Drawing.Size(78, 22);
            this.plineButton.TabIndex = 126;
            this.plineButton.Text = "PolyLine";
            this.plineButton.UseVisualStyleBackColor = true;
            this.plineButton.Click += new System.EventHandler(this.plineButton_Click);
            // 
            // pointButton
            // 
            this.pointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pointButton.Location = new System.Drawing.Point(519, 28);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(78, 22);
            this.pointButton.TabIndex = 127;
            this.pointButton.Text = "Points";
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // objectSnapCheckBox
            // 
            this.objectSnapCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objectSnapCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.objectSnapCheckBox.Location = new System.Drawing.Point(519, 211);
            this.objectSnapCheckBox.Name = "objectSnapCheckBox";
            this.objectSnapCheckBox.Size = new System.Drawing.Size(78, 22);
            this.objectSnapCheckBox.TabIndex = 128;
            this.objectSnapCheckBox.Text = "Object Snap";
            this.objectSnapCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.objectSnapCheckBox.UseVisualStyleBackColor = true;
            this.objectSnapCheckBox.CheckedChanged += new System.EventHandler(this.objectSnapCheckBox_CheckedChanged);
            // 
            // gridSnapCheckBox
            // 
            this.gridSnapCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSnapCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.gridSnapCheckBox.Location = new System.Drawing.Point(599, 211);
            this.gridSnapCheckBox.Name = "gridSnapCheckBox";
            this.gridSnapCheckBox.Size = new System.Drawing.Size(78, 22);
            this.gridSnapCheckBox.TabIndex = 129;
            this.gridSnapCheckBox.Text = "Grid Snap";
            this.gridSnapCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gridSnapCheckBox.UseVisualStyleBackColor = true;
            this.gridSnapCheckBox.CheckedChanged += new System.EventHandler(this.gridSnapCheckBox_CheckedChanged);
            // 
            // LinearDimButton
            // 
            this.LinearDimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LinearDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LinearDimButton.Location = new System.Drawing.Point(520, 133);
            this.LinearDimButton.Name = "LinearDimButton";
            this.LinearDimButton.Size = new System.Drawing.Size(78, 22);
            this.LinearDimButton.TabIndex = 0;
            this.LinearDimButton.Text = "Linear";
            this.LinearDimButton.UseVisualStyleBackColor = true;
            this.LinearDimButton.Click += new System.EventHandler(this.linearDimButton_Click);
            // 
            // RadialDimButton
            // 
            this.RadialDimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadialDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadialDimButton.Location = new System.Drawing.Point(683, 133);
            this.RadialDimButton.Name = "RadialDimButton";
            this.RadialDimButton.Size = new System.Drawing.Size(78, 22);
            this.RadialDimButton.TabIndex = 1;
            this.RadialDimButton.Text = "Radial";
            this.RadialDimButton.UseVisualStyleBackColor = true;
            this.RadialDimButton.Click += new System.EventHandler(this.radialDimButton_Click);
            // 
            // DiametricDimButton
            // 
            this.DiametricDimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiametricDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DiametricDimButton.Location = new System.Drawing.Point(764, 133);
            this.DiametricDimButton.Name = "DiametricDimButton";
            this.DiametricDimButton.Size = new System.Drawing.Size(78, 22);
            this.DiametricDimButton.TabIndex = 2;
            this.DiametricDimButton.Text = "Diametric";
            this.DiametricDimButton.UseVisualStyleBackColor = true;
            this.DiametricDimButton.Click += new System.EventHandler(this.diametricDimButton_Click);
            // 
            // dimLabel
            // 
            this.dimLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dimLabel.AutoSize = true;
            this.dimLabel.Location = new System.Drawing.Point(519, 113);
            this.dimLabel.Name = "dimLabel";
            this.dimLabel.Size = new System.Drawing.Size(70, 13);
            this.dimLabel.TabIndex = 131;
            this.dimLabel.Text = "Dimensioning";
            // 
            // ellipseButton
            // 
            this.ellipseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ellipseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ellipseButton.Location = new System.Drawing.Point(683, 55);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(78, 22);
            this.ellipseButton.TabIndex = 132;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // alignedDimButton
            // 
            this.alignedDimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alignedDimButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.alignedDimButton.Location = new System.Drawing.Point(601, 133);
            this.alignedDimButton.Name = "alignedDimButton";
            this.alignedDimButton.Size = new System.Drawing.Size(78, 22);
            this.alignedDimButton.TabIndex = 133;
            this.alignedDimButton.Text = "Aligned";
            this.alignedDimButton.UseVisualStyleBackColor = true;
            this.alignedDimButton.Click += new System.EventHandler(this.alignedDimButton_Click);
            // 
            // ellipticalArcButton
            // 
            this.ellipticalArcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ellipticalArcButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ellipticalArcButton.Location = new System.Drawing.Point(764, 55);
            this.ellipticalArcButton.Name = "ellipticalArcButton";
            this.ellipticalArcButton.Size = new System.Drawing.Size(78, 22);
            this.ellipticalArcButton.TabIndex = 134;
            this.ellipticalArcButton.Text = "EllipticalArc";
            this.ellipticalArcButton.UseVisualStyleBackColor = true;
            this.ellipticalArcButton.Click += new System.EventHandler(this.ellipticalArcButton_Click);
            // 
            // snappingLabel
            // 
            this.snappingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.snappingLabel.AutoSize = true;
            this.snappingLabel.Location = new System.Drawing.Point(519, 192);
            this.snappingLabel.Name = "snappingLabel";
            this.snappingLabel.Size = new System.Drawing.Size(52, 13);
            this.snappingLabel.TabIndex = 135;
            this.snappingLabel.Text = "Snapping";
            // 
            // angularDimButton
            // 
            this.angularDimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angularDimButton.Location = new System.Drawing.Point(520, 161);
            this.angularDimButton.Name = "angularDimButton";
            this.angularDimButton.Size = new System.Drawing.Size(78, 22);
            this.angularDimButton.TabIndex = 136;
            this.angularDimButton.Text = "Angular";
            this.angularDimButton.UseVisualStyleBackColor = true;
            this.angularDimButton.Click += new System.EventHandler(this.angularDimButton_Click);
            // 
            // compositeCurveButton
            // 
            this.compositeCurveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compositeCurveButton.Location = new System.Drawing.Point(519, 82);
            this.compositeCurveButton.Name = "compositeCurveButton";
            this.compositeCurveButton.Size = new System.Drawing.Size(78, 22);
            this.compositeCurveButton.TabIndex = 137;
            this.compositeCurveButton.Text = "Composite";
            this.compositeCurveButton.UseVisualStyleBackColor = true;
            this.compositeCurveButton.Click += new System.EventHandler(this.compositeCurveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel,
            this.springToolStripStatusLabel,
            this.readWriteProgressBar,
            this.rendererVersionStatusLabel,
            this.selectedCountStatusLabel,
            this.addedCountStatusLabel,
            this.removedCountStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 872);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(854, 25);
            this.statusStrip1.TabIndex = 53;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // design1
            // 
            this.design1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.design1.Cursor = System.Windows.Forms.Cursors.Default;
            this.design1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.design1.Location = new System.Drawing.Point(9, 6);
            this.design1.MinimumSize = new System.Drawing.Size(8, 8);
            this.design1.Name = "design1";
            this.design1.Rendered = displayModeSettingsRendered1;
            this.design1.Size = new System.Drawing.Size(501, 699);
            this.design1.TabIndex = 0;
            originSymbol1.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            coordinateSystemIcon1.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            viewport1.CoordinateSystemIcon = coordinateSystemIcon1;

            viewCubeIcon1.Font = null;
            viewCubeIcon1.InitialRotation = new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D);
            viewport1.ViewCubeIcon = viewCubeIcon1;
            this.design1.Viewports.Add(viewport1);
            this.design1.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
            this.design1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewport1_MouseClick);
            // 
            // endRadioButton
            // 
            this.endRadioButton.AutoSize = true;
            this.endRadioButton.Checked = true;
            this.endRadioButton.Location = new System.Drawing.Point(6, 6);
            this.endRadioButton.Name = "endRadioButton";
            this.endRadioButton.Size = new System.Drawing.Size(44, 17);
            this.endRadioButton.TabIndex = 138;
            this.endRadioButton.TabStop = true;
            this.endRadioButton.Text = "End";
            this.endRadioButton.UseVisualStyleBackColor = true;
            // 
            // midRadioButton
            // 
            this.midRadioButton.AutoSize = true;
            this.midRadioButton.Location = new System.Drawing.Point(55, 6);
            this.midRadioButton.Name = "midRadioButton";
            this.midRadioButton.Size = new System.Drawing.Size(42, 17);
            this.midRadioButton.TabIndex = 139;
            this.midRadioButton.Text = "Mid";
            this.midRadioButton.UseVisualStyleBackColor = true;
            // 
            // cenRadioButton
            // 
            this.cenRadioButton.AutoSize = true;
            this.cenRadioButton.Location = new System.Drawing.Point(102, 6);
            this.cenRadioButton.Name = "cenRadioButton";
            this.cenRadioButton.Size = new System.Drawing.Size(44, 17);
            this.cenRadioButton.TabIndex = 140;
            this.cenRadioButton.Text = "Cen";
            this.cenRadioButton.UseVisualStyleBackColor = true;
            // 
            // pointRadioButton
            // 
            this.pointRadioButton.AutoSize = true;
            this.pointRadioButton.Location = new System.Drawing.Point(209, 6);
            this.pointRadioButton.Name = "pointRadioButton";
            this.pointRadioButton.Size = new System.Drawing.Size(49, 17);
            this.pointRadioButton.TabIndex = 141;
            this.pointRadioButton.Text = "Point";
            this.pointRadioButton.UseVisualStyleBackColor = true;
            // 
            // quadRadioButton
            // 
            this.quadRadioButton.AutoSize = true;
            this.quadRadioButton.Location = new System.Drawing.Point(152, 6);
            this.quadRadioButton.Name = "quadRadioButton";
            this.quadRadioButton.Size = new System.Drawing.Size(51, 17);
            this.quadRadioButton.TabIndex = 142;
            this.quadRadioButton.Text = "Quad";
            this.quadRadioButton.UseVisualStyleBackColor = true;
            // 
            // snapPanel
            // 
            this.snapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.snapPanel.Controls.Add(this.quadRadioButton);
            this.snapPanel.Controls.Add(this.pointRadioButton);
            this.snapPanel.Controls.Add(this.cenRadioButton);
            this.snapPanel.Controls.Add(this.midRadioButton);
            this.snapPanel.Controls.Add(this.endRadioButton);
            this.snapPanel.Enabled = false;
            this.snapPanel.Location = new System.Drawing.Point(520, 235);
            this.snapPanel.Name = "snapPanel";
            this.snapPanel.Size = new System.Drawing.Size(276, 30);
            this.snapPanel.TabIndex = 143;
            // 
            // mirrorButton
            // 
            this.mirrorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorButton.Location = new System.Drawing.Point(684, 407);
            this.mirrorButton.Name = "mirrorButton";
            this.mirrorButton.Size = new System.Drawing.Size(78, 22);
            this.mirrorButton.TabIndex = 144;
            this.mirrorButton.Text = "Mirror";
            this.mirrorButton.UseVisualStyleBackColor = true;
            this.mirrorButton.Click += new System.EventHandler(this.mirrorButton_Click);
            // 
            // offsetButton
            // 
            this.offsetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.offsetButton.Location = new System.Drawing.Point(766, 407);
            this.offsetButton.Name = "offsetButton";
            this.offsetButton.Size = new System.Drawing.Size(78, 22);
            this.offsetButton.TabIndex = 145;
            this.offsetButton.Text = "Offset";
            this.offsetButton.UseVisualStyleBackColor = true;
            this.offsetButton.Click += new System.EventHandler(this.offsetButton_Click);
            // 
            // trimButton
            // 
            this.trimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trimButton.Location = new System.Drawing.Point(520, 435);
            this.trimButton.Name = "trimButton";
            this.trimButton.Size = new System.Drawing.Size(78, 22);
            this.trimButton.TabIndex = 146;
            this.trimButton.Text = "Trim";
            this.trimButton.UseVisualStyleBackColor = true;
            this.trimButton.Click += new System.EventHandler(this.trimButton_Click);
            // 
            // extendButton
            // 
            this.extendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extendButton.Location = new System.Drawing.Point(601, 435);
            this.extendButton.Name = "extendButton";
            this.extendButton.Size = new System.Drawing.Size(78, 22);
            this.extendButton.TabIndex = 147;
            this.extendButton.Text = "Extend";
            this.extendButton.UseVisualStyleBackColor = true;
            this.extendButton.Click += new System.EventHandler(this.extendButton_Click);
            // 
            // filletButton
            // 
            this.filletButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filletButton.Location = new System.Drawing.Point(684, 435);
            this.filletButton.Name = "filletButton";
            this.filletButton.Size = new System.Drawing.Size(78, 22);
            this.filletButton.TabIndex = 148;
            this.filletButton.Text = "Fillet";
            this.filletButton.UseVisualStyleBackColor = true;
            this.filletButton.Click += new System.EventHandler(this.filletButton_Click);
            // 
            // chamferButton
            // 
            this.chamferButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chamferButton.Location = new System.Drawing.Point(766, 435);
            this.chamferButton.Name = "chamferButton";
            this.chamferButton.Size = new System.Drawing.Size(78, 22);
            this.chamferButton.TabIndex = 149;
            this.chamferButton.Text = "Chamfer";
            this.chamferButton.UseVisualStyleBackColor = true;
            this.chamferButton.Click += new System.EventHandler(this.chamferButton_Click);
            // 
            // filletTextBox
            // 
            this.filletTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filletTextBox.Location = new System.Drawing.Point(684, 502);
            this.filletTextBox.Name = "filletTextBox";
            this.filletTextBox.Size = new System.Drawing.Size(76, 20);
            this.filletTextBox.TabIndex = 155;
            this.filletTextBox.Text = "10.0";
            this.filletTextBox.TextChanged += new System.EventHandler(this.filletTextBox_TextChanged);
            // 
            // fillRadLabel
            // 
            this.fillRadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fillRadLabel.AutoSize = true;
            this.fillRadLabel.Location = new System.Drawing.Point(519, 505);
            this.fillRadLabel.Name = "fillRadLabel";
            this.fillRadLabel.Size = new System.Drawing.Size(159, 13);
            this.fillRadLabel.TabIndex = 156;
            this.fillRadLabel.Text = "Fillet Radius / Chamfer Distance";
            // 
            // textButton
            // 
            this.textButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textButton.Location = new System.Drawing.Point(600, 82);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(78, 22);
            this.textButton.TabIndex = 157;
            this.textButton.Text = "Text";
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // showCurveDirectionButton
            // 
            this.showCurveDirectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showCurveDirectionButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showCurveDirectionButton.Location = new System.Drawing.Point(766, 551);
            this.showCurveDirectionButton.Name = "showCurveDirectionButton";
            this.showCurveDirectionButton.Size = new System.Drawing.Size(76, 22);
            this.showCurveDirectionButton.TabIndex = 158;
            this.showCurveDirectionButton.Text = "Show Dir.";
            this.showCurveDirectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showCurveDirectionButton.UseVisualStyleBackColor = true;
            this.showCurveDirectionButton.CheckedChanged += new System.EventHandler(this.showCurveDirectionButton_CheckedChanged);
            // 
            // ordinateVerticalButton
            // 
            this.ordinateVerticalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ordinateVerticalButton.Location = new System.Drawing.Point(683, 161);
            this.ordinateVerticalButton.Name = "ordinateVerticalButton";
            this.ordinateVerticalButton.Size = new System.Drawing.Size(78, 22);
            this.ordinateVerticalButton.TabIndex = 159;
            this.ordinateVerticalButton.Text = "Ordinate V.";
            this.ordinateVerticalButton.UseVisualStyleBackColor = true;
            this.ordinateVerticalButton.Click += new System.EventHandler(this.ordinateVerticalButton_Click);
            // 
            // ordinateHorizontalButton
            // 
            this.ordinateHorizontalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ordinateHorizontalButton.Location = new System.Drawing.Point(601, 161);
            this.ordinateHorizontalButton.Name = "ordinateHorizontalButton";
            this.ordinateHorizontalButton.Size = new System.Drawing.Size(78, 22);
            this.ordinateHorizontalButton.TabIndex = 160;
            this.ordinateHorizontalButton.Text = "Ordinate H.";
            this.ordinateHorizontalButton.UseVisualStyleBackColor = true;
            this.ordinateHorizontalButton.Click += new System.EventHandler(this.ordinateHorizontalButton_Click);
            // 
            // leaderButton
            // 
            this.leaderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leaderButton.Location = new System.Drawing.Point(764, 161);
            this.leaderButton.Name = "leaderButton";
            this.leaderButton.Size = new System.Drawing.Size(78, 22);
            this.leaderButton.TabIndex = 161;
            this.leaderButton.Text = "Leader";
            this.leaderButton.UseVisualStyleBackColor = true;
            this.leaderButton.Click += new System.EventHandler(this.leaderButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.Location = new System.Drawing.Point(520, 463);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(78, 22);
            this.moveButton.TabIndex = 162;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateButton.Location = new System.Drawing.Point(601, 463);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(78, 22);
            this.rotateButton.TabIndex = 163;
            this.rotateButton.Text = "Rotate";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // scaleButton
            // 
            this.scaleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleButton.Location = new System.Drawing.Point(684, 463);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(78, 22);
            this.scaleButton.TabIndex = 164;
            this.scaleButton.Text = "Scale";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(602, 670);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(78, 22);
            this.saveButton.TabIndex = 167;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(520, 670);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(78, 22);
            this.openButton.TabIndex = 166;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(684, 670);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(78, 22);
            this.importButton.TabIndex = 165;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(766, 670);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(76, 22);
            this.exportButton.TabIndex = 168;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // turboButton
            // 
            this.turboButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.turboButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.turboButton.Checked = false;
            this.turboButton.Location = new System.Drawing.Point(601, 698);
            this.turboButton.Name = "turboButton";
            this.turboButton.Size = new System.Drawing.Size(78, 22);
            this.turboButton.TabIndex = 140;
            this.turboButton.Text = "Turbo";
            this.turboButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.turboButton.UseVisualStyleBackColor = true;
            this.turboButton.CheckedChanged += new System.EventHandler(this.turboButton_CheckedChanged);
            // 
            // tangentsButton
            // 
            this.tangentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tangentsButton.Location = new System.Drawing.Point(682, 82);
            this.tangentsButton.Name = "tangentsButton";
            this.tangentsButton.Size = new System.Drawing.Size(78, 22);
            this.tangentsButton.TabIndex = 169;
            this.tangentsButton.Text = "Tangents";
            this.tangentsButton.UseVisualStyleBackColor = true;
            this.tangentsButton.Click += new System.EventHandler(this.tangentsButton_Click);
            // 
            // hatchButton
            // 
            this.hatchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hatchButton.Location = new System.Drawing.Point(764, 82);
            this.hatchButton.Name = "hatchButton";
            this.hatchButton.Size = new System.Drawing.Size(78, 22);
            this.hatchButton.TabIndex = 104;
            this.hatchButton.Text = "Hatch";
            this.hatchButton.UseVisualStyleBackColor = true;
            this.hatchButton.Click += new System.EventHandler(this.hatchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(854, 897);
            this.Controls.Add(this.hatchButton);
            this.Controls.Add(this.tangentsButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.scaleButton);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.leaderButton);
            this.Controls.Add(this.ordinateHorizontalButton);
            this.Controls.Add(this.ordinateVerticalButton);
            this.Controls.Add(this.showCurveDirectionButton);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.fillRadLabel);
            this.Controls.Add(this.filletTextBox);
            this.Controls.Add(this.chamferButton);
            this.Controls.Add(this.filletButton);
            this.Controls.Add(this.extendButton);
            this.Controls.Add(this.trimButton);
            this.Controls.Add(this.offsetButton);
            this.Controls.Add(this.mirrorButton);
            this.Controls.Add(this.snapPanel);
            this.Controls.Add(this.compositeCurveButton);
            this.Controls.Add(this.angularDimButton);
            this.Controls.Add(this.snappingLabel);
            this.Controls.Add(this.gridSnapCheckBox);
            this.Controls.Add(this.ellipticalArcButton);
            this.Controls.Add(this.objectSnapCheckBox);
            this.Controls.Add(this.alignedDimButton);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.dimLabel);
            this.Controls.Add(this.DiametricDimButton);
            this.Controls.Add(this.RadialDimButton);
            this.Controls.Add(this.LinearDimButton);
            this.Controls.Add(this.pointButton);
            this.Controls.Add(this.plineButton);
            this.Controls.Add(this.splineButton);
            this.Controls.Add(this.circleButton);
            this.Controls.Add(this.arcButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.selectCheckBox);
            this.Controls.Add(this.selectionComboBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableTabControl);
            this.Controls.Add(this.design1);
            this.Controls.Add(this.groupButton);
            this.Controls.Add(this.explodeButton);
            this.Controls.Add(this.miscLabel);
            this.Controls.Add(this.vectorLabel);
            this.Controls.Add(this.vectorSaveButton);
            this.Controls.Add(this.vectorCopyToClipbardButton);
            this.Controls.Add(this.dumpButton);
            this.Controls.Add(this.showGridButton);
            this.Controls.Add(this.pickVertexButton);
            this.Controls.Add(this.inspectionLabel);
            this.Controls.Add(this.editingLabel);
            this.Controls.Add(this.selectionLabel);
            this.Controls.Add(this.hideShowLabel);
            this.Controls.Add(this.shadingLabel);
            this.Controls.Add(this.websiteButton);
            this.Controls.Add(this.turboButton);
            this.Controls.Add(this.pageSetupButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.showVerticesButton);
            this.Controls.Add(this.showExtentsButton);
            this.Controls.Add(this.showOriginButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.invertSelectionButton);
            this.Controls.Add(this.clearSelectionButton);
            this.Controls.Add(this.printPreviewButton);
            this.Controls.Add(this.areaButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Drafting Demo";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.design1)).EndInit();
            this.snapPanel.ResumeLayout(false);
            this.snapPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Drafting2D design1;
        private System.Windows.Forms.Button printPreviewButton;
        private System.Windows.Forms.Button invertSelectionButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox showVerticesButton;
        private System.Windows.Forms.CheckBox showExtentsButton;
        private System.Windows.Forms.CheckBox showOriginButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button pageSetupButton;
        private System.Windows.Forms.Button websiteButton;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel springToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar readWriteProgressBar;
        public System.Windows.Forms.ToolStripStatusLabel selectedCountStatusLabel;
        public System.Windows.Forms.ToolStripStatusLabel addedCountStatusLabel;
        public System.Windows.Forms.ToolStripStatusLabel removedCountStatusLabel;
        private System.Windows.Forms.Label shadingLabel;
        private System.Windows.Forms.Label hideShowLabel;
        private System.Windows.Forms.Label selectionLabel;
        private System.Windows.Forms.Label editingLabel;
        private TableTabControl tableTabControl;
        private System.Windows.Forms.CheckBox pickVertexButton;
        private System.Windows.Forms.Label inspectionLabel;
        public System.Windows.Forms.ToolStripStatusLabel rendererVersionStatusLabel;
        private System.Windows.Forms.CheckBox showGridButton;
        private System.Windows.Forms.Button dumpButton;
        private System.Windows.Forms.Button vectorSaveButton;
        private System.Windows.Forms.Button vectorCopyToClipbardButton;
        private System.Windows.Forms.Button zoomSelButton;
        private System.Windows.Forms.Label vectorLabel;
        private System.Windows.Forms.Label miscLabel;
        private System.Windows.Forms.Button explodeButton;
        private System.Windows.Forms.Button areaButton;
        private System.Windows.Forms.Button groupButton;
        private System.Windows.Forms.ComboBox selectionComboBox;
        private System.Windows.Forms.Button clearSelectionButton;
        private System.Windows.Forms.CheckBox selectCheckBox;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button arcButton;        
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button splineButton;
        private System.Windows.Forms.Button plineButton;
        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.CheckBox objectSnapCheckBox;
        private System.Windows.Forms.CheckBox gridSnapCheckBox;
        private System.Windows.Forms.Button LinearDimButton;
        private System.Windows.Forms.Button RadialDimButton;
        private System.Windows.Forms.Button DiametricDimButton;
        private System.Windows.Forms.Label dimLabel;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button alignedDimButton;
        private System.Windows.Forms.Button ellipticalArcButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label snappingLabel;
        private System.Windows.Forms.Button angularDimButton;
        private System.Windows.Forms.Button compositeCurveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RadioButton endRadioButton;
        private System.Windows.Forms.RadioButton midRadioButton;
        private System.Windows.Forms.RadioButton cenRadioButton;
        private System.Windows.Forms.RadioButton pointRadioButton;
        private System.Windows.Forms.RadioButton quadRadioButton;
        private System.Windows.Forms.Panel snapPanel;
        private System.Windows.Forms.Button mirrorButton;
        private System.Windows.Forms.Button offsetButton;
        private System.Windows.Forms.Button trimButton;
        private System.Windows.Forms.Button extendButton;
        private System.Windows.Forms.Button filletButton;
        private System.Windows.Forms.Button chamferButton;
        private System.Windows.Forms.TextBox filletTextBox;
        private System.Windows.Forms.Label fillRadLabel;
        private System.Windows.Forms.Button textButton;
        private System.Windows.Forms.CheckBox showCurveDirectionButton;
        private System.Windows.Forms.Button ordinateVerticalButton;
        private System.Windows.Forms.Button ordinateHorizontalButton;
        private System.Windows.Forms.Button leaderButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.CheckBox turboButton;
        private System.Windows.Forms.Button tangentsButton;
        private System.Windows.Forms.Button hatchButton;
    }
}
