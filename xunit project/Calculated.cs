using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xunit_project
{
    public class Calculator
    {

        public List<int> Fibo => new List<int>{1, 1, 2, 3, 5, 8, 13};


        public int add(int a , int b)
        {
            return a + b ;
        }


        public double addDouble(double a, double b)
        {
            return a + b;
        }

        public int multiple (int a , int b )
        {
            return a * b;
        }

        public string ReturnString (string name)
        {
            return name;
        }


        public string  ReturnNull ()
        {
            return null;
        }
    }

}
