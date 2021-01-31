using System;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Builders
{
    public class SendMessageRequestBuilder
    {
        private string _messageId;
        private DateTime _messageDate;
        private string _serviceId;
        private string _senderId;
        private string _password;
        private string _data;

        public SendMessageRequestBuilder AddMessageId(string messageId)
        {
            _messageId = messageId;
            return this;
        }

        public SendMessageRequestBuilder AddMessageDate(DateTime messageDate)
        {
            _messageDate = messageDate;
            return this;
        }

        public SendMessageRequestBuilder AddServiceId(string serviceId)
        {
            _serviceId = serviceId;
            return this;
        }

        public SendMessageRequestBuilder AddSenderId(string senderId)
        {
            _senderId = senderId;
            return this;
        }

        public SendMessageRequestBuilder AddPassword(string password)
        {
            _password = password;
            return this;
        }

        public SendMessageRequestBuilder AddData(string data)
        {
            _data = data;
            return this;
        }

        public string Build()
        {
            return string.Format(Constants.EgovGateway.SendMessageTemplate, 
                _messageId,
                _serviceId,
                _messageDate.ToString("yyyy-MM-dd"),
                _senderId,
                _password,
                _data);
        }
    }
}
