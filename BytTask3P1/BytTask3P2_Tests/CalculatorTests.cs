using BytTask3P2;

namespace BytTask3P2_Tests;

public class Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // Add Method Tests............
        [Test]
        [TestCase(75,35,'+',110)] //...
        [TestCase(5, 3, '+', 8)]
        [TestCase(-5, 3, '+', -2)]
        [TestCase(5, -3, '+', 2)]
        [TestCase(-5, -3, '+', -8)]
        [TestCase(0, 0, '+', 0)]
        [TestCase(0, 5, '+', 5)]
        [TestCase(5, 0, '+', 5)]
        [TestCase(2.5, 3.7, '+', 6.2)]
        [TestCase(1.1, 2.2, '+', 3.3)]
        [TestCase(double.MaxValue, 0, '+', double.MaxValue)]
        [TestCase(double.MinValue, 0, '+', double.MinValue)]
        public void Add_ValidOperation_ReturnsCorrectResult(double a, double b, char operation, double expected)
        {
            var result = _calculator.Add(a, b, operation);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(5, 3, '-')]
        [TestCase(5, 3, '*')]
        [TestCase(5, 3, '/')]
        [TestCase(5, 3, null)]
        [TestCase(5, 3, ' ')]
        [TestCase(5, 3, 'a')]
        public void Add_InvalidOperation_ThrowsArgumentException(double a, double b, char? operation)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add(a, b, operation));
        }

        // Subtract Method Tests:
        [Test]
        [TestCase(10, 3, '-', 7)]
        [TestCase(5, 8, '-', -3)]
        [TestCase(-5, 3, '-', -8)]
        [TestCase(5, -3, '-', 8)]
        [TestCase(-5, -3, '-', -2)]
        [TestCase(0, 0, '-', 0)]
        [TestCase(0, 5, '-', -5)]
        [TestCase(5, 0, '-', 5)]
        [TestCase(5.5, 2.2, '-', 3.3)]
        [TestCase(1.1, 0.1, '-', 1.0)]
        [TestCase(double.MaxValue, double.MaxValue, '-', 0)]
        public void Subtract_ValidOperation_ReturnsCorrectResult(double a, double b, char operation, double expected)
        {
            var result = _calculator.Subtract(a, b, operation);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(5, 3, '+')]
        [TestCase(5, 3, '*')]
        [TestCase(5, 3, '/')]
        [TestCase(5, 3, null)]
        [TestCase(5, 3, 'x')]
        public void Subtract_InvalidOperation_ThrowsArgumentException(double a, double b, char? operation)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Subtract(a, b, operation));
        }

        // Multiplying Method Tests
        [Test]
        [TestCase(5, 3, '*', 15)]
        [TestCase(-5, 3, '*', -15)]
        [TestCase(5, -3, '*', -15)]
        [TestCase(-5, -3, '*', 15)]
        [TestCase(0, 5, '*', 0)]
        [TestCase(5, 0, '*', 0)]
        [TestCase(0, 0, '*', 0)]
        [TestCase(2.5, 4, '*', 10)]
        [TestCase(1.5, 2.5, '*', 3.75)]
        [TestCase(double.MaxValue, 1, '*', double.MaxValue)]
        [TestCase(double.MaxValue, 0, '*', 0)]
        public void Multiply_ValidOperation_ReturnsCorrectResult(double a, double b, char operation, double expected)
        {
            var result = _calculator.Multiply(a, b, operation);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(5, 3, '+')]
        [TestCase(5, 3, null)]
        [TestCase(5, 3, '-')]
        [TestCase(5, 3, '/')]
        [TestCase(5, 3, 'm')]
        public void Multiply_InvalidOperation_ThrowsArgumentException(double a, double b, char? operation)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Multiply(a, b, operation));
        }

        // Divide Method Tests:
        [Test]
        [TestCase(10, 2, '/', 5)]
        [TestCase(15, 3, '/', 5)]
        [TestCase(-10, 2, '/', -5)]
        [TestCase(10, -2, '/', -5)]
        [TestCase(-10, -2, '/', 5)]
        [TestCase(0, 5, '/', 0)]
        [TestCase(5, 2, '/', 2.5)]
        [TestCase(1, 3, '/', 0.333333)]
        [TestCase(7.5, 2.5, '/', 3)]
        [TestCase(double.MaxValue, 1, '/', double.MaxValue)]
        [TestCase(double.MaxValue, double.MaxValue, '/', 1)]
        public void Divide_ValidOperation_ReturnsCorrectResult(double a, double b, char operation, double expected)
        {
            var result = _calculator.Divide(a, b, operation);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(5, 0, '/')]
        [TestCase(-5, 0, '/')]
        [TestCase(0, 0, '/')]
        [TestCase(double.MaxValue, 0, '/')]
        [TestCase(double.MinValue, 0, '/')]
        public void Divide_ByZero_ThrowsDivideByZeroException(double a, double b, char operation)
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b, operation));
        }

        [Test]
        [TestCase(5, 3, '+')]
        [TestCase(5, 3, '-')]
        [TestCase(5, 3, '*')]
        [TestCase(5, 3, null)]
        [TestCase(5, 3, 'd')]
        public void Divide_InvalidOperation_ThrowsArgumentException(double a, double b, char? operation)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(a, b, operation));
        }

        // Some additional tests....
        [Test]
        [TestCase(double.MaxValue, double.MaxValue, '+')]
        public void Add_VeryLargeNumbers_ThrowsNoException(double a, double b, char operation)
        {
            Assert.DoesNotThrow(() => _calculator.Add(a, b, operation));
        }

        [Test]
        [TestCase(double.Epsilon, double.Epsilon, '+', 2 * double.Epsilon)]
        [TestCase(double.Epsilon, double.Epsilon, '-', 0)]
        public void Operations_WithEpsilonValues_BehaveCorrectly(double a, double b, char operation, double expected)
        {
            switch (operation)
            {
                case '+':
                    Assert.That(_calculator.Add(a, b, operation), Is.EqualTo(expected));
                    break;
                case '-':
                    Assert.That(_calculator.Subtract(a, b, operation), Is.EqualTo(expected));
                    break;
            }
        }
        
        [Test]
        public void AllMethods_NullOperation_ThrowsArgumentException()
        {
            char? nullOperation = null;
            
            Assert.Throws<ArgumentException>(() => _calculator.Add(5, 3, nullOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Subtract(5, 3, nullOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Multiply(5, 3, nullOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Divide(5, 3, nullOperation));
        }
        
        //some invalid characters tests:
        [Test]
        [TestCase(' ')]
        [TestCase('a')]
        [TestCase('1')]
        [TestCase('?')]
        [TestCase('\\')]
        public void AllMethods_InvalidCharacterOperation_ThrowsArgumentException(char invalidOperation)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Add(5, 3, invalidOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Subtract(5, 3, invalidOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Multiply(5, 3, invalidOperation));
            Assert.Throws<ArgumentException>(() => _calculator.Divide(5, 3, invalidOperation));
        }
        
        [Test]
        public void Operation_ConsistencyAcrossValues_WorksCorrectly()
        {
            double[] testValues = { 1, 2, 5, 10, 100, -1, -5, 0.5, 2.5 };

            foreach (double a in testValues)
            {
                foreach (double b in testValues)
                {
                    if (b != 0)
                    {
                        Assert.That(_calculator.Add(a, b, '+'), Is.EqualTo(a + b));
                        Assert.That(_calculator.Subtract(a, b, '-'), Is.EqualTo(a - b));
                        Assert.That(_calculator.Multiply(a, b, '*'), Is.EqualTo(a * b));
                        Assert.That(_calculator.Divide(a, b, '/'), Is.EqualTo(a / b).Within(0.0001));
                    }
                }
            }
        }
    }
}