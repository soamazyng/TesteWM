using System.Web.Mvc;
using WebMotorsDesafio.Contracts;
using WebMotorsDesafio.Entities;

namespace WebMotorsDesafio.Controllers
{
    public class HomeController : Controller
    {
        private IAnuncioRepository _anuncioRepository;
        public HomeController(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
        public ActionResult Index()
        {
            var model = _anuncioRepository.GetAnuncios();
            return View(model);
        }

        public ActionResult InsertAnuncio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertAnuncio(AnuncioWebmotors model)
        {
            if (ModelState.IsValid)
            {
                _anuncioRepository.InsertAnuncio(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateAnuncio(int id)
        {
            var anuncio = _anuncioRepository.GetAnuncioById(id);

            if (anuncio == null)
            {
                return HttpNotFound();
            }

            return View(anuncio);
        }

        [HttpPost]
        public ActionResult UpdateAnuncio(AnuncioWebmotors model)
        {
            if (ModelState.IsValid)
            {
                _anuncioRepository.UpdateAnuncio(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _anuncioRepository.DeleteAnuncio(id);
            return Json(_anuncioRepository.GetAnuncios());
        }
    }
}