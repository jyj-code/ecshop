using System;
namespace ShopNum1.TbBusinessEntity
{
	public class ShopNum1_TbPropValue
	{
		public int int_0;
		public string name;
		public int int_1;
		public bool is_sale_prop;
		public bool is_enum_prop;
		public bool multi;
		public int pid
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
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		public int vid
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
		public bool Is_sale_prop
		{
			get
			{
				return this.is_sale_prop;
			}
			set
			{
				this.is_sale_prop = value;
			}
		}
		public bool Is_enum_prop
		{
			get
			{
				return this.is_enum_prop;
			}
			set
			{
				this.is_enum_prop = value;
			}
		}
		public bool Multi
		{
			get
			{
				return this.multi;
			}
			set
			{
				this.multi = value;
			}
		}
	}
}
