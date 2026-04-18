using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGroundWorkerUi
{
    public class Account
    {
        private int _balance;
        private readonly object _lockObj = new object();
        public Account(int balance)
        {
            _balance = balance;
        }
        public void Deposit(int amount)
        {
            lock (_lockObj)
            {
                _balance += Math.Max(amount, 0);
            }
        }
        public void WithDraw(int amount)
        {
            lock (_lockObj)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                }
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
