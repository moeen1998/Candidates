using Candidates.Core.Interfaces;
using Candidates.Core.Interfaces.Services;
using Candidates.Core.MappingProfiles;
using Candidates.EF;
using Candidates.EF.Repositories;
using Candidates.EF.Services;

namespace Candidates.API.Config;

public static class ServicesRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection provider)
    {
        provider.AddAutoMapper(typeof(CandidateProfile).Assembly);

        provider.AddScoped<IUnitOfWork, UnitOfWork>();
        
        provider.AddScoped<ICandidateService, CandidateService>();

        return provider;
    }
}

