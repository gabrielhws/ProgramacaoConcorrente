using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Exercicio5
    {
        static int [] buffer = new int[100];
        private int Count = 0;

        static void Main(string[] args)
        {
            Exercicio5 ex5 = new Exercicio5();

            ex5.Init();
            Console.WriteLine();
        }

        private void Produtora()
        {
            while (true)
            {
                if (Count<100)
                {
                    buffer[Count] = Count ++;
                    Thread.Sleep(500);
                }
            }
        }

        private void Consumidora()
        {
            while (true)
            {
                if (Count>=100)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(buffer[i]);
                    }
                    for (int i = 10; i < 100; i++)
                    {
                        buffer[i - 10] = buffer[i];

                    }

                    Count -= 10;
                }
            }
        }

        private void Init()
        {
            Thread tp = new Thread(Produtora);
            Thread tc = new Thread(Consumidora);

            tp.Start();
            tc.Start();
        }
    }
}
