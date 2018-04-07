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
public class AgentAdmin_AttachMent_List_Select : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Localize LocalizeAttachMentCateGory;
	protected System.Web.UI.WebControls.DropDownList DropDownListAttachMentCateGory;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView num1GridViewShow;
	protected HiddenField HiddenFieldOrganizeID;
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
			this.BindAttachMentCateGory();
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		ShopNum1_AttachMent_Action shopNum1_AttachMent_Action = (ShopNum1_AttachMent_Action)LogicFactory.CreateShopNum1_AttachMent_Action();
		DataTable dataSource = shopNum1_AttachMent_Action.Search(this.DropDownListAttachMentCateGory.SelectedValue);
		this.num1GridViewShow.DataSource = dataSource;
		this.num1GridViewShow.DataBind();
	}
	protected void BindAttachMentCateGory()
	{
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		DataTable dataTable = shopNum1_AttachMentCategory_Action.Search();
		this.DropDownListAttachMentCateGory.Items.Add(new ListItem("-全部-", "-1"));
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListAttachMentCateGory.Items.Add(new ListItem(dataTable.Rows[i]["CategoryName"].ToString(), dataTable.Rows[i]["Guid"].ToString()));
		}
	}
}
