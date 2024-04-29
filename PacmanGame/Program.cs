﻿namespace PacmanGame;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        var map = ReadMap("map.txt");

        ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

        int pacmanX = 1;
        int pacmanY = 1;

        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            DrawMap(map);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(pacmanX, pacmanY);
            Console.Write("@");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(32, 0);
            Console.Write(pressedKey.KeyChar);

            pressedKey = Console.ReadKey();

            HandleInput(pressedKey, ref pacmanX, ref pacmanY);
        }
    }

    private static char[,] ReadMap(string path)
    {
        var file = File.ReadAllLines(path);
        var map = new char[GetMaxLineLength(file), file.Length];

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                map[x, y] = file[y][x];
            }
        }

        return map;
    }


    private static int GetMaxLineLength(string[] lines)
    {
        int maxLength = lines[0].Length;

        foreach (var line in lines)
        {
            if (line.Length > maxLength)
            {
                maxLength = line.Length;
            }
        }

        return maxLength;
    }

    private static void DrawMap(char[,] map)
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write(map[x, y]);
            }

            Console.Write("\n");
        }
    }

    private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY)
    {
        if (pressedKey.Key == ConsoleKey.UpArrow)
        {
            pacmanY -= 1;
        }
        else if (pressedKey.Key == ConsoleKey.DownArrow)
        {
            pacmanY += 1;
        }
        else if (pressedKey.Key == ConsoleKey.RightArrow)
        {
            pacmanX += 1;
        }
        else if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
            pacmanX -= 1;
        }
    }

    private static int[] GetDirection(ConsoleKeyInfo pressedKey)
    {
        int[] direction = { 0, 0 };

        if (pressedKey.Key == ConsoleKey.UpArrow)
        {
            direction[1] = -1;
        }
        else if (pressedKey.Key == ConsoleKey.DownArrow)
        {
            direction[1] = 1;
        }
        else if (pressedKey.Key == ConsoleKey.RightArrow)
        {
            direction[0] = 1;
        }
        else if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
            direction[0] = -1;
        }

        return direction;
    }
}