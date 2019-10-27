using System;

namespace HS.Sorting
{
    public interface ISortModifier<TEntity>
    {
        bool Asc { get; set; }

        Func<TEntity, object> SortByExpression { get; }
    }
}
