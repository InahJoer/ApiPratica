using ApiPratica.Models;
using ApiPratica.Models.Dto;
using ApiPratica.Repository.IRepository;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ApiPratica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MascotasController : ControllerBase
    {
        private readonly ILogger<MascotasController> _logger;
        private readonly IMascotasRepository _mascotarepository;
        private readonly IMapper _mapper;

        public MascotasController(ILogger<MascotasController> logger, IMascotasRepository mascotarepository, IMapper mapper)
        {
            _logger = logger;
            _mascotarepository = mascotarepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<IEnumerable<MascotasDto>>> GetMascotas()
        {
            _logger.LogInformation("Obtener Mascotas");
            var mascotasList = await _mascotarepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<MascotasDto>>(mascotasList));
        }

        [HttpGet("{id:int}", Name = "GetMascotas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotasDto>> GetMascota(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al Buscar a la mascotas con id {id}");
                return BadRequest();
            }
            var mascotas = await _mascotarepository.Get(s => s.MascotaId == id);

            if (mascotas == null)
            {
                _logger.LogError($"Error al Buscar a la mascotas con id {id}");
                return NotFound();
            }
            return Ok(_mapper.Map<MascotasDto>(mascotas));

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MascotasDto>> addMascotas([FromBody] MascotasCreateDto mascotasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _mascotarepository.Get(s => s.MascotaName.ToLower() == mascotasDto.MascotaName.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "¡La Mascota con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            if (mascotasDto == null)
            {
                return BadRequest(mascotasDto);
            }
            Mascotas modelo = _mapper.Map<Mascotas>(mascotasDto);
            await _mascotarepository.Create(modelo);
            return CreatedAtRoute("GetMascotas", new { id = modelo.MascotaId }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteMascotas(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var mascotas = await _mascotarepository.Get(s => s.MascotaId == id);
            if (id == null)
            {
                return NotFound();
            }
            await _mascotarepository.Remove(mascotas);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMascotas(int id, [FromBody] MascotasUpdateDto mascotasDTO)
        {
            if (mascotasDTO == null || id != mascotasDTO.MascotaId)
            {
                return BadRequest();
            }
            Mascotas modelo = _mapper.Map<Mascotas>(mascotasDTO);
            await _mascotarepository.Update(modelo);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialMascota(int id, JsonPatchDocument<MascotasUpdateDto> patchDto)
        {
            if(patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var mascotas = await _mascotarepository.Get(s => s.MascotaId == id, tracked: false);
            MascotasUpdateDto mascotasdto = _mapper.Map<MascotasUpdateDto>(mascotas);
            if (mascotas == null) return BadRequest();

            patchDto.ApplyTo(mascotasdto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mascotas modelo = _mapper.Map<Mascotas>(mascotasdto);
            await _mascotarepository.Update(modelo);
            return NoContent();
        }
    }

}
