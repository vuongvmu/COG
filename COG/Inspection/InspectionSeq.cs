using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Inspection;

using static COG.Class.InspectionResult;
namespace COG
{
    public partial class Main
    {
        public static bool CGMSInspection(int CamNo, int StageNo, int Row, int Col)
        {
            try
            {
                bool bRes = true;

                CogGraphicInteractiveCollection ResultGraphy = new CogGraphicInteractiveCollection();
                PointF LeftOriginData, RightOriginData, LeftTranslationData, RightTranslationData;

                CogImage8Grey Cogimage = Main.AlignUnit[0].PAT[Row, Col].m_CogLineScanBuf;
                CogImage8Grey FixtureImage = new CogImage8Grey();
                //Step1 Mark Search
                if (!MarkSearch(Cogimage, out LeftTranslationData, out RightTranslationData, out LeftOriginData, out RightOriginData, ref ResultGraphy))
                {
                    bRes = false;
                    CogGraphicLabel label = new CogGraphicLabel();
                    label.Text = "Mark NG";
                    label.Color = CogColorConstants.Red;
                    label.X = 1500;
                    label.Y = 5500;
                    ResultGraphy.Add(label);
                    if (Row == 1)
                    {
                        FormMain.Instance().CGMSViewerControl.UpdateResultimage(Col + 5, Cogimage, ResultGraphy);
                        FormMain.Instance().Set_History(Col + 5, Convert.ToInt32(bRes), 0, 0, 0);
                    }
                    else
                    {
                        FormMain.Instance().CGMSViewerControl.UpdateResultimage(Col, Cogimage, ResultGraphy);
                        FormMain.Instance().Set_History(Col, Convert.ToInt32(bRes), 0, 0, 0);
                    }
                    return false;
                }

                // Step2 Theta Calculation
                double RotT = 0;
                CalculateRotion(LeftOriginData, RightOriginData, LeftTranslationData, RightTranslationData, out RotT);

                // Step3 Image Point Translation
                ExcuteFixture(Cogimage, LeftTranslationData, RotT, out FixtureImage);

                Main.AlignUnit[0].PAT[Row, Col].m_CogFixtureImage = FixtureImage;

                //Step4 Caliper Measure  
                double[] dDistance = new double[1];
                if (Main.machine.UseMeasureLine == true)
                {

                    if (!MeasureCaliper(CamNo, StageNo, FixtureImage, ref ResultGraphy, out dDistance))
                    {
                        bRes = false;
                    }
                }

                // Step5 Circle Search
                if (Main.machine.UseMeasureCircle == true)
                {
                    PointF[] Center;
                    double[] Radius;
                    if (!MeasureFindCicle(CamNo, StageNo, FixtureImage, out Center, out Radius, ref ResultGraphy))
                    {
                        bRes = false;
                    }
                }
                int[] BlobCnt = new int[1];
                // Step6 Blob Seach
                if (Main.machine.UseBlob == true)
                {

                    if (!BlobSearch(CamNo, StageNo, FixtureImage, out BlobCnt, ref ResultGraphy))
                    {
                        bRes = false;
                    }
                }
                else
                {
                    BlobCnt[0] = 0;
                }
                // Step7 Bead Seachr
                if (Main.machine.UseBead)
                {
                    int DefectCnt = 0;
                    if (!BeadSearch(CamNo, StageNo, FixtureImage, out DefectCnt, ref ResultGraphy))
                    {
                        bRes = false;
                    }
                }

                if (Row == 1)
                {
                    FormMain.Instance().CGMSViewerControl.UpdateResultimage(Col + 5, FixtureImage, ResultGraphy);
                    FormMain.Instance().Set_History(Col + 5, Convert.ToInt32(bRes), BlobCnt[0], dDistance[0], 0);
                }
                else
                {
                    FormMain.Instance().CGMSViewerControl.UpdateResultimage(Col, FixtureImage, ResultGraphy);
                    FormMain.Instance().Set_History(Col, Convert.ToInt32(bRes), BlobCnt[0], dDistance[0], 0);
                }




                return bRes;
            }
            catch
            {
                return false;
            }
        }
        private static bool BeadSearch(int nCamNo, int nStageNo, CogImage8Grey objImage, out int ShortCnt, ref CogGraphicInteractiveCollection ResultGraphy)
        {
            bool bRes = true;
            ShortCnt = 0;
            try
            {
                for (int iCnt = 0; iCnt <= Main.AlignUnit[nCamNo].InspectionCnt[nStageNo].BeadToolCount; iCnt++)
                {
                    if (Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Pattern.Trained == false)
                        return false;
                    Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.InputImage = objImage;
                    Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Run();
                    if (Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result != null)
                    {
                        bRes = false;
                        ResultGraphy.Add(Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Contour);
                        switch (iCnt)
                        {
                            case 0:
                                Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Contour.Color = CogColorConstants.Green;
                                break;
                            case 1:
                                Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Contour.Color = CogColorConstants.Orange;
                                break;
                            case 2:
                                Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Contour.Color = CogColorConstants.Purple;
                                break;

                            default:
                                break;
                        }
                        for (int DefectCnt = 0; DefectCnt < Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Defects.Count(); DefectCnt++)
                        {
                            CogRectangleAffine cogRectNG;
                            cogRectNG = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].ShortParamList[iCnt].CogBeadTool.Result.Defects[DefectCnt].Bounds;
                            cogRectNG.Color = CogColorConstants.Red;
                            ResultGraphy.Add(cogRectNG);
                            ShortCnt++;
                        }
                    }

                }
            }
            catch
            {
                bRes = false;
            }
            return bRes;
        }
        private static bool BlobSearch(int nCamNo, int nStageNo, CogImage8Grey objimage, out int[] BlobCnt, ref CogGraphicInteractiveCollection ResultGraphy)
        {
            bool bRes = true;
            try
            {
                BlobCnt = new int[Main.AlignUnit[nCamNo].InspectionCnt[nStageNo].BlobCount];
                for (int nCnt = 0; nCnt < Main.AlignUnit[nCamNo].InspectionCnt[nStageNo].BlobCount; nCnt++)
                {
                    CogBlobResultCollection BlobResult = new CogBlobResultCollection();
                    CogBlobTool InspBlobTool = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].BlobParams[nCnt].CogBlobTool;
                    double dWidthMax = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].BlobParams[nCnt].WidthMax;
                    double dWidthMin = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].BlobParams[nCnt].WidthMin;
                    double dHeightMax = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].BlobParams[nCnt].HeightMax;
                    double dheightMin = Main.AlignUnit[nCamNo].InspectionParams[nStageNo].BlobParams[nCnt].HeightMin;
                    if (Main.ExcuteBlob(InspBlobTool, objimage, out BlobResult))
                    {
                        BlobCnt[nCnt] = 0;
                        string strLog = string.Format("Area: {0:D}, Result: OK", nCnt);
                        FormMain.Instance().SystemLogViewerControl.AddLog(strLog);
                    }
                    else
                    {
                        Blob_Judgement(BlobResult, dWidthMin, dWidthMax, dheightMin, dHeightMax, out BlobCnt[nCnt], ref ResultGraphy);
                    }
                }
                return bRes;
            }
            catch
            {
                BlobCnt = null;
                return false;
            }
        }
        private static bool Blob_Judgement(CogBlobResultCollection ResultBlob, double WidthMin, double WidthMax, double HeightMin, double HeightMax, out int BlobCnt, ref CogGraphicInteractiveCollection ResultGraphy)
        {
            bool bRes = true;
            BlobCnt = 0;
            try
            {
                foreach (CogBlobResult cogBlobResult in ResultBlob)
                {
                    double dWidth = cogBlobResult.GetMeasure(CogBlobMeasureConstants.BoundingBoxPrincipalAxisWidth);
                    double dheight = cogBlobResult.GetMeasure(CogBlobMeasureConstants.BoundingBoxPrincipalAxisHeight);
                    dWidth = dWidth * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);
                    dheight = dheight * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);
                    if ((dWidth > WidthMin && dWidth < WidthMax) && (dheight > HeightMin && dheight > HeightMax))
                    {
                    }
                    else
                    {
                        ResultGraphy.Add(cogBlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary));
                        CogGraphicLabel Label = new CogGraphicLabel();
                        Label.Color = CogColorConstants.Red;
                        Label.Text = string.Format("Width: {0:F3}mm, Height: {1:F3}mm", dWidth, dheight);
                        Label.X = cogBlobResult.CenterOfMassX;
                        Label.Y = cogBlobResult.CenterOfMassY;
                        ResultGraphy.Add(Label);
                        bRes = false;
                        BlobCnt++;
                    }
                }
                return bRes;
            }
            catch
            {
                return false;
            }
        }
        private static bool MeasureFindCicle(int CaMNo, int StageNo, CogImage8Grey objimage, out PointF[] Cneter, out double[] Radius, ref CogGraphicInteractiveCollection ResultGraphy)
        {
            bool bRes = true;
            try
            {
                Cneter = new PointF[Main.AlignUnit[CaMNo].InspectionCnt[StageNo].CircleCount];
                Radius = new double[Main.AlignUnit[CaMNo].InspectionCnt[StageNo].CircleCount];
                PointF ResultCenter = new PointF();
                double dRadius = 0;
                for (int Cnt = 0; Cnt < Main.AlignUnit[CaMNo].InspectionCnt[StageNo].CircleCount; Cnt++)
                {
                    CogFindCircleTool InspCircleTool = Main.AlignUnit[CaMNo].InspectionParams[StageNo].MeasureCircleParamList[Cnt].CogFindCircleTool;
                    if (!Main.ExcuteFindCircle(InspCircleTool, objimage, out ResultCenter, out dRadius, ref ResultGraphy))
                    {
                        bRes = false;
                        Cneter[Cnt].X = 0;
                        Cneter[Cnt].Y = 0;
                        Radius[Cnt] = 0;
                        FormMain.Instance().SystemLogViewerControl.AddLog("Circle Search Fail");
                    }
                    else
                    {
                        Cneter[Cnt] = ResultCenter;
                        Radius[Cnt] = dRadius;
                        string strLog = string.Format("Area :{0:D} Center X: {1:F3}, CenterY: {2:F3}, Radius: {3:F3}", Cnt, ResultCenter.X, ResultCenter.Y, dRadius);
                        FormMain.Instance().SystemLogViewerControl.AddLog(strLog);
                        FormMain.Instance().SystemLogViewerControl.AddLog("Circle Search Complete");
                    }
                }
                return bRes;
            }
            catch
            {
                Radius = null;
                Cneter = null;
                return false;
            }
        }
        private static bool MeasureCaliper(int CamNo, int nStageNo, CogImage8Grey objImage, ref CogGraphicInteractiveCollection ResultGraphy, out double[] ResultDistance)
        {
            bool bRes = true;
            try
            {

                PointF[] EdgePoint1 = new PointF[Main.AlignUnit[CamNo].InspectionCnt[nStageNo].CaliperCount];
                PointF[] EdgePoint2 = new PointF[Main.AlignUnit[CamNo].InspectionCnt[nStageNo].CaliperCount];
                double[] dDistance;
                for (int MeasureCnt = 0; MeasureCnt < Main.AlignUnit[CamNo].InspectionCnt[nStageNo].CaliperCount; MeasureCnt++)
                {
                    EdgePoint1[MeasureCnt] = new PointF();
                    EdgePoint2[MeasureCnt] = new PointF();

                    for (int nPair = 0; nPair < 2; nPair++)
                    {
                        PointF ResultData = new PointF();
                        CogCaliperTool CaliperTool = Main.AlignUnit[CamNo].InspectionParams[nStageNo].MeasureLineParamList[MeasureCnt].CogCaliperTool[nPair];
                        if (!ExcuteCaliper(CaliperTool, objImage, out ResultData, ref ResultGraphy))
                        {
                            bRes = false;
                            string strLog = string.Format("Caliper Search Fail : Measure Area : {0:D}, Edge No {1:D}", MeasureCnt, nPair);
                            FormMain.Instance().SystemLogViewerControl.AddLog(strLog);
                            if (nPair == 0)
                            {
                                EdgePoint1[MeasureCnt].X = 0;
                                EdgePoint1[MeasureCnt].Y = 0;
                            }
                            else
                            {
                                EdgePoint2[MeasureCnt].X = 0;
                                EdgePoint2[MeasureCnt].Y = 0;
                            }
                        }
                        else
                        {
                            if (nPair == 0)
                            {
                                EdgePoint1[MeasureCnt] = ResultData;
                            }
                            else
                            {
                                EdgePoint2[MeasureCnt] = ResultData;
                            }
                        }
                    }
                }
                Line_Calculate_Distace(EdgePoint1, EdgePoint2, out dDistance);
                ResultDistance = dDistance;
                return bRes;
            }
            catch
            {
                ResultDistance = null;
                return false;
            }
        }
        private static void Line_Calculate_Distace(PointF[] Edge1Data, PointF[] Edge2Data, out double[] dDistanceData)
        {
            dDistanceData = new double[Edge1Data.Length];
            for (int nCnt = 0; nCnt < Edge1Data.Length; nCnt++)
            {
                dDistanceData[nCnt] = new double();
                if ((Edge1Data[nCnt].X == 0 || Edge1Data[nCnt].Y == 0) || Edge2Data[nCnt].X == 0 || Edge2Data[nCnt].Y == 0)
                {
                    dDistanceData[nCnt] = 0;
                }
                else
                {
                    double dx = (double)(Edge1Data[nCnt].X - Edge2Data[nCnt].X);
                    double dy = (double)(Edge1Data[nCnt].Y - Edge2Data[nCnt].Y);
                    double Dist = Math.Abs(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
                    dDistanceData[nCnt] = Dist * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);
                    string strLog = string.Format("Area: {0:D}, Distance: {1:F3}", nCnt, dDistanceData[nCnt]);
                    FormMain.Instance().SystemLogViewerControl.AddLog(strLog);
                }
            }
        }
        public static bool MarkSearch(CogImage8Grey objImage, out PointF LeftPoint, out PointF RightPoint, out PointF LeftOring, out PointF RightOrigin, ref CogGraphicInteractiveCollection ResultGraphy)
        {
            try
            {
                bool bRes = true;
                LeftOring = new PointF();
                RightOrigin = new PointF();
                LeftPoint = new PointF();
                RightPoint = new PointF();
                double dScore;
                double dResultScore, dResultAngle;
                //BACK LIGHT
                CogPMAlignTool InspLeftPMAlignTool = Main.AlignUnit[0].PAT[0, 0].AkkonPara.LeftPattern[0];
                double dLScore = Main.AlignUnit[0].PAT[0, 0].AkkonPara.ATTMarkScore;
                CogPMAlignTool InspRightPMAlignTool = Main.AlignUnit[0].PAT[0, 0].AkkonPara.RightPattern[0];
                // SPOT 
                if (Main.machine.UseBlob == true)
                {
                    InspLeftPMAlignTool = Main.AlignUnit[0].PAT[0, 0].AlignPara.LeftPattern[0];
                    dLScore = Main.AlignUnit[0].PAT[0, 0].AkkonPara.ATTMarkScore;
                    InspRightPMAlignTool = Main.AlignUnit[0].PAT[0, 0].AlignPara.RightPattern[0];
                    //Step1 Get Origin Data 
                    Get_OriginData(InspLeftPMAlignTool, InspRightPMAlignTool, out LeftOring, out RightOrigin);
                }

                FormMain.Instance().SystemLogViewerControl.AddLog("Mark Search Start");
                string Log = "";
                // Step2 Pattern Search
                if (!Main.ExcutePMAlign(InspLeftPMAlignTool, objImage, dLScore, out LeftPoint, out dResultScore, out dResultAngle, ref ResultGraphy))
                {
                    FormMain.Instance().SystemLogViewerControl.AddLog("Left Mark Search Fail");
                    bRes = false;
                }
                else
                {
                    Log = string.Format("Left Mark X: {0:F3}, Y: {1:F3}, Score: {2:F3}, Angle: {3:F3}", LeftPoint.X, LeftPoint.Y, dResultScore, dResultAngle);
                    FormMain.Instance().SystemLogViewerControl.AddLog(Log);
                }
                if (!Main.ExcutePMAlign(InspRightPMAlignTool, objImage, dLScore, out RightPoint, out dResultScore, out dResultAngle, ref ResultGraphy))
                {
                    FormMain.Instance().SystemLogViewerControl.AddLog("Right Mark Search Fail");
                    bRes = false;
                }
                else
                {
                    Log = string.Format("Right Mark X: {0:F3}, Y: {1:F3}, Score: {2:F3}, Angle: {3:F3}", RightPoint.X, RightPoint.Y, dResultScore, dResultAngle);
                    FormMain.Instance().SystemLogViewerControl.AddLog(Log);
                }
                return bRes;
            }
            catch
            {
                LeftOring = new PointF();
                RightOrigin = new PointF();
                LeftPoint = new PointF();
                RightPoint = new PointF();
                return false;
            }
        }
        private static void Get_OriginData(CogPMAlignTool objLeftCogPMAlignTool, CogPMAlignTool RightPMAlignTool, out PointF LeftOrigin, out PointF RightOrigin)
        {
            LeftOrigin = new PointF();
            RightOrigin = new PointF();
            LeftOrigin.X = (float)objLeftCogPMAlignTool.Pattern.Origin.TranslationX;
            LeftOrigin.Y = (float)objLeftCogPMAlignTool.Pattern.Origin.TranslationY;
            RightOrigin.X = (float)RightPMAlignTool.Pattern.Origin.TranslationX;
            RightOrigin.Y = (float)RightPMAlignTool.Pattern.Origin.TranslationY;
        }
    }
}
