using System;
namespace ShopNum1.Second
{
	[Serializable]
	public class ShopNum1_SecondUser
	{
		private int int_0;
		private string string_0;
		private string string_1;
		private string string_2;
		private DateTime dateTime_0;
		private int int_1;
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
		public string MemlogID
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
		public string SecondID
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
		public string Secondtype
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
		public int isAvailable
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
	}
}
