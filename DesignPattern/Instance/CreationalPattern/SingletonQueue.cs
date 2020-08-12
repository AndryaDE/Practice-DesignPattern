using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Instance.CreationalPattern.SingletonQueue {
    class SingletonQueue {

        internal static ConcurrentQueue<SingletonQueue> queue = new ConcurrentQueue<SingletonQueue>();

        public string content = "";

        public SingletonQueue(string msg) {
            content = msg;
            queue.Enqueue( this );
        }


    }

    //---------------------------------------------

    static class Program {
        static internal void Run() {
            var text1 = new SingletonQueue("Erster");
            var text2 = new SingletonQueue("Zweiter!");
            var text3 = new SingletonQueue("Kettenunterbrecher!");

            while(SingletonQueue.queue.TryDequeue(out SingletonQueue item)) {
                Console.WriteLine(item.content);
            }
        }
    }

}
