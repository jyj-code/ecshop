using System;
namespace ShopNum1.TbTopCommon
{
	public class SellCatResponse
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public string Cid
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
		public string created
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_1).ToString("yyyy-MM-dd HH:mm:ss");
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string modified
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_2).ToString("yyyy-MM-dd HH:mm:ss");
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
			set
			{
				this.string_2 = value;
			}
		}
	}
}
