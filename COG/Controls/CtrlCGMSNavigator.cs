using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace COG.Controls
{
    public partial class CtrlCGMSNavigator : UserControl
    {
        private int _columnCount = 0;
        private int _rowCount = 0;


        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        public CtrlCGMSNavigator(int row = 10, int column = 25)
        {
            InitializeComponent();
            SetMatrix(row, column);
        }

        private void SetMatrix(int row, int column)
        {
            _rowCount = row;
            _columnCount = column;
        }

        private void CtrlCGMSNavigator_Load(object sender, EventArgs e)
        {
            InitalizeUI();
        }

        private void InitalizeUI()
        {
            dgvNavigator.Rows.Clear();
            dgvNavigator.Columns.Clear();
            dgvNavigator.RowCount = _rowCount;
            dgvNavigator.ColumnCount = _columnCount;
            this.dgvNavigator.GridColor = Color.White;

            //dgvNavigator.Height = dgvNavigator.Width;
            dgvNavigator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Console.WriteLine("가로 사이즈 : " + dgvNavigator.Width.ToString());
            Console.WriteLine("세로 사이즈 : " + dgvNavigator.Height.ToString());

            dgvNavigator.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            Console.WriteLine("Row Header Width : " + dgvNavigator.RowHeadersWidth.ToString()); 


            Console.WriteLine("Column Height : " + dgvNavigator.RowTemplate.Height.ToString());
            dgvNavigator.RowTemplate.Height = 100;
            Console.WriteLine("Column Height : " + dgvNavigator.RowTemplate.Height.ToString());




            int index = 0;
            for (int rowCount = 0; rowCount < dgvNavigator.RowCount; rowCount++)
            {
                for (int columnCount = 0; columnCount < dgvNavigator.ColumnCount; columnCount++)
                {
                    index++;

                    dgvNavigator.Rows[rowCount].Cells[columnCount].Value = index.ToString("D3");
                }
            }
        }

        //public void OpenFormCGMSEnlargedImagePopup(int selectedIndex, int Row, int Col)
        //{
        //    if (_formCGMSEnlargedImagePopup == null)
        //    {
        //        _formCGMSEnlargedImagePopup = new FormCGMSEnlargedImagePopup(selectedIndex, Row, Col);
        //        _formCGMSEnlargedImagePopup.CloseEventDelegate = () => this._formCGMSEnlargedImagePopup = null;
        //        _formCGMSEnlargedImagePopup.ShowDialog();
        //    }
        //}

        private void dgvNavigator_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex * _columnCount + e.ColumnIndex;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            //OpenFormCGMSEnlargedImagePopup(selectedIndex, e.RowIndex, e.ColumnIndex);
            FormMain.Instance().CGMSViewerControl.UpdateDisplay(selectedIndex);
        }

        private delegate void UpdateGrabStatusDelegate(int row, int col);
        public void UpdateGrabStatus(int row, int col)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateGrabStatusDelegate callback = UpdateGrabStatus;
                    BeginInvoke(callback, row, col);
                    return;
                }

                UpdateUI(row, col);
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        //private void UpdateUI(int index)
        //{
        //    //double t1 = index / _rowCount;
        //    //double t2 = Math.Truncate(t1);
        //    //double t3 = index % _rowCount;

        //    int row = (int)(index / _columnCount);
        //    int col = (int)(index % _columnCount);

        //    //dgvNavigator.Rows[row].Cells[col]
        //    dgvNavigator[col, row].Style.BackColor = Color.Green;
        //    //for (int rowCount = 0; rowCount < dgvNavigator.RowCount; rowCount++)
        //    //{
        //    //    for (int columnCount = 0; columnCount < dgvNavigator.ColumnCount; columnCount++)
        //    //    {
        //    //        index++;

        //    //        dgvNavigator.Rows[rowCount].Cells[columnCount].Value = index.ToString("D3");
        //    //    }
        //    //}
        //}
        private void UpdateUI(int row, int col)
        {
            //double t1 = index / _rowCount;
            //double t2 = Math.Truncate(t1);
            //double t3 = index % _rowCount;

            //int row = (int)(index / _columnCount);
            //int col = (int)(index % _columnCount);

            //dgvNavigator.Rows[row].Cells[col]
            dgvNavigator[col, row].Style.BackColor = Color.Green;
            //for (int rowCount = 0; rowCount < dgvNavigator.RowCount; rowCount++)
            //{
            //    for (int columnCount = 0; columnCount < dgvNavigator.ColumnCount; columnCount++)
            //    {
            //        index++;

            //        dgvNavigator.Rows[rowCount].Cells[columnCount].Value = index.ToString("D3");
            //    }
            //}
        }

        //private void UpdateUI(int index)
        //{
        //    int row = (int)(index / _columnCount);
        //    int col = (int)(index % _columnCount);

        //    //dgvNavigator.Rows[row].Cells[col]
        //    //dgvNavigator[col, row].Style.BackColor = Color.Green;
        //    for (int rowCount = 0; rowCount < dgvNavigator.RowCount; rowCount++)
        //    {
        //        for (int columnCount = 0; columnCount < dgvNavigator.ColumnCount; columnCount++)
        //        {
        //            index++;

        //            dgvNavigator.Rows[rowCount].Cells[columnCount].Value = index.ToString("D3");
        //        }
        //    }
        //}

        public void ClearGrabStatus()
        {
            for (int rowCount = 0; rowCount < dgvNavigator.RowCount; rowCount++)
            {
                for (int columnCount = 0; columnCount < dgvNavigator.ColumnCount; columnCount++)
                    dgvNavigator[columnCount, rowCount].Style.BackColor = Color.Gray;
            }
        }
    }
}
