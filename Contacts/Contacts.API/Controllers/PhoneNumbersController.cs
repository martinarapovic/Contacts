using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Contacts.API.Filters;
using Contacts.API.ViewModels;
using Contacts.Models;
using Contacts.Services;

namespace Contacts.API.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumbersController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        public IHttpActionResult Get()
        {
            var phoneNumbers = _phoneNumberService.GetPhoneNumbers();

            var phoneNumberViewModels = new List<PhoneNumberViewModel>();
            Mapper.Map(phoneNumbers, phoneNumberViewModels);

            return Ok(phoneNumberViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var phoneNumber = _phoneNumberService.GetPhoneNumber(id);
            var phoneNumberViewModel = new PhoneNumberViewModel();
            Mapper.Map(phoneNumber, phoneNumberViewModel);

            return Ok(phoneNumberViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Post(PhoneNumberViewModel phoneNumberViewModel)
        {
            var phoneNumber = new PhoneNumber();
            Mapper.Map(phoneNumberViewModel, phoneNumber);
            phoneNumber = _phoneNumberService.AddPhoneNumber(phoneNumber);
            phoneNumberViewModel.PhoneNumberId = phoneNumber.PhoneNumberId;

            return Created(Url.Link("DefaultApi", new { controller = "PhoneNumbers", id = phoneNumberViewModel.PhoneNumberId }), phoneNumberViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Put(int id, PhoneNumberViewModel phoneNumberViewModel)
        {
            phoneNumberViewModel.PhoneNumberId = id;
            var phoneNumber = _phoneNumberService.GetPhoneNumber(id);
            Mapper.Map(phoneNumberViewModel, phoneNumber);
            _phoneNumberService.UpdatePhoneNumber(phoneNumber);

            return Ok(phoneNumberViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            _phoneNumberService.DeletePhoneNumber(id);

            return Ok();
        }
    }
}