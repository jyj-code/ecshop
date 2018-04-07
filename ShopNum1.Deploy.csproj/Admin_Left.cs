using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Left : Page, IRequiresSessionState
{
	protected Repeater RepeaterMenu;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private ShopNum1_Page_Action shopNum1_Page_Action_0 = (ShopNum1_Page_Action)LogicFactory.CreateShopNum1_Page_Action();
	private bool bool_0 = false;
	private DataTable dt = null;
	private DataTable dataTable_1 = null;
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
			if (base.Request.Cookies["AdminLoginCookie"] != null)
			{
				HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.hiddenFieldGuid.Value = httpCookie.Values["Guid"].ToString();
			}
			else
			{
				base.Response.Redirect("~/Admin/Html/Nopower.html");
			}
		}
		this.BindMenu();
	}
	protected void BindMenu()
	{
		if (this.hiddenFieldGuid.Value == "9F1B9C51-F8F3-42C8-8465-501C5F3D1D1B".ToLower())
		{
			this.dataTable_1 = this.shopNum1_Page_Action_0.GetOnePageBySuper(0);
			this.bool_0 = true;
			this.dt = this.shopNum1_Page_Action_0.GetTwopageBySupper(-1, 0);
		}
		else
		{
			this.dataTable_1 = this.shopNum1_Page_Action_0.GetOnePage(this.hiddenFieldGuid.Value, 0);
		}
		this.RepeaterMenu.DataSource = this.dataTable_1;
		this.RepeaterMenu.DataBind();
		if (this.dataTable_1 != null && this.dataTable_1.Rows.Count > 0)
		{
			Repeater repeater = (Repeater)this.RepeaterMenu.Items[this.dataTable_1.Rows.Count - 1].FindControl("RepeaterChild");
			for (int i = 0; i < repeater.Items.Count; i++)
			{
				Localize localize = (Localize)repeater.Items[i].FindControl("LocalizeImgLeft");
				localize.Text = "<img src='images/s.jpg'/>";
			}
		}
	}
	protected void RepeaterMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		DataTable dataTable = new DataTable();
		HiddenField hiddenField = e.Item.FindControl("HiddenFieldOneID") as HiddenField;
		if (this.bool_0)
		{
			if (this.dt != null && this.dt.Rows.Count > 0)
			{
				string text = "OneID='{0}'";
				string sort = "OrderID DESC";
				text = string.Format(text, hiddenField.Value.ToString());
				DataRow[] array = this.dt.Select(text, sort);
				if (array != null && array.Length > 0)
				{
					dataTable = array.CopyToDataTable<DataRow>();
				}
			}
		}
		else
		{
			dataTable = this.shopNum1_Page_Action_0.GetTwopage(this.hiddenFieldGuid.Value, Convert.ToInt32(hiddenField.Value), 0);
		}
		Repeater repeater = e.Item.FindControl("RepeaterChild") as Repeater;
		repeater.DataSource = dataTable;
		repeater.DataBind();
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			Localize localize = (Localize)repeater.Items[dataTable.Rows.Count - 1].FindControl("Localizeimg");
			localize.Text = "<img src='images/icon_line_Last.gif' id='img_Line' runat ='server' style='border-width:0;'/>";
		}
	}
}
