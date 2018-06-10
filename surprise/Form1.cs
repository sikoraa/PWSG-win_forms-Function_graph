using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surprise
{
    public partial class Form1 : Form
    {
        int nr = 1024; // ilosc pktow 
        double MINY = double.MaxValue;
        double MAXY = double.MinValue;
        double[] x;
        int asyncLength = 10;
        double[,] y;
        Point[,] p;
        int n = 3;
        List<bool> selF;
        List<string> functions;
        double x1, x2;
        private addFuncForm f;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
            x1 = double.Parse(fromBox.Text);
            x2 = double.Parse(toBox.Text);
            string[] tmpfunctions = { "x*x*x-x*x-x-1", "x*x", "x - 6" };
            Color[] colors = { Color.Red, Color.Blue, Color.Black, Color.Orange, Color.Green, Color.Purple  };
            functions = tmpfunctions.ToList();
            n = functions.Count;
            x = getX(x1, x2, nr);
            y = new double[n, x.Length];
            selF = new List<bool>(n);
            for (int i = 0; i < n; ++i)
                selF.Add(false);
            selF[0] = true;
            p = new Point[n, x.Length];
            //string[] t = functions.ToArray();
            funcBox.Items.AddRange(functions.ToArray());      
            funcBox.SetItemChecked(0, true);
            this.Refresh();
        }
        
        private void funcBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

        private void funcBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            var x = this.Handle;

            this.BeginInvoke((MethodInvoker)
                delegate
                {
                    funcBox.Enabled = false;
                    if (e.NewValue == CheckState.Checked)
                    {
                        selF[e.Index] = true;
                        debug.Text += "(" + e.Index.ToString() + "," + selF[e.Index] + ") ";

                    }
                    else
                    {
                        selF[e.Index] = false;
                    }
                    Random rnd = new Random();
                    debug.Text = rnd.Next(0, 100).ToString() + "  ";
                    //if (funcBox.SelectedIndex == -1) return;

                    for (int i = 0; i < functions.Count; ++i)
                    {
                        if (i == e.Index) continue;
                        //selF[i] = false;
                        if (funcBox.GetItemChecked(i))
                        {
                            //selF[i] = true;
                            debug.Text += "(" + i.ToString() + "," + selF[i] + ") ";
                        }
                    }
                    funcBox.Enabled = true;
                }
                );
        }

        private void funcBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Random rnd = new Random();
            //debug.Text = rnd.Next(0, 100).ToString();
            //if (funcBox.SelectedIndex == -1) return;

            //for (int i = 0; i < functions.Count; ++i)
            //{
            //    selF[i] = false;
            //    if (funcBox.GetItemChecked(i))
            //    {
            //        selF[i] = true;
            //    }
            //}
        }


        double[] getX(double x1, double x2, int nr)
        {
            double[] ret;
            if (nr < 2) return null;
            double delta = (x2 - x1) / (nr - 1);
            ret = new double[nr];
            ret[0] = x1;
            ret[nr - 1] = x2;
            for (int i = 1; i < nr - 1; ++i)
                ret[i] = ret[i - 1] + delta;
            return ret;

        } // WORKING

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
            double[] tmp = getX(x1, x2, nr);
            if (tmp == null)
            {
                
                MessageBox.Show("Error calculating x points.");
                return;
            }
            x = tmp;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1189, 585);
            //this.Refresh();
        }

        private Point conv(double x, double y)
        {
            double oldrangex = (x2 - x1);
            int newrangex = (mapa.Width);
            double newx = (x - x1)  / oldrangex * newrangex;

            double oldrangey = (int)(MAXY - MINY);
            int newrangey = (mapa.Height);
            double newy = (y - MINY)  / oldrangey * newrangey;

            Point PP = new Point((int)newx, mapa.Height - (int)newy);
            return PP;
        } // WORKING

        private void Form1_Load(object sender, EventArgs e)
        {
            ;
        }

        private void asyncB_Click(object sender, EventArgs e)
        {
            if (!calculations.IsBusy)
                calculations.RunWorkerAsync();
        }

        private void stopB_Click(object sender, EventArgs e)
        {
            if (calculations.IsBusy)
                calculations.CancelAsync();
        }

        private void addFuncB_Click(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            f = new addFuncForm();
            
            //Form tmp = new addFuncForm();
            //f.Parent = this;
            //tmp.MdiParent = this;
            var result = f.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                functions.Add(f.func);
                funcBox.Items.Add(f.func);
                selF.Add(false);
            }
            this.Refresh();
        }

        double [,] calculateY (double[] x, List<string> functions, bool[] selF) // working
        {
            MAXY = double.MinValue;
            MINY = double.MaxValue;
            int funcCount = 0;
            for (int i = 0; i < selF.Length; ++i)
                if (selF[i]) ++funcCount;
            double[,] y = new double[funcCount, x.Length];
            int j = 0;
            for(int i = 0; i < functions.Count; ++i)
            {
                if (selF[i])
                {
                    for (int k = 0; k < x.Length; ++k)
                    {

                        y[j, k] = Convert.ToDouble(new DataTable().Compute(   functions[i].ToString().Replace("x", x[k].ToString())+(".0"), null));
                        if (y[j, k] > MAXY) MAXY = y[j, k];
                        if (y[j, k] < MINY) MINY = y[j, k];

                    }
                    ++j;
                }
            }
            return y;
        }

        private void calculations_DoWork(object sender, DoWorkEventArgs e)
        {
            //double integral = 0;
            for (int i = 0; i < asyncLength; ++i)
            {
                
                if (calculations.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                ThreadHelperClass.SetText(this, integralLabel, "Integral: " + c(selF.ToArray()));
                
                double[] x_tmp = getX(x1, x2, 2<<i + 1);
                double[,] y_tmp = calculateY(x_tmp, functions, selF.ToArray());
                //Point[,] realPoints = getPoints(x_tmp, y_tmp);

                Point[,] p_tmp = getPoints(x_tmp, y_tmp);
                ThreadHelperClass.SetText(this, integralLabel, "Integral: " + Integrate(x_tmp, y_tmp));
                draw(true, p_tmp);

                calculations.ReportProgress((i+1)*10); // obliczenia wykonane, narysowac trzeba

                Thread.Sleep(1000);
            }
        }
        private int c(bool[] s)
        {
            int cc = 0;
            for (int i = 0; i < s.Length; ++i)
                if (s[i]) ++cc;
            return cc;
        }
        private Point[,] convertPoints(Point[,] realPoints)
        {
            throw new NotImplementedException();
        }

        private void calculations_ProgressChanged(object sender, ProgressChangedEventArgs e) // WORKING
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void calculations_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        Point[,] getPoints(double[] x, double[,] y) // WORKING
        {
            Point[,] p = new Point[y.GetLength(0), y.GetLength(1)];
            for(int i = 0; i < y.GetLength(0); ++i) // dla kazdej funkcji
            {
                for(int j = 0; j < x.Length; ++j) // dla kazdego x
                {
                    p[i, j] = conv(x[j], y[i, j]);
                }
            }
            return p;
        }

        private void drawB_Click(object sender, EventArgs e) // WORKING
        {
            double[] x_tmp = getX(x1, x2, mapa.Width+1);
            double[,] y_tmp = calculateY(x_tmp, functions, selF.ToArray());
            Point[,] p_tmp = getPoints(x_tmp, y_tmp);
            double integral = 0;
            ThreadHelperClass.SetText(this, integralLabel, "Integral: " + Integrate(x_tmp, y_tmp));
            draw(false, p_tmp);
        }

        private Double Integrate(double[] x, double[,] y)
        {
            double ret = 0;
            if (p.GetLength(0) < 1 || p.GetLength(1) <= 1) return 0;
            double dX = x[1] - x[0];
            for (int j = 0; j < y.GetLength(0); ++j)
            {
                for (int i = 1; i < y.GetLength(1); ++i)
                {
                    ret += (y[j,i] + y[j,i - 1]) / 2 * dX;
                }
            }
            return ret;
        }

        private void draw(bool zeroLine, Point[,] p) // not quite there yet..
        {
            
            Pen pTmp = new Pen(Color.Red, (float)2);
            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            Graphics gr = mapa.CreateGraphics();
            Graphics rg = Graphics.FromImage(bmp);

            rg.SmoothingMode = SmoothingMode.AntiAlias;
            rg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            rg.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            if (y.GetLength(0) < 1)
            {

                maxLabel.Text = "Max Y : ";
                minLabel.Text = "Min Y : ";
                return;
            }
            //maxLabel.Text = "Max Y : " + MAXY.ToString();
            ThreadHelperClass.SetText(this, maxLabel, "Max Y : " + MAXY.ToString());
            //minLabel.Text = "Min Y : " + MINY.ToString();
            ThreadHelperClass.SetText(this, minLabel, "Min Y : " + MINY.ToString());
            bool draw = false;
            for (int i = 0; i < selF.Count; ++i) if (selF[i]) draw = true;

            if (zeroLine)
            {
                if (draw)
                {
                    double y0 = (MAXY - MINY) / 2 + MINY;
                    rg.DrawLine(new Pen(Color.Black, (float)1), new Point(0, conv(0, y0).Y), new Point(mapa.Width - 1, conv(mapa.Width - 1, y0).Y));
                }
                else
                {
                    MINY = -1;
                    MAXY = 1;
                    double y0 = (MAXY - MINY) / 2 + MINY;
                    
                    rg.DrawLine(new Pen(Color.Black, (float)1), new Point(0, conv(0,0).Y), new Point(mapa.Width - 1, conv(0,0).Y));
                }
            }
            if (y.GetLength(0) >= 1)
            {
                for (int i = 0; i < p.GetLength(0); ++i)
                {
                    for (int j = 0; j < p.GetLength(1); ++j)
                    {
                        rg.DrawEllipse(pTmp, p[i, j].X, p[i, j].Y, (float)1, (float)1);
                        if (j > 0)
                            rg.DrawLine(pTmp, p[i, j - 1], p[i, j]);
                    }
                }
            }
            if (mapa.Image != null)
                mapa.Image.Dispose();
            mapa.Image = null;
            mapa.Image = (Image)bmp.Clone();
            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
            gr.Dispose();
        }
    }
}
