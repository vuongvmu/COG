using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;

namespace COG
{
    public partial class Main
    {
        public partial class Stage
        {
            private int nStagNo;
            private int nCamNo;
            private int nClos;
            public CogImage8Grey[] CogLineScanImage;
            
            public  MeasureCircleParameter _MeasureCircleParam;
            public  MeasureLineParameter _MeasureLineParam;
            public bool Initialize(int CamNo, int StageNo, int Cols)
            {
                bool Res = true;
                try
                {
                    nStagNo = StageNo;
                    nCamNo = CamNo;
                    nClos = Cols;
                    CogLineScanImage = new CogImage8Grey[Cols];
                    for(int nCnt =0; nCnt < Cols; nCnt++)
                    {
                        CogLineScanImage[nCnt] = new CogImage8Grey();
                    }
                    return Res;
                }
                catch
                {
                    return false;
                }
            }
            public void LoadData()
            {
              
            }
        }
    }
}
