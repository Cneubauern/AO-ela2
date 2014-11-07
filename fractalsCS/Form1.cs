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
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;
                star(g, x - newRatio, y + newRatio, newRatio);

                star(g, x - newRatio, y - newRatio, newRatio);

                star(g, x + newRatio, y - newRatio, newRatio);

                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen2, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
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