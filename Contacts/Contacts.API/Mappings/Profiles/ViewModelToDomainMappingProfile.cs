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
            
            Mapper.CreateMap<EmailAddressViewModel, EmailAddress>()
                  .ForMember(m => m.Contact, vm => vm.Ignore())
                  .ForMember(m => m.Label, vm => vm.Ignore());
            
            Mapper.CreateMap<LabelViewModel, Label>()
                .ForMember(m => m.EmailAddresses, vm => vm.Ignore())
                .ForMember(m => m.PhoneNumbers, vm => vm.Ignore());

            Mapper.CreateMap<PhoneNumberViewModel, PhoneNumber>()
                  .ForMember(m => m.Contact, vm => vm.Ignore())
                  .ForMember(m => m.Label, vm => vm.Ignore());

            Mapper.CreateMap<TagViewModel, Tag>()
                  .ForMember(m => m.Contact, vm => vm.Ignore());
        }
    }
}