using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio_Aula03_ExclusaoMutua
{
    public class Conta
    {
		int turn;
        bool[] interested = new bool[2];
        decimal saldo = 100;
        static bool locker;

        static void Main(string[] args)
        {
            Conta cc = new Conta();

            for (int i = 0; i < 10; i++)
            {
                new Thread(cc.Credito).Start();
                new Thread(cc.Debito).Start();
            }

            Console.WriteLine("Saldo Final: " + cc.saldo);
            Console.ReadKey();

        }

        void Credito()
        {
            	EnterRegion(0);
                this.saldo += 100;
                Thread.Sleep(1000);
				LeaveRegion(0);
        }

        void Debito()
        {
        		EnterRegion(1);
                if (saldo >= 200)
                {
                    this.saldo -= 200;
                    Console.WriteLine(string.Format("Saldo: {0}", saldo));
                }
                Thread.Sleep(500);
        		LeaveRegion(1);
        
        }
		
		void LeaveRegion(int process)
		{
			interested[process] = false;
		}
		
		void EnterRegion(int process)
		{
			int other;
			
			other = 1 - process;
			interested[process] = true;
			turn = process;
			while(turn == process && interested[other] == true);			
		}
    }
}
