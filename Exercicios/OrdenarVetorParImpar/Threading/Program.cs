using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        Integer v[] = {0, 1, 3, 4, 8, 9, 10};

        static void Main(string[] args)
        {
            Thread ti = new Thread(print);
            ti.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Y");
            }

            Console.Read();

        }

        static void print()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("X");
            }
        }
    }
}
