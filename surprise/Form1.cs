﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surprise
{
    public partial class Form1 : Form
    {
        int nr = 1024; // ilosc pktow 
        decimal MINY = decimal.MaxValue;
        decimal MAXY = decimal.MinValue;
        double[] x;
        int asyncLength = 10;
        decimal[,] y;
        Point[,] p;
        List<Color> colors = new List<Color>();
        int n = 3;
        List<bool> selF;
        List<string> functions;
        double x1, x2;
        private addFuncForm f;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
            x1 = -2;
            x2 = 3;
            string[] tmpfunctions = { "x*x*x-x*x-x-1", "x*x", "x - 6" };
            functions = tmpfunctions.ToList();
            n = functions.Count;
            x = getX(x1, x2, nr);
            y = new decimal[n, x.Length];
            selF = new List<bool>(n);
            for (int i = 0; i < n; ++i)
                selF.Add(false);
            selF[0] = true;
            debug.Text = "";
            string[] colorss = new string[] {
        "FF0000", "00FF00", "0000FF", "FFFF00", "FF00FF", "00FFFF", "000000",
        "800000", "008000", "000080", "808000", "800080", "008080", "808080",
        "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0",
        "400000", "004000", "000040", "404000", "400040", "004040", "404040",
        "200000", "002000", "000020", "202000", "200020", "002020", "202020",
        "600000", "006000", "000060", "606000", "600060", "006060", "606060",
        "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0",
        "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0",
    };
            foreach (var c in colorss)
                colors.Add(Color.FromArgb((int)long.Parse(c.Substring(0,2),System.Globalization.NumberStyles.HexNumber), (int)long.Parse(c.Substring(2, 2), System.Globalization.NumberStyles.HexNumber), (int)long.Parse(c.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
            p = new Point[n, x.Length];
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
                    }
                    else
                    {
                        selF[e.Index] = false;
                    }
                     
                    funcBox.Enabled = true;
                }
                );
        }

        private void funcBox_SelectedValueChanged(object sender, EventArgs e)
        {
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

        private Point conv(double x, decimal y)
        {
            double oldrangex = (x2 - x1);
            int newrangex = (mapa.Width);
            double newx = (x - x1)  / oldrangex * newrangex;

            decimal oldrangey = (MAXY - MINY);
            int newrangey = (mapa.Height);
            decimal newy = (y - MINY)  / oldrangey * (Decimal)newrangey;

            Point PP = new Point((int)newx, mapa.Height - (int)newy);
            return PP;
        }

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
            f = new addFuncForm();
            var result = f.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                functions.Add(f.func);
                funcBox.Items.Add(f.func);
                selF.Add(false);
            }
            this.Refresh();
        }

        decimal [,] calculateY (double[] x, List<string> functions, bool[] selF) // working
        {
            MAXY = decimal.MinValue;
            MINY = decimal.MaxValue;
            int funcCount = 0;
            for (int i = 0; i < selF.Length; ++i)
                if (selF[i]) ++funcCount;
            decimal[,] y = new decimal[funcCount, x.Length];
            int j = 0;
            string CultureName = Thread.CurrentThread.CurrentCulture.Name;
            CultureInfo ci = new CultureInfo(CultureName);
            if (ci.NumberFormat.NumberDecimalSeparator != ".")
            {
                // Forcing use of decimal separator for numerical values
                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;
            }
            for (int i = 0; i < functions.Count; ++i)
            {
                if (selF[i])
                {
                    for (int k = 0; k < x.Length; ++k)
                    {


                        int ii = 0;
                        Decimal d = (Decimal)x[k];
                        string tt = x[k].ToString("F99").TrimEnd('0');
                        string tmp = functions[i].ToString().Replace("x", d.ToString());//x[k].ToString() + "m");
                        string expression = tmp;
                        expression = Regex.Replace(
                            expression,
                            @"\d+(\.\d+)?",
                            m => {
                                var t = m.ToString();
                                return t.Contains(".") ? t : string.Format("{0}.0", t);
                            }
                        );

                        if (ii == 0)
                        {
                            ++ii;
                        }
                        y[j, k] = (Decimal)new DataTable().Compute(expression, null);// Convert.ToDecimal(new DataTable().Compute(expression, null));
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
                double[] x_tmp = getX(x1, x2, 2<<i + 1);
                decimal[,] y_tmp = calculateY(x_tmp, functions, selF.ToArray());

                Point[,] p_tmp = getPoints(x_tmp, y_tmp);

                ThreadHelperClass.SetText(this, integralLabel, "Integral: " + Integrate(x_tmp, y_tmp).ToString("0.#####E+000").TrimEnd('0').TrimEnd('-').TrimEnd('+').TrimEnd('E'));
                draw(true, p_tmp, y_tmp);

                calculations.ReportProgress((i+1)*10);

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

        Point[,] getPoints(double[] x, decimal[,] y) // WORKING
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
            double[] x_tmp = getX(x1, x2, mapa.Width/4+1);
            decimal[,] y_tmp = calculateY(x_tmp, functions, selF.ToArray());
            Point[,] p_tmp = getPoints(x_tmp, y_tmp);
            ThreadHelperClass.SetText(this, integralLabel, "Integral: " + Integrate(x_tmp, y_tmp).ToString("0.#####E+000").TrimEnd('0').TrimEnd('-').TrimEnd('+').TrimEnd('E'));
            draw(false, p_tmp, y_tmp);
        }

        private Decimal Integrate(double[] x, Decimal[,] y)
        {
            Decimal ret = 0;
            if (p.GetLength(0) < 1 || p.GetLength(1) <= 1) return 0;
            double dX = x[1] - x[0];
            for (int j = 0; j < y.GetLength(0); ++j)
            {
                for (int i = 1; i < y.GetLength(1); ++i)
                {
                    ret += ((y[j, i] * (decimal)dX - y[j, i - 1] * (decimal)dX) / 2 + y[j, i - 1]) * (decimal)dX;//* (Decimal)dX;
                }
            }
            return ret;
        }

        private void draw(bool async, Point[,] p, Decimal[,] y)
        {
            
            Pen pTmp = new Pen(Color.Red, (float)2);
            //Brush bTmp = new Brush();
            Brush brush = new SolidBrush(Color.Red);           
            Pen rect = new Pen(Color.Red, (float)1);
            Bitmap bmp = new Bitmap(mapa.Width, mapa.Height);
            Graphics gr = mapa.CreateGraphics();
            Graphics rg = Graphics.FromImage(bmp);

            rg.SmoothingMode = SmoothingMode.AntiAlias;
            rg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            rg.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            if (y.GetLength(0) < 1)
            {

                ThreadHelperClass.SetText(this, maxLabel, "Max Y : ");
                ThreadHelperClass.SetText(this, minLabel, "Min Y : ");
                mapa.Image = null;
                return;
            }
            ThreadHelperClass.SetText(this, maxLabel, "Max Y : " + MAXY.ToString("0.###E+00").TrimEnd('0').TrimEnd('.').TrimEnd('-').TrimEnd('+').TrimEnd('E'));
            ThreadHelperClass.SetText(this, minLabel, "Min Y : " + MINY.ToString("0.###E+00").TrimEnd('0').TrimEnd('.').TrimEnd('-').TrimEnd('+').TrimEnd('E'));
            bool draw = false;
            for (int i = 0; i < selF.Count; ++i) if (selF[i]) draw = true;

            if (async)
            {
                if (draw)
                {
                    Decimal y0 = (MAXY - MINY) / 2 + MINY;
                    rg.DrawLine(new Pen(Color.Black, (float)1), conv(x1,0), conv(x2,0));
                }
                else
                {
                    MINY = -1;
                    MAXY = 1;
                    Decimal y0 = (MAXY - MINY) / 2 + MINY;
                    
                    rg.DrawLine(new Pen(Color.Black, (float)1), new Point(0, conv(0,0).Y), new Point(mapa.Width - 1, conv(0,0).Y));
                }
            }
            if (y.GetLength(0) >= 1)
            {
                int dx = p[0, 1].X - p[0, 0].X;
                for (int i = 0; i < p.GetLength(0); ++i)
                {
                    pTmp.Color = colors[i];
                    rect.Color = Color.FromArgb(100,colors[i % colors.Count]);
                    brush = new SolidBrush(Color.FromArgb(100, colors[i % colors.Count]));
                    for (int j = 0; j < p.GetLength(1); ++j)
                    {
                        rg.DrawEllipse(pTmp, p[i, j].X, p[i, j].Y, (float)1, (float)1);
                        if (j > 0)
                        {
                            rg.DrawLine(pTmp, p[i, j - 1], p[i, j]);
                            if (async)
                            {
                                int x = p[i, j - 1].X;
                                Decimal yy = (y[i, j - 1] + y[i, j]) / 2;
                                Rectangle r = new Rectangle();
                                r.X = x;
                               
                                r.Width = dx;
                                if (r.Width == 0) r.Width = 1;
                                if (yy > 0)
                                {

                                    r.Y = conv(0, yy).Y;
                                    r.Height = -conv(0,yy).Y + conv(0,0).Y;
                                    
                                }
                                else
                                {
                                    r.Y = conv(0, 0).Y;
                                    r.Height = -conv(0, 0).Y + conv(0, yy).Y;
                                }
                                rg.FillRectangle(brush, r);
                            }
                        }
                    }
                }
            }
            if (mapa.Image != null)
                mapa.Image.Dispose();
            mapa.Image = null;
            if (draw)
                mapa.Image = (Image)bmp.Clone();
            else
                mapa.InitialImage = null;
            
            pTmp.Dispose();
            rg.Dispose();
            bmp.Dispose();
            gr.Dispose();
        }
    }
}
