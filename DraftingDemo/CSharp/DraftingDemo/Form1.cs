using System;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Graphics;
using devDept.Geometry;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Control.Labels;
using System.Text;
using System.Collections.Generic;
using System.IO;
using devDept.CustomControls;
using devDept.Eyeshot.Translators;
using devDept.Serialization;
using System.ComponentModel;
using devDept.CustomControls.Controls.Drafting;
using devDept.Eyeshot.Control;
using static devDept.LicenseManager;

namespace WindowsApplication1
{

    public partial class Form1 : Form
    {
        private Bitmap _logoPdf;
        public TangentsForm TangentsForm;
        private BlockReference _brJittering;

        public Form1()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call. 

            

            // Event handlers
            tableTabControl.LayerListView.SelectedIndexChanged += SelectedIndexChanged;
            design1.SelectionChanged += design1_SelectionChanged;
            design1.WorkCompleted += design1_WorkCompleted;
            design1.WorkCancelled += design1_WorkCancelled;
            design1.WorkFailed += design1_WorkFailed;
            design1.CameraMoveBegin += design1_CameraMoveBegin;
            
            endRadioButton.CheckedChanged += radioButtons_CheckedChanged;
            midRadioButton.CheckedChanged += radioButtons_CheckedChanged;
            cenRadioButton.CheckedChanged += radioButtons_CheckedChanged;
            pointRadioButton.CheckedChanged += radioButtons_CheckedChanged;
            quadRadioButton.CheckedChanged += radioButtons_CheckedChanged;

            if (ProductEdition == licenseType.Pro)
            {
                extendButton.Enabled = false;
                trimButton.Enabled = false;
                filletButton.Enabled = false;
                chamferButton.Enabled = false;
                splineButton.Enabled = false;
            }

        }



#if SETUP
        private readonly BitnessAgnostic _helper = new BitnessAgnostic();
#endif

        protected override void OnLoad(EventArgs e)
        {
            AddDashdotsHatchPattern();

            design1.Layers[0].LineWeight = 2;
            design1.Layers[0].Color = design1.DrawingColor;
            design1.Layers.TryAdd(new Layer("Dimensions", Color.DarkCyan));
            design1.Layers[1].LineWeight = 0.15f;
            design1.Layers.TryAdd(new Layer("Reference geometry", Color.Red));
            
            tableTabControl.Workspace = design1;
            design1.ActiveLayerName = design1.Layers[0].Name;
            design1.DimensionLayerName = design1.Layers[1].Name;

            selectionComboBox.SelectedIndex = 0;

            rendererVersionStatusLabel.Text = design1.RendererVersion.ToString();
            
            design1.SetView(viewType.Top);
            design1.ActiveViewport.Rotate.Enabled = false;

            base.OnLoad(e);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);

            // speed up the resize of the control
            design1.ResizeBegin();
        }

        protected override void OnShown(EventArgs e)
        {
            design1.Focus();

            EnableControls(false);
#if SETUP            
            string fileName = Path.Combine(devDept.Eyeshot.Control.Workspace.GetSamplesFolder(), @"dataset\Assets\Misc\app8.dwg");
            ReadFileAsync ra = _helper.GetReadAutodesk(design1, fileName);
#else
            _logoPdf = new Bitmap("../../../../../../dataset/Assets/Pictures/Logo_big.png");

            ReadAutodesk ra = new ReadAutodesk("../../../../../../dataset/Assets/Misc/app8.dwg");
#endif
            design1.StartWork(ra);

            base.OnShown(e);
        }
        private void AddDashdotsHatchPattern()
        {
            // creates an Hatch Pattern
            string dashDotHatchPattern = "DASHDOTS";
            HatchPatternLine hpl = new HatchPatternLine(0, Point2D.Origin, 0, 1, new float[] { 5, -1.5f, 0, -1.5f });
            HatchPatternLine hpl2 = new HatchPatternLine(Utility.PI_2, Point2D.Origin, 0, 1, new float[] { 5, -1.5f, 0, -1.5f });
            design1.HatchPatterns.Add(new HatchPattern(dashDotHatchPattern, new HatchPatternLine[] { hpl, hpl2 }));
        }

        #region Hide/Show

        private void showOriginButton_CheckedChanged(object sender, EventArgs e)
        {
            design1.ActiveViewport.OriginSymbol.Visible = showOriginButton.Checked;
            design1.Invalidate();
        }

        private void showExtentsButton_CheckedChanged(object sender, EventArgs e)
        {
            design1.BoundingBox.Visible = showExtentsButton.Checked;
            design1.Invalidate();
        }

        private void showVerticesButton_CheckedChanged(object sender, EventArgs e)
        {
            design1.ActiveViewport.ShowVertices = showVerticesButton.Checked;
            design1.Invalidate();
        }

        private void showGridButton_CheckedChanged(object sender, EventArgs e)
        {
            design1.ActiveViewport.Grid.Visible = showGridButton.Checked;
            design1.Invalidate();
        }

#endregion

#region Selection 

        private void selectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupButton.Enabled = true;

            if (selectCheckBox.Checked)

                Selection();
        }

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupButton.Enabled = true;

            if (selectCheckBox.Checked)
            {
                ClearPreviousSelection();
                Selection();
            }
            else
                design1.ActionMode = actionType.None;
        }

        private void Selection()
        {
            switch (selectionComboBox.SelectedIndex)
            {
                case 0: // by pick
                    design1.ActionMode = actionType.SelectByPick;
                    break;

                case 1: // by box
                    design1.ActionMode = actionType.SelectByBox;
                    break;

                case 2: // by poly
                    design1.ActionMode = actionType.SelectByPolygon;
                    break;

                case 3: // by box enclosed
                    design1.ActionMode = actionType.SelectByBoxEnclosed;
                    break;

                case 4: // by poly enclosed
                    design1.ActionMode = actionType.SelectByPolygonEnclosed;
                    break;

                case 5: // visible by pick dynamic
                    design1.ActionMode = actionType.SelectVisibleByPickDynamic;
                    break;

                default:
                    design1.ActionMode = actionType.None;
                    break;
            }
        }

        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            if (design1.ActionMode == actionType.SelectVisibleByPickLabel)

                design1.Viewports[0].Labels.ClearSelection();

            else

                design1.Entities.ClearSelection();

            design1.Invalidate();
        }

        private void invertSelectionButton_Click(object sender, EventArgs e)
        {
            if (design1.ActionMode == actionType.SelectVisibleByPickLabel)

                design1.Viewports[0].Labels.InvertSelection();

            else

                design1.Entities.InvertSelection();

            design1.Invalidate();
        }

        private void groupButton_Click(object sender, EventArgs e)
        {
            design1.CurrentBlock.GroupSelection();
        }

#endregion

        #region Editing

        private void deleteButton_Click(object sender, EventArgs e)
        {
            design1.Entities.DeleteSelected();
            design1.Invalidate();
        }

        private void explodeButton_Click(object sender, EventArgs e)
        {

            for (int i = design1.Entities.Count - 1; i >= 0; i--)
            {

                Entity ent = design1.Entities[i];

                if (ent.Selected)
                {
                    if (ent is BlockReference)
                    {

                        design1.Entities.RemoveAt(i);

                        BlockReference br = (BlockReference)ent;

                        Entity[] entList = design1.Entities.Explode(br);

                        design1.Entities.AddRange(entList);

                    }

                    else if (ent is CompositeCurve)
                    {

                        design1.Entities.RemoveAt(i);

                        CompositeCurve cc = (CompositeCurve)ent;

                        design1.Entities.AddRange(cc.Explode());

                    }
                    else if (ent is Hatch)
                    {
                        design1.Entities.RemoveAt(i);

                        Hatch ht = (Hatch)ent;

                        Entity[] entlist =  ht.Explode();

                        design1.Entities.AddRange(entlist);
                       
                    }
                    else if (ent.GroupIndex > -1)
                    {
                        design1.CurrentBlock.Ungroup(ent.GroupIndex);
                    }
                }
            }

            design1.Invalidate();
        }

        private void trimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingTrim = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void extendButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingExtend = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void offsetButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingOffset = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void mirrorButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingMirror = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void filletButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingFillet = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void chamferButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.doingChamfer = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            design1.selEntities.Clear();

            for (int i = design1.Entities.Count - 1; i > -1; i--)
            {
                Entity ent = design1.Entities[i];
                if (ent.Selected && (ent is ICurve || ent is BlockReference || ent is Text || ent is Leader))
                {
                    design1.selEntities.Add(ent);
                }
            }

            if (design1.selEntities.Count == 0)
                return;

            ClearPreviousSelection();
            design1.doingMove = true;
            foreach (Entity curve in design1.selEntities)
                curve.Selected = true;
            Cursor.Hide();
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            design1.selEntities.Clear();

            for (int i = design1.Entities.Count - 1; i > -1; i--)
            {
                Entity ent = design1.Entities[i];
                if (ent.Selected && (ent is ICurve || ent is BlockReference || ent is Text || ent is Leader))
                {
                    design1.selEntities.Add(ent);
                }
            }

            if (design1.selEntities.Count == 0)
                return;

            ClearPreviousSelection();
            design1.doingRotate = true;
            foreach (Entity curve in design1.selEntities)
                curve.Selected = true;

            Cursor.Hide();
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            design1.selEntities.Clear();

            for (int i = design1.Entities.Count - 1; i > -1; i--)
            {
                Entity ent = design1.Entities[i];
                if (ent.Selected && (ent is ICurve || ent is BlockReference || ent is Text || ent is Leader))
                {
                    design1.selEntities.Add(ent);
                }
            }

            if (design1.selEntities.Count == 0)
                return;

            ClearPreviousSelection();
            design1.doingScale = true;
            foreach (Entity curve in design1.selEntities)
                curve.Selected = true;

            Cursor.Hide();
        }

        private void tangentsButton_Click(object sender, EventArgs e)
        {
            TangentsForm = new TangentsForm();
            TangentsForm.StartPosition = FormStartPosition.CenterParent;
            TangentsForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            if (TangentsForm.ShowDialog(this) == DialogResult.OK)
            {

                design1.lineTangents = TangentsForm.LineTangents;

                design1.circleTangents = TangentsForm.CircleTangents;

                design1.tangentsRadius = TangentsForm.TangentRadius;

                design1.trimTangent = TangentsForm.TrimTangents;

                design1.flipTangent = TangentsForm.FlipTangents;

                ClearPreviousSelection();

                design1.doingTangents = true;

                design1.WaitingForSelection = true;

                Cursor.Hide();
            }
        }

        private void hatchButton_Click(object sender, EventArgs e)
        {
            List<ICurve> selectedCurveList = new List<ICurve>();

            for (int i = 0; i < design1.Entities.Count; i++)
            {
                Entity ent = design1.Entities[i];
                if (ent.Selected && ent is ICurve)
                {
                    ICurve selCurve = (ICurve)ent;
                    if (selCurve.IsClosed)
                        selectedCurveList.Add(selCurve);
                }
            }

            if (selectedCurveList.Count > 0)
            {
                Hatch dotsHatch = new Hatch(design1.HatchPatterns[0].Name, selectedCurveList, Plane.XY){PatternAngle = Utility.QUARTER_PI};
                design1.Entities.Add(dotsHatch, design1.ActiveLayerName);
                design1.Entities.ClearSelection();
                design1.Invalidate();
            }
            else
            {
                MessageBox.Show("Please, select at least one closed curve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Inspection

        bool inspectVertex;

        private void pickVertexButton_Click(object sender, EventArgs e)
        {

            design1.ActionMode = actionType.None;
            selectCheckBox.Checked = false;

            inspectVertex = false;

            if (pickVertexButton.Checked)
            {
                inspectVertex = true;

                mainStatusLabel.Text = "Click on the entity to retrieve the 3D coordinates";

            }
            else
            {
                mainStatusLabel.Text = "";
            }
        }

        private void viewport1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            // Checks that we are not using left mouse button for ZPR
            if (design1.ActionMode == actionType.None)
            {
                selectCheckBox.Checked = false;
                Point3D closest;

                if (inspectVertex)
                {

                    if (design1.FindClosestVertex(e.Location, 50, out closest) != -1)

                        design1.ActiveViewport.Labels.Add(new devDept.Eyeshot.Control.Labels.LeaderAndText(closest, closest.ToString(), new Font("Tahoma", 8.25f), design1.DrawingColor, new Vector2D(0, 50)));

                }

                design1.Invalidate();

            }


        }

        private void dumpButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < design1.Entities.Count; i++)
            {
                if (design1.Entities[i].Selected)
                {
                    string details = "Entity ID = " + i + System.Environment.NewLine + "----------------------" + System.Environment.NewLine + design1.Entities[i].Dump();

                    DetailsForm rf = new DetailsForm();

                    rf.Text = "Dump";

                    rf.contentTextBox.Text = details;

                    rf.Show();

                    break;
                }
            }
        }

        private void areaButton_Click(object sender, EventArgs e)
        {

            AreaProperties ap = new AreaProperties();

            int count = 0;

            for (int i = 0; i < design1.Entities.Count; i++)
            {

                Entity ent = design1.Entities[i];

                if (ent.Selected)
                {
                    ICurve itfCurve = (ICurve)ent;

                    if (itfCurve.IsClosed)

                        ap.Add(ent.Vertices);

                    count++;
                }

            }

            StringBuilder text = new StringBuilder();
            text.AppendLine(count + " entity(ies) selected");
            text.AppendLine("---------------------");

            if (ap.Centroid != null)
            {

                double x, y, z;
                double xx, yy, zz, xy, zx, yz;
                MomentOfInertia world, centroid;

                ap.GetResults(ap.Area, ap.Centroid, out x, out y, out z, out xx, out yy, out zz, out xy, out zx, out yz, out world, out centroid);

                text.AppendLine("Cumulative area: " + ap.Area + " square " + design1.CurrentBlock.Units.ToString().ToLower());
                text.AppendLine("Cumulative centroid: " + ap.Centroid);
                text.AppendLine("Cumulative area moments:");
                text.AppendLine(" First moments");
                text.AppendLine("  x: " + x.ToString("g6"));
                text.AppendLine("  y: " + y.ToString("g6"));
                text.AppendLine("  z: " + z.ToString("g6"));
                text.AppendLine(" Second moments");
                text.AppendLine("  xx: " + xx.ToString("g6"));
                text.AppendLine("  yy: " + yy.ToString("g6"));
                text.AppendLine("  zz: " + zz.ToString("g6"));
                text.AppendLine(" Product moments");
                text.AppendLine("  xy: " + xx.ToString("g6"));
                text.AppendLine("  yz: " + yy.ToString("g6"));
                text.AppendLine("  zx: " + zz.ToString("g6"));
                text.AppendLine(" Area Moments of Inertia about World Coordinate Axes");
                text.AppendLine("  Ix: " + world.Ix.ToString("g6"));
                text.AppendLine("  Iy: " + world.Iy.ToString("g6"));
                text.AppendLine("  Iz: " + world.Iz.ToString("g6"));
                text.AppendLine(" Area Radii of Gyration about World Coordinate Axes");
                text.AppendLine("  Rx: " + world.Rx.ToString("g6"));
                text.AppendLine("  Ry: " + world.Ry.ToString("g6"));
                text.AppendLine("  Rz: " + world.Rz.ToString("g6"));
                text.AppendLine(" Area Moments of Inertia about Centroid Coordinate Axes:");
                text.AppendLine("  Ix: " + centroid.Ix.ToString("g6"));
                text.AppendLine("  Iy: " + centroid.Iy.ToString("g6"));
                text.AppendLine("  Iz: " + centroid.Iz.ToString("g6"));
                text.AppendLine(" Area Radii of Gyration about Centroid Coordinate Axes");
                text.AppendLine("  Rx: " + centroid.Rx.ToString("g6"));
                text.AppendLine("  Ry: " + centroid.Ry.ToString("g6"));
                text.AppendLine("  Rz: " + centroid.Rz.ToString("g6"));

            }

            DetailsForm rf = new DetailsForm();

            rf.Text = "Area Properties";

            rf.contentTextBox.Text = text.ToString();

            rf.Show();
        }

        #endregion

#region Read/Write

        private bool _yAxisUp = false;
        private bool _jittering = false;
        private bool _insertAsBlock = false;

        private void openButton_Click(object sender, EventArgs e)
        {
            _yAxisUp = false;
            _jittering = false;

            ReadFile readFile = ImportExportHelper.ShowOpenDialog(out _insertAsBlock, true);

            if (readFile == null) return;

            if (!_insertAsBlock)
            {
                design1.Clear();
                AddDashdotsHatchPattern();                      
            }

            EnableControls(false);

            design1.StartWork(readFile);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            WriteFile writeFile = ImportExportHelper.ShowSaveDialog(design1);
            if (writeFile != null)
            {
                design1.StartWork(writeFile);
                EnableControls(false);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string fileName;
            ImportExportHelper.ShowImportDialog(importFormats.Autodesk, out fileName, out _yAxisUp, out _jittering, out _insertAsBlock);
            if (fileName != null)
            {
                ReadFileAsync rfa = GetReader(fileName);
                if (!_insertAsBlock)
                {
                    design1.Clear();
                    AddDashdotsHatchPattern();
                }
                        
                EnableControls(false);

                if(rfa != null)
                    design1.StartWork(rfa);                 
            }
        }

        private ReadFileAsync GetReader(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);

            if (ext != null)
            {
                ext = ext.TrimStart('.').ToLower();

                switch (ext)
                {
                    case "dwg":
                    case "dxf":
#if SETUP
                        ReadFileAsync ra = _helper.GetReadAutodesk(design1, fileName);
#else
                        ReadAutodesk ra = new ReadAutodesk(fileName);
#endif
                        return ra;

                    case "dwf":
                    case "dwfx":
#if SETUP
                        ReadFileAsync rd = _helper.GetReadDWF(design1, fileName);
#else
                        ReadDWF rd = new ReadDWF(fileName);
#endif
                        return rd;
                }
            }

            return ImportExportHelper.GetImportReader(fileName);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            string fileName;
            ImportExportHelper.ShowExportDialog(design1, exportFormats.Autodesk, out fileName);
            if (!string.IsNullOrEmpty(fileName))
            {
                WriteFileAsync wfa = GetWriter(design1, fileName);
                if (wfa != null)
                {
                    EnableControls(false);
                    design1.StartWork(wfa);
                }
            }
        }

        public WriteFileAsync GetWriter(Design design, string fileName)
        {
            WriteFileAsync wfa = null;
            string ext = Path.GetExtension(fileName);
            if (ext != null)
            {
                ext = ext.TrimStart('.').ToLower();
                switch (ext)
                {
                    case "dxf":
                    case "dwg":
                        WriteParams dataParams = new WriteAutodeskParams(design.Document, null, false, false, 1D, !design.IsOpenRootLevel);
#if SETUP
                        wfa = _helper.GetWriteAutodesk(design, null, false, fileName);
#else
                        wfa = new WriteAutodesk((WriteAutodeskParams)dataParams, fileName);
#endif
                        break;
                    case "pdf":
#if SETUP
                        wfa = _helper.GetWrite3DPDF(design, fileName);
#else
                        var writeParams = new Write3DPdfParams(design1.Document, new Size(842, 595), new Rectangle(20, 40, 802, 495), false, !design.IsOpenRootLevel)
                        {
                            ViewBorderWidth = 0,
                            BackGroundColor = design.ActiveViewport.Background.TopColor
                        };
                        wfa = new MyWrite3DPDF(writeParams, fileName, _logoPdf);
#endif
                        break;
                    default:
                        wfa = ImportExportHelper.GetExportWriter(fileName, design);
                        break;
                }
            }
            return wfa;
        }

        private void EnableControls(bool status)
        {
            foreach (Control control in Controls)
            {
                if (control is Design == false)
                {
                    control.Enabled = status;
                }
            }

            if (ProductEdition == licenseType.Pro)
            {
                extendButton.Enabled = false;
                trimButton.Enabled = false;
                filletButton.Enabled = false;
                chamferButton.Enabled = false;
                splineButton.Enabled = false;
            }

        }
#endregion

#region Event handlers
        private bool _skipZoomFit;

        private void design1_WorkCompleted(object sender, devDept.WorkCompletedEventArgs e)
        {
            // checks the WorkUnit type, more than one can be present in the same application 
            if (e.WorkUnit is ReadFileAsync)
            {
                _brJittering = null;
                ReadFileAsync rfa = (ReadFileAsync)e.WorkUnit;

                ReadFile rf = e.WorkUnit as ReadFile;
                if (rf != null)
                {
                    _skipZoomFit = rf.Camera != null;
                }
                else
                    _skipZoomFit = false;

                if (rfa.Entities != null && _yAxisUp)
                    rfa.RotateEverythingAroundX();

                if (_insertAsBlock)
                {
                    _brJittering = ImportExportHelper.InsertAsBlock(design1, rfa, new RegenOptions() { Async = true });

                    _skipZoomFit = false;
                }

                else rfa.AddTo(design1);

                if (_jittering && _insertAsBlock) design1.RemoveJittering(_brJittering);

                else if (_jittering)
                {
                    design1.Entities.SelectAll();
                    design1.RemoveJittering();
                }

                ReadPDF readPdf = rfa as ReadPDF;
                if (readPdf != null)
                {
                    foreach (var ent in readPdf.Pages[0].Entities)
                    {
                        if (ent.Color.ToArgb() == design1.ActiveViewport.Background.TopColor.ToArgb())
                            ent.Color = Color.White;
                    }
                }


                if (Path.GetFileName(rfa.FileName) == "app8.dwg")
                {
                    foreach (Entity ent in design1.Entities)
                    {
                        ent.Translate(-170, -400);
                    }

                    design1.Entities.Regen();
                    design1.ActiveViewport.Camera.Target = new Point3D(60, 2.5, 0);
                    design1.ActiveViewport.Camera.ZoomFactor = 2;
                    _skipZoomFit = true;
                }

                design1.Layers[0].LineWeight = 2;
                design1.Layers[0].Color = design1.DrawingColor;
                design1.Layers.TryAdd(new Layer("Dimensions", Color.ForestGreen));
                design1.Layers.TryAdd(new Layer("Reference geometry", Color.Red));
                tableTabControl.Sync();

                if (!_skipZoomFit)
                    design1.SetView(viewType.Top, true, false);
            }

            if (!String.IsNullOrEmpty(e.WorkUnit.Log))
                tableTabControl.ShowLog($"{e.WorkUnit.GetType().Name} log", e.WorkUnit.Log);

            EnableControls(true);
        }

        private void design1_WorkFailed(object sender, devDept.WorkFailedEventArgs e)
        {
            if (e.Exception is OutOfMemoryException)
            {
                MessageBox.Show("This demo relies on OpenDesign libraries for DWG/DXF export and it is currently compiled against x86. Using the x64 version, this problem will disappear.", "Out of Memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableControls(true);
        }

        private void design1_WorkCancelled(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void design1_CameraMoveBegin(object sender, devDept.Eyeshot.Control.CameraMoveEventArgs e)
        {
            // refresh FastZPR button according to FastZPR enable status.
            UpdateTurboButton();
        }

        private int _maxComplexity = 30000;
        private void turboButton_CheckedChanged(object sender, EventArgs e)
        {
            if (turboButton.CheckState == CheckState.Unchecked)
            {
                _maxComplexity = design1.Turbo.MaxComplexity;
                design1.Turbo.MaxComplexity = int.MaxValue;
            }
            else
            {
                design1.Turbo.MaxComplexity = _maxComplexity;
            }

            design1.UpdateBoundingBox();
            UpdateTurboButton();
            design1.Invalidate();
        }

        private void UpdateTurboButton()
        {
            if (design1.Turbo.Enabled)
            {
                this.turboButton.BackColor = System.Drawing.Color.LightGreen;
                turboButton.UseVisualStyleBackColor = false;
            }
            else
            {
                this.turboButton.BackColor = System.Drawing.Color.Black;
                turboButton.UseVisualStyleBackColor = true;
            }
        }

        private void websiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.devdept.com");
        }

        private void design1_SelectionChanged(object sender, devDept.Eyeshot.Control.SelectionChangedEventArgs e)
        {

            int count = 0;

            // counts selected entities
            foreach (Entity ent in design1.Entities)

                if (ent.Selected)

                    count++;
            

            // updates count on the status bar
            selectedCountStatusLabel.Text = count.ToString();
            addedCountStatusLabel.Text = e.AddedItems.Count.ToString();
            removedCountStatusLabel.Text = e.RemovedItems.Count.ToString();

        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {

            if (endRadioButton.Checked)

                design1.ActiveObjectSnap = objectSnapType.End;

            else if (midRadioButton.Checked)

                design1.ActiveObjectSnap = objectSnapType.Mid;

            else if (cenRadioButton.Checked)

                design1.ActiveObjectSnap = objectSnapType.Center;

            else if (quadRadioButton.Checked)

                design1.ActiveObjectSnap = objectSnapType.Quad;

            else if (pointRadioButton.Checked)

                design1.ActiveObjectSnap = objectSnapType.Point;

        }

        private void filletTextBox_TextChanged(object sender, EventArgs e)
        {
            if (design1 == null)
                return;

            double val;
            if (Double.TryParse(filletTextBox.Text, out val))
            {
                design1.filletRadius = val;
            }
        }

        private void showCurveDirectionButton_CheckedChanged(object sender, EventArgs e)
        {
            design1.ShowCurveDirection = showCurveDirectionButton.Checked;
            design1.Invalidate();
        }
#endregion

#region Imaging

        private void printButton_Click(object sender, EventArgs e)
        {
            design1.Print();
        }

        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            design1.PrintPreview(new Size(500, 400));
        }

        private void pageSetupButton_Click(object sender, EventArgs e)
        {
            design1.PageSetup();
        }

        private void vectorCopyToClipbardButton_Click(object sender, EventArgs e)
        {
            design1.CopyToClipboardVector(false);

            //set capture property to false, otherwise the first mouse click is skipped
            vectorCopyToClipbardButton.Capture = false;
        }

        private void vectorSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();

            mySaveFileDialog.Filter = "Enhanced Windows Metafile (*.emf)|*.emf";
            mySaveFileDialog.RestoreDirectory = true;

            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // To save as dxf/dwg, see the class HiddenLinesViewOnFileAutodesk available in x86 and x64 dlls
                design1.WriteToFileVector(false, mySaveFileDialog.FileName);

                //set capture property to false, otherwise the first mouse click is skipped
                vectorSaveButton.Capture = false;
            }
        }

#endregion

#region Drafting

        private void pointButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingPoints = true;
           
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingText = true;
        }

        private void leaderButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingLeader = true;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingLine = true;
        }

        private void plineButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingPolyLine = true;
        }

        private void arcButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingArc = true;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingCircle = true;
        }

        private void splineButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingCurve = true;
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingEllipse = true;
        }

        private void ellipticalArcButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingEllipticalArc = true;
        }

        private void compositeCurveButton_Click(object sender, EventArgs e)
        {
            design1.CreateCompositeCurve();
        }

        private void objectSnapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (objectSnapCheckBox.Checked)
            {
                design1.ObjectSnapEnabled = true;
                snapPanel.Enabled = true;
            }
            else
            {
                design1.ObjectSnapEnabled = false;
                snapPanel.Enabled = false;
            }
        }

        private void gridSnapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gridSnapCheckBox.Checked)
                design1.GridSnapEnabled = true;
            else
                design1.GridSnapEnabled = false;
        }

        private void linearDimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingLinearDim = true;
        }

        private void ordinateVerticalButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingOrdinateDim = true;
            design1.drawingOrdinateDimVertical = true;
        }

        private void ordinateHorizontalButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingOrdinateDim = true;
            design1.drawingOrdinateDimVertical = false;
        }

        private void radialDimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingRadialDim = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void diametricDimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingDiametricDim = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void alignedDimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingAlignedDim = true;
        }

        private void angularDimButton_Click(object sender, EventArgs e)
        {
            ClearPreviousSelection();
            design1.drawingAngularDim = true;
            design1.WaitingForSelection = true;
            Cursor.Hide();
        }

        private void ClearPreviousSelection()
        {
            design1.SetView(viewType.Top, false, true);
            design1.ClearAllPreviousCommandData();
        }

#endregion

#region Layers
        

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableTabControl.LayerListView.SelectedItems.Count > 0)
            {
                design1.ActiveLayerName = tableTabControl.LayerListView.SelectedItem.Text;
            }
            else // nothing selected? we force layer zero
            {
                design1.ActiveLayerName = design1.Layers[0].Name;
            }
        }

#endregion


    }

   

    public class MyWrite3DPDF : Write3DPDF
    {
        private Bitmap _logo;

        public MyWrite3DPDF(Write3DPdfParams writeParams, string fileName, Bitmap logo) : base(writeParams, fileName)
        {
            _logo = logo;
        }

        public MyWrite3DPDF(Write3DPdfParams writeParams, Stream stream, Bitmap logo) : base(writeParams, stream)
        {
            _logo = logo;
        }

        protected override void BuildDocument()
        {
            // Add a page
            int pageIndex = AddPage(paperSize.Width, paperSize.Height);

            // Add the 3D view of the model
            AddDesign(pageIndex, viewRect, backGroundColor, transparentBackground, borderWidth, toolbarVisibility, renderingMode, "Default", "Default");

            // Add frame and line
            AddFrame(pageIndex, new Point2D(20, 20), new Point2D(822, 575), Color.Black);
            AddLine(pageIndex, new Point2D(20, 40), new Point2D(822, 40), Color.Black);
            AddLine(pageIndex, new Point2D(20, 535), new Point2D(822, 535), Color.Black);

            // Add logo
            AddImage(pageIndex, _logo, new Rectangle(30, 543, 88, 20));

            // Add header text
            AddText(pageIndex, System.IO.Path.GetFileNameWithoutExtension(FileName), new Rectangle(390, 548, 80, 20), Color.Black, standardFontsType.HelveticaBold, 15);

            // Add footer text
            AddText(pageIndex, "Generated by a .NET application based on Eyeshot, from devDept Software S.r.l. (www.devdept.com)", new Rectangle(30, 27, 80, 10), Color.Black, standardFontsType.Helvetica, 10);
            AddText(pageIndex, DateTime.Now.ToString("MM/dd/yyyy h:mm tt"), new Rectangle(720, 27, 80, 10), Color.Black, standardFontsType.Helvetica, 10);
        }
    }

}