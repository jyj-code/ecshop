using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Image_List : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	private string string_5 = "Image_List.aspx";
	private int int_0;
	private string string_6;
	private string string_7;
	private string string_8;
	protected HtmlLink sizestylesheet;
	protected Label LabelImageCategory;
	protected DropDownList DropDownListImgCategory1;
	protected Label Label1;
	protected TextBox TextBoxSName;
	protected Button ButtonSearch;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected DataList DataListShow;
	protected LinkButton LinkButton10;
	protected LinkButton LinkButton20;
	protected LinkButton LinkButton100;
	protected HtmlGenericControl pageDiv;
	protected TextBox TextBoxIndex;
	protected Button ButtonIndex;
	protected HiddenField CheckGuid;
	protected HiddenField CheckImgPath;
	protected HiddenField HiddenFieldBianji;
	protected HiddenField HiddenFieldPath;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_9;
	[CompilerGenerated]
	private int int_1;
	public string ImageSpec
	{
		get;
		set;
	}
	public int ShowCount
	{
		get;
		set;
	}
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
		this.int_0 = ((this.Page.Request.QueryString["pageid"] == null) ? 1 : int.Parse(this.Page.Request.QueryString["pageid"]));
		this.string_6 = ((this.Page.Request.QueryString["name"] == null) ? "" : this.Page.Request.QueryString["name"]);
		this.string_8 = ((this.Page.Request.QueryString["category"] == null) ? "0" : this.Page.Request.QueryString["category"]);
		this.ShowCount = ((this.Page.Request.QueryString["size"] == null) ? 10 : int.Parse(this.Page.Request.QueryString["size"]));
		if (!this.Page.IsPostBack)
		{
			this.BindImageCategory();
			this.BindImage();
			this.TextBoxSName.Text = Common.ReqStr("name");
			string text = (Common.ReqStr("size") == "") ? "10" : Common.ReqStr("size");
			string text2 = text;
			if (text2 != null)
			{
				if (text2 == "10")
				{
					this.LinkButton10.CssClass = "cur";
					goto IL_1E0;
				}
				if (text2 == "20")
				{
					this.LinkButton20.CssClass = "cur";
					goto IL_1E0;
				}
				if (text2 == "100")
				{
					this.LinkButton100.CssClass = "cur";
					goto IL_1E0;
				}
			}
			this.LinkButton10.CssClass = "cur";
			IL_1E0:
			if (Common.ReqStr("id") != "")
			{
				ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
				shopNum1_Image_Action.UpdateName(Common.ReqStr("id"), HttpUtility.HtmlDecode(Common.ReqStr("name")));
			}
		}
	}
	protected void BindImage()
	{
		if (this.int_0 <= 0)
		{
			this.int_0 = 1;
		}
		PageList1 pageList = new PageList1();
		pageList.PageSize = this.ShowCount;
		pageList.PageID = this.int_0;
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		DataTable dataTable = shopNum1_Image_Action.SearchImageByType(this.string_7, this.string_6, 0, this.string_8, this.ShowCount.ToString(), this.int_0.ToString(), "1");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		}
		else
		{
			pageList.RecordCount = 0;
		}
		PageListBll pageListBll = new PageListBll("main/admin/Image_List", true, "2");
		pageListBll.ShowRecordCount = true;
		pageListBll.ShowPageCount = true;
		pageListBll.ShowPageIndex = true;
		pageListBll.ShowRecordCount = false;
		pageListBll.ShowNoRecordInfo = false;
		pageListBll.ShowNumListButton = true;
		pageListBll.PrevPageText = "<<上一页";
		pageListBll.NextPageText = "下一页>> ";
		this.pageDiv.InnerHtml = pageListBll.GetPageListVk(pageList);
		DataTable dataSource = shopNum1_Image_Action.SearchImageByType(this.string_7, this.string_6, 0, this.string_8, this.ShowCount.ToString(), this.int_0.ToString(), "0");
		this.DataListShow.DataSource = dataSource;
		this.DataListShow.DataBind();
	}
	protected void BindImageCategory()
	{
		this.DropDownListImgCategory1.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "0";
		this.DropDownListImgCategory1.Items.Add(listItem);
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		DataView defaultView = shopNum1_ImageCategory_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			if (Common.ReqStr("category") == dataRow["ID"].ToString())
			{
				listItem2.Selected = true;
			}
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListImgCategory1.Items.Add(listItem2);
		}
	}
	private void method_5(DataTable dt)
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		foreach (DataRow dataRow in dt.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListImgCategory1.Items.Add(listItem);
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_5(dataTable);
			}
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.TextBoxSName.Text.Trim(),
			"&category=",
			this.DropDownListImgCategory1.SelectedValue,
			"&size=",
			this.ShowCount.ToString(),
			"&pageid=",
			1
		}));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		string guids = this.CheckGuid.Value.Replace(",'on'", "");
		string value = this.CheckImgPath.Value;
		try
		{
			string text = string.Empty;
			string str = string.Empty;
			string str2 = string.Empty;
			string path = string.Empty;
			if (value.IndexOf(",") != -1)
			{
				string[] array = value.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					text = base.Server.MapPath(array[i]);
					str = text.Substring(0, text.LastIndexOf("/") + 1);
					str2 = text.Substring(text.LastIndexOf("/") + 1, text.Length - text.LastIndexOf("/") - 1);
					if (File.Exists(text))
					{
						File.Delete(text);
						this.MessageShow.ShowMessage("DelYes");
						this.MessageShow.Visible = true;
					}
					else
					{
						this.MessageShow.ShowMessage("DelNo");
						this.MessageShow.Visible = false;
					}
				}
			}
			else
			{
				text = value;
				str = text.Substring(0, text.LastIndexOf("/") + 1);
				str2 = text.Substring(text.LastIndexOf("/") + 1, text.Length - text.LastIndexOf("/") - 1);
				path = str + "s_" + str2;
				text = base.Server.MapPath(text);
				path = base.Server.MapPath(path);
				if (File.Exists(text))
				{
					File.Delete(text);
					this.MessageShow.ShowMessage("DelYes");
					this.MessageShow.Visible = true;
				}
				else
				{
					this.MessageShow.ShowMessage("DelNo");
					this.MessageShow.Visible = false;
				}
			}
		}
		catch (Exception)
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
		shopNum1_Image_Action.Delete(guids);
		this.BindImage();
	}
	protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
	{
		if (e.CommandName == "select")
		{
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>loadwindow2(800,600);</script>", false);
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
			ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
			DataTable dataTable = shopNum1_Image_Action.Search("'" + hiddenField.Value.Replace(",'on'", "") + "'");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.HiddenFieldBianji.Value = hiddenField.Value;
			}
		}
		else if (e.CommandName == "delete")
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
			ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
			string text = this.HiddenFieldPath.Value;
			string str = text.Substring(0, text.LastIndexOf("/") + 1);
			string str2 = text.Substring(text.LastIndexOf("/") + 1, text.Length - text.LastIndexOf("/") - 1);
			string path = str + "s_" + str2;
			try
			{
				text = base.Server.MapPath(text);
				path = base.Server.MapPath(path);
				if (File.Exists(text))
				{
					File.Delete(text);
					File.Delete(path);
				}
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
			}
			catch (Exception)
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
			shopNum1_Image_Action.Delete("'" + hiddenField.Value.Replace(",'on'", "") + "'");
			this.BindImage();
		}
	}
	protected void LinkButton10_Click(object sender, EventArgs e)
	{
		this.LinkButton10.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.string_6,
			"&category=",
			this.string_8,
			"&size=",
			10,
			"&pageid=",
			this.int_0
		}));
	}
	protected void LinkButton20_Click(object sender, EventArgs e)
	{
		this.LinkButton20.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.string_6,
			"&category=",
			this.string_8,
			"&size=",
			20,
			"&pageid=",
			this.int_0
		}));
	}
	protected void LinkButton100_Click(object sender, EventArgs e)
	{
		this.LinkButton100.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.string_6,
			"&category=",
			this.string_8,
			"&size=",
			100,
			"&pageid=",
			this.int_0
		}));
	}
	protected void DropDownListImgCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("Image_List.aspx?category={0}&PageID=1", this.DropDownListImgCategory1.SelectedValue));
	}
	protected void ButtonIndex_Click(object sender, EventArgs e)
	{
		try
		{
			int.TryParse(this.TextBoxIndex.Text.Trim(), out this.int_0);
		}
		catch
		{
			this.int_0 = 1;
		}
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.string_6,
			"&category=",
			this.string_8,
			"&size=",
			this.ShowCount,
			"&pageid=",
			this.int_0.ToString()
		}));
	}
}
