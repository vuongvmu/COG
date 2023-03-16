using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32; //Regedit_Password


using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.CNLSearch;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.SearchMax;
using Cognex.VisionPro.LineMax;
using COG.Class.MOTION;
using COG.Class;
using static COG.InspectionItem;

namespace COG
{
    public partial class Main
    {
        public class DataFileTag
        {
            #region DataFileDefine
            String m_FileName;
            [DllImport("kernel32.dll")]
            private static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);

            [DllImport("kernel32.dll")]
            private static extern long WritePrivateProfileString(String section, String key, String val, String filePath);

            public void SetFileName(String FileName)
            {
                m_FileName = FileName;
            }
            public void SetData(String Section, String key, int DataValue)
            {
                WritePrivateProfileString(Section, key, DataValue.ToString(), m_FileName);
            }
            public void SetData(String Section, String key, double DataValue)
            {
                WritePrivateProfileString(Section, key, DataValue.ToString(), m_FileName);
            }
            public void SetData(String Section, String key, string DataValue)
            {
                WritePrivateProfileString(Section, key, DataValue, m_FileName);
            }
            public void SetData(String Section, String key, string DataValue, string nFileName)
            {
                long nRet = WritePrivateProfileString(Section, key, DataValue, nFileName);
                if (nRet == 0)
                {
                    nRet = Marshal.GetLastWin32Error();
                    //Main.AlignUnit[0].LogdataDisplay("ERROR : " + nRet.ToString(), true);
                }
            }
            public void SetData(String Section, String key, bool DataValue)
            {
                WritePrivateProfileString(Section, key, DataValue.ToString(), m_FileName);
            }
            public int GetIData(String Section, String Key)
            {
                StringBuilder temp = new StringBuilder(80);
                string temp_return;
                int i = GetPrivateProfileString(Section, Key, "0", temp, 80, m_FileName);
                temp_return = temp.ToString();
                return Convert.ToInt32(temp_return);
            }
            public double GetFData(String Section, String Key)
            {
                StringBuilder temp = new StringBuilder(80);
                string temp_return;
                int i = GetPrivateProfileString(Section, Key, "0", temp, 80, m_FileName);
                temp_return = temp.ToString();
                return Convert.ToDouble(temp_return);
            }
            public String GetSData(String Section, String Key)
            {
                StringBuilder temp = new StringBuilder(80);
                int i = GetPrivateProfileString(Section, Key, " ", temp, 80, m_FileName);
                return temp.ToString();
            }
            public bool GetBData(String Section, String Key)
            {
                bool Ret;
                StringBuilder temp = new StringBuilder(80);
                int i = GetPrivateProfileString(Section, Key, "false", temp, 80, m_FileName);
                bool.TryParse(temp.ToString(), out Ret);
                return Ret;
            }
            #endregion
        }


        public static DataFileTag SystemFile = new DataFileTag();
        public static DataFileTag OldLogCheckFile = new DataFileTag();
        public static DataFileTag ModelFile = new DataFileTag();
        public static DataFileTag MotionFile = new DataFileTag();
        public static DataFileTag RecipeFile = new DataFileTag();

        public static string ProjectName;
        public static string ProjectInfo;
        public static string SysdataPath;
        public static string ModelPath;
        public static string LogdataPath;
        public static string ErrdataPath;
        public static string CamdataPath;
        public static string MotionPath;
        public static string InterfacePath;

        

        #region PASSWORD
        public static void WriteRegistry(string _Mode, string _Password)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(Main.DEFINE.PASSWORD_DIR, RegistryKeyPermissionCheck.ReadWriteSubTree);
            regKey.SetValue(_Mode, _Password, RegistryValueKind.String);
        }
        public static string ReadRegistry(string _Mode)
        {
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey(Main.DEFINE.PASSWORD_DIR, true);

            if (reg == null) return "";

            if (null != reg.GetValue(_Mode))
            {
                return Convert.ToString(reg.GetValue(_Mode));
            }
            else
            {
                return "";
            }
        }
        public static void DeleteRegistry()
        {
            Registry.CurrentUser.DeleteSubKey(Main.DEFINE.PASSWORD_DIR);
        }
        #endregion
        #region LANGUAGE
        public static void WriteRegistryLan(string _Mode)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(Main.DEFINE.LANGUAGE_DIR, RegistryKeyPermissionCheck.ReadWriteSubTree);

            regKey.SetValue("language", _Mode, RegistryValueKind.String);
        }
        public static int ReadRegistryLan()
        {
            string _Mode = "language";
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey(Main.DEFINE.LANGUAGE_DIR, true);

            if (reg == null) return Main.DEFINE.KOREA;

            if (null != reg.GetValue(_Mode))
            {
                return Convert.ToInt32(reg.GetValue(_Mode));
            }
            else
            {
                return Convert.ToInt32(Main.DEFINE.KOREA);
            }
        }
        #endregion


        #region INITIAL
        public static void System_Initial()
        {
            string buf;

            SysdataPath = DEFINE.SYS_DATADIR;
            ModelPath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\";
            LogdataPath = DEFINE.SYS_DATADIR + DEFINE.LOG_DATADIR;
            ErrdataPath = DEFINE.SYS_DATADIR + DEFINE.ERROR_DATADIR;
            CamdataPath = DEFINE.SYS_DATADIR + DEFINE.CAM_SETDIR;
            InterfacePath = DEFINE.SYS_DATADIR + DEFINE.INTERFACE_DATADIR;

            buf = SysdataPath + "SYSTEM_" + DEFINE.MODEL_DATADIR + ".ini";
            SystemFile.SetFileName(buf);  

            buf = SysdataPath + "OLD_LOG_CHECK_FILE.dat";
            OldLogCheckFile.SetFileName(buf);

            if (!Directory.Exists(SysdataPath)) Directory.CreateDirectory(SysdataPath);
            if (!Directory.Exists(CamdataPath)) Directory.CreateDirectory(CamdataPath);
            if (!Directory.Exists(ModelPath)) Directory.CreateDirectory(ModelPath);
            if (!Directory.Exists(LogdataPath)) Directory.CreateDirectory(LogdataPath);
            if (!Directory.Exists(ErrdataPath)) Directory.CreateDirectory(ErrdataPath);
            if (!Directory.Exists(InterfacePath)) Directory.CreateDirectory(InterfacePath);

            Status.MC_STATUS = DEFINE.MC_STOP;

        }
        public static void Model_Initial()
        {
            string buf;

            ModelPath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\";
            buf = ModelPath + ProjectName + "\\Model.ini";
            ModelFile.SetFileName(buf);

            if (!Directory.Exists(ModelPath)) Directory.CreateDirectory(ModelPath);
        }

        public static void Motion_Initial()
        {
            string buf;

            MotionPath = DEFINE.SYS_DATADIR  + DEFINE.MODEL_DATADIR;

            buf = MotionPath + ProjectName + "\\Motion.ini";
            MotionFile.SetFileName(buf);

            if (!Directory.Exists(MotionPath)) Directory.CreateDirectory(MotionPath);
        }

        public static void Recipe_Initial()
        {
            string buf;

            ModelPath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\";
            buf = ModelPath + ProjectName + "\\Recipe.ini";
            RecipeFile.SetFileName(buf);

            if (!Directory.Exists(ModelPath))
                Directory.CreateDirectory(ModelPath);
        }

        public static void ReadMotionData()
        {
            string buf;

            MotionPath = DEFINE.SYS_DATADIR  + DEFINE.MODEL_DATADIR;

            buf = MotionPath + ProjectName + "\\Motion.ini";
            MotionFile.SetFileName(buf);

            if (!Directory.Exists(MotionPath))
                Directory.CreateDirectory(MotionPath);
        }
       #endregion

        #region Project
        public static bool ProjectRename(string _modelName, string _modelInfo)
        {
            bool nRet = true;

            if (!Directory.Exists(ModelPath))
            {
                nRet = false;
            }
            if (!Directory.Exists(ModelPath + _modelName))
            {
                nRet = false;
            }

            string buf;
            buf = ModelPath + _modelName + "\\Model.ini";
            ModelFile.SetData("PROJECT", "NAME", _modelInfo, buf);
            return nRet;
        }
        public static void ProjectSave(string _modelName, string _modelInfo)
        {
            string buf;
            ProjectName = _modelName;
            ProjectInfo = _modelInfo;

            buf = ModelPath + ProjectName + "\\Model.ini";
            ModelFile.SetFileName(buf);
            SystemFile.SetData("SYSTEM", "LAST_PROJECT", ProjectName);

            if (!Directory.Exists(ModelPath)) Directory.CreateDirectory(ModelPath);
            if (!Directory.Exists(ModelPath + ProjectName)) Directory.CreateDirectory(ModelPath + ProjectName);

            ModelFile.SetData("PROJECT", "NAME", _modelInfo);

            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                for (int j = 0; j < Main.AlignUnit[i].m_AlignPatTagMax; j++)
                {
                    AlignUnit[i].Save(j);
                }
            }
        }
        public static bool ProjectLoad(string _modelName)
        {
            string buf;
            if (!Directory.Exists(ModelPath))
            {
                MessageBox.Show(ModelPath + "not Directory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Directory.Exists(ModelPath + _modelName))
            {
                return false;
            }
            if (ProjectName == _modelName)
            {
                return true;
            }
            ProjectName = _modelName;
            buf = ModelPath + ProjectName + "\\Model.ini";
            ModelFile.SetFileName(buf);
            ProjectInfo = ModelFile.GetSData("PROJECT", "NAME");
            SystemFile.SetData("SYSTEM", "LAST_PROJECT", ProjectName);

            if(!Main.DEFINE.OPEN_F)
                Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.CURRENT_MODEL_CODE, Convert.ToInt16(Main.ProjectName));

            Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, 0);
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                //  for (int j = 0; j < Main.AlignUnit[i].m_AlignPatTagMax; j++)
                for (int j = AlignUnit[i].m_AlignPatTagMax - 1; j >= 0; j--)
                {
                    AlignUnit[i].Load(j);
                }
                Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, i + 1);
            }
            return true;
        }
        public static bool ProjectCopy(string _sourceName, string _targetName)
        {
            string strModelInfo = "";
            if (!Directory.Exists(ModelPath))
            {
                AlignUnit[0].LogdataDisplay(ModelPath + " Directory not exists", true);
                return false;
            }
            if (!Directory.Exists(ModelPath + _sourceName))
            {
                AlignUnit[0].LogdataDisplay(ModelPath + _sourceName + " Directory not exists", true);
                return false;
            }
            if (Directory.Exists(ModelPath + _targetName))
            {
                AlignUnit[0].LogdataDisplay(ModelPath + _targetName + " Directory already exists", true);
                return false;
            }

            if (FolderCopy(ModelPath + _sourceName, ModelPath + _targetName))
            {
                for (int i = 0; i < 10; i++)
                {
                    char m_CharData;
                    long dataNum;
                    string m_strData;

                    dataNum = PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NAME + i] & 0x00ff;
                    m_CharData = Convert.ToChar(dataNum);
                    m_strData = m_CharData.ToString();
                    if (m_strData == "\0") break;
                    strModelInfo += m_strData;

                    dataNum = (PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NAME + i] >> 8) & 0x00ff;
                    m_CharData = Convert.ToChar(dataNum);
                    m_strData = m_CharData.ToString();
                    if (m_strData == "\0") break;
                    strModelInfo += m_strData;
                }

                AlignUnit[0].LogdataDisplay(_targetName + " - " + strModelInfo + " Model Copy Success", true);

                MODEL_COPY = true;
                MODEL_COPY_NAME = _targetName;
                MODEL_COPY_INFO = strModelInfo;

                ProjectRename(_targetName, strModelInfo);

                return true;
            }
            else
            {
                //AlignUnit[0].LogdataDisplay(_targetName + " Model Copy Fail", true);
                return false;
            }
        }
        public static bool ProjectDelete(string _modelName)
        {
            if (Directory.Exists(Main.ModelPath + _modelName))
            {
                string[] arrFile = Directory.GetFiles(Main.ModelPath + _modelName);

                for (int i = 0; i < arrFile.Length; i++)
                {
                    DirectoryInfo DI = new DirectoryInfo(arrFile[i]);
                    File.Delete(DI.FullName);
                }
            }
            else
            {
                Main.AlignUnit[0].LogdataDisplay("Source Or Dest Path  Not Exist", true);
                return false;
            }

            Directory.Delete(Main.ModelPath + _modelName);

            return true;
        }
        public static bool ProjectCreate(string _modelNum, string _ModelName)
        {
            //if (Directory.Exists(ModelPath))
            //{
            //    return false;
            //}
            if (Directory.Exists(ModelPath + _modelNum))
            {
                return false;
            }

            ProjectSave(_modelNum, _ModelName);

            return true;
        }

        #endregion
        public static void CenterXYSave(int CamNo)
        {
            for (int j = 0; j < Main.AlignUnit[CamNo].m_AlignPatTagMax; j++)
            {
                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CENTER_X_" + j.ToString(), AlignUnit[CamNo].m_CenterX[j]);
                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CENTER_Y_" + j.ToString(), AlignUnit[CamNo].m_CenterY[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CENTER_X_" + j.ToString(), AlignUnit[CamNo].m_CenterX[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CENTER_Y_" + j.ToString(), AlignUnit[CamNo].m_CenterY[j]);

                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CALMOTOR_X_" + j.ToString(), AlignUnit[CamNo].m_CalMotoPosX[j]);
                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CALMOTOR_Y_" + j.ToString(), AlignUnit[CamNo].m_CalMotoPosY[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CALMOTOR_X_" + j.ToString(), AlignUnit[CamNo].m_CalMotoPosX[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CALMOTOR_Y_" + j.ToString(), AlignUnit[CamNo].m_CalMotoPosY[j]);

                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CALDISPLAY_X_" + j.ToString(), AlignUnit[CamNo].m_CalDisplayCX[j]);
                SystemFile.SetData(AlignUnit[CamNo].m_AlignName, "CALDISPLAY_Y_" + j.ToString(), AlignUnit[CamNo].m_CalDisplayCY[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CALDISPLAY_X_" + j.ToString(), AlignUnit[CamNo].m_CalDisplayCX[j]);
                ModelFile.SetData(AlignUnit[CamNo].m_AlignName, "CALDISPLAY_Y_" + j.ToString(), AlignUnit[CamNo].m_CalDisplayCY[j]);
            }
        }
        public static void SystemSave()
        {
            //-------------------------------------------
            // OPTION
            //-------------------------------------------
            SystemFile.SetData("OPTION", "OVELAY_IMAGE_SAVE", machine.Overlay_Image_Onf);
            SystemFile.SetData("OPTION", "GAP_LOG_MSG", machine.LogMsg_Onf);
            SystemFile.SetData("OPTION", "INSPECTION", machine.Inspection_Onf);
            SystemFile.SetData("OPTION", "L_CHECK", machine.LengthCheck_Onf);
            SystemFile.SetData("OPTION", "BMP", machine.BMP_ImageSave_Onf);
            SystemFile.SetData("OPTION", "OLD_LOG_PERIOD", machine.m_nOldLogCheckPeriod);
            SystemFile.SetData("OPTION", "OLD_LOG_SPACE", machine.m_nOldLogCheckSpace);
            SystemFile.SetData("OPTION", "CCLINK_COMM_DELAY", machine.m_nCCLinkCommDelay_ms);
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                SystemFile.SetData("OPTION", "USE_LOADING_LIMIT", machine.m_bUseLoadingLimit);
                SystemFile.SetData("OPTION", "LOADING_LIMIT_X", machine.m_nLoadingLimitX_um);
                SystemFile.SetData("OPTION", "LOADING_LIMIT_Y", machine.m_nLoadingLimitY_um);
                SystemFile.SetData("OPTION", "INSP_LIMIT_LOW", machine.m_nInspLowLimit_um);
                SystemFile.SetData("OPTION", "INSP_LIMIT_HIGH", machine.m_nInspHighLimit_um);
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                SystemFile.SetData("OPTION", "USE_ALIGN1_ANGLE_LIMIT", machine.m_bUseAlign1AngleLimit);
                SystemFile.SetData("OPTION", "ALIGN1_CORNER_LIMIT", machine.m_f1stAlignCornerAngleLimit);
                SystemFile.SetData("OPTION", "ALIGN1_VERTICAL_LIMIT", machine.m_f1stAlignVerticalAngleLimit);
            }
            SystemFile.SetData("SYSTEM", "PLC_READ_DATA", PLCDataTag.BASE_RW_ADDR);
            SystemFile.SetData("SYSTEM", "LAST_PROJECT", ProjectName);
            SystemFile.SetData("UVW", "STAGE_R", Main.UVW.STAGE_R);
            SystemFile.SetData("UVW", "LIMIT_X", Main.Common.Limit_X);
            SystemFile.SetData("UVW", "LIMIT_Y", Main.Common.Limit_Y);
            SystemFile.SetData("UVW", "LIMIT_T", Main.Common.Limit_T);
            SystemFile.SetData("LIMIT", "LIMIT_ANGLE", Main.Common.Limit_Angle);

            // Vision Setting
            SystemFile.SetData("VISION_SETTING", "CAMERA_DISTANCE_X", Main.machine.CameraDistanceX);
            SystemFile.SetData("VISION_SETTING", "CAMERA_DISTANCE_Y", Main.machine.CameraDistanceY);

            SystemFile.SetData("LINESCAN_AXIS", "LINESCAN_AXIS", Main.machine.LineScanAxis.ToString());
            //if (rdoLineScanAxisX.Checked)
            //    Main.machine.LineScanAxis = eAxis.Axis_X;
            //else if (rdoLineScanAxisY.Checked)
            //    Main.machine.LineScanAxis = eAxis.Axis_Y;
            //else { }

            // PreAlign Tolerance
            SystemFile.SetData("TOLERANCE", "PREALIGN_REFERENCE_X", Main.machine.PreAlignReferenceX);
            SystemFile.SetData("TOLERANCE", "PREALIGN_REFERENCE_Y", Main.machine.PreAlignReferenceY);
            SystemFile.SetData("TOLERANCE", "PREALIGN_REFERENCE_T", Main.machine.PreAlignReferenceT);
            SystemFile.SetData("TOLERANCE", "PREALIGN_TOLERANCE_X", Main.machine.PreAlignToleranceX);
            SystemFile.SetData("TOLERANCE", "PREALIGN_TOLERANCE_Y", Main.machine.PreAlignToleranceY);
            SystemFile.SetData("TOLERANCE", "PREALIGN_TOLERANCE_T", Main.machine.PreAlignToleranceT);

            // Inspection Option
            SystemFile.SetData("INSPECTION_OPTION", "UseBlob", Main.machine.UseBlob);
            SystemFile.SetData("INSPECTION_OPTION", "UseMeasure", Main.machine.UseMeasure);
            SystemFile.SetData("INSPECTION_OPTION", "UseMeasureLine", Main.machine.UseMeasureLine);
            SystemFile.SetData("INSPECTION_OPTION", "UseMeasureCircle", Main.machine.UseMeasureCircle);
            SystemFile.SetData("INSPECTION_OPTION", "UseAkkon", Main.machine.UseAkkon);
            SystemFile.SetData("INSPECTION_OPTION", "UseBead", Main.machine.UseBead);
            SystemFile.SetData("INSPECTION_OPTION", "UseMarkWhenAlign", Main.machine.UseMarkWhenAlign);

            // ATT Option
            SystemFile.SetData("ATT_OPTION", "DRAW_CENTER", Main.machine.IsDrawCenter);
            SystemFile.SetData("ATT_OPTION", "DRAW_CONTUR", Main.machine.IsDrawContour);
            SystemFile.SetData("ATT_OPTION", "DRAW_LENGTH", Main.machine.IsDrawlength);
            SystemFile.SetData("ATT_OPTION", "RMS_AAKKON_PARAMETER", Main.machine.IsRMSAkkonParameterSet);

            // Auto Run Option
            SystemFile.SetData("ATT_OPTION", "FORCE_PREALIGN", Main.machine.IsForcePrealign);
            SystemFile.SetData("ATT_OPTION", "FORCE_ALIGN", Main.machine.IsForceAlign);
            SystemFile.SetData("ATT_OPTION", "FORCE_AKKON", Main.machine.IsForceAkkon);

            // Alarm Setting
            //SystemFile.SetData("ATT_OPTION", "CHECK_PANEL_CAPACITY", Main.machine.m_nCheckPanelCapacity);
            //SystemFile.SetData("ATT_OPTION", "NG_COUNG", Main.machine.m_nNGCount);

            // Save Image
            SystemFile.SetData("VISION_OPTION", "SAVE_OK_IMAGE", Main.machine.IsSaveOKImage);
            SystemFile.SetData("VISION_OPTION", "SAVE_OK_IMAGE_EXTENSION", Main.machine.SaveOKImageExtension.ToString());
            SystemFile.SetData("VISION_OPTION", "SAVE_NG_IMAGE", Main.machine.IsSaveNGImage);
            SystemFile.SetData("VISION_OPTION", "SAVE_NG_IMAGE_EXTENSION", Main.machine.SaveNGImageExtension.ToString());

            // Data Store
            SystemFile.SetData("DATA_STORE", "IMAGE_SAVE_DURATION", Main.machine.ImageSaveDuration);
            SystemFile.SetData("DATA_STORE", "IMAGE_SAVE_CAPACITY", Main.machine.ImageSaveCapacity);
            SystemFile.SetData("DATA_STORE", "LOG_SAVE_PERIOD", Main.machine.LogSavePeriod);

            // Motion
            SystemFile.SetData("MOTION", "IP_ADDRESS", Main.machine.MotionIPAddress);
            SystemFile.SetData("MOTION", "PORT_NUMBER", Main.machine.MotionPort);

            // PLC
            SystemFile.SetData("PLC", "IP_ADDRESS", Main.machine.PLCIPAddress);
            SystemFile.SetData("PLC", "PORT_NUMBER", Main.machine.PLCPort);

            // Auto Focus
            SystemFile.SetData("AUTOFOCUS", "COMPORT", Main.machine.AutoFocusCOMPort);
            SystemFile.SetData("AUTOFOCUS", "BAUD_RATE", Main.machine.AutoFocusBaudRate);

            // Light
            SystemFile.SetData("LIGHT", "COMPORT", Main.machine.LightCOMPort);
            SystemFile.SetData("LIGHT", "BAUD_RATE", Main.machine.LightBaudRate);

            Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, 0);

            for (int i = 0; i < DEFINE.AlignUnit_Max; i++)
            {
                // Memory Address
                SystemFile.SetData(AlignUnit[i].m_AlignName, "ALIGN_UNIT_ADDR", AlignUnit[i].ALIGN_UNIT_ADDR);
                // parameter
                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAL_MOVE_X", AlignUnit[i].m_Cal_MOVE_X);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAL_MOVE_Y", AlignUnit[i].m_Cal_MOVE_Y);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAL_MOVE_T1", AlignUnit[i].m_Cal_MOVE_T1);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAL_MOVE_T2", AlignUnit[i].m_Cal_MOVE_T2);

                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAM_OFFSET_X", AlignUnit[i].m_CamOffsetX);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "CAM_OFFSET_Y", AlignUnit[i].m_CamOffsetY);

                SystemFile.SetData(AlignUnit[i].m_AlignName, "STANDARD_MARK_T", AlignUnit[i].m_StandardMark_T);
                // Motor AXIS DIR
                SystemFile.SetData(AlignUnit[i].m_AlignName, "DIR_X", AlignUnit[i].m_DirX);

                SystemFile.SetData(AlignUnit[i].m_AlignName, "GD_IMAGE", AlignUnit[i].m_GD_ImageSave_Use);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "NG_IMAGE", AlignUnit[i].m_NG_ImageSave_Use);

                //                  SystemFile.SetData(AlignUnit[i].m_AlignName, "LENGTH_CHECK_USE", AlignUnit[i].m_LengthCheck_Use);
                // 
                //                  SystemFile.SetData(AlignUnit[i].m_AlignName, "STANDARDMARK_LENGTH_OBJ", AlignUnit[i].m_OBJ_Standard_Length);
                //                  SystemFile.SetData(AlignUnit[i].m_AlignName, "STANDARDMARK_LENGTH_TAR", AlignUnit[i].m_TAR_Standard_Length);

                // Motion
                SystemFile.SetData(AlignUnit[i].m_AlignName, "AXIS_ID", AlignUnit[i].m_MotionParams.AxisID);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "START_POS", AlignUnit[i].m_MotionParams.StartPosition);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "END_POS", AlignUnit[i].m_MotionParams.EndPosition);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "VELOCITY", AlignUnit[i].m_MotionParams.Velocity);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "ACCEL", AlignUnit[i].m_MotionParams.Acceleration);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "DECEL", AlignUnit[i].m_MotionParams.Deceleration);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "TIMEOUTCOND", AlignUnit[i].m_MotionParams.TimeoutCondition);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "POS_LIMIT", AlignUnit[i].m_MotionParams.PositiveLimit);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "NEG_LIMIT", AlignUnit[i].m_MotionParams.NegativeLimit);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "ACCEL_LIMIT", AlignUnit[i].m_MotionParams.AccelerationLimit);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "DECEL_LIMIT", AlignUnit[i].m_MotionParams.DecelerationLimit);
                SystemFile.SetData(AlignUnit[i].m_AlignName, "JERK", AlignUnit[i].m_MotionParams.Jerk);

                //Align Tolerance & Standard Data
                ModelFile.SetData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_X", AlignUnit[i].m_AlignTolX);
                ModelFile.SetData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_Y", AlignUnit[i].m_AlignTolY);
                ModelFile.SetData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_CX", AlignUnit[i].m_AlignTolCX);
                ModelFile.SetData(AlignUnit[i].m_AlignName, "ALIGN_STANDARD_Y", AlignUnit[i].m_AlignStandardY);

                for (int j = 0; j < AlignUnit[i].m_AlignPatTagMax; j++)
                {
                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CENTER_X_" + j.ToString(), AlignUnit[i].m_CenterX[j]);
                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CENTER_Y_" + j.ToString(), AlignUnit[i].m_CenterY[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CENTER_X_" + j.ToString(), AlignUnit[i].m_CenterX[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CENTER_Y_" + j.ToString(), AlignUnit[i].m_CenterY[j]);

                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CALMOTOR_X_" + j.ToString(), AlignUnit[i].m_CalMotoPosX[j]);
                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CALMOTOR_Y_" + j.ToString(), AlignUnit[i].m_CalMotoPosY[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CALMOTOR_X_" + j.ToString(), AlignUnit[i].m_CalMotoPosX[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CALMOTOR_Y_" + j.ToString(), AlignUnit[i].m_CalMotoPosY[j]);

                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CALDISPLAY_X_" + j.ToString(), AlignUnit[i].m_CalDisplayCX[j]);
                    SystemFile.SetData(AlignUnit[i].m_AlignName, "CALDISPLAY_Y_" + j.ToString(), AlignUnit[i].m_CalDisplayCY[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CALDISPLAY_X_" + j.ToString(), AlignUnit[i].m_CalDisplayCX[j]);
                    ModelFile.SetData(AlignUnit[i].m_AlignName, "CALDISPLAY_Y_" + j.ToString(), AlignUnit[i].m_CalDisplayCY[j]);

                    AlignUnit[i].Save(j);
                }


                Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, i + 1);
            }
        }
        public static void LoadTeachData()
        {
            
        }
        public static void SystemLoad()
        {
            ////-------------------------------------------
            //// OPTION
            ////-------------------------------------------
            //machine.Overlay_Image_Onf = SystemFile.GetBData("OPTION", "OVELAY_IMAGE_SAVE");
            //machine.LogMsg_Onf = SystemFile.GetBData("OPTION", "GAP_LOG_MSG");
            //machine.Inspection_Onf = SystemFile.GetBData("OPTION", "INSPECTION");
            //machine.LengthCheck_Onf = SystemFile.GetBData("OPTION", "L_CHECK");
            //machine.BMP_ImageSave_Onf = SystemFile.GetBData("OPTION", "BMP");
            //machine.m_nOldLogCheckPeriod = SystemFile.GetIData("OPTION", "OLD_LOG_PERIOD");
            //machine.m_nOldLogCheckSpace = SystemFile.GetIData("OPTION", "OLD_LOG_SPACE");
            //machine.m_nCCLinkCommDelay_ms = SystemFile.GetIData("OPTION", "CCLINK_COMM_DELAY");
            //if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            //{
            //    machine.m_bUseLoadingLimit = SystemFile.GetBData("OPTION", "USE_LOADING_LIMIT");
            //    machine.m_nLoadingLimitX_um = SystemFile.GetIData("OPTION", "LOADING_LIMIT_X");
            //    machine.m_nLoadingLimitY_um = SystemFile.GetIData("OPTION", "LOADING_LIMIT_Y");
            //    machine.m_nInspLowLimit_um = SystemFile.GetIData("OPTION", "INSP_LIMIT_LOW");
            //    machine.m_nInspHighLimit_um = SystemFile.GetIData("OPTION", "INSP_LIMIT_HIGH");
            //}
            //else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            //{
            //    machine.m_bUseAlign1AngleLimit = SystemFile.GetBData("OPTION", "USE_ALIGN1_ANGLE_LIMIT");
            //    machine.m_f1stAlignCornerAngleLimit = (float)SystemFile.GetFData("OPTION", "ALIGN1_CORNER_LIMIT");
            //    machine.m_f1stAlignVerticalAngleLimit = (float)SystemFile.GetFData("OPTION", "ALIGN1_VERTICAL_LIMIT");
            //}
            ////-------------------------------------------
            //// SYSTEM
            ////-------------------------------------------
            //ProjectName = SystemFile.GetSData("SYSTEM", "LAST_PROJECT");
            //Main.Common.Limit_X = SystemFile.GetIData("UVW", "LIMIT_X");
            //Main.Common.Limit_Y = SystemFile.GetIData("UVW", "LIMIT_Y");
            //Main.Common.Limit_T = SystemFile.GetIData("UVW", "LIMIT_T");

            //Main.Common.Limit_Angle = SystemFile.GetFData("LIMIT", "LIMIT_ANGLE");

            //Main.machine.m_nScanCount = SystemFile.GetIData("SYSTEM", "SCAN_COUNT");
            //Main.machine.m_nTabCount = SystemFile.GetIData("SYSTEM", "TAB_COUNT");

            //Model_Initial();
            //Recipe_Initial();
            //Motion_Initial();
            //ReadMotionData();

            ProjectInfo = ModelFile.GetSData("PROJECT", "NAME");

            Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, 0);

            for (int i = 0; i < DEFINE.AlignUnit_Max; i++)
            {
                //         AlignUnit[i].ALIGN_UNIT_ADDR = SystemFile.GetIData(AlignUnit[i].m_AlignName, "ALIGN_UNIT_ADDR");
                // parameter
                AlignUnit[i].m_Cal_MOVE_X = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAL_MOVE_X");
                AlignUnit[i].m_Cal_MOVE_Y = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAL_MOVE_Y");
                AlignUnit[i].m_Cal_MOVE_T1 = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAL_MOVE_T1");
                AlignUnit[i].m_Cal_MOVE_T2 = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAL_MOVE_T2");
                AlignUnit[i].m_StandardMark_T = SystemFile.GetFData(AlignUnit[i].m_AlignName, "STANDARD_MARK_T");
                //  Motor AXIS DIR
                //                AlignUnit[i].m_DirX = 1;//SystemFile.GetIData(AlignUnit[i].m_AlignName, "DIR_X");
                AlignUnit[i].m_CamOffsetX = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAM_OFFSET_X");
                AlignUnit[i].m_CamOffsetY = SystemFile.GetIData(AlignUnit[i].m_AlignName, "CAM_OFFSET_Y");

                AlignUnit[i].m_GD_ImageSave_Use = SystemFile.GetBData(AlignUnit[i].m_AlignName, "GD_IMAGE");
                AlignUnit[i].m_NG_ImageSave_Use = SystemFile.GetBData(AlignUnit[i].m_AlignName, "NG_IMAGE");

                //                 AlignUnit[i].m_LengthCheck_Use = SystemFile.GetBData(AlignUnit[i].m_AlignName, "LENGTH_CHECK_USE");
                //                 AlignUnit[i].m_OBJ_Standard_Length = SystemFile.GetFData(AlignUnit[i].m_AlignName, "STANDARDMARK_LENGTH_OBJ");
                //                 AlignUnit[i].m_TAR_Standard_Length = SystemFile.GetFData(AlignUnit[i].m_AlignName, "STANDARDMARK_LENGTH_TAR");

                // Motion
                AlignUnit[i].m_MotionParams.AxisID = SystemFile.GetIData(AlignUnit[i].m_AlignName, "AXIS_ID");
                AlignUnit[i].m_MotionParams.StartPosition = SystemFile.GetFData(AlignUnit[i].m_AlignName, "START_POS");
                AlignUnit[i].m_MotionParams.EndPosition = SystemFile.GetFData(AlignUnit[i].m_AlignName, "END_POS");
                AlignUnit[i].m_MotionParams.Velocity = SystemFile.GetFData(AlignUnit[i].m_AlignName, "VELOCITY");
                AlignUnit[i].m_MotionParams.Acceleration = SystemFile.GetFData(AlignUnit[i].m_AlignName, "ACCEL");
                AlignUnit[i].m_MotionParams.Deceleration = SystemFile.GetFData(AlignUnit[i].m_AlignName, "DECEL");
                AlignUnit[i].m_MotionParams.TimeoutCondition = SystemFile.GetIData(AlignUnit[i].m_AlignName, "TIMEOUTCOND");
                AlignUnit[i].m_MotionParams.PositiveLimit = SystemFile.GetFData(AlignUnit[i].m_AlignName, "POS_LIMIT");
                AlignUnit[i].m_MotionParams.NegativeLimit = SystemFile.GetFData(AlignUnit[i].m_AlignName, "NEG_LIMIT");
                AlignUnit[i].m_MotionParams.AccelerationLimit = SystemFile.GetFData(AlignUnit[i].m_AlignName, "ACCEL_LIMIT");
                AlignUnit[i].m_MotionParams.DecelerationLimit = SystemFile.GetFData(AlignUnit[i].m_AlignName, "DECEL_LIMIT");
                AlignUnit[i].m_MotionParams.Jerk = SystemFile.GetFData(AlignUnit[i].m_AlignName, "JERK");

                // for (int j = 0; j < AlignUnit[i].m_AlignPatTagMax; j++)
                for (int j = AlignUnit[i].m_AlignPatTagMax - 1; j >= 0; j--)
                {
//                     AlignUnit[i].m_CenterX[j] = SystemFile.GetFData(AlignUnit[i].m_AlignName, "CENTER_X_" + j.ToString());
//                     AlignUnit[i].m_CenterY[j] = SystemFile.GetFData(AlignUnit[i].m_AlignName, "CENTER_Y_" + j.ToString());
                    AlignUnit[i].m_CenterX[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CENTER_X_" + j.ToString());
                    AlignUnit[i].m_CenterY[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CENTER_Y_" + j.ToString());

                    AlignUnit[i].m_CalMotoPosX[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CALMOTOR_X_" + j.ToString());
                    AlignUnit[i].m_CalMotoPosY[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CALMOTOR_Y_" + j.ToString());

                    AlignUnit[i].m_CalDisplayCX[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CALDISPLAY_X_" + j.ToString());
                    AlignUnit[i].m_CalDisplayCY[j] = ModelFile.GetFData(AlignUnit[i].m_AlignName, "CALDISPLAY_Y_" + j.ToString());
                    AlignUnit[i].Load(j);
                }

                // Vision Setting
                Main.machine.CameraDistanceX = SystemFile.GetFData("VISION_SETTING", "CAMERA_DISTANCE_X");
                Main.machine.CameraDistanceY = SystemFile.GetFData("VISION_SETTING", "CAMERA_DISTANCE_Y");

                Main.machine.LineScanAxis = (eAxis)Enum.Parse(typeof(eAxis), SystemFile.GetSData("LINESCAN_AXIS", "LINESCAN_AXIS"));

                // PreAlign Tolerance
                Main.machine.PreAlignReferenceX = SystemFile.GetFData("TOLERANCE", "PREALIGN_REFERENCE_X");
                Main.machine.PreAlignReferenceY = SystemFile.GetFData("TOLERANCE", "PREALIGN_REFERENCE_Y");
                Main.machine.PreAlignReferenceT = SystemFile.GetFData("TOLERANCE", "PREALIGN_REFERENCE_T");
                Main.machine.PreAlignToleranceX = SystemFile.GetFData("TOLERANCE", "PREALIGN_TOLERANCE_X");
                Main.machine.PreAlignToleranceY = SystemFile.GetFData("TOLERANCE", "PREALIGN_TOLERANCE_Y");
                Main.machine.PreAlignToleranceT = SystemFile.GetFData("TOLERANCE", "PREALIGN_TOLERANCE_T");

                // Inspection Option
                Main.machine.UseBlob = SystemFile.GetBData("INSPECTION_OPTION", "UseBlob");
                Main.machine.UseMeasure = SystemFile.GetBData("INSPECTION_OPTION", "UseMeasure");
                Main.machine.UseMeasureLine = SystemFile.GetBData("INSPECTION_OPTION", "UseMeasureLine");
                Main.machine.UseMeasureCircle = SystemFile.GetBData("INSPECTION_OPTION", "UseMeasureCircle");
                Main.machine.UseAkkon = SystemFile.GetBData("INSPECTION_OPTION", "UseAkkon");
                Main.machine.UseBead = SystemFile.GetBData("INSPECTION_OPTION", "UseBead");
                Main.machine.UseMarkWhenAlign = SystemFile.GetBData("INSPECTION_OPTION", "UseMarkWhenAlign");

                // ATT Option
                Main.machine.IsDrawCenter = SystemFile.GetBData("ATT_OPTION", "DRAW_CENTER");
                Main.machine.IsDrawContour = SystemFile.GetBData("ATT_OPTION", "DRAW_CONTUR");
                Main.machine.IsDrawlength = SystemFile.GetBData("ATT_OPTION", "DRAW_LENGTH");
                Main.machine.IsRMSAkkonParameterSet = SystemFile.GetBData("ATT_OPTION", "RMS_AAKKON_PARAMETER");

                // Auto Run Option
                Main.machine.IsForcePrealign = SystemFile.GetBData("ATT_OPTION", "FORCE_PREALIGN");
                Main.machine.IsForceAlign = SystemFile.GetBData("ATT_OPTION", "FORCE_ALIGN");
                Main.machine.IsForceAkkon = SystemFile.GetBData("ATT_OPTION", "FORCE_AKKON");

                // Alarm Setting
                //Main.machine.m_nCheckPanelCapacity = SystemFile.GetIData("ATT_OPTION", "CHECK_PANEL_CAPACITY");
                //Main.machine.m_nNGCount = SystemFile.GetIData("ATT_OPTION", "NG_COUNG");

                // Save Image
                Main.machine.IsSaveOKImage = SystemFile.GetBData("VISION_OPTION", "SAVE_OK_IMAGE");
                if (SystemFile.GetSData("VISION_OPTION", "SAVE_OK_IMAGE_EXTENSION") == "")
                   Main.machine.SaveOKImageExtension = eImageExtension.Bmp;
                else
                    Main.machine.SaveOKImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), SystemFile.GetSData("VISION_OPTION", "SAVE_OK_IMAGE_EXTENSION"));

                Main.machine.IsSaveNGImage = SystemFile.GetBData("VISION_OPTION", "SAVE_NG_IMAGE");
                if (SystemFile.GetSData("VISION_OPTION", "SAVE_NG_IMAGE_EXTENSION") == "")
                   Main.machine.SaveNGImageExtension = eImageExtension.Bmp;
                else
                    Main.machine.SaveNGImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), SystemFile.GetSData("VISION_OPTION", "SAVE_NG_IMAGE_EXTENSION"));

                // Data Store
                Main.machine.ImageSaveDuration = SystemFile.GetIData("DATA_STORE", "IMAGE_SAVE_DURATION");
                Main.machine.ImageSaveCapacity = SystemFile.GetIData("DATA_STORE", "IMAGE_SAVE_CAPACITY");
                Main.machine.LogSavePeriod = SystemFile.GetIData("DATA_STORE", "LOG_SAVE_PERIOD");

                // Motion
                Main.machine.MotionIPAddress = SystemFile.GetSData("MOTION", "IP_ADDRESS");
                Main.machine.MotionPort = SystemFile.GetIData("MOTION", "PORT_NUMBER");

                // PLC
                Main.machine.PLCIPAddress = SystemFile.GetSData("PLC", "IP_ADDRESS");
                Main.machine.PLCPort = SystemFile.GetIData("PLC", "PORT_NUMBER");

                // Auto Focus
                Main.machine.AutoFocusCOMPort = SystemFile.GetSData("AUTOFOCUS", "COMPORT");
                Main.machine.AutoFocusBaudRate = SystemFile.GetIData("AUTOFOCUS", "BAUD_RATE");

                // Light
                Main.machine.LightCOMPort = SystemFile.GetSData("LIGHT", "COMPORT");
                Main.machine.LightBaudRate = SystemFile.GetIData("LIGHT", "BAUD_RATE");

                //Align Tolerance & Standard Data
                AlignUnit[i].m_AlignTolX = ModelFile.GetFData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_X");
                AlignUnit[i].m_AlignTolY = ModelFile.GetFData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_Y");
                AlignUnit[i].m_AlignTolCX = ModelFile.GetFData(AlignUnit[i].m_AlignName, "ALIGN_TOLERANCE_CX");
                AlignUnit[i].m_AlignStandardY = ModelFile.GetFData(AlignUnit[i].m_AlignName, "ALIGN_STANDARD_Y");

                //AlignUnit[i].m_TabCount = Main.TabCnt;
                for (int j = 0; j < Main.recipe.m_nTabCount; j++)
                {
                    AlignUnit[i].Load_ATT(0, j); //2022 1014 YSH 
                    AlignUnit[i].LoadMark(0, j);
                    AlignUnit[i].LoadAlign(0, j);
                }

                Main.ProgerssBar_Unit(Main.formProgressBar, DEFINE.AlignUnit_Max, true, i + 1);
            }
        }

        public static void RecipeDataSave()
        {
#if CGMS
            RecipeFile.SetData("RECIPE", "MARK_TO_PATTERN_X_DISTANCE", Main.recipe.m_MarkToPatternXDistance);
            RecipeFile.SetData("RECIPE", "MARK_TO_PATTERN_Y_DISTANCE", Main.recipe.m_MarkToPatternYDistance);
            RecipeFile.SetData("RECIPE", "PATTERN_TO_PATTERN_X_DISTANCE", Main.recipe.m_PatternToPatternXDistance);
            RecipeFile.SetData("RECIPE", "PATTERN_TO_PATTERN_Y_DISTANCE", Main.recipe.m_PatternToPatternYDistance);

            RecipeFile.SetData("RECIPE", "SCAN_COUNT", Main.recipe.m_nScanCount);
            RecipeFile.SetData("RECIPE", "TAB_COUNT", Main.recipe.m_nTabCount);
            RecipeFile.SetData("RECIPE", "PATTERN_Y_SIZE", Main.recipe.m_PatternYSize);
#endif
#if ATT
            RecipeFile.SetData("RECIPE", "PANEL_SIZE_X", Main.recipe.m_dPanelSizeX);
            RecipeFile.SetData("RECIPE", "MARK_TO_MARK_DISTANCE", Main.recipe.m_dMarkToMarkDistance);
            RecipeFile.SetData("RECIPE", "TAB_WIDTH", Main.recipe.m_dTabWidth);
            RecipeFile.SetData("RECIPE", "PANEL_TO_TAB_DISTANCE", Main.recipe.m_dPanelToTabDistance);
            RecipeFile.SetData("RECIPE", "TAB_COUNT", Main.recipe.m_nTabCount);

            RecipeFile.SetData("RECIPE", "TAB_DISTANCE_1", Main.recipe.m_dTabDistance1);
            RecipeFile.SetData("RECIPE", "TAB_DISTANCE_2", Main.recipe.m_dTabDistance2);
            RecipeFile.SetData("RECIPE", "TAB_DISTANCE_3", Main.recipe.m_dTabDistance3);
            RecipeFile.SetData("RECIPE", "TAB_DISTANCE_4", Main.recipe.m_dTabDistance4);
            RecipeFile.SetData("RECIPE", "TAB_DISTANCE_5", Main.recipe.m_dTabDistance5);
#endif
        }

        public static void RecipeDataLoad()
        {
#if CGMS
            Main.recipe.m_nScanCount =  RecipeFile.GetIData("RECIPE", "SCAN_COUNT");
            Main.recipe.m_nTabCount = RecipeFile.GetIData("RECIPE", "TAB_COUNT");
            Main.recipe.m_PatternYSize = RecipeFile.GetFData("RECIPE", "PATTERN_Y_SIZE");
            Main.recipe.m_MarkToPatternXDistance = RecipeFile.GetFData("RECIPE", "MARK_TO_PATTERN_X_DISTANCE");
            Main.recipe.m_MarkToPatternYDistance = RecipeFile.GetFData("RECIPE", "MARK_TO_PATTERN_Y_DISTANCE");
            Main.recipe.m_PatternToPatternXDistance = RecipeFile.GetFData("RECIPE", "PATTERN_TO_PATTERN_X_DISTANCE");
            Main.recipe.m_PatternToPatternYDistance = RecipeFile.GetFData("RECIPE", "PATTERN_TO_PATTERN_Y_DISTANCE");
#endif
#if ATT
            Main.recipe.m_dPanelSizeX = RecipeFile.GetFData("RECIPE", "PANEL_SIZE_X");
            Main.recipe.m_dMarkToMarkDistance = RecipeFile.GetFData("RECIPE", "MARK_TO_MARK_DISTANCE");
            Main.recipe.m_dTabWidth = RecipeFile.GetFData("RECIPE", "TAB_WIDTH");
            Main.recipe.m_dPanelToTabDistance = RecipeFile.GetFData("RECIPE", "PANEL_TO_TAB_DISTANCE");
            Main.recipe.m_nTabCount = RecipeFile.GetIData("RECIPE", "TAB_COUNT");

            Main.recipe.m_dTabDistance1 = RecipeFile.GetFData("RECIPE", "TAB_DISTANCE_1");
            Main.recipe.m_dTabDistance2 = RecipeFile.GetFData("RECIPE", "TAB_DISTANCE_2");
            Main.recipe.m_dTabDistance3 = RecipeFile.GetFData("RECIPE", "TAB_DISTANCE_3");
            Main.recipe.m_dTabDistance4 = RecipeFile.GetFData("RECIPE", "TAB_DISTANCE_4");
            Main.recipe.m_dTabDistance5 = RecipeFile.GetFData("RECIPE", "TAB_DISTANCE_5");
#endif
        }

        public static void MachineDataLoad()
        {
            //-------------------------------------------
            // OPTION
            //-------------------------------------------
            machine.Overlay_Image_Onf = SystemFile.GetBData("OPTION", "OVELAY_IMAGE_SAVE");
            machine.LogMsg_Onf = SystemFile.GetBData("OPTION", "GAP_LOG_MSG");
            machine.Inspection_Onf = SystemFile.GetBData("OPTION", "INSPECTION");
            machine.LengthCheck_Onf = SystemFile.GetBData("OPTION", "L_CHECK");
            machine.BMP_ImageSave_Onf = SystemFile.GetBData("OPTION", "BMP");
            machine.m_nOldLogCheckPeriod = SystemFile.GetIData("OPTION", "OLD_LOG_PERIOD");
            machine.m_nOldLogCheckSpace = SystemFile.GetIData("OPTION", "OLD_LOG_SPACE");
            machine.m_nCCLinkCommDelay_ms = SystemFile.GetIData("OPTION", "CCLINK_COMM_DELAY");
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                machine.m_bUseLoadingLimit = SystemFile.GetBData("OPTION", "USE_LOADING_LIMIT");
                machine.m_nLoadingLimitX_um = SystemFile.GetIData("OPTION", "LOADING_LIMIT_X");
                machine.m_nLoadingLimitY_um = SystemFile.GetIData("OPTION", "LOADING_LIMIT_Y");
                machine.m_nInspLowLimit_um = SystemFile.GetIData("OPTION", "INSP_LIMIT_LOW");
                machine.m_nInspHighLimit_um = SystemFile.GetIData("OPTION", "INSP_LIMIT_HIGH");
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                machine.m_bUseAlign1AngleLimit = SystemFile.GetBData("OPTION", "USE_ALIGN1_ANGLE_LIMIT");
                machine.m_f1stAlignCornerAngleLimit = (float)SystemFile.GetFData("OPTION", "ALIGN1_CORNER_LIMIT");
                machine.m_f1stAlignVerticalAngleLimit = (float)SystemFile.GetFData("OPTION", "ALIGN1_VERTICAL_LIMIT");
            }
            //-------------------------------------------
            // SYSTEM
            //-------------------------------------------
            ProjectName = SystemFile.GetSData("SYSTEM", "LAST_PROJECT");
            Main.Common.Limit_X = SystemFile.GetIData("UVW", "LIMIT_X");
            Main.Common.Limit_Y = SystemFile.GetIData("UVW", "LIMIT_Y");
            Main.Common.Limit_T = SystemFile.GetIData("UVW", "LIMIT_T");

            Main.Common.Limit_Angle = SystemFile.GetFData("LIMIT", "LIMIT_ANGLE");

            Model_Initial();
            Recipe_Initial();
            ReadMotionData();
        }

        public static void MotionSave()
        {
            for (int i = 0; i < (int)Main.DefaultMotionData.MAX_DIRECTION_COUNT; i++)
            {
                for (int j = 0; j < (int)Main.DefaultMotionData.MAX_POSITION_COUNT; j++)
                {
                    for (int k = 0; k < (int)Main.DefaultMotionData.MAX_AXIS_COUNT; k++)
                    {
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "JOG_SPEED", Main.m_sPositionData[i, j, k].JogSpeed);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "VELOCITY", Main.m_sPositionData[i, j, k].Velocity);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "MOVE_LIMIT_TIME", Main.m_sPositionData[i, j, k].MoveLimitTime);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "ACCELERATION", Main.m_sPositionData[i, j, k].Acceleration);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "DECELERATION", Main.m_sPositionData[i, j, k].Deceleration);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "MOVE_TO_TOLERANCE", Main.m_sPositionData[i, j, k].MoveTolerance);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "LIMIT_POSITIVE", Main.m_sPositionData[i, j, k].LimitPositive);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "LIMIT_NEGATIVE", Main.m_sPositionData[i, j, k].LimitNegative);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "AFTER_WAIT_TIME", Main.m_sPositionData[i, j, k].AfterWaitTime);
                        MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "HOMING_LIMIT_TIME", Main.m_sPositionData[i, j, k].HomingLimitTime);
                        //MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "AF_OFFSET_VALUE", Main.m_sPositionData[i, j, k].AFOffsetValue);
                        //MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION", Main.m_sPositionData[i, j, k].TargetPosition);
                        //MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_OFFSET", Main.m_sPositionData[i, j, k].TargetPositionOffset);
                        //MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_START_OFFSET", Main.m_sPositionData[i, j, k].TargetPositionStartOffset);
                        //MotionFile.SetData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_END_OFFSET", Main.m_sPositionData[i, j, k].TargetPositionEndOffset);
                    }
                }
            }
        }
        public static void MotionLoad()
        {
            machine.Overlay_Image_Onf = SystemFile.GetBData("OPTION", "OVELAY_IMAGE_SAVE");
            for (int i = 0; i < (int)Main.DefaultMotionData.MAX_DIRECTION_COUNT; i++)
            {
                for (int j = 0; j < (int)Main.DefaultMotionData.MAX_POSITION_COUNT; j++)
                {
                    for (int k = 0; k < (int)Main.DefaultMotionData.MAX_AXIS_COUNT; k++)
                    {
                        Main.m_sPositionData[i, j, k].JogSpeed = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "JOG_SPEED");
                        Main.m_sPositionData[i, j, k].Velocity = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "VELOCITY");
                        Main.m_sPositionData[i, j, k].MoveLimitTime = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "MOVE_LIMIT_TIME");
                        Main.m_sPositionData[i, j, k].Acceleration = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "ACCELERATION");
                        Main.m_sPositionData[i, j, k].Deceleration = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "DECELERATION");
                        Main.m_sPositionData[i, j, k].MoveTolerance = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "MOVE_TO_TOLERANCE");
                        Main.m_sPositionData[i, j, k].LimitPositive = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "LIMIT_POSITIVE");
                        Main.m_sPositionData[i, j, k].LimitNegative = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "LIMIT_NEGATIVE");
                        Main.m_sPositionData[i, j, k].AfterWaitTime = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "AFTER_WAIT_TIME");
                        Main.m_sPositionData[i, j, k].HomingLimitTime = MotionFile.GetFData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "HOMING_LIMIT_TIME");
                        //Main.m_sPositionData[i, j, k].AFOffsetValue = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "AF_OFFSET_VALUE");
                        //Main.m_sPositionData[i, j, k].TargetPosition = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION");
                        //Main.m_sPositionData[i, j, k].TargetPositionStartOffset = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_START_OFFSET");
                        //Main.m_sPositionData[i, j, k].TargetPositionOffset = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_OFFSET");
                        //Main.m_sPositionData[i, j, k].TargetPositionEndOffset = MotionFile.GetIData("Motion_" + (i + 1).ToString() + "_" + (j + 1).ToString() + "_" + (k + 1).ToString(), "TARGET_POSITION_END_OFFSET");
                    }
                }
            }
        }

        public static List<TeachingPosition> TeachingPositionList = new List<TeachingPosition>();
        public static void CreateTeachingParameter()
        {
            for (int i = 0; i < Enum.GetValues(typeof(eTeachingPosition)).Length; i++)
                TeachingPositionList.Add(new TeachingPosition());
        }

        public static void ReadPatternParameter(int camNo, int stageNo, int markIndex)
        {
            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\";
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Mark_", camNo, stageNo);
            filePath += fileName;

            PatternMatchParameter[,] patternArray = new PatternMatchParameter[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];

            for (int targetIndex = 0; targetIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetIndex++)
            {
                for (int positionIndex = 0; positionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; positionIndex++)
                {
                    patternArray[targetIndex, positionIndex] = new PatternMatchParameter();
                    patternArray[targetIndex, positionIndex].LoadVPP(filePath, targetIndex, positionIndex, markIndex);
                    patternArray[targetIndex, positionIndex].LoadXml(filePath);
                }
            }

           Main.AlignUnit[camNo].InspectionParams[stageNo].PatternList.Add(patternArray);
        }

        public static void ReadBlobParameter(int camNo, int stageNo, int MeasureIndex)
        {
            Main.AlignUnit[camNo].InspectionParams[stageNo].BlobItem = new BlobParameter();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName +"\\BLOB\\";
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Blob_", camNo, stageNo);
            filePath += fileName;

            Main.AlignUnit[camNo].InspectionParams[stageNo].BlobItem.LoadVPP(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].BlobItem.LoadXml(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].BlobParams.Add( Main.AlignUnit[camNo].InspectionParams[stageNo].BlobItem);
        }
		
        public static void ReadCaliperParamerter(int camNo, int stageNo, int MeasureIndex)
        {
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureLineItem = new MeasureLineParameter();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MEASURE\\Caliper\\";
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Caliper_", camNo, stageNo);
            filePath += fileName;

            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureLineItem.LoadVPP(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureLineParamList.Add(Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureLineItem);
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureLineItem.LoadXml(filePath, MeasureIndex);
        }

        public static void ReadFindCircleParamerter(int camNo, int stageNo, int MeasureIndex)
        {
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureCircleItem = new MeasureCircleParameter();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MEASURE\\Circle\\";
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Circle_", camNo, stageNo);
            filePath += fileName;

            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureCircleItem.LoadVPP(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureCircleItem.LoadXml(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureCircleParamList.Add(Main.AlignUnit[camNo].InspectionParams[stageNo].MeasureCircleItem);
        }

        public static void ReadBeadParameter(int camNo, int stageNo, int MeasureIndex)
        {
            Main.AlignUnit[camNo].InspectionParams[stageNo].ShortItem = new ShortParameter();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\Bead\\";
            string fileName = string.Format("Cam{0:D}_Stage{1:D}_Bead", camNo, stageNo);
            filePath += fileName;

            Main.AlignUnit[camNo].InspectionParams[stageNo].ShortItem.LoadVPP(filePath, MeasureIndex);
            Main.AlignUnit[camNo].InspectionParams[stageNo].ShortParamList.Add(Main.AlignUnit[camNo].InspectionParams[stageNo].ShortItem);
        }

        public static void ReadTeachingParameter()
        {
            TeachingPosition.Instance().LoadXml("tt");
        }

        public static void SaveTeachingParameter()
        {
            TeachingPosition.Instance().SaveXml("tt");
        }

        public static void SaveOldLogCheckFile()
        {
            OldLogCheckFile.SetData("SYSTEM", "LAST_CHECK", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static bool FileCopy(string strOriginFile, string strCopyFile)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(strOriginFile);
            long iSize = 0;
            long iTotalSize = fi.Length; //1024 버퍼 사이즈 임의로...
            byte[] bBuf = new byte[104857600]; //동일 파일이 존재하면 삭제 하고 다시하기 위해... 

            if (File.Exists(strCopyFile))
                File.Delete(strCopyFile);

            FileStream fsIn = new FileStream(strOriginFile, FileMode.Open, FileAccess.Read, FileShare.Read); //대상 파일 만들기...
            FileStream fsOut = new FileStream(strCopyFile, FileMode.Create, FileAccess.Write);
            while (iSize < iTotalSize)
            {
                try
                {
                    int iLen = fsIn.Read(bBuf, 0, bBuf.Length); iSize += iLen; fsOut.Write(bBuf, 0, iLen);
                }
                catch (Exception ex)
                { //파일 연결 해제...
                    Console.WriteLine(ex.ToString());
                    fsOut.Flush();
                    fsOut.Close();
                    fsIn.Close(); //에러시 삭제... 
                    if (File.Exists(strCopyFile))
                        File.Delete(strCopyFile);
                }
                return false;
            }
            //파일 연결 해제... 
            fsOut.Flush();
            fsOut.Close();
            fsIn.Close();
            return true;

        }

        public static bool FolderCopy(string strOriginFolder, string strCopyFolder)
        {
            //폴더가 없으면 만듬...
            if (!System.IO.Directory.Exists(strCopyFolder))
            {
                System.IO.Directory.CreateDirectory(strCopyFolder);
            }
            //파일 목록 불러오기...
            string[] files = System.IO.Directory.GetFiles(strOriginFolder);
            //폴더 목록 불러오기... 
            string[] folders = System.IO.Directory.GetDirectories(strOriginFolder);

            Main.ProgerssBar_Unit(Main.formProgressBar, files.Length, true, 0);
            int i = 0;
            foreach (string file in files)
            {
                string name = System.IO.Path.GetFileName(file);
                string dest = System.IO.Path.Combine(strCopyFolder, name);

                FileCopy(file, dest);
                Main.ProgerssBar_Unit(Main.formProgressBar, files.Length, true, i++ + 1);
            }
            // foreach 안에서 재귀 함수를 통해서 폴더 복사 및 파일 복사 진행 완료  
            foreach (string folder in folders)
            {
                string name = System.IO.Path.GetFileName(folder);
                string dest = System.IO.Path.Combine(strCopyFolder, name);

                FolderCopy(folder, dest);
            }

            return true;
        }

        public partial class AlignUnitTag
        {
            public void Save(int m_PatTagNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], true, 0, "Saving");
                //220930 YSH Test
                //for (int i = 0; i < m_AlignPatMax[m_PatTagNo]; i++)
                //{
                //    PAT[StageNo, TabNo].Save();
                //    Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], true, i + 1, "Saving");
                //}
                Model_Initial();
                ModelFile.SetData(m_AlignName, "CENTER_X_" + m_PatTagNo.ToString(), m_CenterX[m_PatTagNo]);
                ModelFile.SetData(m_AlignName, "CENTER_Y_" + m_PatTagNo.ToString(), m_CenterY[m_PatTagNo]);

                ModelFile.SetData(m_AlignName, "CALMOTOR_X_" + m_PatTagNo.ToString(), m_CalMotoPosX[m_PatTagNo]);
                ModelFile.SetData(m_AlignName, "CALMOTOR_Y_" + m_PatTagNo.ToString(), m_CalMotoPosY[m_PatTagNo]);

                ModelFile.SetData(m_AlignName, "CALDISPLAY_X_" + m_PatTagNo.ToString(), m_CalDisplayCX[m_PatTagNo]);
                ModelFile.SetData(m_AlignName, "CALDISPLAY_Y_" + m_PatTagNo.ToString(), m_CalDisplayCY[m_PatTagNo]);

                //--------------------------------------------------------------------------------------------------
                ModelFile.SetData("OPTION", "MAP_FUNCTION", machine.MAP_Function_Onf);
                ModelFile.SetData("OPTION", "MAP_FUNCTION_DATA", machine.MAP_Function_Data);

                ModelFile.SetData("OPTION", "MAP_Limit", machine.MAP_Limit_Onf);
                ModelFile.SetData("OPTION", "MAP_HIGH", machine.MAP_High);
                ModelFile.SetData("OPTION", "MAP_LOW", machine.MAP_Low);

                /*
                ModelFile.SetData("OPTION", "PICKER1_DIS_X", machine.m_Fpcpicker1_Dis_X);
                ModelFile.SetData("OPTION", "PICKER1_DIS_Y", machine.m_Fpcpicker1_Dis_Y);
                ModelFile.SetData("OPTION", "PICKER2_DIS_X", machine.m_Fpcpicker2_Dis_X);
                ModelFile.SetData("OPTION", "PICKER2_DIS_Y", machine.m_Fpcpicker2_Dis_Y);
                */
                //PARAMETER
                ModelFile.SetData(m_AlignName, "STANDARD_X", m_Standard[Main.DEFINE.X]);
                ModelFile.SetData(m_AlignName, "STANDARD_Y", m_Standard[Main.DEFINE.Y]);
                ModelFile.SetData(m_AlignName, "STANDARD_T", m_Standard[Main.DEFINE.T]);
                ModelFile.SetData(m_AlignName, "REPEATE", m_RepeatLimit);
                ModelFile.SetData(m_AlignName, "LENGTH_CHECK_USE", m_LengthCheck_Use);
                ModelFile.SetData(m_AlignName, "STANDARDMARK_LENGTH_OBJ", m_OBJ_Standard_Length);
                ModelFile.SetData(m_AlignName, "STANDARDMARK_LENGTH_TAR", m_TAR_Standard_Length);
                ModelFile.SetData(m_AlignName, "LENGTH_TOL", m_Length_Tolerance);
                ModelFile.SetData(m_AlignName, "TRAY_POCKET_X", m_Tray_Pocket_X);
                ModelFile.SetData(m_AlignName, "TRAY_POCKET_Y", m_Tray_Pocket_Y);
                ModelFile.SetData(m_AlignName, "TRAY_BLOB_MODE", TrayBlobMode);

                ModelFile.SetData(m_AlignName, "ALIGN_DELAY", m_AlignDelay);
                ModelFile.SetData(m_AlignName, "BLOB_NG_VIEW", m_Blob_NG_View_Use);

#region ATT Inspection Parameter
                //--------------------------------------------------------------------------------------------------

                //압흔 파라메터 - YSH
                //추후 인덱스 재조정 필요, 임의 0번 인덱스 사용
                //추후 함수 분리 예정
                //Judge부분 보류

                ////ModelFile.SetData(m_AlignName, "JudgeCount", );
                ////ModelFile.SetData(m_AlignName, "JudgeLength", );
                ////ModelFile.SetData(m_AlignName, "JudgeGrayScale", );
                ////ModelFile.SetData(m_AlignName, "JudgeDistribution", );
                ////ModelFile.SetData(m_AlignName, "SliceWidth", );
                ////ModelFile.SetData(m_AlignName, "SliceHeight", );

                //ModelFile.SetData(m_AlignName, "SliceOverlap", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspOption.s_nOverlap);
                //ModelFile.SetData(m_AlignName, "Akkon Filter Type", (int)Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_eFilterType);
                //ModelFile.SetData(m_AlignName, "Akkon Filter Direction", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nFilterDir);
                //ModelFile.SetData(m_AlignName, "Akkon Threshold Mode", (int)Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_eThMode);
                //ModelFile.SetData(m_AlignName, "Akkon Thres Weight", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fThWeight);
                //ModelFile.SetData(m_AlignName, "Shadow Detection Offset", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nShadowOffset);
                //ModelFile.SetData(m_AlignName, "Akkon Shadow Direction", (int)Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_eShadowDir);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Threshold", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fStrengthThreshold);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Base", (int)Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_eStrengthBase);
                //ModelFile.SetData(m_AlignName, "Akkon Peak Property", (int)Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_ePeakProp);
                //ModelFile.SetData(m_AlignName, "Akkon Threshold Peak", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nThPeak);
                //ModelFile.SetData(m_AlignName, "Akkon Extra Lead", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nExtraLead);
                //ModelFile.SetData(m_AlignName, "Akkon Min Shadow Width", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nMinShadowWidth);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Scale Factor", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fStrengthScaleFactor);
                //ModelFile.SetData(m_AlignName, "Akkon Inflate Lead Size", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nInflateLeadSize);
                //ModelFile.SetData(m_AlignName, "Akkon Position Tolerance", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fPosTolerance);
                ////ModelFile.SetData(m_AlignName, "Akkon Strength Boost Offset", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].);
                ////ModelFile.SetData(m_AlignName, "Akkon Strength Boost Weight", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].);



                //ModelFile.SetData(m_AlignName, "Akkon Strength Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fMinStrength);
                //ModelFile.SetData(m_AlignName, "Akkon Min Heigtht Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nMinHeight);
                //ModelFile.SetData(m_AlignName, "Akkon Min Width Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nMinWidth);
                //ModelFile.SetData(m_AlignName, "Akkon Min Size Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fMinSize);
                //ModelFile.SetData(m_AlignName, "Akkon Max Size Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fMaxSize);
                //ModelFile.SetData(m_AlignName, "Akkon Grouping Distance Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fGroupingDistance);
                //ModelFile.SetData(m_AlignName, "Akkon Min Boundary Overlap", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nMinBoundaryOverlap);
                //ModelFile.SetData(m_AlignName, "Akkon Use Edge False Alarm Filter", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_bUseEdgeFARemove);
                //ModelFile.SetData(m_AlignName, "Akkon FAR WH Ratio", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fWHRatio);
                //ModelFile.SetData(m_AlignName, "Akkon FAR Edge Range", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nEdgeRange);
                //ModelFile.SetData(m_AlignName, "Akkon FAR Strength Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fEdgeStrengthCut);
                //ModelFile.SetData(m_AlignName, "Akkon FAR Size Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fEdgeSizeCut);
                //ModelFile.SetData(m_AlignName, "Akkon BW Peak Ratiot", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fBWRatio);
                //ModelFile.SetData(m_AlignName, "Akkon ROI Division Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nROIDiv);
                //ModelFile.SetData(m_AlignName, "Akkon In ROI Line Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nAkkonInLine);
                //ModelFile.SetData(m_AlignName, "Akkon In ROI Line Area", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fAkkonInArea);
                //ModelFile.SetData(m_AlignName, "Akkon BW Ratio Max", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fBWRatioMax);
                //ModelFile.SetData(m_AlignName, "Akkon Enh Std Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fEnhstdcut);
                //ModelFile.SetData(m_AlignName, "Akkon Shadow Peak Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nShadowPeakcut);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Up Shoot Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nRawUpShootcut);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Avg Min", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawAvgMin);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Avg Max", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawAvgMax);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Std Min", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawStdMin);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Std Max", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawStdMax);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Shadow Min", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawShadowMin);
                //ModelFile.SetData(m_AlignName, "Akkon Raw Shadow Max", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fRawShadowMax);

                ////ModelFile.SetData(m_AlignName, "Lead Total Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].);
                ////ModelFile.SetData(m_AlignName, "Lead Set Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.);
                //ModelFile.SetData(m_AlignName, "Akkon Standard Deviation Lead Judge", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fStdDevLeadJudge);
                //ModelFile.SetData(m_AlignName, "Akkon Imul Inspection", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_bImulInspection);
                //ModelFile.SetData(m_AlignName, "Akkon Target Type", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nIsFlexible); // 0 : RIGID, 1 : FLEIBLE
                //ModelFile.SetData(m_AlignName, "Akkon Inspection Type", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspOption.s_nInspType); // 0 : ThresholdMode, 1 : DLMode0, 2 : DLMode1, 3 : DLMode2
                //ModelFile.SetData(m_AlignName, "Akkon Imul Inspection Threshold", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nImulInspectionThresh);
                //ModelFile.SetData(m_AlignName, "Akkon Imul size", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_fImulSize);
                //ModelFile.SetData(m_AlignName, "Akkon Filter Width Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nWidthCut);
                //ModelFile.SetData(m_AlignName, "Akkon Filter Heigth Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nHeightCut);
                //ModelFile.SetData(m_AlignName, "Akkon Filter Raw Peak Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nRawPeakCut);
                //ModelFile.SetData(m_AlignName, "Akkon Filter WH Raw Peak Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspFilter.s_nWHRawPeakCut);
                //ModelFile.SetData(m_AlignName, "Akkon Use Absolute Threshold", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_bUseAbsTh);
                //ModelFile.SetData(m_AlignName, "Akkon Absolute Threshold High", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nAbsoluteThHi);
                //ModelFile.SetData(m_AlignName, "Akkon Absolute Threshold Low", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nAbsoluteThLow);
                //ModelFile.SetData(m_AlignName, "Akkon Panel Type", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nPanelInfo); // 0 COF, 1 COG, 2 FOG



                //ModelFile.SetData(m_AlignName, "DL Peak Prob", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fDLPeakProb);
                //ModelFile.SetData(m_AlignName, "DL Size Prob", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_fDLSizeProb);
                //ModelFile.SetData(m_AlignName, "DL Sperate Cut", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nDLSperateCut);
                //ModelFile.SetData(m_AlignName, "DL Network Type", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nDLNetWorkType);
                //ModelFile.SetData(m_AlignName, "DL Edge Flip", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_bEdgeFlip);
                //ModelFile.SetData(m_AlignName, "DL Patch Size X", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nDLPatchSizeX);
                //ModelFile.SetData(m_AlignName, "DL Patch Size Y", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspPara.s_nDLPatchSizeY);



                //ModelFile.SetData(m_AlignName, "Log Trace", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonInspOption.s_bLogTrace);

                ////Align 검사 Data
                //ModelFile.SetData(m_AlignName, "Lead Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AlignPara.m_nLeadCount);

                //string FileName;
                //// for (int i = 0; i < m_AlignPatMax[m_PatTagNo]; i++)
                //for (int i = 0; i < 1; i++)
                //{
                //    for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                //    {
                //        try
                //        {
                //            //압흔검사 Mark Data [Panel]
                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_LeftPattern[j].Pattern.Trained == true)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_LeftPattern[j].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ATT_LEFTMARK" + j.ToString() + ".vpp";
                //                //CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_LeftPattern[j], MarkFileName);

                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_LeftPattern[j], FileName,
                //                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                //            }

                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_RightPattern[j].Pattern.Trained == true)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_RightPattern[j].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ATT_RIGHTMARK" + j.ToString() + ".vpp";
                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_RightPattern[j], FileName,
                //                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);

                //            }

                //            //얼라인검사 Mark Data [FPC]
                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_LeftPattern[j].Pattern.Trained == true)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_LeftPattern[j].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ALIGN_LEFTMARK" + j.ToString() + ".vpp";
                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_LeftPattern[j], FileName,
                //                     typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                //            }

                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_RightPattern[j].Pattern.Trained == true)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_RightPattern[j].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ALIGN_RIGHTMARK" + j.ToString() + ".vpp";
                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_RightPattern[j], FileName,
                //                     typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                //            }

                //        }
                //        catch (System.Exception ex)
                //        {
                //            //   MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                //        }
                //    }
                //}


                ////얼라인검사 Caliper Data
                ////for (int i = 0; i < m_AlignPatMax[m_PatTagNo]; i++)
                //for (int i = 0; i < 1; i++)
                //{
                //    for (int j = 0; j < (int)Main.AlignTagData.DefaultParam.DEF_INSP_POS; j++)//Tab의 Left, Right
                //    {
                //        for (int k = 0; k < (int)Main.AlignTagData.DefaultParam.DEF_TARGET_POS; k++)//FPC, Panel
                //        {
                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperX[j, k] != null)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperX[j, k].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ALIGN_X_CALIPER" + j.ToString() + k.ToString() + ".vpp";

                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperX[j, k], FileName,
                //                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                //            }

                //            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperY[j, k] != null)
                //            {
                //                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperY[j, k].InputImage = null;
                //                FileName = DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ALIGN_Y_CALIPER" + j.ToString() + k.ToString() + ".vpp";

                //                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.m_AlignCaliperY[j, k], FileName,
                //                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                //            }
                //        }
                //    }
                //}

                ////ROI Data 
                ////YSH 추후 모델별 관리부분 추가 예정
                //using (StreamWriter outputFile = new StreamWriter(DEFINE.SYS_DATADIR + "MODEL_" + DEFINE.MODEL_DATADIR + "\\" + ProjectName + m_AlignName + "_ROIData.txt"))
                //{
                //    //File경로 제대로 확인
                //    for (int i = 0; i < Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI.Count; i++)
                //    {
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerOriginX);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerOriginY);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerXX);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerXY);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerOppositeX);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerOppositeY);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerYX);
                //        outputFile.Write(" ");
                //        outputFile.Write(Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_AkkonBumpROI[i].CornerYY);
                //        outputFile.Write(" ");
                //        outputFile.Write("\n");
                //    }
                //}
                ////Lead Group 부분
                //ModelFile.SetData(m_AlignName, "Lead Group Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].AkkonPara[0].m_nLeadGroupCount);
                //for (int i = 0; i < Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].LeadGroupInfo.Count(); i++)
                //{
                //    ModelFile.SetData(m_AlignName, "Lead Group" + (i + 1) + "Lead Count", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].LeadGroupInfo[i].m_LeadCount);
                //    ModelFile.SetData(m_AlignName, "Lead Group" + (i + 1) + "Lead Pitch", Main.AlignUnit[CamNo].PAT[m_PatTagNo, 0].LeadGroupInfo[i].m_LeadPitch);
                //}
                //--------------------------------------------------------------------------------------------------
#endregion

                Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], false, 0, "Saving");
            }

            public void Load(int m_PatTagNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], true, 0, "Loading");

                //              for (int i = 0; i < m_AlignPatMax; i++)

                //220930 YSH Test
                //for (int i = m_AlignPatMax[m_PatTagNo] - 1; i >= 0; i--)
                //{
                //    PAT[StageNo, TabNo].Load();
                //    if (i == DEFINE.CAM_SELECT_INSPECT)
                //    {
                //        PAT[StageNo, TabNo].m_CamOffsetX = this.m_CamOffsetX / 1000.0;   // um to mm
                //        PAT[StageNo, TabNo].m_CamOffsetY = this.m_CamOffsetY / 1000.0;
                //    }
                //    Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], true, i + 1, "Loading");

                //}
                //--------------------------------------------------------------------------------------------------
                machine.MAP_Function_Onf = ModelFile.GetBData("OPTION", "MAP_FUNCTION");
                machine.MAP_Function_Data = ModelFile.GetFData("OPTION", "MAP_FUNCTION_DATA");

                machine.MAP_Limit_Onf = ModelFile.GetBData("OPTION", "MAP_Limit");
                machine.MAP_High = ModelFile.GetIData("OPTION", "MAP_HIGH");
                machine.MAP_Low = ModelFile.GetIData("OPTION", "MAP_LOW");
                
                /*
                machine.m_Fpcpicker1_Dis_X = ModelFile.GetIData("OPTION", "PICKER1_DIS_X");
                machine.m_Fpcpicker1_Dis_Y = ModelFile.GetIData("OPTION", "PICKER1_DIS_Y");
                machine.m_Fpcpicker2_Dis_X = ModelFile.GetIData("OPTION", "PICKER2_DIS_X");
                machine.m_Fpcpicker2_Dis_Y = ModelFile.GetIData("OPTION", "PICKER2_DIS_Y");
                */
                // PARAMETER
                m_Standard[Main.DEFINE.X] = ModelFile.GetFData(m_AlignName, "STANDARD_X");
                m_Standard[Main.DEFINE.Y] = ModelFile.GetFData(m_AlignName, "STANDARD_Y");
                m_Standard[Main.DEFINE.T] = ModelFile.GetFData(m_AlignName, "STANDARD_T");
                m_RepeatLimit = ModelFile.GetIData(m_AlignName, "REPEATE");

                m_LengthCheck_Use     = ModelFile.GetBData(m_AlignName, "LENGTH_CHECK_USE");
                m_OBJ_Standard_Length = ModelFile.GetFData(m_AlignName, "STANDARDMARK_LENGTH_OBJ");
                m_TAR_Standard_Length = ModelFile.GetFData(m_AlignName, "STANDARDMARK_LENGTH_TAR");
                m_Length_Tolerance = ModelFile.GetFData(m_AlignName, "LENGTH_TOL");

                if(ModelFile.GetIData(m_AlignName, "TRAY_POCKET_X") > 0)
                    m_Tray_Pocket_X = ModelFile.GetIData(m_AlignName, "TRAY_POCKET_X");
                else 
                m_Tray_Pocket_X = 1;

                if (ModelFile.GetIData(m_AlignName, "TRAY_POCKET_Y") > 0)
                    m_Tray_Pocket_Y = ModelFile.GetIData(m_AlignName, "TRAY_POCKET_Y");
                else
                    m_Tray_Pocket_Y = 1;

                TrayBlobMode = ModelFile.GetBData(m_AlignName, "TRAY_BLOB_MODE");

                m_AlignDelay = ModelFile.GetIData(m_AlignName, "ALIGN_DELAY");
                m_Blob_NG_View_Use = ModelFile.GetBData(m_AlignName, "BLOB_NG_VIEW");

                m_CenterX[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CENTER_X_" + m_PatTagNo.ToString());
                m_CenterY[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CENTER_Y_" + m_PatTagNo.ToString());

                m_CalMotoPosX[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CALMOTOR_X_" + m_PatTagNo.ToString());
                m_CalMotoPosY[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CALMOTOR_Y_" + m_PatTagNo.ToString());

                m_CalDisplayCX[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CALDISPLAY_X_" + m_PatTagNo.ToString());
                m_CalDisplayCY[m_PatTagNo] = ModelFile.GetFData(m_AlignName, "CALDISPLAY_Y_" + m_PatTagNo.ToString());

                Main.ProgerssBar_PAT(Main.formProgressBar_1, m_AlignPatMax[m_PatTagNo], true, 0, "Loading");
            }

            public void SaveMark(int StageNo, int TabNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, true, 0, "Saving");

                string FileName;
                for (int markIndex = 0; markIndex < Main.DEFINE.SUBPATTERNMAX; markIndex++)
                {
                    try
                    {
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex] != null)
                        {
                            //압흔검사 Mark Data [Panel]
                            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].Pattern.Trained == true)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].InputImage = null;
                                FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK"; 
                                if (!Directory.Exists(FileName))
                                    Directory.CreateDirectory(FileName);
                                FileName = FileName+  "\\" + m_AlignName + "_ATT_LEFTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";
                                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex], FileName,
                                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                            }
                        }
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex] != null)
                        {
                            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].Pattern.Trained == true)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].InputImage = null;

                                FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK";
                                if (!Directory.Exists(FileName))
                                    Directory.CreateDirectory(FileName);
                                FileName = FileName+"\\" + m_AlignName + "_ATT_RIGHTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";
                                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex], FileName,
                                    typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);

                            }
                        }
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex] != null)
                        {
                            //얼라인검사 Mark Data [FPC]
                            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].Pattern.Trained == true)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].InputImage = null;
                                FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK"; 
                                if (!Directory.Exists(FileName))
                                    Directory.CreateDirectory(FileName);
                                FileName = FileName+"\\"+ m_AlignName + "_ALIGN_LEFTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";
                                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex], FileName,
                                        typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                            }
                        }
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex] != null)
                        {
                            if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].Pattern.Trained == true)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].InputImage = null;
                                FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK"; 
                                if (!Directory.Exists(FileName))
                                    Directory.CreateDirectory(FileName);
                                FileName = FileName+ "\\" + m_AlignName + "_ALIGN_RIGHTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";
                                CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex], FileName,
                                        typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        //   MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                    }
                }

                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, false, 0, "Saving");
            }

            public void SaveAlign(int StageNo, int TabNo)
            {
                string FileName;

                //얼라인검사 Caliper Data
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; j++)//Tab의 Left, Right
                {
                    for (int k = 0; k < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; k++)//FPC, Panel
                    {
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperX[j, k] != null)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperX[j, k].InputImage = null;
                            FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\ALIGN\\" + m_AlignName + "_ALIGN_X_CALIPER" + StageNo.ToString() + TabNo.ToString() + j.ToString() + k.ToString() + ".vpp";

                            CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperX[j, k], FileName,
                                typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                        }

                        if (Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperY[j, k] != null)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperY[j, k].InputImage = null;
                            FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\ALIGN\\" + m_AlignName + "_ALIGN_Y_CALIPER" + StageNo.ToString() + TabNo.ToString() + j.ToString() + k.ToString() + ".vpp";

                            CogSerializer.SaveObjectToFile(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperY[j, k], FileName,
                                typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.ExcludeDataBindings);
                        }
                    }
                }
            }
            public void Save_ATT(int StageNo, int TabNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, true, 0, "Saving");
#region ATT Inspection Parameter
                //--------------------------------------------------------------------------------------------------

                //압흔 파라메터 - YSH
                //ModelFile.SetData(m_AlignName, "JudgeCount", );
                //ModelFile.SetData(m_AlignName, "JudgeLength", );
                //ModelFile.SetData(m_AlignName, "JudgeGrayScale", );
                //ModelFile.SetData(m_AlignName, "JudgeDistribution", );
                //ModelFile.SetData(m_AlignName, "SliceWidth", );
                //ModelFile.SetData(m_AlignName, "SliceHeight", );
                ModelFile.SetData(m_AlignName, "JudgeCount" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].JudgeCount);
                ModelFile.SetData(m_AlignName, "JudgeLength" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].JudgeLength);

                ModelFile.SetData(m_AlignName, "SliceOverlap" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_nOverlap);
                ModelFile.SetData(m_AlignName, "Akkon Filter Type" + StageNo.ToString() + TabNo.ToString(), (int)Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eFilterType);
                ModelFile.SetData(m_AlignName, "Akkon Filter Direction" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nFilterDir);
                ModelFile.SetData(m_AlignName, "Akkon Threshold Mode" + StageNo.ToString() + TabNo.ToString(), (int)Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eThMode);
                ModelFile.SetData(m_AlignName, "Akkon Thres Weight" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fThWeight);
                ModelFile.SetData(m_AlignName, "Shadow Detection Offset" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nShadowOffset);
                ModelFile.SetData(m_AlignName, "Akkon Shadow Direction" + StageNo.ToString() + TabNo.ToString(), (int)Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eShadowDir);
                ModelFile.SetData(m_AlignName, "Akkon Strength Threshold" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStrengthThreshold);
                ModelFile.SetData(m_AlignName, "Akkon Strength Base" + StageNo.ToString() + TabNo.ToString(), (int)Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eStrengthBase);
                ModelFile.SetData(m_AlignName, "Akkon Peak Property" + StageNo.ToString() + TabNo.ToString(), (int)Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_ePeakProp);
                ModelFile.SetData(m_AlignName, "Akkon Threshold Peak" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nThPeak);
                ModelFile.SetData(m_AlignName, "Akkon Extra Lead" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nExtraLead);
                ModelFile.SetData(m_AlignName, "Akkon Min Shadow Width" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nMinShadowWidth);
                ModelFile.SetData(m_AlignName, "Akkon Strength Scale Factor" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStrengthScaleFactor);
                ModelFile.SetData(m_AlignName, "Akkon Inflate Lead Size" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nInflateLeadSize);
                ModelFile.SetData(m_AlignName, "Akkon Position Tolerance" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fPosTolerance);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Boost Offset", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Boost Weight", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);


                ModelFile.SetData(m_AlignName, "Akkon Strength Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMinStrength);
                ModelFile.SetData(m_AlignName, "Akkon Min Heigtht Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinHeight);
                ModelFile.SetData(m_AlignName, "Akkon Min Width Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinWidth);
                ModelFile.SetData(m_AlignName, "Akkon Min Size Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMinSize);
                ModelFile.SetData(m_AlignName, "Akkon Max Size Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMaxSize);
                ModelFile.SetData(m_AlignName, "Akkon Grouping Distance Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fGroupingDistance);
                ModelFile.SetData(m_AlignName, "Akkon Min Boundary Overlap" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinBoundaryOverlap);
                ModelFile.SetData(m_AlignName, "Akkon Use Edge False Alarm Filter" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_bUseEdgeFARemove);
                ModelFile.SetData(m_AlignName, "Akkon FAR WH Ratio" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fWHRatio);
                ModelFile.SetData(m_AlignName, "Akkon FAR Edge Range" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nEdgeRange);
                ModelFile.SetData(m_AlignName, "Akkon FAR Strength Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEdgeStrengthCut);
                ModelFile.SetData(m_AlignName, "Akkon FAR Size Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEdgeSizeCut);
                ModelFile.SetData(m_AlignName, "Akkon BW Peak Ratiot" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fBWRatio);
                ModelFile.SetData(m_AlignName, "Akkon ROI Division Count" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nROIDiv);
                ModelFile.SetData(m_AlignName, "Akkon In ROI Line Count" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nAkkonInLine);
                ModelFile.SetData(m_AlignName, "Akkon In ROI Line Area" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fAkkonInArea);
                ModelFile.SetData(m_AlignName, "Akkon BW Ratio Max" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fBWRatioMax);
                ModelFile.SetData(m_AlignName, "Akkon Enh Std Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEnhstdcut);
                ModelFile.SetData(m_AlignName, "Akkon Shadow Peak Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nShadowPeakcut);
                ModelFile.SetData(m_AlignName, "Akkon Raw Up Shoot Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nRawUpShootcut);
                ModelFile.SetData(m_AlignName, "Akkon Raw Avg Min" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawAvgMin);
                ModelFile.SetData(m_AlignName, "Akkon Raw Avg Max" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawAvgMax);
                ModelFile.SetData(m_AlignName, "Akkon Raw Std Min" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawStdMin);
                ModelFile.SetData(m_AlignName, "Akkon Raw Std Max" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawStdMax);
                ModelFile.SetData(m_AlignName, "Akkon Raw Shadow Min" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawShadowMin);
                ModelFile.SetData(m_AlignName, "Akkon Raw Shadow Max" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawShadowMax);

                //ModelFile.SetData(m_AlignName, "Lead Total Count", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);
                //ModelFile.SetData(m_AlignName, "Lead Set Count", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_AkkonInspFilter.);
                ModelFile.SetData(m_AlignName, "Akkon Standard Deviation Lead Judge" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStdDevLeadJudge);
                ModelFile.SetData(m_AlignName, "Akkon Imul Inspection" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bImulInspection);
                ModelFile.SetData(m_AlignName, "Akkon Target Type" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nIsFlexible); // 0 : RIGID, 1 : FLEIBLE
                ModelFile.SetData(m_AlignName, "Akkon Inspection Type" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_nInspType); // 0 : ThresholdMode, 1 : DLMode0, 2 : DLMode1, 3 : DLMode2
                ModelFile.SetData(m_AlignName, "Akkon Imul Inspection Threshold" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nImulInspectionThresh);
                ModelFile.SetData(m_AlignName, "Akkon Imul size" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fImulSize);
                ModelFile.SetData(m_AlignName, "Akkon Filter Width Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nWidthCut);
                ModelFile.SetData(m_AlignName, "Akkon Filter Heigth Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nHeightCut);
                ModelFile.SetData(m_AlignName, "Akkon Filter Raw Peak Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nRawPeakCut);
                ModelFile.SetData(m_AlignName, "Akkon Filter WH Raw Peak Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nWHRawPeakCut);
                ModelFile.SetData(m_AlignName, "Akkon Use Absolute Threshold" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bUseAbsTh);
                ModelFile.SetData(m_AlignName, "Akkon Absolute Threshold High" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nAbsoluteThHi);
                ModelFile.SetData(m_AlignName, "Akkon Absolute Threshold Low" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nAbsoluteThLow);
                ModelFile.SetData(m_AlignName, "Akkon Panel Type", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nPanelInfo); // 0 COF, 1 COG, 2 FOG


                ModelFile.SetData(m_AlignName, "DL Peak Prob" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fDLPeakProb);
                ModelFile.SetData(m_AlignName, "DL Size Prob" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fDLSizeProb);
                ModelFile.SetData(m_AlignName, "DL Sperate Cut" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLSperateCut);
                ModelFile.SetData(m_AlignName, "DL Network Type" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLNetWorkType);
                ModelFile.SetData(m_AlignName, "DL Edge Flip" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bEdgeFlip);
                ModelFile.SetData(m_AlignName, "DL Patch Size X" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLPatchSizeX);
                ModelFile.SetData(m_AlignName, "DL Patch Size Y" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLPatchSizeY);

                

                ModelFile.SetData(m_AlignName, "Log Trace" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_bLogTrace);

                //Align 검사 Data
                ModelFile.SetData(m_AlignName, "Lead Count" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeadCount);


                //ROI Data 
                //YSH 추후 모델별 관리부분 추가 예정
                using (StreamWriter outputFile = new StreamWriter(DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\AKKON\\" + m_AlignName + StageNo.ToString() + TabNo.ToString() + "_ROIData.txt"))
                {
                    //File경로 제대로 확인
                    for (int i = 0; i < Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList.Count; i++)
                    {
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerOriginX);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerOriginY);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerXX);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerXY);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerOppositeX);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerOppositeY);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerYX);
                        outputFile.Write(" ");
                        outputFile.Write(Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList[i].CornerYY);
                        outputFile.Write(" ");
                        outputFile.Write("\n");
                    }
                }
                //Lead Group 부분
                ModelFile.SetData(m_AlignName, "Lead Group Count" + StageNo.ToString() + TabNo.ToString(), Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeadGroupCount);
                for (int i = 0; i < Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo.Count(); i++)
                {
                    ModelFile.SetData(m_AlignName, "Lead Group" + StageNo.ToString() + TabNo.ToString() + (i + 1).ToString() + "_Lead Count", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo[i].LeadCount);
                    ModelFile.SetData(m_AlignName, "Lead Group" + StageNo.ToString() + TabNo.ToString() + (i + 1).ToString() + "_Lead Pitch", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo[i].LeadPitch);
                }
                //--------------------------------------------------------------------------------------------------
#endregion
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 1, false, 0, "Saving");
            }

            public void LoadMark(int StageNo, int TabNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, true, 0, "Loading");
                Model_Initial();

                string FileName;
                bool bExist;

                for (int markIndex = 0; markIndex < Main.DEFINE.SUBPATTERNMAX; markIndex++)
                {
                    try
                    {
                        //string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName +"\\BLOB\\";

                        //얼라인검사 Mark Data [FPC]
                        FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\" + m_AlignName + "_ALIGN_LEFTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";

                        bExist = File.Exists(FileName);
                        if (bExist)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex] = CogSerializer.LoadObjectFromFile(FileName) as CogPMAlignTool;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].RunParams.ZoneAngle.High = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].RunParams.TimeoutEnabled = true;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeftPattern[markIndex].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }

                        FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\" + m_AlignName + "_ALIGN_RIGHTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";

                        bExist = File.Exists(FileName);
                        if (bExist)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex] = CogSerializer.LoadObjectFromFile(FileName) as CogPMAlignTool;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].RunParams.ZoneAngle.High = (Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].RunParams.TimeoutEnabled = true;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.RightPattern[markIndex].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }

                        //압흔검사 Mark Data [Panel]

                        FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\" + m_AlignName + "_ATT_LEFTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";

                        bExist = File.Exists(FileName);
                        if (bExist)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex] = CogSerializer.LoadObjectFromFile(FileName) as CogPMAlignTool;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].RunParams.ZoneAngle.High = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].RunParams.TimeoutEnabled = true;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeftPattern[markIndex].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }

                        FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\" + m_AlignName + "_ATT_RIGHTMARK" + StageNo.ToString() + TabNo.ToString() + markIndex.ToString() + ".vpp";

                        bExist = File.Exists(FileName);
                        if (bExist)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex] = CogSerializer.LoadObjectFromFile(FileName) as CogPMAlignTool;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].RunParams.ZoneAngle.High = -(Main.DEFINE.radian * Main.DEFINE.DEFAULT_ACCEPT_ANGLE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].RunParams.TimeoutEnabled = true;
                            Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].RightPattern[markIndex].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, false, 0, "Loading");
            }

            public void LoadAlign(int StageNo, int TabNo)
            {
                string FileName;
                bool bExist;

                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.LeadCount = ModelFile.GetIData(m_AlignName, "Lead Count" + StageNo.ToString() + TabNo.ToString());

                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; j++)//Tab의 Left, Right
                {
                    for (int k = 0; k < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; k++)//FPC, Panel
                    {
                        try
                        {
                            FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\ALIGN\\" + m_AlignName + "_ALIGN_X_CALIPER" + StageNo.ToString() + TabNo.ToString() + j.ToString() + k.ToString() + ".vpp";

                            bExist = File.Exists(FileName);

                            if (bExist)
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperX[j, k] = CogSerializer.LoadObjectFromFile(FileName) as CogCaliperTool;

                            FileName = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\ALIGN\\" + m_AlignName + "_ALIGN_Y_CALIPER" + StageNo.ToString() + TabNo.ToString() + j.ToString() + k.ToString() + ".vpp";

                            bExist = File.Exists(FileName);

                            if (bExist)
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AlignPara.AlignCaliperY[j, k] = CogSerializer.LoadObjectFromFile(FileName) as CogCaliperTool;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                        }
                    }
                }
            }

            public void Load_ATT(int StageNo, int TabNo)
            {
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 0, true, 0, "Loading");
#region ATT Inspection Parameter
                //--------------------------------------------------------------------------------------------------
                //압흔 파라메터 - YSH
                //추후 인덱스 재조정 필요, 임의 0번 인덱스 사용
                //Judge부분 보류
                Model_Initial();

                //ModelFile.SetData(m_AlignName, "JudgeCount", );
                //ModelFile.SetData(m_AlignName, "JudgeLength", );
                //ModelFile.SetData(m_AlignName, "JudgeGrayScale", );
                //ModelFile.SetData(m_AlignName, "JudgeDistribution", );
                //ModelFile.SetData(m_AlignName, "SliceWidth",);
                //ModelFile.SetData(m_AlignName, "SliceHeight", );
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].JudgeCount = ModelFile.GetIData(m_AlignName, "JudgeCount" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].JudgeLength = ModelFile.GetFData(m_AlignName, "JudgeLength" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_nOverlap = ModelFile.GetIData(m_AlignName, "SliceOverlap" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eFilterType = (AW.EN_MVFILTERTYPE_WRAP)ModelFile.GetIData(m_AlignName, "Akkon Filter Type" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nFilterDir = ModelFile.GetIData(m_AlignName, "Akkon Filter Direction" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eThMode = (AW.EN_THMODE_WRAP)ModelFile.GetIData(m_AlignName, "Akkon Threshold Mode" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fThWeight = ModelFile.GetFData(m_AlignName, "Akkon Thres Weight" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nShadowOffset = ModelFile.GetIData(m_AlignName, "Shadow Detection Offset" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eShadowDir = (AW.EN_SHADOWDIR_WRAP)ModelFile.GetIData(m_AlignName, "Akkon Shadow Direction" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStrengthThreshold = (float)ModelFile.GetFData(m_AlignName, "Akkon Strength Threshold" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_eStrengthBase = (AW.EN_STRENGTH_BASE_WRAP)ModelFile.GetIData(m_AlignName, "Akkon Strength Base" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_ePeakProp = (AW.EN_PEAK_PROP_WRAP)ModelFile.GetIData(m_AlignName, "Akkon Peak Property" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nThPeak = ModelFile.GetIData(m_AlignName, "Akkon Threshold Peak" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nExtraLead = ModelFile.GetIData(m_AlignName, "Akkon Extra Lead" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nMinShadowWidth = ModelFile.GetIData(m_AlignName, "Akkon Min Shadow Width" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)ModelFile.GetFData(m_AlignName, "Akkon Strength Scale Factor" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nInflateLeadSize = ModelFile.GetIData(m_AlignName, "Akkon Inflate Lead Size" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fPosTolerance = (float)ModelFile.GetFData(m_AlignName, "Akkon Position Tolerance" + StageNo.ToString() + TabNo.ToString());

                //ModelFile.SetData(m_AlignName, "Akkon Strength Boost Offset", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);
                //ModelFile.SetData(m_AlignName, "Akkon Strength Boost Weight", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);


                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMinStrength = (float)ModelFile.GetFData(m_AlignName, "Akkon Strength Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinHeight = ModelFile.GetIData(m_AlignName, "Akkon Min Heigtht Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinWidth = ModelFile.GetIData(m_AlignName, "Akkon Min Width Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMinSize = (float)ModelFile.GetFData(m_AlignName, "Akkon Min Size Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fMaxSize = (float)ModelFile.GetFData(m_AlignName, "Akkon Max Size Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fGroupingDistance = ModelFile.GetFData(m_AlignName, "Akkon Grouping Distance Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nMinBoundaryOverlap = ModelFile.GetIData(m_AlignName, "Akkon Min Boundary Overlap" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_bUseEdgeFARemove = ModelFile.GetBData(m_AlignName, "Akkon Use Edge False Alarm Filter" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fWHRatio = (float)ModelFile.GetFData(m_AlignName, "Akkon FAR WH Ratio" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nEdgeRange = ModelFile.GetIData(m_AlignName, "Akkon FAR Edge Range" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEdgeStrengthCut = (float)ModelFile.GetFData(m_AlignName, "Akkon FAR Strength Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEdgeSizeCut = ModelFile.GetIData(m_AlignName, "Akkon FAR Size Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fBWRatio = (float)ModelFile.GetFData(m_AlignName, "Akkon BW Peak Ratiot" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nROIDiv = ModelFile.GetIData(m_AlignName, "Akkon ROI Division Count" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nAkkonInLine = ModelFile.GetIData(m_AlignName, "Akkon In ROI Line Count" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fAkkonInArea = (float)ModelFile.GetFData(m_AlignName, "Akkon In ROI Line Area" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fBWRatioMax = (float)ModelFile.GetFData(m_AlignName, "Akkon BW Ratio Max" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fEnhstdcut = (float)ModelFile.GetFData(m_AlignName, "Akkon Enh Std Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nShadowPeakcut = ModelFile.GetIData(m_AlignName, "Akkon Shadow Peak Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nRawUpShootcut = ModelFile.GetIData(m_AlignName, "Akkon Raw Up Shoot Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawAvgMin = (float)ModelFile.GetFData(m_AlignName, "Akkon Raw Avg Min" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawAvgMax = (float)ModelFile.GetFData(m_AlignName, "Akkon Raw Avg Max" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawStdMin = (float)ModelFile.GetFData(m_AlignName, "Akkon Raw Std Min" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawStdMax = (float)ModelFile.GetFData(m_AlignName, "Akkon Raw Std Max" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawShadowMin = ModelFile.GetIData(m_AlignName, "Akkon Raw Shadow Min" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fRawShadowMax = ModelFile.GetIData(m_AlignName, "Akkon Raw Shadow Max" + StageNo.ToString() + TabNo.ToString());



                //ModelFile.SetData(m_AlignName, "Lead Total Count", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].);
                //ModelFile.SetData(m_AlignName, "Lead Set Count", Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].m_AkkonInspFilter.);

                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fStdDevLeadJudge = (float)ModelFile.GetFData(m_AlignName, "Akkon Standard Deviation Lead Judge" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bImulInspection = ModelFile.GetBData(m_AlignName, "Akkon Imul Inspection" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nIsFlexible = ModelFile.GetIData(m_AlignName, "Akkon Target Type" + StageNo.ToString() + TabNo.ToString());// 0 : RIGID, 1 : FLEIBLE
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_nInspType = ModelFile.GetIData(m_AlignName, "Akkon Inspection Type" + StageNo.ToString() + TabNo.ToString());// 0 : ThresholdMode, 1 : DLMode0, 2 : DLMode1, 3 : DLMode2
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nImulInspectionThresh = ModelFile.GetIData(m_AlignName, "Akkon Imul Inspection Threshold" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_fImulSize = (float)ModelFile.GetFData(m_AlignName, "Akkon Imul size" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nWidthCut = ModelFile.GetIData(m_AlignName, "Akkon Filter Width Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nHeightCut = ModelFile.GetIData(m_AlignName, "Akkon Filter Heigth Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nRawPeakCut = ModelFile.GetIData(m_AlignName, "Akkon Filter Raw Peak Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionFilter.s_nWHRawPeakCut = ModelFile.GetIData(m_AlignName, "Akkon Filter WH Raw Peak Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bUseAbsTh = ModelFile.GetBData(m_AlignName, "Akkon Use Absolute Threshold" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nAbsoluteThHi = ModelFile.GetIData(m_AlignName, "Akkon Absolute Threshold High" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nAbsoluteThLow = ModelFile.GetIData(m_AlignName, "Akkon Absolute Threshold Low" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nPanelInfo = ModelFile.GetIData(m_AlignName, "Akkon Panel Type" + StageNo.ToString() + TabNo.ToString());// 0 COF, 1 COG, 2 FOG



                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fDLPeakProb = (float)ModelFile.GetFData(m_AlignName, "DL Peak Prob" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_fDLSizeProb = (float)ModelFile.GetFData(m_AlignName, "DL Size Prob" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLSperateCut = ModelFile.GetIData(m_AlignName, "DL Sperate Cut" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLNetWorkType = ModelFile.GetIData(m_AlignName, "DL Network Type" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_bEdgeFlip = ModelFile.GetBData(m_AlignName, "DL Edge Flip" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLPatchSizeX = ModelFile.GetIData(m_AlignName, "DL Patch Size X" + StageNo.ToString() + TabNo.ToString());
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionParameter.s_nDLPatchSizeY = ModelFile.GetIData(m_AlignName, "DL Patch Size Y" + StageNo.ToString() + TabNo.ToString());


                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonInspectionOption.s_bLogTrace = ModelFile.GetBData(m_AlignName, "Log Trace" + StageNo.ToString() + TabNo.ToString());


                //Lead Group 부분 
                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].LeadGroupCount = ModelFile.GetIData(m_AlignName, "Lead Group Count" + StageNo.ToString() + TabNo.ToString());

                for (int i = 0; i < Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo.Count(); i++)
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo[i].LeadCount = ModelFile.GetIData(m_AlignName, "Lead Group" + StageNo.ToString() + TabNo.ToString() + (i + 1).ToString() + "_Lead Count");
                    Main.AlignUnit[CamNo].PAT[StageNo, TabNo].LeadGroupInfo[i].LeadPitch = ModelFile.GetFData(m_AlignName, "Lead Group" + StageNo.ToString() + TabNo.ToString() + (i + 1).ToString() + "_Lead Pitch");
                }

                //--------------------------------------------------------------------------------------------------



                //ATT Data 
                bool bExist;

                //--------------------------------------------------------------------------------------------------
                //ROI Data 
                try
                {
                    //ROI Data 파일이 없을 경우 Pass

                    bExist = File.Exists(DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\AKKON\\" + m_AlignName + StageNo.ToString() + TabNo.ToString() + "_ROIData.txt");

                    if (bExist)
                    {
                        string text = File.ReadAllText(DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\AKKON\\" + m_AlignName + StageNo.ToString() + TabNo.ToString() + "_ROIData.txt");

                        if (text.ToString() == string.Empty)
                            return;

                        char[] delimiterChars = { ' ', '\0', '\n' };
                        string[] Str_tmp = text.Split(delimiterChars);
                        string ReadData;

                        int lineCount = File.ReadAllLines(DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\AKKON\\" + m_AlignName + StageNo.ToString() + TabNo.ToString() + "_ROIData.txt").Length;

                        int[,] nLeadPoint = new int[lineCount, 8];

                        int nCnt = 0;
                        int nIndex = 0;
                        for (int i = 0; i < Str_tmp.Length; i++)
                        {
                            ReadData = Str_tmp[i];
                            if (ReadData.Equals("") || ReadData.Equals("\r"))
                            {
                                if (nIndex == lineCount)
                                    break;

                                if (nLeadPoint[nIndex, 7] == 0)
                                {
                                    break;
                                }
                                //하나의 CogRectangleAffine ROI Data를 Read 할때 마다, ROI 변수에 할당     
                                CogRectangleAffine tempRectAffine = new CogRectangleAffine();
                                tempRectAffine.SetOriginCornerXCornerY(nLeadPoint[nIndex, 0], nLeadPoint[nIndex, 1],
                                    nLeadPoint[nIndex, 2], nLeadPoint[nIndex, 3], nLeadPoint[nIndex, 6], nLeadPoint[nIndex, 7]);
                                Main.AlignUnit[CamNo].PAT[StageNo, TabNo].AkkonPara[0].AkkonBumpROIList.Add(tempRectAffine);
                                nCnt = 0;
                                nIndex++;
                                continue;
                            }
                            else
                            {
                                nLeadPoint[nIndex, nCnt] = Convert.ToInt32(Convert.ToDouble(ReadData));
                                nCnt++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString() + ex.StackTrace);
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
                    //throw;
                }
#endregion
                Main.ProgerssBar_PAT(Main.formProgressBar_1, 1, false, 0, "Loading");
            }
        }
        public partial class PatternTag
        {
            public void Save()
            {
                string buf;


                for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
                {
                    buf = "LIGHTCTRL_" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_LightCtrl[i]);
                    buf = "LIGHTCH_" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_LightCH[i]);
                    buf = "LIGHTNAME_" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_Light_Name[i]);
                }
                //---------------------------ModelFile-----------------------------------
                for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
                {
                    for (int j = 0; j < Main.DEFINE.Light_ToolMaxCount; j++)
                    {
                        buf = "LIGHT" + i.ToString() + "_" + j.ToString();
                        ModelFile.SetData(m_PatternName, buf, m_LightValue[i, j]);
                    }
                }
                //------------------------SystemFile-------------------------------------
                for (int i = 0; i < 2; i++)
                {
                    buf = "CAL_X" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_CalX[i]);
                    buf = "CAL_Y" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_CalY[i]);
                }

                for (int i = 0; i < 9; i++)
                {
                    buf = "CALMATRIX" + i.ToString();
                    //                    if(!Main.DEFINE.OPEN_F)
                    SystemFile.SetData(m_PatternName, buf, CALMATRIX[i]);
                }
                buf = "CCD_T_X";
                SystemFile.SetData(m_PatternName, buf, CAMCCDTHETA[0, 0]);
                buf = "CCD_T_Y";
                SystemFile.SetData(m_PatternName, buf, CAMCCDTHETA[0, 1]);

                buf = "MANU_MATCH_USE";
                ModelFile.SetData(m_PatternName, buf, m_Manu_Match_Use);

                buf = "PMALIGN_USE";
                ModelFile.SetData(m_PatternName, buf, m_PMAlign_Use);

                buf = "LINEMAX_USE";
                ModelFile.SetData(m_PatternName, buf, m_UseLineMax);

                buf = "CUSTOM_CROSS_USE";
                ModelFile.SetData(m_PatternName, buf, Main.vision.USE_CUSTOM_CROSS[m_CamNo]);

                buf = "CUSTOM_CROSS_X";
                ModelFile.SetData(m_PatternName, buf, Main.vision.CUSTOM_CROSS_X[m_CamNo]);

                buf = "CUSTOM_CROSS_Y";
                ModelFile.SetData(m_PatternName, buf, Main.vision.CUSTOM_CROSS_Y[m_CamNo]);


                if (Main.Status.MC_MODE != Main.DEFINE.MC_SETUPFORM && Main.Status.MC_STATUS != Main.DEFINE.MC_RUN)
                {
                    //----------------------------------------------------------------------
                    String ModelDir = ModelPath;

#region PATTERN
                    String PatFileName;
                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        PatFileName = ModelDir + ProjectName + "\\" + m_PatternName + "_" + i.ToString() + ".vpp";
                        try
                        {
                            Pattern[i].InputImage = null;
                            CogSerializer.SaveObjectToFile(Pattern[i], PatFileName);
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            //   MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                        }
                    }
                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        PatFileName = ModelDir + ProjectName + "\\" + m_PatternName + "_" + "G" + i.ToString() + ".vpp";
                        try
                        {
                            GPattern[i].InputImage = null;
                            CogSerializer.SaveObjectToFile(GPattern[i], PatFileName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            //   MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                        }
                    }

                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        buf = "PATUSE" + i.ToString();
                        ModelFile.SetData(m_PatternName, buf, Pattern_USE[i]);
                    }
                    buf = "ACCEPT_SCORE";
                    ModelFile.SetData(m_PatternName, buf, m_ACCeptScore);
                    buf = "ACCEPT_GSCORE";
                    ModelFile.SetData(m_PatternName, buf, m_GACCeptScore);

                    buf = "CALIPER_MARKUSE";
                    ModelFile.SetData(m_PatternName, buf, Caliper_MarkUse);

                    buf = "BLOB_MARKUSE";
                    ModelFile.SetData(m_PatternName, buf, Blob_MarkUse);

                    buf = "BLOB_CALIPERUSE";
                    ModelFile.SetData(m_PatternName, buf, Blob_CaliperUse); 
                     
                    buf = "BLOB_INSPECT_CNT";
                    ModelFile.SetData(m_PatternName, buf, m_Blob_InspCnt);

                    buf = "FINDLINE_MARKUSE";
                    ModelFile.SetData(m_PatternName, buf, FINDLine_MarkUse);

                    buf = "CIRCLE_MARKUSE";
                    ModelFile.SetData(m_PatternName, buf, Circle_MarkUse);
#endregion

#region CALIPER

                    string m_CaliName;
                    for (int i = 0; i < Main.DEFINE.CALIPER_MAX; i++)
                    {
                        m_CaliName = m_PatternName + "_CALIPER";
                        buf = "CALIPER_CENTERX" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].Region.CenterX);

                        buf = "CALIPER_CENTERY" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].Region.CenterY);

                        buf = "CALIPER_SIZEX" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].Region.SideXLength);

                        buf = "CALIPER_SIZEY" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].Region.SideYLength);

                        buf = "CALIPER_THRESHOLD" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].RunParams.ContrastThreshold);

                        buf = "CALIPER_DIRECTION" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].Region.Rotation);

                        buf = "CALIPER_POLARLITY" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, Convert.ToInt16(CaliperTools[i].RunParams.Edge0Polarity));

                        buf = "CALIPER_EDGE_MODE" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, Convert.ToInt16(CaliperTools[i].RunParams.EdgeMode));

                        buf = "CALIPER_POSITION_0" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].RunParams.Edge0Position);

                        buf = "CALIPER_POSITION_1" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].RunParams.Edge1Position);

                        buf = "CALIPER_USE" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_UseCheck);

                        buf = "Caliper FilterHSPixel" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperTools[i].RunParams.FilterHalfSizeInPixels);

                        buf = "CALIPER_COP_MODE" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_bCOPMode);

                        buf = "CALIPER_COP_DVDCOUNT" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_nCOPROICnt);

                        buf = "CALIPER_COP_DVDOFFSET" + i.ToString();
                        ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_nCOPROIOffset);

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_TargetToCenter[k].X);
                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_CaliName, buf, CaliperPara[i].m_TargetToCenter[k].Y);
                        }
                    }
#endregion

#region BLOB 수정한거
                    CogRectangleAffine BlobRegion;
                    string m_BlobName;
                    for (int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
                    {
                        BlobRegion = new CogRectangleAffine(BlobTools[i].Region as CogRectangleAffine);

                        m_BlobName = m_PatternName + "_BLOB";
                        //----------------------------------------------------------------------------------------------------------
                        buf = "BLOBUSE" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobPara[i].m_UseCheck);
                        //------------REGION----------------------------------------------------------------------------------------
                        buf = "BLOBREGION_CENTERX" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.CenterX);

                        buf = "BLOBREGION_CENTERY" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.CenterY);

                        buf = "BLOBREGION_WIDTH" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.SideXLength);

                        buf = "BLOBREGION_HEIGHT" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.SideYLength);

                        buf = "BLOBREGION_ROTATION" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.Rotation);

                        buf = "BLOBREGION_SKEW" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobRegion.Skew);
                        //----------------------------------------------------------------------------------------------------------
                        buf = "BLOB_POLARITY" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, Convert.ToInt16(BlobTools[i].RunParams.SegmentationParams.Polarity));

                        buf = "BLOB_MINPIXELS" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobTools[i].RunParams.ConnectivityMinPixels);

                        buf = "BLOB_THRESHOLD" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobTools[i].RunParams.SegmentationParams.HardFixedThreshold);

                        buf = "BLOB_AREA_MIN" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobTools[i].RunParams.RunTimeMeasures[0].FilterRangeLow);
                        buf = "BLOB_AREA_HIGH" + i.ToString();
                        ModelFile.SetData(m_BlobName, buf, BlobTools[i].RunParams.RunTimeMeasures[0].FilterRangeHigh);

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_BlobName, buf, BlobPara[i].m_TargetToCenter[k].X);
                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_BlobName, buf, BlobPara[i].m_TargetToCenter[k].Y);
                        }
                        //----------------------------------------------------------------------------------------------------------
                    }
#endregion

#region FINDLINE
                    buf = "TRAY_GUIDE_DIS_X";
                    ModelFile.SetData(m_PatternName, buf, TRAY_GUIDE_DISX);

                    buf = "TRAY_GUIDE_DIS_Y";
                    ModelFile.SetData(m_PatternName, buf, TRAY_GUIDE_DISY);

                    buf = "TRAY_PITCH_DIS_X";
                    ModelFile.SetData(m_PatternName, buf, TRAY_PITCH_DISX);

                    buf = "TRAY_PITCH_DIS_Y";
                    ModelFile.SetData(m_PatternName, buf, TRAY_PITCH_DISY);

                    string m_FINDLineName, m_LineMaxName;
                    for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                    {
                        for (int i = 0; i < Main.DEFINE.FINDLINE_MAX; i++)
                        {
                            m_FINDLineName = m_PatternName + "_FINDLine_" + ii.ToString();
                            buf = "FINDLINE_STARTX" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.ExpectedLineSegment.StartX);

                            buf = "FINDLINE_STARTY" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.ExpectedLineSegment.StartY);

                            buf = "FINDLINE_LENGTH" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.ExpectedLineSegment.Length);

                            buf = "FINDLINE_DIRECTION" + i.ToString();
                            if (FINDLineTools[ii, i].RunParams.ExpectedLineSegment.StartX != FINDLineTools[ii, i].RunParams.ExpectedLineSegment.EndX
                                && FINDLineTools[ii, i].RunParams.ExpectedLineSegment.StartY != FINDLineTools[ii, i].RunParams.ExpectedLineSegment.EndY)
                                ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.ExpectedLineSegment.Rotation);
                            else
                                ModelFile.SetData(m_FINDLineName, buf, 0);

                            buf = "FINDLINE_CALIPER_CNT" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.NumCalipers);

                            buf = "FINDLINE_NUMTOLGNORE" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, Convert.ToInt16(FINDLineTools[ii, i].RunParams.NumToIgnore));

                            buf = "FINDLINE_CALIPERX" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.CaliperProjectionLength); // Caliper X

                            buf = "FINDLINE_CALIPERY" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.CaliperSearchLength);  // Caliper Y

                            buf = "FINDLINE_CALIPER_THRESHOLD" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.CaliperRunParams.ContrastThreshold);

                            buf = "FINDLINE_CALIPER_POLARLITY" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, Convert.ToInt16(FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge0Polarity));

                            buf = "FINDLINE_CALIPER_USE" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_UseCheck);

                            buf = "FINDLINE_CALIPER_PAIR_USE" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_UsePairCheck);

                            buf = "FINDLINE_CALIPER_POLARLITY_1" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, Convert.ToInt16(FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge1Polarity));

                            buf = "FINDLINE_CALIPER_FINDLine1POS" + i.ToString();    //Pos 간격 이하만 찾아라.
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge1Position);

                            buf = "FINDLINE_CALIPER_FINDLineMODE" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, Convert.ToInt16(FINDLineTools[ii, i].RunParams.CaliperRunParams.EdgeMode));

                            buf = "FINDLINE_CALIPER_SEARCHDIRECTION" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLineTools[ii, i].RunParams.CaliperSearchDirection);

                            buf = "FINDLINE_FILTERHALFSIZE" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, Convert.ToInt16(FINDLineTools[ii, i].RunParams.CaliperRunParams.FilterHalfSizeInPixels));

                            buf = "FINDLINE_CALIPER_METHOD" + i.ToString();
                            ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_LineCaliperMethod);

                            for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                            {
                                buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                                ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_TargetToCenter[k].X);
                                buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                                ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_TargetToCenter[k].Y);

                                buf = "TARGET_TO_CENTER_2X" + i.ToString() + "_" + k.ToString();
                                ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_TargetToCenter[k].X2);
                                buf = "TARGET_TO_CENTER_2Y" + i.ToString() + "_" + k.ToString();
                                ModelFile.SetData(m_FINDLineName, buf, FINDLinePara[ii, i].m_TargetToCenter[k].Y2);
                            }

                            //==================== LINEMAX ====================//
                            m_LineMaxName = m_PatternName + "_LineMax_" + ii.ToString();

                            buf = "LINEMAX_CENTERX" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, (LineMaxTools[ii, i].Region as CogRectangleAffine).CenterX);

                            buf = "LINEMAX_CENTERY" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, (LineMaxTools[ii, i].Region as CogRectangleAffine).CenterY);

                            buf = "LINEMAX_EXPLINE_ANGLE" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.ExpectedLineNormal.Angle);

                            buf = "LINEMAX_GRAKERNEL_SIZE" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels);

                            buf = "LINEMAX_PROJECTION_LENGTH" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ProjectionLengthInPixels);

                            buf = "LINEMAX_CONTRAST_THRES" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ContrastThreshold);

                            buf = "LINEMAX_POLARITY" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, Convert.ToInt16(LineMaxTools[ii, i].RunParams.Polarity));

                            buf = "LINEMAX_EDGE_ANGLE_TOL" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.EdgeAngleTolerance);

                            buf = "LINEMAX_EDGE_DIST_TOL" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.DistanceTolerance);

                            buf = "LINEMAX_MAX_LINES" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.MaxNumLines);

                            buf = "LINEMAX_LINE_ANGLE_TOL" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.LineAngleTolerance);

                            buf = "LINEMAX_COVERAGE_THRES" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.CoverageThreshold);

                            buf = "LINEMAX_LENGTH_THRES" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, LineMaxTools[ii, i].RunParams.LengthThreshold);

                            buf = "LINEMAX_HORIZONTAL_COND" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, FINDLinePara[ii, i].m_LineMaxHCond);

                            buf = "LINEMAX_VERTICAL_COND" + i.ToString();
                            ModelFile.SetData(m_LineMaxName, buf, FINDLinePara[ii, i].m_LineMaxVCond);
                        }
                    }
#endregion

#region CIRCLE
                    string m_CircleName;
                    for (int i = 0; i < Main.DEFINE.CIRCLE_MAX; i++)
                    {
                        m_CircleName = m_PatternName + "_CIRCLE";
                        buf = "CIRCLE_CENTERX" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.ExpectedCircularArc.CenterX);

                        buf = "CIRCLE_CENTERY" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.ExpectedCircularArc.CenterY);

                        buf = "CIRCLE_RADIUS" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.ExpectedCircularArc.Radius);

                        buf = "RUNPARAMS_NUMCALIPERTS" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.NumCalipers);

                        buf = "RUNPARAMS_SEARCHLENGTH" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.CaliperSearchLength);

                        buf = "RUNPARAMS_SEARCHDIRECTION" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, Convert.ToInt16(CircleTools[i].RunParams.CaliperSearchDirection));

                        buf = "RUNPARAMS_PROJECTIONLENGTH" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.CaliperProjectionLength);

                        buf = "RUNPARAMS_RADIUSCONSTRAINT" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.RadiusConstraint);

                        buf = "RUNPARAMS_RADIUSCONSTRAINT_ENABLE" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.RadiusConstraintEnabled);

                        buf = "RUNPARAMS_NUMTOLGNORE" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.NumToIgnore);

                        buf = "RUNPARAMS_ANGLESTART" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.ExpectedCircularArc.AngleStart);

                        buf = "RUNPARAMS_ANGLESPAN" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.ExpectedCircularArc.AngleSpan);

                        buf = "CALIPER_THRESHOLD" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.CaliperRunParams.ContrastThreshold);

                        buf = "CALIPER_EDGE_MODE" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, Convert.ToInt16(CircleTools[i].RunParams.CaliperRunParams.EdgeMode));

                        buf = "CALIPER_POLARLITY" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, Convert.ToInt16(CircleTools[i].RunParams.CaliperRunParams.Edge0Polarity));

                        //                         buf = "CALIPER_POSITION_0" + i.ToString();
                        //                         ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.CaliperRunParams.Edge0Position);
                        // 
                        //                         buf = "CALIPER_POSITION_1" + i.ToString();
                        //                         ModelFile.SetData(m_CircleName, buf, CircleTools[i].RunParams.CaliperRunParams.Edge1Position);

                        buf = "CIRCLE_USE" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CirclePara[i].m_UseCheck);

                        buf = "CIRCLE_CALIPER_METHOD" + i.ToString();
                        ModelFile.SetData(m_CircleName, buf, CirclePara[i].m_CircleCaliperMethod);

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_CircleName, buf, CirclePara[i].m_TargetToCenter[k].X);
                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            ModelFile.SetData(m_CircleName, buf, CirclePara[i].m_TargetToCenter[k].Y);
                        }
                    }
#endregion
                }
            }
            public void Load()
            {
                string buf;
                for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
                {
                    buf = "LIGHTCTRL_" + i.ToString();
                    m_LightCtrl[i] = SystemFile.GetIData(m_PatternName, buf);

                    buf = "LIGHTCH_" + i.ToString();
                    m_LightCH[i] = SystemFile.GetIData(m_PatternName, buf);

                    buf = "LIGHTNAME_" + i.ToString();
                    m_Light_Name[i] = SystemFile.GetSData(m_PatternName, buf);
                }
                //---------------------------ModelFile-----------------------------------
                for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
                {
                    //                 for (int j = 0; j < Main.DEFINE.Light_ToolMaxCount; j++)
                    for (int j = Main.DEFINE.Light_ToolMaxCount - 1; j >= 0; j--)
                    {
                        buf = "LIGHT" + i.ToString() + "_" + j.ToString();
                        m_LightValue[i, j] = ModelFile.GetIData(m_PatternName, buf);
                        if (Main.Status.MC_MODE != Main.DEFINE.MC_SETUPFORM)
                        SetLight(i, m_LightValue[i, j]);
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    buf = "CAL_X" + i.ToString();
                    m_CalX[i] = SystemFile.GetFData(m_PatternName, buf);
                    buf = "CAL_Y" + i.ToString();
                    m_CalY[i] = SystemFile.GetFData(m_PatternName, buf);
                }

                for (int i = 0; i < 9; i++)
                {
                    buf = "CALMATRIX" + i.ToString();
                    CALMATRIX[i] = SystemFile.GetFData(m_PatternName, buf);
                }
                 if (Main.DEFINE.OPEN_F)
                 {
#region
                     CALMATRIX[0] =  0.00230390066009215;
                     CALMATRIX[1] = -3.2820097040512E-07;
                     CALMATRIX[2] = -2.98789960112807;
                     CALMATRIX[3] = -2.4528505176532E-07;
                     CALMATRIX[4] = -0.00230483660374504;
                     CALMATRIX[5] = 2.24360308486755;
                     CALMATRIX[6] = -5.09295780651445E-07;
                     CALMATRIX[7] = 1.28121274314743E-06;
                     CALMATRIX[8] = 1;
                     m_CalX[0] = 1;
                     m_CalX[1] = 1;
                     m_CalY[0] = 1;
                     m_CalY[1] = 1;
#endregion
                 }


                buf = "CCD_T_X";
                CAMCCDTHETA[0, 0] = SystemFile.GetFData(m_PatternName, buf);
                buf = "CCD_T_Y";
                CAMCCDTHETA[0, 1] = SystemFile.GetFData(m_PatternName, buf);

                buf = "MANU_MATCH_USE";
                m_Manu_Match_Use = ModelFile.GetBData(m_PatternName, buf);

                buf = "PMALIGN_USE";
                m_PMAlign_Use = ModelFile.GetBData(m_PatternName, buf);

                buf = "LINEMAX_USE";
                m_UseLineMax = ModelFile.GetBData(m_PatternName, buf);

                buf = "CUSTOM_CROSS_USE";
                Main.vision.USE_CUSTOM_CROSS[m_CamNo] = ModelFile.GetBData(m_PatternName, buf);

                buf = "CUSTOM_CROSS_X";
                Main.vision.CUSTOM_CROSS_X[m_CamNo] = ModelFile.GetIData(m_PatternName, buf);

                buf = "CUSTOM_CROSS_Y";
                Main.vision.CUSTOM_CROSS_Y[m_CamNo] = ModelFile.GetIData(m_PatternName, buf);

                V2R(Main.vision.CUSTOM_CROSS_X[m_CamNo], Main.vision.CUSTOM_CROSS_Y[m_CamNo], ref m_dCustomCrossX, ref m_dCustomCrossY);

                if (Main.Status.MC_MODE != Main.DEFINE.MC_SETUPFORM)
                {
                    //--------------------------TEACH창에서 적용 되는 것들 -------------------
                    //-----------------------------------------------------------------------
                    String ModelDir = ModelPath;
                    String PatFileName;

                    double Temp_Angle;
                    if (m_AlignName == "LOAD_ALIGN")
                        Temp_Angle = 50;    // 스카라 로딩에서는 각도가 많이 필요.
                    else
                        Temp_Angle = Main.DEFINE.DEFAULT_ACCEPT_ANGLE;

                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {                            
                        PatFileName = ModelDir + ProjectName + "\\" + m_PatternName + "_" + i.ToString() + ".vpp";
                        try
                        {
                            Pattern[i].Dispose();
                            Pattern[i] = CogSerializer.LoadObjectFromFile(PatFileName) as CogSearchMaxTool;
                            Pattern[i].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Temp_Angle);
                            Pattern[i].RunParams.ZoneAngle.High = (Main.DEFINE.radian * Temp_Angle);
                            Pattern[i].RunParams.TimeoutEnabled = true;
                            Pattern[i].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());

                            Pattern[i] = new CogSearchMaxTool();
                            Pattern[i].Pattern.TrainRegion = new CogRectangle();
                            Pattern[i].SearchRegion = new CogRectangle();
                            (Pattern[i].SearchRegion as CogRectangle).SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);


                            Pattern[i].RunParams.RunAlgorithm = CogSearchMaxRunAlgorithmConstants.HighAccuracy;

                            if (Main.AlignUnit[m_PatAlign_No].m_AlignName == "TRAY_ALIGN")
                            {
                                Pattern[i].RunParams.RunAlgorithm = CogSearchMaxRunAlgorithmConstants.Standard;
                            }

                            Pattern[i].RunParams.AcceptThreshold = Main.DEFINE.DEFAULT_ACCEPT_SCORE;
                            Pattern[i].RunParams.ConfusionThreshold = Main.DEFINE.DEFAULT_CONFUSION_SCORE;
                           
//                             if (Main.AlignUnit[m_PatAlign_No].m_AlignName == "CHIP_PRE" && m_PatNo == Main.DEFINE.TAR_L)
//                             {
//                                 Pattern[i].RunParams.ZoneUsePattern = true;
//                             }
//                             else
                                Pattern[i].RunParams.ZoneUsePattern = false;

                                if (Main.AlignUnit[m_PatAlign_No].m_AlignName == "CHIP_PRE")
                                {
                                    Pattern[i].RunParams.ContrastEnabled = true;
                                    Pattern[i].RunParams.ContrastRangeLow = 0.5;
                                    Pattern[i].RunParams.ContrastRangeHigh = 1.3;
                                }

                            Pattern[i].RunParams.ZoneAngle.Configuration = CogSearchMaxZoneConstants.LowHigh;
                            Pattern[i].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Temp_Angle);
                            Pattern[i].RunParams.ZoneAngle.High = (Main.DEFINE.radian * Temp_Angle);
                            Pattern[i].RunParams.ZoneScale.Configuration = CogSearchMaxZoneConstants.Nominal;
                            Pattern[i].RunParams.TimeoutEnabled = true;
                            Pattern[i].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }
                    } 
                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        PatFileName = ModelDir + ProjectName + "\\" + m_PatternName + "_" + "G" + i.ToString() + ".vpp";
                        try
                        {
                            GPattern[i].Dispose();
                            GPattern[i] = CogSerializer.LoadObjectFromFile(PatFileName) as CogPMAlignTool;
                            GPattern[i].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;

                            GPattern[i].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Temp_Angle);
                            GPattern[i].RunParams.ZoneAngle.High = (Main.DEFINE.radian * Temp_Angle);
                            GPattern[i].RunParams.TimeoutEnabled = true;
                            GPattern[i].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());

                            GPattern[i] = new CogPMAlignTool();
                            GPattern[i].Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatMaxHighSensitivity;
                            GPattern[i].SearchRegion = new CogRectangle();
                            (GPattern[i].SearchRegion as CogRectangle).SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);

                            GPattern[i].RunParams.ScoreUsingClutter = false;
                            GPattern[i].RunParams.AcceptThreshold = Main.DEFINE.DEFAULT_GACCEPT_SCORE;
                            GPattern[i].RunParams.TimeoutEnabled = true;
                            GPattern[i].RunParams.Timeout = Main.DEFINE.PATTERN_TIMEOUT;

                            GPattern[i].RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                            GPattern[i].RunParams.ZoneAngle.Low = -(Main.DEFINE.radian * Temp_Angle);
                            GPattern[i].RunParams.ZoneAngle.High = (Main.DEFINE.radian * Temp_Angle);                           
                            GPattern[i].RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                            GPattern[i].RunParams.SaveMatchInfo = true;
                            GPattern[i].LastRunRecordDiagEnable = CogPMAlignLastRunRecordDiagConstants.InputImageByReference | CogPMAlignLastRunRecordDiagConstants.ResultsMatchFeatures;
                        }
                    }

                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        buf = "PATUSE" + i.ToString();
                        Pattern_USE[i] = ModelFile.GetBData(m_PatternName, buf);
                        if (i == Main.DEFINE.MAIN) Pattern_USE[i] = true;
                    }

                    buf = "ACCEPT_SCORE";
                    double ntemp;
                    ntemp = ModelFile.GetFData(m_PatternName, buf);
                    if (ntemp != 0)
                        m_ACCeptScore = ntemp;

                    buf = "ACCEPT_GSCORE";
                    ntemp = ModelFile.GetFData(m_PatternName, buf);
                    if (ntemp != 0)
                        m_GACCeptScore = ntemp;

                    buf = "CALIPER_MARKUSE";
                    Caliper_MarkUse = ModelFile.GetBData(m_PatternName, buf);

                    buf = "BLOB_MARKUSE";
                    Blob_MarkUse = ModelFile.GetBData(m_PatternName, buf);

                    buf = "BLOB_CALIPERUSE";
                    Blob_CaliperUse = ModelFile.GetBData(m_PatternName, buf);

                    buf = "BLOB_INSPECT_CNT";
                    m_Blob_InspCnt = ModelFile.GetIData(m_PatternName, buf);

                    buf = "FINDLINE_MARKUSE";
                    FINDLine_MarkUse = ModelFile.GetBData(m_PatternName, buf);

                    buf = "CIRCLE_MARKUSE";
                    Circle_MarkUse = ModelFile.GetBData(m_PatternName, buf);

#region CALIPER
                    string m_CaliName;
                    for (int i = 0; i < Main.DEFINE.CALIPER_MAX; i++)
                    {
                        m_CaliName = m_PatternName + "_CALIPER";
                        buf = "CALIPER_CENTERX" + i.ToString();
                        CaliperTools[i].Region.CenterX = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_CENTERY" + i.ToString();
                        CaliperTools[i].Region.CenterY = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_SIZEX" + i.ToString();
                        if (ModelFile.GetFData(m_CaliName, buf) <= 0)
                        {
                            CaliperTools[i].Region.SideXLength = 200;
                            CaliperTools[i].Region.CenterX = vision.IMAGE_CENTER_X[m_CamNo];
                        }
                        else CaliperTools[i].Region.SideXLength = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_SIZEY" + i.ToString();
                        if (ModelFile.GetFData(m_CaliName, buf) <= 0)
                        {
                            CaliperTools[i].Region.SideYLength = 200;
                            CaliperTools[i].Region.CenterY = vision.IMAGE_CENTER_Y[m_CamNo];
                        }
                        else CaliperTools[i].Region.SideYLength = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_THRESHOLD" + i.ToString();
                        CaliperTools[i].RunParams.ContrastThreshold = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_DIRECTION" + i.ToString();
                        CaliperTools[i].Region.Rotation = ModelFile.GetFData(m_CaliName, buf);// * 90 * Main.DEFINE.radian;

                        buf = "CALIPER_POLARLITY" + i.ToString();
                        if (ModelFile.GetIData(m_CaliName, buf) == 0)
                            CaliperTools[i].RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight; // 1-> 기본
                        else
                            CaliperTools[i].RunParams.Edge0Polarity = (CogCaliperPolarityConstants)ModelFile.GetIData(m_CaliName, buf);

                        buf = "CALIPER_EDGE_MODE" + i.ToString();
                        if (ModelFile.GetIData(m_CaliName, buf) == 0)
                            CaliperTools[i].RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;      // 기본값 설정 
                        else
                            CaliperTools[i].RunParams.EdgeMode = (CogCaliperEdgeModeConstants)ModelFile.GetIData(m_CaliName, buf);

                        buf = "CALIPER_POSITION_0" + i.ToString();
                        CaliperTools[i].RunParams.Edge0Position = ModelFile.GetFData(m_CaliName, buf);

                        buf = "CALIPER_POSITION_1" + i.ToString();
                        if (ModelFile.GetFData(m_CaliName, buf) == 0)
                            CaliperTools[i].RunParams.Edge1Position = 100;
                        else
                            CaliperTools[i].RunParams.Edge1Position = ModelFile.GetFData(m_CaliName, buf);

                        if (Main.GetCaliperPairMode(CaliperTools[i].RunParams.EdgeMode))
                        {
                            Main.SetCaliperPairPolarity(CaliperTools[i]);
                        }

                        buf = "CALIPER_USE" + i.ToString();
                        CaliperPara[i].m_UseCheck = ModelFile.GetBData(m_CaliName, buf);

                        buf = "Caliper FilterHSPixel" + i.ToString();
                        if (ModelFile.GetIData(m_CaliName, buf) == 0)
                            CaliperTools[i].RunParams.FilterHalfSizeInPixels = 2; //2기본
                        else
                            CaliperTools[i].RunParams.FilterHalfSizeInPixels = ModelFile.GetIData(m_CaliName, buf);


                        buf = "CALIPER_COP_MODE" + i.ToString();
                        CaliperPara[i].m_bCOPMode = ModelFile.GetBData(m_CaliName, buf);

                        buf = "CALIPER_COP_DVDCOUNT" + i.ToString();
                        CaliperPara[i].m_nCOPROICnt = ModelFile.GetIData(m_CaliName, buf);

                        buf = "CALIPER_COP_DVDOFFSET" + i.ToString();
                        CaliperPara[i].m_nCOPROIOffset = ModelFile.GetIData(m_CaliName, buf);

                        CaliperTools[i].Region.SelectedSpaceName = ".";
                        CaliperTools[i].LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.TransformedRegionPixels;
                        CaliperTools[i].LastRunRecordEnable = CogCaliperLastRunRecordConstants.FilteredProjectionGraph | CogCaliperLastRunRecordConstants.Edges2;

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            CaliperPara[i].m_TargetToCenter[k].X = ModelFile.GetFData(m_CaliName, buf);

                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            CaliperPara[i].m_TargetToCenter[k].Y = ModelFile.GetFData(m_CaliName, buf);
                        }

                    }
#endregion

#region BLOB 수정한거
                    CogRectangleAffine BlobRegion;
                    string m_BlobName;
                    for (int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
                    {
                        BlobRegion = new CogRectangleAffine();
                        double nCenterX, nCenterY, nWidth, nHeight, nRotation, nSkew;

                        m_BlobName = m_PatternName + "_BLOB";

                        buf = "BLOBUSE" + i.ToString();
                        BlobPara[i].m_UseCheck = ModelFile.GetBData(m_BlobName, buf);

                        buf = "BLOBREGION_CENTERX" + i.ToString();
                        nCenterX = ModelFile.GetFData(m_BlobName, buf);

                        buf = "BLOBREGION_CENTERY" + i.ToString();
                        nCenterY = ModelFile.GetFData(m_BlobName, buf);

                        buf = "BLOBREGION_WIDTH" + i.ToString();
                        nWidth = ModelFile.GetFData(m_BlobName, buf);

                        buf = "BLOBREGION_HEIGHT" + i.ToString();
                        nHeight = ModelFile.GetFData(m_BlobName, buf);

                        buf = "BLOBREGION_ROTATION" + i.ToString();
                        nRotation = ModelFile.GetFData(m_BlobName, buf);

                        buf = "BLOBREGION_SKEW" + i.ToString();
                        nSkew = ModelFile.GetFData(m_BlobName, buf);

                        if (nWidth == 0 || nHeight == 0)
                            BlobRegion.SetCenterLengthsRotationSkew(vision.IMAGE_CENTER_X[m_CamNo], vision.IMAGE_CENTER_Y[m_CamNo], 200, 200, 0, 0);
                        else
                            BlobRegion.SetCenterLengthsRotationSkew(nCenterX, nCenterY, nWidth, nHeight, nRotation, nSkew);

                        /// Select Use ///---------------------------------------------------------
                        BlobTools[i].Region = new CogRectangleAffine(BlobRegion);

                        buf = "BLOB_POLARITY" + i.ToString();
                        BlobTools[i].RunParams.SegmentationParams.Polarity = (CogBlobSegmentationPolarityConstants)ModelFile.GetIData(m_BlobName, buf);

                        buf = "BLOB_MINPIXELS" + i.ToString();
                        BlobTools[i].RunParams.ConnectivityMinPixels = ModelFile.GetIData(m_BlobName, buf);

                        buf = "BLOB_THRESHOLD" + i.ToString();
                        BlobTools[i].RunParams.SegmentationParams.HardFixedThreshold = ModelFile.GetIData(m_BlobName, buf);

                        BlobTools[i].RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;

                        BlobTools[i].RunParams.MorphologyOperations.Clear();
                        BlobTools[i].RunParams.MorphologyOperations.Add(CogBlobMorphologyConstants.ErodeSquare);   //사각형침식
                        BlobTools[i].RunParams.MorphologyOperations.Add(CogBlobMorphologyConstants.DilateSquare);  //사각형확장  
                        BlobTools[i].LastRunRecordEnable = CogBlobLastRunRecordConstants.ResultsBoundary | CogBlobLastRunRecordConstants.BlobImageAsGraphic | CogBlobLastRunRecordConstants.ResultsCenterOfMass;

                        BlobTools[i].RunParams.RunTimeMeasures.Clear();
                        CogBlobMeasure[] nItem = new CogBlobMeasure[3];
                        for (int j = 0; j < nItem.Length; j++)
                        {
                            nItem[j] = new CogBlobMeasure();
                        }
                        nItem[0].Measure = CogBlobMeasureConstants.Area;
                        BlobTools[i].RunParams.RunTimeMeasures.Add(nItem[0]);

                        nItem[1].Measure = CogBlobMeasureConstants.CenterMassX;
                        BlobTools[i].RunParams.RunTimeMeasures.Add(nItem[1]);

                        nItem[2].Measure = CogBlobMeasureConstants.CenterMassY;
                        BlobTools[i].RunParams.RunTimeMeasures.Add(nItem[2]);

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            BlobPara[i].m_TargetToCenter[k].X = ModelFile.GetFData(m_BlobName, buf);

                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            BlobPara[i].m_TargetToCenter[k].Y = ModelFile.GetFData(m_BlobName, buf);
                        }
                    }
#endregion

#region FINDLine
                    buf = "TRAY_GUIDE_DIS_X";
                    TRAY_GUIDE_DISX = ModelFile.GetFData(m_PatternName, buf);

                    buf = "TRAY_GUIDE_DIS_Y";
                    TRAY_GUIDE_DISY = ModelFile.GetFData(m_PatternName, buf);

                    buf = "TRAY_PITCH_DIS_X";
                    TRAY_PITCH_DISX = ModelFile.GetFData(m_PatternName, buf);

                    buf = "TRAY_PITCH_DIS_Y";
                    TRAY_PITCH_DISY = ModelFile.GetFData(m_PatternName, buf);

                    string m_FINDLineName, m_LineMaxName;
                    double StartX, StartY, LengTh, Direction;

                    for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                    {
                        for (int i = 0; i < Main.DEFINE.FINDLINE_MAX; i++)
                        {
                            m_FINDLineName = m_PatternName + "_FINDLine_" + ii.ToString();
                            buf = "FINDLINE_STARTX" + i.ToString();
                            StartX = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_STARTY" + i.ToString();
                            StartY = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_LENGTH" + i.ToString();
                            LengTh = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_DIRECTION" + i.ToString();
                            Direction = ModelFile.GetFData(m_FINDLineName, buf);

                            if (LengTh < 1)
                            {
                                StartX = vision.IMAGE_CENTER_X[m_CamNo];
                                StartY = vision.IMAGE_CENTER_Y[m_CamNo];
                                LengTh = vision.IMAGE_CENTER_X[m_CamNo];
                                Direction = 0;
                            }
                            else
                                FINDLineTools[ii, i].RunParams.ExpectedLineSegment.SetStartLengthRotation(StartX, StartY, LengTh, Direction);

                            buf = "FINDLINE_CALIPER_CNT" + i.ToString();
                            if (ModelFile.GetIData(m_FINDLineName, buf) <= 0)
                            {
                                FINDLineTools[ii, i].RunParams.NumCalipers = 16;
                            }
                            else FINDLineTools[ii, i].RunParams.NumCalipers = ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_NUMTOLGNORE" + i.ToString();
                            if (ModelFile.GetIData(m_FINDLineName, buf) <= 0)
                            {
                                FINDLineTools[ii, i].RunParams.NumToIgnore = 8;
                            }
                            else FINDLineTools[ii, i].RunParams.NumToIgnore = ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPERX" + i.ToString();
                            if (ModelFile.GetFData(m_FINDLineName, buf) <= 0)   // Caliper X
                            {
                                FINDLineTools[ii, i].RunParams.CaliperProjectionLength = 100;
                            }
                            else FINDLineTools[ii, i].RunParams.CaliperProjectionLength = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPERY" + i.ToString();
                            if (ModelFile.GetFData(m_FINDLineName, buf) <= 0)   // Caliper Y
                            {
                                FINDLineTools[ii, i].RunParams.CaliperSearchLength = 400;
                            }
                            else FINDLineTools[ii, i].RunParams.CaliperSearchLength = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_THRESHOLD" + i.ToString();
                            if (ModelFile.GetFData(m_FINDLineName, buf) <= 0)
                            {
                                FINDLineTools[ii, i].RunParams.CaliperRunParams.ContrastThreshold = 10;
                            }
                            else FINDLineTools[ii, i].RunParams.CaliperRunParams.ContrastThreshold = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_POLARLITY" + i.ToString();
                            if (ModelFile.GetIData(m_FINDLineName, buf) == 0) FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)2; // 1-> 기본
                            else FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_USE" + i.ToString();
                            FINDLinePara[ii, i].m_UseCheck = ModelFile.GetBData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_PAIR_USE" + i.ToString();
                            FINDLinePara[ii, i].m_UsePairCheck = ModelFile.GetBData(m_FINDLineName, buf);
                            if (FINDLinePara[ii, i].m_UsePairCheck)
                                FINDLineTools[ii, i].RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;

                            buf = "FINDLINE_CALIPER_POLARLITY_1" + i.ToString();
                            if (ModelFile.GetIData(m_FINDLineName, buf) == 0) FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge1Polarity = (CogCaliperPolarityConstants)1; // 1-> 기본
                            else FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge1Polarity = (CogCaliperPolarityConstants)ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_FINDLine1POS" + i.ToString();    //Pos 간격 이하만 찾아라.
                            FINDLineTools[ii, i].RunParams.CaliperRunParams.Edge1Position = ModelFile.GetFData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_FINDLineMODE" + i.ToString();
                            if (ModelFile.GetIData(m_FINDLineName, buf) == 0) FINDLineTools[ii, i].RunParams.CaliperRunParams.EdgeMode = (CogCaliperEdgeModeConstants)1; // 1-> 기본
                            else FINDLineTools[ii, i].RunParams.CaliperRunParams.EdgeMode = (CogCaliperEdgeModeConstants)ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_SEARCHDIRECTION" + i.ToString();
                            try
                            {
                                FINDLineTools[ii, i].RunParams.CaliperSearchDirection = ModelFile.GetFData(m_FINDLineName, buf);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            buf = "FINDLINE_FILTERHALFSIZE" + i.ToString();
                            FINDLineTools[ii, i].RunParams.CaliperRunParams.FilterHalfSizeInPixels = (ModelFile.GetIData(m_FINDLineName, buf) < 1) ? 2 : ModelFile.GetIData(m_FINDLineName, buf);

                            buf = "FINDLINE_CALIPER_METHOD" + i.ToString();
                            FINDLineTools[ii, i].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                            FINDLinePara[ii, i].m_LineCaliperMethod = ModelFile.GetIData(m_FINDLineName, buf);

                            if (FINDLinePara[ii, i].m_LineCaliperMethod == DEFINE.CLP_METHOD_SCORE)
                            {
                                CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                                scorer.Enabled = true;
                                FINDLineTools[ii, i].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                            }
                            else if (FINDLinePara[ii, i].m_LineCaliperMethod == DEFINE.CLP_METHOD_POS)
                            {
                                CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                                scorer.Enabled = true;
                                FINDLineTools[ii, i].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                            }

                            FINDLineTools[ii, i].RunParams.ExpectedLineSegment.SelectedSpaceName = ".";
                            FINDLineTools[ii, i].LastRunRecordDiagEnable = CogFindLineLastRunRecordDiagConstants.TransformedRegionPixels;
                            FINDLineTools[ii, i].LastRunRecordEnable = CogFindLineLastRunRecordConstants.BestFitLineSegment | CogFindLineLastRunRecordConstants.FoundEdges;

                            for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                            {
                                buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                                FINDLinePara[ii, i].m_TargetToCenter[k].X = ModelFile.GetFData(m_FINDLineName, buf);
                                buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                                FINDLinePara[ii, i].m_TargetToCenter[k].Y = ModelFile.GetFData(m_FINDLineName, buf);

                                buf = "TARGET_TO_CENTER_2X" + i.ToString() + "_" + k.ToString();
                                FINDLinePara[ii, i].m_TargetToCenter[k].X2 = ModelFile.GetFData(m_FINDLineName, buf);
                                buf = "TARGET_TO_CENTER_2Y" + i.ToString() + "_" + k.ToString();
                                FINDLinePara[ii, i].m_TargetToCenter[k].Y2 = ModelFile.GetFData(m_FINDLineName, buf);
                            }

                            //==================== LINEMAX ====================//
                            m_LineMaxName = m_PatternName + "_LineMax_" + ii.ToString();

                            buf = "LINEMAX_CENTERX" + i.ToString();
                            (LineMaxTools[ii, i].Region as CogRectangleAffine).CenterX = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_CENTERY" + i.ToString();
                            (LineMaxTools[ii, i].Region as CogRectangleAffine).CenterY = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_EXPLINE_ANGLE" + i.ToString();
                            LineMaxTools[ii, i].RunParams.ExpectedLineNormal.Angle = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_GRAKERNEL_SIZE" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels = 2;
                            else LineMaxTools[ii, i].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_PROJECTION_LENGTH" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ProjectionLengthInPixels = 10;
                            else LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ProjectionLengthInPixels = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_CONTRAST_THRES" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ContrastThreshold = 5;
                            else LineMaxTools[ii, i].RunParams.EdgeDetectionParams.ContrastThreshold = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_POLARITY" + i.ToString();
                            if (ModelFile.GetIData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.Polarity = CogLineMaxPolarityConstants.LightToDark;
                            else LineMaxTools[ii, i].RunParams.Polarity = (CogLineMaxPolarityConstants)ModelFile.GetIData(m_LineMaxName, buf);

                            buf = "LINEMAX_EDGE_ANGLE_TOL" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.EdgeAngleTolerance = 5 * DEFINE.radian;
                            else LineMaxTools[ii, i].RunParams.EdgeAngleTolerance = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_EDGE_DIST_TOL" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.DistanceTolerance = 1;
                            else LineMaxTools[ii, i].RunParams.DistanceTolerance = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_MAX_LINES" + i.ToString();
                            if (ModelFile.GetIData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.MaxNumLines = 1;
                            else LineMaxTools[ii, i].RunParams.MaxNumLines = ModelFile.GetIData(m_LineMaxName, buf);

                            buf = "LINEMAX_LINE_ANGLE_TOL" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) <= 0) LineMaxTools[ii, i].RunParams.LineAngleTolerance = 5 * DEFINE.radian;
                            else LineMaxTools[ii, i].RunParams.LineAngleTolerance = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_COVERAGE_THRES" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) < 0) LineMaxTools[ii, i].RunParams.CoverageThreshold = 0.5;
                            else LineMaxTools[ii, i].RunParams.CoverageThreshold = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_LENGTH_THRES" + i.ToString();
                            if (ModelFile.GetFData(m_LineMaxName, buf) < 0) LineMaxTools[ii, i].RunParams.LengthThreshold = 0;
                            else LineMaxTools[ii, i].RunParams.LengthThreshold = ModelFile.GetFData(m_LineMaxName, buf);

                            buf = "LINEMAX_HORIZONTAL_COND" + i.ToString();
                            FINDLinePara[ii, i].m_LineMaxHCond = ModelFile.GetIData(m_LineMaxName, buf);

                            buf = "LINEMAX_VERTICAL_COND" + i.ToString();
                            FINDLinePara[ii, i].m_LineMaxVCond = ModelFile.GetIData(m_LineMaxName, buf);
                        }
                    }
#endregion

#region CIRCLE
                    string m_CircleName;
                    for (int i = 0; i < Main.DEFINE.CIRCLE_MAX; i++)
                    {
                        m_CircleName = m_PatternName + "_CIRCLE";

                        buf = "CIRCLE_CENTERX" + i.ToString();
                        CircleTools[i].RunParams.ExpectedCircularArc.CenterX = ModelFile.GetFData(m_CircleName, buf);

                        buf = "CIRCLE_CENTERY" + i.ToString();
                        CircleTools[i].RunParams.ExpectedCircularArc.CenterY = ModelFile.GetFData(m_CircleName, buf);

                        buf = "CIRCLE_RADIUS" + i.ToString();
                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                            if (i == Main.DEFINE.VCM)
                                CircleTools[i].RunParams.ExpectedCircularArc.Radius = 90;
                            else
                                CircleTools[i].RunParams.ExpectedCircularArc.Radius = 55;
                        else
                            CircleTools[i].RunParams.ExpectedCircularArc.Radius = ModelFile.GetFData(m_CircleName, buf);

                        buf = "RUNPARAMS_NUMCALIPERTS" + i.ToString();
                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                            CircleTools[i].RunParams.NumCalipers = 15;
                        else
                            CircleTools[i].RunParams.NumCalipers = ModelFile.GetIData(m_CircleName, buf);


                        buf = "RUNPARAMS_SEARCHLENGTH" + i.ToString();
                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                        {
                            if (i == Main.DEFINE.VCM)
                                CircleTools[i].RunParams.CaliperSearchLength = 200;
                            else
                                CircleTools[i].RunParams.CaliperSearchLength = 100;
                        }
                        else
                            CircleTools[i].RunParams.CaliperSearchLength = ModelFile.GetFData(m_CircleName, buf);


                        buf = "RUNPARAMS_SEARCHDIRECTION" + i.ToString();
                        if (ModelFile.GetFData(m_CircleName, buf) == 0)
                            CircleTools[i].RunParams.CaliperSearchDirection = CogFindCircleSearchDirectionConstants.Inward;
                        else
                            CircleTools[i].RunParams.CaliperSearchDirection = CogFindCircleSearchDirectionConstants.Outward;

                        buf = "RUNPARAMS_PROJECTIONLENGTH" + i.ToString();

                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                            CircleTools[i].RunParams.CaliperProjectionLength = 30;
                        else
                            CircleTools[i].RunParams.CaliperProjectionLength = ModelFile.GetFData(m_CircleName, buf);

                        buf = "RUNPARAMS_RADIUSCONSTRAINT_ENABLE" + i.ToString();
                        CircleTools[i].RunParams.RadiusConstraintEnabled = ModelFile.GetBData(m_CircleName, buf);

                        buf = "RUNPARAMS_RADIUSCONSTRAINT" + i.ToString();
                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                            CircleTools[i].RunParams.RadiusConstraint = 70;
                        else
                            CircleTools[i].RunParams.RadiusConstraint = ModelFile.GetFData(m_CircleName, buf);

                        buf = "RUNPARAMS_NUMTOLGNORE" + i.ToString();

                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || ModelFile.GetFData(m_CircleName, buf) < 0)
                            CircleTools[i].RunParams.NumToIgnore = 5;
                        else
                            CircleTools[i].RunParams.NumToIgnore = ModelFile.GetIData(m_CircleName, buf);

                        buf = "RUNPARAMS_ANGLESTART" + i.ToString();

                        if (ModelFile.GetFData(m_CircleName, buf) < -180 || ModelFile.GetFData(m_CircleName, buf) > 179)
                            CircleTools[i].RunParams.ExpectedCircularArc.AngleStart = 0;
                        else
                            CircleTools[i].RunParams.ExpectedCircularArc.AngleStart = ModelFile.GetFData(m_CircleName, buf);

                        buf = "RUNPARAMS_ANGLESPAN" + i.ToString();

                        if (ModelFile.GetFData(m_CircleName, buf) == 0 || Math.Abs(ModelFile.GetFData(m_CircleName, buf)) > Math.PI)
                            CircleTools[i].RunParams.ExpectedCircularArc.AngleSpan = Math.PI / 2;
                        else
                            CircleTools[i].RunParams.ExpectedCircularArc.AngleSpan = ModelFile.GetFData(m_CircleName, buf);

                        buf = "CALIPER_THRESHOLD" + i.ToString();
                        if (ModelFile.GetIData(m_CircleName, buf) == 0)
                            CircleTools[i].RunParams.CaliperRunParams.ContrastThreshold = 7;
                        else
                            CircleTools[i].RunParams.CaliperRunParams.ContrastThreshold = ModelFile.GetFData(m_CircleName, buf);

                        buf = "CALIPER_EDGE_MODE" + i.ToString();
                        if (ModelFile.GetIData(m_CircleName, buf) == 0)
                            CircleTools[i].RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;      // 기본값 설정 
                        else
                            CircleTools[i].RunParams.CaliperRunParams.EdgeMode = (CogCaliperEdgeModeConstants)ModelFile.GetIData(m_CircleName, buf);

                        buf = "CALIPER_POLARLITY" + i.ToString();
                        if (ModelFile.GetIData(m_CircleName, buf) == 0)
                            CircleTools[i].RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight; // 1-> 기본
                        else
                            CircleTools[i].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)ModelFile.GetIData(m_CircleName, buf);

                        //                         buf = "CALIPER_POSITION_0" + i.ToString();
                        //                         CircleTools[i].RunParams.CaliperRunParams.Edge0Position = ModelFile.GetFData(m_CircleName, buf);
                        // 
                        //                         buf = "CALIPER_POSITION_1" + i.ToString();
                        //                         CircleTools[i].RunParams.CaliperRunParams.Edge1Position = ModelFile.GetFData(m_CircleName, buf);

                        buf = "CIRCLE_USE" + i.ToString();
                        CirclePara[i].m_UseCheck = ModelFile.GetBData(m_CircleName, buf);

                        buf = "CIRCLE_CALIPER_METHOD" + i.ToString();
                        CircleTools[i].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                        CirclePara[i].m_CircleCaliperMethod = ModelFile.GetIData(m_CircleName, buf);

                        if (CirclePara[i].m_CircleCaliperMethod == DEFINE.CLP_METHOD_SCORE)
                        {
                            CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                            scorer.Enabled = true;
                            CircleTools[i].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                        }
                        else if (CirclePara[i].m_CircleCaliperMethod == DEFINE.CLP_METHOD_POS)
                        {
                            CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                            scorer.Enabled = true;
                            CircleTools[i].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                        }

                        //CircleTools[i].RunParams.ExpectedCircularArc.AngleStart = 0;
                        ////CircleTools[i].RunParams.ExpectedCircularArc.AngleSpan = 6.28318530717959;
                        //CircleTools[i].RunParams.ExpectedCircularArc.AngleSpan = 3.141592;

                        CircleTools[i].LastRunRecordDiagEnable = CogFindCircleLastRunRecordDiagConstants.TransformedRegionPixels;
                        CircleTools[i].LastRunRecordEnable = CogFindCircleLastRunRecordConstants.FoundEdges | CogFindCircleLastRunRecordConstants.FilteredProjectionGraph;

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            buf = "TARGET_TO_CENTER_X" + i.ToString() + "_" + k.ToString();
                            CirclePara[i].m_TargetToCenter[k].X = ModelFile.GetFData(m_CircleName, buf);
                            buf = "TARGET_TO_CENTER_Y" + i.ToString() + "_" + k.ToString();
                            CirclePara[i].m_TargetToCenter[k].Y = ModelFile.GetFData(m_CircleName, buf);
                        }
                    }
#endregion
                }

            }

            public void SyetemLoad()
            {
                string buf;
                string result;
                for (int i = 0; i < Main.DEFINE.Light_Control_Max; i++)
                {
                    buf = "COM" + i.ToString();
                    SystemFile.GetSData(m_PatternName, buf);

                    result = System.Text.RegularExpressions.Regex.Replace(buf, @"[^0-9]", "");
                    LightControl.LightComport[i] = Convert.ToInt32(result);
                }
            }

            public void SaveCal()
            {
                string buf;
                for (int i = 0; i < 2; i++)
                {
                    buf = "CAL_X" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_CalX[i]);
                    buf = "CAL_Y" + i.ToString();
                    SystemFile.SetData(m_PatternName, buf, m_CalY[i]);
                }

                for (int i = 0; i < 9; i++)
                {
                    buf = "CALMATRIX" + i.ToString();
                    //                    if(!Main.DEFINE.OPEN_F)
                    SystemFile.SetData(m_PatternName, buf, CALMATRIX[i]);
                }
                buf = "CCD_T_X";
                SystemFile.SetData(m_PatternName, buf, CAMCCDTHETA[0, 0]);
                buf = "CCD_T_Y";
                SystemFile.SetData(m_PatternName, buf, CAMCCDTHETA[0, 1]);
            }
        }

    }// DataFileTag
    // ModelFile
}// COG
