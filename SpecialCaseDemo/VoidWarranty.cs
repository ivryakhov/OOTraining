using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCaseDemo
{
    class VoidWarranty : IWarranty
    {
        [ThreadStatic]
        private static VoidWarranty instance;

        private VoidWarranty() { }

        public static VoidWarranty Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }

        public bool IsValidOn(DateTime date) => false;
    }
}
