using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThirdPartyAService.Mappers;

namespace ThirdPartyAService;

public static class ServiceCollectionExtensions
{
    public static void AddThirdPartyAService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ThirdPartyClientOptions>(configuration.GetSection("ThirdPartyAService"));
        
        services.AddHttpClient<IThirdPartyAClient, ThirdPartyAClient>();
        services.AddTransient<IThirdPartyAClient, ThirdPartyAClient>();
        services.AddTransient<ICompanyDetailsAdapter, ThirdPartyAAdapter>();
        services.AddTransient<IAddressMapper, AddressMapper>();
        services.AddTransient<IAssociatedEntitiesMapper, AssociatedEntitiesMapper>();
        services.AddTransient<ICompanyDetailsMapper, CompanyDetailsMapper>();
        services.AddTransient<ICompanyDetailsResponseMapper, CompanyDetailsResponseMapper>();
        services.AddTransient<IDateMapper, DateMapper>();
    }
}