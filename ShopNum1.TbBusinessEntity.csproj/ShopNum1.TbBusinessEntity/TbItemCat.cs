using System;
namespace ShopNum1.TbBusinessEntity
{
	public class TbItemCat
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private bool bool_0 = false;
		private string string_3 = string.Empty;
		private int int_0 = 0;
        public string cid
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
		public string parent_cid
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
		public string name
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
		public bool is_parent
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public string status
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
		public int sort_order
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
	}
}
