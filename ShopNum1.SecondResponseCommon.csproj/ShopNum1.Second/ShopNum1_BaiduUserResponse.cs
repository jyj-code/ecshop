using System;
namespace ShopNum1.Second
{
	[Serializable]
	public class ShopNum1_BaiduUserResponse
	{
		private string string_0;
		private string string_1;
		private string string_2;
        public string uid
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
		public string uname
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
		public string portrait
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
