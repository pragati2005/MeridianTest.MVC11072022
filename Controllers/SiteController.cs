using Meridian.Example.MVC.EF;
using Meridian.Example.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meridian.Example.MVC.Controllers
{
    public class SiteController : Controller
    {
        DocumentsContext dcb;
        public SiteController(DocumentsContext documentsContext)
        {
            this.dcb = documentsContext;
        }
        // GET: SiteController
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Site/AddSiteById/{id}")]
        public ActionResult AddSiteById(int id)
        {
            var value = dcb.Sites.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Existing"] = value;
          
                return View("Views/Site/Add.cshtml");          
            

        }
        [HttpPost]

        public ActionResult AddSite(Site site)
        {
            if (site.Id > 0)
            {
                var value = dcb.Sites.Where(x => x.Id == site.Id).FirstOrDefault();
                value.Name = site.Name;
                value.Code = site.Code;
                dcb.Sites.Update(value);
                if (dcb.SaveChanges() >= 0)
                {
                    ViewData["AllSites"] = dcb.Sites.ToList();
                    return View("Views/Site/SiteList.cshtml");
                }
                else
                {
                    return View("Views/Shared/Error.cshtml");
                }

            }
            else
            {
                this.dcb.Add(site);
                var result = this.dcb.SaveChanges();
                if (dcb.SaveChanges() == 0)
                {
                    ViewData["AllSites"] = dcb.Sites.ToList();

                    return View("Views/Site/SiteList.cshtml");
                }
                else
                {
                    return View("Views/Shared/Error.cshtml");
                }
            }
        }

        // GET: SiteController/Details/5
        public ActionResult EditSite()
        {
            ViewData["AllSites"] = dcb.Sites.ToList();

            return View("Views/Site/SiteList.cshtml");

        }

        // GET: SiteController/Create

    }
}
