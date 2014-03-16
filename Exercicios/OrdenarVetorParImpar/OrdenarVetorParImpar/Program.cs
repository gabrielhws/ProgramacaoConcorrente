using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarVetorParImpar
{
    class Program
    {
        //private static void Main(string[] args)
        {
            int[] vetor = {1, 5, 0, 3, 4, 7, 2, 1};

            int temp = 0;
            int aux = 0;

            

            for (int i = 0; i < vetor.Length; i++)
            {
                    for (int j = 0; j < vetor.Length - 1; j++)
                    {
                        if (vetor[j] > vetor[j + 1])
                        {
                            temp = vetor[j + 1];
                            vetor[j + 1] = vetor[j];
                            vetor[j] = temp;
                        }

                    }
            }

            for (int i = 0; i < vetor.Length; i++)
            {
                for (int j = i; j < vetor.Length; j++)
                {
                    if (vetor[i] % 2 != 0 && vetor[j] % 2 == 0)
                    {
                        aux = vetor[j];
                        vetor[j] = vetor[i];
                        vetor[i] = aux;
                    }
                }
            }
            

            
            for (int i = 0; i < vetor.Length; i++) Console.Write(vetor[i] + " ");
       
            Console.ReadKey();



        }
    }
}

