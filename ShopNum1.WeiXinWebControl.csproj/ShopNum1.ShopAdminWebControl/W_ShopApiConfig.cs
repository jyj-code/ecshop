using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopApiConfig : BaseShopWebControl
	{
		private string string_0 = "W_ShopApiConfig.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private CheckBox checkBox_0;
		private CheckBox checkBox_1;
		public W_ShopApiConfig()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("default_new");
			this.textBox_1 = (TextBox)skin.FindControl("default_reply");
			this.checkBox_0 = (CheckBox)skin.FindControl("cb_Atten");
			this.checkBox_1 = (CheckBox)skin.FindControl("cb_NotFind");
			IShopNum1_Weixin_ShopWeiXinConfig_Active shopNum1_Weixin_ShopWeiXinConfig_Active = new ShopNum1_Weixin_ShopWeiXinConfig_Active();
			DataTable weixinConfig = shopNum1_Weixin_ShopWeiXinConfig_Active.GetWeixinConfig(this.MemLoginID);
			if (weixinConfig.Rows.Count != 0)
			{
				this.textBox_0.Text = weixinConfig.Rows[0]["AttenRepKeys"].ToString();
				this.textBox_1.Text = weixinConfig.Rows[0]["NotFindKeys"].ToString();
				if (Convert.ToBoolean(weixinConfig.Rows[0]["IsOpenAtten"]))
				{
					this.checkBox_0.Checked = true;
				}
				else
				{
					this.checkBox_0.Checked = false;
				}
				if (Convert.ToBoolean(weixinConfig.Rows[0]["IsOpenNotFindKey"]))
				{
					this.checkBox_1.Checked = true;
				}
				else
				{
					this.checkBox_1.Checked = false;
				}
			}
		}
	}
}
