namespace BlogCore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // IEntityRepository Entity { get; }
         ICategoryRepository Category { get; }

        Task Save();
    }
}
