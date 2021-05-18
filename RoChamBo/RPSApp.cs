using System;
using System.Collections.Generic;
using System.Text;

namespace RoChamBo
{
    public class RPSApp
    {
        public HumanPlayer human;
        public Player opponent = new RandomPlayer();        //I initialize as RandomPlayer so I can use that delicious name without having to type it again.
        public List<bool> winRecord;

        public int PlayerScore 
        {
            get
            {
                return winRecord.FindAll(x => x).Count;
            }
        }

        public int OpponentScore
        {
            get
            {
                return winRecord.FindAll(x => !x).Count;
            }
        }

        public RPSApp()
        {
            human = new HumanPlayer();
            ChooseOpponent();
            winRecord = new List<bool>();
        }

        public void PlayRPS()
        {
            while (true)
            {
                Console.WriteLine("Let's play Rock, Paper, Scissors!");
                RoChamBo();
                PrintScore();
                if (!YesOrNo())
                {
                    Console.WriteLine("Bye, then.");
                    return;
                }
                Console.Write("Great! ");
            }
        }

        public bool YesOrNo() 
        {
            while (true)
            {
                Console.Write("Would you like to play again? ");
                string response = Console.ReadLine().Trim().ToLower();
                if (response == "no" || response == "n")
                {
                    return false;
                }
                if (response == "yes" || response == "y")
                {
                    return true;
                }
            }
        }
        public void RoChamBo()
        {
            string winnerName = "";
            int winner = CalculateWinner();
            switch (winner)
            {
                case -1:
                    winnerName = opponent.Name;
                    winRecord.Add(false);
                    break;
                case 0:
                    winnerName = "Nobody";
                    break;
                case 1:
                    winnerName = human.Name;
                    winRecord.Add(true);
                    break;
            }

            string outputString = $"You selected {human.Selection.ToString().ToLower()}, " +
                $"while {opponent.Name} selected {opponent.Selection.ToString().ToLower()}. " +
                $"{winnerName} is the winner.";
            Console.WriteLine(outputString);
        }

        public void PrintScore()
        {
            Console.WriteLine($"{human.Name} has won {PlayerScore} game(s). {opponent.Name} has won {OpponentScore} games.");
        }

        public int CalculateWinner()
        {
            RPS humanSelection = human.GenerateRPS();
            RPS opponentSelection = opponent.GenerateRPS();
            if (humanSelection == opponentSelection)
            {
                return 0;
            }
            if (((int)humanSelection) == (((int)opponentSelection) + 1) % 3)
            {
                return 1;
            }
            return -1;
        }

        public void ChooseOpponent()
        {

            while (true)
            {
                Console.WriteLine(string.Format("Please select your opponent:\n1.{0,-15} 2. {1,-15}", "Dwayne Johnson", opponent.Name));
                string response = Console.ReadLine().Trim().ToLower();
                if (int.TryParse(response, out int intResult))
                {
                    if (intResult == 1)
                    {
                        opponent = new RockPlayer();
                        return;
                    }
                    if (intResult == 2)
                    {
                        return;             //changing the player is not necessary here, since player is already random
                    }
                }

                if (response == "dwayne johnson")
                {
                    opponent = new RockPlayer();
                    return;
                }
                if (response.StartsWith("ghost"))
                {
                    return;
                }
                Console.Write("Invalid selection. ");
            }
        }
    }
}
