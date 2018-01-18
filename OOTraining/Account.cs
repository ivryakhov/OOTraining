using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTraining
{
    class Account
    {
        public decimal Balance { get; private set; }

        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;
            if (this.IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            this.Balance -= amount;

        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    }
}
