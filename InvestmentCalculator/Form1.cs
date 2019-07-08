using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);

            //if(txtMonthlyInvestment.Text==string.Empty)
            //{
            //    MessageBox.Show("Monthly Investment is a required field.", "Entry Error");
            //    txtMonthlyInvestment.Focus();
            //}

            if (!(decimal.TryParse(txtMonthlyInvestment.Text,out monthlyInvestment)))
            {
                MessageBox.Show("Monthly Investment must be a numeric value.", "Entry Error");
                txtMonthlyInvestment.Clear();
                txtMonthlyInvestment.Focus();
            }

            if(monthlyInvestment<=0)
            {
                MessageBox.Show("Monthly Investment must be greater than 0.", "Entry Error");
                txtMonthlyInvestment.Clear();
                txtMonthlyInvestment.Focus();
            }
            else if(monthlyInvestment>=1000)
            {
                MessageBox.Show("Monthly Investment must be less than 1000.", "Entry Error");
                txtMonthlyInvestment.Clear();
                txtMonthlyInvestment.Focus();
            }
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text==string.Empty)
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Clear();
                textBox.Focus();
            }

            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text,out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error");
                textBox.Clear();
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number<min||number>max)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + min.ToString() + ".", "Entry Error");
                textBox.Clear();
                textBox.Focus();
            }

            return true;
        }
    }
}
