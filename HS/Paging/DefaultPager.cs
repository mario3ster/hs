namespace HS.Paging
{
    using System;

    public class DefaultPager : IPageable
    {
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

        public byte CurrentPage { get; private set; }

        public int SkipItems 
        {
            get 
            {
                return (CurrentPage - 1) * ItemsPerPage;                
            }
        }

        public DefaultPager(byte itemsPerPage)
        {
            ItemsPerPage = itemsPerPage;
            CurrentPage = 1;
        }

        public void GoPrevPage() 
        {
            CurrentPage--;
        }

        public void GoNextPage() 
        {
            CurrentPage++;
        }
    }
}
