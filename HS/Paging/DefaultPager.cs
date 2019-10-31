namespace HS.Paging
{
    using System;

    public class DefaultPager : IPageable
    {
        private byte currentPage = 1;

        private int totalItemsCount;

        private const byte MAX_ITEMS_PER_PAGE = 255;

        private byte itemsPerPage;

        public byte ItemsPerPage
        {
            get
            {
                return itemsPerPage;
            }
            set
            {
                if (value > MAX_ITEMS_PER_PAGE)
                {
                    throw new ArgumentOutOfRangeException("Max items per page: " + MAX_ITEMS_PER_PAGE + ". It was passed: " + value);
                }

                itemsPerPage = value;
            }
        }

        public byte CurrentPage 
        { 
            get
            {
                return currentPage;
            }
            set 
            {
                if(value > 0 && value <= TotalPagesCount) 
                {
                    currentPage = value;
                }       
            }
        }

        public int TotalPagesCount
        {
            get
            {
                return totalItemsCount / ItemsPerPage;
            }
        }

        public int SkipItems 
        {
            get 
            {
                return (CurrentPage - 1) * ItemsPerPage;                
            }
        }

        public DefaultPager(byte itemsPerPage, int totalItemsCount)
        {
            this.totalItemsCount = totalItemsCount;
            ItemsPerPage = itemsPerPage;
        }
    }
}