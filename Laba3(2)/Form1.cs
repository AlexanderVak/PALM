﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(myBitmap);
            Font textFont = new Font("Stencil", 15);

            Rectangle rectBlue = new Rectangle(0, 100, 60, 60);
            Rectangle rectRed = new Rectangle(60, 100, 60, 60);
            Rectangle rectDjrBlue = new Rectangle(0, 160, 120, 52);
            Rectangle rectForEllipse1 = new Rectangle(80, 120, 20, 20);
            Rectangle rectForEllipse2 = new Rectangle(5, 110, 20, 20);
            Rectangle rectForEllipse3 = new Rectangle(30, 130, 20, 20);

            SolidBrush sbBlue = new SolidBrush(Color.Blue);
            SolidBrush sbRed = new SolidBrush(Color.Red);
            SolidBrush sbWhite = new SolidBrush(Color.White);
            SolidBrush sbDjrBlue = new SolidBrush(Color.DodgerBlue);

            g.RotateTransform(-40.0F);
            g.FillRectangle(sbBlue, rectBlue);
            g.FillRectangle(sbRed, rectRed);
            g.FillRectangle(sbDjrBlue, rectDjrBlue);
            g.FillEllipse(sbWhite, rectForEllipse1);
            g.FillEllipse(sbWhite, rectForEllipse2);
            g.FillEllipse(sbWhite, rectForEllipse3);
            g.DrawString("Domino\'s\n    Pizza", textFont, sbWhite, 12, 160);

            pictureBox1.Image = myBitmap;
        }





    }


 
}