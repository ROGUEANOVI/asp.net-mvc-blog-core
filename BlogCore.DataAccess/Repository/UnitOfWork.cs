using BlogCore.DataAccess.Repository.IRepository;
using BlogCore.Web.Data;

namespace BlogCore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // public IEntityRepository Entity { get; private set; }
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            // Entity = new EntityRepository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
