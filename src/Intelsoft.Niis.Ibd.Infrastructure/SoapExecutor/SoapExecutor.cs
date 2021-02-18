using System.IO;
using System.Net;
using System.Xml;

namespace Intelsoft.Niis.Ibd.Infrastructure.SoapExecutor
{
    public class SoapExecutor : ISoapExecutor
    {
        public SoapExecutionResponse Execute(SoapExecutionRequest request)
        {
            var executedResult = ExecuteInternal(request.Uri, request.Action, request.Method, request.RequestData);

            return string.IsNullOrEmpty(executedResult)
                ? null
                : new SoapExecutionResponse(executedResult);
        }

        internal string ExecuteInternal(string uri, string action, string method, string requestData)
        {
            var soapEnvelopeXml = CreateSoapEnvelope(requestData);
            var webRequest = CreateWebRequest(uri, action, method);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // Begin async call to web request.
            var asyncResult = webRequest.BeginGetResponse(null, null);

            // Suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // Get the response from the completed web request.
            using (var webResponse = webRequest.EndGetResponse(asyncResult))
            {
                var stream = webResponse.GetResponseStream();
                if (stream == null) return null;

                string soapResult;
                using (var rd = new StreamReader(stream))
                {
                    soapResult = rd.ReadToEnd();
                }

                return soapResult;
            }
        }

        private static HttpWebRequest CreateWebRequest(string uri, string action, string method)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(uri);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = method;
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string requestData)
        {
            var soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(requestData);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (var stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}