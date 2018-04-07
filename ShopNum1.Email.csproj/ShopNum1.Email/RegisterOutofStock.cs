using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class RegisterOutofStock
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
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private string string_8;
		[CompilerGenerated]
		private string string_9;
		public string MemberName
		{
			get;
			set;
		}
		public string SendTime
		{
			get;
			set;
		}
		public string ReplyUser
		{
			get;
			set;
		}
		public string ReplyTime
		{
			get;
			set;
		}
		public string ReplyMemo
		{
			get;
			set;
		}
		public string Product
		{
			get;
			set;
		}
		public string Number
		{
			get;
			set;
		}
		public string latestTime
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string ChangeRegisterOutofStock(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$MemberName}", this.MemberName);
			text = text.Replace("{$SendTime}", this.SendTime);
			text = text.Replace("{$ReplyUser}", this.ReplyUser);
			text = text.Replace("{$ReplyTime}", this.ReplyTime);
			text = text.Replace("{$ReplyMemo}", this.ReplyMemo);
			text = text.Replace("{$Product}", this.Product);
			text = text.Replace("{$Number}", this.Number);
			text = text.Replace("{$latestTime}", this.latestTime);
			text = text.Replace("{$ShopName}", this.ShopName);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
