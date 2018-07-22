using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Data.Access.DAL;
using Contacts.Data.Model;
using Contacts.Queries;
using ContatctApp.Models;

namespace ContatctApp.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        private readonly IContactQueryProcessor _query;


        public ContactController(IContactQueryProcessor query)
        {
            _query = query;
        }

        public ContactController()
        {
            var uow = new EFUnitOfWork();
            _query = new ContactQueryProcessor(() => uow);
        }
        public ActionResult Index()
        {
            var resultSet = new List<Contact>();
            
            var models = _query.Get();
            
            Console.WriteLine(models.Count());
            
            foreach (dynamic model in models)
            {
               
                resultSet.Add(model);
            }

            return View("List",resultSet);
        }

        public ActionResult Create(Contact contactModel)
        {
            if (ModelState.IsValid)
            {
               var  contact = _query.Create(contactModel);
               return View(contact);
            }
            return View(contactModel);

        }

        [HttpPost]
        public ActionResult Edit(Contact contactModel)
        {
            if (ModelState.IsValid)
            {
                _query.Update(contactModel);
            }
            
            return View(contactModel);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {

            var model = _query.Get().Where(x=>x.Id == id).SingleOrDefault();


            return View(model);
        }

        public ActionResult Delete(long id)
        {
            _query.Delete(id);
            return RedirectToAction("Index");
        }

       

    }
}
