
using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Filters
{
	public class HullTypeFilter : Filter<HullType>, IFilter<Boat>
	{
		public Func<Boat, bool> Apply()
		{
            return x => x.HullType == base.SelectedValue;
		}

		public HullTypeFilter(HullType value) : base(value)
		{
		}
	}
}
