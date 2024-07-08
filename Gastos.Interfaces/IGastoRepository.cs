using Gastos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gastos.Interfaces
{
    public interface IGastoRepository
    {
        Task<IEnumerable<Gasto>> GetAllGastosAsync();
        Task<Gasto> GetGastoByIdAsync(int id);
        Task AddGastoAsync(Gasto gasto);
        Task UpdateGastoAsync(Gasto gasto);
        Task DeleteGastoAsync(int id);
    }
}
