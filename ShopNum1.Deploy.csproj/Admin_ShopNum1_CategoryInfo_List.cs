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
public class Admin_ShopNum1_CategoryInfo_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label Label1;
	protected Localize LocalizeFavourTickitName;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategoryCf;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategoryCs;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategoryCt;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearchDetail;
	protected System.Web.UI.WebControls.Button ButtonAudit;
	protected System.Web.UI.WebControls.Button ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow1;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField HiddenFieldCode;
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
		if (!base.IsPostBack)
		{
			this.CategoryCfBind();
			this.method_5();
			this.DropDownListCategoryCf_SelectedIndexChanged(null, null);
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
	protected void CategoryCfBind()
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		DataTable list = shopNum1_CategoryChecked_Action.GetList("0");
		this.DropDownListCategoryCf.Items.Clear();
		this.DropDownListCategoryCf.Items.Add(new ListItem("-请选择-", "-1"));
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListCategoryCf.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.SetCode();
		this.BindGrid();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		if (shopNum1_CategoryChecked_Action.Update(this.CheckGuid.Value, "1") > 0)
		{
			this.BindGrid();
			this.MessageShow1.ShowMessage("Audit1Yes");
			this.MessageShow1.Visible = true;
		}
		else
		{
			this.MessageShow1.ShowMessage("Audit1No");
			this.MessageShow1.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		if (shopNum1_CategoryChecked_Action.Update(this.CheckGuid.Value, "0") > 0)
		{
			this.BindGrid();
			this.MessageShow1.ShowMessage("Audit2Yes");
			this.MessageShow1.Visible = true;
		}
		else
		{
			this.MessageShow1.ShowMessage("Audit2No");
			this.MessageShow1.Visible = true;
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		if (shopNum1_CategoryChecked_Action.Delete(this.CheckGuid.Value.ToString()) > 0)
		{
			this.BindGrid();
			this.MessageShow1.ShowMessage("DelYes");
			this.MessageShow1.Visible = true;
		}
		else
		{
			this.MessageShow1.ShowMessage("DelNo");
			this.MessageShow1.Visible = true;
		}
	}
	protected void DropDownListCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		DataTable list = shopNum1_CategoryChecked_Action.GetList(this.DropDownListCategoryCf.SelectedValue.Split(new char[]
		{
			'/'
		})[0]);
		this.DropDownListCategoryCs.Items.Clear();
		this.DropDownListCategoryCs.Items.Add(new ListItem("-请选择-", "-1"));
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListCategoryCs.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
		}
		this.DropDownListCategoryCs_SelectedIndexChanged(null, null);
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
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryDetails.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
	}
	protected void DropDownListCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		DataTable list = shopNum1_CategoryChecked_Action.GetList(this.DropDownListCategoryCs.SelectedValue.Split(new char[]
		{
			'/'
		})[0]);
		this.DropDownListCategoryCt.Items.Clear();
		this.DropDownListCategoryCt.Items.Add(new ListItem("-请选择-", "-1"));
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListCategoryCt.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["ID"].ToString() + "/" + list.Rows[i]["Code"].ToString()));
		}
	}
	public void SetCode()
	{
		if (this.DropDownListCategoryCt.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCategoryCt.SelectedValue.Split(new char[]
			{
				'/'
			})[1];
		}
		else if (this.DropDownListCategoryCs.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCategoryCs.SelectedValue.Split(new char[]
			{
				'/'
			})[1];
		}
		else if (this.DropDownListCategoryCf.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListCategoryCf.SelectedValue.Split(new char[]
			{
				'/'
			})[1];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
		int num = shopNum1_CategoryChecked_Action.Delete(commandArgument);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow1.ShowMessage("DelYes");
			this.MessageShow1.Visible = true;
		}
		else
		{
			this.MessageShow1.ShowMessage("DelNo");
			this.MessageShow1.Visible = true;
		}
	}
}
