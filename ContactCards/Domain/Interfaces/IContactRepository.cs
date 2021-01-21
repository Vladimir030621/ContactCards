using ContactCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCards.Domain.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();

        void AddContact(Contact contact);
    }
}
