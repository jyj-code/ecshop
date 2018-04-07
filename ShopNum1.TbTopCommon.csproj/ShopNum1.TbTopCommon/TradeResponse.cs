using System;
namespace ShopNum1.TbTopCommon
{
	public class TradeResponse
	{
		private string string_0;
		private string string_1;
		private string string_2;
		public string total_results
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
		public string String_0
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
		public string String_1
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
	}
}
