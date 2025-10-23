
using LibreriaWeb.Models.Atletas;
using LibreriaWeb.Models.Disciplinas;
using LibreriaWeb.Models.Eventos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace LibreriaWeb.Controllers
{
    public class EventoController : Controller
    {


        
        //GET
        public ActionResult GetEventosXDisciplinaId()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            EventoPorDisciplinaIdViewModel eventoIdDisciplinaVm = new EventoPorDisciplinaIdViewModel();


            return View(eventoIdDisciplinaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetEventosXDisciplinaId(EventoPorDisciplinaIdViewModel eventoIdDisciplinaVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                IEnumerable<EventoListadoViewModel> listaEventosVM = new List<EventoListadoViewModel>();
                int id = eventoIdDisciplinaVm.DisciplinaId;
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Evento/ByIdDisciplina/" + id);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    listaEventosVM = JsonConvert.DeserializeObject<IEnumerable<EventoListadoViewModel>>(datos);
                    if (listaEventosVM.Count() == 0)
                    {
                        ViewBag.Mensaje = "No hay Eventos con la Disciplina ingresada";
                    }
                    return View("ResultadoBusquedaDisciplinaID", listaEventosVM);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public ActionResult ResultadoBusquedaDisciplinaID(EventoListadoViewModel eventosVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(eventosVm);
        }

        //GET EventosPorFecha
        public ActionResult BuscarEventosFecha()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            EventoFechaViewModel eventoFechaVm = new EventoFechaViewModel();
            return View(eventoFechaVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult BuscarEventosFecha(EventoFechaViewModel fechaVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                IEnumerable<EventoListadoViewModel> listaEventosVM = new List<EventoListadoViewModel>();
                string FechaInicio = fechaVM.FechaInicio.ToString("dd-MM-yyyy");
                string FechaFin = fechaVM.FechaFin.ToString("dd-MM-yyyy");
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Evento/ByFechas/"+ FechaInicio + "/" + FechaFin);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    listaEventosVM = JsonConvert.DeserializeObject<IEnumerable<EventoListadoViewModel>>(datos);
                    if (listaEventosVM.Count() == 0)
                    {
                        ViewBag.Mensaje = "No se inicio ningun evento entre " + FechaInicio + " al "+ FechaFin;
                    }
                    return View("ResultadoBusquedaPorFechaEventos", listaEventosVM);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public ActionResult ResultadoBusquedaPorFechaEventos(EventoListadoViewModel listaEventoVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(listaEventoVM);
        }

        public ActionResult BuscarEventosPorTexto()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            EventoPorTextoViewModel eventoTextoVm = new EventoPorTextoViewModel();
            return View(eventoTextoVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult BuscarEventosPorTexto(EventoPorTextoViewModel eventoTextoVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                IEnumerable<EventoListadoViewModel> listaEventosVM = new List<EventoListadoViewModel>();
                string texto= eventoTextoVm.NombrePrueba;                
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Evento/ByTexto/"+ texto);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    listaEventosVM = JsonConvert.DeserializeObject<IEnumerable<EventoListadoViewModel>>(datos); 
                    if (listaEventosVM.Count() == 0)
                    {
                        ViewBag.Mensaje = "No hay eventos que contenga "+"'" + texto + "'";
                    }
                    return View("ResultadoBusquedaPorTexto", listaEventosVM);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public ActionResult ResultadoBusquedaPorTexto(EventoListadoViewModel listaEventoVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(listaEventoVM);
        }

        public ActionResult BuscarEventosPorPuntaje()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            EventoPorPuntajeViewModel eventoFechaVm = new EventoPorPuntajeViewModel();
            return View(eventoFechaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarEventosPorPuntaje(EventoPorPuntajeViewModel eventoVm)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            try
            {
                IEnumerable<EventoListadoViewModel> listaEventosVM = new List<EventoListadoViewModel>();
                decimal puntaje1 = eventoVm.Puntaje1;
                 decimal puntaje2 = eventoVm.Puntaje2;
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135";
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/api/Evento/ByPuntaje/"+ puntaje1 + "/" + puntaje2);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    listaEventosVM = JsonConvert.DeserializeObject<IEnumerable<EventoListadoViewModel>>(datos);
                    if (listaEventosVM.Count() == 0)
                    {
                        ViewBag.Mensaje = "No hay eventos con el rango de puntaje " + puntaje1+ " al " + puntaje2;
                    }
                    return View("ResultadoBusquedaPorPuntaje", listaEventosVM);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public ActionResult ResultadoBusquedaPorPuntaje(EventoListadoViewModel listaEventoVM)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Digitador" || HttpContext.Session.GetString("token") == null) { return RedirectToAction("Index", "Home"); }
            return View(listaEventoVM);
        }
         
    }
}
