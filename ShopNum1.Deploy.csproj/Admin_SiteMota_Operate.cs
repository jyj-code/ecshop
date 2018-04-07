using ShopNum1.Common;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_SiteMota_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label Label1;
	protected TextBox TextBoxPageName;
	protected RequiredFieldValidator Re1;
	protected Label Label2;
	protected TextBox TextBoxFileName;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected Label Label3;
	protected TextBox TextBoxDivID;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected Label Label4;
	protected TextBox TextBoxExplain;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	public XmlDocument xmlDoc;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["pagename"] == null) ? "0" : base.Request.QueryString["pagename"].Replace("'", ""));
		if (!base.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.hiddenFieldGuid.Value = this.hiddenFieldGuid.Value.Replace('/', '.');
			this.TextBoxPageName.Enabled = false;
			this.ButtonConfirm.Text = "更新";
			this.GetEditInfo();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SiteMota_List.aspx");
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
	public void GetEditInfo()
	{
		DataRow dataRow = this.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
		this.TextBoxPageName.Text = dataRow["PageName"].ToString();
		this.TextBoxFileName.Text = dataRow["Title"].ToString();
		this.TextBoxDivID.Text = dataRow["KeyWords"].ToString();
		this.TextBoxExplain.Text = dataRow["Description"].ToString();
	}
	public DataTable SelectByID(string PageName)
	{
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(this.GetPath());
		DataRow[] array = dataSet.Tables[0].Select("PageName = '" + PageName + "'");
		DataTable result;
		if (array.Length > 0)
		{
			result = array.CopyToDataTable<DataRow>();
		}
		else
		{
			result = null;
		}
		return result;
	}
	public void Add()
	{
		if (this.check(this.TextBoxPageName.Text))
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("SiteMeta");
			XmlElement xmlElement = this.xmlDoc.CreateElement("Meta");
			xmlElement.SetAttribute("PageName", this.TextBoxPageName.Text);
			xmlElement.SetAttribute("Title", this.TextBoxFileName.Text);
			xmlElement.SetAttribute("KeyWords", this.TextBoxDivID.Text);
			xmlElement.SetAttribute("Description", this.TextBoxExplain.Text);
			xmlNode.AppendChild(xmlElement);
			try
			{
				this.xmlDoc.Save(this.GetPath());
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				return;
			}
			catch (Exception)
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
				return;
			}
		}
		MessageBox.Show("该页面已存在");
	}
	public bool check(string PageName)
	{
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(this.GetPath());
		DataRow[] array = dataSet.Tables[0].Select("PageName = '" + PageName + "'");
		return array.Length <= 0;
	}
	public void edit()
	{
		this.LoadXml();
		XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
		foreach (XmlNode xmlNode in childNodes)
		{
			XmlElement xmlElement = (XmlElement)xmlNode;
			if (xmlElement.GetAttribute("PageName") == this.TextBoxPageName.Text.ToString())
			{
				xmlElement.SetAttribute("PageName", this.TextBoxPageName.Text);
				xmlElement.SetAttribute("Title", this.TextBoxFileName.Text);
				xmlElement.SetAttribute("KeyWords", this.TextBoxDivID.Text);
				xmlElement.SetAttribute("Description", this.TextBoxExplain.Text);
				break;
			}
		}
		try
		{
			this.xmlDoc.Save(this.GetPath());
			this.MessageShow.ShowMessage("EditYes");
		}
		catch (Exception)
		{
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.edit();
			base.Response.Redirect("SiteMota_List.aspx");
		}
		else
		{
			this.Add();
		}
	}
}
