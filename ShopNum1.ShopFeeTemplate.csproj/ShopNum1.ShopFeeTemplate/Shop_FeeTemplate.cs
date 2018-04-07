using System;
namespace ShopNum1.ShopFeeTemplate
{
	[Serializable]
	public class Shop_FeeTemplate
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		private string string_7;
		private string string_8;
		private string string_9;
		private string string_10;
		private string string_11;
		private string string_12;
		private string string_13;
		public string String_0
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
		public string templateid
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
		public string templatename
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
        public string fee
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
		public string feetype
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
		public string oneadd
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string regioncode
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
		public string regionname
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public string createtime
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_8).ToString("yyyy-MM-dd hh:mm:ss");
				}
				catch
				{
					result = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
				}
				return result;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public string altertime
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_9).ToString("yyyy-MM-dd hh:mm:ss");
				}
				catch
				{
					result = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
				}
				return result;
			}
			set
			{
				this.string_9 = value;
			}
		}
		public string orderid
		{
			get
			{
				return this.string_13;
			}
			set
			{
				this.string_13 = value;
			}
		}
		public string groupid
		{
			get
			{
				return this.string_10;
			}
			set
			{
				this.string_10 = value;
			}
		}
		public string groupregionnames
		{
			get
			{
				return this.string_11;
			}
			set
			{
				this.string_11 = value;
			}
		}
		public string groupregioncodes
		{
			get
			{
				return this.string_12;
			}
			set
			{
				this.string_12 = value;
			}
		}
	}
}
