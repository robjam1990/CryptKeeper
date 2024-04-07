using static System.Console;

namespace CryptKeeper
{
    internal class Menu
    {
        public bool Esc { get; protected set; } = false;
        public bool IsEncrypted { get; protected set; }
        public bool IsDecrypted { get; protected set; }

        public Menu(bool IsEncrypted, bool IsDecrypted)
        {
            IsEncrypted = !IsDecrypted;
            IsDecrypted = !IsEncrypted;
        }

        public static void MainMenu()
        {
            WriteLine("Main Menu\n\n1. Visit the Crypt\n2. Decrypt a file\n3. Exit");
            Write("Please select an option: ");
            string option = ReadLine()!;
            switch (option)
            {
                case "1":
                    CryptMenu();
                    break;
                case "2":
                    Program.About();
                    break;
                case "3":
                    ExitConfirmation();
                    WriteLine("Goodbye!");
                    break;
                default:
                    WriteLine("I'm sorry, I do not recognize that option.");
                    break;
            }
        }

        private static void CryptMenu()
        {
            WriteLine("Crypt Menu\n\n1. Encrypt a file\n2. Decrypt a file\n3. Return to Main Menu");
            Write("Please select an option: ");
            string option = ReadLine()!;
            switch (option)
            {
                case "1":
                    Crypt.Encryption();
                    break;
                case "2":
                    Crypt.Decrypt();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    WriteLine("I'm sorry, I do not recognize that option.");
                    break;
            }
        }

        private static void ExitConfirmation()
        {
            WriteLine("Are you sure you want to exit the program?\n\n1. Yes\n2. No");
            Write("Please select an option: ");
            string option = ReadLine()!;
            switch (option)
            {
                case "1":
                    Environment.Exit(0);
                    break;
                case "2":
                    MainMenu();
                    break;
                default:
                    WriteLine("I'm sorry, I do not recognize that option.");
                    break;
            }
        }
    }
}
