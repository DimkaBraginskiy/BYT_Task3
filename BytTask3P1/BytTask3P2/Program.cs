namespace BytTask3P2;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello. This is a presentation of a calculator...");
            Console.WriteLine("Enter number a: ");
            var a = Console.ReadLine();
            Console.WriteLine("Enter number b: ");
            var b = Console.ReadLine();
            
            Console.WriteLine("Enter operation (+, -, *, /): ");
            var operation = Console.ReadLine();
            
            Calculator calculator = new Calculator();
            double numA, numB;
            if (!double.TryParse(a, out numA) || !double.TryParse(b, out numB))
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
                continue;
            }
            try
            {
                double result = operation switch
                {
                    "+" => calculator.Add(numA, numB, '+'),
                    "-" => calculator.Subtract(numA, numB, '-'),
                    "*" => calculator.Multiply(numA, numB, '*'),
                    "/" => calculator.Divide(numA, numB, '/'),
                    _ => throw new ArgumentException("Invalid operation")
                };
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("Do you want to perform another calculation? (y/n): ");
            var continueInput = Console.ReadLine();
            if (continueInput == null || continueInput.ToLower() != "y")
            {
                break;
            }
        }
    }
}