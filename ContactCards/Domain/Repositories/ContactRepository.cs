using ContactCards.Domain.Interfaces;
using ContactCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.Domain.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsdbContext context;

        public ContactRepository(ContactsdbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return context.Contacts;
        }

        public void AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}
