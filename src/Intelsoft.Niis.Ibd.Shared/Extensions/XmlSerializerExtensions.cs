using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Intelsoft.Niis.Ibd.Shared.Extensions
{
    public static class XmlSerializerExtensions
    {
        public static string SerializeToString<T>(this T toSerialize)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(toSerialize.GetType());
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, toSerialize, emptyNamespaces);
                return stream.ToString();
            }
        }
    }
}
