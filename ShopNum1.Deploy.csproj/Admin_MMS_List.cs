using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_MMS_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox textBoxTitle;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridiewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridiewShow.DataBind();
	}
	private void method_5()
	{
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("MMS_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MMS_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		string[] array = this.CheckGuid.Value.ToString().Split(new char[]
		{
			','
		});
		ArrayList arrayList = new ArrayList();
		arrayList.Add(array);
		for (int i = 0; i < arrayList.Count; i++)
		{
			if (array[i].ToUpper() == "'EFAE7062-E62E-4BF3-A513-126F55EDB960'" || array[i].ToUpper() == "'B18D049B-BDC5-4B08-AE29-6D686F6B4A03'" || array[i].ToUpper() == "'B195A8AB-8B12-4DF2-B719-C9CC8E6E5226'" || array[i].ToUpper() == "'7C367402-4219-46B7-BC48-72CF48F6A836'" || array[i].ToUpper() == "'D6F534A3-0538-4933-B114-CB4C85B26265'" || array[i].ToUpper() == "'D483077E-E7A3-4F4F-BD66-9010DC04E4E3'" || array[i].ToUpper() == "'4A12724C-5154-4928-B867-D5BD180E80E6'" || array[i].ToUpper() == "'9D7B9B03-DFE5-4BD5-9EEE-E0A1A86E347B'")
			{
				MessageBox.Show("删除内容中含有系统文件，无法删除！");
				return;
			}
		}
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		int num = shopNum1_MMS_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "MMS_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			return;
		}
		this.MessageShow.ShowMessage("DelNo");
		this.MessageShow.Visible = true;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
		int num = shopNum1_MMS_Action.Delete("'" + commandArgument + "'");
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
