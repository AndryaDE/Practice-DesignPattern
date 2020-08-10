using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoolCreationPatterns {
    class Pool<T> {

        private ConcurrentBag<T> pool; // Der Pool ist hiermit Threading Safe; geilomat!
        private Func<T> generator; // Hinterlegt die Function, womit ein Object generiert wird, wenn der Pool leer ist

        public int Count {
            get => pool.Count;
        }

        public Pool(Func<T> function) { // ex: var States = new Pool<State>(() => new State);
            generator = function;
            pool = new ConcurrentBag<T>();
        }

        public T Get() {
            if(pool.TryTake(out T obj)) {
                return obj; // Erfolgreich ein Object aus dem Pool rausgenommen
            }
            return generator(); // Sonst ein neues erstellen
        }

        public void Put(T obj) {
            pool.Add(obj); // Ein Object ins Pool stecken
        }

    }

    //-----------------------------------------

    static class Program {
        static internal void Run() {

            var stringPool = new Pool<string>(() => RandomNumberGenerator.Create().ToString());

            Parallel.For(0, 100000000, (i, state) => {
                string x = stringPool.Get();
                stringPool.Put(x);
            });

            Console.ReadLine();
            Console.WriteLine(stringPool.Count);
            Console.ReadLine();

        }
    }
}
