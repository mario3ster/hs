namespace HS.Paging
{
    public interface IPageable
    {
        byte ItemsPerPage { get; set; }

        int TotalPagesCount { get; }

        byte CurrentPage { get; set; }

        int SkipItems { get; }
    }
}
