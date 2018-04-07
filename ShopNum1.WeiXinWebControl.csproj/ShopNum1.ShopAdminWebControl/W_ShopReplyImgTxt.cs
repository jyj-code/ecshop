using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopReplyImgTxt : BaseShopWebControl
	{
		private string string_0 = "W_ShopReplyImgTxt.ascx";
		private TextBox textBox_0;
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private TextBox textBox_1;
		private Image image_0;
		private HiddenField hiddenField_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private Repeater repeater_0;
		private RadioButton radioButton_2;
		private RadioButton radioButton_3;
		private TextBox textBox_4;
		public W_ShopReplyImgTxt()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string text = HttpContext.Current.Request.QueryString["ruleid"];
			if (!string.IsNullOrEmpty(text))
			{
				this.textBox_0 = (TextBox)skin.FindControl("txt_keyword");
				this.radioButton_0 = (RadioButton)skin.FindControl("rbtn_accurate");
				this.radioButton_1 = (RadioButton)skin.FindControl("rbtn_vague");
				this.textBox_1 = (TextBox)skin.FindControl("txt_title");
				this.image_0 = (Image)skin.FindControl("thumb_img");
				this.hiddenField_0 = (HiddenField)skin.FindControl("thumb");
				this.textBox_2 = (TextBox)skin.FindControl("txt_description");
				this.textBox_3 = (TextBox)skin.FindControl("FCKeditorRemark");
				this.hiddenField_1 = (HiddenField)skin.FindControl("hid_ruleid");
				this.hiddenField_2 = (HiddenField)skin.FindControl("hid_articleid");
				this.repeater_0 = (Repeater)skin.FindControl("rep_contentlist");
				this.radioButton_2 = (RadioButton)skin.FindControl("rbtn_Arti");
				this.radioButton_3 = (RadioButton)skin.FindControl("rbtn_link");
				this.textBox_4 = (TextBox)skin.FindControl("txtLink");
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
						if (dataTable3.Rows.Count != 0)
						{
							this.textBox_1.Text = dataTable3.Rows[0]["Title"].ToString();
							this.textBox_2.Text = dataTable3.Rows[0]["Description"].ToString();
							this.hiddenField_0.Value = (this.image_0.ImageUrl = dataTable3.Rows[0]["ImgSrc"].ToString());
							DataTable dataTable4 = shopNum1_Weixin_ReplyRule_Active.SelectArticle(text);
							if (dataTable4.Rows.Count != 0)
							{
								this.hiddenField_2.Value = dataTable4.Rows[0]["ID"].ToString();
								if (Convert.ToInt32(dataTable4.Rows[0]["Type"]) == 0)
								{
									this.radioButton_3.Checked = true;
									this.textBox_4.Text = HttpUtility.UrlDecode(dataTable4.Rows[0]["ArticleContent"].ToString(), Encoding.GetEncoding("utf-8"));
								}
								else
								{
									this.radioButton_2.Checked = true;
									this.textBox_3.Text = HttpUtility.UrlDecode(dataTable4.Rows[0]["ArticleContent"].ToString(), Encoding.GetEncoding("utf-8"));
								}
							}
							DataTable dataSource = shopNum1_Weixin_ReplyRule_Active.SelectContent(text);
							this.repeater_0.DataSource = dataSource;
							this.repeater_0.DataBind();
						}
						if (Convert.ToInt32(dataTable.Rows[0]["Matching"]) == 1)
						{
							this.radioButton_1.Checked = true;
						}
						else
						{
							this.radioButton_0.Checked = true;
						}
						this.hiddenField_1.Value = text;
					}
				}
			}
		}
	}
}
