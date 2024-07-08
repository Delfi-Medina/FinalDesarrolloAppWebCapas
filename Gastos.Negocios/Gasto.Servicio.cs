using Gastos.Datos;
using Gastos.Interfaces;

namespace Gastos.Negocios
{
    public class GastoServicio
    {
        private readonly IGastoRepository _gastoRepository;

        public GastoServicio (IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }
        public async Task<IEnumerable<Gasto>> ObtenerTodosLosGastosAsync()
        {
            return await _gastoRepository.GetAllGastosAsync();
        }

        public async Task<Gasto> ObtenerGastoPorIdAsync(int id)
        {
            return await _gastoRepository.GetGastoByIdAsync(id);
        }

        public async Task AgregarGastoAsync(Gasto gasto)
        {
            await _gastoRepository.AddGastoAsync(gasto);
        }

        public async Task ActualizarGastoAsync(Gasto gasto)
        {
            await _gastoRepository.UpdateGastoAsync(gasto);
        }

        public async Task EliminarGastoAsync(int id)
        {
            await _gastoRepository.DeleteGastoAsync(id);
        }
    }
}

