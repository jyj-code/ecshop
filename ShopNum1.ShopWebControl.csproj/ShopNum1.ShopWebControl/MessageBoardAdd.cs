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
	public class MessageBoardAdd : BaseWebControl
	{
		private string string_0 = "MessageBoardAdd.ascx";
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Label label_0;
		private Button button_0;
		private Image image_0;
		private RadioButtonList radioButtonList_0;
		private HtmlTableRow htmlTableRow_0;
		private Panel panel_0;
		private Panel panel_1;
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string ShopID
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
		public MessageBoardAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
			}
			this.panel_0 = (Panel)skin.FindControl("PanelAdd");
			this.panel_1 = (Panel)skin.FindControl("PanelOut");
			if (ShopSettings.GetValue("ShopMessageCondition") == "1")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					this.panel_0.Visible = true;
					this.panel_1.Visible = false;
				}
				else
				{
					this.panel_0.Visible = false;
					this.panel_1.Visible = true;
				}
			}
			else
			{
				this.panel_0.Visible = true;
				this.panel_1.Visible = false;
			}
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.string_1 = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxContent");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxCode");
			this.image_0 = (Image)skin.FindControl("CheckImage");
			this.button_0 = (Button)skin.FindControl("ButtonConfrim");
			this.radioButtonList_0 = (RadioButtonList)skin.FindControl("RadioButtonListmessageType");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonRegister");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLogin");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("VerifyCode");
			if (this.MemberLoginID != null)
			{
				this.label_0.Text = this.MemberLoginID;
			}
			this.method_0();
			this.button_0.Click += new EventHandler(this.ButtonConfrim_Click);
			if (ShopSettings.GetValue("ShopMessageVerifyCode") == "1")
			{
				this.htmlTableRow_0.Visible = true;
			}
			else
			{
				this.htmlTableRow_0.Visible = false;
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			string text = "http://" + ShopSettings.siteDomain + "/Login" + (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
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
			string text = "http://" + ShopSettings.siteDomain + "/MemberRegister" + (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msg", string.Concat(new string[]
			{
				"location.href='",
				text,
				"?goback=",
				this.Page.Server.UrlEncode(this.Page.Request.Url.AbsoluteUri),
				"';"
			}), true);
		}
		private void method_0()
		{
			ListItem listItem = new ListItem();
			listItem.Text = "询问";
			listItem.Value = "0";
			this.radioButtonList_0.Items.Add(listItem);
			ListItem listItem2 = new ListItem();
			listItem2.Text = "求购";
			listItem2.Value = "1";
			this.radioButtonList_0.Items.Add(listItem2);
			ListItem listItem3 = new ListItem();
			listItem3.Text = "售后";
			listItem3.Value = "2";
			this.radioButtonList_0.Items.Add(listItem3);
			ListItem listItem4 = new ListItem();
			listItem4.Text = "其它";
			listItem4.Value = "3";
			this.radioButtonList_0.Items.Add(listItem4);
			this.radioButtonList_0.Items[0].Selected = true;
		}
		public void ButtonConfrim_Click(object sender, EventArgs e)
		{
			ShopNum1_Shop_MessageBoard shopNum1_Shop_MessageBoard = new ShopNum1_Shop_MessageBoard();
			if (ShopSettings.GetValue("ShopMessageCondition") == "1")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
				{
					ShopNum1.Common.GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再评论！");
					return;
				}
				shopNum1_Shop_MessageBoard.MemLoginID = this.MemberLoginID;
			}
			else
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
				{
					ShopNum1.Common.GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再留言！");
					return;
				}
				shopNum1_Shop_MessageBoard.MemLoginID = this.MemberLoginID;
			}
			if (this.string_1 != this.MemberLoginID)
			{
				string value = ShopSettings.GetValue("ShopMessageVerifyCode");
				if (value == "1")
				{
					if (this.Page.Session["code"] == null)
					{
						MessageBox.Show("验证码有误！");
						return;
					}
					if (this.textBox_2.Text.ToUpper() != this.Page.Session["code"].ToString())
					{
						MessageBox.Show("验证码不正确！");
						return;
					}
				}
				shopNum1_Shop_MessageBoard.Guid = Guid.NewGuid();
				shopNum1_Shop_MessageBoard.MessageType = Convert.ToInt32(this.radioButtonList_0.SelectedValue);
				shopNum1_Shop_MessageBoard.Title = this.textBox_0.Text;
				shopNum1_Shop_MessageBoard.Content = this.textBox_1.Text;
				shopNum1_Shop_MessageBoard.SendTime = DateTime.Now;
				shopNum1_Shop_MessageBoard.IsReply = 0;
				shopNum1_Shop_MessageBoard.IsShow = 1;
				shopNum1_Shop_MessageBoard.ReplyUser = this.string_1;
				Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
				int num = shop_MessageBoard_Action.AddMemMessageBoard(shopNum1_Shop_MessageBoard);
				if (num > 0)
				{
					MessageBox.Show("留言成功！");
					this.Page.Response.Redirect(string.Concat(new object[]
					{
						"http://",
						this.Page.Request.Url.Host,
						"/ShopMessageBoard.html?type=",
						shopNum1_Shop_MessageBoard.MessageType
					}));
				}
				else
				{
					MessageBox.Show("留言失败！");
				}
			}
			else
			{
				MessageBox.Show("不能给自己店铺留言！");
			}
		}
		public static string GetUrl(string pageName)
		{
			return "http://" + ShopSettings.siteDomain + pageName;
		}
	}
}
