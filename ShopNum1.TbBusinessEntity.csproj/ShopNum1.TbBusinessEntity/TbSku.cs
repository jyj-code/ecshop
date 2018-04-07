using System;
namespace ShopNum1.TbBusinessEntity
{
	public class TbSku
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private int int_0 = 0;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		private string string_8 = string.Empty;
		private string string_9 = string.Empty;
		public string sku_id
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
		public string num_iid
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
		public string properties
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string propertiesText
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public int quantity
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public string price
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDouble(this.string_5).ToString("#.00");
				}
				catch
				{
					result = ((this.string_5 != string.Empty) ? "0.00" : "");
				}
				return result;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string outer_id
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public string created
		{
			get
			{
				string result;
				try
				{
					result = (this.string_7 = Convert.ToDateTime(this.string_7).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				catch
				{
					result = ((this.string_7 == string.Empty) ? "1990-1-1 00:00:00" : "1991-1-1 00:00:01");
				}
				return result;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public string modified
		{
			get
			{
				string result;
				try
				{
					result = (this.string_8 = Convert.ToDateTime(this.string_8).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				catch
				{
					result = ((this.string_8 == string.Empty) ? "1990-1-1 00:00:00" : "1991-1-1 00:00:01");
				}
				return result;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public string status
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
			}
		}
	}
}
