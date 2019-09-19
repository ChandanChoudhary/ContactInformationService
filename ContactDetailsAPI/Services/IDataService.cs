using ContactDetailsAPI.Contract;
using ContactDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetailsAPI.Services
{
  public  interface IDataService
    {
        List<ContactModel> GetContacts();
        ContactModel GetContactsById(int ContactId);
        void AddEditContacts(ContactModel contactModel);
        void DeleteContacts(int ContactId);
    }
}
