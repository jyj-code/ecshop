using System;
using System.Text;
namespace ShopNum1.Common
{
	public class XMLDecorator : XMLComponent
	{
		protected XMLComponent ActualXMLComponent;
		private string string_8;
		public XMLDecorator(string string_9)
		{
			this.string_8 = string_9;
		}
		public void SetXMLComponent(XMLComponent xmlcomponent_0)
		{
			this.ActualXMLComponent = xmlcomponent_0;
			this.GetSettingFromComponent(xmlcomponent_0);
		}
		public void GetSettingFromComponent(XMLComponent xmlcomponent_0)
		{
			base.FileEncode = xmlcomponent_0.FileEncode;
			base.FileOutPath = xmlcomponent_0.FileOutPath;
			base.Indentation = xmlcomponent_0.Indentation;
			base.SourceDataTable = xmlcomponent_0.SourceDataTable;
			base.StartElement = xmlcomponent_0.StartElement;
			base.Version = xmlcomponent_0.Version;
			base.XslLink = xmlcomponent_0.XslLink;
			base.Key = xmlcomponent_0.Key;
			base.ParentField = xmlcomponent_0.ParentField;
		}
		public override string WriteFile()
		{
			if (this.ActualXMLComponent != null)
			{
				this.ActualXMLComponent.WriteFile();
			}
			return null;
		}
		public override StringBuilder WriteStringBuilder()
		{
			StringBuilder result;
			if (this.ActualXMLComponent != null)
			{
				result = this.ActualXMLComponent.WriteStringBuilder();
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
