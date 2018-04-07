using System;
namespace ShopNum1.Common
{
	public class PageList1
	{
		private int int_0 = 20;
		private int int_1 = 1;
		private int int_2 = 1;
		private int int_3 = 1;
		public int PageSize
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
		public int PageID
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
		public int PageCount
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
		public int RecordCount
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}
	}
}
