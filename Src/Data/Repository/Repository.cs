using System.Linq.Expressions;
using Data.Context;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class Repository : IRepository
{
    private readonly CampusContext _context;

    public Repository(CampusContext context)
    {
        _context = context;
    }

    public async Task Update<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        _context.Update(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Add<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        await _context.Set<TEntity>().AddAsync(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Delete<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        _context.Set<TEntity>().Remove(entidad);
        await _context.SaveChangesAsync();
    }

    private IQueryable<TEntity> Incluir<TEntity>(IQueryable<TEntity> consulta, string[] incluidos)
        where TEntity : EntityBase
    {
        var incluidosConsulta = consulta;

        foreach (var incluido in incluidos)
        {
            incluidosConsulta = incluidosConsulta.Include(incluido);
        }

        return incluidosConsulta;
    }

    private IQueryable<TEntity> Incluir<TEntity>(IQueryable<TEntity> consulta,
        params Expression<Func<TEntity, object>>[] includes) where TEntity : EntityBase
    {
        foreach (var include in includes)
        {
            consulta = consulta.Include(include);
        }

        return consulta;
    }

    public async Task<List<TEntity>> List<TEntity>(Expression<Func<TEntity, bool>> predicado,
        params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).Where(predicado).ToListAsync();
    }

    public async Task<List<TEntity>> ListAll<TEntity>(params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).ToListAsync();
    }

    public async Task<List<TEntity>> ListAllWith<TEntity>(params Expression<Func<TEntity, object>>[] includes)
        where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), includes).ToListAsync();
    }

    public async Task<TEntity?> GetTheFirstOne<TEntity>(Expression<Func<TEntity, bool>> predicado,
        params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).FirstOrDefaultAsync(predicado);
    }

    public async Task<TEntity?> GetForId<TEntity>(Guid id, params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> GetForIdWith<TEntity>(Guid id, params Expression<Func<TEntity, object>>[] includes)
        where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), includes).SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : EntityBase
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
}