using AutoMapper;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace hafta3.Controllers
{
	[Route("api/kullanicilar")]
	[ApiController]
	public class KullaniciController : Controller
	{

		private readonly IValidator<KullaniciEkleDTO> _validator;
		private readonly IMapper _mapper;
		private readonly IKullaniciRepository _kullaniciRepository;
		public KullaniciController(IKullaniciRepository kullaniciRepository, IMapper mapper, IValidator<KullaniciEkleDTO> validator)
		{
			_kullaniciRepository = kullaniciRepository ?? throw new ArgumentNullException(nameof(kullaniciRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_validator = validator;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<KullaniciDTO>>> GetKullanici(
		   [FromQuery] int? page = 1,
		   [FromQuery] int? pageSize = 10,
		   [FromQuery] string name = null,
		   [FromQuery] string sortField = "Adi",
		   [FromQuery] string sortOrder = "asc")
		{
			try
			{
				var query = _kullaniciRepository.AsQueryable();
				//var query1 = _context.Kullanicilar.AsQueryable();

				// Filtreleme
				if (!string.IsNullOrEmpty(name))
				{
					query = query.Where(u => u.Adi.Contains(name));
				}

				// Sıralama
				if (!string.IsNullOrEmpty(sortField))
				{
					switch (sortOrder.ToLower())
					{
						case "asc":
							query = query.OrderBy(u => EF.Property<object>(u, sortField));
							break;
						case "desc":
							query = query.OrderByDescending(u => EF.Property<object>(u, sortField));
							break;
					}
				}

				// Sayfalama
				if (page.HasValue && pageSize.HasValue)
				{
					query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
				}

				List<Kullanici> kullanicilar = query.ToList();
				IEnumerable<KullaniciDTO> kullanicilarDto = _mapper.Map<IEnumerable<KullaniciDTO>>(kullanicilar);

				return Ok(kullanicilarDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}

		//Belirli bir kullanıcının bilgilerini getirir.
		[HttpGet("kullaniciId")]
		public async Task<ActionResult<KullaniciDTO>> GetByID(int id)
		{
			var kullaniciGetir = await _kullaniciRepository.GetByIDAsync(id);

			if (kullaniciGetir == null)
			{
				return NotFound("Kullanıcı bulunamadı.");
			}
			return Ok(_mapper.Map<KullaniciDTO>(kullaniciGetir));
		}

		//Yeni kullanıcı oluşturur.
		[HttpPost]
		public async Task<ActionResult<KullaniciDTO>> Add(KullaniciEkleDTO kullaniciEkleDTO)
		{
			var result = _validator.Validate(kullaniciEkleDTO);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
			}
			//try
			//{
			Kullanici kullaniciNew = _mapper.Map<Kullanici>(kullaniciEkleDTO);
			await _kullaniciRepository.AddAsync(kullaniciNew);

			KullaniciDTO returnKullanici = _mapper.Map<KullaniciDTO>(kullaniciNew);
			return CreatedAtAction(nameof(GetByID), new { id = kullaniciNew.ID }, returnKullanici);

		}

		[HttpGet("istatistikler/kullaniciID")]
		public async Task<ActionResult<EvcilHayvanAktivitelerListDTO>> GeEvcilHayvanIstatistik(int id)
		{
			var istatistikler = await _kullaniciRepository.KullaniciEvcilHayvanIstatistikAl(id);
			if (istatistikler == null)
			{
				return NotFound("Evcil Hayvana ait istatistikler bulunamadı.");
			}
			return Ok(istatistikler);
		}
	}
}


