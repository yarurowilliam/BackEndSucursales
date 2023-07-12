using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
	public class SucursalService : ISucursalService
	{
		private readonly ISucursalRepository _sucursalRepository;
		private readonly IMonedaRepository _monedaRepository;

		public SucursalService(ISucursalRepository sucursalRepository, IMonedaRepository monedaRepository)
		{
			_sucursalRepository = sucursalRepository;
			_monedaRepository = monedaRepository;
		}

		public async Task<Sucursal> GetSucursalAsync(int codigoSucursal)
		{
			return await _sucursalRepository.GetSucursalAsync(codigoSucursal);
		}

		public async Task<List<Sucursal>> GetListSucursalesAsync()
		{
			return await _sucursalRepository.GetListSucursalesAsync();
		}

		public async Task<string> SavedSucursalAsync(Sucursal sucursal)
		{
			var result = string.Empty;
			var sucursalExistente = await _sucursalRepository.GetSucursalAsync(sucursal.Codigo);
			var moneda = await _monedaRepository.GetMonedaAsync(sucursal.IdMoneda);

			if (sucursalExistente != null)
			{
				result = "Esta sucursal ya se encuentra registrada!";
			}
			else
			{
				DateTime fechaCreacion = sucursal.FechaCreacion.Date;
				DateTime fechaActual = DateTime.Now.Date;
				if (fechaCreacion >= fechaActual)
				{
					sucursal.Moneda = moneda;

					await _sucursalRepository.SavedSucursalAsync(sucursal);
					result = "La sucursal se registro correctamente!";
				}
				else
				{
					result = "No puede registrar una sucursal si la fecha de creación es menor a la actual!";
				}

			}
		
			return result;
		}

	public async Task<string> ActualizarSucursalAsync(int codigoSucursal, Sucursal sucursal)
	{
		var sucursalCheck = await _sucursalRepository.ActualizarSucursalAsync(codigoSucursal, sucursal);
		if (sucursalCheck != null)
		{
			return "Se actualizo la sucursal correctamente";
		}
		else
		{
			return "No fue posible actualizar la sucursal";
		}
	}

	public async Task<string> EliminarSucursalAsync(int codigoSucursal)
	{
		var sucursalCheck = await _sucursalRepository.EliminarSucursalAsync(codigoSucursal);
		if (sucursalCheck != null)
		{
			return "Se elimino la sucursal correctamente";
		}
		else
		{
			return "No fue posible eliminar la sucursal";
		}
	}
}
}
