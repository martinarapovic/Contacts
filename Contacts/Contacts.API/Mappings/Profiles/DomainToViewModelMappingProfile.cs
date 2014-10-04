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
            // TODO: Define mapping configurations when model is fully defined...
            Mapper.CreateMap<Contact, ContactViewModel>();
        }
    }
}