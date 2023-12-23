using AutoMapper;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace hafta3.Controllers
{
    [Route("api/sosyalEtkilesimler")]
    [ApiController]
    public class SosyalEtkilesimlerController : Controller
    {
		private readonly IValidator<SosyalEtkilesimlerEkleDTO> _validator;
		private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public SosyalEtkilesimlerController(ProjeDB context, IMapper mapper, IValidator<SosyalEtkilesimlerEkleDTO> validator)
		{
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_validator = validator;
		}


        [HttpPost]
        public async Task<ActionResult<SosyalEtkilesimlerDTO>> PostEtkilesim(SosyalEtkilesimlerEkleDTO sosyalEtkilesimEkleDTO)
        {
			var result = _validator.Validate(sosyalEtkilesimEkleDTO);
			try
			{
				SosyalEtkilesimler sosyal = _mapper.Map<SosyalEtkilesimler>(sosyalEtkilesimEkleDTO);
				_context.SosyalEtkilesimler.Add(sosyal);
				await _context.SaveChangesAsync();
				SosyalEtkilesimlerDTO returnsosyal = _mapper.Map<SosyalEtkilesimlerDTO>(sosyal);
				return CreatedAtAction(nameof(GetSosyalByID), new { id = sosyal.ID }, returnsosyal);
			}
			catch (Exception ex)
			{
				return BadRequest($"Bad Request: {ex.Message}");
			}

		}


		[HttpGet("evcilHayvanId")]
		public async Task<ActionResult<IEnumerable<SosyalEtkilesimlerDTO>>> GetSosyalByID(int evcilHayvanId)
		{
			try
			{
				var query = _context.SosyalEtkilesimler.Where(x => x.EvcilHayvanID == evcilHayvanId).AsQueryable();


				var sosyal = await query.ToListAsync();
				IEnumerable<SosyalEtkilesimlerDTO> newDto = _mapper.Map<IEnumerable<SosyalEtkilesimlerDTO>>(sosyal);

				return Ok(newDto);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}




	}
}
