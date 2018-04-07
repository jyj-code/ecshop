using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Theme_ActivityList : PageBase, IRequiresSessionState
{
	public DataTable dt = null;
	private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected HtmlGenericControl pageDiv;
	protected HtmlGenericControl showPage;
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
			try
			{
				if (Common.ReqStr("close") != "")
				{
					string text = Common.ReqStr("close");
					this.shopNum1_Activity_Action_0.CloseActivity(text);
				}
				else if (Common.ReqStr("delete") != "")
				{
					string text = Common.ReqStr("delete");
					this.shopNum1_Activity_Action_0.DeleteThemeActivty("'" + text + "'");
					this.MessageShow.Visible = true;
					this.MessageShow.ShowMessage("删除成功！");
				}
			}
			catch
			{
			}
			this.method_5();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		string result;
		if (SubstationID == "all")
		{
			result = "全国站";
		}
		else
		{
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				result = dataBySubstationID.Rows[0]["Name"].ToString();
			}
			else
			{
				result = "分站不存在";
			}
		}
		return result;
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		string guid = this.CheckGuid.Value.Replace("''", "");
		this.shopNum1_Activity_Action_0.DeleteThemeActivty(guid);
		this.method_5();
		this.MessageShow.Visible = true;
		this.MessageShow.ShowMessage("删除成功！");
	}
	private void method_5()
	{
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
		DataTable dataTable = this.shopNum1_Activity_Action_0.SelectThemeActivty(text2, text3, "AND SubstationID='" + base.SubstationID + "' ", "0");
		int num = Convert.ToInt32(dataTable.Rows[0][0]);
		PageListBll pageListBll = new PageListBll(text, true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text2);
		pageList.PageID = Convert.ToInt32(text3);
		pageList.RecordCount = num;
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (pageList.PageID > pageList.PageCount)
		{
			pageList.PageID = pageList.PageCount;
		}
		if (pageList.PageSize > num || pageList.PageCount == 1)
		{
			this.showPage.Visible = false;
		}
		else
		{
			this.showPage.Visible = true;
		}
		this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.dt = this.shopNum1_Activity_Action_0.SelectThemeActivty(text2, pageList.PageID.ToString(), "AND SubstationID='" + base.SubstationID + "' ", "1");
	}
}
