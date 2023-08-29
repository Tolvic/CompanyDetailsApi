using CompanyDetails.Core.Models;

namespace ThirdPartyBService.Mappers;

public class NameMapper : INameMapper
{
    public string? GetFirstName(string? fullName)
    {
        var names = fullName?.Split(' ');
        return names?[0];
    }
    
    public string? GetLastName(string? fullName)
    {
        var names = fullName?.Split(' ');
        return names?[^1];
    }
    
    public string? GetMiddleNames(string? fullName)
    {
        if (fullName == null) return null;
        
        var names = fullName.Split(' ');
        return string.Join(' ', names[1..^1]);

    }
}