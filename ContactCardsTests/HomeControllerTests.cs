using ContactCards.Controllers;
using ContactCards.Domain.Interfaces;
using ContactCards.Models;
using ContactCards.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ContactCardsTests
{
    public class HomeControllerTests
    {
        private IWebHostEnvironment hostingEnvironment;

        private List<Contact> GetTestContacts()
        {
            string format = "yyyy.MM.dd HH:mm:ss:ffff";

            var testContacts = new List<Contact>
            {
                new Contact {
                    Id = 1,
                    Fullname = "Fullname1",
                    Email = "Email1@mail.com",
                    Facebook = "https://www.facebook.com/contact1",
                    Twitter = "https://twitter.com/contact1",
                    Note = "Something about contact1",
                    Imagepath = "contact1photo.jpg",
                    Lasttimeaccess = DateTime.ParseExact("2020.01.12 15:32:04:4687", format, null)
                },
                new Contact {
                    Id = 2,
                    Fullname = "Fullname2",
                    Email = "Email2@mail.com",
                    Facebook = "https://www.facebook.com/contact2",
                    Twitter = "https://twitter.com/contact2",
                    Note = "Something about contact2",
                    Imagepath = "contact2photo.jpg",
                    Lasttimeaccess = DateTime.ParseExact("2020.01.13 20:02:54:1233", format, null)
                },
                new Contact {
                    Id = 1,
                    Fullname = "Fullname1",
                    Email = "Email1@mail.com",
                    Facebook = "https://www.facebook.com/contact1",
                    Twitter = "https://twitter.com/contact1",
                    Note = "Something about contact1",
                    Imagepath = "contact1photo.jpg",
                    Lasttimeaccess = DateTime.ParseExact("2020.01.14 10:10:32:1875", format, null)
                }
            };

            return testContacts;
        }


        [Fact]
        public void IndexReturnsViewWithContacts()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(repo => repo.GetContacts()).Returns(GetTestContacts());
            HomeController homeController = new HomeController(mock.Object, hostingEnvironment);

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Contact>>(viewResult.Model);
            Assert.Equal(GetTestContacts().Count, model.Count);
        }

        [Fact]
        public void AddContactReturnsView()
        {
            var mock = new Mock<IContactRepository>();
            HomeController homeController = new HomeController(mock.Object, hostingEnvironment);

            var result = homeController.AddContact();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddContactReturnsBadRequest()
        {
            var mock = new Mock<IContactRepository>();
            HomeController homeController = new HomeController(mock.Object, hostingEnvironment);
            ContactViewModel contactViewModel = null;

            var result = homeController.AddContact(contactViewModel);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
