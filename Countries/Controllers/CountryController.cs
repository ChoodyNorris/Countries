using Countries.Models;
using Countries.Providers;
using Countries.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Countries.Controllers
{
    public class CountryController : Controller
    {
        private ICountryProvider _provider;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stub()
        {
            ViewBag.Title = "Stub";

            _provider = new CountryProvider(new CountryReaderStub());

            return View("CountryList", _provider.GetCountries());
        }

        public ActionResult XML()
        {
            ViewBag.Title = "XML";

            string strPath = HttpRuntime.BinDirectory + "\\Countries.xml";
            _provider = new CountryProvider(new CountryReader(strPath));

            return View("CountryList", _provider.GetCountries());
        }

        public ActionResult Add()
        {       
            ViewBag.Title = "Dodaj";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Country model)
        {
            if (ModelState.IsValid)
            {
                string strPath = HttpRuntime.BinDirectory + "\\Countries.xml";
                _provider = new CountryProvider(new CountryReader(strPath));

                List<Country> result = _provider.GetCountries().ToList();
                result.Add(model);

                if(_provider.SaveCountries(result))
                    return RedirectToAction("Index", "Country");
            }
            return View();
        }
    }
}