using System;
using System.Xml;
using System.Xml.Serialization;
namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
	public sealed class ArrayOfObjectSerializer15 : XmlSerializer1
	{
		public override bool CanDeserialize(XmlReader xmlReader)
		{
			return xmlReader.IsStartElement("smsSendResponseOutHeaders", "http://service.ewing.com");
		}
		protected override object Deserialize(XmlSerializationReader reader)
		{
			return ((XmlSerializationReaderISmsService)reader).Read8_smsSendResponseOutHeaders();
		}
	}
}
