using Microsoft.Extensions.DependencyInjection;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public static class ConsolidationHandlerServiceCollectionExtensions
{
    public static IServiceCollection AddConsolidationService(this IServiceCollection services)
    {
        services.AddTransient<ICompanyDetailsConsolidationOrchestrator, CompanyDetailsConsolidationOrchestrator>();
        services.AddTransient<ValidationHandler>();
        services.AddTransient<CompanyDetailsHandler>();
        services.AddTransient<ActivitiesHandler>();
        services.AddTransient<AssociatedPersonsHandler>();
        services.AddTransient<AssociatedCompanyHandler>();
        return services;
    }
}