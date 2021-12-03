namespace TriMania.Infra.Database.Repository.Base
{
    public class PaginationInfo
    {
        public PaginationInfo(int actualPage, int count, int totalInPage)
        {
            Count = count;
            ActualPage = actualPage;
            TotalInPage = totalInPage;
        }

        public int TotalInPage { get; }
        public int Count { get; }
        public int ActualPage { get; }
    }
}