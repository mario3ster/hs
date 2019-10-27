using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Filters
{
	public class SkipperPriceFilter : Filter<decimal>, IFilter<Skipper>
	{
        public Func<Skipper, bool> Apply()
		{
            return x => x.Price <= SelectedValue;
		}

		public SkipperPriceFilter(decimal value) : base(value)
		{
        }
	}
}
