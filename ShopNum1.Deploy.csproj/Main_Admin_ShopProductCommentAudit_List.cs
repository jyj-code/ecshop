using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopProductCommentAudit_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected System.Web.UI.WebControls.TextBox TextBox3;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateMerber;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected Localize Localize3;
	protected System.Web.UI.WebControls.TextBox TextBoxProductName;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected Localize LocalizeCreateTime;
	protected System.Web.UI.WebControls.TextBox TextBoxTime1;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxTime2;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownList1;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
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
		if (!base.IsPostBack)
		{
			this.GetSubstationID();
			this.BindGrid();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.DeleteProduct(this.CheckGuid.Value.ToString()) > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.DeleteProduct(guids) > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable commentTypeByGuid = shopNum1_ProductComment_Action.GetCommentTypeByGuid(this.CheckGuid.Value);
		string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("GoodAppraiseReputation");
		string s2 = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("StandardAppraiseReputation");
		string s3 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("BadAppraiseReputation");
		int score = 0;
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
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
		if (shopNum1_ProductComment_Action.UpdateProductAudit(this.CheckGuid.Value, "1") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5(int int_0, int int_1, string string_5)
	{
		string nameById = Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + string_5 + "'");
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
			shopNum1_ScoreModifyLog.MemLoginID = string_5;
			shopNum1_ScoreModifyLog.CreateUser = string_5;
			shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_ScoreModifyLog.IsDeleted = 0;
			ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
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
			shopNum1_RankScoreModifyLog.MemLoginID = string_5;
			shopNum1_RankScoreModifyLog.CreateUser = string_5;
			shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_RankScoreModifyLog.IsDeleted = 0;
			ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
			shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.UpdateProductAudit(this.CheckGuid.Value, "2") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else
		{
			result = "审核未通过";
		}
		return result;
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopProductComment_Detail.aspx?Guid=" + this.CheckGuid.Value.ToString() + "&Type=Audit");
	}
}
