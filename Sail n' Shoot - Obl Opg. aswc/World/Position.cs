using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;

namespace Sail_n__Shoot___Obl_Opg._aswc.World
{
    public abstract class Position
    {
        private int _xposition = 0;
        private int _yposition = 0;

        public int Xposition
        {
            get => _xposition;
            set => _xposition = value;
        }

        public int Yposition
        {
            get => _yposition;
            set => _yposition = value;
        }

        public void ChangePosition(int currentDir)
        {
            if (currentDir == 0) //retning = nord
            {
                _yposition++; //flytter skibbet 1 tile op
            }

            if (currentDir == 1) //retning = vest
            {
                _xposition--;//flytter skibbet 1 tile til venstre
            }
            if (currentDir == 2) //retning = syd
            {
                _yposition--; // -||- nedad
            }
            if (currentDir == 3) //Direction øst
            {
                _xposition++; // -||- til højre
            }
            Console.WriteLine($"new position: {_xposition}, {_yposition}");
        }

    }
}
