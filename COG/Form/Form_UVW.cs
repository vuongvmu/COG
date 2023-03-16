using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class Form_UVW : Form
    {
        public Form_UVW()
        {
            InitializeComponent();
        }
        //---------------------------------------------도포기---------------------------------------------
//         public struct UVW
//         {
//             public const double CRB_X1 = 90;
//             public const double CRB_X2 = 270;
//             public const double CRB_Y1 = 180;
//             public const double CRB_Y2 = 0;
//             public static double STAGE_R = 39; //mm
//         }
        // case 0:
        // Move_X1 = UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X1 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X1));
        // Move_X2 = UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X2 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X2));
        // Move_Y1 = UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y1 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y1));
        // MOT.Add(Move_X1); MOT.Add(Move_X2); MOT.Add(Move_Y1);
        // XY.Add(dx); XY.Add(dx); XY.Add(dy);
        // break;
        //-------------------------------------------합착기----------------------------------------------
//         public struct UVW
//         {
//             public const double CRB_X1 = 90;
//             public const double CRB_X2 = 0;
//             public const double CRB_Y1 = 180;
//             public const double CRB_Y2 = 0;
//             public static double STAGE_R = 60; //mm
//         }
        // case 1:
        // Move_X1 = UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X1 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Cos(DEGtoRAD(initTheta + UVW.CRB_X1));
        // Move_Y1 = UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y1 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y1));
        // Move_Y2 = UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y2 + (double)dt / 1000.0)) - UVW.STAGE_R * Math.Sin(DEGtoRAD(initTheta + UVW.CRB_Y2));
        // MOT.Add(Move_X1); MOT.Add(Move_Y1); MOT.Add(Move_Y2);
        // XY.Add(dx); XY.Add(dy); XY.Add(dy);
        // break;
        //----------------------------------------------------------------------------------------------------       

    }
}
