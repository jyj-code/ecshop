using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopWeiXinApiConfig : BaseShopWebControl
	{
		private string string_0 = "W_ShopWeiXinApiConfig.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		public W_ShopWeiXinApiConfig()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("txt_tokenurl");
			this.textBox_1 = (TextBox)skin.FindControl("txt_token");
			this.textBox_2 = (TextBox)skin.FindControl("txt_appid");
			this.textBox_3 = (TextBox)skin.FindControl("txt_appsecret");
			IShopNum1_Weixin_ShopWeiXinConfig_Active shopNum1_Weixin_ShopWeiXinConfig_Active = new ShopNum1_Weixin_ShopWeiXinConfig_Active();
			DataTable weixinConfig = shopNum1_Weixin_ShopWeiXinConfig_Active.GetWeixinConfig(this.MemLoginID);
			if (weixinConfig.Rows.Count != 0)
			{
				this.textBox_0.Text = weixinConfig.Rows[0]["TokenURL"].ToString();
				this.textBox_1.Text = weixinConfig.Rows[0]["Token"].ToString();
				this.textBox_2.Text = weixinConfig.Rows[0]["AppId"].ToString();
				this.textBox_3.Text = weixinConfig.Rows[0]["AppSecret"].ToString();
			}
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				this.textBox_0.Text = Guid.NewGuid().ToString().Replace("-", "");
			}
			if (string.IsNullOrEmpty(this.textBox_1.Text))
			{
				this.textBox_1.Text = Guid.NewGuid().ToString().Replace("-", "");
			}
			this.textBox_0.Text = string.Format("http://{0}/api/shopadmin/api_weixin.ashx?shopowner={1}", HttpContext.Current.Request.Url.Host, this.textBox_0.Text);
		}
	}
}
