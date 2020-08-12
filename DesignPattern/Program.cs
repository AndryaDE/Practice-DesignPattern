using System;
using Instance.CreationalPattern.Pool;
using Instance.BehavioralPattern.State;
using Instance.CreationalPattern.SingletonQueue;

namespace DesignPattern {
    class Program {
        static void Main(string[] args) {


            Console.WriteLine("Hello World");

            //Instance.BehavioralPattern.State.Program.Run(); //StateMachine with Questions as States
            //Instance.BehavioralPattern.StateStack.Program.Run(); //StateMachine with a StateStack of Questions
            //Instance.CreationalPattern.Pool.Program.Run();
            Instance.CreationalPattern.SingletonQueue.Program.Run();

            Console.ReadLine();
        }
    }
}
