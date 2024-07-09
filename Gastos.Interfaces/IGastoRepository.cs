using Gastos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gastos.Interfaces
{
    public interface IGastoRepository
    {
        Task<IEnumerable<Gasto>> ObtenerTodosLosGastos();
        Task<Gasto> ObtenerGastoPorId(int id);
        Task AgregarGasto(Gasto gasto);
        Task ActualizarGasto(Gasto gasto);
        Task EliminarGasto(int id);
    }
}
