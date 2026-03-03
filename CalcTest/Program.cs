using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit
namespace CalcTest
{
    internal class Program
    {
        static void Main(string[] args)
         {
        }
    } 
    public class Calculator
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Нельзя делить на ноль");
            }
            return a / b;
        }
        public string CheckNumber(int number)
        {
            if (number > 0)
            {
                return "Положительное";
            }
            else if (number < 0)
            {
                return "Отрицательное";
            }
            else
            {
                return "Ноль";
            }
        }
    } 
}
 public class CalculatorTest
{
    private Calculator calc = new Calculator();
    [Fact]
    public void Divide_NormalNumbers_ReturnsResult()
    {
        int result = calc.Divide(10, 2);
        Assert.Equal(5, result);
    }
    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
    }
    [Fact]
    public void CheckNumber_Positive_ReturnsPositive()
    {
        string result = calc.CheckNumber(5);
        Assert.Equal("Положительное", result);
    }
    [Fact]
    public void CheckNumber_Negative_ReturnsNegative()
    {
        string result = calc.CheckNumber(-5);
        Assert.Equal("Отрицательное", result);
    }
    [Fact]
    public void CheckNumber_Zero_ReturnsZero()
    {
        string result = calc.CheckNumber(0);
        Assert.Equal("Ноль", result);
    }
}