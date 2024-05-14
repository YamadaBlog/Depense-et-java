using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev.WebAPI.Controllers
{
    public class SuiviDepenseController : Controller
    {
        // GET: SuiviDepenseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SuiviDepenseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuiviDepenseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuiviDepenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuiviDepenseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuiviDepenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuiviDepenseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuiviDepenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
