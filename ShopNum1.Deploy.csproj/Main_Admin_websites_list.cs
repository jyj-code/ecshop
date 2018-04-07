using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_websites_list : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelName;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid2;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonInsert;
	protected System.Web.UI.WebControls.Button ButtonUpdata;
	protected LinkButton ButtonDel;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
			this.DropDownListProductGuidBind();
			this.BindData();
		}
	}
	public void BindData()
	{
		this.returnProductCategory();
		this.Num1GridViewShow.DataBind();
	}
	public void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindData();
	}
	protected void ButtonInsert_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("websites_Operate.aspx?ID=" + this.CheckGuid.Value);
	}
	protected void ButtonUpdata_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("websites_Operate.aspx?ID=" + this.CheckGuid.Value + "&Type=1");
	}
	protected void ButtonDel_Click(object sender, EventArgs e)
	{
		IShopNum1_WebSite_Action shopNum1_WebSite_Action = LogicFactory.CreateShopNum1_WebSite_Action();
		int num = shopNum1_WebSite_Action.DeleteById(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			this.BindData();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		IShopNum1_WebSite_Action shopNum1_WebSite_Action = LogicFactory.CreateShopNum1_WebSite_Action();
		ShopNum1_OrderInfo_Action arg_10_0 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_WebSite_Action.DeleteById(commandArgument);
		if (num > 0)
		{
			this.BindData();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)LogicFactory.CreateShopNum1_WebSite_Action();
		DataTable list = shopNum1_WebSite_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid2.Items.Clear();
		this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)LogicFactory.CreateShopNum1_WebSite_Action();
			DataTable list = shopNum1_WebSite_Action.GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid3.Items.Clear();
		this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)LogicFactory.CreateShopNum1_WebSite_Action();
			DataTable list = shopNum1_WebSite_Action.GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void returnProductCategory()
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	public string GetListImageStatus(string isshow)
	{
		string result;
		if (isshow == "True")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
}
