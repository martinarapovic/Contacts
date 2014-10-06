using AutoMapper;
using Contacts.API.ViewModels;
using Contacts.Models;

namespace Contacts.API.Mappings.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<EmailAddress, EmailAddressViewModel>();
            Mapper.CreateMap<Label, LabelViewModel>();
            Mapper.CreateMap<PhoneNumber, PhoneNumberViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}