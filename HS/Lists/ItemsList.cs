namespace HS.Lists
{
    using HS.Filters;
    using HS.Sorting;
    using HS.Paging;
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
                    listWithMofifiersApplied = ApplyFiltering(listWithMofifiersApplied);
                }
                    
                if (SortModifiers != null)
                {
                    listWithMofifiersApplied = ApplySorting(listWithMofifiersApplied);
                } 

                return listWithMofifiersApplied.Skip(Pager.SkipItems).Take(Pager.ItemsPerPage);
            }
        }        

        public int Count 
        { 
            get 
            {
                return items.Count();
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

        public IPageable Pager { get; set; }

        public ItemsList(IEnumerable<TEntity> listOfItems, IPageable pager)
        {
            if (listOfItems == null)
            {
                throw new ArgumentNullException("The colection passed to the ctor of " + this.GetType() + " should not be null!");
            }

            items = listOfItems;
            Pager = pager;
        }

        public ItemsList(IEnumerable<TEntity> listOfItems,
            IPageable pagingPolicy,
            IEnumerable<IFilter<TEntity>> filters,
            IEnumerable<ISortModifier<TEntity>> sorters) : this (listOfItems, pagingPolicy)
        {
            Filters = filters;
            SortModifiers = sorters;
        }

        private IEnumerable<TEntity> ApplyFiltering(IEnumerable<TEntity> listWithMofifiersApplied)
        {
            var predicates = new List<Func<TEntity, bool>>();

            foreach (var filter in Filters)
            {
                predicates.Add(filter.Apply());
            }

            return listWithMofifiersApplied.Where(p => predicates.All(f => f(p)));
        }

        private IOrderedEnumerable<TEntity> ApplySorting(IEnumerable<TEntity> listWithMofifiersApplied) {
            var sortByFirstCriterion = SortModifiers.First();
            IOrderedEnumerable<TEntity> sortedList;

            if (sortByFirstCriterion.Asc)
            {
                sortedList = listWithMofifiersApplied.OrderBy(sortByFirstCriterion.SortByExpression);
            }
            else
            {
                sortedList = listWithMofifiersApplied.OrderByDescending(sortByFirstCriterion.SortByExpression);
            }

            var sortByAddtionalCriteria = SortModifiers.Skip(1); // Sort by more than one column => loop trough all the rest columns

            foreach (var sortMod in sortByAddtionalCriteria)
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
