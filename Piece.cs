﻿using System;

namespace TicTacToe
{
    internal class Piece
    {
        public Player Owner { get; set; }

        public Piece(Player player)
        {
            Owner = player;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";

                case Player.Cross:
                    return "X";

                case Player.Circle:
                    return "O";

                default:
                    throw new Exception("INVALID");
            }
        }

        public enum Player { Noone = 0, Cross = 1, Circle = 2 };
    }
}