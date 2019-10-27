using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Filters
{
	public class SkipperExprFilter : Filter<int>, IFilter<Skipper>
	{
		

		public Func<Skipper, bool> Apply()
		{
            return x => x.Expirience >= base.SelectedValue;
		}

		public SkipperExprFilter(int value) : base (value)
		{
		}
	}
}
