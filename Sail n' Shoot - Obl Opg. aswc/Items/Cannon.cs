using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;

namespace Sail_n__Shoot___Obl_Opg._aswc.Items
{
    public class Cannon : Item
    {
        private int _range;
        private int _damage;
        private int _id;

        public Cannon(int id, string name, string description, int range, int damage) : base(id,name, description)
        {
            _id = id;
            _range = range;
            _damage = damage;
        }

        public int Id => _id;

        public int Range => _range;

        public int Damage => _damage;

        public override void UseItem(Player player, Enemy enemy)
        {
            List<int> _shippositions = Sort(player.Xposition, enemy.Xposition);

            if (_range < _shippositions[1] - _shippositions[0])
            {
                _shippositions.RemoveRange(0, 2);
                _shippositions = Sort(player.Yposition, player.Yposition);
                if (_range < _shippositions[1] - _shippositions[0])
                {
                    Console.WriteLine("out of range");
                }
            }
            else
            {
                for (int i = 0; i < _damage; i++)
                {
                    enemy.RecieveHit();
                }
            }
        }
        public List<int> Sort(int i1, int i2)
        {
            List<int> list = new List<int>()
            {
                i1,i2
            };
            list.Sort();
            return list;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}, {Description}, Position [{Xposition},{Yposition}] - Damage: {Damage}, Range: {Range}";
        }
    }
}

    

