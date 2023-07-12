using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface ISucursalService
    {
        Task<string> SavedSucursalAsync(Sucursal sucursal);
        Task<List<Sucursal>> GetListSucursalesAsync();
        Task<Sucursal> GetSucursalAsync(int codigoSucursal);
        Task<string> ActualizarSucursalAsync(int codigoSucursal, Sucursal sucursal);
        Task<string> EliminarSucursalAsync(int codigoSucursal);
    }
}
