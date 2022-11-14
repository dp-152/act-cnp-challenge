using CnpChallenge.Domain.Interfaces.Repository;
using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CnpChallenge.Infrastructure.Repository;

public class SqlClienteRepository : IClienteRepository
{
    private readonly MainContext _context;
    
    public SqlClienteRepository(MainContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> Get(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente> Create(Cliente data)
    {
        var result =_context.Clientes.Add(data);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Cliente> Update(Cliente data)
    {
        var result = _context.Clientes.Update(data);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _context.Clientes.FindAsync(id);
        if (entity is null) return false;

        var result = _context.Clientes.Remove(entity);
        await _context.SaveChangesAsync();

        return result.State == EntityState.Deleted;
    }

    private async Task<bool> SaveChanges()
    {
        return (await _context.SaveChangesAsync()) >= 0;
    }
} 