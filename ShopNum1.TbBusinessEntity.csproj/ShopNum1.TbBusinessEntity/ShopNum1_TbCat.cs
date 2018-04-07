using System;
namespace ShopNum1.TbBusinessEntity
{
	public class ShopNum1_TbCat
	{
		public int int_0;
		public string name;
		public DateTime createTime;
		private int _cid
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
		private string _name
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
		private DateTime _createTime
		{
			get
			{
				return this.createTime;
			}
			set
			{
				this.createTime = value;
			}
		}
	}
}
