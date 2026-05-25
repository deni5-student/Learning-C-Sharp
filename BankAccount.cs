using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learning_C_Sharp
{
    public class BankAccount
    {
        /*  kan det passe at BankAccount klassen er encapsuleret fra programmet
         *  
            Ja, det passer! Din BankAccount klasse er godt encapsuleret fordi:

            balance er private — Program.cs kan ikke læse eller ændre den direkte
            GetBalance() er den eneste måde at se saldoen udefra
            Deposit() og Withdraw() kontrollerer al logik og validering selv
            Så Program.cs kan ikke gøre noget som klassen ikke tillader. Det er præcis formålet med encapsulation.
        */

        private decimal balance;

        public BankAccount ()
        {
            Deposit(100);
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");

            }
            this.balance += amount;

        }

        public decimal GetBalance()
        {
            return balance;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }
            this.balance -= amount;
        }
    }
}
