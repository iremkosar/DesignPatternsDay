using DesignPatternsDay.Repository;

namespace DesignPatternsDay.Patterns.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        int Commit();
    }
}
