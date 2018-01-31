using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCaseDemo
{
    class SoldArticle
    {
        public Warranty MoneyBackGuarantee { get; }
        public Warranty ExpressWarranty { get; }

        public SolidArticle(Warranty moneyBack, Warranty express)
        {
            this.MoneyBackGuarantee = moneyBack;
            this.ExpressWarranty = express;
        }
    }
}
