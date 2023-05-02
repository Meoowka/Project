using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_p.Models;

namespace Library_p.Controllers
{
    public class HomeController : Controller
    {
        ILibrary repo;
        public HomeController(ILibrary r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetLibrary());
        }

        public ActionResult Details(int Lib_ID)
        {
            Library library = repo.Get(Lib_ID);
            if (library != null)
                return View(library);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library library)
        {
            repo.Create(library);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Lib_ID)
        {
            Library library = repo.Get(Lib_ID);
            if (library != null)
                return View(library);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Library library)
        {
            repo.Update(library);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Lib_ID)
        {
            Library library = repo.Get(Lib_ID);
            if (library != null)
                return View(library);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int Lib_ID)
        {
            repo.Delete(Lib_ID);
            return RedirectToAction("Index");
        }
    }
}
