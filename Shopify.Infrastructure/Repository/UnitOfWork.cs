using Supliex.Infrastructure.Data;
using Supliex.Infrastructure.Repository.IRepository;
using System.Threading.Tasks;

namespace Supliex.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        //public ITestRepository Test { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            //Test=new TestRepository(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
