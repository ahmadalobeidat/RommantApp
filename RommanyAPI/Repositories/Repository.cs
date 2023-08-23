using Microsoft.EntityFrameworkCore;
using RommanyAPI.Store;

namespace RommanyAPI;

public class Repository<T> : IRepository<T> where T : class
{
    public RommanyDBContext _dbContext { get; }
    public Repository(RommanyDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id) ?? throw new Exception("entity not found");
        return entity;
    }

    public async Task<T> Add(T entity)
    {
        if(entity is null) throw new Exception("entity can not be null");
        await _dbContext.Set<T>().AddAsync(entity); 
        await _dbContext.SaveChangesAsync();
        return entity;  
    }

    public async Task<T> Update(T entity)
    {
        if(entity is null) throw new Exception("entity can not be null");
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity; 
    }

    public async Task Delete(int id)
    {
        if(id <= 0 ) throw new Exception("id can not be less than zero");
        var entity = await GetById(id) ?? throw new Exception("entity not found");
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync ();
    }
}
