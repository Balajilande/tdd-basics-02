using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void addtionwithtwoNumber_test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('0');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            Assert.Equal("12", cal.SendKeyPress('='));
        }

        [Fact]
        public void IgnoreInvalidInput_test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('0');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('A');
            Assert.Equal("12", cal.SendKeyPress('='));
        }

        [Fact]
        public void dividedbyZeroexception_test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('0');
            cal.SendKeyPress('/');
            cal.SendKeyPress('0');
            Assert.Equal("-E-", cal.SendKeyPress('='));

        }

        [Fact]
        public void multipleZeroBeforeDecimalPoint_test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('0');
            cal.SendKeyPress('0');
            cal.SendKeyPress('.');
            cal.SendKeyPress('.');
            cal.SendKeyPress('.');
            cal.SendKeyPress('0');
            cal.SendKeyPress('0');
            Assert.Equal("0.001", cal.SendKeyPress('1'));

        }

        [Fact]
        public void ToggleSign_Test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('s');
            cal.SendKeyPress('s');
            cal.SendKeyPress('s');
            Assert.Equal("10", cal.SendKeyPress('='));
        }

        [Fact]
        public void AddtionwithmultipleplusSign_Test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');
            cal.SendKeyPress('3');
            cal.SendKeyPress('+');
            Assert.Equal("6", cal.SendKeyPress('='));
        }


        [Fact]
        public void AddtionwithClear_Test()
        {
            var cal = new Calculator();
            cal.SendKeyPress('1');
            cal.SendKeyPress('+');
            cal.SendKeyPress('2');
            cal.SendKeyPress('+');            
            Assert.Equal("0", cal.SendKeyPress('c'));
        }


    }
}
