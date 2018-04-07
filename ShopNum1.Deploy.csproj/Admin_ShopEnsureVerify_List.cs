using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopEnsureVerify_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSourceData;
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
			this.GetSubstationID();
			this.BandDropdownIsAudit();
			this.BindGrid();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.DelShopEnsureList(this.CheckGuid.Value);
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		int num = shop_Ensure_Action.DelShopEnsureList(guid);
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
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 1);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 0);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	public void BandDropdownIsAudit()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("-已审核-", "1"));
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected string IsAudit(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
}
