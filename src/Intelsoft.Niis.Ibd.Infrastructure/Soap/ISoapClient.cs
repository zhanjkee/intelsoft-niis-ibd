namespace Intelsoft.Niis.Ibd.Infrastructure.Soap
{
    public interface ISoapClient
    {
        string Invoke(string action, string method, string requestData);
    }
}