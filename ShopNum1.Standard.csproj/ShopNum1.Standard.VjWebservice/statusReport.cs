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
	public class statusReport
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private int int_0;
		private long long_0;
		private string string_4;
		private string string_5;
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string errorCode
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
		public string memo
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
		public string mobile
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
		public string receiveDate
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
		public int reportStatus
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public long seqID
		{
			get
			{
				return this.long_0;
			}
			set
			{
				this.long_0 = value;
			}
		}
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string serviceCodeAdd
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
		public string submitDate
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
