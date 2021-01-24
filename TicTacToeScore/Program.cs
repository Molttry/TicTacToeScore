using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ConsoleApp1
{
    public class Scoreboard
    {
        public Dictionary<string, int> scoreboard = new Dictionary<string, int>();
        public void LoadFile()
        {
            using (var sr = new StreamReader("Score1.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] elements = line.Split(";");
                    string player = elements[0];
                    int score = int.Parse(elements[1]);
                    scoreboard.Add(player, score);
                }
            }

        }
        public void ScoreForPlayer(string name, string name1, char player)
        {
            if (player == 'X')
                scoreboard[name] += 10;
            else scoreboard[name1] += 10;
        }
        public void TieScore(string name, string name1)
        {
            scoreboard[name] += 5;
            scoreboard[name1] += 5;
        }
        public void Playeradd(string name, int newScore = 0)
        {
            if (!scoreboard.ContainsKey(name))
            {
                scoreboard.Add(name, 0);
            }
        }
        public void SaveScore()
        {
            using (var sr = new StreamWriter("Score1.txt"))
            {
                foreach (var entry in scoreboard)
                {
                    sr.WriteLine($"{entry.Key};{entry.Value}");
                    sr.Flush();
                }
            }
        }
        public void Show()
        {
            foreach (var entry in scoreboard)
            {
                Console.WriteLine($"Player: {entry.Key} has a score of {entry.Value}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.LoadFile();
            int turns = 9;
            char player = 'X';
            char[,] board = new char[3, 3];
            int row, col;
            char choice = ' ';
            string playerx, playero;
            while (true)
            {
                MenuPrint();
                BoardEx(board);
                choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {
                    case 's':
                        Console.Clear();
                        Console.WriteLine("PlayerX name:");
                        playerx = Console.ReadLine();
                        scoreboard.Playeradd(playerx);
                        Console.WriteLine("PlayerO name:");
                        playero = Console.ReadLine();
                        scoreboard.Playeradd(playero);
                        player = 'X';
                        while (true)
                        {
                            Console.Clear();
                            Print(board);
                            Console.WriteLine("Player '" + player + "' is playing!");
                            do
                            {
                                Console.WriteLine("Select the row");
                                row = Convert.ToInt32(Console.ReadLine()) - 1;
                                Console.WriteLine("Select column");
                                col = Convert.ToInt32(Console.ReadLine()) - 1;
                                Console.WriteLine("Try one more time!");
                            } while (board[row, col] == 'X' || board[row, col] == 'O');
                            board[row, col] = player;
                            turns--;
                            if (turns == 0)
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("We have a draw here 'X' and 'O' pretty good at this game");
                                scoreboard.TieScore(playerx, playero);
                                break;
                            }
                            if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[1, 0] && player == board[1, 1] && player == board[1, 2])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[2, 0] && player == board[2, 1] && player == board[2, 2])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[0, 0] && player == board[1, 0] && player == board[2, 0])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                if (player == 'X')
                                    scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[0, 1] && player == board[1, 1] && player == board[2, 1])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[0, 2] && player == board[1, 2] && player == board[2, 2])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[0, 0] && player == board[1, 1] && player == board[2, 2])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            else if (player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
                            {
                                Console.Clear();
                                Print(board);
                                Console.WriteLine("Very cool! Player '" + player + "' won!");
                                scoreboard.ScoreForPlayer(playerx, playero, player);
                                break;
                            }
                            if (player == 'X')
                            {
                                player = 'O';
                            }
                            else
                            {
                                player = 'X';
                            }

                        }
                        scoreboard.SaveScore();
                        Console.WriteLine("To go to menu press the key!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 'p':
                        Console.Clear();
                        scoreboard.Show();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 'a':
                        Console.Clear();
                        Console.WriteLine("Author of this game is Anton Berdiuhin. Who made this game not knowing anything about c# ://");
                        Console.WriteLine("Press any botton");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 'e':
                        Console.Clear();
                        Console.WriteLine("Do you really want to exit? (y/n)");
                        choice = Convert.ToChar(Console.ReadLine());
                        switch (choice)
                        {
                            case 'y':
                                Console.WriteLine("Thanks for attention");
                                System.Environment.Exit(-1);
                                break;

                            case 'n':
                                Console.Clear();
                                break;

                        }
                        break;

                }
            }




        }
        static void MenuPrint()
        {
            Console.WriteLine("__-Welcome to TIC-TAC-TOE-__");
            Console.WriteLine("Press the button to use menu!");
            Console.WriteLine("Start the game! (s)");
            Console.WriteLine("Player board! (p)");
            Console.WriteLine("About the author (a)");
            Console.WriteLine("Exit the game (e)");
        }
        static void BoardEx(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                    board[row, col] = ' ';
            }
        }
        static void Print(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {

                Console.Write(row + 1 + "| ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("   1   2   3   ");
        }
    }

}
