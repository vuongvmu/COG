using COG.Class.MOTION;
using JASUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace COG.Class
{
    public class OperationParameter
    {
        #region Camera Spec
        public double LineScanPixelSize { get; set; } = 0.0035;
        public double LensMagnification { get; set; } = 5.0;
        #endregion

        #region Vision Setting
        public double PreAlignCamToLineScanCamDistanceX { get; set; } = 0.0;
        public double PreAlignCamToLineScanCamDistanceY { get; set; } = 0.0;
        #endregion

        public eAxis LineScannerAxis { get; set; } = eAxis.Axis_Y;

        #region PreAlign Tolerance
        public double PreAlignReferenceX { get; set; } = 0.0;
        public double PreAlignReferenceY { get; set; } = 0.0;
        public double PreAlignReferenceT { get; set; } = 0.0;
        public double PreAlignToleranceX { get; set; } = 0.0;
        public double PreAlignToleranceY { get; set; } = 0.0;
        public double PreAlignToleranceT { get; set; } = 0.0;
        #endregion

        #region Device
        public string MotionIPAddress { get; set; } = "0.1.2.3";
        public int MotionPortNumber { get; set; } = 4;

        public string PLCIPAddress { get; set; } = "5.6.7.8";
        public int PLCPortNumber { get; set; } = 9;

        public string AutoFocusCOMPort { get; set; } = "COM1";
        public int AutoFocusBaudRate { get; set; } = 9600;

        public string LightCOMPort { get; set; } = "COM2";
        public int LightBaudRate { get; set; } = 9600;
        #endregion

        #region Option
        // Data Store Option
        public string ImageSavePath { get; set; } = Directory.GetCurrentDirectory();
        public int ImageSaveDurtaion { get; set; } = 90;
        public string LogSavePath { get; set; } = Directory.GetCurrentDirectory();
        public int LogSaveDuration { get; set; } = 90;
        public int DataSaveCapacity { get; set; } = 90;

        // Image Save Option
        public bool IsSaveOKImage { get; set; } = false;
        public eImageExtension SaveOKImageExtension { get; set; } = eImageExtension.Jpg;
        public bool IsSaveNGImage { get; set; } = false;
        public eImageExtension SaveNGImageExtension { get; set; } = eImageExtension.Jpg;
        #endregion

        #region Inspection Item Option
        public bool UseMark { get; set; } = false;
        public bool UseAlign { get; set; } = false;
        public bool UseAkkon { get; set; } = false;
        public bool UseMeasure { get; set; } = false;
        public bool UseParticle { get; set; } = false;
        public bool UseShort { get; set; } = false;
        #endregion

        #region AutoRun Option
        public bool IsJudgeAlign { get; set; } = true;
        public bool IsJudgeAkkon { get; set; } = true;
        public bool IsJudgeMesure { get; set; } = true;
        public bool IsJudgeParticle { get; set; } = true;
        public bool IsJudgeShort { get; set; } = true;
        #endregion

        #region ATT Option
        public bool IsDrawCenter { get; set; } = false;
        public bool IsDrawContour { get; set; } = false;
        public bool IsDrawLength { get; set; } = false;
        public bool IsRMSAkkonParameterSet { get; set; } = false;
        #endregion

        public void Save(bool isBackup = false)
        {
            string strPath = Directory.GetCurrentDirectory() + "\\Config";
            Utility.CreateDir(strPath);
            strPath += "\\System.xml";

            if (isBackup)
            {
                string backupPath = strPath + ".bak"; // 백업 주소를 만듭니다.

                if (File.Exists(backupPath))
                    File.Delete(backupPath);

                File.Move(strPath, backupPath);
            }

            XmlDocument xmlDocument = new XmlDocument();

            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement operationElement = xmlDocument.CreateElement("", "Operation", "");
            xmlDocument.AppendChild(operationElement);

            SaveParams(operationElement);

            xmlDocument.Save(strPath);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            #region Camera Spec
            XmlElement opticInforamtionElement = xmlElement.OwnerDocument.CreateElement("", "OpticInformation", "");
            xmlElement.AppendChild(opticInforamtionElement);

            XmlHelper.SetValue(opticInforamtionElement, "LineScanPixelSize", LineScanPixelSize.ToString());
            XmlHelper.SetValue(opticInforamtionElement, "LensMagnification", LensMagnification.ToString());
            #endregion

            #region Vision Setting
            XmlElement visionSettingElement = xmlElement.OwnerDocument.CreateElement("", "VisionSetting", "");
            xmlElement.AppendChild(visionSettingElement);

            XmlHelper.SetValue(visionSettingElement, "PreAlignCamToLineScanCamDistanceX", PreAlignCamToLineScanCamDistanceX.ToString());
            XmlHelper.SetValue(visionSettingElement, "PreAlignCamToLineScanCamDistanceY", PreAlignCamToLineScanCamDistanceY.ToString());
            #endregion

            #region PreAlign Tolerance
            XmlElement preAlignToleranceElement = xmlElement.OwnerDocument.CreateElement("", "PreAlignTolerance", "");
            xmlElement.AppendChild(preAlignToleranceElement);

            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignReferenceX", PreAlignReferenceX.ToString());
            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignReferenceY", PreAlignReferenceY.ToString());
            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignReferenceT", PreAlignReferenceT.ToString());

            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignToleranceX", PreAlignToleranceX.ToString());
            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignToleranceY", PreAlignToleranceY.ToString());
            XmlHelper.SetValue(preAlignToleranceElement, "PreAlignToleranceT", PreAlignToleranceT.ToString());
            #endregion

            #region Option
            XmlElement optionElement = xmlElement.OwnerDocument.CreateElement("", "Option", "");
            xmlElement.AppendChild(optionElement);

            // Data Store Option
            XmlElement dataSaveOptionElement = optionElement.OwnerDocument.CreateElement("", "DataSaveOption", "");
            optionElement.AppendChild(dataSaveOptionElement);

            XmlHelper.SetValue(dataSaveOptionElement, "ImageSavePath", ImageSavePath.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "ImageSaveDurtaion", ImageSaveDurtaion.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "LogSavePath", LogSavePath.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "LogSaveDuration", LogSaveDuration.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "DataSaveCapacity", DataSaveCapacity.ToString());

            // Image Save Option
            XmlHelper.SetValue(dataSaveOptionElement, "IsSaveOKImage", IsSaveOKImage.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "SaveOKImageExtension", SaveOKImageExtension.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "IsSaveNGImage", IsSaveNGImage.ToString());
            XmlHelper.SetValue(dataSaveOptionElement, "SaveNGImageExtension", SaveNGImageExtension.ToString());
            #endregion

            #region Inspection Item Option
            // Inspection Option
            XmlElement inspectionOptionElement = optionElement.OwnerDocument.CreateElement("", "InspectionOption", "");
            optionElement.AppendChild(inspectionOptionElement);

            XmlHelper.SetValue(inspectionOptionElement, "UseMark", UseMark.ToString());
            XmlHelper.SetValue(inspectionOptionElement, "UseAlign", UseAlign.ToString());
            XmlHelper.SetValue(inspectionOptionElement, "UseAkkon", UseAkkon.ToString());
            XmlHelper.SetValue(inspectionOptionElement, "UseMeasure", UseMeasure.ToString());
            XmlHelper.SetValue(inspectionOptionElement, "UseParticle", UseParticle.ToString());
            XmlHelper.SetValue(inspectionOptionElement, "UseShort", UseShort.ToString());
            #endregion

            #region AutoRun Option
            XmlElement autoRunOptionElement = optionElement.OwnerDocument.CreateElement("", "AutoRunOption", "");
            optionElement.AppendChild(autoRunOptionElement);

            XmlHelper.SetValue(autoRunOptionElement, "IsJudgeAlign", IsJudgeAlign.ToString());
            XmlHelper.SetValue(autoRunOptionElement, "IsJudgeAkkon", IsJudgeAkkon.ToString());
            XmlHelper.SetValue(autoRunOptionElement, "IsJudgeMesure", IsJudgeMesure.ToString());
            XmlHelper.SetValue(autoRunOptionElement, "IsJudgeParticle", IsJudgeParticle.ToString());
            XmlHelper.SetValue(autoRunOptionElement, "IsJudgeShort", IsJudgeShort.ToString());
            #endregion

            #region ATT Option
            XmlElement attOptionElement = xmlElement.OwnerDocument.CreateElement("", "ATTOption", "");
            xmlElement.AppendChild(attOptionElement);

            XmlHelper.SetValue(attOptionElement, "IsDrawCenter", IsDrawCenter.ToString());
            XmlHelper.SetValue(attOptionElement, "IsDrawContour", IsDrawContour.ToString());
            XmlHelper.SetValue(attOptionElement, "IsDrawLength", IsDrawLength.ToString());
            XmlHelper.SetValue(attOptionElement, "IsRMSAkkonParameterSet", IsRMSAkkonParameterSet.ToString());
            #endregion

            #region Device
            XmlElement deviceElement = xmlElement.OwnerDocument.CreateElement("", "Device", "");
            xmlElement.AppendChild(deviceElement);

            XmlHelper.SetValue(deviceElement, "MotionIPAddress", MotionIPAddress.ToString());
            XmlHelper.SetValue(deviceElement, "MotionPortNumber", MotionPortNumber.ToString());

            XmlHelper.SetValue(deviceElement, "PLCIPAddress", PLCIPAddress.ToString());
            XmlHelper.SetValue(deviceElement, "PLCPortNumber", PLCPortNumber.ToString());

            XmlHelper.SetValue(deviceElement, "AutoFocusCOMPort", AutoFocusCOMPort.ToString());
            XmlHelper.SetValue(deviceElement, "AutoFocusBaudRate", AutoFocusBaudRate.ToString());

            XmlHelper.SetValue(deviceElement, "LightCOMPort", LightCOMPort.ToString());
            XmlHelper.SetValue(deviceElement, "LightBaudRate", LightBaudRate.ToString());
            #endregion
        }

        public bool Load()
        {
            string path = Directory.GetCurrentDirectory() + "\\config";
            Utility.CreateDir(path);
            string fileName = path + "\\System.xml";

            if (!File.Exists(fileName))
            {
                // 필요한 객체 생성
                Save();
                return false;
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                XmlElement operationElement = xmlDocument.DocumentElement;

                LoadParams(operationElement);

                return true;
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            if (xmlElement == null)
                return;

            #region Camera Spec
            XmlElement opticInforamtionElement = xmlElement["OpticInformation"];

            LineScanPixelSize = Convert.ToDouble(XmlHelper.GetValue(opticInforamtionElement, "LineScanPixelSize", LineScanPixelSize.ToString()));
            LensMagnification = Convert.ToDouble(XmlHelper.GetValue(opticInforamtionElement, "LensMagnification", LensMagnification.ToString()));
            #endregion

            #region Vision Setting
            XmlElement visionSettingElement = xmlElement["VisionSetting"];

            PreAlignCamToLineScanCamDistanceX = Convert.ToDouble(XmlHelper.GetValue(visionSettingElement, "PreAlignCamToLineScanCamDistanceX", PreAlignCamToLineScanCamDistanceX.ToString()));
            PreAlignCamToLineScanCamDistanceY = Convert.ToDouble(XmlHelper.GetValue(visionSettingElement, "PreAlignCamToLineScanCamDistanceY", PreAlignCamToLineScanCamDistanceY.ToString()));
            #endregion

            #region PreAlign Tolerance
            XmlElement preAlignToleranceElement = xmlElement["PreAlignTolerance"];

            PreAlignReferenceX = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignReferenceX", PreAlignReferenceX.ToString()));
            PreAlignReferenceY = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignReferenceY", PreAlignReferenceY.ToString()));
            PreAlignReferenceT = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignReferenceT", PreAlignReferenceT.ToString()));

            PreAlignToleranceX = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignToleranceX", PreAlignToleranceX.ToString()));
            PreAlignToleranceY = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignToleranceY", PreAlignToleranceY.ToString()));
            PreAlignToleranceT = Convert.ToDouble(XmlHelper.GetValue(preAlignToleranceElement, "PreAlignToleranceT", PreAlignToleranceT.ToString()));
            #endregion

            #region Option
            XmlElement optionElement = xmlElement["Option"];
            XmlElement dataSaveOptionElement = optionElement["DataSaveOption"];

            // Data Store Option
            ImageSavePath = XmlHelper.GetValue(dataSaveOptionElement, "ImageSavePath", ImageSavePath);
            ImageSaveDurtaion = Convert.ToInt32(XmlHelper.GetValue(dataSaveOptionElement, "ImageSaveDurtaion", ImageSaveDurtaion.ToString()));
            LogSavePath = XmlHelper.GetValue(dataSaveOptionElement, "LogSavePath", LogSavePath);
            LogSaveDuration = Convert.ToInt32(XmlHelper.GetValue(dataSaveOptionElement, "LogSaveDuration", LogSaveDuration.ToString()));
            DataSaveCapacity = Convert.ToInt32(XmlHelper.GetValue(dataSaveOptionElement, "DataSaveCapacity", DataSaveCapacity.ToString()));

            // Image Save Option
            IsSaveOKImage = Convert.ToBoolean(XmlHelper.GetValue(dataSaveOptionElement, "IsSaveOKImage", IsSaveOKImage.ToString()));
            SaveOKImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), XmlHelper.GetValue(dataSaveOptionElement, "SaveOKImageExtension", SaveOKImageExtension.ToString()));
            IsSaveNGImage = Convert.ToBoolean(XmlHelper.GetValue(dataSaveOptionElement, "IsSaveNGImage", IsSaveNGImage.ToString()));
            SaveNGImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), XmlHelper.GetValue(dataSaveOptionElement, "SaveNGImageExtension", SaveNGImageExtension.ToString()));
            #endregion

            #region Inspection Item Option
            XmlElement inspectionOptionnElement = optionElement["InspectionOption"];

            UseMark = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseMark", UseMark.ToString()));
            UseAlign = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseAlign", UseAlign.ToString()));
            UseAkkon = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseAkkon", UseAkkon.ToString()));
            UseMeasure = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseMeasure", UseMeasure.ToString()));
            UseParticle = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseParticle", UseParticle.ToString()));
            UseShort = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "UseShort", UseShort.ToString()));
            #endregion

            #region AutoRun Option
            XmlElement autoRunOptionElement = optionElement["AutoRunOption"];

            IsJudgeAlign = Convert.ToBoolean(XmlHelper.GetValue(autoRunOptionElement, "IsJudgeAlign", IsJudgeAlign.ToString()));
            IsJudgeAkkon = Convert.ToBoolean(XmlHelper.GetValue(autoRunOptionElement, "IsJudgeAkkon", IsJudgeAkkon.ToString()));
            IsJudgeMesure = Convert.ToBoolean(XmlHelper.GetValue(autoRunOptionElement, "IsJudgeMesure", IsJudgeMesure.ToString()));
            IsJudgeParticle = Convert.ToBoolean(XmlHelper.GetValue(autoRunOptionElement, "IsJudgeParticle", IsJudgeParticle.ToString()));
            IsJudgeShort = Convert.ToBoolean(XmlHelper.GetValue(autoRunOptionElement, "IsJudgeShort", IsJudgeShort.ToString()));
            #endregion

            #region ATT Option
            XmlElement attOptionElement = xmlElement.OwnerDocument.CreateElement("", "ATTOption", "");

            IsDrawCenter = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "IsDrawCenter", IsDrawCenter.ToString()));
            IsDrawContour = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "IsDrawContour", IsDrawContour.ToString()));
            IsDrawLength = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "IsDrawLength", IsDrawLength.ToString()));
            IsRMSAkkonParameterSet = Convert.ToBoolean(XmlHelper.GetValue(inspectionOptionnElement, "IsRMSAkkonParameterSet", IsRMSAkkonParameterSet.ToString()));
            #endregion

            #region Device
            XmlElement deviceElement = xmlElement["Device"];

            MotionIPAddress = XmlHelper.GetValue(deviceElement, "MotionIPAddress", MotionIPAddress);
            MotionPortNumber = Convert.ToInt32(XmlHelper.GetValue(deviceElement, "MotionPortNumber", MotionPortNumber.ToString()));

            PLCIPAddress = XmlHelper.GetValue(deviceElement, "PLCIPAddress", PLCIPAddress);
            PLCPortNumber = Convert.ToInt32(XmlHelper.GetValue(deviceElement, "PLCPortNumber", PLCPortNumber.ToString()));

            AutoFocusCOMPort = XmlHelper.GetValue(deviceElement, "AutoFocusCOMPort", AutoFocusCOMPort);
            AutoFocusBaudRate = Convert.ToInt32(XmlHelper.GetValue(deviceElement, "AutoFocusBaudRate", AutoFocusBaudRate.ToString()));

            LightCOMPort = XmlHelper.GetValue(deviceElement, "LightCOMPort", LightCOMPort);
            LightBaudRate = Convert.ToInt32(XmlHelper.GetValue(deviceElement, "LightBaudRate", LightBaudRate.ToString()));
            #endregion
        }
    }
}
