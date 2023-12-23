using AutoMapper;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace hafta3.Controllers
{
    [Route("api/egitimler")]
    [ApiController]
    public class EgitimlerController : Controller
    {
		private readonly IValidator<EgitimlerEkleDTO> _validator;
		private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public EgitimlerController(ProjeDB context, IMapper mapper, IValidator<EgitimlerEkleDTO> validator)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_validator = validator;
		}

        //Evcil hayvanın aldığı eğitimleri listeler.
        [HttpGet("evcilHayvanId")]
        public async Task<ActionResult<IEnumerable<EgitimlerDTO>>> GetEgitimByID(int evcilHayvanId)
        {
            try
            {
                var query = _context.Egitimler.Where(x => x.EvcilHayvanID == evcilHayvanId).AsQueryable();


                var egitim = await query.ToListAsync();
                IEnumerable<EgitimlerDTO> egitimDto = _mapper.Map<IEnumerable<EgitimlerDTO>>(egitim);

                return Ok(egitimDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }




        //// Evcil hayvana yeni bir eğitim ekler.
        [HttpPost]
        public async Task<ActionResult<EgitimlerDTO>> Add(EgitimlerEkleDTO egitimEkleDTO)
        {
			var result = _validator.Validate(egitimEkleDTO);
			try
            {
                Egitimler egitim = _mapper.Map<Egitimler>(egitimEkleDTO);
                _context.Egitimler.Add(egitim);
                await _context.SaveChangesAsync();
                EgitimlerDTO returnEgitim = _mapper.Map<EgitimlerDTO>(egitim);
                return CreatedAtAction(nameof(GetEgitimByID), new { id = egitim.ID }, returnEgitim);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }


    }
}
