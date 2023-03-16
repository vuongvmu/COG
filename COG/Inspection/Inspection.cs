using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Dimensioning;

namespace COG
{
    public partial class Main
    {
        public static bool ExcuteCaliper(CogCaliperTool objCogCaliperTool, CogImage8Grey objCogimage, out PointF ResultData, ref CogGraphicInteractiveCollection ResultGrapht )
        {
            try
            {
                bool bRes = false;
                ResultData = new PointF();
                objCogCaliperTool.InputImage = objCogimage;
                objCogCaliperTool.Run();
                if (objCogCaliperTool.Results != null)
                {
                    ResultData.X = (float)objCogCaliperTool.Results[0].Edge0.PositionX;
                    ResultData.Y = (float)objCogCaliperTool.Results[0].Edge0.PositionY;
                    ResultGrapht.Add(objCogCaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    bRes = true;
                }
                return bRes;
            }
            catch
            {
                ResultData = new PointF();
                return false;
            }
        }
        public static bool ExcutePMAlign(CogPMAlignTool objPMAlignTool, CogImage8Grey objCogImage, double dScore, out PointF ResultData, out double dResultScore, out double dResultAngle  ,ref CogGraphicInteractiveCollection ResultGrapht)
        {
            bool bRes = false;
            try
            {
                ResultData = new PointF();
                dResultScore = 0;
                dResultAngle = 0;
                objPMAlignTool.InputImage = objCogImage;
                objPMAlignTool.Run();
                if(objPMAlignTool.Results.Count >0)
                {
                    if(objPMAlignTool.Results[0].Score >= dScore)
                    {
                        ResultData.X = (float)objPMAlignTool.Results[0].GetPose().TranslationX;
                        ResultData.Y = (float)objPMAlignTool.Results[0].GetPose().TranslationY;
                        dResultAngle = (float)objPMAlignTool.Results[0].GetPose().Rotation;
                        dResultScore = (float)objPMAlignTool.Results[0].Score;
                        bRes = true;
                        ResultGrapht.Add(objPMAlignTool.Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox | CogPMAlignResultGraphicConstants.Origin));
                    }
                    else
                    {
                        bRes = false;
                    }
                }
                else
                {
                    bRes = false;
                }

                return bRes;
             }
            catch
            {
                dResultAngle = 0;
                dResultScore = 0;
                ResultData = new PointF();
                return false;
            }
        }
        public static bool ExcuteFixture(CogImage8Grey objImage, PointF Translation, double Rotaion, out CogImage8Grey outImage)
        {
            bool bRes = true;
            try
            {
                CogTransform2DLinear TransData = new CogTransform2DLinear();
                TransData.TranslationX = (double)Translation.X;
                TransData.TranslationY = (double)Translation.Y;
                TransData.Rotation = Rotaion;

                CogFixtureTool _CogFixTureTool = new CogFixtureTool();
                _CogFixTureTool.InputImage = objImage;
                _CogFixTureTool.RunParams.UnfixturedFromFixturedTransform = TransData;
                _CogFixTureTool.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
              
                _CogFixTureTool.Run();

                outImage = (CogImage8Grey)_CogFixTureTool.OutputImage;
                FormMain.Instance().SystemLogViewerControl.AddLog("Complete Fixture Tool");

                return bRes;
            }
            catch
            {
                FormMain.Instance().SystemLogViewerControl.AddLog("Fail Fixture Tool");
                outImage = null;
                return false;
            }
        }
        public static bool ExcuteBlob(CogBlobTool objBlobTool, CogImage8Grey objImage, out CogBlobResultCollection ResultBlob)
        {
           
            bool bRes = false;
            try
            {
                ResultBlob = new CogBlobResultCollection();
                objBlobTool.InputImage = objImage;
                objBlobTool.Run();

                if(objBlobTool.Results != null)
                {
                    ResultBlob = objBlobTool.Results.GetBlobs();
                    bRes = true;
                }

                return bRes;
            }
            catch
            {
                ResultBlob = new CogBlobResultCollection();
                return false;
            }

        }
        public static bool ExcuteFindCircle(CogFindCircleTool objCogFindCircle, CogImage8Grey objImage, out PointF Center, out double Radius, ref CogGraphicInteractiveCollection ResultGrapht)
        {
            try
            {
                bool bRes = true;
                Center = new PointF();
                Radius = 0;
                objCogFindCircle.InputImage = objImage;
                objCogFindCircle.Run();
                if (objCogFindCircle.Results.GetCircle() != null)
                {
                    Center.X = (float) objCogFindCircle.Results.GetCircle().CenterX;
                    Center.Y = (float) objCogFindCircle.Results.GetCircle().CenterY;
                    Radius = objCogFindCircle.Results.GetCircle().Radius;
                    ResultGrapht.Add(objCogFindCircle.Results.GetCircle());
                 
                }
                return bRes;
            }
            catch
            {
                Center = new PointF();
                Radius = 0;
                return false;
            }
        }
        public static void CalculateRotion(PointF LeftOriginData, PointF RightOriginData, PointF LeftTransData, PointF RightTransData, out double Rotion)
        {
            double dx = (((double)RightTransData.X + (double)LeftTransData.X) / 2) -
                                (((double)RightOriginData.X + (double)LeftOriginData.X) / 2);
            double dy = (((double)RightTransData.Y + (double)LeftTransData.Y) / 2) -
                                (((double)RightOriginData.Y + (double)LeftOriginData.Y) / 2);

            double dRotDx = (double)RightTransData.X - (double)LeftTransData.X;
            double dRotDy = (double)RightTransData.Y - (double)LeftTransData.Y;

            double dRotT = OpenCvSharp.Cv2.FastAtan2((float)dRotDy, (float)dRotDx);
            if (dRotT > 180) dRotT -= 360;

            double dTeachX = (double)RightOriginData.X - (double)LeftOriginData.X;
            double dTeachY = (double)RightOriginData.Y - (double)LeftOriginData.Y;

            double dTeachT = OpenCvSharp.Cv2.FastAtan2((float)dTeachY, (float)dTeachX);
            if (dTeachT > 180.0) dTeachT -= 360.0;

            dRotT -= dTeachT;
            Rotion = dRotT;
        }
    }
}
