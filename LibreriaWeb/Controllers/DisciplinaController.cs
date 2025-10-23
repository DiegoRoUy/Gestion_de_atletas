using LibreriaWeb.Models.Disciplinas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LibreriaWeb.Controllers
{
    public class DisciplinaController : Controller
    {


        // GET: DisciplinaController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }

            IEnumerable<DisciplinaListadoViewModel> listaDisciplinas = new List<DisciplinaListadoViewModel>();

            HttpClient cliente = new HttpClient();
            string url = "http://localhost:5135";
            cliente.BaseAddress = new Uri(url);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Disciplina");
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
                if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
                listaDisciplinas = JsonConvert.DeserializeObject<IEnumerable<DisciplinaListadoViewModel>>(datos);
            }
            else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
            {
                return RedirectToAction("IniciarSesion", "Usuario");
            }
            else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = datos;
            }

            return View(listaDisciplinas);

        }

      


        // GET: DisciplinaController/Create
        public ActionResult Create()
        {

            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }

            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisciplinaViewModel disciplinaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpClient cliente = new HttpClient();
                    string url = "http://localhost:5135";
                    cliente.BaseAddress = new Uri(url);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    string email = HttpContext.Session.GetString("email");
                    disciplinaVM.Email = email;
                    Task<HttpResponseMessage> tarea = cliente.PostAsJsonAsync(url + "/api/Disciplina", disciplinaVM);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["Exito"] = "Disciplina " + "'" + disciplinaVM.Nombre + "'" + " dada de alta correctamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
                    {
                        return RedirectToAction("IniciarSesion", "Usuario");
                    }
                    else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                        contenido.Wait();
                        string datos = contenido.Result;
                        ViewBag.Mensaje = datos;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Error";
                }
            }
            return View();
        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaListadoViewModel disciplinaVM = new DisciplinaListadoViewModel();
            try
            {
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Disciplina/ById/" + id);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {    
                    disciplinaVM = JsonConvert.DeserializeObject<DisciplinaListadoViewModel>(datos);
                }
                else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("IniciarSesion", "Usuario");
                }
                else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mensaje = datos;
                }
                return View(disciplinaVM);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }

            return View(disciplinaVM);
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisciplinaListadoViewModel disciplinaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                string email = HttpContext.Session.GetString("email");
                disciplinaVM.Email = email;
                Task<HttpResponseMessage> tarea = cliente.PutAsJsonAsync(url + "/api/Disciplina/" + id, disciplinaVM);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    TempData["Exito"] = "Disciplina " + "'" + disciplinaVM.Nombre + "'" + " fue editada correctamente";
                    return RedirectToAction(nameof(Index));
                }
                else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("IniciarSesion", "Usuario");
                }
                else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                    contenido.Wait();
                    string datos = contenido.Result;
                    ViewBag.Mensaje = datos;
                }                
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(disciplinaVM);
        }

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaListadoViewModel disciplinaVM = new DisciplinaListadoViewModel();

            try
            {
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Disciplina/ById/" + id);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    disciplinaVM = JsonConvert.DeserializeObject<DisciplinaListadoViewModel>(datos);
                }
                else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("IniciarSesion", "Usuario");
                }
                else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mensaje = datos;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }

            return View(disciplinaVM);
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DisciplinaListadoViewModel disciplinaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                string email = HttpContext.Session.GetString("email");
                Task<HttpResponseMessage> tarea = cliente.DeleteAsync(url + "/api/Disciplina/" + id + "/" + email);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    TempData["Exito"] = "Disciplina eliminada correctamente";
                    return RedirectToAction(nameof(Index));
                }
                else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("IniciarSesion", "Usuario");
                }
                else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (StatusCodes.Status409Conflict == (int)respuesta.StatusCode)
                {
                    TempData["Error"] = "No se puede eliminar la disciplina ya que tiene al menos un atleta asociado";
                    return RedirectToAction(nameof(Index));
                }    
                else
                {
                    Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                    contenido.Wait();
                    string datos = contenido.Result;
                    ViewBag.Mensaje = datos;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }

            return View();
        }
        // GET: DisciplinaController/BuscarDisciplinaPorID/5
        public ActionResult BuscarDisciplniaPorID()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaIDViewModel disciplinaIdVm = new DisciplinaIDViewModel();
            return View(disciplinaIdVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarDisciplniaPorID(DisciplinaIDViewModel disciplinaIdVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaListadoViewModel disciplinaVM = new DisciplinaListadoViewModel();
            int id = disciplinaIdVm.IdDisciplina;
            HttpClient cliente = new HttpClient();
            string url = "http://localhost:5135"; cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            cliente.BaseAddress = new Uri(url);

            Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Disciplina/ById/" + id);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                disciplinaVM = JsonConvert.DeserializeObject<DisciplinaListadoViewModel>(datos);
                return View("ResultadoBusquedaId", disciplinaVM);
            }
            else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
            {
                return RedirectToAction("IniciarSesion", "Usuario");
            }
            else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = datos;
                return View();
            }


        }


        public ActionResult ResultadoBusquedaId(DisciplinaListadoViewModel disciplinaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(disciplinaVM);
        }




        public ActionResult BuscarDisciplinaPorNombre()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaNombreViewModel disciplinaNombreVm = new DisciplinaNombreViewModel();
            return View(disciplinaNombreVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarDisciplinaPorNombre(DisciplinaNombreViewModel disciplinaNombreVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            DisciplinaListadoViewModel disciplinaVM = new DisciplinaListadoViewModel();
            string nombre = disciplinaNombreVm.Nombre.ToUpper();
            HttpClient cliente = new HttpClient();
            string url = "http://localhost:5135";
            cliente.BaseAddress = new Uri(url);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Disciplina/ByName/" + nombre);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                disciplinaVM = JsonConvert.DeserializeObject<DisciplinaListadoViewModel>(datos);
                return View("ResultadoBusquedaNombre", disciplinaVM);
            }
            else if (StatusCodes.Status401Unauthorized == (int)respuesta.StatusCode)
            {
                return RedirectToAction("IniciarSesion", "Usuario");
            }
            else if (StatusCodes.Status403Forbidden == (int)respuesta.StatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = datos;
                return View();
            }


        }

        public ActionResult ResultadoBusquedaNombre(DisciplinaListadoViewModel disciplinaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(disciplinaVM);
        }
    }
}
