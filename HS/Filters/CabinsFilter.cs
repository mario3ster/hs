
using HS.Models;
using System;

namespace HS.Filters
{
	public class CabinsFilter : Filter<byte>, IFilter<Boat>
	{
        //public byte SelectedValue { get; set; }

        public Func<Boat, bool> Apply()
		{
            return x => x.CabinsNum == base.SelectedValue;
		}

        public CabinsFilter(byte value) : base (value)
        {
        }
	}
}
