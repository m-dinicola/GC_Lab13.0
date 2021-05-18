using System;
using System.Collections.Generic;
using System.Text;

namespace RoChamBo
{
    public abstract class Player
    {
        public RPS selection;
        public string Name { get; set; }
        public virtual RPS Selection
        {
            get
            {
                return selection;
            }
        }

        public Player()
        {

        }

        public abstract RPS GenerateRPS();
    }
}
