
using LibreriaWeb.Models.Roles;
using LibreriaWeb.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Security.Policy;


namespace LibreriaWeb.Controllers
{
    public class UsuarioController : Controller
    {


        // GET: UsuarioController
        public ActionResult Index()
        {
            // if (HttpContext.Session.GetInt32("Rol") == null || HttpContext.Session.GetInt32("Rol") != 1) { return RedirectToAction("Index", "Home"); }

            IEnumerable<UsuarioListadoViewModel> listaUsuarios = new List<UsuarioListadoViewModel>();
            HttpClient cliente = new HttpClient();
            string url = "http://localhost:5135";
            cliente.BaseAddress = new Uri(url);
            Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Usuario");
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                listaUsuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioListadoViewModel>>(datos);
            }
            else
            {
                ViewBag.Message = datos;
            }

            return View(listaUsuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {

            return View();

        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioListadoViewModel usuarioVM)
        {

            return View();
        }



        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioListadoViewModel usuarioVM)
        {


            return View();
        }

        [HttpGet]
        public ActionResult IniciarSesion()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioLoginViewModel usuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient cliente = new HttpClient();
                    string url = "http://localhost:5135";
                    cliente.BaseAddress = new Uri(url);
                    Task<HttpResponseMessage> respuesta =
                        cliente.PostAsJsonAsync(url + "/api/Usuario/login/" + usuarioVM.Email + "/" + usuarioVM.Password, usuarioVM);
                    respuesta.Wait();
                    HttpResponseMessage contenido = respuesta.Result;
                    Task<string> datos = contenido.Content.ReadAsStringAsync();
                    datos.Wait();
                    string datosRespuesta = datos.Result;
                    if (contenido.IsSuccessStatusCode)
                    {
                        UsuarioLogueadoViewModel usuLogueadoVM =
                            JsonConvert.DeserializeObject<UsuarioLogueadoViewModel>(datosRespuesta);
                        HttpContext.Session.SetString("rol", usuLogueadoVM.Rol);
                        HttpContext.Session.SetString("token", usuLogueadoVM.Token);
                        HttpContext.Session.SetString("email", usuarioVM.Email);

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.Mensaje = datosRespuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }

            return View("IniciarSesion");
        }

        public ActionResult LogOut()
        {         
            if (HttpContext.Session.GetString("rol") == null) { return RedirectToAction("Index", "Home"); }
            HttpContext.Session.Clear();      
            return RedirectToAction(nameof(IniciarSesion));
        }

        //public UsuarioViewModel GetRolUsuarioViewModel()
        //{
        //    UsuarioViewModel usuarioVM = new UsuarioViewModel();
        //    IEnumerable<RolListadoViewModel> roles = new List<RolListadoViewModel>();

        //    usuarioVM.Roles = roles;
        //    return usuarioVM;

        //}


    }
}
