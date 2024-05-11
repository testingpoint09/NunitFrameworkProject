using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkPractice.Tests
{
    public  class GroupingDemo
    {
        [Test,Category("Smoke")]
        public static void MethodOne()
        {

            Console.WriteLine("Smoke methods calling");
        }

        [Test, Category("Smoke")]
        public static void MethodTwo()
        {

            Console.WriteLine("Smoke methods calling");
        }



        [Test, Category("Regression")]
        public static void MethodThree()
        {

            Console.WriteLine("Regression method calling");
        }


        [Test, Category("Sanity")]
        public static void MethodFour()
        {

            Console.WriteLine("Sanity method calling");
        }
    }
}
