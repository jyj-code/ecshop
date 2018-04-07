using System;
namespace ShopNum1.TbBusinessEntity
{
	[Serializable]
	public class TbPromotionDetail
	{
		private decimal decimal_0;
		private string string_0;
		private string string_1;
		private string string_2;
		public decimal Decimal_0
		{
			get
			{
				return this.decimal_0;
			}
			set
			{
				this.decimal_0 = value;
			}
		}
		public string promotion_name
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
		public string discount_fee
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
		public string gift_item_name
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
