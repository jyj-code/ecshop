using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_CouponList_Audit : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode3;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime1;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime2;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime1;
	protected CalendarExtender CalendarExtender2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime2;
	protected CalendarExtender CalendarExtender3;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected LinkButton ButtonSearchShop;
	protected LinkButton ButtonOperate;
	protected LinkButton ButtonOperate1;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSource;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField HiddenFieldRegionCode;
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
			this.BindProductIsAudit();
			this.DropDownListRegionCode1Bind();
			this.BindDropDownListType();
			this.method_5();
		}
	}
	protected void BindDropDownListType()
	{
		this.DropDownListType.Items.Clear();
		this.DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
		Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action();
		DataTable dataTable = shop_CouponType_Action.search(-1, 1);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataTable.Rows[i]["Name"].ToString();
				listItem.Value = dataTable.Rows[i]["ID"].ToString();
				this.DropDownListType.Items.Add(listItem);
			}
		}
	}
	protected void BindProductIsAudit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
		int num = shop_Coupon_Action.UpdateAudit("IsAudit", "1", this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
		Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
		int num = shop_Coupon_Action.UpdateAudit("IsAudit", "2", this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5()
	{
		try
		{
			this.SetShopRegionCode();
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception)
		{
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
		int num = shop_Coupon_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_5();
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
		string iD = "'" + linkButton.CommandArgument + "'";
		Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
		int num = shop_Coupon_Action.Delete(iD);
		if (num > 0)
		{
			this.method_5();
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
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegionCode1.Items.Clear();
		this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
		ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
		DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(0, 0);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListRegionCode1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
		}
		this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode2.Items.Clear();
		this.DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
		if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1].ToString()), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode3.Items.Clear();
		this.DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
		if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1].ToString()), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode3.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void SetShopRegionCode()
	{
		if (this.DropDownListRegionCode3.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldRegionCode.Value = "-1";
		}
	}
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CouponList_Search.aspx?guid=" + this.CheckGuid.Value + "&Type=Audit");
	}
}
