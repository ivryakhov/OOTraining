﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidBranching
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Close()
        {
            return new Closed();
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action substractFromBalance)
        {
            return this; 
        }

        public IAccountState HolderVerified()
        {
            return new Active(this.OnUnfreeze);
        }
    }
}
