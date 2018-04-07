using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class SupplyCommentAdd : BaseWebControl
	{
		private string string_0 = "MessageBoardAdd.ascx";
		private string string_1 = string.Empty;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Label label_0;
		private Button button_0;
		private Image image_0;
		private Panel panel_0;
		private Panel panel_1;
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private static string string_7;
		public string MemLoginID
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public string shopName
		{
			get;
			set;
		}
		public string StrGuid
		{
			get;
			set;
		}
		public static string ShopID
		{
			get;
			set;
		}
		public SupplyCommentAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.StrGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
			this.panel_0 = (Panel)skin.FindControl("PanelAdd");
			this.panel_1 = (Panel)skin.FindControl("PanelOut");
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.string_2 = httpCookie.Values["Name"].ToString();
				this.panel_0.Visible = true;
				this.panel_1.Visible = false;
			}
			else
			{
				this.panel_0.Visible = false;
				this.panel_1.Visible = true;
			}
			SupplyCommentAdd.ShopID = ((this.Page.Request.QueryString["ShopID"].ToString() == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			this.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(SupplyCommentAdd.ShopID).ToString();
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxContent");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxCode");
			this.image_0 = (Image)skin.FindControl("CheckImage");
			this.button_0 = (Button)skin.FindControl("ButtonConfrim");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonRegister");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLogin");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			if (this.MemberLoginID != null)
			{
				this.label_0.Text = this.MemberLoginID;
			}
			this.button_0.Click += new EventHandler(this.ButtonConfrim_Click);
			if (this.Page.IsPostBack)
			{
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			string text = "http://" + ConfigurationSettings.AppSettings["Domain"].ToString() + "Login.html";
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msg", string.Concat(new string[]
			{
				"location.href='",
				text,
				"?goback=",
				this.Page.Server.UrlEncode(this.Page.Request.Url.AbsoluteUri),
				"';"
			}), true);
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			string text = "http://" + ConfigurationSettings.AppSettings["Domain"].ToString() + "MemberRegister.html";
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msg", string.Concat(new string[]
			{
				"location.href='",
				text,
				"?goback=",
				this.Page.Server.UrlEncode(this.Page.Request.Url.AbsoluteUri),
				"';"
			}), true);
		}
		public void ButtonConfrim_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				ShopNum1.Common.GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				httpCookie.Values["MemberType"].ToString();
				if (this.Page.Session["code"] != null)
				{
					if (this.textBox_2.Text.ToUpper() == this.Page.Session["code"].ToString())
					{
						ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment = new ShopNum1_SupplyDemandComment();
						shopNum1_SupplyDemandComment.Guid = Guid.NewGuid();
						shopNum1_SupplyDemandComment.Title = this.textBox_0.Text;
						shopNum1_SupplyDemandComment.Content = this.textBox_1.Text;
						shopNum1_SupplyDemandComment.CreateTime = DateTime.Now;
						shopNum1_SupplyDemandComment.IsAudit = 1;
						shopNum1_SupplyDemandComment.CreateMerber = this.MemLoginID;
						shopNum1_SupplyDemandComment.AssociateMemberID = this.MemberLoginID;
						shopNum1_SupplyDemandComment.CreateIP = this.Page.Request.UserHostAddress;
						shopNum1_SupplyDemandComment.SupplyDemandGuid = new Guid(this.StrGuid).ToString();
						Shop_SupplyDemand_Action shop_SupplyDemand_Action = (Shop_SupplyDemand_Action)LogicFactory.CreateShop_SupplyDemand_Action();
						int num = shop_SupplyDemand_Action.SupplyDemandCommentAdd(shopNum1_SupplyDemandComment);
						if (num > 0)
						{
							MessageBox.Show("留言成功！");
						}
					}
					else
					{
						MessageBox.Show("验证码错误！");
					}
				}
				else
				{
					MessageBox.Show("验证码不正确！");
				}
			}
		}
		public static string GetUrl(string pageName)
		{
			return "http://shop" + SupplyCommentAdd.ShopID + ConfigurationSettings.AppSettings["Domain"].ToString() + pageName;
		}
	}
}
