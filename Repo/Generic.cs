
using FinalAPISession.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalAPISession.Repo
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        //Connection
        protected AppDbContext _appDbContext;
        public Generic( AppDbContext appDbContext) { 
            _appDbContext = appDbContext;
        }

        //Add
        public virtual async Task Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            
        }

        //Delete
        public async Task<bool> Delete(int id)
        {
            var result = await _appDbContext.Set<T>().FindAsync(id);

            if (result == null)
                return false;

              _appDbContext.Set<T>().Remove(result);
              await _appDbContext.SaveChangesAsync();
              return true;

        }

        //GetAll
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }


        //Get BY ID
        public virtual async Task<T?> GetBYID(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);

        }

        //Update
        public async Task Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
