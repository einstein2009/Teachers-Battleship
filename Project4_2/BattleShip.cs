using System;

namespace Project4_2
{
    class BattleShip : Ship
    {
        public BattleShip() :
            base(4)
        {
            Color = ConsoleColor.Blue;
            ShipSymbol = 'B';
        }

        public override bool IsBattleShip
        {
            get
            {
                return true;
            }
        }
    }
}
