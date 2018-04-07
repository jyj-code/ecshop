using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopNum1SupplyDemandCheck_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize LocalizeFavourTickitName;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Cf;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Cs;
	protected System.Web.UI.WebControls.DropDownList DropDownListCommon_Ct;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberID;
	protected System.Web.UI.WebControls.DropDownList DropDownListTradeType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonSerch;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
			this.DropDownListCommon_Cf_SelectedIndexChanged(null, null);
			this.SetCode();
			this.BindGrid();
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	public string Audit(string isAudit)
	{
		string result;
		if (isAudit == "0")
		{
			result = "未审核";
		}
		else if (isAudit == "1")
		{
			result = "审核中";
		}
		else if (isAudit == "2")
		{
			result = "审核未通过";
		}
		else if (isAudit == "3")
		{
			result = "审核通过";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
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
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.SetCode();
		this.BindGrid();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		if (shopNum1_SupplyDemandCheck_Action.Update(this.CheckGuid.Value, "3") > 0)
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
		if (shopNum1_SupplyDemandCheck_Action.Update(this.CheckGuid.Value, "2") > 0)
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
		result = "";
		return result;
	}
	protected void ButtonSerch_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("SupplyDemandDetails.aspx?guid=" + this.CheckGuid.Value.Replace("'", "") + "&&type=audit");
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
		int num = shopNum1_SupplyDemandCheck_Action.Delete(guids);
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
}
