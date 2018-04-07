using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SubstationManage_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid2;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected Label LabelSubstationID;
	protected System.Web.UI.WebControls.TextBox TextBoxSubstationID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected LinkButton LinkButtonManageUser;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridviewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
			this.BindGrid();
		}
	}
	public string GetListImageStatus1(string isshow)
	{
		string result;
		if (isshow == "1")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "images/shopNum1Admin-right.gif";
		}
		return result;
	}
	public string GetListImageStatus(string isshow)
	{
		string result;
		if (isshow == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "images/shopNum1Admin-right.gif";
		}
		return result;
	}
	protected void BindGrid()
	{
		this.Num1GridviewShow.DataBind();
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
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
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
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
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
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
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SubstationManage_Operate.aspx");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
	}
	protected void LinkButtonManageUser_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SubstationManage_UserManage.aspx?Guid=" + this.CheckGuid.Value);
	}
	private void method_5(string string_5)
	{
		try
		{
			if (Directory.Exists(string_5))
			{
				string[] fileSystemEntries = Directory.GetFileSystemEntries(string_5);
				for (int i = 0; i < fileSystemEntries.Length; i++)
				{
					string text = fileSystemEntries[i];
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					else
					{
						this.method_5(text);
					}
				}
				Directory.Delete(string_5, true);
			}
		}
		catch
		{
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		string text = string.Empty;
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(this.CheckGuid.Value.Replace("'", ""));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			text = dataTable.Rows[0]["SubstationID"].ToString();
		}
		DataTable tableById = Common.GetTableById("Guid", "ShopNum1_ShopInfo", "   AND SubstationID='" + text + "'  ");
		if (tableById != null && tableById.Rows.Count > 0)
		{
			MessageBox.Show("请先删除相关的店铺信息！");
		}
		else
		{
			int num = shopNum1_SubstationManage_Action.Delete(this.CheckGuid.Value);
			if (num > 0)
			{
				try
				{
					if (!string.IsNullOrEmpty(text))
					{
						shopNum1_SubstationManage_Action.DeleteUserBySubstationID(text);
					}
					shopNum1_SubstationManage_Action.DeleteSubstationManageNav(text);
					string path = "~/City/" + text.ToString();
					this.method_5(base.Server.MapPath(path));
				}
				catch (Exception)
				{
				}
				MessageBox.Show("操作成功！");
				this.BindGrid();
			}
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string GetCityName(string code)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable cityNameByCode = shopNum1_SubstationManage_Action.GetCityNameByCode(code);
		string result;
		if (cityNameByCode != null && cityNameByCode.Rows.Count > 0)
		{
			result = cityNameByCode.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "";
		}
		return result;
	}
}
