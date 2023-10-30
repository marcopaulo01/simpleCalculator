using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string temp;
        string operation;
        private bool equalsButtonPressed = false;
        double lastNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            answerTextBox.ReadOnly = true;
            answerTextBox.Enabled = false;
            answerTextBox.Text = "0";

            oneButton.Click += numberButton_Click;
            twoButton.Click += numberButton_Click;
            threeButton.Click += numberButton_Click;
            fourButton.Click += numberButton_Click;
            fiveButton.Click += numberButton_Click;
            sixButton.Click += numberButton_Click;
            sevenButton.Click += numberButton_Click;
            eightButton.Click += numberButton_Click;
            nineButton.Click += numberButton_Click;
            zeroButton.Click += numberButton_Click;

            plusButton.Click += operationButton_Click;
            minusButton.Click += operationButton_Click;
            multiplyButton.Click += operationButton_Click;
            divideButton.Click += operationButton_Click;
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            if (equalsButtonPressed)
            {
                answerTextBox.Text = "";
                answerTextBox.Enabled = false;
            }
            
            Button button = (Button)sender;
            string buttonText = button.Text;
            if(answerTextBox.Text != "0")
            {
                answerTextBox.Text += buttonText;
            }
            else
            {
                answerTextBox.Text = buttonText;
            }
            lastNumber = double.Parse(answerTextBox.Text);
            equalsButtonPressed = false;
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;
            if (answerTextBox.Text != "0")
            {
                temp = answerTextBox.Text;
            }
            operation = buttonText;
            answerTextBox.Text = "0";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            answerTextBox.Text = "0";
            temp = "0";
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            if (!answerTextBox.Text.Contains("."))
            {
                answerTextBox.Text += ".";
            }
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            if (!answerTextBox.Text.Contains("-"))
            {
                answerTextBox.Text = "-" + answerTextBox.Text;
            }
            else
            {
                answerTextBox.Text = answerTextBox.Text.Substring(1);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if(answerTextBox.Text != "0")
            {
                answerTextBox.Text = answerTextBox.Text.Substring(0, answerTextBox.Text.Length - 1);
            }
            if(answerTextBox.Text.Length == 0 && !answerTextBox.Text.Contains("-"))
            {
                answerTextBox.Text = "0";
            }
            if(answerTextBox.Text.Length == 1 && answerTextBox.Text.Contains("-"))
            {
                answerTextBox.Text = "0";
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            switch(operation)
            {
                case "+":
                    double sum = double.Parse(temp) + lastNumber;
                    answerTextBox.Text = sum.ToString();
                    break;
                case "-":
                    double difference = double.Parse(temp) - lastNumber;
                    answerTextBox.Text = difference.ToString();
                    break;
                case "x":
                    double product = double.Parse(temp) * lastNumber;
                    answerTextBox.Text = product.ToString();
                    break;
                case "/":
                    if(answerTextBox.Text != "0")
                    {
                        double quotient = double.Parse(temp) / lastNumber;
                        answerTextBox.Text = quotient.ToString();
                    }
                    else
                    {
                        answerTextBox.Text = "Invalid";
                    }
                    break;
            }
            equalsButtonPressed = true;
        }
    }
}
