namespace HS.Paging
{
    public interface IPageable
    {
        byte ItemsPerPage { get; set; }

        int TotalPagesCount { get; }

        byte CurrentPage { get; }

        int SkipItems { get; }

        void GoNextPage();

        void GoPrevPage();
    }
}
