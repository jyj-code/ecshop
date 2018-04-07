using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ZtcGoodsDetal : Page, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Repeater RepeaterShow;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldMemLoginID;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldType;
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
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = this.Page.Request.QueryString["ID"].Replace("'", "");
		}
		this.GetData();
	}
	public void GetData()
	{
		ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
		DataTable infoByGuid = shopNum1_ZtcGoods_Action.GetInfoByGuid(this.hiddenFieldGuid.Value);
		if (infoByGuid != null && infoByGuid.Rows.Count > 0)
		{
			this.RepeaterShow.DataSource = infoByGuid.DefaultView;
			this.RepeaterShow.DataBind();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ZtcGoods_List.aspx");
	}
}
