using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface ISucursalRepository
    {
        Task SavedSucursalAsync(Sucursal sucursal);
        Task<List<Sucursal>> GetListSucursalesAsync();
        Task<Sucursal> GetSucursalAsync(int codigoSucursal);
        Task<Sucursal> ActualizarSucursalAsync(int codigoSucursal, Sucursal sucursal);
        Task<Sucursal> EliminarSucursalAsync(int codigoSucursal);
    }
}
