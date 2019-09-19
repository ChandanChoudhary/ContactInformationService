using ContactDetailsAPI.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetailsAPI.Models
{
    public class ContactModel: IContactModel
    {
    
        [Key]
        public int ContactId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Fname"), MaxLength(30)]
        [Display(Name = "Fname")]
        public string Fname { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Lname"), MaxLength(30)]
        [Display(Name = "Lname")]
        public  string Lname { get; set; }       
        [Required(ErrorMessage = "Please enter Gender")]
        [Display(Name = "Gender")]
        public Char Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email Id")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [MaxLength(10), MinLength(6)]
        public string Phone { get; set; }        
        public bool Status { get; set; }
    }
}
