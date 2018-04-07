using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Shop_ImgManage : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	public string strPageSize = "10";
	public int pageID;
	public string Name;
	private string string_6;
	private string string_7;
	private string string_8;
	protected HtmlLink sizestylesheet;
	protected HtmlSelect selectShop;
	protected Label lblCount;
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
	protected HtmlGenericControl showpage;
	protected HtmlGenericControl pageDiv;
	protected TextBox TextBoxIndex;
	protected Button ButtonIndex;
	protected HiddenField CheckImgPath;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldBianji;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_9;
	[CompilerGenerated]
	private int int_0;
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
		this.string_5 = base.Request.RawUrl;
		if (this.string_5.IndexOf("?") != -1)
		{
			this.string_5 = this.string_5.Split(new char[]
			{
				'?'
			})[0];
		}
		this.pageID = ((this.Page.Request.QueryString["pageid"] == null) ? 1 : int.Parse(this.Page.Request.QueryString["pageid"]));
		this.Name = ((this.Page.Request.QueryString["name"] == null) ? "" : this.Page.Request.QueryString["name"]);
		this.ShowCount = ((this.Page.Request.QueryString["size"] == null) ? 10 : int.Parse(this.Page.Request.QueryString["size"]));
		this.string_8 = ((this.Page.Request.QueryString["sid"] == null) ? "0" : this.Page.Request.QueryString["sid"]);
		this.lblCount.Text = "0";
		this.strPageSize = ((Common.ReqStr("size") == "") ? "10" : Common.ReqStr("size"));
		string text = this.strPageSize;
		if (text != null)
		{
			if (text == "10")
			{
				this.LinkButton10.CssClass = "cur";
				goto IL_20F;
			}
			if (text == "20")
			{
				this.LinkButton20.CssClass = "cur";
				goto IL_20F;
			}
			if (text == "100")
			{
				this.LinkButton100.CssClass = "cur";
				goto IL_20F;
			}
		}
		this.LinkButton10.CssClass = "cur";
		IL_20F:
		if (!this.Page.IsPostBack)
		{
			this.TextBoxSName.Text = Common.ReqStr("name");
			this.BindImage();
		}
	}
	private string method_5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = HttpUtility.HtmlDecode(Common.ReqStr("name"));
		if (text != "")
		{
			stringBuilder.Append(" and name like '%" + text + "%'");
		}
		if (this.string_8 != "0")
		{
			stringBuilder.Append(" and shopid='" + this.string_8 + "'");
		}
		return stringBuilder.ToString();
	}
	protected void BindImage()
	{
		if (this.pageID <= 0)
		{
			this.pageID = 1;
		}
		PageList1 pageList = new PageList1();
		pageList.PageSize = this.ShowCount;
		pageList.PageID = this.pageID;
		Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
		DataSet dataSet = shop_Image_Action.MangeShopImg(this.strPageSize, this.pageID.ToString(), this.method_5(), "0");
		if (dataSet != null)
		{
			this.selectShop.Items.Clear();
			pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			if (pageList.RecordCount < 10)
			{
				this.showpage.Visible = false;
			}
			this.lblCount.Text = ((dataSet.Tables[1].Rows[0][0].ToString() == "") ? "0" : dataSet.Tables[1].Rows[0][0].ToString());
			DataTable dataTable = dataSet.Tables[2];
			ListItem listItem = new ListItem();
			listItem.Text = "-全部-";
			listItem.Value = "0";
			this.selectShop.Items.Add(listItem);
			if (dataTable.Rows.Count <= 0)
			{
				goto IL_29B;
			}
			DataView defaultView = dataTable.DefaultView;
			ListItem listItem2 = new ListItem();
			IEnumerator enumerator = defaultView.Table.Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					if (dataRow["createuser"].ToString() != "admin" && dataRow["shopid"].ToString().Trim() != "")
					{
						listItem2 = new ListItem();
						if (this.string_8 == dataRow["shopid"].ToString())
						{
							listItem2.Selected = true;
						}
						listItem2.Text = dataRow["createuser"].ToString().Trim();
						listItem2.Value = dataRow["shopid"].ToString().Trim();
						this.selectShop.Items.Add(listItem2);
					}
				}
				goto IL_29B;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		this.showpage.Visible = false;
		pageList.RecordCount = 0;
		IL_29B:
		PageListBll pageListBll = new PageListBll(this.string_5.Replace(".aspx", ""), true, "2");
		pageListBll.ShowRecordCount = true;
		pageListBll.ShowPageCount = true;
		pageListBll.ShowPageIndex = true;
		pageListBll.ShowRecordCount = false;
		pageListBll.ShowNoRecordInfo = false;
		pageListBll.ShowNumListButton = true;
		pageListBll.PrevPageText = "<<上一页";
		pageListBll.NextPageText = "下一页>> ";
		this.pageDiv.InnerHtml = pageListBll.GetPageListVk(pageList);
		DataSet dataSet2 = shop_Image_Action.MangeShopImg(this.strPageSize, this.pageID.ToString(), this.method_5(), "1");
		this.DataListShow.DataSource = dataSet2.Tables[0];
		this.DataListShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.TextBoxSName.Text.Trim(),
			"&sid=",
			this.string_8,
			"&size=",
			this.ShowCount.ToString(),
			"&pageid=",
			1
		}));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
		string strID = this.CheckGuid.Value.Replace(",'on'", "");
		string value = this.CheckImgPath.Value;
		try
		{
			string path = string.Empty;
			if (value.IndexOf(",") != -1)
			{
				string[] array = value.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					path = base.Server.MapPath(text);
					string path2 = text + "_25x25.jpg";
					string path3 = text + "_60x60.jpg";
					string path4 = text + "_100x100.jpg";
					string path5 = text + "_160x160.jpg";
					string path6 = text + "_300x300.jpg";
					if (File.Exists(path))
					{
						File.Delete(path);
						File.Delete(base.Server.MapPath(path2));
						File.Delete(base.Server.MapPath(path3));
						File.Delete(base.Server.MapPath(path4));
						File.Delete(base.Server.MapPath(path5));
						File.Delete(base.Server.MapPath(path6));
					}
				}
			}
			else
			{
				path = value;
				string path2 = value + "_25x25.jpg";
				string path3 = value + "_60x60.jpg";
				string path4 = value + "_100x100.jpg";
				string path5 = value + "_160x160.jpg";
				string path6 = value + "_300x300.jpg";
				path = base.Server.MapPath(path);
				if (File.Exists(path))
				{
					File.Delete(path);
					File.Delete(base.Server.MapPath(path2));
					File.Delete(base.Server.MapPath(path3));
					File.Delete(base.Server.MapPath(path4));
					File.Delete(base.Server.MapPath(path5));
					File.Delete(base.Server.MapPath(path6));
				}
			}
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		catch (Exception)
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
		shop_Image_Action.DeleteShopImg(strID);
		this.BindImage();
	}
	protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
	{
		if (e.CommandName == "delete")
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
			HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenFieldPath");
			Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
			string text = hiddenField2.Value;
			string str = text.Substring(0, text.LastIndexOf("/") + 1);
			string str2 = text.Substring(text.LastIndexOf("/") + 1, text.Length - text.LastIndexOf("/") - 1);
			string path = str + "s_" + str2;
			int num = 1;
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
				this.MessageShow.ShowMessage("删除失败,请检查文件权限！");
				this.MessageShow.Visible = true;
			}
			if (num > 0)
			{
				num = shop_Image_Action.DeleteShopImg(hiddenField.Value);
				this.BindImage();
			}
		}
	}
	protected void LinkButton10_Click(object sender, EventArgs e)
	{
		this.LinkButton10.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.Name,
			"&sid=",
			this.string_8,
			"&size=",
			10,
			"&pageid=",
			this.pageID
		}));
	}
	protected void LinkButton20_Click(object sender, EventArgs e)
	{
		this.LinkButton20.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.Name,
			"&sid=",
			this.string_8,
			"&size=",
			20,
			"&pageid=",
			this.pageID
		}));
	}
	protected void LinkButton100_Click(object sender, EventArgs e)
	{
		this.LinkButton100.CssClass = "cur";
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.Name,
			"&sid=",
			this.string_8,
			"&size=",
			100,
			"&pageid=",
			this.pageID
		}));
	}
	protected void ButtonIndex_Click(object sender, EventArgs e)
	{
		try
		{
			int.TryParse(this.TextBoxIndex.Text.Trim(), out this.pageID);
		}
		catch
		{
			this.pageID = 1;
		}
		this.Page.Response.Redirect(string.Concat(new object[]
		{
			this.string_5,
			"?name=",
			this.Name,
			"&shopid=",
			this.string_8,
			"&size=",
			this.ShowCount,
			"&pageid=",
			this.pageID.ToString()
		}));
	}
}
