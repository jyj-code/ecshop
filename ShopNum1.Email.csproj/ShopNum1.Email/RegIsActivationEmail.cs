using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class RegIsActivationEmail
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
		public string ShopName
		{
			get;
			set;
		}
		public string Email
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string link
		{
			get;
			set;
		}
		public string ChangeRegister(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$ShopName}", this.ShopName);
			text = text.Replace("{$Email}", this.Email);
			text = text.Replace("{$SysSendTime}", this.SysSendTime);
			return text.Replace("{$link}", this.link);
		}
	}
}
