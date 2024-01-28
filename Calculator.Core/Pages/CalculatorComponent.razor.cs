using System;
using Microsoft.AspNetCore.Components;

namespace Calculator.Core.Pages
{
    public partial class CalculatorComponent : ComponentBase
    {
        protected string currentResult;

        private string firstValue;
        private bool waitingForSecondValue;
        private string operand;

        public CalculatorComponent()
        {
            currentResult = "0";
            firstValue = "";
            waitingForSecondValue = false;
            operand = null;
        }

        protected void EnterDigit(string digit)
        {
            if (currentResult == "0")
            {
                currentResult = "";
            }

            currentResult = string.Concat(currentResult, digit);
        }

        protected void EnterDecimal()
        {
            if (!currentResult.Contains("."))
            {
                currentResult = string.Concat(currentResult, ".");
            }
        }

        protected void HandleOperand(string selectedOperator)
        {
            firstValue = currentResult;
            operand = selectedOperator;

            if (!waitingForSecondValue)
            {
                currentResult = "0";
            }

            waitingForSecondValue = true;
        }

        protected void Clear()
        {
            currentResult = "0";
            firstValue = "";
            waitingForSecondValue = false;
            operand = null;
        }

        protected void Calculate()
        {
            try
            {
                switch(operand)
                {
                    case "+":
                        Add();
                        break;
                    case "-":
                        Subtract();
                        break;
                    case "*":
                        Multiply();
                        break;
                    case "/":
                        Divide();
                        break;
                    default:
                        Clear();
                        break;
                }
            }
            catch
            {
                currentResult = "Error, Press AC to Continue";
            }
            finally
            {
                waitingForSecondValue = false;
            }
        }

        private void Add()
        {
            currentResult = (Convert.ToDouble(firstValue) + Convert.ToDouble(currentResult)).ToString();
        }

        private void Subtract()
        {
            currentResult = (Convert.ToDouble(firstValue) - Convert.ToDouble(currentResult)).ToString();
        }

        private void Multiply()
        {
            currentResult = (Convert.ToDouble(firstValue) * Convert.ToDouble(currentResult)).ToString();
        }

        private void Divide()
        {
            if (Convert.ToDouble(currentResult) != 0)
            {
                currentResult = (Convert.ToDouble(firstValue) / Convert.ToDouble(currentResult)).ToString();
            }

            else
            {
                currentResult = "Cannot Divide by Zero";
            }
        }
    }
}
