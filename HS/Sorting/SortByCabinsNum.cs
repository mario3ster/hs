using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Sorting
{
    public class SortByCabinsNum : ISortModifier<Boat>
    {
        public bool Asc
        {
            get;
            set;
        }

      

        public Func<Boat, object> SortByExpression
        {
            get
            {
                return x => x.CabinsNum;
            }
           
        }
    }
}
