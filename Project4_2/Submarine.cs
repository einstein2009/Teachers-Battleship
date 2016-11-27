using System;

namespace Project4_2
{
    class Submarine : Ship
    {
        public Submarine() :
            base(3)
        {
            Color = ConsoleColor.Magenta;
            ShipSymbol = 'S';
        }

        public override bool IsBattleShip
        {
            get
            {
                return false;
            }
        }
    }
}
