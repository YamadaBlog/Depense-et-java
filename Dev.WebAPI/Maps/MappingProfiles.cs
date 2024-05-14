using Dev.Common.Models;
using Dev.Common.Resources;
using AutoMapper;

namespace Dev.WebAPI;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Depense, DepenseResource>();
        CreateMap<DepenseResource, Depense>();
        CreateMap<SuiviDepenseResource, SuiviDepense>();
        CreateMap<SuiviDepense, SuiviDepenseResource>();
    }
}
