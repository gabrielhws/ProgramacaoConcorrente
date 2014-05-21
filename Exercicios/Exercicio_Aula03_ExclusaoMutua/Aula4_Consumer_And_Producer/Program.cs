using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula4_Consumer_And_Producer
{
    public class Program
    {
        static private int N = 100;
        private int Count = 0;
        ArrayList item = new ArrayList(N);
        bool wake;
        
        static void Main(string[] args)
        {
            new Thread(new Program().Producer).Start();
            new Thread(new Program().Consumer).Start();
   
        }

        private void Producer()
        {
            int item;
            
            while (true)
            {
                item = ProducerItem();
                if (Count == N) Sleep();
                InserirItem(item);
                Count += 1;
                if (Count == 1) WakeUp(1);


            }
        }

        private void Consumer()
        {
            int item;
            while (true)
            {
                if(Count==0) Sleep();
                item = RemoveItem();
                Count -= 1;
                if (Count == N - 1) WakeUp(0);
            }

        }

        private static int ProducerItem()
        {
            return new Random().Next(0, 100);
        }


        private int RemoveItem()
        {
            var value = (int) this.item[Count];
            this.item.Remove(Count);
            return value;

        }


        private void ConsumerItem(int item)
        {
            Console.WriteLine(item);
        }

        private void InserirItem(int item)
        {
            this.item.Add(item);
            Console.WriteLine(item);
        }

        private void Sleep()
        {
            while (true && !wake) ;
        }
        
        private void WakeUp(int process)
        {
            wake = true;
        }

    }
}
