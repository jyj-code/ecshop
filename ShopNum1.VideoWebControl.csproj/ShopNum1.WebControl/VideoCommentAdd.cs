using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class VideoCommentAdd : BaseWebControl
	{
		private string string_0 = "VideoCommentAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		private string string_1;
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlInputText htmlInputText_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string Guids
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public VideoCommentAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.string_1 = ShopSettings.GetValue("VideoCommentVerifyCode");
			if (this.string_1 == "0")
			{
				this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divVerifyCode");
				this.label_0 = (Label)skin.FindControl("LabelCheckCode");
				this.label_0.Visible = false;
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_0.Attributes.Add("style", "display:none;");
			}
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("VideoCommentAddVerifyCode");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxContent");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.Guids = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			string value = ShopSettings.GetValue("VideoCommentCondition");
			if (value == "0")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
					this.textBox_0.Text = this.MemLoginID;
				}
				else
				{
					this.textBox_0.Text = "游客";
				}
			}
			else if (value == "1")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
					this.textBox_0.Text = this.MemLoginID;
				}
				else
				{
					this.textBox_0.Text = "游客";
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (ShopSettings.GetValue("VideoCommentCondition") == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
				this.Page.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" + (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"));
			}
			else
			{
				string value = ShopSettings.GetValue("VideoCommentVerifyCode");
				if (!(value == "0"))
				{
					string b = (this.Page.Session["code"].ToString() == null) ? "" : this.Page.Session["code"].ToString();
					if (this.htmlInputText_0.Value.ToUpper().Trim() != b)
					{
						ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert(\"验证码不正确!\");", true);
						return;
					}
				}
				ShopNum1_VideoComment shopNum1_VideoComment = new ShopNum1_VideoComment();
				shopNum1_VideoComment.Guid = Guid.NewGuid();
				shopNum1_VideoComment.VideoGuid = this.Guids;
				shopNum1_VideoComment.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_VideoComment.Content = this.textBox_1.Text.Trim();
				shopNum1_VideoComment.MemLoginID = this.textBox_0.Text.Trim();
				string value2 = ShopSettings.GetValue("VideoCommentISAudit");
				int value3;
				if (value2.Trim() == "0")
				{
					value3 = 1;
				}
				else
				{
					value3 = 0;
				}
				shopNum1_VideoComment.IsAudit = new int?(value3);
				shopNum1_VideoComment.IsDeleted = new int?(0);
				ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
				int num = shopNum1_VideoComment_Action.Add(shopNum1_VideoComment);
				if (num > 0)
				{
					this.Page.Request.QueryString["guid"].ToString();
					ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "window.alert(\"评论成功！\");window.location.href=window.location.href", true);
				}
				else
				{
					MessageBox.Show("评论失败！");
				}
			}
		}
		private void method_0()
		{
			string str = Globals.SkinPath + "/Images/CheckCode/";
			Random random = new Random();
			string text = random.Next(1111, 9999).ToString();
			this.method_1(text);
			System.Drawing.Image image = System.Drawing.Image.FromFile(this.Page.Server.MapPath(str + text.Substring(0, 1) + ".gif"));
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(this.Page.Server.MapPath(str + text.Substring(1, 1) + ".gif"));
			System.Drawing.Image image3 = System.Drawing.Image.FromFile(this.Page.Server.MapPath(str + text.Substring(2, 1) + ".gif"));
			System.Drawing.Image image4 = System.Drawing.Image.FromFile(this.Page.Server.MapPath(str + text.Substring(3, 1) + ".gif"));
			int width = image.Width + image2.Width + image3.Width + image4.Width;
			int height = image.Height;
			Bitmap bitmap = new Bitmap(width, height);
			Graphics graphics = Graphics.FromImage(bitmap);
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			graphics.FillRectangle(solidBrush, 0, 0, width, height);
			graphics.DrawImage(image, 0, 0);
			graphics.DrawImage(image2, image.Width, 0);
			graphics.DrawImage(image3, image.Width + image2.Width, 0);
			graphics.DrawImage(image4, image.Width + image2.Width + image3.Width, 0);
			bitmap.Save(this.Page.Server.MapPath(str + "/verify.bmp"));
			solidBrush.Dispose();
			graphics.Dispose();
			bitmap.Dispose();
		}
		private void method_1(string string_4)
		{
			this.ViewState["VerifyCode"] = string_4;
		}
	}
}
