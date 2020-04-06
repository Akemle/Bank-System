using System;
using System.Collections.Generic;
using System.Text;
using BankSystem_exceptions.Entities.Exceptions;

namespace BankSystem_exceptions.Entities
{
    class BusinessAccount : Account
    {
        public double BankLoanLimit { get; set; }


        //constuctor
        public BusinessAccount(int number, string holder, double balance, double withdrawLimit, double bankLoanLimit) : base(number, holder, balance, withdrawLimit)
        {
            BankLoanLimit = bankLoanLimit;
        }


        //method
        public void BankLoan(double loanValue)
        {
            if(loanValue <= BankLoanLimit)
            {
                Balance += loanValue;
            }
            else
            {
                throw new DomainException("Loan limit exceeded.");
            }
        }


    }
}
