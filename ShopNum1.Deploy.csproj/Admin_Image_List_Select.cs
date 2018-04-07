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
public class Admin_Image_List_Select : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	private int int_0;
	private string string_5;
	private string string_6;
	private string string_7;
	private string string_8 = ShopUrlOperate.GetSiteDomain() + "/main/admin/Image_List_Select.aspx";
	protected HtmlHead Head1;
	protected Label LabelImageCategory;
	protected DropDownList DropDownListImgCategory1;
	protected Label Label1;
	protected TextBox TextBoxSName;
	protected Button ButtonSearch;
	protected DataList DataListShow;
	protected Button ButtonDel;
	protected Literal lnkTo;
	protected DropDownList DropDownListNumSelect;
	protected HtmlGenericControl pageDiv;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenImgPath;
	protected HtmlForm form1;
	[CompilerGenerated]
	private int int_1;
	[CompilerGenerated]
	private string string_9;
	public int ShowCount
	{
		get;
		set;
	}
	public string ImageSpec
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
		this.string_5 = ((this.Page.Request.QueryString["name"] == null) ? "" : this.Page.Request.QueryString["name"]);
		this.string_6 = ((this.Page.Request.QueryString["type"] == null) ? "-1" : this.Page.Request.QueryString["type"]);
		this.string_7 = ((this.Page.Request.QueryString["category"] == null) ? "0" : this.Page.Request.QueryString["category"]);
		this.ShowCount = ((this.Page.Request.QueryString["size"] == null) ? 24 : int.Parse(this.Page.Request.QueryString["size"]));
		if (!this.Page.IsPostBack)
		{
			this.BindImageCategory();
			this.BindImage("-1");
			if (base.Request.QueryString["PageID"] != null)
			{
				this.DropDownListNumSelect.SelectedValue = base.Request.QueryString["PageID"];
			}
		}
	}
	protected void BindImage(string strImageType)
	{
		if (this.int_0 <= 0)
		{
			this.int_0 = 1;
		}
		PageList1 pageList = new PageList1();
		pageList.PageSize = this.ShowCount;
		pageList.PageID = this.int_0;
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		DataTable dataTable = shopNum1_Image_Action.SearchImageByType(this.string_6, this.string_5, 0, this.string_7, this.ShowCount.ToString(), this.int_0.ToString(), "1");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		}
		else
		{
			pageList.RecordCount = 0;
		}
		this.method_6(Convert.ToInt32(pageList.RecordCount / pageList.PageSize) + 1);
		PageListBll pageListBll = new PageListBll("main/admin/Image_List_Select", true, "2");
		pageListBll.ShowRecordCount = true;
		pageListBll.ShowPageCount = true;
		pageListBll.ShowPageIndex = true;
		pageListBll.ShowRecordCount = false;
		pageListBll.ShowNoRecordInfo = false;
		pageListBll.ShowNumListButton = true;
		pageListBll.PrevPageText = "<<上一页";
		pageListBll.NextPageText = "下一页>> ";
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (pageList.PageID > pageList.PageCount)
		{
			pageList.PageID = pageList.PageCount;
		}
		this.pageDiv.InnerHtml = pageListBll.GetPageListVk(pageList);
		DataTable dataTable2 = shopNum1_Image_Action.SearchImageByType(this.string_6, this.string_5, 0, this.string_7, this.ShowCount.ToString(), pageList.PageID.ToString(), "0");
		if (dataTable2 != null && dataTable2.Rows.Count > 0)
		{
			this.DataListShow.DataSource = dataTable2;
			this.DataListShow.DataBind();
		}
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
			DataTable dataTable = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable.Rows.Count > 0)
			{
				this.method_5(dataTable);
			}
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		//this.Page.Response.Redirect(string.Concat(new object[]
		//{
		//	this.string_8,
		//	"?name=",
		//	this.TextBoxSName.Text.Trim(),
		//	"&category=",
		//	this.DropDownListImgCategory1.SelectedValue,
		//	"&size=",
		//	this.ShowCount.ToString(),
		//	"&pageid=",
		//	1
		//}));
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
	private void method_6(int int_2)
	{
		this.DropDownListNumSelect.Items.Clear();
		for (int i = 1; i <= int_2; i++)
		{
			ListItem listItem = new ListItem();
			listItem.Text = i.ToString();
			listItem.Value = i.ToString();
			this.DropDownListNumSelect.Items.Add(listItem);
		}
	}
	protected void DropDownListNumSelect_SelectedIndexChanged(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("Image_List_Select.aspx?PageID={0}", this.DropDownListNumSelect.SelectedValue));
	}
	protected void DropDownListImgCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("Image_List_Select.aspx?category={0}&PageID=1", this.DropDownListImgCategory1.SelectedValue));
	}
	protected void ButtonDel_Click(object sender, EventArgs e)
	{
		ShopNum1_Image_Action shopNum1_Image_Action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
		string value = this.HiddenImgPath.Value;
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
				}
			}
		}
		catch
		{
		}
		int num = shopNum1_Image_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			MessageBox.Show("删除成功！");
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				this.string_8,
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
		else
		{
			MessageBox.Show("删除失败！");
		}
	}
}
