using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopNum1_SupplyDemand_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected Localize LocalizeFavourTickitName;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Cf;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Cs;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Ct;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime1;
	protected RegularExpressionValidator RegularExpressionValidatorCreateTime1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime2;
	protected RegularExpressionValidator RegularExpressionValidatorCreateTime2;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonSerch;
	protected System.Web.UI.WebControls.Button ButtonAudit;
	protected System.Web.UI.WebControls.Button ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate1;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldSubstationID;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.method_5();
			this.BindCommon_Cf();
			this.SetCode();
			this.BindGrid();
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
	}
	protected string GetValidateTime(object valitime)
	{
		string result;
		try
		{
			result = valitime.ToString().Split(new char[]
			{
				'/'
			})[0];
		}
		catch
		{
			result = "";
		}
		return result;
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	protected void BindCommon_Cf()
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		DataTable list = shopNum1_SupplyDemandCheck_Action.GetList("0");
		this.DropDownListCommon_Cf.Items.Clear();
		this.DropDownListCommon_Cf.Items.Add(new ListItem("-请选择-", "-1"));
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListCommon_Cf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListCommon_Cf_SelectedIndexChanged(null, null);
		this.SetCode();
	}
	protected void DropDownListCommon_Cf_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListCommon_Cs.Items.Clear();
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		this.DropDownListCommon_Cs.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListCommon_Cf.SelectedValue != "-1")
		{
			DataTable list = shopNum1_SupplyDemandCheck_Action.GetList(this.DropDownListCommon_Cf.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListCommon_Cs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListCommon_Cs_SelectedIndexChanged(null, null);
		this.SetCode();
	}
	protected void DropDownListCommon_Cs_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		this.DropDownListCommon_Ct.Items.Clear();
		this.DropDownListCommon_Ct.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListCommon_Cs.SelectedValue != "-1")
		{
			DataTable list = shopNum1_SupplyDemandCheck_Action.GetList(this.DropDownListCommon_Cs.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListCommon_Ct.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.SetCode();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.SetCode();
		this.BindGrid();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Update(this.CheckGuid.Value, "1") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Update(this.CheckGuid.Value, "0") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Delete(this.CheckGuid.Value.ToString()) > 0)
		{
			this.BindGrid();
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
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		int num = shopNum1_SupplyDemandCheck_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else
		{
			result = "审核未通过";
		}
		return result;
	}
	public string ShowTradeType(object object_0)
	{
		string text = object_0.ToString();
		string result;
		if (text != null)
		{
			if (text == "0")
			{
				result = "供应";
				return result;
			}
			if (text == "1")
			{
				result = "求购";
				return result;
			}
		}
		result = "供应";
		return result;
	}
	public string IsValidTime(object object_0)
	{
		string text = object_0.ToString();
		string result;
		if (text.IndexOf("/") != -1)
		{
			result = text.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			result = text;
		}
		return result;
	}
	protected void ButtonSerch_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("SupplyDemandDetails.aspx?guid=" + this.CheckGuid.Value.Replace("'", "") + "&&type=list");
	}
	public void SetCode()
	{
		if (this.DropDownListCommon_Ct.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCommon_Ct.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListCommon_Cs.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCommon_Cs.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListCommon_Cf.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCommon_Cf.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
}
