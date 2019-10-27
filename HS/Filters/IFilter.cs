using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Filters
{
	public interface IFilter<TEntity>
	{
		Func<TEntity, bool> Apply();
	}
}
