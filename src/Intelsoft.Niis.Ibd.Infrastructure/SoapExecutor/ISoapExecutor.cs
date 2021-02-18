namespace Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor
{
    public interface ISoapExecutor
    {
        SoapExecutionResponse Execute(SoapExecutionRequest request);
    }
}