using System;
using System.Collections.Generic;
using BankApp.Classes;

namespace BankApp.Classes
{
    class Program
    {
        private static List<Customer> customers = new();

        static void Main()
        {
          
            customers.Add(new Customer());
            customers.Add(new Customer());

            int buyruq = 0;
            do
            {
                System.Console.WriteLine("1. Hisobni to'ldirish");
                System.Console.WriteLine("2. Pul yechib olish");
                System.Console.WriteLine("3. Balansni chiqarish");
                System.Console.WriteLine("4. Transer");
                System.Console.WriteLine("5. Dasturni tugatish");

                buyruq = Convert.ToInt32(Console.ReadLine());

                switch (buyruq)
                {
                    // Depazit qo'yish
                    case 1:
                        System.Console.WriteLine("Qaysi hisob raqam bilan ishlaysiz?");
                        System.Console.WriteLine("1. 1-hisob, 2. 2-hisob");
                        int buyruq2 = Convert.ToInt32(Console.ReadLine());
                        if (buyruq2 == 1)
                        {
                            System.Console.WriteLine("Qancha pul kiritasiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            customers[0].Deposit(miqdor);
                            System.Console.WriteLine($"Yangi Balance: {customers[0].AccountNumber} {customers[0].Name}, {customers[0].Balance}");
                        }
                        else if (buyruq2 == 2)
                        {
                            System.Console.WriteLine("Qancha pul kiritasiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            customers[1].Deposit(miqdor);
                            System.Console.WriteLine($"Yangi Balance: {customers[1].AccountNumber} {customers[1].Name}, {customers[1].Balance}");
                        }
                        break;

                    // Pul yechish
                    case 2:
                        System.Console.WriteLine("Qaysi hisob raqam bilan ishlaysiz?");
                        System.Console.WriteLine("1. 1-hisob, 2. 2-hisob");
                        int buyruq3 = Convert.ToInt32(Console.ReadLine());
                        if (buyruq3 == 1)
                        {
                            System.Console.WriteLine("Qancha pul yechsiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            customers[0].Withdrawal(miqdor);
                            System.Console.WriteLine($"Yengi Balance: {customers[0].AccountNumber} {customers[0].Name}, {customers[0].Balance}");
                        }
                        else if (buyruq3 == 2)
                        {
                            System.Console.WriteLine("Qancha pul yechsiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            customers[1].Withdrawal(miqdor);
                            System.Console.WriteLine($"Yengi Balance: {customers[1].AccountNumber} {customers[1].Name}, {customers[1].Balance}");
                        }
                        break;

                    // Balansni chiqarish
                    case 3:
                        System.Console.WriteLine($"{customers[0].Name}, {customers[0].AccountNumber}, {customers[0].Balance}");
                        System.Console.WriteLine($"{customers[1].Name}, {customers[1].AccountNumber}, {customers[1].Balance}");
                        break;

                    // Transer
                    case 4:
                        System.Console.WriteLine("Qaysi hisob raqam bilan ishlaysiz?");
                        System.Console.WriteLine("1. 1-hisob, 2. 2-hisob");
                        int buyruq4 = Convert.ToInt32(Console.ReadLine());
                        if (buyruq4 == 1)
                        {
                            System.Console.WriteLine("Qancha pul o'tkazasiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            Transer(customers[0].AccountNumber, customers[1].AccountNumber, miqdor);
                        }
                        else if (buyruq4 == 2)
                        {
                            System.Console.WriteLine("Qancha pul o'tkazasiz?");
                            decimal miqdor = Convert.ToDecimal(Console.ReadLine());
                            Transer(customers[1].AccountNumber, customers[0].AccountNumber, miqdor);
                        }
                        System.Console.WriteLine($"{customers[0].Name}, {customers[0].AccountNumber}, {customers[0].Balance}");
                        System.Console.WriteLine($"{customers[1].Name}, {customers[1].AccountNumber}, {customers[1].Balance}");
                        break;

                    // Dasturni tugatish
                    case 5:
                        break;

                    default:
                        System.Console.WriteLine("Noto'g'ri buyruq!");
                        break;
                }
            } while (buyruq != 5);
        }

        public static bool Transer(long fromAccount, long toAccount, decimal amount)
        {
            Customer? fromCustomer = FindByAccount(fromAccount);
            Customer? toCustomer = FindByAccount(toAccount);

            if (fromCustomer is null || toCustomer is null)
            {
                return false;
            }

            if (fromCustomer.Withdrawal(amount))
            {
                bool completed = toCustomer.Deposit(amount);
                if (!completed) fromCustomer.Deposit(amount); 
                return completed;
            }
            return false;
        }

        private static Customer? FindByAccount(long accountNumber)
        {
            foreach (Customer item in customers)
            {
                if (item.AccountNumber == accountNumber)
                    return item;
            }
            System.Console.WriteLine($"Customer with account={accountNumber} not found");
            return null;
        }
    }
}
