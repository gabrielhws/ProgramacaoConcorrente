using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Console
{
    public class Principal
    {
        
        private static void Main(string[] args)
        {
            System.Console.WriteLine("### Bem Vindo ao Chat ###");
            while (true)
            {
                using (var mutex = new Mutex(false, "01"))
                {
                   
                    if (!mutex.WaitOne())
                    {
                        System.Console.WriteLine("TimeOut");
                        return;
                        
                    }
                    Read();
                    Writer();
                    mutex.ReleaseMutex();
                    
                }
            }
            System.Console.ReadLine();
            
        }

        private static void Read()
        {
     
            string texto = File.ReadAllText(@"D:\Codes\Git\ProgramacaoConcorrente\Exercicios\Chat\Chat.Console\arquivo.txt");

            System.Console.WriteLine("\t", texto);
          
        }

        private static void Writer()
        { 
            using (StreamWriter file = new StreamWriter(@"D:\Codes\Git\ProgramacaoConcorrente\Exercicios\Chat\Chat.Console\arquivo.txt", true))
            {
                System.Console.WriteLine("Escreva sua mensagem");
                var digitado = System.Console.ReadLine();

                file.WriteLine(digitado);
            }

        }
    }
}
