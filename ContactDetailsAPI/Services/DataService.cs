using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetailsAPI.Contract;
using ContactDetailsAPI.Models;

namespace ContactDetailsAPI.Services
{
    public class DataService : IDataService
    {
        private readonly List<ContactModel> listContactDetails = new List<ContactModel>();
        public DataService()
        {
            ContactModel contactModel = new ContactModel();
            contactModel.ContactId = 1;
            contactModel.Fname = "Chandan";
            contactModel.Lname = "Choudhary";
            contactModel.Gender = 'M';
            contactModel.Phone = "7276710928";
            contactModel.Email = "chandan.pu.mca@gmail.com";
            contactModel.Status = true;
            listContactDetails.Add(contactModel);

        }
        public List<ContactModel> GetContacts()
        {         
            return listContactDetails.Where(x=> x.Status == true).ToList();
        }

        public ContactModel GetContactsById(int contactId)
        {

            return listContactDetails.FirstOrDefault(x => x.ContactId == contactId);
        }

        public void AddEditContacts(ContactModel contactModel)
        {
           if(contactModel.ContactId==0) {
                contactModel.ContactId = (listContactDetails.Max(x => x.ContactId) + 1);
                listContactDetails.Add(contactModel);
            }
            else {
                int index = listContactDetails.IndexOf(listContactDetails.FirstOrDefault(x => x.ContactId == contactModel.ContactId));
                listContactDetails[index] = contactModel;
            }

        }

        public void DeleteContacts(int ContactId)
        {
            int index = listContactDetails.IndexOf(listContactDetails.FirstOrDefault(x => x.ContactId == ContactId));
            listContactDetails[index].Status = false;
        }
    }
}
