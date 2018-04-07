using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Limit_ActivityList : Page, IRequiresSessionState
{
	public DataTable dt = null;
	private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
	protected LinkButton LinkButton1;
	protected MessageShow MessageShow;
	protected HtmlGenericControl pageDiv;
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
		if (Common.ReqStr("agree") != "")
		{
			this.shopNum1_Activity_Action_0.UpdateActivityState(Common.ReqStr("agree"), "1");
		}
		if (Common.ReqStr("disagree") != "")
		{
			this.shopNum1_Activity_Action_0.UpdateActivityState(Common.ReqStr("disagree"), "2");
		}
		if (Common.ReqStr("delete") != "")
		{
			this.shopNum1_Activity_Action_0.DeleteActivity(Common.ReqStr("delete"));
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("DelYes");
		}
		if (Common.ReqStr("end") != "")
		{
			this.shopNum1_Activity_Action_0.CloseActivity(Common.ReqStr("end"));
		}
		if (!this.Page.IsPostBack)
		{
			this.method_0();
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
	private void method_0()
	{
		string condition = " AND TYPE=2";
		string text = base.Request.RawUrl;
		if (text.IndexOf("?") != -1)
		{
			text = text.Split(new char[]
			{
				'?'
			})[0];
		}
		string text2 = "10";
		string text3 = "1";
		if (Common.ReqStr("pagesize") != "")
		{
			text2 = Common.ReqStr("pagesize");
		}
		if (Common.ReqStr("pageid") != "")
		{
			text3 = Common.ReqStr("pageid");
		}
		DataTable dataTable = this.shopNum1_Activity_Action_0.SelectActivity(text2, text3, condition, "0");
		int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		PageListBll pageListBll = new PageListBll(text, true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text2);
		pageList.PageID = Convert.ToInt32(text3);
		pageList.RecordCount = recordCount;
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (Convert.ToInt32(text3) > pageList.PageCount)
		{
			text3 = pageList.PageCount.ToString();
		}
		this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.dt = this.shopNum1_Activity_Action_0.SelectActivity(text2, text3, condition, "1");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		this.shopNum1_Activity_Action_0.DeleteActivity(this.CheckGuid.Value);
		this.MessageShow.Visible = true;
		this.MessageShow.ShowMessage("批量删除成功！");
		this.method_0();
	}
}
