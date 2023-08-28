using CompanyDetails.Core.Interfaces.Orchestrator;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDetails.Application.Orchestrators;

public static class RequestOrchestratorsServiceCollectionExtensions
{
    public static void AddRequestOrchestrators(this IServiceCollection services)
    {
        services.AddScoped<ICompanyDetailsRequestOrchestrator, CompanyDetailsRequestOrchestrator>();
    }
}