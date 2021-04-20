using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;
using Sail_n__Shoot___Obl_Opg._aswc.Items;

namespace Sail_n__Shoot___Obl_Opg._aswc.Observer
{
    public interface IObserver
    {
        void Update(Ship ship);

    }
}
