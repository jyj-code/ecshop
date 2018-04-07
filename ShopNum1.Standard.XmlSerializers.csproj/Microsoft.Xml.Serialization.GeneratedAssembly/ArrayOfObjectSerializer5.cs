using System;
using System.Xml;
using System.Xml.Serialization;
namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
	public sealed class ArrayOfObjectSerializer5 : XmlSerializer1
	{
		public override bool CanDeserialize(XmlReader xmlReader)
		{
			return xmlReader.IsStartElement("updatePasswordResponse", "http://service.ewing.com");
		}
		protected override object Deserialize(XmlSerializationReader reader)
		{
			return ((XmlSerializationReaderISmsService)reader).Read3_updatePasswordResponse();
		}
	}
}
