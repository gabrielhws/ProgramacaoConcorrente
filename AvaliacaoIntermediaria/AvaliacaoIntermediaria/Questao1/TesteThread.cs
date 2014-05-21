using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Questao1
{
    class TesteThread
    {
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
            Console.ReadKey();
        }

        private static void Go()
        {
            for (int cycles = 0; cycles < 5; cycles++)
            {
              Console.WriteLine('?');  
            }
        }
    }
}
