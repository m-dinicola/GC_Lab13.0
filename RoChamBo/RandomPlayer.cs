using System;
using System.Collections.Generic;
using System.Text;

namespace RoChamBo
{
    public class RandomPlayer:Player
    {
        
        Random rng;


        public RandomPlayer()
        {
            Name = "Gx05t !n 7h3 5h3LL";
            rng = new Random();
        }

        public override RPS GenerateRPS()
        {
            selection = (RPS) rng.Next(0, Enum.GetNames(typeof(RPS)).Length);
            return selection;
        }
    }
}
