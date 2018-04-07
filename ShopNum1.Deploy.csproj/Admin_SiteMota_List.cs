using ShopNum1.Common;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_SiteMota_List : PageBase, IRequiresSessionState
{
	public XmlDocument xmlDoc;
	protected Label LabelPageName;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.Button butSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected Num1GridView Num1GridViewShow;
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
		if (!base.IsPostBack)
		{
			this.Bind();
		}
	}
	public string GetPath()
	{
		string path = "~/Settings/SetMeto.xml";
		return HttpContext.Current.Server.MapPath(path);
	}
	public void LoadXml()
	{
		this.xmlDoc = new XmlDocument();
		this.xmlDoc.Load(this.GetPath());
	}
	public void Bind()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void butSearch_Click(object sender, EventArgs e)
	{
		this.Bind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("SiteMota_Operate.aspx?PageName=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SiteMota_Operate.aspx?PageName=" + this.CheckGuid.Value.Replace('.', '/'));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		int num = this.delete(this.CheckGuid.Value);
		if (num == 1)
		{
			this.Bind();
			MessageBox.Show("删除成功");
		}
		else
		{
			MessageBox.Show("删除失败");
		}
	}
	public int delete(string PageName)
	{
		if (PageName.IndexOf(",") == -1)
		{
			PageName += ",";
		}
		string[] array = PageName.Replace("'", "").Split(new char[]
		{
			','
		});
		this.LoadXml();
		XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("PageName") == array[i])
				{
					this.xmlDoc.SelectSingleNode("SiteMeta").RemoveChild(xmlNode);
					break;
				}
			}
		}
		int result;
		try
		{
			this.xmlDoc.Save(this.GetPath());
			result = 1;
		}
		catch (Exception)
		{
			result = 0;
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = this.delete(commandArgument);
		if (num == 1)
		{
			this.Bind();
			MessageBox.Show("删除成功");
		}
		else
		{
			MessageBox.Show("删除失败");
		}
	}
}
