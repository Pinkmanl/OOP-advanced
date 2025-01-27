using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BankApp.Classes
{
    public class Customer
    {
        private long accountNumber;
        public string Name { get; set; }
        public long AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public decimal Balance { get; set; } = 0M;
        public Customer()
        {
            System.Console.Write("Mijoz ismini kiriting :");
            Name = Console.ReadLine() ?? " ";
            CreateAccount();
        }
        //Pul qo'yish
        public bool Deposit(decimal amount)
        {
            if (IsActiveAccount() && amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        //Pul yechish
        public bool Withdrawal(decimal amount)
        {

            if (!IsActiveAccount() || amount < 0 || Balance < amount)
            {
                System.Console.WriteLine("Withdrawal");
                return false;
            }
            Balance -= amount;
            return true;
        }

        public void CloseAccount()
        {
            accountNumber = 0;
        }
        private bool IsActiveAccount()
        {
            if (AccountNumber > 0)
            {
                return true;
            }
            System.Console.WriteLine("Account closed");
            return false;
        }

        public bool CreateAccount()
        {
            if (AccountNumber > 0)
            {
                System.Console.WriteLine("Accont already created");
                return false;
            }
            System.Console.WriteLine($"{Name} uchun hisob raqamni kiriting");
            accountNumber = Convert.ToInt64(Console.ReadLine() ?? "0");
            return true;
        }
    }
}