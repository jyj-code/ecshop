using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopNum1_ShopProductProp_List : PageBase, IRequiresSessionState
{
	public enum ShowTypeImg : uint
	{
		列表单选 = 1u,
		下拉框单选,
		多选,
		手动输入
	}
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSource1;
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
			this.BindData();
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("ShopNum1_ShopProductProp_Operate.aspx?guid={0}", this.CheckGuid.Value.Replace("'", "").Trim()));
	}
	protected void BindData()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = new ShopNum1_ShopProductProp_Action();
		int num = shopNum1_ShopProductProp_Action.Delete(this.CheckGuid.Value.Replace("'", ""));
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除属性",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "ShopNum1_ShopProductProp_List.aspx",
				Date = DateTime.Now
			});
			this.BindData();
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
		string string_ = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = new ShopNum1_ShopProductProp_Action();
		int num = shopNum1_ShopProductProp_Action.Delete(string_);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除属性",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "ShopNum1_ShopProductProp_List.aspx",
				Date = DateTime.Now
			});
			this.BindData();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	public string setProp(string strType)
	{
		string result;
		if (strType != null)
		{
			if (strType == "0")
			{
				result = "文字输入";
				return result;
			}
			if (strType == "1")
			{
				result = "列表单选";
				return result;
			}
			if (strType == "2")
			{
				result = "下拉框单选";
				return result;
			}
			if (strType == "3")
			{
				result = "多选";
				return result;
			}
		}
		result = "自定义属性";
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "-1";
		base.Response.Redirect("ShopNum1_ShopProductProp_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
