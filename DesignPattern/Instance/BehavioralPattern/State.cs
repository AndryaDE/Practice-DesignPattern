using System;
using System.Collections.Generic;
using System.Text;

namespace Instance.BehavioralPattern.State {

    class StateMachine { // Wrapper Class and Interface, faced to Client Requests
        #region Core Mechanic

        private IState currentState;

        public void setState(IState state) {
            currentState = state;
        }

        #endregion
        #region Interface

        public void whatIsTheQuestion() => currentState.whatIsTheQuestion(this);
        public void hereIsMyAnswer(string answer) => currentState.hereIsMyAnswer(this, answer);

        #endregion
    }

    interface IState {
        void whatIsTheQuestion(StateMachine statemachine);
        void hereIsMyAnswer(StateMachine stateMachine, string answer);
    }

    class QuestionB : IState {
        private int tries = 4;
        public void hereIsMyAnswer(StateMachine stateMachine, string answer) {
            if (answer == "6276,27") {
                Console.WriteLine("Right!");
                stateMachine.setState(new QuestionMenu());
            }
            else if (--tries <= 0) {
                Console.WriteLine("Com'on Man.. Go Away!");
                stateMachine.setState(new QuestionMenu());
            } else {
                Console.WriteLine("Wrong! You have " + tries + " trie(s) left.");
            }
        }

        public void whatIsTheQuestion(StateMachine statemachine) {
            Console.WriteLine("What is 627 + 1,9 * 3,3 ?");
        }
    }

    class QuestionA : IState {
        public void hereIsMyAnswer(StateMachine stateMachine, string answer) {
            if (answer == "yes") {
                stateMachine.setState(new QuestionMenu());
            }
        }

        public void whatIsTheQuestion(StateMachine statemachine) {
            Console.WriteLine("Do you want me to stop repeating this question? yes or no");
        }
    }

    class QuestionMenu : IState {
        public void hereIsMyAnswer(StateMachine stateMachine, string message) {
            switch(message.ToLower()) {
                case "a":
                    stateMachine.setState(new QuestionA());
                    break;
                case "b":
                    stateMachine.setState(new QuestionB());
                    break;
            }
        }

        public void whatIsTheQuestion(StateMachine statemachine) {
            Console.WriteLine("Do you want question A or B?");
        }
    }

    //====================================================
    
    static class Program {
        static internal void Run() {

            // Initialisation
            StateMachine state = new StateMachine();
            state.setState(new QuestionMenu());

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
