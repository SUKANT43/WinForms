using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationWithThreadSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(10000);
            BankAccount account2 = new BankAccount(20000);
            Parallel.For(0, 10, i =>
            {
                account1.Deposit(100);
                account1.WithDraw(50);

                account2.Deposit(100);
                account2.WithDraw(50);

            });
            Console.WriteLine($"\nFinal Balance: {account1.GetBalance()}");
            Console.ReadLine();

        }
    }

    public class BankAccount
    {
        private int _balance;
        private readonly object _lockObj = new object();

        public BankAccount(int balance)
        {
            _balance = balance;
        }

        public void WithDraw(int amount)
        {
            lock (_lockObj)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdrawn {amount}, Balance: {_balance}");
                }
                else
                {
                    Console.WriteLine($"Insufficient balance for {amount}, Balance: {_balance}");
                }
            }
        }

        public void Deposit(int amount)
        {
            lock (_lockObj)
            {
                _balance += Math.Max(0, amount);
                Console.WriteLine($"Deposited {amount}, Balance: {_balance}");
            }
        }

        public int GetBalance()
        {
            lock (_lockObj)
            {
                return _balance;
            }
        }

    }
}
