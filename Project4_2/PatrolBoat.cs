using System;

namespace Project4_2
{
    class PatrolBoat : Ship
    {
        public PatrolBoat() :
            base(2)
        {
            Color = ConsoleColor.Yellow;
            ShipSymbol = 'P';
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
