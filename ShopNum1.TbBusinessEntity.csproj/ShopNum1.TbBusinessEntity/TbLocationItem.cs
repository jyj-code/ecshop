using System;
namespace ShopNum1.TbBusinessEntity
{
	public class TbLocationItem
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		public string city
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public string state
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
	}
}
