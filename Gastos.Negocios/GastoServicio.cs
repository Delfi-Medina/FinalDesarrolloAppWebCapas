using Gastos.Interfaces;
using Gastos.Modelos;


namespace Gastos.Negocios
{
    public class GastoServicio
    {
        private readonly IGastoRepository _gastoRepository;

        public GastoServicio(IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<IEnumerable<Gasto>> ObtenerTodosLosGastos()
        {
            return await _gastoRepository.ObtenerTodosLosGastos();
        }

        public async Task<Gasto> ObtenerGastoPorId(int id)
        {
            return await _gastoRepository.ObtenerGastoPorId(id);
        }

        public async Task AgregarGasto(Gasto gasto)
        {
            await _gastoRepository.AgregarGasto(gasto);
        }

        public async Task ActualizarGasto(Gasto gasto)
        {
            await _gastoRepository.ActualizarGasto(gasto);
        }

        public async Task EliminarGasto(int id)
        {
            await _gastoRepository.EliminarGasto(id);
        }
    }
}

