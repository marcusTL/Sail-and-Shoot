using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Annotations;
using Sail_n__Shoot___Obl_Opg._aswc.Items;
using Sail_n__Shoot___Obl_Opg._aswc.Observer;
using Sail_n__Shoot___Obl_Opg._aswc.World;

namespace Sail_n__Shoot___Obl_Opg._aswc.Creatures
{
    public abstract class Ship : Position, INotifyPropertyChanged
    {
        private int _hp;
        private string _name;
        private List<IObserver> _listIObservers;


        public bool IsDead
        {
            get { return _hp < 1; }
        }

        protected Ship(int hp, string name) 
        {
            _hp = hp;
            _name = name;
            _listIObservers = new List<IObserver>();
        }

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public void AddObserver(IObserver observer)
        {
            _listIObservers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _listIObservers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var Observer in _listIObservers)
            {
                Observer.Update(this);
            }
        }
        public abstract void Shoot(Ship ship);



        public abstract void Brace();
        

        public void RecieveHit()
        {
            _hp--;
            if (_hp < 1)
            {
                NotifyObservers();
                //OnPropertyChanged("IsDead");
            }
        }

        public override string ToString()
        {
            return $"{_name}, HP: {_hp} - Position [{Xposition},{Yposition}]";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
