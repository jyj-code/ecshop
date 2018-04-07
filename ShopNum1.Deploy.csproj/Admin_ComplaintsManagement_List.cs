using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ComplaintsManagement_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
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
		this.DropDownListType.Items.Add(new ListItem("炒作信用度", "炒作信用度"));
		this.DropDownListType.Items.Add(new ListItem("哄抬物价", "哄抬物价"));
		this.DropDownListType.Items.Add(new ListItem("图片发布侵权", "图片发布侵权"));
		this.DropDownListType.Items.Add(new ListItem("发布广告信息", "发布广告信息"));
		this.DropDownListType.Items.Add(new ListItem("支付方式不符合商品", "支付方式不符合商品"));
		this.DropDownListType.Items.Add(new ListItem("出售禁售货", "出售禁售货"));
		this.DropDownListType.Items.Add(new ListItem("放错类目属性", "放错类目属性"));
		this.DropDownListType.Items.Add(new ListItem("重复铺货", "重复铺货"));
		this.DropDownListType.Items.Add(new ListItem("滥用关键字", "滥用关键字"));
	}
	private void method_6()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonReply_Click(object sender, EventArgs e)
	{
		ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
		DataTable complaintsManagement = shopNum1_MemberReport_Action.GetComplaintsManagement(this.CheckGuid.Value);
		if (complaintsManagement.Rows.Count > 0)
		{
			base.Response.Redirect("ComplaintsManagement_Operate.aspx?guid=" + this.CheckGuid.Value);
		}
		else
		{
			MessageBox.Show("举报的商品已被删除或不存在！");
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ComplaintsManagement_Action shopNum1_ComplaintsManagement_Action = (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
		int num = shopNum1_ComplaintsManagement_Action.DeleteReport(this.CheckGuid.Value);
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
		ShopNum1_ComplaintsManagement_Action shopNum1_ComplaintsManagement_Action = (ShopNum1_ComplaintsManagement_Action)LogicFactory.CreateShopNum1_ComplaintsManagement_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_ComplaintsManagement_Action.DeleteReport(commandArgument);
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
