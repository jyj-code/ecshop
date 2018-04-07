using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Group_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenGuid;
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
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void PowerSet_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string str = linkButton.CommandArgument ?? "";
		base.Response.Redirect("Competence.aspx?ID=" + str);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string[] array = this.CheckGuid.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			DataTable tableById = Common.GetTableById("*", "ShopNum1_GroupUser", " and GroupGuid='" + array[i].ToString().Replace("'", "") + "'");
			if (tableById != null && tableById.Rows.Count > 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			MessageBox.Show("删除的角色组中有用户数据，请先删除角色组对应的用户！");
		}
		else
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			int num = shopNum1_Group_Action.Delete(this.CheckGuid.Value.ToString());
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "删除管理员组",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Group_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
				this.BindGrid();
			}
			else
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected DataTable GetGroup()
	{
		string value = this.CheckGuid.Value;
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetGroupByGuid(value, 0);
	}
	protected DataTable GetGroup(string strGuid)
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetGroupByGuid(strGuid, 0);
	}
	protected DataTable GetPage()
	{
		string value = this.CheckGuid.Value;
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetPageByGroupGuid(value, 0);
	}
	protected DataTable GetPage(string strGuid)
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetPageByGroupGuid(strGuid, 0);
	}
	protected DataTable GetUser()
	{
		string value = this.CheckGuid.Value;
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetUserByGroupGuid(value, 0);
	}
	protected DataTable GetUser(string strGuid)
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		return shopNum1_Group_Action.GetUserByGroupGuid(strGuid, 0);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		bool flag = false;
		DataTable tableById = Common.GetTableById("*", "ShopNum1_GroupUser", " and GroupGuid='" + linkButton.CommandArgument + "'");
		if (tableById != null && tableById.Rows.Count > 0)
		{
			flag = true;
		}
		if (flag)
		{
			MessageBox.Show("删除的角色组中有用户数据，请先删除角色组对应的用户！");
		}
		else
		{
			ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
			int num = shopNum1_Group_Action.Delete(guids);
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
}
