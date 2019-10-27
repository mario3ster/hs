namespace HS.Lists
{
    using HS.Filters;
    using HS.Sorting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemsList<TEntity>
	{
        private IEnumerable<TEntity> items;

        public IEnumerable<TEntity> Items
        {
            get
            {
                IEnumerable<TEntity> listWithMofifiersApplied = items;

                if (Filters != null)
                {
                    listWithMofifiersApplied = ApplyFilters(listWithMofifiersApplied);
                }
                    
                if (SortModifiers != null)
                {
                    listWithMofifiersApplied = ApplySorting(listWithMofifiersApplied);
                } 

                return listWithMofifiersApplied;
            }
        }

        public IEnumerable<IFilter<TEntity>> Filters
		{
            get;
            set;
		}

		public IEnumerable<ISortModifier<TEntity>> SortModifiers
		{
            get;
            set;
		}

        public ItemsList(IEnumerable<TEntity> items,
           IEnumerable<IFilter<TEntity>> filters = null,
           IEnumerable<ISortModifier<TEntity>> sorters = null)
        {
            if (items == null)
            {
                throw new ArgumentNullException("The colection of items should not be null!");
            }

            this.items = items;
            Filters = filters;
            SortModifiers = sorters;
        }

        private IEnumerable<TEntity> ApplyFilters(IEnumerable<TEntity> listWithMofifiersApplied)
        {
            var predicates = new List<Func<TEntity, bool>>();

            foreach (var filter in Filters)
            {
                predicates.Add(filter.Apply());
            }

            return listWithMofifiersApplied.Where(p => predicates.All(f => f(p)));
        }

        private IOrderedEnumerable<TEntity> ApplySorting(IEnumerable<TEntity> listWithMofifiersApplied) {


            var firstSort = SortModifiers.First();
            IOrderedEnumerable<TEntity> sortedList;

            if (firstSort.Asc)
            {
                sortedList = listWithMofifiersApplied.OrderBy(firstSort.SortByExpression);
            }
            else
            {
                sortedList = listWithMofifiersApplied.OrderByDescending(firstSort.SortByExpression);
            }

            var additionalSortModifiers = SortModifiers.Skip(1); // Sort by more than one column

            foreach (var sortMod in additionalSortModifiers)
            {
                if (sortMod.Asc)
                {
                    sortedList = sortedList.ThenBy(sortMod.SortByExpression);
                }
                else
                {
                    sortedList = sortedList.ThenByDescending(sortMod.SortByExpression);
                }
            }

            return sortedList;
        }
    }
}
