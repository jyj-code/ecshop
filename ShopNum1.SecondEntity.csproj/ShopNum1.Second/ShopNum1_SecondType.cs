using System;
namespace ShopNum1.Second
{
	[Serializable]
	public class ShopNum1_SecondType
	{
		private int int_0;
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private int int_1;
		private DateTime dateTime_0;
		private string string_5;
		private int int_2;
		public int ID
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
		public string TypeName
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
		public string AppID
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
		public string AppSecret
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
		public string content
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
		public string redirectURL
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
		public int isAvabile
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		public DateTime createTime
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
			}
		}
		public int OrderID
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		public string ImgSrc
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
	}
}
