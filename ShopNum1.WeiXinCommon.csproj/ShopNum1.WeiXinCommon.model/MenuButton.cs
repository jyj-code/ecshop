using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace ShopNum1.WeiXinCommon.model
{
	public class MenuButton
	{
		public List<MenuButton> SubButton = new List<MenuButton>();
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string Sort
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Value
		{
			get;
			set;
		}
	}
}
