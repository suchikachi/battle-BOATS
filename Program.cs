using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Calculator
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
                        
                        Console.Write("\nPlease enter the coordinates of your ships in ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("x,y ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("format.\n\n");
                        Console.ForegroundColor = ConsoleColor.Blue;


                        // get input of first coordinates and split characters into array
                        string coordinate1 = Console.ReadLine();
                        string[] coordinatearray1 = coordinate1.Split(',');
                        // initialize new integer array and convert the string array to int array
                        int arrsize1 = coordinatearray1.Length;
                        int[] intcoords1 = new int[arrsize1];
                        for(int i = 0; i < arrsize1; i++)
                        {
                            intcoords1[i] = Int32.Parse(coordinatearray1[i]);
                        }
                        //Console.WriteLine(intcoords1);

                        // Repeat 2
                        string coordinate2 = Console.ReadLine();
                        string[] coordinatearray2 = coordinate2.Split(',');
                        int arrsize2 = coordinatearray2.Length;
                        int[] intcoords2 = new int[arrsize2];
                        for(int i = 0; i < arrsize2; i++) intcoords2[i] = Int32.Parse(coordinatearray2[i]);
                        
                        // Repeat 3
                        string coordinate3 = Console.ReadLine();
                        string[] coordinatearray3 = coordinate3.Split(',');
                        int arrsize3 = coordinatearray3.Length;
                        int[] intcoords3 = new int[arrsize3];
                        for(int i = 0; i < arrsize3; i++) intcoords3[i] = Int32.Parse(coordinatearray3[i]);
                        
                        // Repeat 4
                        string coordinate4 = Console.ReadLine();
                        string[] coordinatearray4 = coordinate4.Split(',');
                        int arrsize4 = coordinatearray4.Length;
                        int[] intcoords4 = new int[arrsize4];
                        for(int i = 0; i < arrsize4; i++) intcoords4[i] = Int32.Parse(coordinatearray4[i]);

                        // Repeat 5
                        string coordinate5 = Console.ReadLine();
                        string[] coordinatearray5 = coordinate5.Split(',');
                        int arrsize5 = coordinatearray5.Length;
                        int[] intcoords5 = new int[arrsize5];
                        for(int i = 0; i < arrsize5; i++) intcoords5[i] = Int32.Parse(coordinatearray5[i]);
                         
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYour coordinates are displayed as follows:\n");
                        
                        // create 2d array to display updated grid
                        string[,] grid = new string[8, 8]
                        {
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."}
                        };
                        
                        string[,] gridfinal = new string[8, 8];
                        Array.Copy(grid, gridfinal, grid.Length);

                        // edit user defined locations of array and mark it
                        Console.ForegroundColor = ConsoleColor.Red;
                        grid[intcoords1[0] - 1, intcoords1[1] - 1] = "▢";
                        grid[intcoords2[0] - 1, intcoords2[1] - 1] = "▢";
                        grid[intcoords3[0] - 1, intcoords3[1] - 1] = "▢";
                        grid[intcoords4[0] - 1, intcoords4[1] - 1] = "▢";
                        grid[intcoords5[0] - 1, intcoords5[1] - 1] = "▢";

                        // looping through array
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" 1 2 3 4 5 6 7 8");
                        for (int i = 0; i < 8; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(i + 1);
                            for (int j = 0; j < 8; j++)
                            {
                                // loop through and print all elements of 2d array
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write($"{grid[i, j]} ");
                            }
                            // new line between each row
                            ResetColors();
                            Console.WriteLine("");
                        }

                        // new line to clear coloring
                        ResetColors();
                        Console.WriteLine("");

                        // generate computer's coordinates
                        Random computervalues = new Random();
                        int[] computercoords1 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords2 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords3 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords4 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords5 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};

                        /*for (int i = 0; i < computercoords1.Length; i++)
                        {
                            Console.WriteLine(computercoords1[i]);
                            Console.WriteLine(computercoords2[i]);
                            Console.WriteLine(computercoords3[i]);
                            Console.WriteLine(computercoords4[i]);
                            Console.WriteLine(computercoords5[i]);
                        }*/

                        int userguesses = 0;
                        int computerguesses = 0;
                        bool gamedone = false;

                        do
                        {
                            Thread.Sleep(500);

                            // user guesses
                            Console.Write("\nGuess the location computer's ships in ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("x,y ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("format.\n\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            string userguess = Console.ReadLine();

                            // split the user guess into an array
                            string[] userguessarray = userguess.Split(',');

                            // make array to validate user input
                            //int[] uservalidator = {Int32.Parse(userguessarray[0]),Int32.Parse(userguessarray[1])};
                            //Console.WriteLine($"{uservalidator[0]} {uservalidator[1]}");

                            int[] userguessint = new int[2];
                            for(int i = 0; i < 2; i++) userguessint[i] = Int32.Parse(userguessarray[i]);
                            if ((userguessint[0] == computercoords1[0] && userguessint[1] == computercoords1[1]) || (userguessint[0] == computercoords2[0] && userguessint[1] == computercoords2[1]) || (userguessint[0] == computercoords3[0] && userguessint[1] == computercoords3[1]) || (userguessint[0] == computercoords4[0] && userguessint[1] == computercoords4[1]) || (userguessint[0] == computercoords5[0] && userguessint[1] == computercoords5[1]))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Hit!\n");
                                userguesses += 1;
                                Thread.Sleep(1000);
                                // re print grid with a H on the place hit
                                gridfinal[userguessint[0] - 1, userguessint[1] - 1] = "H";
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{grid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{gridfinal[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Miss!\n");

                                // re print grid with a M on the place hit
                                Thread.Sleep(500);
                                gridfinal[userguessint[0] - 1, userguessint[1] - 1] = "M";
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{grid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{gridfinal[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                            }
                            if (userguesses == 5)
                            {
                                Console.WriteLine("You found all the computer's ships and won!");
                                gamedone = true;
                            }
                        } while (!gamedone);

                        // computer guesses


                        break;
                    case "2":
                        Console.WriteLine("in progress");
                        break;

                    case "3":
                        Console.WriteLine("in progress");
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
                        Console.WriteLine("Please re-enter a valid choice");
                        break;
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


                static void CreateBaseGrid()
                {
                    // nested for-loop matrix for base grid 
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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

                /*static int RandomNumberExcluding(int values)
                {
                    var exclude = new HashSet<int>() { 5, 7, 1};
                    var range = Enumerable.Range(1, 8).Where(i => !exclude.Contains(i));

                    var rand = new System.Random();
                    int index = rand.Next(0, 8 - exclude.Count);
                    return range.ElementAt(index);
                }*/
            }
        }
    }
}