﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Implementation.Internal;
using Cognex.VisionPro.CNLSearch;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.SearchMax;
using Cognex.VisionPro.LineMax;

namespace COG
{
    public partial class Form_PatternMask : Form
    {

        private CogSearchMaxTool TempSearchMaxTool = new CogSearchMaxTool();
        private CogPMAlignTool TempPMAlignTool = new CogPMAlignTool();

        public CogSearchMaxTool BackUpSearchMaxTool = new CogSearchMaxTool();
        public CogPMAlignTool BackUpPMAlignTool = new CogPMAlignTool();

        public CogRecordDisplay Mask_Display = new CogRecordDisplay();



        public int CogDisplayNum;
        public Form_PatternMask()
        {
            InitializeComponent();

        }


        private void Form_PatternMask_Load(object sender, EventArgs e)
        {


            TempSearchMaxTool = new CogSearchMaxTool(BackUpSearchMaxTool);
            TempPMAlignTool = new CogPMAlignTool(BackUpPMAlignTool);

            MaskEditRefresh();
            try
            {
                if (TempSearchMaxTool.Pattern.TrainImageMask != null)
                {
                    MaskEdit.MaskImage = TempSearchMaxTool.Pattern.TrainImageMask;
                    
                }
            }
            catch
            {

            }
        }

        private void MaskEditRefresh()
        {
            try
            {
                if (TempSearchMaxTool.Pattern.Trained)
                {
                    MaskEdit.Image = null;
                    MaskEdit.Image = CopyIMG(TempSearchMaxTool.Pattern.GetTrainedPatternImage());
                    MaskEdit.MaskImage = null;
                    MaskEdit.MaskImage.Allocate(MaskEdit.Image.Width, MaskEdit.Image.Height);
                    Mask_Display.Image = CopyIMG(TempSearchMaxTool.Pattern.GetTrainedPatternImage());



                }
            }
            catch
            {

            }
        }

        private CogImage8Grey CopyIMG(ICogImage IMG)
        {
            CogImage8Grey returnIMG;
            returnIMG = new CogImage8Grey(IMG as CogImage8Grey);
            return returnIMG;
        }
        private void BTN_MASK_CLEAR_Click(object sender, EventArgs e)
        {
            MaskEditRefresh();
        }
        private void BTN_SAVE_Click(object sender, EventArgs e)
        {

            try
            {
                TempSearchMaxTool.Pattern.TrainImageMaskOffsetX = (int)((Cognex.VisionPro.CogRectangle)(TempSearchMaxTool.Pattern.TrainRegion)).X;
                TempSearchMaxTool.Pattern.TrainImageMaskOffsetY = (int)((Cognex.VisionPro.CogRectangle)(TempSearchMaxTool.Pattern.TrainRegion)).Y;
                TempSearchMaxTool.Pattern.TrainImageMask = CopyIMG(MaskEdit.MaskImage);

                TempSearchMaxTool.Pattern.TrainImage = BackUpSearchMaxTool.Pattern.TrainImage;
                TempSearchMaxTool.Pattern.Train();

                TempPMAlignTool.Pattern.TrainImageMaskOffsetX = (int)((Cognex.VisionPro.CogRectangle)(TempPMAlignTool.Pattern.TrainRegion)).X;
                TempPMAlignTool.Pattern.TrainImageMaskOffsetY = (int)((Cognex.VisionPro.CogRectangle)(TempPMAlignTool.Pattern.TrainRegion)).Y;
                TempPMAlignTool.Pattern.TrainImageMask = CopyIMG(MaskEdit.MaskImage);

                TempPMAlignTool.Pattern.TrainImage = BackUpPMAlignTool.Pattern.TrainImage;
                TempPMAlignTool.Pattern.Train();

                BackUpSearchMaxTool = TempSearchMaxTool;
                BackUpPMAlignTool = TempPMAlignTool;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("등록 가능한 마크 특징이 없습니다.마스킹 확인바람!."," ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Hide();
        }
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
