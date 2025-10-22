using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.ExcepcionesEntidades.Usuarios;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {


        
        public ILoginUsuario LoginUsuario { get; set; }

        public UsuarioController( ILoginUsuario loginUsuario)
        {           
            LoginUsuario = loginUsuario;
        }


        // GET: api/<UsuarioController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        return Ok(ListadoUsuarios.Ejecutar());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error en los datos");
        //    }
        //}

        //// GET api/<UsuarioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UsuarioController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UsuarioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsuarioController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        /// <summary>
        /// Iniciar Sesion
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpPost("login/{email}/{password}")]
        public IActionResult IniciarSesion(string email, string password)
        {
            try
            {
                if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    return BadRequest("Los datos no son correctos");
                }
                DTOUsuarioIniciarSesion dtoUsu = LoginUsuario.Ejecutar(email, password);
                DTOUsuarioLogueado dtoUsuarioLogueado = new DTOUsuarioLogueado()
                {
                    Rol = dtoUsu.Rol,
                    Token = ManejadorToken.CrearToken(dtoUsu)
                };
                return Ok(dtoUsuarioLogueado);

            }
            catch (UsuarioException ex)
            {
                return StatusCode(400, ex.Message);
            }           
            catch (Exception ex)
            {
                return StatusCode(500,"Error");
            }
        }
    }
}
