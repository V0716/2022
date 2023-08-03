using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using System.Linq;
using devDept.Eyeshot.Translators;
using devDept.CustomControls;
using static devDept.LicenseManager;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private static readonly Color NOT_MODIFIED_COLOR = Color.FromArgb(44, 44, 44); 

        public Form1()
        {
            InitializeComponent();

            design1.ActiveViewport.Rotate.Enabled = false;
            design2.ActiveViewport.Rotate.Enabled = false;
            
            design1.ActiveViewport.ViewCubeIcon.Visible = false;
            design2.ActiveViewport.ViewCubeIcon.Visible = false;
                        
            #region Camera Sync

            design1.AnimateCamera = false;
            design2.AnimateCamera = false;

            design1.CameraChangedFrequency = 200;
            design2.CameraChangedFrequency = 200;

            design1.CameraChanged += CameraChanged;
            design2.CameraChanged += CameraChanged;

            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {

            OpenFile(design1, beforePathLabel, "../../../../../../dataset/Assets/Misc/app8.dwg");
            OpenFile(design2, afterPathLabel, "../../../../../../dataset/Assets/Misc/app8mod.dwg");

            CompareAndMark(design1.Entities, design2.Entities);

            base.OnLoad(e);
        }

        private void beforeButton_Click(object sender, EventArgs e)
        {
            ColorCompareAndMark(design1, beforePathLabel, design2);
        }
        private void afterButton_Click(object sender, EventArgs e)
        {
            ColorCompareAndMark(design2, afterPathLabel, design1);
        }

        private void ColorCompareAndMark(Design designForFile, Label pathLabel, Design designToColor)
        {
            OpenFile(designForFile, pathLabel);

            //The action therefore are same for both models, so we do not need parameters anymore.
            if (design1.Entities.Count > 0 && 
                design2.Entities.Count > 0)
            {
                CompareAndMark(design1.Entities, design2.Entities);

                design1.ZoomFit();
                design2.ZoomFit();

                design1.Invalidate();
                design2.Invalidate();
            }
        }

        public bool AreEqual(Entity ent1, Entity ent2)
        {
            if (ent1 is CompositeCurve)
            {
                CompositeCurve cc1 = (CompositeCurve)ent1;
                CompositeCurve cc2 = (CompositeCurve)ent2;

                if (cc1.CurveList.Count == cc2.CurveList.Count)
                {
                    int equalCurvesInListCount = 0;
                    foreach (Entity entC in cc1.CurveList)
                    {
                        foreach (Entity entC2 in cc2.CurveList)
                        {
                            if (entC.GetType() == entC2.GetType())
                            {
                                if (CompareIfEqual(entC, entC2))
                                {
                                    equalCurvesInListCount++;
                                    break;
                                }
                            }
                        }
                    }

                    if (cc1.CurveList.Count == equalCurvesInListCount)
                    {
                        return true;
                    }
                }
            }

            else if (ent1 is LinearPath)
            {
                LinearPath lp1 = (LinearPath)ent1;
                LinearPath lp2 = (LinearPath)ent2;

                if (lp1.Vertices.Length == lp2.Vertices.Length)
                {
                    for (int i = 0; i < lp1.Vertices.Length; i++)
                    {
                        if (!(lp1.Vertices[i] == lp2.Vertices[i]))
                            return false;
                    }
                    return true;
                }
            }

            else if (ent1 is PlanarEntity)
            {
                PlanarEntity pe1 = (PlanarEntity)ent1;
                PlanarEntity pe2 = (PlanarEntity)ent2;
                if (
                    pe1.Plane.AxisZ == pe2.Plane.AxisZ &&
                    pe1.Plane.AxisX == pe2.Plane.AxisX
                    )
                {
                    if (ent1 is Arc)
                    {
                        Arc arc1 = (Arc)ent1;
                        Arc arc2 = (Arc)ent2;

                        if (
                            arc1.Center == arc2.Center &&
                            arc1.Radius == arc2.Radius &&
                            arc1.Domain.Min == arc2.Domain.Min &&
                            arc1.Domain.Max == arc2.Domain.Max
                            )
                        {
                            return true;
                        }
                    }
                    else if (ent1 is Circle)
                    {
                        Circle c1 = (Circle)ent1;
                        Circle c2 = (Circle)ent2;

                        if (
                            c1.Center == c2.Center &&
                            c1.Radius == c2.Radius
                            )
                        {
                            return true;
                        }
                    }
                    else if (ent1 is EllipticalArc)
                    {
                        EllipticalArc e1 = (EllipticalArc)ent1;
                        EllipticalArc e2 = (EllipticalArc)ent2;

                        if (
                            e1.Center == e2.Center &&
                            e1.RadiusX == e2.RadiusX &&
                            e1.RadiusY == e2.RadiusY &&
                            e1.Domain.Low == e2.Domain.Low &&
                            e1.Domain.High == e2.Domain.High
                        )
                        {
                            return true;
                        }
                    }
                    else if (ent1 is Ellipse)
                    {
                        Ellipse e1 = (Ellipse)ent1;
                        Ellipse e2 = (Ellipse)ent2;

                        if (
                            e1.Center == e2.Center &&
                            e1.RadiusX == e2.RadiusX &&
                            e1.RadiusY == e2.RadiusY
                        )
                        {
                            return true;
                        }
                    }

                    else if (ent1 is Text)
                    {
                        if (ent1 is Dimension)
                        {
                            Dimension dim1 = (Dimension)ent1;
                            Dimension dim2 = (Dimension)ent2;

                            if (
                                dim1.InsertionPoint == dim2.InsertionPoint &&
                                dim1.DimLinePosition == dim2.DimLinePosition
                                )
                            {

                                if (ent1 is AngularDim)
                                {
                                    AngularDim ad1 = (AngularDim)ent1;
                                    AngularDim ad2 = (AngularDim)ent2;

                                    if (
                                        ad1.ExtLine1 == ad2.ExtLine1 &&
                                        ad1.ExtLine2 == ad2.ExtLine2 &&
                                        ad1.StartAngle == ad2.StartAngle &&
                                        ad1.EndAngle == ad2.EndAngle &&
                                        ad1.Radius == ad2.Radius
                                        )
                                    {
                                        return true;
                                    }
                                }
                                else if (ent1 is LinearDim)
                                {
                                    LinearDim ld1 = (LinearDim)ent1;
                                    LinearDim ld2 = (LinearDim)ent2;

                                    if (
                                        ld1.ExtLine1 == ld2.ExtLine1 &&
                                        ld1.ExtLine2 == ld2.ExtLine2
                                        )
                                    {
                                        return true;
                                    }
                                }
                                else if (ent1 is DiametricDim)
                                {
                                    DiametricDim dd1 = (DiametricDim)ent1;
                                    DiametricDim dd2 = (DiametricDim)ent2;

                                    if (
                                        dd1.Distance == dd2.Distance &&
                                        dd1.Radius == dd2.Radius &&
                                        dd1.CenterMarkSize == dd2.CenterMarkSize
                                    )
                                    {
                                        return true;
                                    }
                                }
                                else if (ent1 is RadialDim)
                                {
                                    RadialDim rd1 = (RadialDim)ent1;
                                    RadialDim rd2 = (RadialDim)ent2;

                                    if (
                                        rd1.Radius == rd2.Radius &&
                                        rd1.CenterMarkSize == rd2.CenterMarkSize
                                    )
                                    {
                                        return true;
                                    }
                                }
                                else if (ent1 is OrdinateDim)
                                {
                                    OrdinateDim od1 = (OrdinateDim)ent1;
                                    OrdinateDim od2 = (OrdinateDim)ent2;

                                    if (
                                        od1.DefiningPoint == od2.DefiningPoint &&
                                        od1.Origin == od2.Origin &&
                                        od1.LeaderEndPoint == od2.LeaderEndPoint
                                    )
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    Console.Write("Type " + ent1.GetType() + " not implemented.");
                                    return true;
                                }
                            }
                        }

                        else if (ent1 is devDept.Eyeshot.Entities.Attribute)
                        {
                            devDept.Eyeshot.Entities.Attribute att1 = (devDept.Eyeshot.Entities.Attribute)ent1;
                            devDept.Eyeshot.Entities.Attribute att2 = (devDept.Eyeshot.Entities.Attribute)ent2;

                            if (
                                att1.Value == att2.Value &&
                                att1.InsertionPoint == att2.InsertionPoint
                                )
                            {
                                return true;
                            }
                        }

                        else
                        {
                            Text tx1 = (Text)ent1;
                            Text tx2 = (Text)ent2;

                            if (
                                tx1.InsertionPoint == tx2.InsertionPoint &&
                                tx1.TextString == tx2.TextString &&
                                tx1.StyleName == tx2.StyleName &&
                                tx1.WidthFactor == tx2.WidthFactor &&
                                tx1.Height == tx2.Height
                                )
                            {
                                return true;
                            }
                        }
                    }

                    else
                    {
                        Console.Write("Type " + ent1.GetType() + " not implemented.");
                        return true;
                    }
                }
            }

            else if (ent1 is Line)
            {
                Line line1 = (Line)ent1;
                Line line2 = (Line)ent2;

                if (
                    line1.StartPoint == line2.StartPoint &&
                    line1.EndPoint == line2.EndPoint
                )
                {
                    return true;
                }
            }

            else if (ent1 is devDept.Eyeshot.Entities.Point)
            {
                devDept.Eyeshot.Entities.Point point1 = (devDept.Eyeshot.Entities.Point)ent1;
                devDept.Eyeshot.Entities.Point point2 = (devDept.Eyeshot.Entities.Point)ent2;

                if (
                    point1.Position == point2.Position
                )
                {
                    return true;
                }
            }
            else if (ProductEdition != licenseType.Pro && ent1 is Curve)
            {
                Curve cu1 = (Curve)ent1;
                Curve cu2 = (Curve)ent2;

                if (
                    cu1.ControlPoints.Length == cu2.ControlPoints.Length &&
                    cu1.KnotVector.Length == cu2.KnotVector.Length &&
                    cu1.Degree == cu2.Degree
                    )
                {
                    for (int k = 0; k < cu1.ControlPoints.Length; k++)
                    {
                        if (cu1.ControlPoints[k] != cu2.ControlPoints[k])
                        {
                            return false;
                        }
                    }

                    for (int k = 0; k < cu1.KnotVector.Length; k++)
                    {
                        if (cu1.KnotVector[k] != cu2.KnotVector[k])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            else
            {
                Console.Write("Type " + ent1.GetType() + " not implemented.");
                return true;
            }
            return false;
        }
        public bool AreEqualAttributes(Entity ent1, Entity ent2)
        {
            return
                ent1.LayerName == ent2.LayerName &&
                ent1.GroupIndex == ent2.GroupIndex &&
                ent1.ColorMethod == ent2.ColorMethod &&
                ent1.Color == ent2.Color &&
                ent1.LineWeightMethod == ent2.LineWeightMethod &&
                ent1.LineWeight == ent2.LineWeight &&
                ent1.LineTypeMethod == ent2.LineTypeMethod &&
                ent1.LineTypeName == ent2.LineTypeName &&
                ent1.LineTypeScale == ent2.LineTypeScale &&
                ent1.MaterialName == ent2.MaterialName;
        }
        public void ColorEntities(EntityList list)
        {
            foreach (Entity ent in list)
            {
                ent.Color = NOT_MODIFIED_COLOR;
                ent.ColorMethod = colorMethodType.byEntity;
            }
        }
        public void CompareAndMark(IList<Entity> entList1, IList<Entity> entList2)
        {
            bool[] equalEntitiesInV2 = new bool[entList2.Count];

            for (int i = 0; i < entList1.Count(); i++)
            {
                Entity entVp1 = entList1[i];
                bool foundEqual = false;

                for (int j = 0; j < entList2.Count(); j++)
                {
                    Entity entVp2 = entList2[j];

                    if (!equalEntitiesInV2[j] &&
                        entVp1.GetType() == entVp2.GetType() &&
                        CompareIfEqual(entVp1, entVp2))
                    {
                        equalEntitiesInV2[j] = true;
                        foundEqual = true;
                        break;
                    }
                }
                if (!foundEqual)
                {
                    entList1[i].Color = Color.Yellow;
                    entList1[i].ColorMethod = colorMethodType.byEntity;
                }
            }

            for (int j = 0; j < entList2.Count; j++)
            {
                if (!equalEntitiesInV2[j])
                {
                    entList2[j].Color = Color.Yellow;
                    entList2[j].ColorMethod = colorMethodType.byEntity;
                }
            }
        }
        public bool CompareIfEqual(Entity entVp1, Entity entVp2)
        {
            bool areEqualAttributes = AreEqualAttributes(entVp1, entVp2);
            bool areEqual = AreEqual(entVp1, entVp2);

            return areEqualAttributes && areEqual;
        }
        public void OpenFile(Design design, Label labelPath, string fileName = null)
        {
            if (fileName == null)
            {
                bool foo;
                ImportExportHelper.ShowImportDialog(importFormats.Autodesk, out fileName, out foo, out foo, out foo);
            }

            if (fileName != null)
            {
                ReadFileAsync rfa = GetReader(fileName);
                beforeButton.Enabled = afterButton.Enabled = false;
                labelPath.Text = "Loading...";
                labelPath.Refresh();

                rfa.DoWork();

                design.Clear();

                rfa.AddTo(design);

                Entity[] toAdd = design.Entities.Explode();

                design.Entities.AddRange(toAdd, NOT_MODIFIED_COLOR);

                ColorEntities(design == design1 ? design2.Entities : design1.Entities);

                beforeButton.Enabled = afterButton.Enabled = true;

                labelPath.Text = rfa.FileName;

                // Sets the view as Top
                design.SetView(viewType.Top); 

                // Fits the model in the viewport
                design.ZoomFit();

                // Refresh the viewport
                design.Invalidate();
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
                        ReadDWG rd = new ReadDWG(fileName);
                        return rd;
                    case "dxf":
                        ReadDXF rdx = new ReadDXF(fileName);
                        return rdx;

                }
            }

            return ImportExportHelper.GetImportReader(fileName);
        }

        #region Camera Sync

        private void CameraChanged(object sender, devDept.Eyeshot.Control.CameraMoveEventArgs e)
        {
            if (sender == design1)
                SyncCamera(design1, design2);
            else
                SyncCamera(design2, design1);
        }

        private void SyncCamera(Design designMovedCamera, Design designCameraToMove)
        {
            Camera savedCamera;
            designMovedCamera.SaveView(out savedCamera);

            // restores the camera to the other model
            designCameraToMove.RestoreView(savedCamera);
            designCameraToMove.AdjustNearAndFarPlanes();
            designCameraToMove.Invalidate();
        }
        #endregion
    }
}