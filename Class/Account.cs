using System;

namespace Bank.api
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        

        public Account (AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Draw (double Drawvalue)
        {
            if (this.Balance - Drawvalue < (this.Credit *-1))
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }

            this.Balance -= Drawvalue;

            Console.WriteLine ("{0} your current balance is {1}", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double Depositvalue)
        {
            this.Balance += Depositvalue;

            Console.WriteLine("{0} your current balance is {1}", this.Name, this.Balance);
        }

        public void Transfer(double Transfervalue, Account destinationAccount)
        { 
            if (this.Draw(Transfervalue))
            {
                destinationAccount.Deposit(Transfervalue);
            }
        }

        public override string ToString()
        {
            string back = "";
            back += "Account Type " + this.AccountType + " / ";
            back += "Name " + this.Name + " / ";
            back += "Balance " + this.Balance + " / ";
            back += "Credit " + this.Credit + " / ";

            return back;
        }
    }
}