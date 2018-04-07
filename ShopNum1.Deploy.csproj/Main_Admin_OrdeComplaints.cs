using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_OrdeComplaints : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxComplaintShop;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton Button1;
	protected LinkButton ButtonReply;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
			this.method_5();
			this.method_6();
		}
	}
	private void method_5()
	{
		this.DropDownListType.Items.Clear();
		this.DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
		this.DropDownListType.Items.Add(new ListItem("恶意骚扰", "恶意骚扰"));
		this.DropDownListType.Items.Add(new ListItem("售后保障服务", "售后保障服务"));
		this.DropDownListType.Items.Add(new ListItem("未收到货", "未收到货"));
		this.DropDownListType.Items.Add(new ListItem("违背承诺", "违背承诺"));
	}
	private void method_6()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string ShowType(string type)
	{
		return "";
	}
	protected void ButtonReply_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrdeComplaints_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_OrdeComplaints_Action shopNum1_OrdeComplaints_Action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
		int num = shopNum1_OrdeComplaints_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.method_6();
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
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_OrdeComplaints_Action shopNum1_OrdeComplaints_Action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
		int num = shopNum1_OrdeComplaints_Action.Delete(commandArgument);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.method_6();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected string IsProcess(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未处理";
		}
		else if (object_0.ToString() == "1")
		{
			result = "处理中";
		}
		else if (object_0.ToString() == "2")
		{
			result = "已处理";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
}
