using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;

namespace Sail_n__Shoot___Obl_Opg._aswc.Items
{
    public class Carpenters_Tools: Item
    {
        private int _id = 2;

        public Carpenters_Tools(int id, string name, string description) : base(id,name, description)
        {
            _id = id;
        }

        public int Id => _id;

        public override void UseItem(Player player, Enemy enemy)
        {
            player.Hp++;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}, {Description}";
        }
    }
}
