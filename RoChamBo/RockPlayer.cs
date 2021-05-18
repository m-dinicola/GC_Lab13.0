using System;
using System.Collections.Generic;
using System.Text;

namespace RoChamBo
{
    public class RockPlayer : Player
    {
        public RockPlayer()
        {
            Name = "Dwayne Johnson";
            selection = RPS.ROCK;
        }

        public override RPS GenerateRPS()
        {
            return RPS.ROCK;
        }
    }
}
