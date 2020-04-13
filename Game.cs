using System;

namespace TicTacToe
{
    internal class Game
    {
        private Board board;
        private Piece.Player owner = Piece.Player.Cross;
        private Piece.Player winner;

        public Game(Board board)
        {
            this.board = board;
        }

        public void PlayGame()
        {
            bool @continue = true;
            board.initialSetup();
            board.DisplayBoard();

            while (@continue)
            {
                Move();
                Console.Clear();
                board.DisplayBoard();
                @continue = !checkGameOver();

                if (@continue)
                {
                    owner = 3 - owner;
                }
            }

            if (winner == Piece.Player.Noone)
            {
                Console.WriteLine("Game Over - Result: DRAW.");
            }
            else
            {
                Console.WriteLine($"Player {winner} WON");
            }
        }

        public void Move()
        {
            bool done = false;
            while (!done)
            {
                Console.Write($"Player({owner}) enter the position (i,j): ");
                string input = Console.ReadLine();
                string[] parts = input.Split(',');
                int.TryParse(parts[0], out int row);
                int.TryParse(parts[1], out int column);

                if (board.pieces[(row - 1), (column - 1)].Owner == Piece.Player.Noone)
                {
                    Console.WriteLine($" trying to set Piece, row: {row}, column: {column}");
                    board.pieces[row - 1, column - 1] = new Piece(owner);
                    done = true;
                }
                else
                {
                    Console.WriteLine($"Sorry the position: {row}, {column} is already occupied.");
                }
            }
        }

        public bool checkGameOver()
        {
            return (LineGameOverCheck() || ColumnGameOverCheck() || MajorDiagonalGameOver() || MinorDiagonalGameOver() || DrawGameOver());
        }

        private bool LineGameOverCheck()
        {
            int countMarks = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (board.pieces[i, j].Owner == board.pieces[i, (j - 1)].Owner && board.pieces[i, j].Owner != Piece.Player.Noone)
                    {
                        countMarks++;
                    }
                    else
                    {
                        countMarks = 0;
                    }
                    if (countMarks == 2)
                    {
                        winner = owner;
                        return true;
                    }
                }
                countMarks = 0;
            }
            return false;
        }

        private bool ColumnGameOverCheck()
        {
            int countMarks = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 1; i < 3; i++)
                {
                    if (board.pieces[i, j].Owner == board.pieces[(i - 1), j].Owner && board.pieces[i, j].Owner != Piece.Player.Noone)
                    {
                        countMarks++;
                    }
                    else
                    {
                        countMarks = 0;
                    }
                    if (countMarks == 2)
                    {
                        winner = owner;
                        return true;
                    }
                }
                countMarks = 0;
            }
            return false;
        }

        private bool MajorDiagonalGameOver()
        {
            int countMarks = 0;
            int i = 1, j = 1;
            while (i < 3)
            {
                if (board.pieces[i, j].Owner == board.pieces[(i - 1), (j - 1)].Owner & board.pieces[i, j].Owner != Piece.Player.Noone)
                {
                    countMarks++;
                }
                if (countMarks == 2)
                {
                    winner = owner;
                    return true;
                }
                i++;
                j++;
            }
            return false;
        }

        private bool MinorDiagonalGameOver()
        {
            int countMarks = 0;
            int i = 1, j = 1;
            while (i < 3)
            {
                if (board.pieces[i, j].Owner == board.pieces[(i - 1), (j + 1)].Owner && board.pieces[i, j].Owner != Piece.Player.Noone)
                {
                    countMarks++;
                }
                if (countMarks == 2)
                {
                    winner = owner;
                    return true;
                }
                i++;
                j--;
            }
            return false;
        }

        private bool DrawGameOver()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.pieces[i, j].Owner == Piece.Player.Noone)
                    {
                        winner = Piece.Player.Noone;
                        return false;
                    }
                }
            }
            return true;
        }
    }
}