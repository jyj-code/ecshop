using System;
using System.Configuration;
using System.Data;
namespace ShopNum1.Second
{
	public class ShopNum1_Alipay_config
	{
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "";
		private string string_5 = "";
		public string Partner
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
		public string Key
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
		public string Return_url
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
		public string Input_charset
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
		public string Sign_type
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string Transport
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public ShopNum1_Alipay_config()
		{
			ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
			DataTable model = shopNum1_SecondTypeBussiness.GetModel(4);
			this.string_0 = model.Rows[0]["AppID"].ToString();
			this.string_1 = model.Rows[0]["AppSecret"].ToString();
			this.string_2 = "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Alipay/AlipayReturn.aspx";
			this.string_3 = "utf-8";
			this.string_4 = "MD5";
			this.string_5 = "http";
		}
	}
}
