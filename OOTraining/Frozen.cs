using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidBranching
{
    class Frozen : IAccountState 
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action substractFromBalance)
        {
            this.OnUnfreeze();
            substractFromBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState Close() => new Closed();

        public IAccountState HolderVerified() => this;
            
    }
}
