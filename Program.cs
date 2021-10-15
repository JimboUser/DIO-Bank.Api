using System;
using System.Collections.Generic;

namespace Bank.api
{
    class Program
    {   

        static List<Account> listAccounts = new List<Account>();

        static void Main(string[] args)
        {
            
            string userOption = GetUserOption();

            while (userOption.ToUpper() !="X")
            {
                switch(userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    
                    case "2":
                        InsertAccount();
                        break;

                    case "3":
                        Transfer();
                        break;

                    case "4":
                        Draw();
                        break;

                    case "5":
                        Deposit();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();        

                }
            
                userOption = GetUserOption(); 
            
            }   
        
            Console.WriteLine("Thank you for using our services");
            
        }

        private static void ListAccounts()
        {
            
            Console.WriteLine("List Accounts");

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("No account registered.");
                return;
            }

            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccount()
        {
            
            Console.WriteLine("Insert new account");

            Console.WriteLine("Type 1 for Natural Person or 2 for Legal Entity: ");
            int entryAccountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Type in the name: ");
            string entryClientName = Console.ReadLine();

            Console.WriteLine("Type in the initial balance: ");
            double entryBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Type in the credit: ");
            double entryCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)entryAccountType,
            name: entryClientName, balance: entryBalance, credit: entryCredit);

            listAccounts.Add(newAccount);
        
        }

        private static void Transfer()
        {
            
            Console.WriteLine("Enter the Origin Account Number: ");
            int IndexOriginAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Destination Account Number");
            int IndexDestinationAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the desired value: ");
            double ValueTransfer = double.Parse(Console.ReadLine());

            listAccounts[IndexOriginAccount].Transfer(ValueTransfer, listAccounts[IndexDestinationAccount]);

        }

        private static void Draw()
        {

            Console.WriteLine("Enter the Account Number: ");
            int AccNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the desired value: ");
            double ValueDraw = double.Parse(Console.ReadLine());

            listAccounts[AccNum].Draw(ValueDraw);
        }

        private static void Deposit()
        {

            Console.WriteLine("Enter the Account Number: ");
            int AccNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the desired value");
            double ValueDeposit = double.Parse(Console.ReadLine());

            listAccounts[AccNum].Deposit(ValueDeposit);
            
        }

        private static string GetUserOption()
        {
            
            Console.WriteLine();
            Console.WriteLine("Welcome");
            Console.WriteLine("Select the desired option");

            Console.WriteLine("1. List accounts");
            Console.WriteLine("2. Insert new account");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Draw");
            Console.WriteLine("5. Deposit");
            Console.WriteLine("C. Clean screen");
            Console.WriteLine("X. Quit");
            Console.WriteLine();

            string UserOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return UserOption;

        }
    }
}
