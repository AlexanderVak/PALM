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
        private void DrawLine()
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            rnd = new Random();
            rndForColors = new Random(DateTime.Now.Millisecond);
            pen = new Pen(Color.FromArgb(rndForColors.Next(256), rndForColors.Next(256), rndForColors.Next(256), 10));
            int x = rnd.Next(pictureBox1.Width);
            int y = rnd.Next(pictureBox1.Height);
            Point point1 = new Point(x, y);
            Point point2 = new Point(x, y);
            g.DrawLine(pen, point1, point2);
            pictureBox1.Image = myBitmap;
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }


    }
}
