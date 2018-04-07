using System;
namespace ShopNum1.TbBusinessEntity
{
	public class ShopNum1_TbSysItemCat
	{
		public bool is_parent;
		public string name;
		public string string_0;
		public bool Is_parent
		{
			get
			{
				return this.is_parent;
			}
			set
			{
				this.is_parent = value;
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
	}
}
