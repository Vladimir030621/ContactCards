using ContactCards.Domain.Interfaces;
using ContactCards.Models;
using ContactCards.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository context;
        private IWebHostEnvironment hostingEnvironment;

        public HomeController(IContactRepository context, IWebHostEnvironment environment)
        {
            this.context = context;
            hostingEnvironment = environment;

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
        public void AddContact(ContactViewModel contactViewModel)
        {
            var currentContact = new Contact();

            currentContact.Fullname = contactViewModel.Fullname;
            currentContact.Email = contactViewModel.Email;
            currentContact.Facebook = contactViewModel.Facebook;
            currentContact.Twitter = contactViewModel.Twitter;
            currentContact.Note = contactViewModel.Note;
            currentContact.Lasttimeaccess = DateTime.Now;
            currentContact.Imagepath = SaveUploadedFile(contactViewModel.Image);

            context.AddContact(currentContact);
        }

        #region Save input csv file
        /// <summary>
        /// Save input csv file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private string SaveUploadedFile(IFormFile inputFile)
        {
            var uniqueFileName = GetUniqueFileName(inputFile.FileName);

            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            var filePath = Path.Combine(uploads, uniqueFileName);

            var newfile = new FileStream(filePath, FileMode.CreateNew);

            inputFile.CopyTo(newfile);

            newfile.Close();

            return filePath;
        }

        #endregion


        #region Save input file
        /// <summary>
        /// Save input csv file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private string SaveImageFile(IFormFile imageFile)
        {
            var uniqueFileName = GetUniqueFileName(imageFile.FileName);

            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            var filePath = Path.Combine(uploads, uniqueFileName);

            var newfile = new FileStream(filePath, FileMode.CreateNew);

            imageFile.CopyTo(newfile);

            newfile.Close();

            return filePath;
        }

        #endregion

        #region Create a unique name for input file
        /// <summary>
        /// Create a unique name for input file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);

            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        #endregion
    }
}
