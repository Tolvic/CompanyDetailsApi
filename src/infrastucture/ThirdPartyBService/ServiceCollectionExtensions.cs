using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThirdPartyBService.Mappers;

namespace ThirdPartyBService;

public static class ServiceCollectionExtensions
{
    public static void AddThirdPartyBService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ThirdPartyBOptions>(configuration.GetSection("ThirdPartyBService"));
        
        services.AddHttpClient<IThirdPartyBClient, ThirdPartyBClient>();
        services.AddTransient<IThirdPartyBClient, ThirdPartyBClient>();
        services.AddTransient<ICompanyDetailsAdapter, ThirdPartyBAdapter>();
        services.AddTransient<IActivitiesMapper, ActivitiesMapper>();
        services.AddTransient<IAddressMapper, AddressMapper>();
        services.AddTransient<IAssociatedEntitiesMapper, AssociatedEntitiesMapper>();
        services.AddTransient<ICompanyDetailsMapper, CompanyDetailsMapper>();
        services.AddTransient<ICompanyDetailsResponseMapper, CompanyDetailsResponseMapper>();
        services.AddTransient<IDateMapper, DateMapper>();
        services.AddTransient<INameMapper, NameMapper>();
    }
}