using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_DefaultAd_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
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
		this.BindGrid();
	}
	public void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string AdType(object object_0)
	{
		string result = "";
		string text = object_0.ToString();
		if (text != null)
		{
			if (!(text == "0"))
			{
				if (!(text == "1"))
				{
					if (!(text == "2"))
					{
						if (text == "3")
						{
							result = "flash";
						}
					}
					else
					{
						result = "幻灯片";
					}
				}
				else
				{
					result = "图片";
				}
			}
			else
			{
				result = "文字";
			}
		}
		return result;
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("DefaultAd_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("DefaultAd_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
		if (shopNum1_DefaultAdImg_Action.Delete(this.CheckGuid.Value))
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		if (shopNum1_DefaultAdImg_Action.Delete(commandArgument))
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
