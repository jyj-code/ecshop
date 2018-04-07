using System;
namespace ShopNum1.TbTopCommon
{
	public class ItemImgResponse
	{
		private string string_0;
		private string string_1;
		private string string_2;
		public string created
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_0).ToString("yyyy-MM-dd HH:mm:ss");
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
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
