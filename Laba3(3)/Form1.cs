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
        int x, y, x1, y1, cntrX, cntrY, angle, rad;
        int[] cntrArray;



        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            pen = new Pen(Color.FromArgb(rndForColors.Next(0, 256), rndForColors.Next(0, 256), rndForColors.Next(0, 256)), 5.0F);
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            
            
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

            if (cntrX == x)
            {
                angle += 5;

                x1 = (int)(cntrX + rad * Math.Cos(angle * Math.PI / 180));
                y1 = (int)(cntrY + rad * Math.Sin(angle * Math.PI / 180));
                Invalidate();
                g.DrawLine(pen, x, y, x1, y1);



            }
            else
            {
                angle += 5;

                x = (int)(cntrX + rad * Math.Cos(angle * Math.PI / 180));
                y = (int)(cntrY + rad * Math.Sin(angle * Math.PI / 180));
                Invalidate();
                g.DrawLine(pen, x, y, x1, y1);



            }


            pictureBox1.Image = myBitmap;
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            x = rnd.Next(200, 437);
            y = rnd.Next(100, 297);
            x1 = rnd.Next(200, 437);
            y1 = rnd.Next(100, 297);
            cntrArray = new int[] { x, x1 };
            cntrX = cntrArray[rnd.Next(0, 1)];
            if (cntrX == x)
                cntrY = y;
            else cntrY = y1;
            rad = (int)Math.Sqrt((int)Math.Pow((x1 - x), 2) + (int)Math.Pow((y1 - y), 2));
            rndForColors = new Random();
            pen = new Pen(Color.FromArgb(rndForColors.Next(0, 256), rndForColors.Next(0, 256), rndForColors.Next(0, 256)), 5.0F);
            colorTimer.Interval = rnd.Next(50, 5000);


        }

        



    }
}
