using JASUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace COG.Params
{
    public class RecipeParameter
    {
        private ATTRecipe _att = new ATTRecipe();
        public ATTRecipe ATT
        {
            get { return _att; }
            set { _att = value; }
        }

        private CGMSRecipe _cgms = new CGMSRecipe();
        public CGMSRecipe CGMS
        {
            get { return _cgms; }
            set { _cgms = value; }
        }

        public void Save(bool isBackup = false)
        {

        }
    }

    public class CGMSRecipe
    {
        public SampleInformation SampleInfo { get; set; } = new SampleInformation();
        public GrabMethod GrabMatrix { get; set; } = new GrabMethod();
        public class SampleInformation
        {
            //public double PatternYSize { get; set; } = 0.0;
            //public double MarkToPatternXDistance { get; set; } = 0.0;
            //public double PatternToPatternXDistance { get; set; } = 0.0;
            //public double PatternToPatternYDistance { get; set; } = 0.0;
            public double PatternSizeY { get; set; } = 0.0;
            public double MarkToPatternDistanceX { get; set; } = 1.1;
            public double PatternToPatternDistanceX { get; set; } = 2.2;
            public double PatternToPatternDistanceY { get; set; } = 3.3;

            public void Save(bool isBackup = false)
            {
                string strPath = Directory.GetCurrentDirectory() + "\\Config";
                Utility.CreateDir(strPath);
                strPath += "\\MaterialInformation.xml";

                if (isBackup)
                {
                    string backupPath = strPath + ".bak"; // 백업 주소를 만듭니다.

                    if (File.Exists(backupPath))
                        File.Delete(backupPath);

                    File.Move(strPath, backupPath);
                }

                XmlDocument xmlDocument = new XmlDocument();

                XmlHelper.SaveDeclaration(xmlDocument);

                XmlElement sampleElement = xmlDocument.CreateElement("", "MaterialInformation", "");
                xmlDocument.AppendChild(sampleElement);

                SaveParams(sampleElement);

                xmlDocument.Save(strPath);
            }

            private void SaveParams(XmlElement xmlElement)
            {
                // Sample
                XmlElement deviceElement = xmlElement.OwnerDocument.CreateElement("", "Device", "");
                xmlElement.AppendChild(deviceElement);

                XmlHelper.SetValue(deviceElement, "PatternSizeY", PatternSizeY.ToString());
                XmlHelper.SetValue(deviceElement, "MarkToPatternDistanceX", MarkToPatternDistanceX.ToString());
                XmlHelper.SetValue(deviceElement, "PatternToPatternDistanceX", PatternToPatternDistanceX.ToString());
                XmlHelper.SetValue(deviceElement, "PatternToPatternDistanceY", PatternToPatternDistanceY.ToString());
            }
        }

        public class GrabMethod
        {
            public int Row { get; set; } = 0;
            public int Column { get; set; } = 0;
        }
    }

    public class ATTRecipe
    {
        public SampleInformation SampleInfo { get; set; } = new SampleInformation();

        public class SampleInformation
        {
            //public double PatternYSize { get; set; } = 0.0;
            //public double MarkToPatternXDistance { get; set; } = 0.0;
            //public double PatternToPatternXDistance { get; set; } = 0.0;
            //public double PatternToPatternYDistance { get; set; } = 0.0;
            public double PanelSizeX { get; set; } = 0.0;
            public double MarkToMarkDistance { get; set; } = 0.0;
            public double TabWidth { get; set; } = 0.0;
            public double PanelEdgeToFirstTabDistance { get; set; } = 0.0;
            public int TabToTabDistance1 { get; set; } = 0;
            public int TabToTabDistance2 { get; set; } = 0;
            public int TabToTabDistance3 { get; set; } = 0;
            public int TabToTabDistance4 { get; set; } = 0;
            public int TabToTabDistance5 { get; set; } = 0;
        }
    }
}
