using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_MemberActualAuthentication_Audit : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.TextBox TextBoxRealName;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxCardNum;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
	protected System.Web.UI.WebControls.Button ButtonSearchShop;
	protected System.Web.UI.WebControls.Button ButtonOperate;
	protected System.Web.UI.WebControls.Button ButtonOperate1;
	protected MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected HtmlForm form1;
	private ShopNum1_Member_Action shopNum1_Member_Action_0 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
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
		if (!base.IsPostBack)
		{
			base.CheckLogin();
			this.BindProductIsAudit();
			this.method_5();
		}
	}
	protected void BindProductIsAudit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已通过";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MemberActualAuthentication_Detai.aspx?guid=" + this.CheckGuid.Value);
	}
}
