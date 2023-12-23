using AutoMapper;
using FluentValidation;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;

namespace hafta3.Controllers
{
    [Route("api/aktiviteler")]
    [ApiController]
    public class AktivitelerController : Controller
    {

        private readonly IValidator<AktivitelerEkleDTO> _validator;
        //private readonly ProjeDB _context;
        private readonly IMapper _mapper;
		private readonly IAktivitelerRepository _aktivitelerRepository;
		public AktivitelerController(IAktivitelerRepository aktivitelerRepository, IMapper mapper, IValidator<AktivitelerEkleDTO> validator)
        {
			//throw new Exception("hata exception middleware");
			_aktivitelerRepository = aktivitelerRepository ?? throw new ArgumentNullException(nameof(aktivitelerRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator;
        }

        //Evcil hayvan için yeni bir aktivite ekler.
        [HttpPost]
        public async Task<ActionResult<AktivitelerDTO>> Add([FromBody]AktivitelerEkleDTO aktivitelerEkleDTO)
        {

            var result = _validator.Validate(aktivitelerEkleDTO);
            //result.IsValid;
            try
            {
                Aktiviteler aktivite = _mapper.Map<Aktiviteler>(aktivitelerEkleDTO);
				//_aktivitelerRepository.Aktiviteler.Add(aktivite);
				await _aktivitelerRepository.AddAsync(aktivite);
				AktivitelerDTO returnAktivite = _mapper.Map<AktivitelerDTO>(aktivite);
                return CreatedAtAction(nameof(GetAktiviteByID), new { id = aktivite.ID }, returnAktivite);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }

        //Evcil hayvanın yapabileceği aktiviteleri listeler.
        [HttpGet("evcilHayvanId")]
        public async Task<ActionResult<IEnumerable<AktivitelerDTO>>> GetAktiviteByID( int evcilHayvanId)
        {
            try
            {
                var query = _aktivitelerRepository.GetWhereQuery(x=>x.EvcilHayvanID== evcilHayvanId).AsQueryable();

               
                var aktivite = await query.ToListAsync();
                IEnumerable<AktivitelerDTO> aktiviteDto = _mapper.Map<IEnumerable<AktivitelerDTO>>(aktivite);

                return Ok(aktiviteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

       

    }
}
