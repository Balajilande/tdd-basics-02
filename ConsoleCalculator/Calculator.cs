using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public class Calculator
    {
        string inputnumber;
        List<double> numbers = new List<double>();
        List<char> operations = new List<char>();

        public string SendKeyPress(char key)
        {
            string displayinput = string.Empty;

            if (Helper.IsValidInput(key))
            {
                if (key == 'c' || key == 'C')
                {
                    numbers.Clear();
                    operations.Clear();
                    inputnumber = string.Empty;
                    return "0";
                }

                if (!Helper.IsSignPress(key))
                {
                    if (!string.IsNullOrEmpty(inputnumber) && inputnumber.Contains(".") && key == '.')
                        return inputnumber;

                    if (key == 's' || key == 'S')
                    {
                        inputnumber = Helper.ToggleSign(Convert.ToDouble(inputnumber)).ToString();
                    }
                    else
                    {
                        inputnumber += key;
                    }
                    displayinput = inputnumber;
                }
                else
                {
                    if (string.IsNullOrEmpty(inputnumber) && operations.Count > 0)
                    {
                        operations[operations.Count - 1] = key;
                    }
                    else
                    {
                        operations.Add(key);
                        numbers.Add(Convert.ToDouble(inputnumber));
                        displayinput = inputnumber;
                        inputnumber = string.Empty;
                    }

                }

                if (key == '=')
                {
                    if (numbers.Count != operations.Count)
                    {
                        operations.RemoveAt(numbers.Count - 1);
                    }
                    return Calculate();
                }
                return Convert.ToDouble(displayinput).ToString();
            }
            else
            {
                return inputnumber;
            }
           

        }

        private string Calculate()
        {
            double result = 0;
            bool isFirstOperation = true;
            int i = 0;
            foreach (var key in operations)
            {

                switch (key)
                {
                    case '+':
                        if (isFirstOperation)
                            result = numbers[i] + numbers[i + 1];
                        else
                            result = result + numbers[i + 1];
                        break;
                    case '-':
                        if (isFirstOperation)
                            result = numbers[i] - numbers[i + 1];
                        else
                            result = result - numbers[i + 1];
                        break;
                    case 'X':
                    case 'x':
                        if (isFirstOperation)
                            result = numbers[i] * numbers[i + 1];
                        else
                            result = result * numbers[i + 1];
                        break;
                    case '/':
                        if (isFirstOperation)
                            result = numbers[i] / numbers[i + 1];
                        else
                            result = result / numbers[i + 1];

                        break;
                    case '=':
                        if (Double.IsInfinity(result))
                            return @"-E-";

                        return result.ToString();
                    default:
                        break;
                }
                isFirstOperation = false;
                i++;
            }
            return result.ToString();
        }  

    }
}
