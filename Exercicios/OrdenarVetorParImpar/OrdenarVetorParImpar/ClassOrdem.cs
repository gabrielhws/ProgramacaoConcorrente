using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarVetorParImpar
{
    class ClassOrdem
    {
        int[] vetor = { 1, 5, 0, 3, 4, 7, 2, 1 };
        private static void Main(string[] args)
        {

            
        }

        public void Ordenar(int pos)
        {
            for (int i = 0; i < 8; i++)
            {
                if (vetor[pos]>vetor[i])
                {
                    int aux = vetor[i];
                    vetor[i] = vetor[pos];
                    vetor[pos] = aux;
                    pos = i;
                }
            }
        }

        public void Init()
        {
            for (int i = 0; i < 8; i++)
            {
                if (vetor[i]%2 == 0)
                {
                    Ordenar(i);
                }

            }
            for (int i = 0; i < 8; i++)
            {
                if (vetor[i]%2!=0)
                {
                    Ordenar(i);
                }

                
            }

        }
    }
}
