using System.Threading.Tasks;

namespace Supliex.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //public ITestRepository Test { get; }

        Task SaveAsync();
    }
}
