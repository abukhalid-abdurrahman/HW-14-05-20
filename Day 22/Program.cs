using System;
using System.Collections.Generic;

namespace Day_22
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = string.Empty;
            string menu = "1. Create(Add New Record)\n2. Read(Show Records)\n3. Update(Edit Record)\n4. Delete(Remove Record)";
            Models.AccountRepository accountRep = new Models.AccountRepository();
            while (cmd != "0")
            {
                Console.WriteLine(menu);
                Console.Write("Input: ");
                cmd = Console.ReadLine();
                if(cmd == "1")
                {
                    Console.WriteLine(menu);
                    Console.Write("Input Login: ");
                    string accountLogin = Console.ReadLine();
                    Console.Write("Input Name: ");
                    string accountName = Console.ReadLine();
                    Console.Write("Input Surname: ");
                    string accountSurname = Console.ReadLine();
                    Models.Account account = new Models.Account();
                    account.Login = accountLogin;
                    account.Name = accountName;
                    account.Surname = accountSurname;
                    accountRep.Create(account);
                }
                if (cmd == "2")
                {
                    List<Models.Account> accounts = new List<Models.Account>();
                    accounts = accountRep.Read();
                    foreach (Models.Account it in accounts)
                    {
                        Console.WriteLine("ID: " + it.Id);
                        Console.WriteLine("Login: " + it.Login);
                        Console.WriteLine("Name: " + it.Name);
                        Console.WriteLine("Surname: " + it.Surname);
                    }
                }
                if (cmd == "3")
                {
                    Console.WriteLine(menu);
                    Console.Write("Input ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Input Login: ");
                    string accountLogin = Console.ReadLine();
                    Console.Write("Input Name: ");
                    string accountName = Console.ReadLine();
                    Console.Write("Input Surname: ");
                    string accountSurname = Console.ReadLine();
                    Models.Account account = new Models.Account();
                    account.Id = int.Parse(id);
                    account.Login = accountLogin;
                    account.Name = accountName;
                    account.Surname = accountSurname;
                    accountRep.Update(account);
                }
                if (cmd == "4")
                {
                    Console.Write("Input Account ID: ");
                    string id = Console.ReadLine();
                    accountRep.Delete(int.Parse(id));
                }
            }
        }
    }
}
