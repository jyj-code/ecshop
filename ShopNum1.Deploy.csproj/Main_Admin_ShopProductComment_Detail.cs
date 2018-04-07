using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopProductComment_Detail : PageBase, IRequiresSessionState
{
	protected TextBox TextBoxName;
	protected TextBox TextBoxMenLoginID;
	protected TextBox TextBoxCommentTime;
	protected TextBox TextBoxCommentType;
	protected TextBox TextBoxSpeed;
	protected TextBox TextBoxAttitude;
	protected TextBox TextBoxCharacter;
	protected TextBox TextBoxReplyTime;
	protected TextBox TextBoxComment;
	protected TextBox TextBoxReply;
	protected Button ButtonAudit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	private string GoBack
	{
		get;
		set;
	}
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		string guid = this.Page.Request.QueryString["Guid"].Replace("'", "");
		this.GoBack = ((this.Page.Request.QueryString["Type"] == null) ? "-1" : this.Page.Request.QueryString["Type"]);
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
		DataTable dataTable = shopNum1_ProductComment_Action.Search(guid);
		this.TextBoxName.Text = dataTable.Rows[0]["ProductName"].ToString();
		this.TextBoxMenLoginID.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		this.TextBoxCommentTime.Text = dataTable.Rows[0]["CommentTime"].ToString();
		if (dataTable.Rows[0]["CommentType"].ToString() == "5")
		{
			this.TextBoxCommentType.Text = "好评";
		}
		else if (dataTable.Rows[0]["CommentType"].ToString() == "3")
		{
			this.TextBoxCommentType.Text = "中评";
		}
		else
		{
			this.TextBoxCommentType.Text = "差评";
		}
		string text = dataTable.Rows[0]["Speed"].ToString();
		string text2 = text;
		if (text2 != null)
		{
			if (!(text2 == "5"))
			{
				if (!(text2 == "4"))
				{
					if (!(text2 == "3"))
					{
						if (!(text2 == "2"))
						{
							if (text2 == "1")
							{
								this.TextBoxSpeed.Text = "很慢";
							}
						}
						else
						{
							this.TextBoxSpeed.Text = "慢";
						}
					}
					else
					{
						this.TextBoxSpeed.Text = "一般";
					}
				}
				else
				{
					this.TextBoxSpeed.Text = "比较快";
				}
			}
			else
			{
				this.TextBoxSpeed.Text = "很快";
			}
		}
		string text3 = dataTable.Rows[0]["Attitude"].ToString();
		text2 = text3;
		if (text2 != null)
		{
			if (!(text2 == "5"))
			{
				if (!(text2 == "4"))
				{
					if (!(text2 == "3"))
					{
						if (!(text2 == "2"))
						{
							if (text2 == "1")
							{
								this.TextBoxAttitude.Text = "很差";
							}
						}
						else
						{
							this.TextBoxAttitude.Text = "差";
						}
					}
					else
					{
						this.TextBoxAttitude.Text = "一般";
					}
				}
				else
				{
					this.TextBoxAttitude.Text = "比较好";
				}
			}
			else
			{
				this.TextBoxAttitude.Text = "很好";
			}
		}
		string text4 = dataTable.Rows[0]["Character"].ToString();
		text2 = text4;
		if (text2 != null)
		{
			if (!(text2 == "5"))
			{
				if (!(text2 == "4"))
				{
					if (!(text2 == "3"))
					{
						if (!(text2 == "2"))
						{
							if (text2 == "1")
							{
								this.TextBoxCharacter.Text = "很不相符";
							}
						}
						else
						{
							this.TextBoxCharacter.Text = "不相符";
						}
					}
					else
					{
						this.TextBoxCharacter.Text = "相符";
					}
				}
				else
				{
					this.TextBoxCharacter.Text = "比较相符";
				}
			}
			else
			{
				this.TextBoxCharacter.Text = "很相符";
			}
		}
		this.TextBoxComment.Text = dataTable.Rows[0]["Comment"].ToString();
		this.TextBoxReplyTime.Text = dataTable.Rows[0]["ReplyTime"].ToString();
		this.TextBoxReply.Text = dataTable.Rows[0]["Reply"].ToString();
		if (dataTable.Rows[0]["isAudit"].ToString() == "1" || dataTable.Rows[0]["isAudit"].ToString() == "2")
		{
			this.ButtonAudit.Visible = false;
			this.ButtonCancelAudit.Visible = false;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.GoBack == "List")
		{
			base.Response.Redirect("ShopProductComment_List.aspx");
		}
		else if (this.GoBack == "Audit")
		{
			base.Response.Redirect("ShopProductCommentAudit_List.aspx");
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable commentTypeByGuid = shopNum1_ProductComment_Action.GetCommentTypeByGuid(this.Page.Request.QueryString["Guid"].ToString());
		string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("GoodAppraiseReputation");
		string s2 = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("StandardAppraiseReputation");
		string s3 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("BadAppraiseReputation");
		int score = 0;
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		int num = (ShopSettings.GetValue("MyProductCommentRankSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyProductCommentRankSorce"));
		int num2 = (ShopSettings.GetValue("MyProductCommentSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyProductCommentSorce"));
		for (int i = 0; i < commentTypeByGuid.Rows.Count; i++)
		{
			if (!(commentTypeByGuid.Rows[i]["IsAudit"].ToString() == "1"))
			{
				if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "5")
				{
					score = int.Parse(s);
				}
				else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "3")
				{
					score = int.Parse(s2);
				}
				else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "1")
				{
					score = -int.Parse(s3);
				}
				shopNum1_ShopInfoList_Action.UpdateShopReputationByMemLoginID(commentTypeByGuid.Rows[i]["ShopLoginId"].ToString(), score);
				shopNum1_Member_Action.UpdateMemberScore(commentTypeByGuid.Rows[i]["MemLoginID"].ToString(), num, num2);
				this.method_5(num2, num, commentTypeByGuid.Rows[i]["MemLoginID"].ToString());
			}
		}
		if (shopNum1_ProductComment_Action.UpdateProductAudit(this.Page.Request.QueryString["Guid"].ToString(), "1") > 0)
		{
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5(int int_0, int int_1, string string_6)
	{
		string nameById = Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + string_6 + "'");
		int currentScore = 0;
		int currentScore2 = 0;
		if (nameById != "" && nameById.IndexOf("-") != -1)
		{
			currentScore = Convert.ToInt32(nameById.Split(new char[]
			{
				'-'
			})[1]);
			currentScore2 = Convert.ToInt32(nameById.Split(new char[]
			{
				'-'
			})[0]);
		}
		if (int_0 > 0)
		{
			ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
			shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
			shopNum1_ScoreModifyLog.OperateType = 1;
			shopNum1_ScoreModifyLog.CurrentScore = currentScore;
			shopNum1_ScoreModifyLog.OperateScore = int_0;
			shopNum1_ScoreModifyLog.LastOperateScore = int_0;
			shopNum1_ScoreModifyLog.Date = DateTime.Now;
			shopNum1_ScoreModifyLog.Memo = "买家评论送消费积分";
			shopNum1_ScoreModifyLog.MemLoginID = string_6;
			shopNum1_ScoreModifyLog.CreateUser = string_6;
			shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_ScoreModifyLog.IsDeleted = 0;
			ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
			shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
		}
		if (int_1 > 0)
		{
			ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
			shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
			shopNum1_RankScoreModifyLog.OperateType = 1;
			shopNum1_RankScoreModifyLog.CurrentScore = currentScore2;
			shopNum1_RankScoreModifyLog.OperateScore = int_1;
			shopNum1_RankScoreModifyLog.LastOperateScore = int_1;
			shopNum1_RankScoreModifyLog.Date = DateTime.Now;
			shopNum1_RankScoreModifyLog.Memo = "买家评论送等级积分";
			shopNum1_RankScoreModifyLog.MemLoginID = string_6;
			shopNum1_RankScoreModifyLog.CreateUser = string_6;
			shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_RankScoreModifyLog.IsDeleted = 0;
			ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
			shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.UpdateProductAudit(this.Page.Request.QueryString["Guid"].ToString(), "2") > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
}
