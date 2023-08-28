namespace ThirdPartyBService.Mappers;

public interface IDateMapper
{
    public DateOnly? Map(string? date);
}