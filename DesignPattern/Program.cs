using System;
using PoolCreationPatterns;
using StateBehaviorPatter;
using StateStackBehaviorPatter;

namespace DesignPattern {
    class Program {
        static void Main(string[] args) {



            var asdf = new Pool<string>(Console.ReadLine);

            //StateBehavioralPatter.Program.Run(); //StateMachine with Questions as States
            StateStackBehaviorPatter.Program.Run(); //StateMachine with a StateStack of Questions

            //Console.ReadLine();
        }
    }
}
