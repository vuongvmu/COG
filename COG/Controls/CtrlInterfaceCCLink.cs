using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COG.Controls
{
    public partial class CtrlInterfaceCCLink : UserControl
    {
        private const int ROWCOUNT = 16;
        private string _title = "";
        private Dictionary<string, string> _dictionaryData = new Dictionary<string, string>();

        private List<Dictionary<string, string>> _dictionaryDataList = new List<Dictionary<string, string>>();

        private List<CtrlInterfaceCCLinkAddress> _addressControlList = new List<CtrlInterfaceCCLinkAddress>();
        private List<List<CtrlInterfaceCCLinkAddress>> _pageAddressControlList = new List<List<CtrlInterfaceCCLinkAddress>>();

        public CtrlInterfaceCCLink(string title, Dictionary<string, string> dictionaryData)
        {
            InitializeComponent();

            _title = title;
            _dictionaryData = dictionaryData;
        }

        private void CtrlInterfaceCCLink_Load(object sender, EventArgs e)
        {
            SeperateData(_dictionaryData);

            InitializeUI();
            AddControl();

            UpdateControl();
        }

        private bool _isEnable = false;
        private void InitializeUI()
        {
            lblSubject.Text = _title;

            int gg, tt;

            // PLC 입장에서 X가 아웃풋이므로 우리는 X가 인풋
            if (_title.ToLower().Contains("bx") || _title.ToLower().Contains("wr"))
                _isEnable = false;
            else
                _isEnable = true;
        }

        private void AddControl()
        {
            for (int pageCount = 0; pageCount < _dictionaryDataList.Count; pageCount++) // 8
            {
                List<CtrlInterfaceCCLinkAddress> addressList = new List<CtrlInterfaceCCLinkAddress>();

                for (int listCount = 0; listCount < _dictionaryDataList[pageCount].Count; listCount++)  // 16
                {
                    string name = _dictionaryDataList[pageCount].ToList()[listCount].Key.ToString();
                    string caption = _dictionaryDataList[pageCount].ToList()[listCount].Value.ToString();

                    CtrlInterfaceCCLinkAddress addressControl = new CtrlInterfaceCCLinkAddress(name, caption, _isEnable);
                    addressControl.Dock = DockStyle.Fill;
                    addressList.Add(addressControl);
                }

                _pageAddressControlList.Add(addressList);
            }

            tlpAddress.RowStyles.Clear();
            tlpAddress.ColumnStyles.Clear();

            tlpAddress.RowCount = 16;
            tlpAddress.ColumnCount = 1;

            for (int rowIndex = 0; rowIndex < tlpAddress.RowCount; rowIndex++)
                tlpAddress.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlpAddress.RowCount)));

            for (int columnIndex = 0; columnIndex < tlpAddress.ColumnCount; columnIndex++)
                tlpAddress.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / tlpAddress.ColumnCount)));
        }

        private void SeperateData(Dictionary<string, string> originData)
        {
            int page = Convert.ToInt32(Math.Ceiling((double)(originData.Count / 16)));

            _dictionaryDataList = new List<Dictionary<string, string>>();

            for (int i = 0; i < page; i++)
                _dictionaryDataList.Add(new Dictionary<string, string>());

            int index = 0;
            int loop = 0;

            foreach (KeyValuePair<string, string> item in originData)
            {
                if (index >= 16)
                {
                    loop++;
                    index = 0;
                }

                _dictionaryDataList[loop].Add(item.Key, item.Value);
                index++;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowPrevPage();
        }

        private int _pageNo = 0;
        private void ShowPrevPage()
        {
            if (_pageNo <= 0)
                _pageNo = 0;
            else
            {
                _pageNo--;
                UpdateControl(_pageNo);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowNextPage();
        }

        private void ShowNextPage()
        {
            if (_pageNo >= (_dictionaryDataList.Count - 1))
                _pageNo = _dictionaryDataList.Count - 1;
            else
            {
                _pageNo++;
                UpdateControl(_pageNo);
            }
        }

        private void UpdateControl(int pageNo = 0)
        {
            this.tlpAddress.Controls.Clear();

            for (int i = 0; i < 16; i++)
            {
                //this.tlpAddress.RowStyles.Clear();
                
                this.tlpAddress.Controls.Add(_pageAddressControlList[pageNo][i], i, 0);
                _pageAddressControlList[pageNo][i].Tag = i;
            }

            lblPage.Text = (pageNo + 1).ToString() + " / " + (_dictionaryData.Count / tlpAddress.RowCount).ToString();
        }
    }
}
