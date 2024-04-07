using System.IO;
using static System.Console;

namespace CryptKeeper
{

    internal class Crypt : Menu
    {
        private new bool IsEncrypted;
        private new bool IsDecrypted;
        private static string? path;

        public Crypt(bool isEncrypted, bool isDecrypted) : base(isEncrypted, isDecrypted)
        {
            IsEncrypted = isEncrypted;
            IsDecrypted = isDecrypted;
        }

        public static void Encrypt(string path)
        {
            string encryptedPath = $@"c:\crypt\{path}.enc";
            if (!File.Exists(path))
            {
                WriteLine($"Hello,\nand welcome to the world of encrypted files.\nYour file has been successfully encrypted and saved to..\n\t{encryptedPath}.");
                Encrypt(path);
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()!) != null)
                    {
                        WriteLine(s);
                    }
                    Encrypt(path);
                }
            }
        }

        public static void Decrypt()
        {
            DecryptionConfirmation();
        }

        protected static void DecryptionConfirmation()
        {
            Write("Please enter the path of the encrypted file: ");
            string path = ReadLine()!;
            if (File.Exists(path))
            {
                WriteLine("Are you sure you want to decrypt the file?\n\n1. Yes\n2. No");
                Write("Please select an option: ");
                string option = ReadLine()!;
                switch (option)
                {
                    case "1":
                        Decrypt();
                        break;
                    case "2":
                        MainMenu();
                        break;
                    default:
                        WriteLine("I'm sorry, I do not recognize that option.");
                        break;
                }
            }
            else
            {
                WriteLine("I'm sorry, I do not recognize that file.");
                return;
            }
        }

        internal static void Encryption()
        {
            Encrypt(path!);
        }
    }
}
