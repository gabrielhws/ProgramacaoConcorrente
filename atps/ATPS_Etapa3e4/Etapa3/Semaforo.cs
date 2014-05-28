using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Etapa3
{
    public class Semaforo
    {
        //vamos usar um semáforo para limitar as threads.

        private static Semaphore Pool;


        //este flag é apenas para indicar que estamos na thread desordenada.

        // então temos que chamar o waitOne nos métodos

        private static bool flag = false;


        public static void Main()
        {

            Console.WriteLine("Programa Iniciado");



            ThreadOrdenada();



            ThreadAleatoria();



            Console.WriteLine("Aguarde as threads serem executadas");


            Console.ReadKey();

        }

        /// <summary>

        /// este método irá executar as threads em ordem de criação

        /// </summary>

        private static void ThreadOrdenada()
        {

            Console.WriteLine("Threads Ordenadas");



            //este buffer será criado para garantir que as threads

            //sejam executadas na ordem em que foram chamadas (criadas)

            //iremos usar ele mais abaixo para iniciar as nossas threads

            Queue<Thread> ThreadBuffer = new Queue<Thread>();



            //iniciamos o Pool


            //o primeiro parâmetro do Pool indica quantas threads temos liberadas para iniciar

            //o segundo parâmetro indica quantas threads podemos executar por vez

            Pool = new Semaphore(0, 1);



            //criando um Pool de threads que chamam o MetodoUm

            for (int i = 0; i < 5; i++)
            {

                Thread t = new Thread(new ThreadStart(MetodoUm));

                t.Name = "MetodoUm_Thread#" + i;

                ThreadBuffer.Enqueue(t);

            }

            //criando um Pool de threads que chamam o MetodoDois

            for (int i = 0; i < 5; i++)
            {

                Thread t = new Thread(new ThreadStart(MetodoDois));

                t.Name = "MetodoDois_Thread#" + i;

                ThreadBuffer.Enqueue(t);

            }



            //agora iremos iniciar todas as threads

            while (ThreadBuffer.Count > 0)
            {

                Thread t = ThreadBuffer.Dequeue();

                t.Start();



                //espera o fim da thread anterior para continuar

                //resolvi esperar aqui para garantir que qualquer thread que for executada

                //irá esperar a outra terminar.

                //se tirarmos esta linha as threads nao terão uma ordem definida para executar.

                Pool.WaitOne();//comente este linha e execute o programa novamente. Atente aos erros

            }

        }

        /// <summary>

        /// Este método chama as threads em qualquer ordem

        /// </summary>

        private static void ThreadAleatoria()
        {

            Console.WriteLine("Threads Aleatórias");


            flag = true;

            //iniciamos o Pool

            //o primeiro parâmetro do Pool indica quantas threads temos liberadas para iniciar

            //o segundo parâmetro indica quantas threads podemos executar por vez



            //repare que aqui, diferente da thread ordenada

            //o primeiro parâmetro é 3 para indicar que temos posições livres

            //o segundo é três para indicar que podemos executar até 3 por vez

            Pool = new Semaphore(3, 3);



            //criando um Pool de threads que chamam o MetodoUm

            for (int i = 0; i < 5; i++)
            {

                Thread t = new Thread(new ThreadStart(MetodoUm));

                t.Name = "MetodoUm_Thread#" + i;

                t.Start();

            }



            //criando um Pool de threads que chamam o MetodoDois

            for (int i = 0; i < 5; i++)
            {

                Thread t = new Thread(new ThreadStart(MetodoDois));

                t.Name = "MetodoDois_Thread#" + i;

                t.Start();

            }

        }

        private static void MetodoUm()
        {

            try
            {

                if (flag) Pool.WaitOne();



                Console.WriteLine("A thread " + Thread.CurrentThread.Name + " iniciou.");

                //espera 3 segundos antes de terminar

                Thread.Sleep(3000);



                if (Thread.CurrentThread.Name == "MetodoUm_Thread#1")

                    throw new Exception("erro apenas para mostrar que não podemos esquecer de liberar o semáforo mesmo \nque haja erros...");

                Console.WriteLine("A thread " + Thread.CurrentThread.Name + " finalizou.");

            }

            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(ex.Message);

                Console.ResetColor();

            }

            finally
            {

                //temos que sinalizar que a thread terminou.

                //isso é muito importante, não podemos esquecer, pois caso contrário

                //as outras threads não serão executadas

                Pool.Release();

            }

        }

        private static void MetodoDois()
        {

            try
            {

                if (flag) Pool.WaitOne();



                Console.WriteLine("A thread " + Thread.CurrentThread.Name + " iniciou.");

                //espera 3 segundos antes de terminar

                Thread.Sleep(3000);

                Console.WriteLine("A thread " + Thread.CurrentThread.Name + " finalizou.");



            }

            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(ex.Message);

                Console.ResetColor();

            }

            finally
            {

                //temos que sinalizar que a thread terminou.

                //isso é muito importante, não podemos esquecer, pois caso contrário

                //as outras threads não serão executadas

                Pool.Release();

            }

        }


    }


}

