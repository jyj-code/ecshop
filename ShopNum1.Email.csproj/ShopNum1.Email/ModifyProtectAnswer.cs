using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class ModifyProtectAnswer
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
		public string SendTime
		{
			get;
			set;
		}
		public string Question
		{
			get;
			set;
		}
		public string Answer
		{
			get;
			set;
		}
		public string Url
		{
			get;
			set;
		}
		public string SysSendTime
		{
			get;
			set;
		}
		public string ChangeModifyProtectAnswer(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			text = text.Replace("{$ShopName}", this.ShopName);
			text = text.Replace("{$SendTime}", this.SendTime);
			text = text.Replace("{$Question}", this.Question);
			text = text.Replace("{$Answer}", this.Answer);
			text = text.Replace("{$Url}", this.Url);
			return text.Replace("{$SysSendTime}", this.SysSendTime);
		}
	}
}
