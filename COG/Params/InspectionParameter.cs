using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.EdgeInspect;
using Cognex.VisionPro.PMAlign;
using JASUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace COG
{
    public enum eTeachingItem
    {
        LineScan,
        Mark,
#if ATT
        Align,
        Akkon,
#endif
#if CGMS
        Particle,
        Measure,
        Short,
#endif
    }

    public class InspectionItem
    {
        public enum eMarkIndex
        {
            MainMark,
            SubMark1,
            SubMark2,
            SubMark3,
            SubMark4,
        }

        public enum eMarkPosition
        {
            Left,
            Right,
        }

#if CGMS
        public enum eTargetObject
        {
            BackLight,
            Coaxial,
        }
#endif
#if ATT
        private eTargetObject _targetObject = eTargetObject.FPC;
        public enum eTargetObject
        {
            FPC,
            PANEL,
        }
#endif

        public BlobParameter BlobItem;
        public List<BlobParameter> BlobParams;

        public MeasureLineParameter MeasureLineItem;
        public List<MeasureLineParameter> MeasureLineParamList;

        public MeasureCircleParameter MeasureCircleItem;
        public List<MeasureCircleParameter> MeasureCircleParamList;

        public ShortParameter ShortItem;
        public List<ShortParameter> ShortParamList;

        public PatternMatchParameter[,] PatternItem = new PatternMatchParameter[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];
        public List<PatternMatchParameter[,]> PatternList = new List<PatternMatchParameter[,]>();

		
        public InspectionItem()
        {
            BlobParams = new List<BlobParameter>();
            MeasureLineParamList = new List<MeasureLineParameter>();
            MeasureCircleParamList = new List<MeasureCircleParameter>();
            PatternList = new List<PatternMatchParameter[,]>();
            ShortParamList = new List<ShortParameter>();
        }
       
        public void Save()
        {
          
        }

        public void Load()
        {

        }
    }

    public class InspectionCount
    {
        public int BlobCount { get; set; } = 0;

        public int CaliperCount { get; set; } = 0;

        public int BeadToolCount { get; set; } = 0;

        public int CircleCount { get; set; } = 0;

        public void SetParam (InspectionCount Params)
        {
            this.BlobCount = Params.BlobCount;
            this.CaliperCount = Params.CaliperCount;
            this.BeadToolCount = Params.BeadToolCount;
            this.CircleCount = Params.CircleCount;
        }

        public InspectionCount Copy()
        {
            InspectionCount Params = new InspectionCount();

            Params.BlobCount = this.BlobCount;
            Params.CaliperCount = this.CaliperCount;
            Params.BeadToolCount = this.BeadToolCount;
            Params.CircleCount = this.CircleCount;

            return Params;
        }

        public void SaveXml(string filePath)
        {
            string path = filePath +".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement MeasureCount = xmlDocument.CreateElement("", "Measure", "");
            xmlDocument.AppendChild(MeasureCount);

            SaveParams(MeasureCount);

            xmlDocument.Save(path);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            XmlHelper.SetValue(xmlElement, "BlobCount", BlobCount.ToString());
            XmlHelper.SetValue(xmlElement, "CaliperCount", CaliperCount.ToString());
            XmlHelper.SetValue(xmlElement, "BeadToolCount", BeadToolCount.ToString());
            XmlHelper.SetValue(xmlElement, "CircleCount", CircleCount.ToString());
        }

        private bool FileExist(string strPath)
        {
            bool bRes = true;
            bRes = File.Exists(strPath);
            return bRes;
        }

        public void LoadXml(string filePath)
        {
            if (File.Exists(filePath))
            {
               XmlDocument xmlDocument = new XmlDocument();
               xmlDocument.Load(filePath);
               XmlElement xmlElement = xmlDocument.DocumentElement;

               LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            BlobCount = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "BlobCount", BlobCount.ToString()));
            CaliperCount = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "CaliperCount", CaliperCount.ToString()));
            BeadToolCount = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "BeadToolCount", BeadToolCount.ToString()));
            CircleCount = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "CircleCount", CircleCount.ToString()));
        }

    }

    public class AlignParameter
    {
        public bool UseAlignItem { get; set; } = false;
    }

    public class AkkonParameter
    {
        public bool UseAkkonItem { get; set; } = false;
    }

    public class BlobParameter
    {
        public CogBlobTool CogBlobTool { get; set; } = new CogBlobTool();

        public int WidthMin { get; set; } = 0;
        public int WidthMax { get; set; } = 0;
        public int HeightMin { get; set; } = 0;
        public int HeightMax { get; set; } = 0;
        public int MesureCnt { get; set; } = 0;

        public void SetParam(BlobParameter param)
        {
            this.CogBlobTool = new CogBlobTool();

            this.CogBlobTool = param.CogBlobTool;
            this.WidthMax = param.WidthMax;
            this.WidthMin = param.WidthMin;
            this.HeightMin = param.HeightMin;
            this.HeightMax = param.HeightMax;
        }
       
        public BlobParameter Copy()
        {
            BlobParameter param = new BlobParameter();

            param.CogBlobTool = this.CogBlobTool;
            param.WidthMax = this.WidthMax;
            param.WidthMin = this.WidthMin;
            param.HeightMax = this.HeightMax;
            param.HeightMin = this.HeightMin;
            param.MesureCnt = this.MesureCnt;

            return param;
        }

        public void SaveVPP(string filePath,int camNo, int stageNo, int index)
        {
            if (!Directory.Exists(filePath))
                Utility.CreateDir(filePath);

            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Blob", camNo, stageNo);

            if (CogBlobTool != null)
            {
                CogBlobTool.InputImage = null;
                CogSerializer.SaveObjectToFile(CogBlobTool, filePath+ fileName + index + ".vpp",
                                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
            }
        }

        public void LoadVPP(string filePath, int index)
        {
            filePath += index.ToString() + ".vpp";

            if (File.Exists(filePath))
                CogBlobTool = CogSerializer.LoadObjectFromFile(filePath) as CogBlobTool;
            else
                CogBlobTool = new CogBlobTool();
        }


        public void SaveXml(string filePath, int camNo, int stageNo, int index)
        {
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Blob", camNo, stageNo);
            string path = filePath+ fileName + index + ".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement blobElement = xmlDocument.CreateElement("", "Blob", "");
            xmlDocument.AppendChild(blobElement);

            SaveParams(blobElement);
            xmlDocument.Save(path);
        }
        
        private void SaveParams(XmlElement xmlElement)
        {
            XmlHelper.SetValue(xmlElement, "WidthMin", WidthMin.ToString());
            XmlHelper.SetValue(xmlElement, "WidthMax", WidthMax.ToString());
            XmlHelper.SetValue(xmlElement, "HeightMin", HeightMin.ToString());
            XmlHelper.SetValue(xmlElement, "HeightMax", HeightMax.ToString());
        }

        public void LoadXml(string filePath, int index)
        {
            filePath += index.ToString() + ".xml";
            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement xmlElement = xmlDocument.DocumentElement;

                LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            WidthMin = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "WidthMin", WidthMin.ToString()));
            WidthMax = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "WidthMax", WidthMin.ToString()));
            HeightMin = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "HeightMin", WidthMin.ToString()));
            HeightMax = Convert.ToInt32(XmlHelper.GetValue(xmlElement, "HeightMax", WidthMin.ToString()));
        }




        private void ExitFile(string path)
        {
            if (!File.Exists(path))
            {
                FileStream Files = File.Create(path);
                Files.Close();
            }
        }


        private bool FileExist(string fileName)
        {
            bool bRes = true;
            bRes = File.Exists(fileName);
            return bRes;
        }
    }

    public class PatternMatchParameter
    {
        public CogPMAlignTool CogPMAlignTool { set; get; } = new CogPMAlignTool();
        public double Score { get; set; } = 0.8;
        public double Angle { get; set; } = 0.1;
      
        public void SetParam(PatternMatchParameter param)
        {
            this.CogPMAlignTool = new CogPMAlignTool();

            if (param == null)
                param = new PatternMatchParameter();

            this.CogPMAlignTool = param.CogPMAlignTool;
            this.Score = param.Score;
            this.Angle = param.Angle;
        }

        public PatternMatchParameter Copy()
        {
            PatternMatchParameter cogPattern = new PatternMatchParameter();

            cogPattern.CogPMAlignTool = this.CogPMAlignTool;
            cogPattern.Score = this.Score;
            cogPattern.Angle = this.Angle;

            return cogPattern;
        }

        public void SaveVPP(string filePath, int camNo, int stageNo, int targetIndex, int positionIndex, int markIndex)
        {
            if (!Directory.Exists(filePath))
                Utility.CreateDir(filePath);

            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Mark_", camNo, stageNo);

            if (CogPMAlignTool != null)
            {
                if (CogPMAlignTool.Pattern.Trained == true)
                {
                    CogSerializer.SaveObjectToFile(CogPMAlignTool, filePath + fileName + targetIndex.ToString() + positionIndex.ToString() + markIndex.ToString() + ".vpp",
                                   typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);

                }
            }
        }

        public void LoadVPP(string filePath, int Type, int Position, int index)
        {
            filePath += Type.ToString() + Position.ToString() + index.ToString() + ".vpp";

            if (File.Exists(filePath))
                CogPMAlignTool = CogSerializer.LoadObjectFromFile(filePath) as CogPMAlignTool;
            else
                CogPMAlignTool = new CogPMAlignTool();
        }

        public void SaveXml(string filePath, int camNo, int stageNo)
        {
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Mark", camNo, stageNo);
            string path = filePath + fileName + ".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement xmlElement = xmlDocument.CreateElement("", "Mark", "");
            xmlDocument.AppendChild(xmlElement);

            //ExitFile(path);
            SaveParams(xmlElement);

            xmlDocument.Save(path);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            XmlHelper.SetValue(xmlElement, "Score", Score.ToString());
            XmlHelper.SetValue(xmlElement, "Angle", Angle.ToString());
        }

        public void LoadXml(string filePath)
        {
            filePath = filePath.Substring(0, filePath.Length - 1);
            filePath += ".xml";

            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement xmlElement = xmlDocument.DocumentElement;

                LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            Score = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "Score", Score.ToString()));
            Angle = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "Angle", Angle.ToString()));
        }

        private void ExitFile(string path)
        {
            if (!File.Exists(path))
            {
                FileStream Files = File.Create(path);
                Files.Close();
            }
        }

        private bool FileExist(string fileName)
        {
            bool bRes = true;
            bRes = File.Exists(fileName);
            return bRes;
        }
    }

    public class MeasureLineParameter
    {
        public const int PAIR = 2;
        public CogCaliperTool[] CogCaliperTool { set; get; } = new CogCaliperTool[PAIR];
        public double SpecX { get; set; } = 0;
        public double SpecY { get; set; } = 0;

        public void SetParam(MeasureLineParameter param)
        {
            for (int pair = 0; pair < PAIR; pair++)
            {
                this.CogCaliperTool[pair] = new CogCaliperTool();
                if (param.CogCaliperTool[pair] == null)
                {
                    param.CogCaliperTool[pair] = new Cognex.VisionPro.Caliper.CogCaliperTool();
                }
            }
          
            this.CogCaliperTool = param.CogCaliperTool;
            this.SpecX = param.SpecX;
            this.SpecY = param.SpecY;
        }

        public MeasureLineParameter Copy()
        {
            MeasureLineParameter param = new MeasureLineParameter();

            param.CogCaliperTool = this.CogCaliperTool;
            param.SpecX = this.SpecX;
            param.SpecY = this.SpecY;

            return param;
        }

        public void SaveVPP(string filePath, int camNo, int stageNo, int index)
        {
            if (!Directory.Exists(filePath))
                Utility.CreateDir(filePath);

            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Caliper_", camNo, stageNo);

            if (CogCaliperTool != null)
            {
                for (int pair = 0; pair < PAIR; pair++)
                {
                    if (CogCaliperTool[pair] == null)
                        continue;

                    CogCaliperTool[pair].InputImage = null;
                    CogSerializer.SaveObjectToFile(CogCaliperTool[pair], filePath + fileName + index.ToString() + "_" + pair.ToString()+".vpp",
                                   typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                }
            }
        }

        public void LoadVPP(string filePath, int index)
        {
            filePath += index.ToString();

            for (int pair = 0; pair < PAIR; pair++)
            {
                string fileName = filePath + "_" + pair.ToString() + ".vpp";

                if (File.Exists(fileName))
                    CogCaliperTool[pair] = CogSerializer.LoadObjectFromFile(fileName) as CogCaliperTool;
                else
                    CogCaliperTool[pair] = new Cognex.VisionPro.Caliper.CogCaliperTool();
            }
        }

        public void SaveXml(string filePath, int camNo, int stageNo, int index)
        {
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Caliper_", camNo, stageNo);
            string path = filePath + fileName + index + ".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement xmlElement = xmlDocument.CreateElement("", "Caliper", "");
            xmlDocument.AppendChild(xmlElement);

            //ExitFile(path);
            SaveParams(xmlElement);

            xmlDocument.Save(path);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            XmlHelper.SetValue(xmlElement, "SpecX", SpecX.ToString());
            XmlHelper.SetValue(xmlElement, "SpecY", SpecY.ToString());
        }

        public void LoadXml(string filePath, int Index)
        {
            filePath += Index.ToString() + ".xml";
            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement xmlElement = xmlDocument.DocumentElement;

                LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            SpecX = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "SpecX", SpecX.ToString()));
            SpecY = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "SpecY", SpecY.ToString()));
        }




        private void ExitFile(string path)
        {
            if (!File.Exists(path))
            {
                FileStream Files = File.Create(path);
                Files.Close();
            }
        }

        

        private bool IsExistFile(string fileName)
        {
            bool bRes = true;
            bRes = File.Exists(fileName);
            return bRes;
        }

        
    }

    public class MeasureCircleParameter
    {
        public CogFindCircleTool CogFindCircleTool = new CogFindCircleTool();
        public double SpecCenterX { get; set; } = 0;
        public double SpecCenterY { get; set; } = 0;

        public void SetParam(MeasureCircleParameter param)
        {
            this.CogFindCircleTool = new CogFindCircleTool();
            if (param.CogFindCircleTool == null) param.CogFindCircleTool = new CogFindCircleTool();
            this.CogFindCircleTool = param.CogFindCircleTool;
            this.SpecCenterX = param.SpecCenterX;
            this.SpecCenterY = param.SpecCenterY;
        }

        public MeasureCircleParameter Copy()
        {
            MeasureCircleParameter param = new MeasureCircleParameter();

            param.CogFindCircleTool = this.CogFindCircleTool;
            param.SpecCenterX = this.SpecCenterX;
            param.SpecCenterY = this.SpecCenterY;

            return param;
        }

        public void SaveVPP(string filePath, int camNo, int stageNo, int index)
        {
           if (!Directory.Exists(filePath))
               Utility.CreateDir(filePath);

           string fileName = string.Format("Cam{0:D}_Stage{1:D}_Circle_", camNo, stageNo);

            if (CogFindCircleTool != null)
            {
                CogFindCircleTool.InputImage = null;
                CogSerializer.SaveObjectToFile(CogFindCircleTool, filePath + fileName + index.ToString()+".vpp",
                                       typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
            }
        }

        public void LoadVPP(string filePath, int index)
        {
            filePath += index.ToString() + ".vpp";

            if (File.Exists(filePath))
                CogFindCircleTool = CogSerializer.LoadObjectFromFile(filePath) as CogFindCircleTool;
            else
                CogFindCircleTool = new CogFindCircleTool();
        }

        public void SaveXml(string filePath,int camNo, int stageNo, int index)
        {
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Circle_", camNo, stageNo);
            string path = filePath + fileName + index + ".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement blobElement = xmlDocument.CreateElement("", "Circle", "");
            xmlDocument.AppendChild(blobElement);

            //ExitFile(path);
            SaveParams(blobElement);

            xmlDocument.Save(path);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            XmlHelper.SetValue(xmlElement, "SpecCenterX", SpecCenterX.ToString());
            XmlHelper.SetValue(xmlElement, "SpecCenterY", SpecCenterY.ToString());
        }

        public void LoadXml(string filePath, int Index)
        {
            filePath += Index.ToString() + ".xml";

            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement xmlElement = xmlDocument.DocumentElement;

                LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            SpecCenterX = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "SpecX", SpecCenterX.ToString()));
            SpecCenterY = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "SpecY", SpecCenterY.ToString()));
        }



        private void ExitFile(string Path)
        {
            if (!File.Exists(Path))
            {
                FileStream Files = File.Create(Path);
                Files.Close();
            }
        }

        

        

        private bool IsExistFile(string fileName)
        {
            bool bRes = true;
            bRes = File.Exists(fileName);
            return bRes;
        }

        
    }

    public class ShortParameter
    {
        public CogBeadInspectTool CogBeadTool { get; set; } = new CogBeadInspectTool();

        public void SetParam(ShortParameter param)
        {
            this.CogBeadTool = new CogBeadInspectTool();
            this.CogBeadTool = param.CogBeadTool;
        }

        public ShortParameter Copy()
        {
            ShortParameter param = new ShortParameter();

            param.CogBeadTool = this.CogBeadTool;

            return param;
        }

        public void SaveVPP(string filePath, int camNo, int stageNo, int index)
        {
            if (!Directory.Exists(filePath))
                Utility.CreateDir(filePath);

            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Blob", camNo, stageNo);

            if (CogBeadTool != null)
            {
                CogBeadTool.InputImage = null;
                CogSerializer.SaveObjectToFile(CogBeadTool, filePath + fileName + index + ".vpp",
                                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
            }
        }

        public void LoadVPP(string filePath, int index)
        {
            filePath += index.ToString() + ".vpp";

            if (File.Exists(filePath))
                CogBeadTool = CogSerializer.LoadObjectFromFile(filePath) as CogBeadInspectTool;
            else
                CogBeadTool = new CogBeadInspectTool();
        }

        public void SaveXml(string filePath, int camNo, int stageNo, int index)
        {
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Blob", camNo, stageNo);
            string path = filePath + fileName + index + ".xml";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement shortElement = xmlDocument.CreateElement("", "Short", "");
            xmlDocument.AppendChild(shortElement);

            //ExitFile(path);
            SaveParams(shortElement);

            xmlDocument.Save(path);
        }

        private void SaveParams(XmlElement xmlElement)
        {
            //XmlElement blobParamElement = xmlElement.OwnerDocument.CreateElement("", "Blob", "");
            //xmlElement.AppendChild(blobParamElement);

            //XmlHelper.SetValue(xmlElement, "WidthMin", WidthMin.ToString());
            //XmlHelper.SetValue(xmlElement, "WidthMax", WidthMax.ToString());
            //XmlHelper.SetValue(xmlElement, "HeightMin", HeightMin.ToString());
            //XmlHelper.SetValue(xmlElement, "HeightMax", HeightMax.ToString());
        }

        public void LoadXml(string filePath, int index)
        {
            filePath += index.ToString() + ".xml";
            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement xmlElement = xmlDocument.DocumentElement;

                LoadParams(xmlElement);
            }
        }

        private void LoadParams(XmlElement xmlElement)
        {
            //XmlElement blobParamElement = xmlElement["Blob"];

            //if (blobParamElement == null)
            //    return;
            //WidthMin = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "WidthMin", WidthMin.ToString()));
            //WidthMax = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "WidthMax", WidthMin.ToString()));
            //HeightMin = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "HeightMin", WidthMin.ToString()));
            //HeightMax = Convert.ToDouble(XmlHelper.GetValue(xmlElement, "HeightMax", WidthMin.ToString()));
        }

        private void ExitFile(string Path)
        {
            if (!File.Exists(Path))
            {
                FileStream Files = File.Create(Path);
                Files.Close();
            }
        }

        private bool IsExistFile(string fileName)
        {
            bool bRes = true;
            bRes = File.Exists(fileName);
            return bRes;
        }
    }
}
