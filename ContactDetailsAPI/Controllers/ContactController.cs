using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetailsAPI.Contract;
using ContactDetailsAPI.Models;
using ContactDetailsAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactDetailsAPI.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    public class ContactController : ControllerBase
    {
        private readonly IDataService _dataService;
        public ContactController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("contacts")]
        [HttpGet]
        public IActionResult GetContacts()
        {
           
         return Ok(_dataService.GetContacts());
          
        }

        [Route("contacts/{contactId}")]
        [HttpGet]
        public IActionResult GetContact(int contactId)
        {
            var record = _dataService.GetContactsById(contactId);

            if (record != null)
                return Ok(record);
            else
                return NotFound();

        }

        [Route("contacts")]
        [HttpPost]
        public IActionResult AddEditContacts([FromBody]ContactModel contactModel)
        {
               _dataService.AddEditContacts(contactModel);

            return Ok("Success");

        }
        [Route("contacts")]
        [HttpDelete]
        public IActionResult DeleteContacts([FromBody]int contactId)
        {
            _dataService.DeleteContacts(contactId);

            return Ok("Success");

        }
    }
}