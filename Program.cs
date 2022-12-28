﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using WW;

// EXTENSION METHOD: Wordwrap - allows the programmer to specify how many characters should be printed before a newline is made. i have implemented this to ensure enhanced readability of code.
namespace WW
{
#if WWLIB
    public
#endif
    static partial class StringUtility
    {
        static readonly char[] _WordBreakChars = new char[]
        {
            ' ',
            '_',
            '\t',
            '+',
            '-',
            '(',
            ')',
            '[',
            ']',
            '\"',
            /*'\'',*/
            '{',
            '}',
            '!',
            '<',
            '>',
            '~',
            '`',
            '*',
            '$',
            '#',
            '@',
            '!',
            '\\',
            '/',
            ':',
            ';',
            '?',
            '^',
            '%',
            '&',
            '|',
            '\n',
            '\r',
            '\v',
            '\f',
            '\0'
        };
        public static string WordWrap(this string text, int width, params char[] wordBreakChars)
        {
            if (string.IsNullOrEmpty(text) || 0 == width || width >= text.Length)
                return text;
            if (null == wordBreakChars || 0 == wordBreakChars.Length)
                wordBreakChars = _WordBreakChars;
            var sb = new StringBuilder();
            var sr = new StringReader(text);
            string line;
            var first = true;
            while (null != (line = sr.ReadLine()))
            {
                var col = 0;
                if (!first)
                {
                    sb.AppendLine();
                    col = 0;
                }
                else
                    first = false;
                var words = line.Split(wordBreakChars);

                for (var i = 0; i < words.Length; i++)
                {
                    var word = words[i];
                    if (0 != i)
                    {
                        sb.Append(" ");
                        ++col;
                    }
                    if (col + word.Length > width)
                    {
                        sb.AppendLine();
                        col = 0;
                    }
                    sb.Append(word);
                    col += word.Length;
                }
            }
            return sb.ToString();
        }
    }
}

// main program

namespace Boats
{
    class Program
    {
        static void Main(string[] args)
        {
            // support advanced unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Battle Boats (c) S104 Productions 2001-2023");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            while (true)
            {
                // Output the menu options
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your menu choice: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Start new game\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("2 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Resume game\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("3 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("View instructions\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("4 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Exit program\n\n");

                // Ask for the menu option
                Console.ForegroundColor = ConsoleColor.Blue;
                string menuOption = Console.ReadLine();

                // Perform a subroutine based on the menu option
                switch (menuOption)
                {
                    case "1":
                        LoadingAnimation();
                        CreateBaseGrid();

                        PlayGame();
                        break;

                    case "2":
                        // read the variable data from the file
                        try
                        {
                            string[] fileLines = File.ReadAllLines("47495645204d4520414e2041.dat");
                            int lineIndex = 0;

                            // read the primary grid data from the file
                            string[,] primarygrid = new string[8, 8];
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    primarygrid[i, j] = fileLines[lineIndex][j].ToString();
                                }
                                lineIndex++;
                            }

                            // read the secondary grid data from the file
                            string[,] secondarygrid = new string[8, 8];
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    secondarygrid[i, j] = fileLines[lineIndex][j].ToString();
                                }
                                lineIndex++;
                            }

                            // read the intcoords variables from the file
                            string[] intcoords1Line = fileLines[lineIndex].Split(':')[1].Split(',');
                            List<int> intcoords1 = new List<int>
                            {
                                int.Parse(intcoords1Line[0]),
                                int.Parse(intcoords1Line[1])
                            };
                            lineIndex++;

                            string[] intcoords2Line = fileLines[lineIndex].Split(':')[1].Split(',');
                            List<int> intcoords2 = new List<int>
                            {
                                int.Parse(intcoords2Line[0]),
                                int.Parse(intcoords2Line[1])
                            };
                            lineIndex++;

                            string[] intcoords3Line = fileLines[lineIndex].Split(':')[1].Split(',');
                            List<int> intcoords3 = new List<int>
                            {
                                int.Parse(intcoords3Line[0]),
                                int.Parse(intcoords3Line[1])
                            };
                            lineIndex++;

                            string[] intcoords4Line = fileLines[lineIndex].Split(':')[1].Split(',');
                            List<int> intcoords4 = new List<int>
                            {
                                int.Parse(intcoords4Line[0]),
                                int.Parse(intcoords4Line[1])
                            };
                            lineIndex++;

                            string[] intcoords5Line = fileLines[lineIndex].Split(':')[1].Split(',');
                            List<int> intcoords5 = new List<int>
                            {
                                int.Parse(intcoords5Line[0]),
                                int.Parse(intcoords5Line[1])
                            };
                            lineIndex++;

                            // read the computercoords variables from the file
                            string[] computercoords1Line = fileLines[lineIndex].Split(':')[1].Split(
                                ','
                            );
                            int[] computercoords1 = new int[]
                            {
                                int.Parse(computercoords1Line[0]),
                                int.Parse(computercoords1Line[1])
                            };
                            lineIndex++;

                            string[] computercoords2Line = fileLines[lineIndex].Split(':')[1].Split(
                                ','
                            );
                            int[] computercoords2 = new int[]
                            {
                                int.Parse(computercoords2Line[0]),
                                int.Parse(computercoords2Line[1])
                            };
                            lineIndex++;

                            string[] computercoords3Line = fileLines[lineIndex].Split(':')[1].Split(
                                ','
                            );
                            int[] computercoords3 = new int[]
                            {
                                int.Parse(computercoords3Line[0]),
                                int.Parse(computercoords3Line[1])
                            };
                            lineIndex++;

                            string[] computercoords4Line = fileLines[lineIndex].Split(':')[1].Split(
                                ','
                            );
                            int[] computercoords4 = new int[]
                            {
                                int.Parse(computercoords4Line[0]),
                                int.Parse(computercoords4Line[1])
                            };
                            lineIndex++;

                            string[] computercoords5Line = fileLines[lineIndex].Split(':')[1].Split(
                                ','
                            );
                            int[] computercoords5 = new int[]
                            {
                                int.Parse(computercoords5Line[0]),
                                int.Parse(computercoords5Line[1])
                            };
                            lineIndex++;

                            // looping through array
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" 1 2 3 4 5 6 7 8");
                            for (int i = 0; i < 8; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(i + 1);
                                for (int j = 0; j < 8; j++)
                                {
                                    // loop through and print all elements of 2d array
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write($"{primarygrid[i, j]} ");
                                }
                                // new line between each row
                                ResetColors();
                                Console.WriteLine("");
                            }

                            // new line to clear coloring
                            ResetColors();
                            Console.WriteLine("");

                            // generate computer's coordinates and ensure the same set is not made twice
                            Random rng = new Random();

                            List<int[]> computercoords = new List<int[]>();

                            while (computercoords.Count < 5)
                            {
                                int x = rng.Next(1, 9);
                                int y = rng.Next(1, 9);
                                int[] coord = { x, y };

                                if (!computercoords.Contains(coord))
                                {
                                    computercoords.Add(coord);
                                }
                            }

                            computercoords1 = computercoords[0];
                            computercoords2 = computercoords[1];
                            computercoords3 = computercoords[2];
                            computercoords4 = computercoords[3];
                            computercoords5 = computercoords[4];

                            // print all coords (testing purposes)

                            Console.WriteLine($"{computercoords1[0]}, {computercoords1[1]}");
                            Console.WriteLine($"{computercoords2[0]}, {computercoords2[1]}");
                            Console.WriteLine($"{computercoords3[0]}, {computercoords3[1]}");
                            Console.WriteLine($"{computercoords4[0]}, {computercoords4[1]}");
                            Console.WriteLine($"{computercoords5[0]}, {computercoords5[1]}\n\n");

                            Console.WriteLine($"{intcoords1[0]}, {intcoords1[1]}");
                            Console.WriteLine($"{intcoords2[0]}, {intcoords2[1]}");
                            Console.WriteLine($"{intcoords3[0]}, {intcoords3[1]}");
                            Console.WriteLine($"{intcoords4[0]}, {intcoords4[1]}");
                            Console.WriteLine($"{intcoords5[0]}, {intcoords5[1]}");

                            // initialise the user and computer guess count to keep track of all correct guesses
                            int userguesses = 0;
                            int computerguesses = 0;
                            bool gamedone = false;
                            int itcount = 1;

                            List<int[]> previoususercoords = new List<int[]>();
                            List<int[]> previouscomputercoords = new List<int[]>();

                            do
                            {
                                Thread.Sleep(500);
                                string userguess = "";
                                string pattern = @"^\d+,\d+$";
                                Regex regcheck = new Regex(pattern);

                                // user guess
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\nGuess the location of a computer's ship in ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("x,y ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"format. (iteration: {itcount})\n\n");
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    userguess = Console.ReadLine();
                                    string[] uservalidator = userguess.Split(',');

                                    if (
                                        regcheck.IsMatch(userguess)
                                        && Convert.ToInt32(uservalidator[0]) >= 1
                                        && Convert.ToInt32(uservalidator[0]) <= 8
                                        && Convert.ToInt32(uservalidator[1]) >= 1
                                        && Convert.ToInt32(uservalidator[1]) <= 8
                                    )
                                    {
                                        // userguess is in x, y format and is inside bounds
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("Error: Invalid input string\n");
                                        Thread.Sleep(500);
                                    }
                                }

                                itcount += 1;
                                // split the user guess into an array
                                string[] userguessarray = userguess.Split(',');

                                int[] userguessint = new int[2];

                                // check if hit with abnormally big statement

                                for (int i = 0; i < 2; i++)
                                    userguessint[i] = Int32.Parse(userguessarray[i]);

                                if (
                                    (
                                        userguessint[0] == computercoords1[0]
                                        && userguessint[1] == computercoords1[1]
                                    )
                                    || (
                                        userguessint[0] == computercoords2[0]
                                        && userguessint[1] == computercoords2[1]
                                    )
                                    || (
                                        userguessint[0] == computercoords3[0]
                                        && userguessint[1] == computercoords3[1]
                                    )
                                    || (
                                        userguessint[0] == computercoords4[0]
                                        && userguessint[1] == computercoords4[1]
                                    )
                                    || (
                                        userguessint[0] == computercoords5[0]
                                        && userguessint[1] == computercoords5[1]
                                    )
                                )
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("You hit one of the computer's ships!\n");
                                    userguesses += 1;
                                    Thread.Sleep(1000);
                                    // re print grid with a H on the place hit
                                    secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "H";
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{primarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{secondarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You missed your shot.\n");

                                    Thread.Sleep(1000);

                                    // re print grid with a M on the place hit
                                    secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "M";
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{primarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{secondarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }
                                }

                                // create a list to store the previously generated coordinates
                                List<int[]> usedcoordinates = new List<int[]>();

                                // generate random computer guess coordinates
                                Random r = new Random();
                                int[] computerguess = new int[2];

                                // assign random computer value
                                computerguess[0] = r.Next(0, 8);
                                computerguess[1] = r.Next(0, 8);

                                //Console.WriteLine($"computer coordinate for next: {computerguess[0] + 1}, {computerguess[1] + 1}");

                                // check if the computer has hit a previously referenced position, and if so then generate new coordinates. if not then continue
                                while (
                                    (primarygrid[computerguess[1], computerguess[0]] == "M")
                                    || (primarygrid[computerguess[1], computerguess[0]] == "H")
                                    || usedcoordinates.Contains(computerguess)
                                )
                                {
                                    // generate new coordinates
                                    //Console.WriteLine("computer hit a set of coordinates and regenerated.");
                                    computerguess[0] = r.Next(0, 8);
                                    computerguess[1] = r.Next(0, 8);
                                }

                                // add the generated coordinates to the list of used coordinates
                                usedcoordinates.Add(computerguess);

                                // the computer is guessing animation
                                ComputerIsGuessing();

                                // unfortunately big if statement again to check if computer guess lines up with player's coordinates and if it does then edit the PRIMARY GRID
                                if (
                                    (
                                        computerguess[0] == intcoords1[0]
                                        && computerguess[1] == intcoords1[1]
                                    )
                                    || (
                                        computerguess[0] == intcoords2[0]
                                        && computerguess[1] == intcoords2[1]
                                    )
                                    || (
                                        computerguess[0] == intcoords3[0]
                                        && computerguess[1] == intcoords3[1]
                                    )
                                    || (
                                        computerguess[0] == intcoords4[0]
                                        && computerguess[1] == intcoords4[1]
                                    )
                                    || (
                                        computerguess[0] == intcoords5[0]
                                        && computerguess[1] == intcoords5[1]
                                    )
                                )
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" One of your ships was struck!\n");
                                    computerguesses += 1;
                                    Thread.Sleep(1000);
                                    // re print primary grid with a H on the place hit
                                    primarygrid[computerguess[1] - 1, computerguess[0] - 1] = "H";
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{primarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{secondarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }
                                }
                                else
                                {
                                    // the computer is guessing again
                                    ComputerIsGuessing();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" The computer misses!\n");
                                    Thread.Sleep(500);

                                    // re print grid with a M on the place hit
                                    primarygrid[computerguess[1], computerguess[0]] = "M";
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{primarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                    for (int i = 0; i < 8; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(i + 1);
                                        for (int j = 0; j < 8; j++)
                                        {
                                            // loop through and print all elements of 2d array
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.Write($"{secondarygrid[i, j]} ");
                                        }
                                        // new line between each row
                                        ResetColors();
                                        Console.WriteLine("");
                                    }
                                }

                                // save the game variables to a file after each guess made by the user and computer
                                using (
                                    StreamWriter writer = new StreamWriter(
                                        "47495645204d4520414e2041.dat", false
                                    )
                                )
                                {
                                    // Save the primary grid to the file
                                    for (int i = 0; i < 8; i++)
                                    {
                                        for (int j = 0; j < 8; j++)
                                        {
                                            writer.Write(primarygrid[i, j]);
                                        }
                                        writer.WriteLine();
                                    }

                                    // Save the secondary grid to the file
                                    for (int i = 0; i < 8; i++)
                                    {
                                        for (int j = 0; j < 8; j++)
                                        {
                                            writer.Write(secondarygrid[i, j]);
                                        }
                                        writer.WriteLine();
                                    }

                                    // Save the intcoords variables to the file
                                    writer.WriteLine($"intcoords1:{intcoords1[0]},{intcoords1[1]}");
                                    writer.WriteLine($"intcoords2:{intcoords2[0]},{intcoords2[1]}");
                                    writer.WriteLine($"intcoords3:{intcoords3[0]},{intcoords3[1]}");
                                    writer.WriteLine($"intcoords4:{intcoords4[0]},{intcoords4[1]}");
                                    writer.WriteLine($"intcoords5:{intcoords5[0]},{intcoords5[1]}");

                                    // Save the computercoords variables to the file
                                    writer.WriteLine(
                                        $"computercoords1:{computercoords1[0]},{computercoords1[1]}"
                                    );
                                    writer.WriteLine(
                                        $"computercoords2:{computercoords2[0]},{computercoords2[1]}"
                                    );
                                    writer.WriteLine(
                                        $"computercoords3:{computercoords3[0]},{computercoords3[0]}"
                                    );
                                    writer.WriteLine(
                                        $"computercoords4:{computercoords4[0]},{computercoords4[1]}"
                                    );
                                    writer.WriteLine(
                                        $"computercoords5:{computercoords5[0]},{computercoords5[1]}"
                                    );
                                }

                                if (userguesses == 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(
                                        "\nYou found all the computer's ships and won!"
                                    );
                                    Thread.Sleep(1000);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nGame over!");
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(
                                        "\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n"
                                    );
                                    gamedone = true;
                                }

                                if (computerguesses == 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nThe computer hit all your ships and won!");
                                    Thread.Sleep(1000);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nGame over!");
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(
                                        "\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n"
                                    );
                                    gamedone = true;
                                }
                            } while (!gamedone);
                        }
                        catch
                        {
                            InvalidInputString("Error: File couldn't be read or doesn't exist\n");
                            break;
                        }
                        break;

                    case "3":
                        Thread.Sleep(990);
                        string s1 =
                            "\nBattle boats is a turn based strategy game where players eliminate their opponents fleet of boats by firing at a location on a grid in an attempt to sink them. The first player to sink all of their opponents’ battle boats is declared the winner.";
                        string s2 =
                            "Each player has two eight by eight grids. One grid is used for their own battle boats and the other is used to record any hits or misses placed on their opponents. At the beginning of the game, players decide where they wish to place their fleet of five battle boats.";
                        string s3 =
                            "During game play, players take it in turns to fire at a location on their opponent’s board. They do this by stating the coordinates for their target. If a player hits their opponent's boat then this is recorded as a hit. If they miss then this is recorded as a miss.";
                        string s4 =
                            "The game ends when a player's fleet of boats have been sunk. The winner is the player with boats remaining at the end of the game.";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(s1.WordWrap(80));
                        Thread.Sleep(6250);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(s2.WordWrap(85));
                        Thread.Sleep(6500);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(s3.WordWrap(80));
                        Thread.Sleep(6550);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(s4.WordWrap(85));
                        Thread.Sleep(5550);

                        Thread.Sleep(550);
                        Console.WriteLine("");
                        Thread.Sleep(500);
                        Console.WriteLine("");
                        Thread.Sleep(500);
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nG");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("d");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("b");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("y");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("e");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;

                    default:
                        InvalidInputString("Error: Invalid input string\n");
                        break;
                }
            }
        }

        static void PlayGame()
        {
            string pattern = @"^\d+,\d+$";
            Regex regcheck = new Regex(pattern);

            Console.Write("\nPlease enter the coordinates of your ships in ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("x,y ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("format.\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;

            string coordinate1;
            string coordinate2;
            string coordinate3;
            string coordinate4;
            string coordinate5;
            List<int> intcoords1 = new List<int>();
            List<int> intcoords2 = new List<int>();
            List<int> intcoords3 = new List<int>();
            List<int> intcoords4 = new List<int>();
            List<int> intcoords5 = new List<int>();

            // do while loop to repeatedly ask for input until int parseable and is in right format
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                // get input for first set of coordinates
                coordinate1 = Console.ReadLine();
                string[] coordinatearray1 = coordinate1.Split(',');
                if (
                    !(regcheck.IsMatch(coordinate1))
                    || coordinatearray1.Length != 2
                    || !int.TryParse(coordinatearray1[0], out int x)
                    || !int.TryParse(coordinatearray1[1], out int y)
                    || !(Convert.ToInt32(coordinatearray1[0]) >= 1)
                    || !(Convert.ToInt32(coordinatearray1[0]) <= 8)
                    || !(Convert.ToInt32(coordinatearray1[1]) >= 1)
                    || !(Convert.ToInt32(coordinatearray1[1]) <= 8)
                )
                {
                    InvalidInputString("Error: Invalid input string\n");
                    continue;
                }
                intcoords1.Add(x);
                intcoords1.Add(y);
                break;
            } while (true);

            // repeat (2) the process for the remaining sets of coordinates
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                coordinate2 = Console.ReadLine();
                string[] coordinatearray2 = coordinate2.Split(',');
                if (
                    !(regcheck.IsMatch(coordinate2))
                    || coordinatearray2.Length != 2
                    || !int.TryParse(coordinatearray2[0], out int x)
                    || !int.TryParse(coordinatearray2[1], out int y)
                    || !(Convert.ToInt32(coordinatearray2[0]) >= 1)
                    || !(Convert.ToInt32(coordinatearray2[0]) <= 8)
                    || !(Convert.ToInt32(coordinatearray2[1]) >= 1)
                    || !(Convert.ToInt32(coordinatearray2[1]) <= 8)
                )
                {
                    InvalidInputString("Error: Invalid input string\n");
                    continue;
                }
                if (coordinate2 == coordinate1)
                {
                    InvalidInputString("Error: Duplicate input string\n");
                    continue;
                }
                intcoords2.Add(x);
                intcoords2.Add(y);
                break;
            } while (true);

            // repeat (3)
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                coordinate3 = Console.ReadLine();
                string[] coordinatearray3 = coordinate3.Split(',');
                if (
                    coordinatearray3.Length != 2
                    || !int.TryParse(coordinatearray3[0], out int x)
                    || !int.TryParse(coordinatearray3[1], out int y)
                    || !(Convert.ToInt32(coordinatearray3[0]) >= 1)
                    || !(Convert.ToInt32(coordinatearray3[0]) <= 8)
                    || !(Convert.ToInt32(coordinatearray3[1]) >= 1)
                    || !(Convert.ToInt32(coordinatearray3[1]) <= 8)
                )
                {
                    InvalidInputString("Error: Invalid input string\n");
                    continue;
                }

                if ((coordinate3 == coordinate2) || (coordinate3 == coordinate1))
                {
                    InvalidInputString("Error: Duplicate input string\n");
                    continue;
                }
                intcoords3.Add(x);
                intcoords3.Add(y);
                break;
            } while (true);

            // repeat (4)
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                coordinate4 = Console.ReadLine();
                string[] coordinatearray4 = coordinate4.Split(',');
                if (
                    !(regcheck.IsMatch(coordinate4))
                    || coordinatearray4.Length != 2
                    || !int.TryParse(coordinatearray4[0], out int x)
                    || !int.TryParse(coordinatearray4[1], out int y)
                    || !(Convert.ToInt32(coordinatearray4[0]) >= 1)
                    || !(Convert.ToInt32(coordinatearray4[0]) <= 8)
                    || !(Convert.ToInt32(coordinatearray4[1]) >= 1)
                    || !(Convert.ToInt32(coordinatearray4[1]) <= 8)
                )
                {
                    InvalidInputString("Error: Invalid input string\n");
                    continue;
                }

                if (
                    (coordinate4 == coordinate3)
                    || (coordinate4 == coordinate2)
                    || (coordinate4 == coordinate1)
                )
                {
                    InvalidInputString("Error: Duplicate input string\n");
                    continue;
                }
                intcoords4.Add(x);
                intcoords4.Add(y);
                break;
            } while (true);

            // repeat (5)
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                coordinate5 = Console.ReadLine();
                string[] coordinatearray5 = coordinate5.Split(',');
                if (
                    !(regcheck.IsMatch(coordinate1))
                    || coordinatearray5.Length != 2
                    || !int.TryParse(coordinatearray5[0], out int x)
                    || !int.TryParse(coordinatearray5[1], out int y)
                    || !(Convert.ToInt32(coordinatearray5[0]) >= 1)
                    || !(Convert.ToInt32(coordinatearray5[0]) <= 8)
                    || !(Convert.ToInt32(coordinatearray5[1]) >= 1)
                    || !(Convert.ToInt32(coordinatearray5[1]) <= 8)
                )
                {
                    InvalidInputString("Error: Invalid input string\n");
                    continue;
                }

                if (
                    (coordinate5 == coordinate4)
                    || (coordinate5 == coordinate3)
                    || (coordinate5 == coordinate2)
                    || (coordinate5 == coordinate1)
                )
                {
                    InvalidInputString("Error: Duplicate input string\n");
                    continue;
                }
                intcoords5.Add(x);
                intcoords5.Add(y);
                break;
            } while (true);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYour coordinates are displayed as follows:\n");

            // create 2d array to display updated grid
            string[,] primarygrid = new string[8, 8]
            {
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." },
                { ".", ".", ".", ".", ".", ".", ".", "." }
            };

            string[,] secondarygrid = new string[8, 8];
            Array.Copy(primarygrid, secondarygrid, primarygrid.Length);

            // edit user defined locations of array and mark it
            Console.ForegroundColor = ConsoleColor.Red;
            primarygrid[intcoords1[1] - 1, intcoords1[0] - 1] = "▢";
            primarygrid[intcoords2[1] - 1, intcoords2[0] - 1] = "▢";
            primarygrid[intcoords3[1] - 1, intcoords3[0] - 1] = "▢";
            primarygrid[intcoords4[1] - 1, intcoords4[0] - 1] = "▢";
            primarygrid[intcoords5[1] - 1, intcoords5[0] - 1] = "▢";

            // looping through array
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" 1 2 3 4 5 6 7 8");
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(i + 1);
                for (int j = 0; j < 8; j++)
                {
                    // loop through and print all elements of 2d array
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{primarygrid[i, j]} ");
                }
                // new line between each row
                ResetColors();
                Console.WriteLine("");
            }

            // new line to clear coloring
            ResetColors();
            Console.WriteLine("");

            // generate computer's coordinates and ensure the same set is not made twice
            Random rng = new Random();

            List<int[]> computercoords = new List<int[]>();

            while (computercoords.Count < 5)
            {
                int x = rng.Next(1, 9);
                int y = rng.Next(1, 9);
                int[] coord = { x, y };

                if (!computercoords.Contains(coord))
                {
                    computercoords.Add(coord);
                }
            }

            int[] computercoords1 = computercoords[0];
            int[] computercoords2 = computercoords[1];
            int[] computercoords3 = computercoords[2];
            int[] computercoords4 = computercoords[3];
            int[] computercoords5 = computercoords[4];

            // print all coords (testing purposes)

            Console.WriteLine($"{computercoords1[0]}, {computercoords1[1]}");
            Console.WriteLine($"{computercoords2[0]}, {computercoords2[1]}");
            Console.WriteLine($"{computercoords3[0]}, {computercoords3[1]}");
            Console.WriteLine($"{computercoords4[0]}, {computercoords4[1]}");
            Console.WriteLine($"{computercoords5[0]}, {computercoords5[1]}\n\n");

            Console.WriteLine($"{intcoords1[0]}, {intcoords1[1]}");
            Console.WriteLine($"{intcoords2[0]}, {intcoords2[1]}");
            Console.WriteLine($"{intcoords3[0]}, {intcoords3[1]}");
            Console.WriteLine($"{intcoords4[0]}, {intcoords4[1]}");
            Console.WriteLine($"{intcoords5[0]}, {intcoords5[1]}");

            // initialise the user and computer guess count to keep track of all correct guesses
            int userguesses = 0;
            int computerguesses = 0;
            bool gamedone = false;
            int itcount = 1;

            List<int[]> previoususercoords = new List<int[]>();
            List<int[]> previouscomputercoords = new List<int[]>();

            do
            {
                Thread.Sleep(500);
                string userguess = "";

                // user guess
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nGuess the location of a computer's ship in ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("x,y ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"format. (iteration: {itcount})\n\n");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    userguess = Console.ReadLine();
                    string[] uservalidator = userguess.Split(',');

                    if (
                        regcheck.IsMatch(userguess)
                        && Convert.ToInt32(uservalidator[0]) >= 1
                        && Convert.ToInt32(uservalidator[0]) <= 8
                        && Convert.ToInt32(uservalidator[1]) >= 1
                        && Convert.ToInt32(uservalidator[1]) <= 8
                    )
                    {
                        // userguess is in x, y format and is inside bounds
                        break;
                    }
                    else
                    {
                        InvalidInputString("Error: Invalid input string\n");
                    }
                }

                itcount += 1;
                // split the user guess into an array
                string[] userguessarray = userguess.Split(',');

                int[] userguessint = new int[2];

                // check if hit with abnormally big statement

                for (int i = 0; i < 2; i++)
                    userguessint[i] = Int32.Parse(userguessarray[i]);

                if (
                    (userguessint[0] == computercoords1[0] && userguessint[1] == computercoords1[1])
                    || (
                        userguessint[0] == computercoords2[0]
                        && userguessint[1] == computercoords2[1]
                    )
                    || (
                        userguessint[0] == computercoords3[0]
                        && userguessint[1] == computercoords3[1]
                    )
                    || (
                        userguessint[0] == computercoords4[0]
                        && userguessint[1] == computercoords4[1]
                    )
                    || (
                        userguessint[0] == computercoords5[0]
                        && userguessint[1] == computercoords5[1]
                    )
                )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You hit one of the computer's ships!\n");
                    userguesses += 1;
                    Thread.Sleep(1000);
                    // re print grid with a H on the place hit
                    secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "H";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{primarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{secondarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You missed your shot.\n");

                    Thread.Sleep(1000);

                    // re print grid with a M on the place hit
                    secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "M";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{primarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{secondarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }
                }

                // create a list to store the previously generated coordinates
                List<int[]> usedcoordinates = new List<int[]>();

                // generate random computer guess coordinates
                Random r = new Random();
                int[] computerguess = new int[2];

                // assign random computer value
                computerguess[0] = r.Next(0, 8);
                computerguess[1] = r.Next(0, 8);

                //Console.WriteLine($"computer coordinate for next: {computerguess[0] + 1}, {computerguess[1] + 1}");

                // check if the computer has hit a previously referenced position, and if so then generate new coordinates. if not then continue
                while (
                    (primarygrid[computerguess[1], computerguess[0]] == "M")
                    || (primarygrid[computerguess[1], computerguess[0]] == "H")
                    || usedcoordinates.Contains(computerguess)
                )
                {
                    // generate new coordinates
                    //Console.WriteLine("computer hit a set of coordinates and regenerated.");
                    computerguess[0] = r.Next(0, 8);
                    computerguess[1] = r.Next(0, 8);
                }

                // add the generated coordinates to the list of used coordinates
                usedcoordinates.Add(computerguess);

                // the computer is guessing animation
                ComputerIsGuessing();

                // unfortunately big if statement again to check if computer guess lines up with player's coordinates and if it does then edit the PRIMARY GRID
                if (
                    (computerguess[0] == intcoords1[0] && computerguess[1] == intcoords1[1])
                    || (computerguess[0] == intcoords2[0] && computerguess[1] == intcoords2[1])
                    || (computerguess[0] == intcoords3[0] && computerguess[1] == intcoords3[1])
                    || (computerguess[0] == intcoords4[0] && computerguess[1] == intcoords4[1])
                    || (computerguess[0] == intcoords5[0] && computerguess[1] == intcoords5[1])
                )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" One of your ships was struck!\n");
                    computerguesses += 1;
                    Thread.Sleep(1000);
                    // re print primary grid with a H on the place hit
                    primarygrid[computerguess[1] - 1, computerguess[0] - 1] = "H";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{primarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{secondarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }
                }
                else
                {
                    // the computer is guessing again
                    ComputerIsGuessing();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" The computer misses!\n");
                    Thread.Sleep(500);

                    // re print grid with a M on the place hit
                    primarygrid[computerguess[1], computerguess[0]] = "M";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{primarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // loop through and print all elements of 2d array
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"{secondarygrid[i, j]} ");
                        }
                        // new line between each row
                        ResetColors();
                        Console.WriteLine("");
                    }
                }

                // save the game variables to a file after each guess made by the user and computer
                using (StreamWriter writer = new StreamWriter("47495645204d4520414e2041.dat", false))
                {
                    // Save the primary grid to the file
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            writer.Write(primarygrid[i, j]);
                        }
                        writer.WriteLine();
                    }

                    // Save the secondary grid to the file
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            writer.Write(secondarygrid[i, j]);
                        }
                        writer.WriteLine();
                    }

                    // Save the intcoords variables to the file
                    writer.WriteLine($"intcoords1:{intcoords1[0]},{intcoords1[1]}");
                    writer.WriteLine($"intcoords2:{intcoords2[0]},{intcoords2[1]}");
                    writer.WriteLine($"intcoords3:{intcoords3[0]},{intcoords3[1]}");
                    writer.WriteLine($"intcoords4:{intcoords4[0]},{intcoords4[1]}");
                    writer.WriteLine($"intcoords5:{intcoords5[0]},{intcoords5[1]}");

                    // Save the computercoords variables to the file
                    writer.WriteLine($"computercoords1:{computercoords1[0]},{computercoords1[1]}");
                    writer.WriteLine($"computercoords2:{computercoords2[0]},{computercoords2[1]}");
                    writer.WriteLine($"computercoords3:{computercoords3[0]},{computercoords3[0]}");
                    writer.WriteLine($"computercoords4:{computercoords4[0]},{computercoords4[1]}");
                    writer.WriteLine($"computercoords5:{computercoords5[0]},{computercoords5[1]}");
                }

                if (userguesses == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nYou found all the computer's ships and won!");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGame over!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
                    gamedone = true;
                }

                if (computerguesses == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThe computer hit all your ships and won!");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGame over!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
                    gamedone = true;
                }
            } while (!gamedone);
        }

        static void LoadingAnimation()
        {
            // weird unnecessary loading animation
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nStarting new game");
            Console.SetCursorPosition(17, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(18, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(19, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.SetCursorPosition(21, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!");
            Thread.Sleep(1500);
        }

        static void InvalidInputString(string reason)
        {
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(reason);
            Thread.Sleep(500);
        }

        static void CreateBaseGrid()
        {
            // nested for-loop matrix for base grid
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" 1 2 3 4 5 6 7 8");
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(i + 1);
                for (int j = 0; j < 8; j++)
                {
                    // make it look pretty
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(". ");
                }
                // new line between each row
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
        }

        static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ComputerIsGuessing()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] guessidentifiers =
            {
                "The computer prepares for battle",
                "The computer is adjusting its tactics",
                "The computer is scanning the battlefield",
                "The computer is broadcasting a message to you: 010001000100100101000101",
                "The computer is making a calculated guess",
                "A fan is whirring somewhere",
                "The computer begins overclocking itself for extra efficiency",
                "The computer is undergoing a situational analysis",
                "The computer begins measuring change in potential energy",
                "The computer is thinking",
                "The AI is racking its cache",
                "The computer prepares for its turn",
                "The computer begins trash talking you in machine code",
                "The computer is analysing its choices"
            };
            Random r = new Random();
            string sentenceinuse = guessidentifiers[r.Next(0, guessidentifiers.Length)];

            Console.WriteLine("\n" + sentenceinuse);

            Console.SetCursorPosition(sentenceinuse.Length, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(sentenceinuse.Length + 1, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.SetCursorPosition(sentenceinuse.Length + 2, Console.CursorTop - 1);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.SetCursorPosition(sentenceinuse.Length + 3, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}