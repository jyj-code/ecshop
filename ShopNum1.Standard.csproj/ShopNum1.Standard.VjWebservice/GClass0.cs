using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
namespace ShopNum1.Standard.VjWebservice
{
	[GeneratedCode("System.Xml", "2.0.50727.1433"), DesignerCategory("code"), DebuggerStepThrough, XmlType(Namespace = "http://sdkhttp.eucp.b2m.cn/")]
	[Serializable]
	public class GClass0
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string addSerial
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string addSerialRev
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string channelnumber
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string mobileNumber
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string sentTime
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string smsContent
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
	}
}
