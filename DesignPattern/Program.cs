using System;
using Instance.CreationalPattern.Pool;
using Instance.BehavioralPattern.State;

namespace DesignPattern {
    class Program {
        static void Main(string[] args) {


            Console.WriteLine("asd");

            //Instance.BehavioralPattern.State.Program.Run(); //StateMachine with Questions as States
            //Instance.BehavioralPattern.StateStack.Program.Run(); //StateMachine with a StateStack of Questions
            Instance.CreationalPattern.Pool.Program.Run(); //StateMachine with a StateStack of Questions

            //Console.ReadLine();
        }
    }
}
