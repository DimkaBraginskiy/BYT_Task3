using System.Net.Sockets;

namespace BytTask3P2;

public class Calculator
{
  public double Add(double a, double b, char? operation)
  {
    if (operation != null && operation == '+')
    {
      return a + b;
    }else
    {
      throw new ArgumentException("Invalid operation for Add method");
    }
  }
  
  public double Subtract(double a, double b, char? operation)
  {
    if (operation != null && operation == '-')
    {
      return a - b;
    }else
    {
      throw new ArgumentException("Invalid operation for Subtract method");
    }
  }
  
  public double Multiply(double a, double b, char? operation)
  {
    if (operation != null && operation == '*')
    {
      return a * b;
    }else
    {
      throw new ArgumentException("Invalid operation for Multiply method");
    }
  }
  
  public double Divide(double a, double b, char? operation)
  {
    if (operation != null && operation == '/')
    {
      if (b == 0)
      {
        throw new DivideByZeroException("Cannot divide by zero");
      }
      return a / b;
    }else
    {
      throw new ArgumentException("Invalid operation for Divide method");
    }
  }

}