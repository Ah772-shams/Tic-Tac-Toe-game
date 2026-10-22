
using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    static void Main()
    {
        char player = 'X';
        int moves = 0;

        while (true)
        {
            Console.Clear();
            DrawBoard();

            Console.WriteLine($"Player {player}, choose a position (1-9):");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int position) ||
                position < 1 || position > 9)
            {
                Console.WriteLine("Invalid choice! Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            int index = position - 1;

            if (board[index] == 'X' || board[index] == 'O')
            {
                Console.WriteLine("This position is already taken!");
                Console.ReadLine();
                continue;
            }

            board[index] = player;
            moves++;

            if (CheckWinner(player))
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"Player {player} wins!");
                break;
            }

            if (moves == 9)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("The game is a draw!");
                break;
            }

            player = player == 'X' ? 'O' : 'X';
        }

        Console.WriteLine("Game over. Press Enter to exit.");
        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine("TIC TAC TOE\n");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        Console.WriteLine();
    }

    static bool CheckWinner(char player)
    {
        int[,] combinations =
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (int i = 0; i < 8; i++)
        {
            if (board[combinations[i, 0]] == player &&
                board[combinations[i, 1]] == player &&
                board[combinations[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }
}
