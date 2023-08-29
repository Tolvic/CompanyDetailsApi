namespace ThirdPartyBService.Mappers;

public interface INameMapper
{
    string? GetFirstName(string? fullName);
    string? GetLastName(string? fullName);
    string? GetMiddleNames(string? fullName);
}