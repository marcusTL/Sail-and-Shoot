using System;
using System.Collections.Generic;
using System.Text;

namespace Sail_n__Shoot___Obl_Opg._aswc.World
{
    public class ShipStateMachine
    {
        private int _currentState = 0;
        private int[,] _shipStates;
        private const int nord = 0;
        private const int vest = 1;
        private const int syd = 2;
        private const int øst = 3;

        public ShipStateMachine()
        {
            _shipStates = new int[3, 4];

            _shipStates[0, nord] = nord;
            _shipStates[1, nord] = vest;
            _shipStates[2, nord] = øst;

            _shipStates[0, vest] = vest;
            _shipStates[1, vest] = syd;
            _shipStates[2, vest] = nord;

            _shipStates[0, syd] = syd;
            _shipStates[1, syd] = øst;
            _shipStates[2, syd] = vest;

            _shipStates[0, øst] = øst;
            _shipStates[1, øst] = nord;
            _shipStates[2, øst] = syd;
        }

        public int ChangeDirection(char input)
        {
            _currentState = _shipStates[ConvertInput(input), _currentState];
            PrintDirection(_currentState);
            return _currentState;
        }

        public int ConvertInput(char inp)
        {
            switch (inp)
            {
                case 'w': return 0;
                case 'a': return 1;
                case 'd': return 2;
                default: return 0;
            }
        }

        public char ReadNextKey()
        {
            Console.Write("choose a direction ");
            string str = Console.ReadLine();
            char[] cstr = str.ToCharArray();
            return cstr[0];
        }

        public void PrintDirection(int dir)
        {
            if (dir == 0)
            {
                Console.WriteLine("you are heading north");
            }

            if (dir == 1)
            {
                Console.WriteLine("you are heading west");
            }

            if (dir == 2)
            {
                Console.WriteLine("you are heading south");
            }

            if (dir == 3)
            {
                Console.WriteLine("you are heading east");
            }
        }
    }
}
