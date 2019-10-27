using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Filters
{
    public abstract class Filter<TValue>
    {
        public TValue SelectedValue { get; set; }

        protected Filter(TValue value)
        {
            SelectedValue = value;
        }
    }
}
