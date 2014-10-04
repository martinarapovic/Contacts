using AutoMapper;
using Contacts.API.Mappings.Profiles;

namespace Contacts.API.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                mapper.AddProfile<ViewModelToDomainMappingProfile>();
                mapper.AddProfile<DomainToViewModelMappingProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}