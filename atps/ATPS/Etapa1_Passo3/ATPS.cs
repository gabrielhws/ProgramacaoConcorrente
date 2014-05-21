using System;
using System.Threading;

namespace Etapa1_Passo3
{
    class ATPS
    {
        static int max = 5000;
        static int[] buffer = new int[max];
        //int maxTh;

        static void Main(string[] args)
        {

            ATPS atps = new ATPS();
            Console.WriteLine("Digite a quantidade de thread a serem executadas:");
            string qtdeTh = Console.ReadLine();
            if (qtdeTh != "")
            {
                //atps.maxTh = Convert.ToInt32(qtdeTh);
                atps.Init(Convert.ToInt32(qtdeTh));
            }

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
                Thread ts = new Thread(ImprimiMax);
                Thread.Sleep(10000);
                DateTime fim = DateTime.Now;

                Console.WriteLine("Inicio: {0:mm:ss}  - Fim: {1:mm:ss} ", inicio, fim);
            }
        }

        private void Init(int maxTh)
        {
            for (int i = 0; i < maxTh; i++)
            {
                Produtora();
                Thread tc = new Thread(Consumidora);
                tc.Start();
                tc.Join();
            }

        }


        void ImprimiMax()
        {
            Console.WriteLine("Thead número: ", max);
        }
    }
}

