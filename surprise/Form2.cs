using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surprise
{
    public partial class addFuncForm : Form
    {

        public string func { get; set; }

        public addFuncForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ActiveControl = funcBox;
            funcBox.Focus();
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            if (isFormula(funcBox.Text))
            {
                this.func = funcBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //this.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Function can't be parsed");
            }
        }

        private bool isFormula(string text)
        {
            if (text == null || text == "") return false;
            try
            {
                double p = Convert.ToDouble(new DataTable().Compute(text.Replace("x", "1.1"), null));
                //if (p == null)
                //    return false;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
