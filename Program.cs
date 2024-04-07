using System;
using static System.Console;
using System.IO;

namespace CryptKeeper
{
    class Program
    {
        protected bool Esc { get; set; } = false;
        protected bool IsEncrypted { get; set; }
        protected bool IsDecrypted { get; set; }

        public void Introduction()
        {
            WriteLine($"This program will encrypt a file and save it to a specified location.\nIf you would like to encrypt");
            Write($" a file you may begin typing, otherwise you may press 'Esc' to return to Exit.\n\n");
            if (KeyAvailable)
            {
                ConsoleKeyInfo cki = ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
            else
                WriteLine("Please enter the name of the file you would like to encrypt: ");
            string path = ReadLine()!;
            if (string.IsNullOrEmpty(path))
            {
                WriteLine("I do not recognize that path as a valid file name, Would you like to try again?");
                return;
            }
            else if (path == "Esc")
            {
                WriteLine("Returning to the Main Menu..");
                return;
            }
            else if (IsEncrypted)
            {
                WriteLine("This file has already been encrypted, would you like to decrypt it?");
                return;
            }
            else Crypt.Encrypt(path);
        }

        internal static void About()
        {
            throw new NotImplementedException();
        }

        static void Main(string[,] args)
        {
            Clear();
            ResetColor();
            ForegroundColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.DarkGreen;

            Program program = new Program();
            program.Introduction();

        }
    }
}