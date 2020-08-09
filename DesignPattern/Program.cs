using System;

using StateBehaviorPatter;
using StateStackBehaviorPatter;

namespace DesignPattern {
    class Program {
        static void Main(string[] args) {



            //StateBehavioralPatter.Program.Run(); //StateMachine with Questions as States
            StateStackBehaviorPatter.Program.Run(); //StateMachine with a StateStack of Questions

            //Console.ReadLine();
        }
    }
}
