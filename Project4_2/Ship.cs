﻿// ***********************************************************************
// Assembly         : Project4_2
// Author           : Richard Lesh
// Created          : 11-23-2016
//
// Last Modified By : Richard Lesh
// Last Modified On : 11-26-2016
// ***********************************************************************
// <copyright file="Ship.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>This class implements a ship in the game BattleShip.</summary>
// ***********************************************************************
using System;

namespace Project4_2
{
    /// <summary>
    /// Structure to represent a 2D position on the grid.
    /// </summary>
    public struct Position
    {
        public int Row { get; }
        public int Column { get; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Position)) return false;
            Position p = (Position)obj;
            if (Row != p.Row) return false;
            if (Column != p.Column) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return 31 * Row + Column;
        }

        public static bool operator ==(Position lhs, Position rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Position lhs, Position rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Row, Column);
        }
    }

    /// <summary>
    /// Abstract Ship class to represent those features common
    /// to all ship types.
    /// </summary>
    abstract class Ship
    {
        public enum Direction { Horizontal, Vertical };

        private static Random rnd = new Random();

        public Position StartPosition { get; set; }
        public Direction ShipDirection { get; set; }
        private Position[] Positions;
        private bool[] Damage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="size">The number of positions occupied by the ship.</param>
        public Ship(int size)
        {
            Positions = new Position[size];
            Damage = new bool[size];
        }

        /// <summary>
        /// Returns the length of the ship.
        /// </summary>
        /// <value>The number of positions occupied by the ship.</value>
        public int Length
        {
            get
            {
                return Positions.Length;
            }
        }

        public bool AtLocation(Position pos)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Positions[i].Equals(pos))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets or sets the ship color.
        /// </summary>
        /// <value>The ship color.</value>
        public ConsoleColor Color { get; protected set; }

        /// <summary>
        /// Gets or sets the ship symbol.
        /// </summary>
        /// <value>The ship symbol.</value>
        public char ShipSymbol { get; protected set; }

        /// <summary>
        /// Determines if this <see cref="Ship"/> is sunk.
        /// </summary>
        /// <value><c>true</c> if sunk; otherwise, <c>false</c>.</value>
        public bool Sunk {
            get
            {
                foreach (bool b in Damage)
                {
                    if (!b) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Attacks the specified position.  Modifies the ships
        /// Damage array if the position equals one of the ships
        /// positions.
        /// </summary>
        /// <param name="p">The Position to target.</param>
        /// <returns><c>true</c> if the ship is hit, <c>false</c> otherwise.</returns>
        public bool Attack(Position p)
        {
            for (int i = 0; i < Positions.Length; ++i)
            {
                if (p == Positions[i])
                {
                    Damage[i] = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is the BattleShip.
        /// </summary>
        /// <value><c>true</c> if this instance is a BattleShip; otherwise, <c>false</c>.</value>
        abstract public bool IsBattleShip { get; }

        /// <summary>
        /// Resets all the ship damage.
        /// </summary>
        public void Reset() {
            for (int i = 0; i < Damage.Length; ++i)
            {
                Damage[i] = false;
            }
        }

        /// <summary>
        /// Gets a position of the ship.
        /// </summary>
        /// <param name="index">The index [0, Length) to return.</param>
        /// <returns>Position at the specified index.</returns>
        public Position GetPosition(int index)
        {
            return Positions[index];
        }

        /// <summary>
        /// Computes all the positions that a ship occupies.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="direction">The direction of the ship.</param>
        public void Place(Position start, Direction direction)
        {
            StartPosition = start;
            ShipDirection = direction;

            int r = start.Row;
            int c = start.Column;

            // Add the Positions of the ship to the array
            for (int i = 0; i < Length; ++i)
            {
                Positions[i] = new Position(r, c);
                if (direction == Ship.Direction.Horizontal)
                {
                    ++c;
                } else
                {
                    ++r;
                }
            }
        }

        /// <summary>
        /// Randoms places a ship.
        /// </summary>
        /// <param name="gridSize">Size of the grid.</param>
        public void RandomPlace(int gridSize)
        {
            Position p;
            Direction d;
            int x = rnd.Next(gridSize);
            int y = rnd.Next(gridSize);
            d = (Direction)rnd.Next(Enum.GetValues(typeof(Direction)).GetUpperBound(0) + 1);
            if (d == Direction.Horizontal)
            {
                y = rnd.Next(gridSize - Length + 1);
            } else
            {
                x = rnd.Next(gridSize - Length + 1);
            }
            p = new Position(x, y);
            Place(p, d);
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}, {2}, {3}, {4}, {5}, {6}]", this.GetType().Name, Length, Color, StartPosition, ShipDirection, IsBattleShip, Sunk);
        }
    }
}
