using ExamenCloud.ConsumeAPI;
using ExamenCloud.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenCloud.MVC1.Controllers
{
    public class DistribuidoresController : Controller
    {
        private string urlApi;

        public DistribuidoresController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Distribuidores";
        }

        // GET: EmpleadosController
        public ActionResult Index()
        {
            var data = Crud<Distribuidor>.Read(urlApi);
            return View(data);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Distribuidor>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Distribuidor data)
        {
            try
            {
                var newData = Crud<Distribuidor>.Create(urlApi, data);
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
            var data = Crud<Distribuidor>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Distribuidor data)
        {
            try
            {
                Crud<Distribuidor>.Update(urlApi, id, data);
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
            var data = Crud<Distribuidor>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Distribuidor data)
        {
            try
            {
                Crud<Distribuidor>.Delete(urlApi, id);
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
