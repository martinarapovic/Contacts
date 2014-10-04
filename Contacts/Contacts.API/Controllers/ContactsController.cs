using AutoMapper;
using Contacts.API.ViewModels;
using Contacts.Models;
using Contacts.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Contacts.API.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IHttpActionResult Get()
        {
            var contacts = _contactService.GetContacts();
            var contactViewModels = new List<ContactViewModel>();
            Mapper.Map(contacts, contactViewModels);
            return Ok(contactViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var contact = _contactService.GetContactById(id);
            var contactViewModel = new ContactViewModel();
            Mapper.Map(contact, contactViewModel);
            return Ok(contactViewModel);
        }

        public IHttpActionResult Post(ContactViewModel contactViewModel)
        {
            var contact = new Contact();
            Mapper.Map(contactViewModel, contact);
            _contactService.AddContact(contact);
            Mapper.Map(contact, contactViewModel);
            return Created(Url.Link("DefaultApi", new {controller = "Contacts", id = contact.ContactId}), contact);
        }

        public IHttpActionResult Put(int id, ContactViewModel contactViewModel)
        {
            contactViewModel.ContactId = id;
            var contact = _contactService.GetContactById(id);
            Mapper.Map(contactViewModel, contact);
            _contactService.UpdateContact(contact);
            return Ok(contactViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return Ok();
        }
    }
}