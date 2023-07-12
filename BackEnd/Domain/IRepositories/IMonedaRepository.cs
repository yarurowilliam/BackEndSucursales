using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IMonedaRepository
    { 
        Task SavedMonedaAsync(Moneda moneda);
        Task<bool> ValidateExistenceAsync(Moneda moneda);
        Task<List<Moneda>> GetListMonedasAsync();
        Task<Moneda> GetMonedaAsync(int idMoneda);
    }
}
