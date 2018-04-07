using ShopNum1.Standard.WebReference;
using System;
using System.Collections;
using System.Xml.Serialization;
namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
	public class XmlSerializerContract : XmlSerializerImplementation
	{
		private Hashtable hashtable_0;
		private Hashtable hashtable_1;
		private Hashtable hashtable_2;
		public override XmlSerializationReader Reader
		{
			get
			{
				return new XmlSerializationReaderISmsService();
			}
		}
		public override XmlSerializationWriter Writer
		{
			get
			{
				return new XmlSerializationWriterISmsService();
			}
		}
		public override Hashtable ReadMethods
		{
			get
			{
				if (this.hashtable_0 == null)
				{
					Hashtable hashtable = new Hashtable();
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):Response"] = "Read1_accountResponse";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):OutHeaders"] = "Read2_accountResponseOutHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):Response"] = "Read3_updatePasswordResponse";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):OutHeaders"] = "Read4_Item";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):Response"] = "Read5_reportResponse";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):OutHeaders"] = "Read6_reportResponseOutHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):Response"] = "Read7_smsSendResponse";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):OutHeaders"] = "Read8_smsSendResponseOutHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):Response"] = "Read9_moResponse";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):OutHeaders"] = "Read10_moResponseOutHeaders";
					if (this.hashtable_0 == null)
					{
						this.hashtable_0 = hashtable;
					}
				}
				return this.hashtable_0;
			}
		}
		public override Hashtable WriteMethods
		{
			get
			{
				if (this.hashtable_1 == null)
				{
					Hashtable hashtable = new Hashtable();
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String)"] = "Write1_account";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):InHeaders"] = "Write2_accountInHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String)"] = "Write3_updatePassword";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):InHeaders"] = "Write4_updatePasswordInHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String)"] = "Write5_report";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):InHeaders"] = "Write6_reportInHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String)"] = "Write7_smsSend";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):InHeaders"] = "Write8_smsSendInHeaders";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String)"] = "Write9_mo";
					hashtable["ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):InHeaders"] = "Write10_moInHeaders";
					if (this.hashtable_1 == null)
					{
						this.hashtable_1 = hashtable;
					}
				}
				return this.hashtable_1;
			}
		}
		public override Hashtable TypedSerializers
		{
			get
			{
				if (this.hashtable_2 == null)
				{
					Hashtable hashtable = new Hashtable();
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String)", new ArrayOfObjectSerializer16());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer15());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):Response", new ArrayOfObjectSerializer13());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer3());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer10());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer18());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer1());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer14());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer9());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer7());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer6());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String)", new ArrayOfObjectSerializer());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String)", new ArrayOfObjectSerializer4());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String)", new ArrayOfObjectSerializer8());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String smsSend(System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String, System.String)", new ArrayOfObjectSerializer12());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String account(System.String, System.String, System.String):InHeaders", new ArrayOfObjectSerializer2());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String report(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer11());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):Response", new ArrayOfObjectSerializer17());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String updatePassword(System.String, System.String, System.String, System.String):Response", new ArrayOfObjectSerializer5());
					hashtable.Add("ShopNum1.Standard.WebReference.ISmsService:System.String mo(System.String, System.String, System.String):OutHeaders", new ArrayOfObjectSerializer19());
					if (this.hashtable_2 == null)
					{
						this.hashtable_2 = hashtable;
					}
				}
				return this.hashtable_2;
			}
		}
		public override bool CanSerialize(Type type)
		{
			return type == typeof(ISmsService);
		}
		public override XmlSerializer GetSerializer(Type type)
		{
			return null;
		}
	}
}
