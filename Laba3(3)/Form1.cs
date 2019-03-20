using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3_3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen pen;
        Random rnd;
        Random rndForColors; 
        Bitmap myBitmap;
        Graphics g;
        int x, y, x1, y1;
        Point point1, point2;

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

            rndForColors = new Random();
            pen = new Pen(Color.FromArgb(rndForColors.Next(0, 256), rndForColors.Next(0, 256), rndForColors.Next(0, 256)), 5.0F);
            x = rnd.Next(200, 437);
            y = rnd.Next(100, 297);
            x1 = rnd.Next(200, 437);
            y1 = rnd.Next(100, 297);
            point1 = new Point(x, y);
            point2 = new Point(x1, y1);
            g.DrawLine(pen, point1, point2);
            pictureBox1.Image = myBitmap;
        }
    }
}
