using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = new char[9];
        static char player = 'X';
        static char computer = 'O';
        static void Main(string[] args)
        {
            InitializeBoard();
            RandomizePlayer();
            PlayGame();
        }
        static void InitializeBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }
        static void RandomizePlayer()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
                Console.WriteLine("Игрок начинает первым!");
            else
                Console.WriteLine("Компьютер начинает первым!");
        }
        static void PlayGame()
        {
            while (true)
            {
                PlayerMove();
                if (CheckWin(player))
                {
                    Console.WriteLine("Победа игрока!");
                    break;
                }
                if (CheckDraw())
                {
                    Console.WriteLine("Ничья!");
                    break;
                }

                ComputerMove();
                DisplayBoard();
                if (CheckWin(computer))
                {
                    Console.WriteLine("Победа компьютера!");
                    break;
                }
                if (CheckDraw())
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
                DisplayBoard();
            }
        }
        static void PlayerMove()
        {
            DisplayBoard();
            Console.Write("Введите позицию (1-9): ");
            int position = Convert.ToInt32(Console.ReadLine()) - 1;
            if (board[position] == ' ')
                board[position] = player;
            else
                Console.WriteLine("Эта позиция уже занята.");
        }
        static void ComputerMove()
        {
            Random rnd = new Random();
            int position;
            do
            {
                position = rnd.Next(0, 9);
            } while (board[position] != ' ');
            board[position] = computer;
            Console.WriteLine($"Компьютер сделал ход на позицию {position + 1}");
        }
        static bool CheckWin(char symbol)
        {
            return (board[0] == symbol && board[1] == symbol && board[2] == symbol) ||  // горизонтальные
                   (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
                   (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||
                   (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||  // вертикальные
                   (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                   (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                   (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||  // диагонали
                   (board[2] == symbol && board[4] == symbol && board[6] == symbol);
        }
        static bool CheckDraw()
        {
            foreach (char c in board)
            {
                if (c == ' ')
                    return false;
            }
            return true;
        }
        static void DisplayBoard()
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--|---|--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--|---|--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
            Console.WriteLine();
        }
    }
}



