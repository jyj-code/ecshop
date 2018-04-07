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
public class Main_Admin_ShopInfoList_AuditNo : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle1;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSource;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldIsAudit;
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
			this.GetDropDownListSubstationID();
			this.method_5();
		}
	}
	public void GetDropDownListSubstationID()
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	public string GetSubstationIDNameBySubstationID(string SubstationID)
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.DeleteMore(this.CheckGuid.Value) > 0)
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable shopInfoByGuid = shopNum1_ShopInfoList_Action.GetShopInfoByGuid(guid);
		string value = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
		string text = shopInfoByGuid.Rows[0]["ShopID"].ToString();
		string path = string.Concat(new string[]
		{
			"~/Shop/Shop/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		string path2 = string.Concat(new string[]
		{
			"~/ImgUpload/",
			Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/'),
			"/",
			ShopSettings.GetValue("PersonShopUrl"),
			text
		});
		this.method_6(base.Server.MapPath(path2));
		this.method_6(base.Server.MapPath(path));
		if (shopNum1_ShopInfoList_Action.Delete(guid) > 0)
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
	private void method_6(string string_5)
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
					this.method_6(text);
				}
			}
			Directory.Delete(string_5, true);
		}
	}
	public string YesOrNo(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "是";
		}
		else
		{
			result = "否";
		}
		return result;
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
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopInfo_AuditOperate.aspx?guid=" + this.CheckGuid.Value);
	}
}
