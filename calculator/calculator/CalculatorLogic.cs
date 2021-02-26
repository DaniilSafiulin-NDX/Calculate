using System;

namespace calculator
{
    public class CalculatorLogic
    {
        const String divideByZeroMessage = "Divide by zero!!";
        const String fpFormat = "";

        private decimal? firstOperator;
        private char? operation;
        private bool divideByZeroFlag;

        /* temporary storage for the numerals that enters */
        private string currentOperator;


        public CalculatorLogic()
        {
            /* just reset than start */
            reset();
        }

        public String GetExpression() {
            if (divideByZeroFlag)
            {
                return divideByZeroMessage;
            }
            else if (currentOperator.Equals(""))
            {

                if (firstOperator == null) 
                {
                    /* For empty equation */
                    return "0";
                }
                else
                {
                    /* For equation which contain first operator and operation symbol*/
                    return ((decimal)firstOperator).ToString(fpFormat) + operation;
                }
            }
            else if (operation == null)
            {
                /* For only one operator */
                return currentOperator;
            }
            else
            {
                /* For correct equation */
                return ((decimal)firstOperator).ToString(fpFormat) + operation + currentOperator;
            }
        }

        private void reset()
        {
            divideByZeroFlag = false;
            firstOperator = null;
            operation = null;
            currentOperator = "";
        }

        public void addSymbolToExpression(char input)
        {

            /* Cleaning  after divide by zero or clear signal arrival*/
            if (divideByZeroFlag || isClear(input))
            {
                divideByZeroFlag = false;
                reset();
            }

            if (isDot(input))
            {
                addDotToCurrentOperator();
            }
            
            else if (isNumber(input))
            {
                addNumberToCurrentOperator(input);
            }

            else if (isOperator(input))
            {
                addOperatorToExpression(input);
            }

            else if (isEquals(input))
            {
                if (isCompleteExpression())
                {
                    calculate();
                }
            }
        }

        private void addOperatorToExpression(char _operator)
        {
            /* For like 1+ */ 
            if (operation == null &&
                !currentOperator.Equals("") &&
                !currentOperator.Equals("-"))
            {
                firstOperator = decimal.Parse(currentOperator);
                currentOperator = "";
                operation = _operator;
            }
            else if (operation != null)
            {
                /* For like 1+- */
                if (currentOperator.Equals(""))
                {
                    operation = _operator;
                }
                /* For like 1+1- */
                else 
                {
                    calculate();
                    addOperatorToExpression(_operator);
                }
            }
            /* Special for minus in empty equation */
            else if (_operator == '-' && !currentOperator.Equals("-"))
            {
                currentOperator = "-";
            }
        }

        private void addNumberToCurrentOperator(char number)
        {
            if (!(currentOperator.Equals("0") || currentOperator.Equals("-0")))
            {
                currentOperator += number.ToString();
            }
        }
        
        private void addDotToCurrentOperator()
        {
            if (currentOperator.Contains(".")) 
            { /* Do nothing */ }
            else if (currentOperator.Equals(""))
            {
                /* Fill empty string */
                currentOperator = "0.";
            }
            else
            {
                /* just add dot */
                currentOperator += ".";
            }
        }

        private void calculate()
        {
            decimal secondOperator = decimal.Parse(currentOperator);
            decimal answer;
            if (operation == '+')
            {
                answer = (decimal)firstOperator + (decimal)secondOperator;
            }
            else if (operation == '-')
            {
                answer = (decimal)firstOperator - (decimal)secondOperator;

            }
            else if (operation == '*')
            {
                answer = (decimal)firstOperator * (decimal)secondOperator;

            }
            else
            {
                /*Devide by zero protection*/
                if (secondOperator == 0)
                {
                    reset();
                    divideByZeroFlag = true;
                    return;
                }
                else {
                    answer = (decimal)firstOperator / (decimal)secondOperator;
                }
            }
            reset();
            currentOperator = answer.ToString();
        }

        /* Utility */
        private Boolean isNumber(char symbol) 
        {
            return (symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' || symbol == '5' ||
                    symbol == '6' || symbol == '7' || symbol == '8' || symbol == '9' || symbol == '0');

        }

        private Boolean isEquals(char symbol)
        {
            return symbol == '=';
        }

        private Boolean isClear(char symbol)
        {
            return symbol == 'C';
        }

        private Boolean isOperator(char symbol) 
        {
            return (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/');
        }

        private Boolean isDot(char symbol) 
        {
            return symbol == '.';
        }

        private Boolean isCompleteExpression()
        {
            return firstOperator != null && operation != null && !currentOperator.Equals("");
        }

        
    }
}