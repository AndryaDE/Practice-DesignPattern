using System;
using PoolCreationPatterns;
using StateBehaviorPatter;

namespace DesignPattern {
    class Program {
        static void Main(string[] args) {


            Console.WriteLine("asd");

            //StateBehavioralPatter.Program.Run(); //StateMachine with Questions as States
            //StateStackBehaviorPatter.Program.Run(); //StateMachine with a StateStack of Questions
            PoolCreationPatterns.Program.Run(); //StateMachine with a StateStack of Questions

            //Console.ReadLine();
        }
    }
}
