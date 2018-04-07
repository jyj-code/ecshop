using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopTemplate_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected LinkButton ButtonAdd;
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
		base.Response.Redirect("ShopTemplate_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopTemplate_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
		DataTable templatePathAndImg = shopNum1_ShopTemplate_Action.GetTemplatePathAndImg1(this.CheckGuid.Value);
		int num = shopNum1_ShopTemplate_Action.Delete1(this.CheckGuid.Value);
		if (num > 0)
		{
			this.BindGrid();
			if (templatePathAndImg.Rows.Count > 0)
			{
				string str = templatePathAndImg.Rows[0]["Path"].ToString();
				string str2 = templatePathAndImg.Rows[0]["TemplateImg"].ToString();
				if (File.Exists(this.Page.Server.MapPath("~/Template/Shop/" + str)))
				{
					File.Delete(this.Page.Server.MapPath("~/Template/Shop/" + str));
				}
				if (File.Exists(this.Page.Server.MapPath("~/Template/Shop/" + str2)))
				{
					File.Delete(this.Page.Server.MapPath("~/Template/Shop/" + str2));
				}
			}
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
		ShopNum1_ShopTemplate_Action shopNum1_ShopTemplate_Action = (ShopNum1_ShopTemplate_Action)LogicFactory.CreateShopNum1_ShopTemplate_Action();
		LinkButton linkButton = (LinkButton)sender;
		string string_ = "'" + linkButton.CommandArgument + "'";
		DataTable templatePathAndImg = shopNum1_ShopTemplate_Action.GetTemplatePathAndImg1(string_);
		int num = shopNum1_ShopTemplate_Action.Delete1(string_);
		if (num > 0)
		{
			this.BindGrid();
			if (templatePathAndImg.Rows.Count > 0)
			{
				string str = templatePathAndImg.Rows[0]["Path"].ToString();
				string str2 = templatePathAndImg.Rows[0]["TemplateImg"].ToString();
				if (File.Exists(this.Page.Server.MapPath("~/Template/Shop/" + str)))
				{
					File.Delete(this.Page.Server.MapPath("~/Template/Shop/" + str));
				}
				if (File.Exists(this.Page.Server.MapPath("~/Template/Shop/" + str2)))
				{
					File.Delete(this.Page.Server.MapPath("~/Template/Shop/" + str2));
				}
			}
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected string IsDefault(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "默认";
		}
		else if (object_0.ToString() == "1")
		{
			result = "非默认";
		}
		else
		{
			result = "非法类型";
		}
		return result;
	}
	protected string IsForbid(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未禁用";
		}
		else if (object_0.ToString() == "1")
		{
			result = "禁用";
		}
		else
		{
			result = "非法类型";
		}
		return result;
	}
}
