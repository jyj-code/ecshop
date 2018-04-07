using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class UpdateOrderStute
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
		[CompilerGenerated]
		private string string_5;
		public string Name
		{
			get;
			set;
		}
		public string OrderNumber
		{
			get;
			set;
		}
		public string OrderStatus
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string UpdateTime
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string ChangeUpdateOrderStute(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$OrderNumber}", this.OrderNumber);
			text = text.Replace("{$OrderStatus}", this.OrderStatus);
			text = text.Replace("{$ShopName}", this.ShopName);
			text = text.Replace("{$UpdateTime}", this.UpdateTime);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
