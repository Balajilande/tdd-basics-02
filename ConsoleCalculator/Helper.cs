using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public static class Helper
    {
        public static bool IsValidInput(char key)
        {
            return Regex.IsMatch(key.ToString(), RegExp.allowedOperators) || Regex.IsMatch(key.ToString(), RegExp.allowedchars);
        }

        public static bool IsSignPress(Char key)
        {
            return Regex.IsMatch(key.ToString(), RegExp.allowedOperators);
        }

        public static double ToggleSign(double num)
        {

            if (Math.Sign(num) == 1)
                num = num * (-1);
            else
                num = num * (1);

            return num;
        }
    }
}
