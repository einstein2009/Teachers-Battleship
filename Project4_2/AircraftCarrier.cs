using System;

namespace Project4_2
{
    class AircraftCarrier : Ship
    {
        public AircraftCarrier() :
            base(5)
        {
            Color = ConsoleColor.Green;
            ShipSymbol = 'A';
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
