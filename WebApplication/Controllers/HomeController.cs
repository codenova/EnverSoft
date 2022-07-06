using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult CompanyDetail(Models.CompanyDetail companyDetail)
        {
            WebService webService = new WebService();
            webService.saveCompanyDetail(companyDetail.name, companyDetail.telephone);
            ViewBag.Status = "Saved";
            return View("Index");
        }

        [HttpPost]
        public ActionResult Search(Models.CompanyDetail companyDetail)
        {
            WebService webService = new WebService();
            ViewBag.telephone = webService.Search(companyDetail.name);
            
            return View("About");
        }
        public ActionResult Index()
        {
            CompanyDetail model = new CompanyDetail();
            model.name = "";
            model.telephone = "";
            return View(model);
        }

        public ActionResult About()
        {
            CompanyDetail model = new CompanyDetail();
            model.name = "";
            model.telephone = "";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}