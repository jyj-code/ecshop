using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Theme_ProductList : PageBase, IRequiresSessionState
{
	public DataTable dt = null;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
	protected LinkButton LinkButton1;
	protected AgentAdmin_MessageShow MessageShow;
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
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			if (Common.ReqStr("delete") != "")
			{
				this.string_6 = Common.ReqStr("delete");
				this.shopNum1_Activity_Action_0.DeleteThemeActivtyProduct("'" + this.string_6 + "'");
				base.Response.Redirect("Theme_ProductList.aspx?state=3&Aid=" + Common.ReqStr("Aid"));
			}
			if (Common.ReqStr("agree") != "")
			{
				this.string_6 = Common.ReqStr("agree");
				this.shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(this.string_6, "1");
				base.Response.Redirect("Theme_ProductList.aspx?state=0&Aid=" + Common.ReqStr("Aid"));
			}
			if (Common.ReqStr("disagree") != "")
			{
				this.string_6 = Common.ReqStr("disagree");
				this.shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(this.string_6, "2");
				base.Response.Redirect("Theme_ProductList.aspx?state=0&Aid=" + Common.ReqStr("Aid"));
			}
			if (Common.ReqStr("end") != "")
			{
				this.string_6 = Common.ReqStr("end");
				this.shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(this.string_6, "3");
				base.Response.Redirect("Theme_ProductList.aspx?state=1&Aid=" + Common.ReqStr("Aid"));
			}
			this.string_5 = " and ThemeGuid='" + Common.ReqStr("Aid") + "' ";
			if (Common.ReqStr("state") != "")
			{
				this.string_5 = this.string_5 + "  and IsAudit=" + Common.ReqStr("state");
			}
			else
			{
				this.string_5 += " and IsAudit=0";
			}
			this.method_5();
		}
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
		DataTable dataTable = this.shopNum1_Activity_Action_0.SelectThemeActivtyProduct(text2, text3, this.string_5, "0");
		int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		PageListBll pageListBll = new PageListBll(text, true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text2);
		pageList.PageID = Convert.ToInt32(text3);
		pageList.RecordCount = recordCount;
		this.pageDiv.InnerHtml = pageListBll.GetPageListNew(pageList);
		this.dt = this.shopNum1_Activity_Action_0.SelectThemeActivtyProduct(text2, text3, this.string_5, "1");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		this.string_6 = this.CheckGuid.Value.Replace("''", "");
		this.shopNum1_Activity_Action_0.DeleteThemeActivtyProduct(this.string_6);
		this.method_5();
		this.MessageShow.Visible = true;
		this.MessageShow.ShowMessage("删除成功！");
		this.method_5();
	}
}
