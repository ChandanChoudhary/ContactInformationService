using ContactDetailsAPI.Controllers;
using ContactDetailsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ContactDetailsXUnitTest
{
    public class ContactControllerTest
    {
        private readonly ContactController _controller;
        private readonly IDataService _dataService;
        public ContactControllerTest()
        {
            _dataService = new DataService();
            _controller = new ContactController(_dataService);
        }
        [Fact]
        public void GetContacts_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetContacts();

            var okResult = result as OkObjectResult;

            // assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void GetContactsById_NotFoundResult()
        {
            // Act
            var result = _controller.GetContact(2);

            var notFoundResult = result as NotFoundResult;

            // assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void SaveContacts_CreatedAtActionResult()
        {
            // Act
            var result = _controller.AddEditContacts(new ContactDetailsAPI.Models.ContactModel());

            var okResult = result as OkObjectResult;

            // assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
