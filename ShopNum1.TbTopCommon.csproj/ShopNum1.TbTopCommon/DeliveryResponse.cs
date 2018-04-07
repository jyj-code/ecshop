using System;
namespace ShopNum1.TbTopCommon
{
	public class DeliveryResponse
	{
		private bool bool_0 = false;
		public bool is_success
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
	}
}
