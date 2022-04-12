using System;
using System.IO;

namespace ConsoleApp4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;

            Console.WriteLine("1 - Играть в заготовленную карту\n2 - Выгрузить свою\n3 - выход");

            int userInput = Convert.ToInt32(Console.ReadLine());

            while (isPlaying)
            {
                switch (userInput)
                {
                    case 1:
                        PlayPreparedMap(ref isPlaying);
                        break;

                    case 2:
                        PlayCreatedMap(ref isPlaying);
                        break;

                    case 3:
                        isPlaying = false;
                        break;

                    default:
                        Console.WriteLine("Такого выбора нет");
                        break;
                }
                Console.Clear();
            }
        }

        static void PlayPreparedMap(ref bool isPlaying)
        {
            Console.Clear();

            char[,] map = new char[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'  },
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'  },
                {'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'  },
                {'#', ' ', '#', ' ', '#', '#', '#', ' ', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#'  },
                {'#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#'  },
                {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', ' ', '#'  },
                {'#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#'  },
                {'#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#'  },
                {'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', '#', ' ', '#', '#', ' ', ' ', ' ', '#', ' ', '#'  },
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'  },
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'  }
            };

            int userY = 5;
            int userX = 10;

            while (isPlaying)
            {
                GamePlayLogic(map, ref userY, ref userX, ref isPlaying);
            }
        }

        static void PlayCreatedMap(ref bool isPlaying)
        {
            char[,] map = ReadMap("map1");

            int userX = 1;
            int userY = 1;

            while (isPlaying)
            {
                GamePlayLogic(map, ref userY, ref userX, ref isPlaying);
            }
        }

        static void GamePlayLogic(char[,] map, ref int userY, ref int userX, ref bool isPlaying)
        {
            Console.Clear();

            Console.CursorVisible = false;

            DrawMap(map);

            Console.SetCursorPosition(userX, userY);

            Console.Write("@");

            ConsoleKeyInfo payerMoveKey = Console.ReadKey();

            switch (payerMoveKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userY - 1, userX] != '#')
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userY + 1, userX] != '#')
                    {
                        userY++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userY, userX - 1] != '#')
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userY, userX + 1] != '#')
                    {
                        userX++;
                    }
                    break;
                case ConsoleKey.Escape:
                    isPlaying = false;
                    break;
            }

            Console.Clear();
        }

        static char[,] ReadMap(string mapName)
        {
            string[] newMapFile = File.ReadAllLines($"Maps/{mapName}.txt");

            char[,] map = new char[newMapFile.Length, newMapFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newMapFile[i][j];
                }
            }
            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
