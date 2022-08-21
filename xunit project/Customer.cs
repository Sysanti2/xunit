using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xunit_project
{
    public class Customer
    {
        public string Name => "Mehdi";
        public int Age => 30;


        public  virtual int getOrderByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            return 100;
        }

    }


    public class LoyalCostumer : Customer
    {
        public int Discount { get; set; }
         public LoyalCostumer()
        {
            Discount = 10;
        }
        public override int getOrderByName( string name)
        {
            return 101;
        }

    }

    public static class CostumerFactory
    {
        public static Customer CreateCustomerInstance(int order)
        {
            if (order >100)
            {
                return new LoyalCostumer ();
            }
            else
            {
                return new Customer(); 
            }

        }

    }
}
