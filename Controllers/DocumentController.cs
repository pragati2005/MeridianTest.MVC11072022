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
    
    public class DocumentController : Controller
    {
        DocumentsContext dcb;
        public DocumentController(DocumentsContext documentsContext)
        {
            this.dcb = documentsContext;
        }
        
        public ActionResult Add()
        {
            return View();

        }
       
        public ActionResult EditDocument()
        {
            ViewData["AllDocuments"] = dcb.DocumentTypes.ToList();

            return View();

        }

        [HttpPost]
         public ActionResult AddDocument(DocumentType documentType)
        {
            if (documentType.Id > 0)
            {
                var value = dcb.DocumentTypes.Where(x => x.Id == documentType.Id).FirstOrDefault();
                value.Type = documentType.Type;
                dcb.Update(value);
                if (dcb.SaveChanges() >= 0)
                {
                    ViewData["AllDocuments"] = dcb.DocumentTypes.ToList();
                    return View("Views/Document/EditDocument.cshtml");
                }
                else
                {
                    return View("Views/Shared/Error.cshtml");
                }

            }
            else
            {
                dcb.Add(documentType);
                var result = dcb.SaveChanges();
                if (dcb.SaveChanges() == 0)
                {
                    ViewData["AllDocuments"] = dcb.DocumentTypes.ToList();

                    return View("Views/Document/EditDocument.cshtml");
                }
                else
                {
                    return View("Views/Shared/Error.cshtml");
                }
            }
            
          }
       [Route("Document/AddDocumentById/{id}")]
        public ActionResult AddDocumentById(int id)
        {
            var value = dcb.DocumentTypes.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Existing"] = value;
            
                return View("Views/Document/Add.cshtml");
                        

        }
        [Route("Site/AddSiteById/{id}")]
        public ActionResult AddSiteById(int id)
        {
            var value = dcb.Sites.Where(x => x.Id == id).FirstOrDefault();
            ViewData["Existing"] = value;
            if (true)
            {
                return View("Views/Site/Add.cshtml");
            }
            else
            {
                return View("Views/Shared/Error.cshtml");
            }

        }



        public ActionResult EditDocumentId(DocumentType documentType)
        {
           var record = dcb.DocumentTypes.Where(d => d.Id == documentType.Id).First();
            record.name = documentType.name;
           
            var result = dcb.SaveChanges();
            if (dcb.SaveChanges() == 0)
            {
                return View("Views/Document/Add.cshtml");
            }
            else
            {
                return View("Views/Shared/Error.cshtml");
            }

        }
    }
}
