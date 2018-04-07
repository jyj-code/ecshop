using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Advertisement_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListFileName;
	protected System.Web.UI.WebControls.TextBox TextBoxdivid;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
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
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.GetFileName();
			this.BindGrid();
		}
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
		base.Response.Redirect("Advertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Advertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		int num = shopNum1_Advertisement_Action.Delete(this.CheckGuid.Value);
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
	public void GetFileName()
	{
		string[] files = Directory.GetFiles(base.Server.MapPath("~/Main/Themes/Skin_Default/"), "*.aspx");
		this.DropDownListFileName.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("All");
		listItem.Value = "-1";
		this.DropDownListFileName.Items.Add(listItem);
		for (int i = 0; i < files.Length; i++)
		{
			this.DropDownListFileName.Items.Add(new ListItem
			{
				Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
				Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
			});
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		string arg_0B_0 = this.TextBoxdivid.Text;
		this.BindGrid();
	}
}
