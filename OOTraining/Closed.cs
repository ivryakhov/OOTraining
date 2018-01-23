﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidBranching
{
    class Closed : IAccountState
    {
        public IAccountState Close()
        {
            return this;
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            return this;
        }

        public IAccountState Withdraw(Action substractFromBalance)
        {
            return this;
        }

        public IAccountState HolderVerified()
        {
            return this;
        }
    }
}
