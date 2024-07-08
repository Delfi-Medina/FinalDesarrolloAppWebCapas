using Gastos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Gastos.Datos
{
    public class GastoRepository : IGastoRepository
    { 
        private readonly ApplicationDbContext _context;

    public GastoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Gasto>> GetAllGastosAsync()
    {
        return await _context.Gastos.ToListAsync();
    }

    public async Task<Gasto> GetGastoByIdAsync(int id)
    {
        return await _context.Gastos.FindAsync(id);
    }

    public async Task AddGastoAsync(Gasto gasto)
    {
        await _context.Gastos.AddAsync(gasto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGastoAsync(Gasto gasto)
    {
        _context.Gastos.Update(gasto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGastoAsync(int id)
    {
        var gasto = await _context.Gastos.FindAsync(id);
        if (gasto != null)
        {
            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
        }
    }
    }
}
