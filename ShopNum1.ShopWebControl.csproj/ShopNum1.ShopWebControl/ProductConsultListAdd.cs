using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductConsultListAdd : BaseWebControl
	{
		private string string_0 = "ProductConsultListAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Button button_0;
		private HtmlTableRow htmlTableRow_0;
		private TextBox textBox_3;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		protected string MemLoginID
		{
			get;
			set;
		}
		protected string ShopID
		{
			get;
			set;
		}
		public ProductConsultListAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"]);
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("TRVerifyCode");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			if (ShopSettings.GetValue("ProductConsultVerifyCode") == "0")
			{
				this.htmlTableRow_0.Visible = false;
			}
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.IsPostBack)
			{
			}
			if (this.Page.Request.QueryString["guid"] != null)
			{
				string arg_14D_0 = this.Page.Request.QueryString["guid"];
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.textBox_0.Text = this.MemLoginID;
				this.textBox_0.Enabled = false;
			}
			else
			{
				this.textBox_0.Text = "游客";
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo", "   AND   ShopID='" + this.ShopID + "' ");
				if (this.textBox_0.Text == nameById)
				{
					MessageBox.Show("不能给自己的店铺留言！");
					return;
				}
			}
			catch (Exception)
			{
				return;
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再留言！");
			}
			else
			{
				this.textBox_0.ReadOnly = true;
				string value = ShopSettings.GetValue("ProductConsultVerifyCode");
				if (!(value == "0"))
				{
					if (this.Page.Session["code"] == null)
					{
						MessageBox.Show("验证码有误！");
						return;
					}
					if (this.textBox_3.Text.Trim().ToUpper() != this.Page.Session["code"].ToString())
					{
						MessageBox.Show("验证码不正确！");
						return;
					}
				}
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
				string shopID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
				ShopNum1_ShopProductConsult shopNum1_ShopProductConsult = new ShopNum1_ShopProductConsult();
				shopNum1_ShopProductConsult.Guid = Guid.NewGuid();
				shopNum1_ShopProductConsult.ProductGuid = new Guid(this.Page.Request.QueryString["guid"].ToString());
				shopNum1_ShopProductConsult.Content = this.textBox_2.Text.Trim();
				shopNum1_ShopProductConsult.ConsultPeople = this.textBox_0.Text.Trim();
				shopNum1_ShopProductConsult.Title = this.textBox_1.Text.Trim();
				if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
				{
					shopNum1_ShopProductConsult.MemLoginID = "";
				}
				else
				{
					shopNum1_ShopProductConsult.MemLoginID = this.MemLoginID;
				}
				shopNum1_ShopProductConsult.IsReply = 0;
				shopNum1_ShopProductConsult.SendTime = DateTime.Now;
				shopNum1_ShopProductConsult.IsDeleted = 0;
				if (ShopSettings.GetValue("ProductConsultISAudit") == "1")
				{
					shopNum1_ShopProductConsult.IsAudit = 0;
				}
				else
				{
					shopNum1_ShopProductConsult.IsAudit = 1;
				}
				shopNum1_ShopProductConsult.ShopID = shopID;
				shopNum1_ShopProductConsult.IPAddress = Globals.IPAddress;
				Shop_ProductConsult_Action shop_ProductConsult_Action = (Shop_ProductConsult_Action)LogicFactory.CreateShop_ProductConsult_Action();
				int num = shop_ProductConsult_Action.Add(shopNum1_ShopProductConsult);
				if (num > 0)
				{
					this.ClearControl();
					this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('恭喜您，留言成功！');window.location.href=window.location.href;</script>", false);
				}
				else
				{
					MessageBox.Show("留言失败！");
				}
			}
		}
		public void ClearControl()
		{
			this.textBox_1.Text = string.Empty;
			this.textBox_2.Text = string.Empty;
			this.textBox_3.Text = string.Empty;
		}
	}
}
