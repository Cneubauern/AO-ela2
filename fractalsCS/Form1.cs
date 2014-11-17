using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractalsCS
{
    public partial class Form1 : Form
    {
        private int sleepTime=10;
        SolidBrush br = new SolidBrush(Color.White);
        SolidBrush brBl = new SolidBrush(Color.Black);
        Pen pen1 = new Pen(Color.Black);
        Pen pen2 = new Pen(Color.White);

        public Form1()
        {
            InitializeComponent();
        }

        private void star(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;
                star(g,  x - newRatio, y + newRatio, newRatio);                

                star(g,  x - newRatio, y - newRatio, newRatio);
               
                star(g,  x + newRatio, y - newRatio, newRatio);                

                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }
        private void starWhite(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                starWhite(g, x - 3*ratioRects/4, y - 3*ratioRects/4, newRatio);
                starWhite(g, x - 3*ratioRects/4, y + 4*ratioRects/3, newRatio);
                starWhite(g, x + 4*ratioRects/3, y - 3*ratioRects/4, newRatio);
                starWhite(g, x + 4*ratioRects/3, y + 4*ratioRects/3, newRatio);
   
                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }
        private void starBlack(Graphics g, int x, int y, int ratioRects)
        {

            if (ratioRects > 0)
            {
                int newRatio = ratioRects/2 ;
                starBlack(g, x - 3 * ratioRects / 4, y - 3 * ratioRects / 4, newRatio);
                starBlack(g, x - 3 * ratioRects / 4, y + 4 * ratioRects / 3, newRatio);
                starBlack(g, x + 4 * ratioRects / 3, y - 3 * ratioRects / 4, newRatio);
                starBlack(g, x + 4 * ratioRects / 3, y + 4 * ratioRects / 3, newRatio);

                int resizedRatio= 3 * ratioRects / 2;
                int newX = x+((ratioRects-resizedRatio) /2);
                int newY = y + ((ratioRects - resizedRatio) / 2);
          
                g.FillRectangle(br, newX, newY,resizedRatio, resizedRatio);
                g.DrawRectangle(pen2, newX, newY,resizedRatio, resizedRatio);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }
        private void starNew(Graphics g, int x, int y, int ratioRects)
        {
            double Ang36 = Math.PI / 5.0;
            double Ang72 = 2.0 * Ang36;
            float sin36 = (float)Math.Sin(Ang36);
            float sin72 = (float)Math.Sin(Ang72);
            float cos36 = (float)Math.Cos(Ang36);
            float cos72 = (float)Math.Cos(Ang72);

           if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;
             
                starNew(g, x , y - ratioRects, newRatio);
                starNew(g, x - ratioRects, y + ratioRects, newRatio);
                starNew(g, x + ratioRects, y + ratioRects, newRatio);
                starNew(g, x - ratioRects, y, newRatio);
                starNew(g, x + ratioRects, y, newRatio);



             //   starNew(g, x - newRatio, y - newRatio, newRatio);

             //   starNew(g, x + newRatio, y - newRatio, newRatio);

           //     g.FillRectangle(br, x, y, ratioRects, ratioRects);
           //     g.DrawRectangle(pen2, x, y, ratioRects, ratioRects);

                drawStar(g, x, y, ratioRects);


                System.Threading.Thread.Sleep(sleepTime);
            }
        }
        private void drawStar(Graphics g, int x, int y, int radius)
        {
            PointF[] Star = calculateStar(new PointF(x, y), radius, radius/3);
            g.FillPolygon(brBl, Star);
        }
        private PointF[] calculateStar(PointF orig,float outerradius, float innerradius)
        {
            double Ang36 = Math.PI/5.0;
            double Ang72 = 2.0 * Ang36;
            float sin36 = (float)Math.Sin(Ang36);
            float sin72 = (float)Math.Sin(Ang72);
            float cos36 = (float)Math.Cos(Ang36);
            float cos72 = (float)Math.Cos(Ang72);

            PointF[] pnts = {orig,orig,orig,orig,orig,orig,orig,orig,orig,orig,};
            pnts[0].Y -= outerradius;
            pnts[1].X += innerradius * sin36;
            pnts[1].Y -= innerradius * cos36;
            pnts[2].X += outerradius * sin72;
            pnts[2].Y -= outerradius * cos72;
            pnts[3].X += innerradius * sin72 ;
            pnts[3].Y += innerradius * cos72 ;
            pnts[4].X += outerradius * sin36;
            pnts[4].Y += outerradius * cos36;
            
            pnts[5].Y += innerradius;
            
            pnts[6].X -= outerradius * sin36;
            pnts[6].Y += outerradius * cos36;
            pnts[7].X -= innerradius * sin72;
            pnts[7].Y += innerradius * cos72;
            pnts[8].X -= outerradius * sin72;
            pnts[8].Y -= outerradius * cos72;
            pnts[9].X -= innerradius * sin36;
            pnts[9].Y -= innerradius * cos36;
            return pnts;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            
            g.Clear(Color.White);
            
            int ratioRects = int.Parse(textBox2.Text);

            star(g,100, 100, ratioRects);

            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            int newX = (pictureBox1.Width - ratioRects ) / 2;
            int newY = (pictureBox1.Height - ratioRects) / 2;

            starWhite(g, newX , newY, ratioRects );

            pictureBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.Black);
            int ratioRects = int.Parse(textBox2.Text);

            int newX = (pictureBox1.Width - ratioRects) / 2;
            int newY = (pictureBox1.Height - ratioRects) / 2;

            starBlack(g, newX, newY, ratioRects);

            pictureBox1.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            starNew(g, 100, 100, ratioRects);

            pictureBox1.Update();
        }
    }
}