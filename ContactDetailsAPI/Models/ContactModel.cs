using ContactDetailsAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetailsAPI.Models
{
    public class ContactModel: IContactModel
    {
       public int ContactId { get; set; }
       public string Fname { get; set; }
       public  string Lname { get; set; }
       public Char Gender { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public bool Status { get; set; }
    }
}
