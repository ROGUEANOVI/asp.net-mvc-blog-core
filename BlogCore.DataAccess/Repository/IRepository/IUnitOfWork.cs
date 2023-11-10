namespace BlogCore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // IEntityRepository Entity { get; }
        void save();
    }
}
