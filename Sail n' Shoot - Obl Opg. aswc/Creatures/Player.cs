using Sail_n__Shoot___Obl_Opg._aswc.Items;
using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.World;

namespace Sail_n__Shoot___Obl_Opg._aswc.Creatures
{
    public class Player : Ship
    {
        private List<Item> _inventory;
         
        public Player(int hp, string name) : base(hp, name)
        {
            _inventory = new List<Item>();
        }

        public List<Item> Inventory
        {
            get => _inventory;
            set => _inventory = value;
        }

        //public List<Item> Inventory
        //{
        //    get => _inventory;
        //    set => _inventory = value;
        //}

        public override void Shoot(Ship ship)
        {
            ship.RecieveHit();
        }

        public override void Brace()
        {
            {
                if (Hp < 1)
                {
                    Hp = 1;
                }
            }
        }

        public void PickUpItem(Item item, Ship ship)
        {
            if (item.Xposition == ship.Xposition && item.Yposition == ship.Yposition)
            {
                _inventory.Add(item);
                //item.NotifyObservers();
            }
            else
            {
                Console.WriteLine("out of range");
            }
        }

        public void CheckItems()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
            }
            else
            {
                foreach (var item in _inventory)
                {
                    Console.WriteLine(item);

                }
            }
        }
        public void UseItem(Player player, Enemy enemy)
        {
            CheckItems();
            Console.WriteLine("pick an item");
            string itemstring = Console.ReadLine();
            int itempick = Convert.ToInt32(itemstring);

            if (_inventory.Exists(x=>x.Id == itempick))
            {
                Item item = _inventory.Find(x=>x.Id == itempick);
                item.UseItem(player,enemy);

                _inventory.Remove(item);
                
            }
            else
            {
                Console.WriteLine("no item was selected");
            }
            
            
        }

    }
}
