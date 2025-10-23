
using LibreriaWeb.Models.Atletas;
using LibreriaWeb.Models.Disciplinas;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibreriaWeb.Controllers
{
    public class AtletaController : Controller
    {
        // GET: AtletaController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != null ) { return RedirectToAction("Index", "Home"); }

            IEnumerable<AtletaListadoViewModel> listaAtletas = new List<AtletaListadoViewModel>();
            HttpClient cliente = new HttpClient();
            string url = "http://localhost:5135/api/Atleta";
            cliente.BaseAddress = new Uri(url);
            Task<HttpResponseMessage> tarea = cliente.GetAsync(url);
            tarea.Wait();
            HttpResponseMessage respuesta = tarea.Result;
            Task<string> contenido = respuesta.Content.ReadAsStringAsync();
            contenido.Wait();
            string datos = contenido.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                listaAtletas = JsonConvert.DeserializeObject<IEnumerable<AtletaListadoViewModel>>(datos);
            }
            else
            {
                ViewBag.Message = datos;
            }
            return View(listaAtletas);
        }
           
              

        //HTTPGET
        public ActionResult ListaAteltasXDisciplina()
        {
            if (HttpContext.Session.GetString("rol") != null) { return RedirectToAction("Index", "Home"); }
            AtletaDisciplinaIdViewModel atletavm = new AtletaDisciplinaIdViewModel();
            try
            {
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135/api/Atleta";
                cliente.BaseAddress = new Uri(url);
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    atletavm = JsonConvert.DeserializeObject<AtletaDisciplinaIdViewModel>(datos);
                }
                else
                {
                    ViewBag.Mensaje = datos;
                }
                return View(atletavm);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }

            return View(atletavm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListaAteltasXDisciplina(AtletaDisciplinaIdViewModel atletaVM)
        {
            if (HttpContext.Session.GetString("rol") != null) { return RedirectToAction("Index", "Home"); }
            try
            {
                IEnumerable<AtletaListadoViewModel> listaAtletasVm = new List<AtletaListadoViewModel>();
                
                HttpClient cliente = new HttpClient();
                string url = "http://localhost:5135/api/Atleta";
                cliente.BaseAddress = new Uri(url);
                Task<HttpResponseMessage> tarea = cliente.GetAsync(url + "/" + atletaVM.DisciplinaId);
                tarea.Wait();
                HttpResponseMessage respuesta = tarea.Result;
                Task<string> contenido = respuesta.Content.ReadAsStringAsync();
                contenido.Wait();
                string datos = contenido.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    listaAtletasVm = JsonConvert.DeserializeObject<IEnumerable<AtletaListadoViewModel>>(datos);
                }
                else
                {
                    ViewBag.Message = datos;
                }
                if (listaAtletasVm.Count() == 0)
                {
                    ViewBag.Mensaje = "No hay Atletas con esa Disciplina";
                }
                return View("ResultadoListaAteltasXDisciplina", listaAtletasVm);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult ResultadoListaAteltasXDisciplina(AtletaListadoViewModel listaAtletasVm)
        {
            if (HttpContext.Session.GetString("rol") != null) { return RedirectToAction("Index", "Home"); }
            if (listaAtletasVm == null)
            {
                ViewBag.Mensaje = "No hay Atletas con ese ID";
            }
            return View(listaAtletasVm);
        }

    }
}
