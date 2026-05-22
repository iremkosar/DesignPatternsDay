using DesignPatternsDay.Context;
using DesignPatternsDay.Repository;

namespace DesignPatternsDay.Patterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }
        
        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IGenericRepository<T>)_repositories[typeof(T)];

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
        public int Commit() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
