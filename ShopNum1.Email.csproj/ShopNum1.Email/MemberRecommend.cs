using System;
using System.Runtime.CompilerServices;
namespace ShopNum1.Email
{
	public class MemberRecommend
	{
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
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
		public string ChangeMemberRecommed(string content)
		{
			string text = string.Empty;
			text = content.Replace("{$Name}", this.Name);
			return text.Replace("{$ShopName}", this.ShopName);
		}
	}
}
