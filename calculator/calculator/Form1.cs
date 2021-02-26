using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        private CalculatorLogic calculatorLogic;

        public Calculator(CalculatorLogic calculatorLogic)
        {
            InitializeComponent();
            this.calculatorLogic = calculatorLogic;

            updateLabel();
        }


        private void button0_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('0'); 
            updateLabel();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('1'); 
            updateLabel();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('2'); 
            updateLabel();
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('3'); 
            updateLabel();
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('4'); 
            updateLabel();
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('5'); 
            updateLabel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculatorLogic.addSymbolToExpression('6'); 
            updateLabel();
        }

        private void button7_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('7'); 
            updateLabel();
        }

        private void button8_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('8'); 
            updateLabel();
        }

        private void button9_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('9'); 
            updateLabel();
        }

        private void buttonDot_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('.'); 
            updateLabel();
        }

        private void buttonAdd_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('+'); 
            updateLabel();
        }

        private void buttonSubstract_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('-'); 
            updateLabel();
        }

        private void buttonMultiply_Click(object sender, EventArgs e) 
        { 
            calculatorLogic.addSymbolToExpression('*'); 
            updateLabel();
        }

        private void buttonDivide_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('/'); 
            updateLabel();
        }

        private void buttonEQ_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('=');
            updateLabel();
        }

        private void buttonC_Click(object sender, EventArgs e) 
        {
            calculatorLogic.addSymbolToExpression('C');
            updateLabel();
        }

        private void updateLabel()
        {
            calculatorScreen.Text = calculatorLogic.GetExpression();
        }

        private void checkboxAlwaysOnTop_Click(object sender, EventArgs e)
        {
            if (checkboxAlwaysOnTop.Checked == false)
            {
                TopMost = false;
            }
            else
            {
                TopMost = true;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
