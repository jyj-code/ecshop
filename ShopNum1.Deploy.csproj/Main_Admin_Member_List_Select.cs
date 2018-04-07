using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Member_List_Select : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	private int int_0;
	private string string_5;
	private string string_6 = ShopUrlOperate.GetSiteDomain() + "/main/admin/Member_List_Select.aspx";
	private ShopNum1_Member_Action shopNum1_Member_Action_0 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
	protected TextBox txtMemName;
	protected Button ButtonSearch;
	protected DataList DataListShow;
	protected Literal lnkTo;
	protected DropDownList DropDownListNumSelect;
	protected HtmlGenericControl pageDiv;
	protected HtmlForm form1;
	[CompilerGenerated]
	private int int_1;
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
		this.ShowCount = ((this.Page.Request.QueryString["size"] == null) ? 50 : int.Parse(this.Page.Request.QueryString["size"]));
		this.string_5 = ((this.Page.Request.QueryString["name"] == null) ? "" : this.Page.Request.QueryString["name"]);
		if (!base.IsPostBack)
		{
			this.BindData();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_6,
			"?name=",
			this.txtMemName.Text.Trim(),
			"&size=",
			this.ShowCount.ToString(),
			"&pageid=",
			1
		}));
	}
	protected void DropDownListNumSelect_SelectedIndexChanged(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("Member_List_Select.aspx?PageID={0}", this.DropDownListNumSelect.SelectedValue));
	}
	protected void BindData()
	{
		PageList1 pageList = new PageList1();
		pageList.PageSize = this.ShowCount;
		pageList.PageID = this.int_0;
		DataTable pagedData = this.GetPagedData(this.string_5, this.ShowCount.ToString(), this.int_0.ToString(), "1");
		if (pagedData != null && pagedData.Rows.Count > 0)
		{
			pageList.RecordCount = Convert.ToInt32(pagedData.Rows[0][0]);
		}
		else
		{
			pageList.RecordCount = 0;
		}
		this.method_5(Convert.ToInt32(pageList.RecordCount / pageList.PageSize) + 1);
		PageListBll pageListBll = new PageListBll("main/admin/Member_List_Select", true, "2");
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
		DataTable pagedData2 = this.GetPagedData(this.string_5, this.ShowCount.ToString(), this.int_0.ToString(), "0");
		if (pagedData2 != null && pagedData2.Rows.Count > 0)
		{
			this.DataListShow.DataSource = pagedData2;
			this.DataListShow.DataBind();
		}
	}
	public DataTable GetPagedData(string name, string pagesize, string current_page, string isReturCount)
	{
		string text = string.Empty;
		if (!string.IsNullOrEmpty(name))
		{
			text = text + " and MemLoginID like '%" + name + "%'";
		}
		string[] array = new string[5];
		string[] array2 = new string[5];
		array[0] = "@perPageNum";
		array2[0] = pagesize;
		array[1] = "@current_page";
		array2[1] = current_page;
		array[2] = "@ColumnNames";
		array2[2] = "MemLoginID";
		array[3] = "@searchName";
		array2[3] = text;
		array[4] = "@isReturCount";
		array2[4] = isReturCount;
		return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchMemberInfoPage", array, array2);
	}
	private void method_5(int int_2)
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
}
