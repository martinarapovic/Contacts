using AutoMapper;
using Contacts.API.Filters;
using Contacts.API.ViewModels;
using Contacts.Models;
using Contacts.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Contacts.API.Controllers
{
    public class EmailAddressesController : ApiController
    {
        private readonly IEmailAddressService _emailAddressService;

        public EmailAddressesController(IEmailAddressService emailAddressService)
        {
            _emailAddressService = emailAddressService;
        }

        public IHttpActionResult Get()
        {
            var emailAddresses = _emailAddressService.GetEmailAddresses();

            var emailAddressViewModels = new List<EmailAddressViewModel>();
            Mapper.Map(emailAddresses, emailAddressViewModels);

            return Ok(emailAddressViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var emailAddress = _emailAddressService.GetEmailAddress(id);
            var emailAddressViewModel = new EmailAddressViewModel();
            Mapper.Map(emailAddress, emailAddressViewModel);

            return Ok(emailAddressViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Post(EmailAddressViewModel emailAddressViewModel)
        {
            var emailAddress = new EmailAddress();
            Mapper.Map(emailAddressViewModel, emailAddress);
            emailAddress = _emailAddressService.AddEmailAddress(emailAddress);
            emailAddressViewModel.EmailAddressId = emailAddress.EmailAddressId;

            return Created(Url.Link("DefaultApi", new { controller = "EmailAddresses", id = emailAddressViewModel.EmailAddressId }), emailAddressViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Put(int id, EmailAddressViewModel emailAddressViewModel)
        {
            emailAddressViewModel.EmailAddressId = id;
            var emailAddress = _emailAddressService.GetEmailAddress(id);
            Mapper.Map(emailAddressViewModel, emailAddress);
            _emailAddressService.UpdateEmailAddress(emailAddress);

            return Ok(emailAddressViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            _emailAddressService.DeleteEmailAddress(id);

            return Ok();
        }
    }
}