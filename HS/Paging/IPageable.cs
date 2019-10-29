namespace HS.Paging
{
    public interface IPageable
    {
        byte ItemsPerPage { get; set; }

        byte CurrentPage { get; }

        int SkipItems { get; }

        void GoNextPage();

        void GoPrevPage();
    }
}
