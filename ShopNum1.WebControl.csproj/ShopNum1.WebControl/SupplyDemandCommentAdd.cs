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
	public class SupplyDemandCommentAdd : BaseWebControl
	{
		private string string_0 = "SupplyDemandCommentAdd.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private HtmlTableRow htmlTableRow_0;
		private HtmlAnchor htmlAnchor_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string SupplyDemandGuid
		{
			get;
			set;
		}
		public string strSupplyDemandCommentCondition
		{
			get;
			set;
		}
		public string strSupplyDemandCommentVerifyCode
		{
			get;
			set;
		}
		public SupplyDemandCommentAdd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trCode");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("LoginHref");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxContent");
			this.button_0 = (Button)skin.FindControl("ButtonAdd");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.SupplyDemandGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.strSupplyDemandCommentCondition = ShopSettings.GetValue("SupplyDemandCommentCondition");
			this.strSupplyDemandCommentVerifyCode = ShopSettings.GetValue("SupplyDemandCommentVerifyCode");
			if (this.strSupplyDemandCommentVerifyCode == "0")
			{
				this.htmlTableRow_0.Visible = false;
			}
			else
			{
				this.textBox_3 = (TextBox)skin.FindControl("TextBoxCode");
			}
			if (this.strSupplyDemandCommentCondition == "1")
			{
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					this.textBox_0.Text = httpCookie.Values["MemLoginID"].ToString();
					this.textBox_0.ReadOnly = true;
					this.htmlAnchor_0.Visible = false;
				}
				else
				{
					new Order();
					this.textBox_0.Text = "游客";
					this.htmlAnchor_0.Visible = true;
					this.htmlAnchor_0.HRef = string.Concat(new string[]
					{
						"http://",
						ShopSettings.siteDomain,
						"/Login",
						ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx",
						"?goback=",
						this.Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26")
					});
				}
			}
			else if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.textBox_0.Text = httpCookie.Values["MemLoginID"].ToString();
				this.textBox_0.ReadOnly = true;
				this.htmlAnchor_0.Visible = false;
			}
			else
			{
				new Order();
				this.textBox_0.Text = "游客";
				this.htmlAnchor_0.Visible = true;
				this.htmlAnchor_0.HRef = string.Concat(new string[]
				{
					"http://",
					ShopSettings.siteDomain,
					"/Login",
					ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx",
					"?goback=",
					this.Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26")
				});
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.strSupplyDemandCommentCondition == "1" && this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
			}
			else
			{
				if (this.strSupplyDemandCommentVerifyCode == "1")
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
				ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment = new ShopNum1_SupplyDemandComment();
				shopNum1_SupplyDemandComment.Guid = Guid.NewGuid();
				shopNum1_SupplyDemandComment.CreateIP = this.Page.Request.UserHostAddress;
				shopNum1_SupplyDemandComment.Title = this.textBox_1.Text;
				shopNum1_SupplyDemandComment.Content = this.textBox_2.Text;
				shopNum1_SupplyDemandComment.SupplyDemandGuid = this.SupplyDemandGuid;
				shopNum1_SupplyDemandComment.CreateMerber = this.textBox_0.Text;
				shopNum1_SupplyDemandComment.CreateTime = DateTime.Now;
				if (ShopSettings.GetValue("SupplyDemandCommentISAudit") == "1")
				{
					shopNum1_SupplyDemandComment.IsAudit = 0;
				}
				else
				{
					shopNum1_SupplyDemandComment.IsAudit = 1;
				}
				ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
				DataTable supplyDemandAssociatedMemberID = shopNum1_SupplyDemandComment_Action.GetSupplyDemandAssociatedMemberID(this.SupplyDemandGuid);
				if (supplyDemandAssociatedMemberID.Rows.Count > 0)
				{
					shopNum1_SupplyDemandComment.AssociateMemberID = supplyDemandAssociatedMemberID.Rows[0][0].ToString();
				}
				int num = shopNum1_SupplyDemandComment_Action.AddSupplyDemandComment(shopNum1_SupplyDemandComment);
				if (num > 0)
				{
					MessageBox.Show("评论成功！");
					if (ShopSettings.GetValue("SupplyDemandCommentISAudit") == "0")
					{
						if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
						{
							string text = this.textBox_0.Text;
							string value = ShopSettings.GetValue("MySupplyDemandCommentRankSorce");
							string value2 = ShopSettings.GetValue("MySupplyDemandCommentSorce");
							if (int.Parse(value) > 0 || int.Parse(value2) > 0)
							{
								ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
								DataTable memInfoByMemberloginId = shopNum1_Member_Action.GetMemInfoByMemberloginId(text);
								int num2 = 0;
								int num3 = 0;
								if (memInfoByMemberloginId == null || memInfoByMemberloginId.Rows.Count <= 0)
								{
									return;
								}
								if (!string.IsNullOrEmpty(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString()))
								{
									num2 = Convert.ToInt32(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
								}
								if (!string.IsNullOrEmpty(memInfoByMemberloginId.Rows[0]["Score"].ToString()))
								{
									num3 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
								}
								int num4 = shopNum1_Member_Action.UpdateScore(new ShopNum1_Member
								{
									MemberRank = new int?(num2 + int.Parse(value)),
									Score = num3 + int.Parse(value2),
									MemLoginID = text
								});
								if (num4 < 0)
								{
									return;
								}
								if (int.Parse(value2) > 0)
								{
									ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
									shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
									shopNum1_ScoreModifyLog.OperateType = 1;
									shopNum1_ScoreModifyLog.CurrentScore = num3;
									shopNum1_ScoreModifyLog.OperateScore = int.Parse(value2);
									shopNum1_ScoreModifyLog.LastOperateScore = num3 + int.Parse(value2);
									shopNum1_ScoreModifyLog.Date = DateTime.Now;
									shopNum1_ScoreModifyLog.Memo = "供求评论赠送消费积分";
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
									shopNum1_RankScoreModifyLog.Memo = "供求评论赠送等级积分";
									shopNum1_RankScoreModifyLog.MemLoginID = text;
									shopNum1_RankScoreModifyLog.CreateUser = text;
									shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
									shopNum1_RankScoreModifyLog.IsDeleted = 0;
									ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
									shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
								}
							}
						}
						this.Page.Response.Redirect(this.Page.Request.Url.ToString());
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
