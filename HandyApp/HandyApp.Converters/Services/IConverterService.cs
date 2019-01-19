namespace HandyApp.Converters.Services
{
    public interface IConverterService
    {
        string CalculateDistance(string convertFrom, string value, string convertTo);
        string CalculateTempereture(string convertFrom, string value, string convertTo);
    }
}