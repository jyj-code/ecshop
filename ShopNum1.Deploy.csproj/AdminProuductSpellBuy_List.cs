using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AdminProuductSpellBuy_List : PageBase, IRequiresSessionState
{
	public DataTable dt = null;
	private string string_5;
	private ShopNum1_GroupProduct_Action shopNum1_GroupProduct_Action_0 = (ShopNum1_GroupProduct_Action)LogicFactory.CreateShopNum1_GroupProduct_Action();
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected HtmlGenericControl pageDiv;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
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
				this.string_5 = Common.ReqStr("delete");
				this.shopNum1_GroupProduct_Action_0.DeleteButch(this.string_5);
			}
			this.method_6();
		}
	}
	private string method_5()
	{
		StringBuilder stringBuilder = new StringBuilder(" and state=1");
		string text = Common.ReqStr("pname");
		string text2 = Common.ReqStr("sname");
		string text3 = Common.ReqStr("sp");
		string text4 = Common.ReqStr("ep");
		if (text != "")
		{
			stringBuilder.Append(" and pname like '%" + text + "%'");
		}
		if (text2 != "")
		{
			stringBuilder.Append(" and shopname like '%" + text2 + "%'");
		}
		if (text3 != "" && text4 != "")
		{
			stringBuilder.Append(string.Concat(new string[]
			{
				" and Groupprice>='",
				text3,
				"' and Groupprice<='",
				text4,
				"'"
			}));
		}
		return stringBuilder.ToString();
	}
	private void method_6()
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
		DataTable dataTable = this.shopNum1_GroupProduct_Action_0.SelectGroupByAId(text2, text3, this.method_5(), "3");
		int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		PageListBll pageListBll = new PageListBll(text, true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text2);
		pageList.PageID = Convert.ToInt32(text3);
		pageList.RecordCount = recordCount;
		this.pageDiv.InnerHtml = pageListBll.GetPageListNew(pageList);
		this.dt = this.shopNum1_GroupProduct_Action_0.SelectGroupByAId(text2, text3, this.method_5(), "2");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		this.string_5 = this.CheckGuid.Value.Replace("''", "");
		this.shopNum1_GroupProduct_Action_0.DeleteButch(this.string_5);
		this.method_6();
		this.MessageShow.Visible = true;
		this.MessageShow.ShowMessage("删除成功！");
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
	}
}
