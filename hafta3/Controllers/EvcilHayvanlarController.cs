using AutoMapper;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DataAccessLayer.IRepository;

namespace hafta3.Controllers
{
    [Route("api/evcilhayvanlar")]
    [ApiController]
    public class EvcilHayvanlarController : Controller
    {
		private readonly IMapper _mapper;
		private readonly IEvcilHayvanlarRepository _evcilHayvanlarRepository;
		private readonly IValidator<EvcilHayvanEkleDTO> _validator;

		public EvcilHayvanlarController(IEvcilHayvanlarRepository evcilHayvanlarRepository, IMapper mapper, IValidator<EvcilHayvanEkleDTO> validator)
		{
			_evcilHayvanlarRepository = evcilHayvanlarRepository ?? throw new ArgumentNullException(nameof(evcilHayvanlarRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_validator = validator;
		}


		//Tüm evcil hayvanları listeler.
		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvcilHayvanDTO>>> GetEvcilHayvanlar(
		   [FromQuery] int? page = 1,
		   [FromQuery] int? pageSize = 10,
		   [FromQuery] string name = null,
		   [FromQuery] string sortField = "Isim",
		   [FromQuery] string sortOrder = "asc")
		{
			try
			{
				var query = _evcilHayvanlarRepository.AsQueryable();

				// Filtreleme
				if (!string.IsNullOrEmpty(name))
				{
					query = query.Where(u => u.Isim.Contains(name));
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

				var hayvanlar = await query.ToListAsync();
				IEnumerable<EvcilHayvanDTO> hayvanlarDto = _mapper.Map<IEnumerable<EvcilHayvanDTO>>(hayvanlar);
				return Ok(hayvanlarDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}

		//Belirli bir evcil hayvanın bilgilerini getirir.
		[HttpGet("evcilHayvanId")]
		public async Task<ActionResult<EvcilHayvanDTO>> GeEvcilHayvanlarById(int id)
		{
			var hayvan = await _evcilHayvanlarRepository.GetWhereQuery(x => x.ID == id).FirstOrDefaultAsync();
			if (hayvan == null)
			{
				return NotFound("Evcil Hayvan bulunamadı.");
			}
			return Ok(_mapper.Map<EvcilHayvanDTO>(hayvan));
		}

		//Yeni evcil hayvan oluşturur.
		[HttpPost]
		public async Task<ActionResult<EvcilHayvanDTO>> Add(EvcilHayvanEkleDTO evcilHayvanEkleDTO)
		{
			var result = _validator.Validate(evcilHayvanEkleDTO);
			try
			{
				EvcilHayvanlar hayvanNew = _mapper.Map<EvcilHayvanlar>(evcilHayvanEkleDTO);
				await _evcilHayvanlarRepository.AddAsync(hayvanNew);

				return CreatedAtAction(nameof(GeEvcilHayvanlarById), new { id = hayvanNew.ID }, _mapper.Map<EvcilHayvanDTO>(hayvanNew));
			}
			catch (Exception ex)
			{
				return BadRequest($"Bad Request: {ex.Message}");
			}
		}

		//Evcil hayvanın bilgilerini günceller.
		[HttpPut("evcilHayvanId")]
		public async Task<IActionResult> UpdateEvcilHayvan(int evcilHayvanId, EvcilHayvanEkleDTO evcilHayvanDTO)
		{


			if (evcilHayvanId == 0)
			{
				return BadRequest("Bad Request: Evcil Hayvan Kimliği eşleşmiyor.");
			}
			EvcilHayvanlar evcilHayvanlar = _mapper.Map<EvcilHayvanlar>(evcilHayvanDTO);
			evcilHayvanlar.ID = evcilHayvanId;
			await _evcilHayvanlarRepository.UpdateAsync(evcilHayvanlar);

			try
			{
				return NoContent();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _evcilHayvanlarRepository.Exist(evcilHayvanlar.ID))
				{
					return NotFound("Evcil hayvan bulunamadı.");
				}
				else
				{
					return StatusCode(500, "Internal Server Error");
				}
			}
		}

		//Belirli bir evcil hayvanın bilgilerini getirir.
		[HttpGet("istatistikler/evcilHayvanId")]
		public async Task<ActionResult<EvcilHayvanAktivitelerListDTO>> GeEvcilHayvanIstatistik(int id)
		{
			//EvcilHayvanIstatistikAl
			var hayvan = await _evcilHayvanlarRepository.EvcilHayvanIstatistikAl(id);
			if (hayvan == null)
			{
				return NotFound("Evcil Hayvan bulunamadı.");
			}
			return Ok(hayvan);
		}

	}
}

