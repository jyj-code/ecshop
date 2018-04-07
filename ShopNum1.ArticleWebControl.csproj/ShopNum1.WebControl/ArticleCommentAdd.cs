using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleCommentAdd : BaseWebControl
	{
		private string string_0 = "AriticleCommentAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private HtmlTableRow htmlTableRow_0;
		private TextBox textBox_2;
		private RadioButton radioButton_0;
		private RadioButton radioButton_1;
		private RadioButton radioButton_2;
		private RadioButton radioButton_3;
		private RadioButton radioButton_4;
		private TextBox textBox_3;
		private Button button_0;
		private HtmlAnchor htmlAnchor_0;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string MemLoginID
		{
			get;
			set;
		}
		public string strArticleCommentCondition
		{
			get;
			set;
		}
		public string strAriticleCommentVerifyCode
		{
			get;
			set;
		}
		public string strArticleCommentISAudit
		{
			get;
			set;
		}
		public ArticleCommentAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("CommentsAddShow");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("LoginHref");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trCode");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.radioButton_0 = (RadioButton)skin.FindControl("RadioButton1");
			this.radioButton_1 = (RadioButton)skin.FindControl("RadioButton2");
			this.radioButton_2 = (RadioButton)skin.FindControl("RadioButton3");
			this.radioButton_3 = (RadioButton)skin.FindControl("RadioButton4");
			this.radioButton_4 = (RadioButton)skin.FindControl("RadioButton5");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				string arg_15C_0 = this.Page.Request.QueryString["guid"];
			}
			this.strArticleCommentCondition = ShopSettings.GetValue("ArticleCommentCondition");
			this.strAriticleCommentVerifyCode = ShopSettings.GetValue("AriticleCommentVerifyCode");
			this.strArticleCommentISAudit = ShopSettings.GetValue("ArticleCommentISAudit");
			if (this.strAriticleCommentVerifyCode == "0")
			{
				this.htmlTableRow_0.Visible = false;
			}
			else
			{
				this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.textBox_0.Text = httpCookie.Values["MemLoginID"].ToString();
				this.htmlAnchor_0.Visible = false;
			}
			else
			{
				Order order = new Order();
				this.textBox_0.Text = "游客" + order.CreateOrderNumber();
			}
			if (this.strArticleCommentCondition == "1")
			{
				this.textBox_0.Text = "仅限登录用户";
				this.textBox_0.ReadOnly = true;
				this.htmlAnchor_0.Visible = true;
				this.button_0.Visible = false;
			}
			else
			{
				this.htmlAnchor_0.Visible = false;
			}
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("isallowcomment", "ShopNum1_Article", " and guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
				if (nameById == "0")
				{
					this.htmlGenericControl_0.Visible = false;
				}
			}
			catch
			{
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.strArticleCommentCondition == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
			}
			else
			{
				if (this.strAriticleCommentVerifyCode == "1")
				{
					if (this.textBox_3.Text == null)
					{
						MessageBox.Show("验证码不能为空值！");
						return;
					}
					if (this.Page.Session["code"] == null)
					{
						MessageBox.Show("验证码有误！");
						return;
					}
					if (this.textBox_3.Text.ToUpper() != this.Page.Session["code"].ToString().ToUpper())
					{
						MessageBox.Show("验证码输入错误！");
						return;
					}
				}
				ShopNum1_ArticleComment shopNum1_ArticleComment = new ShopNum1_ArticleComment();
				shopNum1_ArticleComment.Guid = Guid.NewGuid();
				shopNum1_ArticleComment.ArticleGuid = new Guid(this.Page.Request.QueryString["guid"].ToString());
				shopNum1_ArticleComment.Title = "";
				shopNum1_ArticleComment.Content = this.textBox_2.Text.Trim();
				shopNum1_ArticleComment.MemLoginID = this.textBox_0.Text.Trim();
				if (this.strArticleCommentISAudit == "0")
				{
					shopNum1_ArticleComment.IsAudit = 1;
				}
				else
				{
					shopNum1_ArticleComment.IsAudit = 0;
				}
				shopNum1_ArticleComment.IsReply = 0;
				shopNum1_ArticleComment.SendTime = DateTime.Now;
				shopNum1_ArticleComment.IsDeleted = 0;
				shopNum1_ArticleComment.IPAddress = Globals.IPAddress;
				shopNum1_ArticleComment.Rank = 1;
				ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
				int num = shopNum1_ArticleComment_Action.Add(shopNum1_ArticleComment);
				if (num > 0)
				{
					this.Page.Request.QueryString["guid"].ToString();
					MessageBox.Show("评论成功！");
					if (this.strArticleCommentISAudit == "0" && this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						string text = this.textBox_0.Text;
						string value = ShopSettings.GetValue("ArticleCommentRankSorce");
						string value2 = ShopSettings.GetValue("ArticleCommentSorce");
						if (int.Parse(value) > 0 || int.Parse(value2) > 0)
						{
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
							DataTable memInfoByMemberloginId = shopNum1_Member_Action.GetMemInfoByMemberloginId(text);
							if (memInfoByMemberloginId != null && memInfoByMemberloginId.Rows.Count > 0)
							{
								int num2 = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
								int num3 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
								int num4 = shopNum1_Member_Action.UpdateScore(new ShopNum1_Member
								{
									MemberRank = new int?(num2 + int.Parse(value)),
									Score = num3 + int.Parse(value2),
									MemLoginID = text
								});
								if (num4 >= 0)
								{
									if (int.Parse(value2) > 0)
									{
										ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
										shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
										shopNum1_ScoreModifyLog.OperateType = 1;
										shopNum1_ScoreModifyLog.CurrentScore = num3;
										shopNum1_ScoreModifyLog.OperateScore = int.Parse(value2);
										shopNum1_ScoreModifyLog.LastOperateScore = num3 + int.Parse(value2);
										shopNum1_ScoreModifyLog.Date = DateTime.Now;
										shopNum1_ScoreModifyLog.Memo = "商品评论赠送消费积分";
										shopNum1_ScoreModifyLog.MemLoginID = text;
										shopNum1_ScoreModifyLog.CreateUser = text;
										shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
										shopNum1_ScoreModifyLog.IsDeleted = 0;
										ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
										shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
									}
									if (int.Parse(value) > 0)
									{
										ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
										shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
										shopNum1_RankScoreModifyLog.OperateType = 1;
										shopNum1_RankScoreModifyLog.CurrentScore = num2;
										shopNum1_RankScoreModifyLog.OperateScore = int.Parse(value);
										shopNum1_RankScoreModifyLog.LastOperateScore = num2 + int.Parse(value);
										shopNum1_RankScoreModifyLog.Date = DateTime.Now;
										shopNum1_RankScoreModifyLog.Memo = "商品评论赠送等级积分";
										shopNum1_RankScoreModifyLog.MemLoginID = text;
										shopNum1_RankScoreModifyLog.CreateUser = text;
										shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
										shopNum1_RankScoreModifyLog.IsDeleted = 0;
										ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
										shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
									}
								}
							}
						}
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
