using AutoMapper;
using Contacts.API.ViewModels;
using Contacts.Models;

namespace Contacts.API.Mappings.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            // TODO: Define mapping configurations when model is fully defined...
            Mapper.CreateMap<ContactViewModel, Contact>();
        }
    }
}