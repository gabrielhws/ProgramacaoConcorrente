using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula3ProgConcorrente
{
    class Program
    {
        private double saldo = 100;
        static void Main(string[] args)
        {
            Program p = new Program();

            for (int i = 0; i < 10; i++)
            {
                new Thread(p.Credito).Start();
                new Thread(p.Debito).Start();
                Console.WriteLine("Saldo Final:" + p.saldo);
            }

            Console.ReadKey();

        }

        private void Credito()
        {
            saldo = saldo + 100;

            Console.WriteLine("Cretidou + 100");
        }

        private void Debito()
        {
            if (saldo>=200)
            {
                saldo = saldo - 200;
                Console.WriteLine(string.Format("Debitou {0}: {1}",++i,saldo));
            }
            Thread.Sleep(500);
            
        }
    }
}
