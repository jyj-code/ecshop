using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
public class Main_Admin_MemberRank_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridviewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridviewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("MemberRank_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MemberRank_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		string[] array = this.CheckGuid.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			if (!this.IsUserLv(array[i].ToString()))
			{
				MessageBox.Show("请首先删除选择等级会员信息！");
				return;
			}
		}
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		int num = shopNum1_MemberRank_Action.Delete(this.CheckGuid.Value);
		if (num == -1)
		{
			MessageBox.Show("默认等级不能删除！");
			return;
		}
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			return;
		}
		this.MessageShow.ShowMessage("DelNo");
		this.MessageShow.Visible = true;
	}
	public bool IsUserLv(string MemberRankGuid)
	{
		DataTable dataTable = null;
		try
		{
			dataTable = Common.GetTableById("Guid", "ShopNum1_Member", "    and   MemberRankGuid='" + MemberRankGuid.Replace("'", "") + "'   ");
		}
		catch (Exception)
		{
		}
		return dataTable == null || dataTable.Rows.Count <= 0;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		if (!this.IsUserLv(linkButton.CommandArgument))
		{
			MessageBox.Show("请首先删除该等级会员信息！");
		}
		else
		{
			ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
			int num = shopNum1_MemberRank_Action.Delete(guids);
			if (num == -1)
			{
				MessageBox.Show("默认等级不能删除！");
			}
			else if (num > 0)
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
