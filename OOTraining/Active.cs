using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidBranching
{
    class Active : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action substractFromBalance)
        {
            substractFromBalance();
            return this;
        }

        public IAccountState Freeze()
        {
            return new Frozen(this.OnUnfreeze);
        }

        public IAccountState Close()
        {
            return new Closed();
        }

        public IAccountState HolderVerified() => this;
    }
}
