using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;
using Sail_n__Shoot___Obl_Opg._aswc.Items;
using Sail_n__Shoot___Obl_Opg._aswc.Observer;
using Sail_n__Shoot___Obl_Opg._aswc.XMLConfig;

namespace Sail_n__Shoot___Obl_Opg._aswc.World
{
    public class Sea : IObserver
    {
        
        private List<Ship> _creatureList;
        private List<Item> _itemList;


        private int _width;
        private int _height;

        Random rand = new Random();
        public Sea( int width, int height)
        {
            _creatureList = new List<Ship>();
            _itemList = new List<Item>();
            _width = width;
            _height = height;
        }

        public List<Ship> CreatureList
        {
            get => _creatureList;
            set => _creatureList = value;
        }
        public List<Item> ItemList
        {
            get => _itemList;
            set => _itemList = value;
        }
        public int Width => _width;

        public int Height => _height;


        public void PrintGround()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine("[]");

                for (int j = 0; j < _width; j++)
                {
                    Console.Write("[]");
                    
                }
            }
        }

        public void PlaceCreatures()
        {
            foreach (var ship in _creatureList)
            {
                ship.Xposition = rand.Next(Width);
                ship.Xposition = rand.Next(Width);
                //if (!_creatureList.Exists(x => x.Yposition == 0)) 
                //{
                //    ship.Xposition = Width / 2;
                //    ship.Yposition = 0;
                //}
                //else
                //{
                //    ship.Xposition = Width / _creatureList.Count;
                //    ship.Yposition = Height;
                //}
                ship.AddObserver(this);
            }
        }

        public void PlaceItems()
        {

            foreach (var item in _itemList)
            {
                item.Xposition = rand.Next(Width);
                item.Yposition = rand.Next(Height);

                //item.AddObserver(this);
            }
        }

        public void PrintShips(int hp)
        {
            IEnumerable<Ship> ships = from ship in _creatureList
                where ship.Hp < hp select ship;

            foreach (Ship ship in ships)
            {
                Console.WriteLine(ship);
            }
        }

        public void PrintItems()
        {
            foreach (var item in _itemList)
            {
                Console.WriteLine(item);
            }
        }
        public void Update(Ship ship)
        {
            _creatureList.Remove(ship);
        }
        public void UpdateItem(Item item)
        {
            _itemList.Remove(item);
        }

    }
}
