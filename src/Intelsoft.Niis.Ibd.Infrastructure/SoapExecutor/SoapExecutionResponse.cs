namespace Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor
{
    public class SoapExecutionResponse
    {
        public SoapExecutionResponse(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}