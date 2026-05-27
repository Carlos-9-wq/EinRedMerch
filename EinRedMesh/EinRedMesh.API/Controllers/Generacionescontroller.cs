using AutoMapper;
using Ein.Dtos;
using Ein.Entidades;
using EinRedMesh.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace EinRedMesh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Generacionescontroller : ControllerBase
    {

        private readonly EinDataContext _context;
        private readonly IMapper _mapper;

        public Generacionescontroller(EinDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<ActionResult<RespuestasModels>> Get() 
        {
            try
            {
                var lista = await _context.Generacion
                    .Where(x => x.EstaActivo == true)
                    .Select(x => _mapper.Map<GeneracionGetDto>(x))
                    .ToListAsync();

                if (lista.Count == 0)
                {
                    return new RespuestasModels(StatusCodes.Status204NoContent, "No existe contenido en las generaciones"); // 👈 CORREGIDO: Tu nombre exacto
                }

                return new RespuestasModels(StatusCodes.Status200OK, "Generaciones obtenidas correctamente", lista);
            }
            catch (Exception ex)
            {
                return new RespuestasModels(StatusCodes.Status400BadRequest,ex.Message);
            }
        }

        

        [HttpGet("{id}")]
        public async Task <ActionResult<RespuestasModels>> GetById(int id)
        {
            try
            {
                var generacion = await _context.Generacion.Where(x=> x.EstaActivo==true && x.Id==id).FirstOrDefaultAsync();

                if (generacion == null)
                    return new RespuestasModels(StatusCodes.Status204NoContent,"No existe contenido");

                var obj = _mapper.Map<GeneracionGetDto>(generacion);
                return new RespuestasModels(StatusCodes.Status200OK, "Se ejecuto correctamente", obj);
            }
            catch (Exception ex)
            {

                return new RespuestasModels(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(int id, GeneracionSetDto newObj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var generacion = await _context.Generacion.Where(x => x.EstaActivo && x.Id == id).FirstOrDefaultAsync();

                if (generacion == null)
                    return NotFound();

                var obj = _mapper.Map<GeneracionEntity>(newObj);

               await _context.Generacion.AddAsync(obj);
               await _context.SaveChangesAsync();

                return Ok(newObj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var generacion = await _context.Generacion.Where(x=> x.EstaActivo && x.Id==Id).FirstOrDefaultAsync();

                if (generacion == null)
                    return NotFound();

              //  _context.Generacion.Remove(generacion);
               generacion.EstaActivo = false;

                _context.Generacion.Update(generacion); 
                await _context.SaveChangesAsync();

                return Ok($"Se elimino correctamente Id:{Id}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Edit(int id, GeneracionSetDto obj)
        {
            try
            {
                var generacion = await _context.Generacion.FindAsync(id);

                if (generacion == null)
                    return NotFound();
                generacion.Nombre = obj.Nombre;

                _context.Generacion.Update(generacion);
               await _context.SaveChangesAsync();

                return Ok(new { Mensaje = $"Se modifico Correctamente el Id:{id}", Data = obj });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPatch]
        public IActionResult EditarNombre(int id, string nombre)
        {
            return Ok(new { Mensaje = $"Se modifico el Nombre Correctamente el Id:{id}", Data = nombre });
        }
    



    }
}
