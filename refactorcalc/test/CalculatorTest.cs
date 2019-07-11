using NUnit.Framework;
using System.Collections.Generic;

namespace refactorcalc
{
    [TestFixture]
    public class ValidatorsTest
    {
        [Test, TestCaseSource("ValidNumbers")]
        public void isValidNumberTest(string input) =>
            Assert.True(BasicOperation.isValidNumber(input), $"{input} is not valid input");
        //Assert.True(BasicOperation.isValidNumber("1"), "1 is valid input");

        [Test, TestCaseSource("inValidNumbers")]
        public void isValidNumberInvalidTest(string input) =>
                    Assert.False(BasicOperation.isValidNumber(input), $"{input} is not valid input");
        //Assert.True(BasicOperation.isValidNumber("1"), "1 is valid input");

        [Test, TestCaseSource("inValidNumbers")]
        public void isValidNumberWhole(string input) =>
                Assert.False(BasicOperation.isValidNumber(input), $"{input} is not valid input");

      
        public void isValidNumberWholeTest()
        {
            Assert.False(BasicOperation.isValidNumberWhole("1.5"), "$a is not a whole number");
            Assert.False(BasicOperation.isValidNumberWhole("aaa"), "$a is not a whole number");
            Assert.True(BasicOperation.isValidNumberWhole("1"), "1 is valid whole number");
        }
        [Test]
        public void inputNumberTest()
        {
            //A
        }
        static string[] inValidNumbers = new string[] { "a", "z", " ", "я", "0a65", "-", "A", "Я", "!@#$%^&", "ら" };
        static string[] ValidNumbers = new string[] { "1", "0", "-1", "100000", "-100000", "0.12", "-0.12", "500.501543" };
    }
    public class BMITest
    {
        User vasyan;
        [SetUp]
        public void SetUp()
        {
            vasyan = new User();
        }

        [Test, TestCaseSource("BmiCalculations")]
        public void calculateBMITest(double weight, double height, double result)
        {
            Assert.That(vasyan.calculateBMI(weight, height), Is.EqualTo(result).Within(0.01));
        }

        [Test, TestCaseSource("BMIData")] //to do;
        public void inputNewUserDataTest(string name, double weight, double height, double result)
        {
            var user = new User();
            user.Name = name;
            user.Weight = weight;
            user.Height = height;
            //Assert.That(, Is.EqualTo(result).Within(0.01));
        }
        static object[] BMIData =
            {
            new object[] {"test",55,150,24.44},
            new object[] {"test",74,180,22.84},
            new object[] {"test",85,150,37.78},
            new object[] {"test",70,170,24.22}

        //new double{{1,2,3}}
    };
        static object[] BmiCalculations =
            {
            new object[] {55,150,24.44},
            new object[] {74,180,22.84},
            new object[] {85,150,37.78},
            new object[] {70,170,24.22}

        //new double{{1,2,3}}
    };
    }

    public class CalculatorOperations
    {
        [Test, TestCaseSource("calcSum")]
        public void calculatorSumTest(double a, double b, double result)
        {
            var basicOperation = new CalculatorSum();
            basicOperation.A = a;
            basicOperation.B = b;
            basicOperation.Calculate();
            Assert.AreEqual(basicOperation.Result, result);
        }
        [Test, TestCaseSource("calcSub")]
        public void calculatorSubTest(double a, double b, double result)
        {
            var basicOperation = new CalculatorSub();
            basicOperation.A = a;
            basicOperation.B = b;
            basicOperation.Calculate();
            Assert.That(basicOperation.Result, Is.EqualTo(result).Within(0.01));
        }
        [Test, TestCaseSource("calcMultiply")]
        public void calculatorMutliplyTest(double a, double b, double result)
        {
            CalculatorMultiply basicOperation = new CalculatorMultiply();
            basicOperation.A = a;
            basicOperation.B = b;
            basicOperation.Calculate();
            Assert.That(basicOperation.Result, Is.EqualTo(result).Within(0.01));

        }
        [Test, TestCaseSource("calcDivision")]
        public void calcDivisionTest(double a, double b, double result)
        {
            var basicOperation = new CalculatorDivision();
            basicOperation.A = a;
            basicOperation.B = b;
            basicOperation.Calculate();
            Assert.That(basicOperation.Result, Is.EqualTo(result).Within(0.01));
            //Assert.AreEqual(basicOperation.Result, result);

        }
        static object[] calcSub =
            {
            new object[] {2,1,1},
            new object[] {99999.9,55555.5,44444.4},
            new object[] {0,1,-1},
            new object[] {0.1,1,-0.9},
            new object[] {0,0,0},
            new object[] {-99,-1,-98},
            new object[] {0.1,-0.1,0.2}
            };
        static object[] calcSum =
            {
            new object[] {1,2,3},
            new object[] {2,4,6},
            new object[] {0,1,1},
            new object[] {0,0,0},
            new object[] {-99,-1,-100},
            new object[] {0.1,-0.1,0},
            new object[] {10.5,10.6,21.1},
            new object[] {10,0.99,10.99}
            };
        static object[] calcDivision =
            {
            new object[] {1,2,0.5},
            new object[] {2,1,2},
            new object[] {2,4,0.5},
            new object[] {0,1,0},
            //new object[] {0,0,"NaN"}, 0 can't be used by input method.
            new object[] {-99,-1,99},
            new object[] {0.1,-0.1,-1},
            new object[] {10.5,10.6,0.99}
            };
        static object[] calcMultiply = // to do;
            {
            new object[] {1,2,2},
            new object[] {0,2,0},
            new object[] {200,400,80000},
            new object[] {1,0,0},
            new object[] {0,0,0},
            new object[] {-99,-1,99},
            new object[] {0.1,-0.1,-0.01},
            new object[] {-145545.56,0.99,-144090.1044}
            };
    }

    public class MatrixTests
    {


        //[Test, TestCaseSource("calcDivision")]
        //public void MatrixValidInputs()
        //{
        //    //Matrix.fillMatrixWithInput();
        //    //Assert.AreEqual(basicOperation.Result, result);

        //}
        [Test, TestCaseSource("validMatrixSize")]
        public void MatrixSizePositiveTest(string a,int b)
        {
            Assert.AreEqual(MatrixMultiply.defineMatrixSize(a),b);
        }
        //[Test, TestCaseSource("invalidMatrixSize")]
        //public void MatrixSizeNegativeTest(string a)
        //{
        //    Assert.Fail("invalid data detected - can't define matrix size by \"{0}\" ",a,MatrixMultiply.defineMatrixSize(a));
        //}
        static string[] invalidMatrixSize = new string[] { "0", "-1", "-100000", "1.5", "0.12", "-0.12", "aaaa","%$","select * from credit c where c.id in"};
        static object[] validMatrixSize =
            {
            new object[] {"1",1},
            new object[] {"2",2},
            new object[] {"100",100}
            };
    }
}

