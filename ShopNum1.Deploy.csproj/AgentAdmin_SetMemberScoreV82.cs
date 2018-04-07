using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_SetMemberScoreV82 : PageBase, IRequiresSessionState
{
	protected Label lblMemloginId;
	protected HtmlInputText txtScore;
	protected HtmlTextArea txtRemark;
	protected Button btnSetScore;
	protected HtmlInputHidden hidMemloginId;
	protected HtmlInputHidden CheckGuid;
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
		if (!this.Page.IsPostBack)
		{
			if (Common.ReqStr("guid") != "")
			{
				string strSql = "select memloginid from shopnum1_orderinfo where oderstatus=3 and guid='" + Common.ReqStr("guid") + "'";
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
				if (dataTable.Rows.Count > 0)
				{
					this.lblMemloginId.Text = dataTable.Rows[0]["memloginid"].ToString();
					this.hidMemloginId.Value = dataTable.Rows[0]["memloginid"].ToString();
				}
			}
			else if (Common.ReqStr("mguid") != "")
			{
				string strSql = "select memloginid from shopnum1_member where guid='" + Common.ReqStr("mguid") + "'";
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
				if (dataTable.Rows.Count > 0)
				{
					this.lblMemloginId.Text = dataTable.Rows[0]["memloginid"].ToString();
					this.hidMemloginId.Value = dataTable.Rows[0]["memloginid"].ToString();
				}
			}
		}
	}
	protected void btnSetScore_Click(object sender, EventArgs e)
	{
		if (this.txtScore.Value == "")
		{
			MessageBox.Show("赠送的积分不能为空！");
		}
		else
		{
			if (this.hidMemloginId.Value != "" && Common.ReqStr("guid") != "")
			{
				string value = this.hidMemloginId.Value;
				int num = Convert.ToInt32(this.txtScore.Value);
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				shopNum1_Member_Action.UpdateMemberScore(value, 0, num);
				this.method_5(num, 0, value);
				this.OrderOperateLog("平台赠送积分", "平台赠送" + num + "个消费积分", "无");
				this.Page.Response.Redirect("Order_List.aspx");
			}
			if (this.hidMemloginId.Value != "" && Common.ReqStr("mguid") != "")
			{
				string value = this.hidMemloginId.Value;
				int num = Convert.ToInt32(this.txtScore.Value);
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				shopNum1_Member_Action.UpdateMemberScore(value, 0, num);
				this.method_5(num, 0, value);
				this.Page.Response.Redirect("Order_List.aspx");
			}
		}
	}
	protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
	{
		if (!string.IsNullOrEmpty(Common.ReqStr("guid")))
		{
			ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
			shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
			shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(Common.ReqStr("guid"));
			shopNum1_OrderOperateLog.OderStatus = 1;
			shopNum1_OrderOperateLog.ShipmentStatus = 0;
			shopNum1_OrderOperateLog.PaymentStatus = 0;
			shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
			shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
			shopNum1_OrderOperateLog.Memo = memo;
			shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			shopNum1_OrderOperateLog.IsDeleted = 0;
			shopNum1_OrderOperateLog.CreateUser = this.hidMemloginId.Value;
			ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
			shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
		}
	}
	private void method_5(int int_0, int int_1, string string_5)
	{
		string nameById = Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + string_5 + "'");
		int num = 0;
		int currentScore = 0;
		if (nameById != "" && nameById.IndexOf("-") != -1)
		{
			num = Convert.ToInt32(nameById.Split(new char[]
			{
				'-'
			})[1]);
			currentScore = Convert.ToInt32(nameById.Split(new char[]
			{
				'-'
			})[0]);
		}
		if (int_0 > 0)
		{
			ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
			shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
			shopNum1_ScoreModifyLog.OperateType = 1;
			shopNum1_ScoreModifyLog.CurrentScore = num;
			shopNum1_ScoreModifyLog.OperateScore = int_0;
			shopNum1_ScoreModifyLog.LastOperateScore = int_0 + num;
			shopNum1_ScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			shopNum1_ScoreModifyLog.Memo = this.txtRemark.Value;
			shopNum1_ScoreModifyLog.MemLoginID = string_5;
			shopNum1_ScoreModifyLog.CreateUser = base.ShopNum1LoginID;
			shopNum1_ScoreModifyLog.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
			shopNum1_ScoreModifyLog.IsDeleted = 0;
			ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
			shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
		}
		if (int_1 > 0)
		{
			ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
			shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
			shopNum1_RankScoreModifyLog.OperateType = 1;
			shopNum1_RankScoreModifyLog.CurrentScore = currentScore;
			shopNum1_RankScoreModifyLog.OperateScore = int_1;
			shopNum1_RankScoreModifyLog.LastOperateScore = int_1;
			shopNum1_RankScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			shopNum1_RankScoreModifyLog.Memo = "买家评论送等级积分";
			shopNum1_RankScoreModifyLog.MemLoginID = string_5;
			shopNum1_RankScoreModifyLog.CreateUser = base.ShopNum1LoginID;
			shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
			shopNum1_RankScoreModifyLog.IsDeleted = 0;
			ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
			shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
		}
	}
}
