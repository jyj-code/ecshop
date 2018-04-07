using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Brand_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Label Label4;
	protected System.Web.UI.WebControls.TextBox TxtCategoryName;
	protected Label Label2;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShow;
	protected Label Label1;
	protected System.Web.UI.WebControls.TextBox TxtBrandLink;
	protected Label Label3;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsRecommond;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
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
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridviewShow.DataBind();
	}
	public string GetListImageStatus(string string_5)
	{
		string result;
		if (string_5 == "-1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Brand_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Brand_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		int num = shopNum1_Brand_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除品牌",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "Brand_List.aspx",
				Date = DateTime.Now
			});
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		int num = shopNum1_Brand_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除品牌",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "Brand_List.aspx",
				Date = DateTime.Now
			});
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string ChangeIsShow(string strIsShow)
	{
		string result;
		if (strIsShow == "0")
		{
			result = "前台不显示";
		}
		else if (strIsShow == "1")
		{
			result = "前台显示";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected string isRecommand(string isrecommand)
	{
		string result;
		if (isrecommand == "1")
		{
			result = "推荐";
		}
		else
		{
			result = "不推荐";
		}
		return result;
	}
	protected string IsCommon(string isCommon)
	{
		string result;
		if (isCommon == "-1")
		{
			result = "是";
		}
		else
		{
			result = "否";
		}
		return result;
	}
}
