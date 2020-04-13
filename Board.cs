using System;

namespace TicTacToe
{
    internal class Board
    {
        //private Piece[,] pieces = new Piece[3, 3];
        public Piece[,] pieces;

        public Board()
        {
            pieces = new Piece[3, 3];
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + pieces[i, j].ToString());
                }
                Console.WriteLine();
            }
        }

        public void initialSetup()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pieces[i, j] = new Piece(Piece.Player.Noone);
                }
            }
        }
    }
}