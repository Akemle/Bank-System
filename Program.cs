using System;
using BankSystem_exceptions.Entities.Exceptions;
using BankSystem_exceptions.Entities;
using BankSystem_exceptions.Extensions;
namespace BankSystem_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();

            Console.WriteLine("Enter account data: ");
            Console.WriteLine("Account type ( a = Account , b = Business Account or s = Savings Account)");
            char accountType = char.Parse(Console.ReadLine());
            Console.WriteLine("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Holder: ");
            string holder = Console.ReadLine();
            Console.WriteLine("Initial balance: ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of withdraw: dd/mm/yyyy hh:mm:ss");
            dateTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (accountType == 'a')
            {
                Account account = new Account(number, holder, balance, withdrawLimit);
                try
                {
                    account.Withdraw(amount);
                    Console.WriteLine("Updated balance:" + account.Balance);
                }
                catch (DomainException domEx)
                {
                    Console.WriteLine("Error in Account: " + domEx.Message);
                }
            }
            else if (accountType == 'b')
            {
                Console.WriteLine("Digite o limite de emprestimo bancario:");
                double bankLoanLimit = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor do emprestimo:");
                double loanValue = double.Parse(Console.ReadLine());

                BusinessAccount busAccount = new BusinessAccount(number, holder, balance, withdrawLimit, bankLoanLimit);
                try
                {
                    busAccount.Withdraw(amount);
                    Console.WriteLine("Updated balance:" + busAccount.Balance);
                    busAccount.BankLoan(loanValue);
                }
                catch (DomainException domEx)
                {
                    Console.WriteLine("Error in Account: " + domEx.Message);
                }
            }
            else if (accountType == 's')
            {
                SavingsAccount savAccount = new SavingsAccount(number, holder, balance, withdrawLimit);
                try
                {
                    savAccount.Withdraw(amount);
                    Console.WriteLine("Updated balance: " + savAccount.Balance);

                }
                catch (DomainException domEx)
                {
                    Console.WriteLine("Error in Account: " + domEx.Message);
                }
            }


            try
            {
                Console.WriteLine(dateTime.ElapsedTime());
            }
            catch (DomainException domEx)
            {
                Console.WriteLine("Error in Account: " + domEx.Message);
            }



        }
    }
}




