// ***********************************************************************
// Assembly         : Project4_2
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Richard Lesh
// Last Modified On : 11-26-2016
// ***********************************************************************
// <copyright file="Ships.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>Class to represent a fleet of ships.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project4_2
{
    /// <summary>
    /// Class that represents a fleet of ships.
    /// </summary>
    class Ships
    {
        public LinkedList<Ship> Fleet;

        /// <summary>
        /// Adds the specified ship to the fleet of ships.  Throws an
        /// ShipCollisionException if the new ship collides with an 
        /// existing ship in the fleet.
        /// </summary>
        /// <param name="newShip">The ship to add.</param>
        /// <exception cref="Project4_2.ShipCollisionException"></exception>
        public void Add(Ship newShip)
        {
            // Loop through all the ships in the fleet to see if they collide with newShip.
            // If none collide Add() to Fleet.
            if (Fleet.Count == 0)
            {
                Fleet.AddFirst(newShip);
            }
            else
            {
                for (int i = 0; i < Fleet.Count; i++)
                {
                    if (Ships.Collision(newShip, Fleet.ElementAt(i)))
                    {
                        throw new Exception("The new ship collides with another placed ship.");
                    }
                }
                Fleet.AddLast(newShip);
            }

        }

        /// <summary>
        /// Clears this instance of ships.
        /// </summary>
        public void clear()
        {
            // Clear Fleet.
            Fleet = new LinkedList<Ship>();
        }

        /// <summary>
        /// Indicates whether or not the BattleShip has been sunk.
        /// </summary>
        /// <value><c>true</c> if the BattleShip is sunk; otherwise, <c>false</c>.</value>
        public bool SunkMyBattleship {
            // Loop through all the ships in the fleet to find the BattleShip.
            // Return true if the BattleShip is sunk.
            get
            {
                for (int i = 0; i < Fleet.Count; i++)
                {
                    if (Fleet.ElementAt(i).IsBattleShip)
                    {
                        return Fleet.ElementAt(i).Sunk;
                    }
                }
                throw new Exception("No battleship on board.");
            }
        }

        /// <summary>
        /// Attacks the specified position.
        /// </summary>
        /// <param name="p">The Position to attack.</param>
        /// <returns><c>true</c> if a ship is hit, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool Attack(Position p)
        {
            // Check to see if position is valid, if not throw ArgumentException.
            // Loop through all the ships in the Fleet and
            // call the Attack method on the ship to see if the attack hits.
            Position attackpos = new Position();
            for (int i = 0; i < Fleet.Count; i++)
            {
                if (Fleet.ElementAt(i).Attack(attackpos))
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Determines if the two ships passed share a common
        /// position, i.e. they collide.
        /// </summary>
        /// <param name="ship1">The first ship</param>
        /// <param name="ship2">The second ship</param>
        /// <returns><c>true</c> if the ships have a common position, <c>false</c> otherwise.</returns>
        static public bool Collision(Ship ship1, Ship ship2)
        {
            for (int i = 0; i < ship1.Length; i++)
            {
                if (ship2.AtLocation(ship1.GetPosition(i)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Prints the fleet of ships.  For each ship print the 
        /// ship itself (using ToString()) on one line followed by
        /// all the ships coordinates on a second line.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Fleet.Count; ++i)
            {
                Ship Ship = Fleet.ElementAt(i);
                Console.WriteLine(Ship);
                Console.Write("\t");
                for (int j = 0; j < Ship.Length; ++j)
                {
                    Console.Write(Ship.GetPosition(j));
                }
                Console.WriteLine();
            }
        }
    }
}
