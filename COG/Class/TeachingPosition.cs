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
    public enum eTeachingPosition
    {
        Standby,

        Stage1_PreAlign_Left,
        Stage1_PreAlign_Right,

        Stage1_Scan_Start,

        //Stage2_PreAlign_Left,
        //Stage2_PreAlign_Right,
        //Stage2_Scan_Start,
    }

    public class UnitPosition
    {
        private eAxis _axis = eAxis.None;
        public eAxis Axis
        {
            get { return _axis; }
            set { _axis = value; }
        }

        private double _targetPosition = 0.0;
        public double TargetPosition
        {
            get { return _targetPosition; }
            set { _targetPosition = value; }
        }

        private double _targetPositionOffset = 0.0;
        public double TargetPositionOffset
        {
            get { return _targetPositionOffset; }
            set { _targetPositionOffset = value; }
        }

        private double _targetPositionStartOffset = 0.0;
        public double TargetPositionStartOffset
        {
            get { return _targetPositionStartOffset; }
            set { _targetPositionStartOffset = value; }
        }

        private double _targetPositionEndOffset = 0.0;
        public double TargetPositionEndOffset
        {
            get { return _targetPositionEndOffset; }
            set { _targetPositionEndOffset = value; }
        }

        public UnitPosition(eAxis axis)
        {
            _axis = axis;
            MotionProperty = new MotionProperty();
        }

        public MotionProperty MotionProperty;
    }

    public class OpticParameter
    {
        public int ExposureTime { get; set; } = 0;
        public double DigitalGain { get; set; } = 0.0;
        public int AnalogGain { get; set; } = 0;
        public int LightLevel { get; set; } = 0;
    }

    public class TeachingPosition
    {
        private static TeachingPosition _instance = null;
        public static TeachingPosition Instance()
        {
            if (_instance == null)
                _instance = new TeachingPosition();

            return _instance;
        }

        public OpticParameter OpticParam = new OpticParameter();
        public UnitPosition UnitPosition;
        public List<UnitPosition> UnitPositionList = new List<UnitPosition>();

        public void CreateUnitPosition()
        {
            int count = 0;
            foreach (TeachingPosition teachingPosition in Main.TeachingPositionList)
            {
                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    teachingPosition.UnitPosition = new UnitPosition(axis);
                    //teachingPosition.UnitPosition.MotionProperty = new MotionProperty();
                    UnitPositionList.Add(teachingPosition.UnitPosition);

                    Main.TeachingPositionList[count].UnitPosition = teachingPosition.UnitPosition;
                    Main.TeachingPositionList[count].UnitPositionList = UnitPositionList;
                }

                count++;
            }
        }
        
        public void Save(string recipeName, bool isBackup = false)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\Config\\";
            Utility.CreateDir(filePath);
            filePath += recipeName + ".teach";

            if (isBackup)
            {
                string backupPath = filePath + ".bak";

                if (File.Exists(backupPath))
                    File.Delete(backupPath);

                File.Move(filePath, backupPath);
            }

            SaveXml(filePath);
        }

        public void SaveXml(string filePath)
        {
            if (filePath.Contains("."))
                filePath = Path.GetFileNameWithoutExtension(filePath);

            string path = Directory.GetCurrentDirectory() + "\\Config\\" + filePath + ".teach";

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);

            XmlElement configElement = xmlDocument.CreateElement("", "Config", "");
            xmlDocument.AppendChild(configElement);

            SaveParams(configElement);

            xmlDocument.Save(path);
        }

        public void SaveParams(XmlElement xmlElement)
        {
            XmlElement teachingParamsElement = xmlElement.OwnerDocument.CreateElement("", "TeachingParameter", "");
            xmlElement.AppendChild(teachingParamsElement);

            int count = 0;
            foreach (TeachingPosition teachingPosition in Main.TeachingPositionList)
            {
                string positionStep = string.Format("{0}", Enum.GetName(typeof(eTeachingPosition), count).ToString());
                XmlElement positionStepElement = teachingParamsElement.OwnerDocument.CreateElement("", positionStep, "");
                teachingParamsElement.AppendChild(positionStepElement);

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    string motionParam = string.Format("{0}", axis.ToString());
                    XmlElement motionPropertyElement = positionStepElement.OwnerDocument.CreateElement("", motionParam, "");
                    positionStepElement.AppendChild(motionPropertyElement);

                    XmlHelper.SetValue(motionPropertyElement, "TargetPosition", teachingPosition.UnitPositionList[(int)axis].TargetPosition.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "TargetPositionOffset", teachingPosition.UnitPositionList[(int)axis].TargetPositionOffset.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "TargetPositionStartOffset", teachingPosition.UnitPositionList[(int)axis].TargetPositionStartOffset.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "TargetPositionEndOffset", teachingPosition.UnitPositionList[(int)axis].TargetPositionEndOffset.ToString());

                    XmlHelper.SetValue(motionPropertyElement, "JogLowSpeed", teachingPosition.UnitPositionList[(int)axis].MotionProperty.JogLowSpeed.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "JogHighSpeed", teachingPosition.UnitPositionList[(int)axis].MotionProperty.JogHighSpeed.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "MovingTimeOut", teachingPosition.UnitPositionList[(int)axis].MotionProperty.MovingTimeOut.ToString());

                    XmlHelper.SetValue(motionPropertyElement, "Velocity", teachingPosition.UnitPositionList[(int)axis].MotionProperty.Velocity.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "Acceleration", teachingPosition.UnitPositionList[(int)axis].MotionProperty.Acceleration.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "Deceleration", teachingPosition.UnitPositionList[(int)axis].MotionProperty.Deceleration.ToString());

                    XmlHelper.SetValue(motionPropertyElement, "NegativeSWLimit", teachingPosition.UnitPositionList[(int)axis].MotionProperty.NegativeSWLimit.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "PositiveSWLimit", teachingPosition.UnitPositionList[(int)axis].MotionProperty.PositiveSWLimit.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "MoveTolerance", teachingPosition.UnitPositionList[(int)axis].MotionProperty.MoveTolerance.ToString());

                    XmlHelper.SetValue(motionPropertyElement, "AfterWaitTime", teachingPosition.UnitPositionList[(int)axis].MotionProperty.AfterWaitTime.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "HomingTimeOut", teachingPosition.UnitPositionList[(int)axis].MotionProperty.HomingTimeOut.ToString());
                    XmlHelper.SetValue(motionPropertyElement, "CenterOfGravity", teachingPosition.UnitPositionList[(int)axis].MotionProperty.CenterOfGravity.ToString());
                }

                XmlHelper.SetValue(positionStepElement, "ExposureTime", teachingPosition.OpticParam.ExposureTime.ToString());
                XmlHelper.SetValue(positionStepElement, "DigitalGain", teachingPosition.OpticParam.DigitalGain.ToString());
                XmlHelper.SetValue(positionStepElement, "AnalogGain", teachingPosition.OpticParam.AnalogGain.ToString());
                XmlHelper.SetValue(positionStepElement, "Light", teachingPosition.OpticParam.LightLevel.ToString());
                count++;
            }
        }

        public void LoadXml(string fileName)
        {
            string path = Directory.GetCurrentDirectory() + "\\Config\\";

            string teachFileName = path + fileName + ".teach";

            if (!File.Exists(teachFileName))
            {
                CreateUnitPosition();
                Save(Path.GetFileNameWithoutExtension(teachFileName));
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(teachFileName);
            XmlElement teachElement = xmlDocument.DocumentElement;
            LoadParams(teachElement);
        }

        public void LoadParams(XmlElement xmlElement)
        {
            XmlElement teachingElement = xmlElement["TeachingParameter"];
            if (teachingElement == null)
                return;

            // Create Posistion Table
            if (Main.TeachingPositionList.Count == 0)
            {
                for (int i = 0; i < Enum.GetValues(typeof(eTeachingPosition)).Length; i++)
                    Main.TeachingPositionList.Add(new TeachingPosition());
            }

            if (!teachingElement.HasChildNodes)
            {
                Main.TeachingPositionList.Clear();
                return;
            }

            int count = 0;
            foreach (TeachingPosition teachingPosition in Main.TeachingPositionList)
            {
                XmlElement positionStepElement = teachingElement[string.Format("{0}", Enum.GetName(typeof(eTeachingPosition), count).ToString())];

                if (positionStepElement == null)
                    return;

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    XmlElement motionPropertyElement = positionStepElement[string.Format("{0}", axis.ToString())];

                    teachingPosition.UnitPosition = new UnitPosition(axis);
                    teachingPosition.UnitPosition.Axis = axis;

                    teachingPosition.UnitPosition.TargetPosition = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "TargetPosition", teachingPosition.UnitPosition.TargetPosition.ToString()));
                    teachingPosition.UnitPosition.TargetPositionOffset = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "TargetPositionOffset", teachingPosition.UnitPosition.TargetPositionOffset.ToString()));
                    teachingPosition.UnitPosition.TargetPositionStartOffset = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "TargetPositionStartOffset", teachingPosition.UnitPosition.TargetPositionStartOffset.ToString()));
                    teachingPosition.UnitPosition.TargetPositionEndOffset = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "TargetPositionEndOffset", teachingPosition.UnitPosition.TargetPositionEndOffset.ToString()));

                    teachingPosition.UnitPosition.MotionProperty.JogLowSpeed = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "JogLowSpeed", teachingPosition.UnitPosition.MotionProperty.JogLowSpeed.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.JogHighSpeed = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "JogHighSpeed", teachingPosition.UnitPosition.MotionProperty.JogHighSpeed.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.MovingTimeOut = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "MovingTimeOut", teachingPosition.UnitPosition.MotionProperty.MovingTimeOut.ToString()));

                    teachingPosition.UnitPosition.MotionProperty.Velocity = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "Velocity", teachingPosition.UnitPosition.MotionProperty.Velocity.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.Acceleration = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "Acceleration", teachingPosition.UnitPosition.MotionProperty.Acceleration.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.Deceleration = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "Deceleration", teachingPosition.UnitPosition.MotionProperty.Deceleration.ToString()));

                    teachingPosition.UnitPosition.MotionProperty.NegativeSWLimit = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "NegativeSWLimit", teachingPosition.UnitPosition.MotionProperty.NegativeSWLimit.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.PositiveSWLimit = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "PositiveSWLimit", teachingPosition.UnitPosition.MotionProperty.PositiveSWLimit.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.MoveTolerance = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "MoveTolerance", teachingPosition.UnitPosition.MotionProperty.MoveTolerance.ToString()));

                    teachingPosition.UnitPosition.MotionProperty.AfterWaitTime = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "AfterWaitTime", teachingPosition.UnitPosition.MotionProperty.AfterWaitTime.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.HomingTimeOut = Convert.ToDouble(XmlHelper.GetValue(motionPropertyElement, "HomingTimeOut", teachingPosition.UnitPosition.MotionProperty.HomingTimeOut.ToString()));
                    teachingPosition.UnitPosition.MotionProperty.CenterOfGravity = Convert.ToInt32(XmlHelper.GetValue(motionPropertyElement, "CenterOfGravity", teachingPosition.UnitPosition.MotionProperty.CenterOfGravity.ToString()));

                    teachingPosition.UnitPositionList.Add(teachingPosition.UnitPosition);
                }

                teachingPosition.OpticParam.ExposureTime = Convert.ToInt32(XmlHelper.GetValue(positionStepElement, "ExposureTime", teachingPosition.OpticParam.ExposureTime.ToString()));
                teachingPosition.OpticParam.DigitalGain = Convert.ToDouble(XmlHelper.GetValue(positionStepElement, "DigitalGain", teachingPosition.OpticParam.DigitalGain.ToString()));
                teachingPosition.OpticParam.AnalogGain = Convert.ToInt32(XmlHelper.GetValue(positionStepElement, "AnalogGain", teachingPosition.OpticParam.AnalogGain.ToString()));
                teachingPosition.OpticParam.LightLevel = Convert.ToInt32(XmlHelper.GetValue(positionStepElement, "Light", teachingPosition.OpticParam.LightLevel.ToString()));
                count++;
            }
        }

        private eTeachingPosition _selectedTeachingPosition = eTeachingPosition.Standby;
        public eTeachingPosition SelectedTeachingPosition
        {
            get { return _selectedTeachingPosition; }
            set { _selectedTeachingPosition = value; }
        }
    }
}
