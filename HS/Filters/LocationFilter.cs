using HS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Filters
{
	public class LocationFilter : Filter<string>, IFilter<Boat>
	{
		public Func<Boat, bool> Apply()
		{
            return x => x.Location == base.SelectedValue;
		}

		public LocationFilter(string value) : base(value)
		{
		}
    }
}
