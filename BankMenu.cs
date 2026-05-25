using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_Sharp
{
    public class BankMenu
    {
        private BankAccount bankAccount;

        public BankMenu()
        {
            bankAccount = new BankAccount();
        }

        public void Start()
        {
            /*
            menu.Start(); bliver kaldt i program.cs
            hvor så Start() bliver initialiseret
                ↓
            while (kørende = true)
                ↓
            ShowMenu() viser menuen
                ↓
            Bruger vælger et tal
                ↓
            switch håndterer valget
                ↓
            tilbage til toppen af while
                ↓
            ShowMenu() vises igen
                ↓
            ... fortsætter indtil kørende = false
            */

            bool kørende = true;

            while (kørende)
            {
                ShowMenu();
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        Deposit();
                        break;
                    case "2":
                        Withdraw();
                        break;
                    case "3":
                        Console.WriteLine($"Balance: {bankAccount.GetBalance():C}");
                        Console.ReadLine();
                        break;
                    case "4":
                        kørende = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== BANK SYSTEM ===");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdraw");
            Console.WriteLine("3 - Check Balance");
            Console.WriteLine("4 - Exit");
        }

        private void Deposit()
        {
            Console.WriteLine("Enter the amount to deposit:");
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
            {
                try
                {
                    bankAccount.Deposit(depositAmount);
                    Console.WriteLine("✓ Deposit completed.");
                    Thread.Sleep(1000);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ReadLine();
                }
            }
        }

        private void Withdraw()
        {
            Console.WriteLine("Enter the amount to withdraw:");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                try
                {
                    bankAccount.Withdraw(amount);
                    Console.WriteLine("✓ Withdrawal completed.");
                    Thread.Sleep(1000);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Fejl: {e.Message}");
                    Console.ReadLine();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Fejl: {e.Message}");
                    Console.ReadLine();
                }
            }
        }
    }
}
