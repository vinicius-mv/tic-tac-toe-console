﻿namespace TicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game(new Board());
            game.PlayGame();
        }
    }
}