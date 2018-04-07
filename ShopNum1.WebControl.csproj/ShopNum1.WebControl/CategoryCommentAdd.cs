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
	public class CategoryCommentAdd : BaseWebControl
	{
		private string string_0 = "CategoryCommentAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private HtmlTableRow htmlTableRow_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private HtmlAnchor htmlAnchor_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string CategoryGuid
		{
			get;
			set;
		}
		public string strCategoryInfoCommentVerifyCode
		{
			get;
			set;
		}
		public string strCategoryInfoCommentCondition
		{
			get;
			set;
		}
		public CategoryCommentAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("LoginHref");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trCode");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxCodex");
			this.button_0 = (Button)skin.FindControl("ButtonAdd");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.CategoryGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.strCategoryInfoCommentCondition = ShopSettings.GetValue("CategoryInfoCommentCondition");
			this.strCategoryInfoCommentVerifyCode = ShopSettings.GetValue("CategoryInfoCommentVerifyCode");
			if (this.strCategoryInfoCommentVerifyCode == "0")
			{
				this.htmlTableRow_0.Visible = false;
			}
			else
			{
				this.textBox_3 = (TextBox)skin.FindControl("TextBoxCodex");
			}
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.textBox_0.Text = httpCookie.Values["MemLoginID"].ToString();
				if (!(this.strCategoryInfoCommentCondition == "1"))
				{
				}
				this.textBox_0.ReadOnly = true;
				this.htmlAnchor_0.Visible = false;
			}
			else if (this.strCategoryInfoCommentCondition == "1")
			{
				this.htmlAnchor_0.Visible = true;
				this.htmlAnchor_0.HRef = "http://" + ShopSettings.siteDomain + "/Login" + (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
			}
			else
			{
				this.htmlAnchor_0.Visible = false;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.strCategoryInfoCommentCondition == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
			}
			else
			{
				if (this.strCategoryInfoCommentVerifyCode == "1")
				{
					if (this.textBox_3.Text == null)
					{
						MessageBox.Show("验证码不能为空值！");
						return;
					}
					if (this.textBox_3.Text.ToUpper() != this.Page.Session["code"].ToString().ToUpper())
					{
						MessageBox.Show("验证码输入错误！");
						return;
					}
				}
				ShopNum1_CategoryComment shopNum1_CategoryComment = new ShopNum1_CategoryComment();
				shopNum1_CategoryComment.Guid = Guid.NewGuid();
				shopNum1_CategoryComment.CreateIP = this.Page.Request.UserHostAddress;
				shopNum1_CategoryComment.Title = this.textBox_1.Text;
				shopNum1_CategoryComment.Content = this.textBox_2.Text;
				if (ShopSettings.GetValue("CategoryInfoCommentISAudit") == "1")
				{
					shopNum1_CategoryComment.IsAudit = 0;
				}
				else
				{
					shopNum1_CategoryComment.IsAudit = 1;
				}
				shopNum1_CategoryComment.CategoryInfoGuid = new Guid(this.CategoryGuid);
				shopNum1_CategoryComment.CreateMember = this.textBox_0.Text;
				shopNum1_CategoryComment.CreateTime = DateTime.Now;
				ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
				DataTable cateGoryAssociatedMemberID = shopNum1_CategoryComment_Action.GetCateGoryAssociatedMemberID(this.CategoryGuid);
				if (cateGoryAssociatedMemberID.Rows.Count > 0)
				{
					shopNum1_CategoryComment.AssociatedMemberID = cateGoryAssociatedMemberID.Rows[0]["AssociatedMemberID"].ToString();
				}
				int num = shopNum1_CategoryComment_Action.Add(shopNum1_CategoryComment);
				if (num > 0)
				{
					MessageBox.Show("评论成功！");
					this.textBox_1.Text = "";
					this.textBox_2.Text = "";
					if (ShopSettings.GetValue("CategoryInfoCommentISAudit") == "0" && this.Page.Request.Cookies["MemberLoginCookie"] != null)
					{
						string text = this.textBox_0.Text;
						string value = ShopSettings.GetValue("MyCategoryInfoCommentRankSorce");
						string value2 = ShopSettings.GetValue("MyCategoryInfoCommentSorce");
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
										shopNum1_ScoreModifyLog.Memo = "分类信息评论赠送消费积分";
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
										shopNum1_RankScoreModifyLog.Memo = "分类信息评论赠送等级积分";
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
			}
		}
	}
}
