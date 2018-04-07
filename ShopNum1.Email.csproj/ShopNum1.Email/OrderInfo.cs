using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class OrderInfo
	{
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string Name
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string OrderNumber
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string ChangeOrderInfo(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$ShopName}", this.ShopName);
			text = text.Replace("{$OrderNumber}", this.OrderNumber);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
