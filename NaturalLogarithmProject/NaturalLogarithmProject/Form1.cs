using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalLogarithmMethod;

namespace NaturalLogarithmProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            if(xTextBox.Text == "")
            {
                errorLabel.Text = "Enter the desired x!";
                return;
            }
            if(accuracyTextBox.Text == "")
            {
                errorLabel.Text = "Enter accuracy!";
                return;
            }
            int temp = 0;
            if(!int.TryParse(xTextBox.Text, out temp) || temp <= 1)
            {
                errorLabel.Text = "x must be a number greater than 1";
                return;
            }
            if(!int.TryParse(accuracyTextBox.Text, out temp) || temp <= 0)
            {
                errorLabel.Text = "Accuracy must be a number greater than 0";
                return;
            }
            try
            {
                Method.OnEndPeriodCycleIterationEvent += doPeriodCycle;
                Method.Step(int.Parse(xTextBox.Text), int.Parse(accuracyTextBox.Text));
            }
            catch(Exception) 
            {
                errorLabel.Text = "Oops! Something went wrong";
            }
        }
        private void doPeriodCycle()
        {
            Application.DoEvents();
            answerLabel.Text = Convert.ToString(Method.ln);
        }
    }
}
