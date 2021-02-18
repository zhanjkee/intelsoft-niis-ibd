namespace Intelsoft.Niis.Ibd.ContractSenderService.Core
{
    public class Constants
    {
        public class EgovGateway
        {
            public const string SendMessageTemplate = @"
<S:Envelope xmlns:S=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Header xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""/><S:Body>
            <ns2:sendMessage xmlns:ns2=""http://bip.bee.kz/AsyncChannel/v10/Types"">
            <request>
            <messageInfo>
            <messageId>{0}</messageId>
            <serviceId>{1}</serviceId>
            <messageType>REQUEST</messageType>
            <messageDate>{2}</messageDate>
            <sender>
            <senderId>{3}</senderId>
            <password>{4}</password>
            </sender>
            </messageInfo>
            <messageData>
            <data xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:type=""xs:string"">
            <MessageInfo>
            <MessageId>{0}</MessageId>
            <MessageDate>{2}</MessageDate>
            </MessageInfo>
            {5}
            </data>
            </messageData></request></ns2:sendMessage></S:Body></S:Envelope>
";

            public class Actions
            {
                public const string SendMessage = "";
            }

            public class Methods
            {
                public const string Post = "POST";
            }
        }
    }
}