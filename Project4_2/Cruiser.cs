using System;

namespace Project4_2
{
    class Cruiser : Ship
    {
        public Cruiser() :
            base(3)
        {
            Color = ConsoleColor.Cyan;
            ShipSymbol = 'C';
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
