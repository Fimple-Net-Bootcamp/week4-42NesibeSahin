using AutoMapper;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace hafta3.Controllers
{
    [Route("api/besinler")]
    [ApiController]
    public class BesinlerController : Controller
    {
		private readonly IValidator<BesinlerEkleDTO> _validator;
		private readonly ProjeDB _context;
        private readonly IMapper _mapper;

        public BesinlerController(ProjeDB context, IMapper mapper, IValidator<BesinlerEkleDTO> validator)
		{
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_validator = validator;
		}

        //Tüm besinleri listeler.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BesinlerDTO>>> GetBesinler(
           [FromQuery] int? page = 1,
           [FromQuery] int? pageSize = 10,
           [FromQuery] string name = null,
           [FromQuery] string sortField = "Adi",
           [FromQuery] string sortOrder = "asc")
        {
            try
            {
                var query = _context.Besinler.AsQueryable();

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

                var besinler = await query.ToListAsync();
                IEnumerable<BesinlerDTO> besinlerDto = _mapper.Map<IEnumerable<BesinlerDTO>>(besinler);

                return Ok(besinlerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

      
    }
}
