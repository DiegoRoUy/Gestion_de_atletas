using Compartido.DTOs.Disciplinas;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Auditorias;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ExcepcionesEntidades.Disciplinas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        public IAltaDisciplina AltaDisciplina { get; set; }
        public IListadoDisciplinas ListadoDisciplinas { get; set; }
        public IBuscarDisciplina BuscarDisciplina { get; set; }

        public IEditarDisciplina EditarDisciplina { get; set; }

        public IEliminarDisciplina EliminarDisciplina { get; set; }

        public IDisciplinaPorNombre DisciplinaPorNombre { get; set; }



        public DisciplinaController(IAltaDisciplina altaDisciplina, IListadoDisciplinas listadoDisciplinas,
            IBuscarDisciplina buscarDisciplina, IEditarDisciplina editarDisciplina, IEliminarDisciplina eliminarDisciplina, IDisciplinaPorNombre disciplinaPorNombre)
        {
            AltaDisciplina = altaDisciplina;
            ListadoDisciplinas = listadoDisciplinas;
            BuscarDisciplina = buscarDisciplina;
            EditarDisciplina = editarDisciplina;
            EliminarDisciplina = eliminarDisciplina;
            DisciplinaPorNombre = disciplinaPorNombre;

        }



        /// <summary>
        /// Listar todas las Disciplinas
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<DisciplinaController>
        [Authorize(Roles = "Digitador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ListadoDisciplinas.Ejecutar());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en los datos");
            }
        }

        /// <summary>
        /// Obtiene una Disciplina dado un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]

        [Authorize(Roles = "Digitador")]
        // GET api/<DisciplinaController>/5
        [HttpGet("ById/{id:int}", Name = "ObtenerDisciplinaPorId")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id recibido no es correcto");
                }
                return Ok(BuscarDisciplina.Ejecutar(id));
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }


        /// <summary>
        /// Permite dar de alta una Disciplina
        /// </summary>
        /// <param name="dTODisciplina"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [Authorize(Roles = "Digitador")]
        // POST api/<DisciplinaController>
        [HttpPost]
        public IActionResult Post([FromBody] DTODisciplina dTODisciplina)
        {
            try
            {

                if (dTODisciplina == null)
                {
                    return BadRequest("Los datos recibidos son incorrectos");
                }
                AltaDisciplina.Ejecutar(dTODisciplina);
                return CreatedAtRoute("ObtenerDisciplinaPorId", new { Id = dTODisciplina.Id }, dTODisciplina);
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }


        /// <summary>
        /// Permite modificar una Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dTODisciplina"></param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DTODisciplina dTODisciplina)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El Id no es correcto");
                }
                if (id != dTODisciplina.Id)
                {
                    return BadRequest("Los id no son iguales");
                }
                if (dTODisciplina == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                EditarDisciplina.Ejecutar(id, dTODisciplina);
                return Ok(dTODisciplina);
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }


        /// <summary>
        /// Permite Eliminar una Disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}/{email}")]
        public IActionResult Delete(int id, string email)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El " + id + " no es correcto");
                }
                EliminarDisciplina.Ejecutar(id, email);
                return NoContent();
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ConflictException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }
        }

        /// <summary>
        /// Obtiene una Disciplina dado un Nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Digitador")]
        [HttpGet("ByName/{nombre}")]
        public IActionResult GetByName(string nombre)
        {
            try
            {

                if (string.IsNullOrEmpty(nombre))
                {
                    return BadRequest("El nombre recibido no es correcto");
                }
                return Ok(DisciplinaPorNombre.Ejecutar(nombre));
            }
            catch (DisciplinaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Datos incorrectos");
            }

        }
    }
}
