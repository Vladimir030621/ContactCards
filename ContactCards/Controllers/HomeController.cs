using ContactCards.Domain.Interfaces;
using ContactCards.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository context;

        public HomeController(IContactRepository context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contacts = context.GetContacts().ToList();

            return View(contacts);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public void AddContact(Contact contact)
        {

        }
    }
}
