using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class SendProductAnnoucement
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
		public string ShopDoMain
		{
			get;
			set;
		}
		public string SendTime
		{
			get;
			set;
		}
		public string Memo
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string ChangeSendProductAnnoucement(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$OrderNumber}", this.OrderNumber);
			text = text.Replace("{$DoMain}", this.ShopDoMain);
			text = text.Replace("{$SendTime}", this.SendTime);
			text = text.Replace("{$Memo}", this.Memo);
			return text.Replace("{$ShopName}", this.ShopName);
		}
	}
}
