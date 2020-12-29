using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormulaChecker.Enums;

namespace FormulaChecker
{
    public partial class MainForm : Form
    {
        private List<double> testValueList = new List<double>();
        
        public MainForm()
        {
            InitializeComponent();
            CommonClass.CommonInitialization(labelTask);
            CommonClass.GenerateTestValueList(testValueList);
            CommonClass.TestValueInitialization(labelTest1, textBoxTest1, testValueList[0]);
            CommonClass.TestValueInitialization(labelTest2, textBoxTest2, testValueList[1]);
            CommonClass.TestValueInitialization(labelTest3, textBoxTest3, testValueList[2]);
            CommonClass.TestValueInitialization(labelTest4, textBoxTest4, testValueList[3]);
            CommonClass.TestValueInitialization(labelTest5, textBoxTest5, testValueList[4]);

        }

        private void buttonCheckResults_Click(object sender, EventArgs e)
        {
            foreach (var element in Controls)
            {
                if (element is TextBox)
                {
                    var elementLikeTextBox = (TextBox)element;
                    elementLikeTextBox.ReadOnly = true;
                    if (String.IsNullOrWhiteSpace(elementLikeTextBox.Text))
                    {
                        elementLikeTextBox.BackColor = Color.Yellow;
                        elementLikeTextBox.Text = "No answer";
                    }
                    else
                    {
                        if (elementLikeTextBox.Text != elementLikeTextBox.Tag.ToString())
                        {
                            elementLikeTextBox.BackColor = Color.Red;
                            elementLikeTextBox.Text += " - this is wrong answer";
                        }
                        else
                        {
                            elementLikeTextBox.BackColor = Color.LightGreen;
                        }
                    }
                }
            }

            ((Button)sender).Enabled = false;
            buttonReset.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (var element in Controls)
            {
                if (element is TextBox)
                {
                    var elementLikeTextBox = (TextBox)element;
                    elementLikeTextBox.ReadOnly = false;
                    elementLikeTextBox.Text = String.Empty;
                    elementLikeTextBox.BackColor = Color.White;
                }
            }
            ((Button)sender).Enabled = false;
            buttonCheckResults.Enabled = true;
        }
    }
}
