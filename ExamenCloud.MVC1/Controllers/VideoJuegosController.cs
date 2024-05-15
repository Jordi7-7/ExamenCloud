
using ExamenCloud.ConsumeAPI;
using ExamenCloud.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenCloud1.MVC.Controllers
{
    public class VideoJuegosController : Controller
    {
        private string urlApi;
        private string urlBase;


        public VideoJuegosController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/VideoJuegos";
            this.urlBase = configuration.GetValue("ApiUrlBase", "").ToString();

        }
        private Distribuidor[] ObtenerListaDistribuidores()
        {

            return Crud<Distribuidor>.Read(urlBase + "/Distribuidores");
        }


    // GET: EmpleadosController
    public ActionResult Index()
        {
            var data = Crud<VideoJuego>.Read(urlApi);
            return View(data);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<VideoJuego>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {

            ViewBag.DistribuidorId = ObtenerListaDistribuidores().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Nombre
            }).ToList();

            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoJuego data)
        {
            try
            {
                var newData = Crud<VideoJuego>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<VideoJuego>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VideoJuego data)
        {
            try
            {
                Crud<VideoJuego>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<VideoJuego>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VideoJuego data)
        {
            try
            {
                Crud<VideoJuego>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
