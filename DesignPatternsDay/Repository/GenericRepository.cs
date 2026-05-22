
using DesignPatternsDay.Context;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsDay.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();
        }
        public void Add(T entity)=>_dbSet.Add(entity);       
        public List<T> GetAll()=>_dbSet.ToList();
        public T GetById(int id) => _dbSet.Find(id);
        public void Update(T entity)=>_dbSet.Update(entity);
        public void Delete(int id)
        {
            var entity=_dbSet.Find(id);
            if(entity !=null) _dbSet.Remove(entity);
        }
    }
}
