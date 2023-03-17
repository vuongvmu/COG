using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.Controls.CtrlTeachROIJog;

namespace COG
{
    public partial class FormROIJog : Form
    {
        public CtrlTeachROIJog ROIJogControl = null;
        private eTeachingItem _inspectionItem = eTeachingItem.Mark;

        public FormROIJog(eTeachingItem teachingItem)
        {
            InitializeComponent();
            SetTeachingItem(teachingItem);
        }

        private void SetTeachingItem(eTeachingItem teachingItem)
        {
            _inspectionItem = teachingItem;
        }

        private void FormROIJog_Load(object sender, EventArgs e)
        {
            InitialzeUI();
            AddControl();
        }

        private void InitialzeUI()
        {
            this.Location = new Point(1100, 360);
        }

        private void AddControl()
        {
            // ROI Jog Control
            ROIJogControl = new CtrlTeachROIJog();
            this.pnlROIJog.Controls.Add(ROIJogControl);
            ROIJogControl.Dock = DockStyle.Fill;
            ROIJogControl.SendEventHandler += new CtrlTeachROIJog.SendClickEventDelegate(ReceiveClickEvent);
            ROIJogControl.tlpSkew.Enabled = false;
        }

        private void ReceiveClickEvent(object sender)
        {
            Button button = sender as Button;

            switch (_inspectionItem)
            {
                case eTeachingItem.LineScan:
                    break;

                case eTeachingItem.Mark:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMarkControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
                    break;
#if ATT
                case eTeachingItem.Align:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAlignControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
                    break;

                case eTeachingItem.Akkon:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);

                    if (button.Name.ToString().Contains("SkewCCW"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SkewROIJog(eSkewType.CCW);

                    if (button.Name.ToString().Contains("SkewZero"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SkewROIJog(eSkewType.Zero);

                    if (button.Name.ToString().Contains("SkewCW"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.SkewROIJog(eSkewType.CW);
                    break;
#endif
#if CGMS
                case eTeachingItem.Particle:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachParticleControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
                    break;
                    
                case eTeachingItem.Measure:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachMeasureControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
                    break;

                case eTeachingItem.Short:
                    if (button.Name.ToString().Contains("MoveUp"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.MoveROIJog(eMoveDirection.Up);

                    if (button.Name.ToString().Contains("MoveDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.MoveROIJog(eMoveDirection.Down);

                    if (button.Name.ToString().Contains("MoveLeft"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.MoveROIJog(eMoveDirection.Left);

                    if (button.Name.ToString().Contains("MoveRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.MoveROIJog(eMoveDirection.Right);

                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                        FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachShortControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
                    break;
#endif
                default:
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            FormMain.Instance().SelectUnitForm.VisionTeachForm.chkShowROIJog.Checked = false;
            this.Close();
        }
    }
}
