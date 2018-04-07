using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class PasswordReset
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
		public string SendTime
		{
			get;
			set;
		}
		public string PassWord
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
		public string ChangePasswordReset(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$SendTime}", this.SendTime);
			text = text.Replace("{$PassWord}", this.PassWord);
			text = text.Replace("{$ShopName}", this.ShopName);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
