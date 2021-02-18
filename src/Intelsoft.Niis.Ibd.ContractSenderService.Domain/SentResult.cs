namespace Intelsoft.Niis.Ibd.ContractSenderService.Domain
{
    public class SentResult
    {
        public SentResult(bool succeeded, string message = null)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}