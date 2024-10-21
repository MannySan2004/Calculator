///////////////////////////////////////////////////////
// TINFO 200 A, Winter 2024
// UWTacoma SET, Manuel Rosales
// 2024-01-27 - Cs4 - C# programming lab - Calcuator
// This program is a calculator that takes in doubles (decimals or integers)
// and buts them through the 4 basic mathematical operations including integers
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

////////////////////////////////////////////////////////////////
// Change History
// Date ------- Developer --- Description
// 2024-01-16 - manuer3 - Intial creation of file to represent this calculator
// 2024-01-16 - manuer3- Added number click functionality to buttons 7, 8, and 9
// 2024-01-18 - manuer3 - Added number click functionality to rest of the number buttons (0-6)
// 2024-01-18 - manuer3 - Added functionality to clear and clear entry buttons
// 2024-01-23 - manuer3 - Added functionality to math operation buttons
// 2024-01-23 - manuer3 - Added functionality to backspace button, postive/negative button, and decimal button
// 2024-01-23 - manuer3 - Added calculator memory, removed leading 0 by editing
// 2024-01-27 - manuer3 - Debugged the editing functions of the calculator

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //this is what we want to happen when the any button is clicked on
        private void numBtn_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            Display.Text = Display.Text + Btn.Text;

        }

        //This method is in charge of clearing the current text on
        //the display
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
        }

        //these 3 instance vars will hold the stage of the before
        // and during math operations
        //storage for the 1st operand of the math operation
        private double leftOperand = 0.0;
        
        //storage for the current selected math operation
        private string mathOperation = string.Empty;

        //signals that we have started into a math operation
        private bool beginMathOp = false;

        //it tells  us what operation will be used on whatever event was clicked
        private void mathOpBtn_Click(object sender, EventArgs e)
        {

            //Signal that a math operation has happened
            beginMathOp = true;

            //load up the global class wide instance vars
            leftOperand = double.Parse(Display.Text);

            //Button btn = (Button)sender
            mathOperation = ((Button)sender).Text;
            //This clears the display
            Display.Clear();
        }
        //This takes the left operand and it puts it into an expression for each sepecifc operation
        // spitting out the answerr of the math operator
        private void equalsBtn_Click(object sender, EventArgs e)
        {
            // This a switch case which can be used instead of an if/else statement,
            // each case represents an operations that are used in math and an exception
            switch (mathOperation)
            {
                case "+":
                    Display.Text = (leftOperand + double.Parse(Display.Text)).ToString();
                    break;
                case "-":
                    Display.Text = (leftOperand - double.Parse(Display.Text)).ToString();
                    break;
                case "x":
                    Display.Text = (leftOperand * double.Parse(Display.Text)).ToString();
                    break;
                case "/":
                    Display.Text = (leftOperand / double.Parse(Display.Text)).ToString();
                    break;
                default:
                    MessageBox.Show("ERROR This code should be unreachable :: " +
                        "From the switch in the equals button handler");
                    break;
            }
        }
        //This method changes a positive integer into a negative (vice versa)
        private void integerBtn_Click(Object sender, EventArgs e)
        {
            //same basic operation  as the "equal handler", but negation is
            //unary and does not the left operand    
            Display.Text = (- double.Parse(Display.Text)).ToString();
        }

        //When this event is clicked on it clears the entire operation inputted
        private void clearBtn_Click(object sender, EventArgs e)
        {
            // These are the things that happen when you clear the display
            beginMathOp = false;
            leftOperand = 0.0;
            mathOperation = string.Empty;

            Display.Text = "";
        }

        //This event simply deletes the most current character on the display
        private void backspaceBtn_Click(object sender, EventArgs e)
        {

            //This if statement takess the string and uses a substring
            // method to select the most recent character on the display
            if (Display.Text.Length > 1) 
            { 
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
        }

        //This event handler will display a decimal when it is clicked
        private void decimalBtn_Click(object sender,EventArgs e)
        {
            Display.Text = Display.Text.Contains(".") ? Display.Text : Display.Text + ".";
        }
    }
}
