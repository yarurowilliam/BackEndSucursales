using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
	public class SucursalRepository : ISucursalRepository
	{

		private readonly AplicationDbContext _context;

		public SucursalRepository(AplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Sucursal> GetSucursalAsync(int codigoSucursal)
		{
			try
			{
				var sucursal = await _context.Sucursal_TEST.Where(x => x.Codigo == codigoSucursal).Include(s => s.Moneda).FirstOrDefaultAsync();
				return sucursal;
			} catch (Exception ex)
			{
				return null;
			}

		}

		public async Task<List<Sucursal>> GetListSucursalesAsync()
		{
			var listaSucursal = await _context.Sucursal_TEST.Include(s => s.Moneda).ToListAsync();
			return listaSucursal;
		}

		public async Task SavedSucursalAsync(Sucursal sucursal)
		{
			_context.Add(sucursal);
			await _context.SaveChangesAsync();
		}

		public async Task<Sucursal> ActualizarSucursalAsync(int codigoSucursal, Sucursal sucursal)
		{
			var entidadOriginal = await _context.Sucursal_TEST.FindAsync(codigoSucursal);
			if (codigoSucursal == sucursal.Codigo)
			{
				_context.Entry(entidadOriginal).State = EntityState.Detached;
				_context.Entry(sucursal).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return sucursal;
			}
			else
			{
				return null;
			}
		}

		public async Task<Sucursal> EliminarSucursalAsync(int codigoSucursal)
		{
			var sucursal = await _context.Sucursal_TEST.FindAsync(codigoSucursal);
			if (sucursal != null)
			{
				_context.Sucursal_TEST.Remove(sucursal);
				await _context.SaveChangesAsync();
				return sucursal;
			}
			else
			{
				return null;
			}
		}
	}
}
