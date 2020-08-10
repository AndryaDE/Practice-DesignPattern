using System;
using System.Collections.Generic;
using System.Text;

namespace Instance.BehavioralPattern.StateStack {

    class StackStateMachine { // Wrapper Class and Interface, faced to Client Requests
        #region Core Mechanic

        private Stack<IState> stateStack = new Stack<IState>(); //alternative: List or Queue

        public void addState(IState state) {
            stateStack.Push(state);
        }

        public void popState() {
            stateStack.Pop();
        }

        #endregion
        #region Interface

        public void whatIsTheQuestion() => stateStack.Peek().whatIsTheQuestion(this);
        public void hereIsMyAnswer(string answer) => stateStack.Peek().hereIsMyAnswer(this, answer);

        #endregion
    }

    interface IState {
        void whatIsTheQuestion(StackStateMachine statemachine);
        void hereIsMyAnswer(StackStateMachine stateMachine, string answer);
    }

    class QuestionB : IState {
        private int tries = 4;
        public void hereIsMyAnswer(StackStateMachine stateMachine, string answer) {
            if (answer == "6276,27") {
                Console.WriteLine("Right!");
                stateMachine.popState();
            }
            else if (--tries <= 0) {
                Console.WriteLine("Com'on Man.. Go Away!");
                stateMachine.popState();
            } else {
                Console.WriteLine("Wrong! You have " + tries + " trie(s) left.");
            }
        }

        public void whatIsTheQuestion(StackStateMachine statemachine) {
            Console.WriteLine("What is 627 + 1,9 * 3,3 ?");
        }
    }

    class QuestionA : IState {
        public void hereIsMyAnswer(StackStateMachine stateMachine, string answer) {
            if (answer == "yes") {
                stateMachine.popState();
            }
        }

        public void whatIsTheQuestion(StackStateMachine statemachine) {
            Console.WriteLine("Do you want me to stop repeating this question? yes or no");
        }
    }

    class QuestionMenu : IState {
        public void hereIsMyAnswer(StackStateMachine stateMachine, string message) {
            switch(message.ToLower()) {
                case "a":
                    stateMachine.addState(new QuestionA());
                    break;
                case "b":
                    stateMachine.addState(new QuestionB());
                    break;
            }
        }

        public void whatIsTheQuestion(StackStateMachine statemachine) {
            Console.WriteLine("Do you want question A or B?");
        }
    }

    //====================================================
    
    static class Program {
        static internal void Run() {

            // Initialisation
            StackStateMachine state = new StackStateMachine();
            state.addState(new QuestionMenu());

            // Main Loop
            while (true) {
                state.whatIsTheQuestion();
                string answer = Console.ReadLine();
                state.hereIsMyAnswer(answer);
            }
            // hiermit übergibst die Kontrolle der StateMachine und deren States

        }
    }

}
