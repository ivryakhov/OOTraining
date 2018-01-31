﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCaseDemo
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article,
                                  bool isInGoodCondition,
                                  bool isBroken)
        {
            DateTime now = DateTime.Now;

            if (isInGoodCondition && !isBroken &&
                article.MoneyBackGuarantee != null &&
                article.MoneyBackGuarantee.IsValidatiOn(now))
            {
                Console.WriteLine("Offer money back.");
            }

            if (isBroken && article.ExpressWarranty != null &&
                article.ExpressWarranty.IsValidatiOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
 