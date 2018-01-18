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
        
        private IFreezable Freezable { get; set; }

        public Account(Action onUnfreeze)
        {
            this.Freezable = new Active(onUnfreeze);
        }
        
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            this.Freezable = this.Freezable.Deposit();
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;
            if (this.IsClosed)
                return;
            this.Freezable = this.Freezable.Withdraw();
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
            this.Freezable = this.Freezable.Freeze();
        }
    }
}
