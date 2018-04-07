using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class VideoCommentAdd : BaseWebControl
	{
		private string string_0 = "VideoCommentAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private RadioButton radioButton_2;
		private RadioButton radioButton_3;
		private RadioButton radioButton_4;
		private Button button_0;
		private HtmlTableRow htmlTableRow_0;
		[CompilerGenerated]
		private string string_1;
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
		protected string ShopID
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
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.radioButton_0 = (RadioButton)skin.FindControl("RadioButton1");
			this.radioButton_1 = (RadioButton)skin.FindControl("RadioButton2");
			this.radioButton_2 = (RadioButton)skin.FindControl("RadioButton3");
			this.radioButton_3 = (RadioButton)skin.FindControl("RadioButton4");
			this.radioButton_4 = (RadioButton)skin.FindControl("RadioButton5");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.Guids = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			if (this.Page.IsPostBack)
			{
			}
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("VerifyCode");
			if (ShopSettings.GetValue("VideoCommentVerifyCode") == "1")
			{
				this.htmlTableRow_0.Visible = true;
			}
			else
			{
				this.htmlTableRow_0.Visible = false;
			}
			this.textBox_0.Enabled = false;
			this.textBox_0.Text = "仅限登录用户";
			if (ShopSettings.GetValue("VideoCommentCondition") == "0")
			{
				this.textBox_0.Enabled = true;
				this.textBox_0.Text = "游客";
				this.button_0.Enabled = true;
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.textBox_0.Text = this.MemLoginID;
				this.textBox_0.ReadOnly = true;
				this.button_0.Enabled = true;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string value = ShopSettings.GetValue("VideoCommentVerifyCode");
			if (value == "1")
			{
				if (this.Page.Session["code"] == null)
				{
					MessageBox.Show("验证码有误！");
					return;
				}
				if (this.textBox_3.Text.ToUpper().Trim() != this.Page.Session["code"].ToString())
				{
					MessageBox.Show("验证码不正确！");
					return;
				}
			}
			string value2 = ShopSettings.GetValue("VideoCommentCondition");
			if (value2 == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再评论！");
			}
			else
			{
				ShopNum1_Shop_VideoComment shopNum1_Shop_VideoComment = new ShopNum1_Shop_VideoComment();
				shopNum1_Shop_VideoComment.Guid = Guid.NewGuid();
				shopNum1_Shop_VideoComment.Title = this.textBox_1.Text.Trim();
				int commentType = 0;
				if (this.radioButton_0.Checked)
				{
					commentType = 1;
				}
				else if (this.radioButton_1.Checked)
				{
					commentType = 2;
				}
				else if (this.radioButton_2.Checked)
				{
					commentType = 3;
				}
				else if (this.radioButton_3.Checked)
				{
					commentType = 4;
				}
				else if (this.radioButton_4.Checked)
				{
					commentType = 5;
				}
				shopNum1_Shop_VideoComment.CommentType = commentType;
				shopNum1_Shop_VideoComment.VideoGuid = this.Guids;
				shopNum1_Shop_VideoComment.CommentTime = DateTime.Now;
				shopNum1_Shop_VideoComment.Comment = this.textBox_2.Text.Trim();
				shopNum1_Shop_VideoComment.ShopID = this.ShopID;
				string value3 = ShopSettings.GetValue("VideoCommentISAudit");
				if (value3 == "0")
				{
					shopNum1_Shop_VideoComment.IsAudit = new int?(1);
				}
				else
				{
					shopNum1_Shop_VideoComment.IsAudit = new int?(0);
				}
				shopNum1_Shop_VideoComment.MemLoginID = this.textBox_0.Text.Trim();
				shopNum1_Shop_VideoComment.IsReply = new int?(0);
				shopNum1_Shop_VideoComment.IPAddress = this.Page.Request.UserHostAddress;
				Shop_VideoComment_Action shop_VideoComment_Action = (Shop_VideoComment_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_VideoComment_Action();
				int num = shop_VideoComment_Action.Add(shopNum1_Shop_VideoComment);
				if (num > 0)
				{
					if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						string text = this.textBox_0.Text;
						string value4 = ShopSettings.GetValue("MyShopMessageRankSorce");
						string value5 = ShopSettings.GetValue("MyShopMessageSorce");
						if (int.Parse(value4) > 0 || int.Parse(value5) > 0)
						{
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
							DataTable memInfoByMemberloginId = shopNum1_Member_Action.GetMemInfoByMemberloginId(text);
							int num2 = 0;
							int num3 = 0;
							if (memInfoByMemberloginId != null && memInfoByMemberloginId.Rows.Count > 0)
							{
								num2 = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
								num3 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
							}
							int num4 = shopNum1_Member_Action.UpdateScore(new ShopNum1_Member
							{
								MemberRank = new int?(num2 + int.Parse(value4)),
								Score = num3 + int.Parse(value5),
								MemLoginID = text
							});
							if (num4 < 0)
							{
								return;
							}
							if (int.Parse(value5) > 0)
							{
								ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
								shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
								shopNum1_ScoreModifyLog.OperateType = 1;
								shopNum1_ScoreModifyLog.CurrentScore = num3;
								shopNum1_ScoreModifyLog.OperateScore = int.Parse(value5);
								shopNum1_ScoreModifyLog.LastOperateScore = num3 + int.Parse(value5);
								shopNum1_ScoreModifyLog.Date = DateTime.Now;
								shopNum1_ScoreModifyLog.Memo = "店铺留言赠送消费积分";
								shopNum1_ScoreModifyLog.MemLoginID = text;
								shopNum1_ScoreModifyLog.CreateUser = text;
								shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
								shopNum1_ScoreModifyLog.IsDeleted = 0;
								ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
								shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
							}
							if (int.Parse(value4) > 0)
							{
								ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
								shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
								shopNum1_RankScoreModifyLog.OperateType = 1;
								shopNum1_RankScoreModifyLog.CurrentScore = num2;
								shopNum1_RankScoreModifyLog.OperateScore = int.Parse(value4);
								shopNum1_RankScoreModifyLog.LastOperateScore = num2 + int.Parse(value4);
								shopNum1_RankScoreModifyLog.Date = DateTime.Now;
								shopNum1_RankScoreModifyLog.Memo = "店铺留言赠送等级积分";
								shopNum1_RankScoreModifyLog.MemLoginID = text;
								shopNum1_RankScoreModifyLog.CreateUser = text;
								shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
								shopNum1_RankScoreModifyLog.IsDeleted = 0;
								ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
								shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
							}
						}
						this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('恭喜您，评论成功！');window.location.href=window.location.href;</script>", false);
					}
				}
				else
				{
					MessageBox.Show("评论失败！");
				}
			}
		}
	}
}
