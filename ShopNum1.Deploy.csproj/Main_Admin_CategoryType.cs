using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class Main_Admin_CategoryType : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected HtmlGenericControl pageDiv;
	protected HtmlForm form1;
	public DataTable dt_CategoryType = null;
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
		PageList1 pageList = new PageList1();
		int num = 1;
		int num2 = 10;
		if (base.Request.QueryString["pagesize"] != null)
		{
			num2 = Convert.ToInt32(base.Request.QueryString["pagesize"].ToString());
		}
		if (base.Request.QueryString["pageid"] != null)
		{
			num = Convert.ToInt32(base.Request.QueryString["pageid"].ToString());
		}
		ShopNum1_CategoryType_Action shopNum1_CategoryType_Action = new ShopNum1_CategoryType_Action();
		int recordCount = Convert.ToInt32(shopNum1_CategoryType_Action.SelectCategoryType_List(num2, num, "", 0).Rows[0][0]);
		PageListBll pageListBll = new PageListBll(text, true);
		pageList.PageSize = num2;
		pageList.PageID = num;
		pageList.RecordCount = recordCount;
		this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.dt_CategoryType = shopNum1_CategoryType_Action.SelectCategoryType_List(num2, num, "", 1);
	}
}
