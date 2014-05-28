
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Etapa1_Passo2
{
    public class ATPS
    {

        static int max = 5000;
        static int[] buffer = new int[max];

        static void Main(string[] args)
        {
            ATPS atps = new ATPS();
            atps.init();
            Console.ReadKey();
        }

        private void Produtora()
        {
            for (int i = 0; i < max; i++)
                buffer[i] = i;
        }

        private void Consumidora()
        {
            for (int i = 0; i < max; i++)
            {
                DateTime inicio = DateTime.Now;
                buffer[i] = buffer[i];
                Thread.Sleep(10000);
                DateTime fim = DateTime.Now;

                Console.WriteLine("Inicio: {0:mm:ss} - Fim: {1:mm:ss}", inicio, fim);
            }
        }

        private void init()
        {
            Produtora();
            Thread tc = new Thread(Consumidora);

            tc.Start();
            tc.Join();
        }
    }
}

