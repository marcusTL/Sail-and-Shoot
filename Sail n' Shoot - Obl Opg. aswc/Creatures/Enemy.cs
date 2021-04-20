using System;
using System.Collections.Generic;
using System.Text;

namespace Sail_n__Shoot___Obl_Opg._aswc.Creatures
{
    public class Enemy : Ship
    {
        public Enemy(int hp, string name) : base(hp, name)
        {
        }

        public override void Shoot(Ship ship)
        {
            ship.RecieveHit();
        }

        public override void Brace()
        {
            {
                if (Hp == 0)
                {
                    Hp = 1;
                }
            }
        }
    }
}
