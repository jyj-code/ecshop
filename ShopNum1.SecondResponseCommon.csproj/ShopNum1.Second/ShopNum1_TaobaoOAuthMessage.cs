using System;
namespace ShopNum1.Second
{
	public class ShopNum1_TaobaoOAuthMessage
	{
		private string string_0;
		private string string_1;
		private int int_0;
		private int int_1;
		public string Access_token
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
		public string Token_type
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
		public int Expires_in
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
		public int Taobao_user_id
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
