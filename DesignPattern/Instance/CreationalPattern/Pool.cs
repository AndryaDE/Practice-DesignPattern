using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Instance.CreationalPattern.Pool {
    class Pool<T> {

        private ConcurrentBag<T> pool;
        //private Stack<T> pool;
        private Func<T> generator;

        public int Count {
            get => pool.Count;
        }

        public Pool(Func<T> function) { // ex: var States = new Pool<State>(() => new State);
            generator = function;
            pool = new ConcurrentBag<T>();
            //pool = new Stack<T>();
        }

        public T Get() {
            if(pool.TryTake(out T obj)) {
            //if(pool.TryPop(out T obj)) {
                return obj;
            }
            return generator();
        }

        public void Put(T obj) {
            pool.Add(obj);
            //pool.Push(obj);
        }

        public void Create(int count) {
            while(0 <= --count) {
                Put(generator());
            }
        }

    }



    //-----------------------------------------

    static class Program {
        static internal void Run() {

            var stringPool = new Pool<string>(() => RandomNumberGenerator.Create().ToString());
            var sw = new Stopwatch();
            int iFor = 100000000;

            Console.WriteLine(iFor + " Object Gets");

            stringPool.Create(500);
            sw.Start();
            //for (int i = 0; i < iFor; i++) {
            Parallel.For(0, iFor, (i, state) => {
                string x = new string(RandomNumberGenerator.Create().ToString());
                //string x = stringPool.Get();
                //stringPool.Put(x);
            });
            sw.Stop();

            Console.WriteLine("Pool Size: " + stringPool.Count);
            Console.WriteLine("Stopwatch: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();

            /* 100mio object RandomNumberGenerator.Create().ToString()
             * 
             *                  False Pool   With Pool
             * Single (Stack)    5509ms      2115ms (1 object)
             * Single (Bag)      7480ms      7581ms (1 object)
             * Parallel (Bag)    3983ms      6611ms (pre created)|| 8726ms (12 objects) || 10117ms (10 objects)
             * 
             * Defined Count Of Created Objects with Parallel Bag:
             *  10 => 10107ms
             *  12 =>  8825ms
             *  15 =>  7574ms
             *  20 =>  6742ms
             * 100 =>  6656ms
             * 500 =>  7100ms
             * 
             * Pre Created: 6611ms (creation time exluceded timewatch)
             * 
             * Parallel without any pool: 3059ms
             * 
             * ---------------
             * 
             * ♥ Pooling wenn die Kosten zum erstellen viel höher sind als das Resetten der internal Properties
             * ♥ Die Frequenz der Klasse ist hoch
             * ♥ Relativ wenig Objekte im Bag (gut: 100-1000)
             * 
             */


        }
    }
}
