using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductIntegral : BaseWebControl
	{
		private string string_0 = "ProductIntegral.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private HiddenField hiddenField_3;
		private HiddenField hiddenField_4;
		public ProductIntegral()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldMaxCount");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldMemloginID");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldMyScore");
			this.hiddenField_4 = (HiddenField)skin.FindControl("HiddenFieldUrl");
			this.hiddenField_4.Value = "http://" + ShopSettings.siteDomain + "/main/member/m_index.aspx?tomurl=M_OrderScoreList.aspx";
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.hiddenField_1.Value = httpCookie.Values["MemLoginID"].ToString();
				this.GetMyScore();
			}
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.hiddenField_0.Value = this.Page.Request.QueryString["guid"].ToString();
				this.GetDataBind();
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				string text = this.Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26");
				this.Page.RegisterClientScriptBlock("script", string.Concat(new string[]
				{
					"<script>$(function(){$('#mylogingo').attr('src','http://",
					ShopSettings.siteDomain,
					"/poplogin.html?vj=shopcar&backurl=",
					text,
					"'); });</script>"
				}));
			}
			if (!string.IsNullOrEmpty(ShopSettings.GetValue("MaxScroeProductCount")))
			{
				this.hiddenField_3.Value = ShopSettings.GetValue("MaxScroeProductCount").ToString();
			}
			if (!this.Page.IsPostBack && this.Page.Request.UrlReferrer != null)
			{
				ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
				try
				{
					shopNum1_Shop_ScoreProduct_Action.ClickProduct(this.Page.Request.QueryString["guid"].ToString());
				}
				catch (Exception)
				{
				}
			}
		}
		public void GetMyScore()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			DataTable scoreByMemLoginID = shopNum1_Shop_ScoreProduct_Action.GetScoreByMemLoginID(this.hiddenField_1.Value);
			if (scoreByMemLoginID != null && scoreByMemLoginID.Rows.Count > 0)
			{
				this.hiddenField_2.Value = scoreByMemLoginID.Rows[0]["Score"].ToString();
			}
			else
			{
				this.hiddenField_2.Value = "0";
			}
		}
		public void GetDataBind()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			DataTable dataShopWeb = shopNum1_Shop_ScoreProduct_Action.GetDataShopWeb(1, 0, 1, this.hiddenField_0.Value);
			if (dataShopWeb != null && dataShopWeb.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataShopWeb.DefaultView;
				this.repeater_0.DataBind();
			}
			else
			{
				MessageBox.Show("商品不存在！");
			}
		}
	}
}
