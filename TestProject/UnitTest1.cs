using System;
using System.Collections.Generic;
using Xunit;
using xunit_project;

namespace TestProject
{

    public class CustomerFixture
    {
        public Customer cstm => new Customer();
    }

    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
    }
    public class UnitTest1 : IClassFixture<CalculatorFixture>, IClassFixture<CustomerFixture>
    {
        public readonly CalculatorFixture _calculatorFixture;
        public readonly CustomerFixture _customerFixture;

        public UnitTest1(CalculatorFixture calculatorFixture, CustomerFixture customerFixture)
        {
            _calculatorFixture = calculatorFixture;
            _customerFixture = customerFixture;
        }

        [Fact]
        [Trait ("Category", "Fibo")]
        public void Test1()
        {
            Assert.True(true);
        }
        // USE Equal() with to params to compaire 2 values 
        [Fact]
        [Trait("Category", "Fibo")]
        public void Add_GivenTwoValues_ReturnSum()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.add(1,2 );
            Assert.Equal(3, result);
        }

        //use equal with 3 params to add precision such as digits or ignoring case for string
        [Fact]
        [Trait("Category", "Fibo")]
        public void Add_GivenTwoDoubleValues_ReturnSum()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.addDouble(1.1, 2.2);
            Assert.Equal(3.3, result,1) ;
        }


        [Fact]
        [Trait("Category", "Number")]
        public void Add_GivenSrtring_ReturName()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.ReturnString("Hello");
            Assert.Contains("he", result, StringComparison.OrdinalIgnoreCase);
            Assert.DoesNotContain("he", result);
            Assert.StartsWith("He", result);
          //  Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", result);
        }


        // some boolean bool 
        [Fact]
        [Trait("Category", "Number")]
        public void Add_GivenBool_ReturStatus()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.ReturnNull();
            Assert.Null(result);
            Assert.True(string.IsNullOrEmpty(result));

        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNotIncludeZero ()
        {
            var calc = _calculatorFixture.Calc;
            Assert.All(calc.Fibo , n => Assert.NotEqual(0,n));
        }

        // collections 
        [Fact]
        [Trait("Category", "Fibo")]
        public void checkFibo ()
        {
            var calc = _calculatorFixture.Calc;
            var testcollection =new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            Assert.Equal(calc.Fibo, testcollection);
        }

        [Fact]
        [Trait("Category", "string")]
        public void CheckNameNotEmpty()
        {
            var cotsomer = _customerFixture.cstm;
            Assert.NotEmpty(cotsomer.Name);
            Assert.False(string.IsNullOrEmpty(cotsomer.Name));


        }


      [Fact]
        [Trait("Category", "Customer")]
        public void checklegidorDiscount()
        {
            var ctm = _customerFixture.cstm;
            Assert.InRange(ctm.Age, 20, 35);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void GetOrderByNameNotNull()
        {
            var cstm = _customerFixture.cstm;
            var exception =  Assert.Throws<ArgumentException>(() => cstm.getOrderByName(null));
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void LoyalCUstomerByOrder()
        {
            var Costumer = CostumerFactory.CreateCustomerInstance(101);
            Assert.IsType<LoyalCostumer>( Costumer);}
            }
}
