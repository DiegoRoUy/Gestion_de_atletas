using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos;
using LogicaNegocio.ExcepcionesEntidades.Eventos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IListadoEventos ListadoEventos { get; set; }
        public IBuscarEvento BuscarEvento { get; set; }
        public IEventosPorFecha EventosPorFecha { get; set; }
        public IEventoPorNombre EventoPorNombre { get; set; }
        public IEventoPorPuntaje EventoPorPuntaje { get; set; }
        public EventoController(IListadoEventos listadoEventos, IBuscarEvento buscarEvento, IEventosPorFecha eventosPorFecha,
            IEventoPorNombre eventoPorNombre, IEventoPorPuntaje eventoPorPuntaje)
        {
            ListadoEventos = listadoEventos;
            BuscarEvento = buscarEvento;
            EventosPorFecha = eventosPorFecha;
            EventoPorNombre = eventoPorNombre;
            EventoPorPuntaje = eventoPorPuntaje;
        }



        /// <summary>
        /// Listar Eventos
        /// </summary>       
        /// <returns></returns>

        // GET: api/<EventoController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize(Roles = "Digitador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(ListadoEventos.Ejecutar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }

        }


        /// <summary>
        /// Listar Eventos dado un Id de Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        [Authorize(Roles = "Digitador")]
        // GET api/<EventoController>/5
        [HttpGet("ByIdDisciplina/{id:int}")]
        public IActionResult GetByIdDisciplina(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El Id recibido no es correcto");
                }
                return Ok(BuscarEvento.Ejecutar(id));
            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }

        /// <summary>
        /// Listar Eventos dado un texto
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
     
        [Authorize(Roles = "Digitador")]
        [HttpGet("ByTexto/{texto}")]
        public IActionResult GetByTexto(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto))
                {
                    return BadRequest("El texto recibido no puede estar vacio");
                }
                return Ok(EventoPorNombre.Ejecutar(texto));

            }
            catch (EventoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }

        /// <summary>
        /// Listar Eventos dada dos fechas
        /// </summary>
        /// <param name="fechaInicio,fechaFin "></param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpGet("ByFechas/{FechaInicio}/{FechaFin}")]
        public IActionResult GetByFechas(string FechaInicio, string FechaFin)
        {
            try
            {
                DateTime fechaIn = DateTime.Parse(FechaInicio);
                DateTime fechaFi = DateTime.Parse(FechaFin);
                if (fechaIn == DateTime.MinValue || fechaFi == DateTime.MinValue)
                {
                    return BadRequest("Las fechas no pueden estar vacias");
                }
                if (fechaFi < fechaIn)
                {
                    return BadRequest("La fecha Inicio no puede ser posterior a la fecha Fin");
                }
                return Ok(EventosPorFecha.Ejecutar(fechaIn, fechaFi));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }

        /// <summary>
        /// Listar Eventos dado dos puntajes
        /// </summary>
        /// <param name="puntaje1,puntaje2 "></param>
        /// <returns></returns>
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpGet("ByPuntaje/{puntaje1}/{puntaje2}")]
        public IActionResult GetByPuntaje(decimal puntaje1, decimal puntaje2)
        {
            try
            {
                if (puntaje1 < 0 || puntaje2 < 0)
                {
                    return BadRequest("Los puntajes tienen que ser mayor a 0");
                }
                if (puntaje1 > puntaje2)
                {
                    return BadRequest("El puntaje1 no puede ser mayor al puntaje2");
                }
                return Ok(EventoPorPuntaje.Ejecutar(puntaje1, puntaje2));


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }

     
    }
}
