using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Sorting
{
	public class SortByRating : ISortModifier<Skipper>
	{
        public bool Asc
        {
            get;
            set;
        }

        public Func<Skipper, object> SortByExpression => x => x.Rating;

    }
}
