using System;
using System.Collections.Generic;
using System.Text;

namespace RoChamBo
{
    public class HumanPlayer:Player
    {

        public HumanPlayer()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
        }


        public void SetUserSelection()
        {
            Type rpsType = typeof(RPS);
            while (true)
            {
                Console.WriteLine(string.Format("Please select a figure to throw against your opponent:\n 1. {0, -15}2. {1, -15}3. {2, -15}",
                                            Enum.GetName(rpsType, RPS.ROCK), Enum.GetName(rpsType, RPS.PAPER), Enum.GetName(rpsType, RPS.SCISSORS)));
                string response = Console.ReadLine().Trim();
                if (int.TryParse(response, out int intResult)) {
                    if (Enum.IsDefined(rpsType, (intResult - 1)))
                    {
                        selection = (RPS)(intResult - 1);
                        return;
                    }
                }

                else if (Enum.TryParse<RPS>(response, true, out RPS result))
                {
                    selection = result;
                    return;
                }
                Console.Write("Invalid entry. ");
            }
        }

        public override RPS GenerateRPS()
        {
            SetUserSelection();
            return Selection;
        }
    }
}
