namespace Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor
{
    public class SoapExecutionRequest
    {
        public SoapExecutionRequest(string uri, string action, string method, string requestData)
        {
            Uri = uri;
            Action = action;
            Method = method;
            RequestData = requestData;
        }

        public string Uri { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string RequestData { get; set; }
    }
}