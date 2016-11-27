﻿// ***********************************************************************
// Assembly         : BattleshipSimple
// Author           : Richard Lesh
// Created          : 11-17-2016
//
// Last Modified By : Richard Lesh
// Last Modified On : 11-17-2016
// ***********************************************************************
// <copyright file="Grid.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>This class implements the Grid of a Battleship game.</summary>
// ***********************************************************************
using System;

namespace Project4_2
{
    /// <summary>
    /// Class that represents the playing board of the game Battleship.
    /// </summary>
    internal class Grid
    {
        public int GridSize { get; }
        private char[,] cellSymbols;  // Ship symbol, '.' if sea and 'X' if bombed
        private bool[,] cellBombed;
        private ConsoleColor[,] cellColors;
        public const string ColumnLabels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        /// <param name="gridsize">The width and height of the playing area.</param>
        public Grid(int gridsize)
        {
            if (gridsize < 5) gridsize = 5;
            if (gridsize > 26) gridsize = 26;
            GridSize = gridsize;
            cellSymbols = new char[gridsize, gridsize];
            cellBombed = new bool[gridsize, gridsize];
            cellColors = new ConsoleColor[gridsize, gridsize];
            Clear();
        }

        /// <summary>
        /// Clears this playing board to all open sea.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < GridSize; ++i)
            {
                for (int j = 0; j < GridSize; ++j)
                {
                    cellSymbols[i, j] = '.';
                    cellColors[i, j] = ConsoleColor.Black;
                }
            }
        }

        /// <summary>
        /// Sets the fleet on this playing board.
        /// </summary>
        public void SetFleet(Ships fleet)
        {
            Clear();
            foreach (Ship s in fleet.Fleet)
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    SetCell(s.GetPosition(i), s.Color, s.ShipSymbol);
                }
            }
        }

        /// <summary>
        /// Sets grid cell color and symbol.
        /// </summary>
        /// <param name="p">The Position to set.</param>
        /// <param name="c">The ConsoleColor</param>
        /// <param name="symbol">The symbol character</param>
        public void SetCell(Position p, ConsoleColor c, char symbol)
        {
            cellSymbols[p.Row, p.Column] = symbol;
            cellColors[p.Row, p.Column] = c;
        }

        /// <summary>
        /// Draws the playing board.
        /// </summary>
        public void Draw()
        {
            // Draw top labels
            Console.Write("   ");
            for (int i = 0; i < GridSize; ++i)
            {
                Console.Write("  " + ColumnLabels[i] + " ");
            }
            Console.WriteLine();

            // Draw top border
            Console.Write("   ");
            for (int i = 0; i < GridSize; ++i)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            // Draw row
            for (int i = 0; i < GridSize; i++)
            {
                Console.Write((i + 1).ToString("00") + " ");
                for (int j = 0; j < GridSize; j++)
                {
                    char symbolToDraw = cellSymbols[i, j];
                    Console.Write("|");
                    Console.BackgroundColor = cellColors[i, j];
                    Console.Write(" " + symbolToDraw + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("|");

                // Draw row border
                Console.Write("   ");
                for (int k = 0; k < GridSize; ++k)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
            }
        }
    }
}
