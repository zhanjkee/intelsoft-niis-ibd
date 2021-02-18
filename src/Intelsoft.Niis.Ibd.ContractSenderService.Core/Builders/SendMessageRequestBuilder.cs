using System;
using Intelsoft.Niis.Ibd.Shared.Extensions;

namespace Intelsoft.Niis.Ibd.ContractSenderService.Core.Builders
{
    public class SendMessageRequestBuilder
    {
        private string _data;
        private string _edsPassword;
        private string _edsPath;
        private DateTime _messageDate;
        private string _messageId;
        private bool _needToSignRequest;
        private string _password;
        private string _senderId;
        private string _serviceId;

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

        public SendMessageRequestBuilder NeedToSignRequest(bool needToSignRequest)
        {
            _needToSignRequest = needToSignRequest;
            return this;
        }

        public SendMessageRequestBuilder SetEdsPath(string edsPath)
        {
            _edsPath = edsPath;
            return this;
        }

        public SendMessageRequestBuilder SetEdsPassword(string edsPassword)
        {
            _edsPassword = edsPassword;
            return this;
        }

        public string Build()
        {
            var request = string.Format(Constants.EgovGateway.SendMessageTemplate,
                _messageId,
                _serviceId,
                _messageDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                _senderId,
                _password,
                _data);

            if (_needToSignRequest)
            {
                // TODO: Sign xml.
            }

            var formattedXml = request.FormatXml();

            return formattedXml;
        }
    }
}