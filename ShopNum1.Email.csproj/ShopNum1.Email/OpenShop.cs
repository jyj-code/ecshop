using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class OpenShop
	{
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string Name
		{
			get;
			set;
		}
		public string ShopID
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string ShopStatus
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string ChangeOpenShop(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$ShopID}", this.ShopID);
			text = text.Replace("{$ShopName}", this.ShopName);
			text = text.Replace("{$ShopStatus}", this.ShopStatus);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
