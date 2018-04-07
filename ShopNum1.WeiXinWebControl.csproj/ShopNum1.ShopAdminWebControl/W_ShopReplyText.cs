using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopReplyText : BaseShopWebControl
	{
		private string string_0 = "W_ShopReplyText.ascx";
		private TextBox textBox_0;
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private TextBox textBox_1;
		private HiddenField hiddenField_0;
		private Label label_0;
		public W_ShopReplyText()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lbl_waplink");
			if (ConfigurationManager.AppSettings["wap_urlhost"] != null)
			{
				this.label_0.Text = string.Format("&nbsp;&nbsp;微信商城链接：&lt;a href=\"{0}\"&gt;进入微信商城&lt;/a&gt;", ConfigurationManager.AppSettings["wap_urlhost"].ToString().Replace("{2}", ""));
			}
			string text = HttpContext.Current.Request.QueryString["ruleid"];
			if (!string.IsNullOrEmpty(text))
			{
				this.textBox_0 = (TextBox)skin.FindControl("txt_keyword");
				this.radioButton_0 = (RadioButton)skin.FindControl("rbtn_accurate");
				this.radioButton_1 = (RadioButton)skin.FindControl("rbtn_vague");
				this.textBox_1 = (TextBox)skin.FindControl("txt_content");
				this.hiddenField_0 = (HiddenField)skin.FindControl("hid_ruleid");
				IShopNum1_Weixin_ReplyRule_Active shopNum1_Weixin_ReplyRule_Active = new ShopNum1_Weixin_ReplyRule_Active();
				DataSet dataSet = shopNum1_Weixin_ReplyRule_Active.SelectReplyRule(text);
				if (dataSet.Tables.Count != 0)
				{
					DataTable dataTable = dataSet.Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						DataTable dataTable2 = dataSet.Tables[1];
						StringBuilder stringBuilder = new StringBuilder();
						foreach (DataRow dataRow in dataTable2.Rows)
						{
							stringBuilder.AppendFormat("{0} ", dataRow["KeyWord"].ToString());
						}
						DataTable dataTable3 = dataSet.Tables[2];
						this.textBox_0.Text = stringBuilder.ToString().Trim();
						this.textBox_1.Text = HttpUtility.UrlDecode((dataTable3.Rows.Count != 0) ? dataTable3.Rows[0]["RepMsgContent"].ToString() : string.Empty, Encoding.GetEncoding("utf-8"));
						if (Convert.ToInt32(dataTable.Rows[0]["Matching"]) == 1)
						{
							this.radioButton_1.Checked = true;
						}
						else
						{
							this.radioButton_0.Checked = true;
						}
						this.hiddenField_0.Value = text;
					}
				}
			}
		}
	}
}
