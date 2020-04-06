using System;
using System.Collections.Generic;
using System.Text;
using BankSystem_exceptions.Entities.Exceptions;
namespace BankSystem_exceptions.Entities
{
    class SavingsAccount : Account
    {
        public double WithdrawFee = 2.50;

        //constructor
        public SavingsAccount(int number, string holder, double balance, double withdrawLimit) : base(number, holder, balance, withdrawLimit)
        {

        }

        //methods
        public override void Deposit(double amount)
        {
                base.Deposit(amount);
        }
        public override void Withdraw(double amount)
        {
            double totalValue = amount + WithdrawFee;   //SOMANDO O VALOR DO SAQUE E DA TAXA DE SAQUE
            if(totalValue > Balance)                    //SE MAIOR QUE O SALDO, REPETE O AVISO DE SALDO INSUFICIENTE 
            {
                throw new DomainException("Not enough balance.");
            }

                base.Withdraw(amount);
           
            
        }




    }

    
    




}
