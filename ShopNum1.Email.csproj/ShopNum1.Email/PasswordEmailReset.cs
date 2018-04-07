using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class PasswordEmailReset
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
		public string ChangePwdUrl
		{
			get;
			set;
		}
		public string Hour
		{
			get;
			set;
		}
		public string ExtireTime
		{
			get;
			set;
		}
		public string PassWord
		{
			get;
			set;
		}
		public string MemloginID
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
		public string ChangePasswordEmailReset(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$ChangePwdUrl}", this.ChangePwdUrl);
			text = text.Replace("{$Hour}", this.Hour);
			text = text.Replace("{$ExtireTime}", this.ExtireTime);
			text = text.Replace("{$Name}", this.MemloginID);
			text = text.Replace("{$PassWord}", this.PassWord);
			text = text.Replace("{$ShopName}", this.ShopName);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
