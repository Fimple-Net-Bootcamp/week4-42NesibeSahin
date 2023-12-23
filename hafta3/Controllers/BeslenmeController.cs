using AutoMapper;
using EntityLayer.DTOs;
using FluentValidation;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using hafta3.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta3.Controllers
{
	[Route("api/beslenme")]
	[ApiController]
	public class BeslenmeController : Controller
	{
		private readonly IValidator<BeslenmeEkleDTO> _validator;
		private readonly ProjeDB _context;
		private readonly IMapper _mapper;

		public BeslenmeController(ProjeDB context, IMapper mapper, IValidator<BeslenmeEkleDTO> validator)
		{
			_context = context;
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		//Evcil hayvana besin verir.
		[HttpPost("evcilHayvanId")]
		public async Task<ActionResult<BeslenmeDTO>> Add(BeslenmeEkleDTO beslenmeEkleDTO, int evcilHayvanId)
		{
			//var result = _validator.Validate(beslenmeEkleDTO);
			try
			{
				Beslenme beslenme = _mapper.Map<Beslenme>(beslenmeEkleDTO);
				beslenme.EvcilHayvanID = evcilHayvanId;
				_context.Beslenme.Add(beslenme);
				await _context.SaveChangesAsync();
				BeslenmeDTO returnBesin = _mapper.Map<BeslenmeDTO>(beslenme);
				return CreatedAtAction(nameof(GetByID), new { id = beslenme.ID }, returnBesin);
			}
			catch (Exception ex)
			{
				return BadRequest($"Bad Request: {ex.Message}");
			}
		}

		[HttpGet("id")]
		public async Task<ActionResult<BeslenmeDTO>> GetByID(int id)
		{
			var besinGetir = await _context.Beslenme.Where(x => x.ID == id).FirstOrDefaultAsync();

			if (besinGetir == null)
			{
				return NotFound("Beslenme bulunamadı.");
			}
			return Ok(_mapper.Map<BeslenmeDTO>(besinGetir));
		}
	}
}
