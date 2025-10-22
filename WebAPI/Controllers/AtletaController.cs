using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Atletas;
using LogicaNegocio.ExcepcionesEntidades.Atletas;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {

        public IListadoAtletasPorDisciplina ListadoAtletasPorDisciplina { get; set; }
        public IListadoAtletas ListadoAtletas { get; set; }

        public AtletaController(IListadoAtletasPorDisciplina listadoAtletasPorDisciplina, IListadoAtletas listadoAtletas)
        {
            ListadoAtletasPorDisciplina = listadoAtletasPorDisciplina;
            ListadoAtletas = listadoAtletas;
        }


        /// <summary>
        /// Listar todos los Atletas
        /// </summary>       
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<AtletaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ListadoAtletas.Ejecutar());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }


        /// <summary>
        /// Listar Atletas dado un Id de disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET api/<AtletaController>/5
        [HttpGet("{id}", Name = "AtletaPorDisciplina")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id recibido no es correcto");
                }
                return Ok(ListadoAtletasPorDisciplina.Ejecutar(id));
            }
            catch (AtletaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
