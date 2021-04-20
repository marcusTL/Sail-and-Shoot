using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;
using Sail_n__Shoot___Obl_Opg._aswc.Observer;
using Sail_n__Shoot___Obl_Opg._aswc.World;

namespace Sail_n__Shoot___Obl_Opg._aswc.Items
{
    public abstract class Item : Position
    {
        private string _name;
        private string _description;
        private int _id;
        //private List<IObserver> _listIObservers;

        public string Name => _name;

        public string Description => _description;

        public int Id => _id;

        protected Item(int id,string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
            //_listIObservers = new List<IObserver>();
        }

        //public void NotifyObservers()
        //{
        //    foreach (var observer in _listIObservers)
        //    {
        //        observer.UpdateItem(this);
        //    }
        //}

        //public void AddObserver(IObserver observer)
        //{
        //    _listIObservers.Add(observer);
        //}

        //public void RemoveObserver(IObserver observer)
        //{
        //    _listIObservers.Remove(observer);
        //}

        public abstract void UseItem(Player player, Enemy enemy);
        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }
}
