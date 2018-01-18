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
        
        private Action OnUnfreeze { get; }
        private Action ManagedUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;

            this.ManagedUnfreezing = this.StayUnfrozen;
        }
        
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            this.ManagedUnfreezing();
            this.Balance += amount;
        }

        private void Unfreeze()
        {
            this.OnUnfreeze();
            this.ManagedUnfreezing = this.StayUnfrozen;
        }

        private void StayUnfrozen() { }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;
            if (this.IsClosed)
                return;
            ManagedUnfreezing();
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
            this.ManagedUnfreezing = this.Unfreeze;
        }
    }
}
