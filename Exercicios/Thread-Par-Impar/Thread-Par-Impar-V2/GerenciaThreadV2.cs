using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Par_Impar_V2
{
    public class GerenciaThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER para iniciar");
            Console.ReadLine();

            GerenciaThread g = new GerenciaThread();
            Parallel.Invoke(
               new Action(g.ChamarThreadPar),
               new Action(g.ChamarThreadImpar)
                );
            Console.WriteLine("\nO Main foi encerrado.");
            Console.ReadLine();
        }

        public void ChamarThreadPar()
        {
            ThreadStart ts = new ThreadStart(ExecutarThread);

            Thread t = new Thread(ts);
            t.IsBackground = true;
            t.Start();

            for (int i = 1; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }

            }
            Console.ReadKey();
        }

        public void ChamarThreadImpar()
        {
            ThreadStart ts = new ThreadStart(ExecutarThread);

            Thread t = new Thread(ts);
            t.IsBackground = true;
            t.Start();

            for (int i = 1; i < 11; i++)
            {
                if (~i % 2 == 0)
                {

                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }

            }
            Console.ReadKey();
        }

        private void ExecutarThread()
        {

        }

    }
}