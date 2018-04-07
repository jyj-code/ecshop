using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_PageInfo_Operate : PageBase, IRequiresSessionState, ICallbackEventHandler
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxPageName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxPageName;
	protected DropDownList DropDownListFileName;
	protected Label Label2;
	protected CompareValidator CompareFatherCateGory;
	protected TextBox TextBoxPageNote;
	protected TextBox TextBoxContent;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldADCount;
	protected HiddenField HiddenFieldADGuid;
	protected HtmlForm form1;
	private string string_5;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", ""));
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.GetFileName();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
			}
		}
	}
	public void Add()
	{
		PageInfo pageInfo = new PageInfo();
		pageInfo.Guid = Guid.NewGuid().ToString();
		pageInfo.PageName = this.TextBoxPageName.Text;
		pageInfo.FileName = this.DropDownListFileName.SelectedItem.Text;
		pageInfo.PageNote = this.TextBoxPageNote.Text;
		ShopNum1_PageInfo_Action shopNum1_PageInfo_Action = (ShopNum1_PageInfo_Action)LogicFactory.CreateShopNum1_PageInfo_Action();
		int num = shopNum1_PageInfo_Action.Add(pageInfo);
		if (num > 0)
		{
			string path = base.Server.MapPath("~/Themes/Skin_Default/" + this.DropDownListFileName.SelectedValue);
			if (File.Exists(path))
			{
				Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
				StreamWriter streamWriter = new StreamWriter(stream, Encoding.Default);
				streamWriter.Write(this.TextBoxContent.Text);
				streamWriter.Close();
				stream.Close();
			}
			if (this.HiddenFieldADCount.Value != "0")
			{
				this.AddAD(this.HiddenFieldADCount.Value);
				base.Response.Redirect("Advertisement_Operate.aspx?guid='" + this.HiddenFieldADGuid.Value + "'");
			}
			else
			{
				base.Response.Redirect("PageInfo_List.aspx");
			}
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		PageInfo pageInfo = new PageInfo();
		pageInfo.Guid = this.hiddenFieldGuid.Value;
		pageInfo.PageName = this.TextBoxPageName.Text;
		pageInfo.FileName = this.DropDownListFileName.SelectedValue;
		pageInfo.PageNote = this.TextBoxPageNote.Text;
		ShopNum1_PageInfo_Action shopNum1_PageInfo_Action = (ShopNum1_PageInfo_Action)LogicFactory.CreateShopNum1_PageInfo_Action();
		int num = shopNum1_PageInfo_Action.Update(pageInfo);
		if (num > 0)
		{
			string path = base.Server.MapPath("~/Themes/Skin_Default/" + this.DropDownListFileName.SelectedValue);
			if (File.Exists(path))
			{
				Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
				StreamWriter streamWriter = new StreamWriter(stream, Encoding.Default);
				streamWriter.Write(this.TextBoxContent.Text);
				streamWriter.Close();
				stream.Close();
			}
			if (this.HiddenFieldADCount.Value != "0")
			{
				this.AddAD(this.HiddenFieldADCount.Value);
				base.Response.Redirect("Advertisement_Operate.aspx?guid='" + this.HiddenFieldADGuid.Value + "'");
			}
			else
			{
				base.Response.Redirect("PageInfo_List.aspx");
			}
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_PageInfo_Action shopNum1_PageInfo_Action = (ShopNum1_PageInfo_Action)LogicFactory.CreateShopNum1_PageInfo_Action();
		DataRow dataRow = shopNum1_PageInfo_Action.SelectByID(this.hiddenFieldGuid.Value).Rows[0];
		this.TextBoxPageName.Text = dataRow["pagename"].ToString();
		this.TextBoxPageNote.Text = dataRow["pagenote"].ToString();
		this.DropDownListFileName.SelectedValue = dataRow["filename"].ToString();
		string path = base.Server.MapPath("~/Themes/Skin_Default/" + this.DropDownListFileName.SelectedValue);
		if (File.Exists(path))
		{
			FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
			this.TextBoxContent.Text = streamReader.ReadToEnd();
			streamReader.Close();
			fileStream.Close();
		}
		this.LabelPageTitle.Text = "编辑广告位列表";
	}
	public void GetFileName()
	{
		string[] files = Directory.GetFiles(base.Server.MapPath("~/Themes/Skin_Default/"), "*.aspx");
		this.DropDownListFileName.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("Select");
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
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PageInfo_List.aspx");
	}
	public void AddAD(string divID)
	{
		Advertisement advertisement = new Advertisement();
		advertisement.Guid = Guid.NewGuid().ToString();
		this.HiddenFieldADGuid.Value = advertisement.Guid;
		advertisement.PageName = this.TextBoxPageName.Text;
		advertisement.FileName = this.DropDownListFileName.SelectedValue;
		advertisement.DivID = divID;
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		shopNum1_Advertisement_Action.Add(advertisement);
	}
	public string GetstrAd()
	{
		string text = string.Empty;
		text = "AD" + DateTime.Now.ToString("yyyyMMddHHmmss");
		return "<div  id='" + text + "' runat='server'></div>|" + text;
	}
	public string GetCallbackResult()
	{
		return this.GetstrAd();
	}
	public void RaiseCallbackEvent(string eventArgument)
	{
		this.string_5 = eventArgument;
	}
	protected void DropDownListFileName_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListFileName.SelectedValue != "-1")
		{
			string path = base.Server.MapPath("~/Themes/Skin_Default/" + this.DropDownListFileName.SelectedValue);
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
				this.TextBoxContent.Text = streamReader.ReadToEnd();
				streamReader.Close();
				fileStream.Close();
			}
		}
		else
		{
			this.TextBoxContent.Text = "";
		}
	}
	protected void ButtonReset_Click(object sender, EventArgs e)
	{
		this.GetEditInfo();
	}
}
