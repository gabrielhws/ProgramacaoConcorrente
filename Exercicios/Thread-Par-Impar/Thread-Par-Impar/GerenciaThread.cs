using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;

namespace Thread_Par_Impar
{
    public class GerenciaThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER para iniciar");
            Console.ReadLine();

            Thread t = new Thread(ChamarThreadImpar);
            t.Start();

            for (int i = 1; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
            
            Console.ReadKey();
        }

       static void ChamarThreadImpar()
        {
          
            for (int i = 1; i < 11; i++)
            {
                if (~i % 2 == 0)
                {

                    Console.WriteLine(i); 
                    Thread.Sleep(1000);
                }

            }
        }

    }
}
