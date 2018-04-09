using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanySearchAppMVCCore2.Models;
using Newtonsoft.Json;

namespace CompanySearchAppMVCCore2.Controllers
{
    public class HomeController : Controller
    {
        private DataAccess.DataAdapter adapter = new DataAccess.DataAdapter();
        private HomeViewModel model = new HomeViewModel();
        public IActionResult Index(HomeViewModel model)
        {

            model = new HomeViewModel();
            model.Name = "";
            model.Toimipaikat = new List<RegistedOffice>();
            model.YTunnus = "";

            return View(model);
        }

        public ActionResult Update(HomeViewModel inputModel)
        {
            model = adapter.GetSearchResults(inputModel.YTunnus).Result;
            return View("Index", model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
