using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace COG
{
    public partial class Form_Project : Form
    {
        public Form_Project()
        {
            InitializeComponent();
        }

        private void Form_Project_Load(object sender, EventArgs e)
        {
            GetModelList();
           
        }
        private void DataUpdate()
        {
            LB_DISPLAY_CURRENT.Text = Main.ProjectName + " - " + Main.ProjectInfo;
        }
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);
        private void GetModelList()
        {
            int index;
            string nName;
            string nDir;
            listModel.Items.Clear();
            if (Directory.Exists(Main.ModelPath))
            {
                string[] arrModel = Directory.GetDirectories(Main.ModelPath);
                for (int i = 0; i < arrModel.Length; i++)
                {
                    DirectoryInfo DI = new DirectoryInfo(arrModel[i]);


                    StringBuilder temp = new StringBuilder(80);
                    nDir = Main.ModelPath + DI.Name + "\\Model.ini";
                    GetPrivateProfileString("PROJECT", "NAME", " ", temp, 80, nDir);
                    nName = DI.Name + temp.ToString();
                    listModel.Items.Add(nName);
                }
            }
            index = listModel.FindString(Main.ProjectName);
            listModel.SelectedIndex = index;
            DataUpdate();
        }

 

        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LB_DISPLAY_SELECTE.Text = listModel.SelectedItem.ToString();
        }

        private void BTN_DELETE_Click(object sender, EventArgs e)
        {

            Form_Password formpassword = new Form_Password(false);
            formpassword.ShowDialog();

            if (!formpassword.LOGINOK)
            {
                formpassword.Dispose();
                return;
            }
            formpassword.Dispose();

            string modelName = LB_DISPLAY_SELECTE.Text;
            string nName;
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Delete " + modelName + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (modelName == "")
                    {
                        MessageBox.Show("Model is not Selected", "error");
                        return;
                    }
                    if (LB_DISPLAY_SELECTE.Text == LB_DISPLAY_CURRENT.Text)
                    {
                        MessageBox.Show("Current models can not be deleted", "error");
                        return;
                    }
                    nName = String.Format("{0:000}", LB_DISPLAY_SELECTE.Text.ToString().Substring(0, 3));
                    modelName = nName;
                    FileDeleteAll(modelName);
                    Directory.Delete(Main.ModelPath + modelName);

                    GetModelList();
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Delete Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }
        private void FileDeleteAll(string _modelName)
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
                MessageBox.Show("Source Or Dest Path  Not Exist", "Error");
                return;
            }

        }
        private void BTN_LOAD_Click(object sender, EventArgs e)
        {
            string selectModel;
            string nName;

            DialogResult result = MessageBox.Show("Do you want to Load?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                nName =  String.Format("{0:000}",listModel.SelectedItem.ToString().Substring(0,3));
                selectModel = nName;
                if (selectModel == Main.ProjectName)
                {
                    MessageBox.Show("Current Model", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GetModelList();
                Main.ProjectLoad(selectModel);
                DataUpdate();
                Main.SystemLoad();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Load Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Save?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string m_SaveName;
                string m_SaveInfo;
                Form_KeyBoard formkeyboard_Name = new Form_KeyBoard("INPUT PROJECT CODE( 0 ~ 999)", 0);
                formkeyboard_Name.ShowDialog();
                if (formkeyboard_Name.m_ResultString != "")
                {
                    m_SaveName = string.Format("{0:000}", Convert.ToInt16(formkeyboard_Name.m_ResultString));
                }
                else
                {
                    m_SaveName = "";
                }
                if (m_SaveName == "" || m_SaveName == Main.ProjectName)
                {
                    if (m_SaveName == Main.ProjectName)
                    {
                        MessageBox.Show("Project name Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show("Enter the Project name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Form_KeyBoard formkeyboard_Info = new Form_KeyBoard("INPUT PROJECT NAME");
                formkeyboard_Info.ShowDialog();
                m_SaveInfo = formkeyboard_Info.m_ResultString;
                m_SaveInfo = "_" + m_SaveInfo;


                Main.ProjectSave(m_SaveName, m_SaveInfo);
                Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.CURRENT_MODEL_CODE, Convert.ToInt16(Main.ProjectName));
                GetModelList();

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Save Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTN_UP_Click(object sender, EventArgs e)
        {
            int index = 0;

            index = listModel.SelectedIndex;

            if (index > 0)
                listModel.SelectedIndex = index - 1;
        }

        private void BTN_DOWN_Click(object sender, EventArgs e)
        {
            int index = 0;

            index = listModel.SelectedIndex;

            if (index < listModel.Items.Count - 1)
                listModel.SelectedIndex = index + 1;
        }

        private void BTN_RENAME_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Rename?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string m_SaveName;
                string m_SaveInfo;
                string m_SaveInfoBack;
                m_SaveName = LB_DISPLAY_SELECTE.Text.Substring(0, 3);
                m_SaveInfo = m_SaveInfoBack = LB_DISPLAY_SELECTE.Text.Substring(3, LB_DISPLAY_SELECTE.Text.Length - 3);
                Form_KeyBoard formkeyboard_Info = new Form_KeyBoard("INPUT PROJECT NAME", 1, m_SaveInfo);
                formkeyboard_Info.ShowDialog();
                m_SaveInfo = formkeyboard_Info.m_ResultString;

                if (m_SaveInfo == "" || Main.ProjectName == "")
                {
                    MessageBox.Show("Enter the Project name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ( m_SaveInfo == m_SaveInfoBack)
                {
                    //전에 이름 이랑 같으면 리턴
                    return;
                }

                bool nRet;
                nRet =  Main.ProjectRename(m_SaveName, m_SaveInfo);
                GetModelList();

                if ((m_SaveName == Main.ProjectName) && nRet)
                {
                    Main.ProjectInfo = m_SaveInfo;
                    DataUpdate();
                }

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Rename Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTN_COPY_Click(object sender, EventArgs e)
        {
            //현재 모델을 다른 번호, 이름으로 복사해주는 기능
            string strCurModelNum;
            string strTargetNum;
            string strCurName;
            string strTargetName;

            DialogResult result = MessageBox.Show("Do you want to Copy?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                strCurModelNum = String.Format("{0:000}", listModel.SelectedItem.ToString().Substring(0, 3));

                //복사할 모델의 번호
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 999, Convert.ToInt32(strCurModelNum), "Input Target Copy Number", 1))
                {
                    int ntmpData;
                    form_keypad.ShowDialog();
                    ntmpData = (int)form_keypad.m_data;
                    strTargetNum = ntmpData.ToString("D3");
                }
                strCurName = LB_DISPLAY_SELECTE.Text.Substring(3, LB_DISPLAY_SELECTE.Text.Length - 3);
                Form_KeyBoard formkeyboard_Info = new Form_KeyBoard("INPUT PROJECT NAME", 1, strCurName);
                formkeyboard_Info.ShowDialog();
                strTargetName = formkeyboard_Info.m_ResultString;

                if (strTargetName == "" || Main.ProjectName == "")
                {
                    MessageBox.Show("Enter the Project name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (strTargetNum == Main.ProjectName)
                {
                    MessageBox.Show("current number and target number are the same. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool nRet;
                nRet = Main.ProjectRename(strTargetNum, strTargetName);
                if(!nRet)
                {
                    MessageBox.Show("Copy Cancel", "Input Name Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Main.ProjectCopy(strCurModelNum, strTargetNum);
                GetModelList();
                Main.ProjectLoad(strTargetNum);
                DataUpdate();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Copy Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTN_RECIPE_Click(object sender, EventArgs e)
        {
            int nModelNumber;
            string modelName = LB_DISPLAY_SELECTE.Text;
            nModelNumber = Convert.ToInt32(String.Format("{0:000}", LB_DISPLAY_SELECTE.Text.ToString().Substring(0, 3)));
            FormRecipe recipeForm = new FormRecipe(nModelNumber);
            recipeForm.ShowDialog();
        }

        private void BTN_CREATE_Click(object sender, EventArgs e)
        {
            string strCurModelNum;
            string strCurName;
            string strTargetNum;
            string strTargetName;

            if (listModel.SelectedItem == null)
            {
                strCurModelNum = "001";
                strCurName = "DEFAULT";
            }
            else
            {
                strCurModelNum = String.Format("{0:000}", listModel.SelectedItem.ToString().Substring(0, 3));
                strCurName = LB_DISPLAY_SELECTE.Text.Substring(3, LB_DISPLAY_SELECTE.Text.Length - 3);
            } 
            //모델번호 입력
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 999, Convert.ToInt32(strCurModelNum), "Input Create Model Number", 1))
            {
                int ntmpData;
                form_keypad.ShowDialog();
                ntmpData = (int)form_keypad.m_data;
                strTargetNum = ntmpData.ToString("D3");
            }
            //모델명 입력
            Form_KeyBoard formkeyboard_Info = new Form_KeyBoard("INPUT PROJECT NAME", 1, strCurName);
            formkeyboard_Info.ShowDialog();
            strTargetName = formkeyboard_Info.m_ResultString;

            //Default Model 폴더 및 Model.ini, Recipe.ini 생성
            bool bRet;
            bRet = Main.ProjectCreate(strTargetNum, strTargetName);
            if (!bRet)
            {
                MessageBox.Show("Create Cancel", "The Input Data is same number already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormRecipe recipeForm = new FormRecipe(Convert.ToInt32(strTargetNum));
            recipeForm.TopMost = true;
            recipeForm.ShowDialog();
            GetModelList();
        }
    }
}
