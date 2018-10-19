using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;

        public HomeController(DataContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("IndexWithForm");
        }


        [HttpGet]
        public IActionResult ContactList()
        {
            ContactListViewModel contactListVM = new ContactListViewModel();
            contactListVM.Contacts = db.Contacts.ToList<Contact>();
            contactListVM.NumberOfContacts = contactListVM.Contacts.Count;
            return View(contactListVM);
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("ContactList");
            }
            return View("IndexWithForm");

            // return NotFound(); would return 404 error, can be used when database doesn't have the info requested
        }
    }
}