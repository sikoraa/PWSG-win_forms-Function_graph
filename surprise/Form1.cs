using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surprise
{
    public partial class Form1 : Form
    {
        string[] functions;
        int nr = 10000; // ilosc pktow 
        double MINY = double.MaxValue;
        double MAXY = double.MinValue;
        double[] x;
        double[,] y;
        Point[,] p;
        int n = 3;
        bool[] selF;
        double x1, x2;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
            x1 = double.Parse(fromBox.Text);
            x2 = double.Parse(toBox.Text);
            string[] tmpfunctions = { "x*x*x-x*x-x-1", "x*x", "x - 6" };
            Color[] colors = { Color.Red, Color.Blue, Color.Black, Color.Orange, Color.Green, Color.Purple  };
            functions = tmpfunctions;
            n = functions.Length;
            x = new double[nr];
            y = new double[n, x.Length];
            selF = new bool[n];
            selF[0] = true;
            p = new Point[n, x.Length];
            funcBox.Items.AddRange(functions);      
            funcBox.SetItemChecked(0, true);
            this.Refresh();
        }
        
        private void funcBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < functions.Length; ++i)
            {
                selF[i] = false;
                if (funcBox.GetItemChecked(i))
                {
                    selF[i] = true;
                }
            }
        }

        private void domainB_Click(object sender, EventArgs e)
        {
            double from = 0;
            double to = 0;
            if (!double.TryParse(fromBox.Text, out from) || !double.TryParse(toBox.Text, out to))
            {
                fromBox.Text = x1.ToString();
                toBox.Text = x2.ToString();
                MessageBox.Show("Please check if domain is a numeric value");
                return;
            }
            if (from >= to)
            {
                fromBox.Text = x1.ToString();
                toBox.Text = x2.ToString();
                MessageBox.Show("Please check that From is lesser than To");
                return;
            }
            fromBox.Text.Trim();
            toBox.Text.Trim();
            
            x1 = from; x2 = to;
            double dx = (x2 - x1) / (nr - 1);
            if (nr > 0) x[0] = x1;
            for (int i = 1; i < nr; ++i)
            {
                x[i] = x[i-1] + dx;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1189, 585);
            //this.Refresh();
        }

        private Point conv(double x, double y)
        {
            int originalStartx = (int)x1; int originalEndx = (int)x2; // original range
    int newStartx = 0;
            int newEndx = 1023; // desired range // value to convert

            double scalex = (double)(newEndx - newEndx) / (originalEndx-originalStartx);
            int originalStarty = (int)MINY; int originalEndy = (int)MAXY; // original range
            int newStarty = 0;
            int newEndy = 511; // desired range // value to convert

            double scaley = (double)(newEndy - newEndy) / (originalEndy - originalStarty);
            //double tx = 
            Point PP = new Point((int)(newStartx + (x - originalStartx) * scalex), (int)y);
            return PP;
        }

        private void drawB_Click(object sender, EventArgs e)
        {
            bool any = false;
            Pen pTmp = new Pen(Color.Red, (float)2);
            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            Graphics gr = mapa.CreateGraphics();          
            Graphics rg = Graphics.FromImage(bmp);

            rg.SmoothingMode = SmoothingMode.AntiAlias;
                        rg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                        rg.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;



            for (int i = 0; i < functions.Length; ++i)
            {
                if (selF[i]) // funkcja zaznaczona do narysowania
                {
                    any = true;
                    for (int j = 0; j < nr; ++j)
                    {
                        //y[i, j] = // 0;
                        switch (i)
                        {
                            case 0:
                                y[i, j] = x[j] * x[j] * x[j] - x[j] * x[j] - x[j] - 1;
                                break;
                            case 1:
                                y[i, j] = x[j]*x[j];
                                break;
                            case 2:
                                y[i, j] = x[j]-6;
                                break;
                        }
                        if (y[i, j] > MAXY) MAXY = y[i, j];
                        if (y[i, j] < MINY) MINY = y[i, j];
                        //new Point((int)x[j], (int)y[i, j]);    
                    }
                }
            }
            for(int i = 0; i < functions.Length; ++i)
            {
                if (selF[i])
                {
                    for (int j = 0; j < nr; ++j)
                    {
                        p[i, j] = conv(x[j], y[i, j]);
                        rg.DrawEllipse(pTmp, p[i, j].X, p[i, j].Y, (float)1, (float)1);
                        if (j > 0)
                            rg.DrawLine(pTmp, p[i, j - 1], p[i, j]);
                    }
                }
            }
            if (!any)
            {
                MAXY = double.MinValue;
                MINY = double.MaxValue;
                maxY.Text = "";
                minY.Text = "";
            }

            if (mapa.Image != null)
                mapa.Image.Dispose();
            mapa.Image = (Image)bmp.Clone();
            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
            gr.Dispose();
                         //tmp.Dispose();

        }
    }
}
