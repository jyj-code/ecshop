using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AdminProuduct_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected TextBox TextBoxRepertoryNumber;
	protected DropDownList DropDownListIsShopRecommend;
	protected DropDownList DropDownListIsShopNew;
	protected DropDownList DropDownListIsShopGood;
	protected Localize LocalizeShopName;
	protected TextBox TextBoxShopName;
	protected DropDownList DropDownListIsSaled;
	protected DropDownList DropDownListIsSell;
	protected DropDownList DropDownListIsShopHot;
	protected Localize Localize1;
	protected TextBox TextBoxShopID;
	protected DropDownList DropDownListProductGuid1;
	protected DropDownList DropDownListProductGuid2;
	protected DropDownList DropDownListProductGuid3;
	protected UpdatePanel UpdatePanel1;
	protected Localize LocalizePrice;
	protected TextBox TextBoxPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorCostPrice1;
	protected TextBox TextBoxPrice2;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected DropDownList DropDownListSubstationID;
	protected Button Button1;
	protected DropDownList DropDownListIsAudit;
	protected DropDownList DropDownListOperate;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonChangeOrderID;
	protected MessageShow MessageShow;
	protected HtmlGenericControl pageDiv;
	protected HtmlGenericControl showPage;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
	protected HtmlForm form1;
	public DataTable dt_ProductList = null;
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
			this.GetSubstationID();
			this.DropDownListProductGuidBind();
			this.method_6();
			this.method_5();
		}
		if (this.Page.Request.QueryString["hot"] != null)
		{
			this.DropDownListIsShopHot.SelectedValue = this.Page.Request.QueryString["hot"].ToString();
		}
		if (this.Page.Request.QueryString["new"] != null)
		{
			this.DropDownListIsShopNew.SelectedValue = this.Page.Request.QueryString["new"].ToString();
		}
		if (this.Page.Request.QueryString["recommend"] != null)
		{
			this.DropDownListIsShopRecommend.SelectedValue = this.Page.Request.QueryString["recommend"].ToString();
		}
		if (this.Page.Request.QueryString["good"] != null)
		{
			this.DropDownListIsShopGood.SelectedValue = this.Page.Request.QueryString["good"].ToString();
		}
		if (Common.ReqStr("sign") == "del" && Common.ReqStr("guid") != "")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
			string guids = "'" + Common.ReqStr("guid") + "'";
			if (shopNum1_ProuductChecked_Action.Delete(guids) > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "管理员删除商品",
					OperatorID = this.Session["AdminLoginCookie"].ToString(),
					IP = Globals.IPAddress,
					PageName = "Prouduct_List.aspx",
					Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
				});
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
		this.BindGrid();
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
	}
	protected void BindGrid()
	{
		string text = Common.ReqStr("pagesize");
		if (text == "")
		{
			text = "10";
		}
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		string text2 = base.Request.RawUrl;
		if (text2.IndexOf("?") != -1)
		{
			text2 = text2.Split(new char[]
			{
				'?'
			})[0];
		}
		string text3 = Common.ReqStr("PageID");
		if (text3 == "")
		{
			text3 = "1";
		}
		DataTable dataTable = shopNum1_ProuductChecked_Action.V8_2_SearchPerPageNew("3", text.ToString(), text3, this.TextBoxName.Text, this.HiddenFieldCode.Value, this.TextBoxPrice1.Text, this.TextBoxPrice2.Text, this.DropDownListIsSaled.SelectedValue, "1", this.TextBoxShopID.Text, this.TextBoxShopName.Text, this.DropDownListIsSell.SelectedValue, this.DropDownListIsShopNew.SelectedValue, this.DropDownListIsShopHot.SelectedValue, this.DropDownListIsShopGood.SelectedValue, this.DropDownListIsShopRecommend.SelectedValue, this.DropDownListSubstationID.SelectedValue);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text);
		pageList.PageID = Convert.ToInt32(text3.ToString());
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		}
		else
		{
			pageList.RecordCount = 0;
		}
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (pageList.PageID > pageList.PageCount)
		{
			pageList.PageID = pageList.PageCount;
		}
		if (pageList.PageSize > pageList.RecordCount || pageList.PageCount == 1)
		{
			this.showPage.Visible = false;
		}
		else
		{
			this.showPage.Visible = true;
		}
		PageListBll pageListBll = new PageListBll(text2, true);
		this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.dt_ProductList = shopNum1_ProuductChecked_Action.V8_2_SearchPerPageNew("2", text.ToString(), pageList.PageID.ToString(), this.TextBoxName.Text, this.HiddenFieldCode.Value, this.TextBoxPrice1.Text, this.TextBoxPrice2.Text, this.DropDownListIsSaled.SelectedValue, "1", this.TextBoxShopID.Text, this.TextBoxShopName.Text, this.DropDownListIsSell.SelectedValue, this.DropDownListIsShopNew.SelectedValue, this.DropDownListIsShopHot.SelectedValue, this.DropDownListIsShopGood.SelectedValue, this.DropDownListIsShopRecommend.SelectedValue, this.DropDownListSubstationID.SelectedValue);
		if (this.dt_ProductList.Rows.Count == 0)
		{
			this.dt_ProductList = null;
		}
	}
	private void method_6()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListIsSaled.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "否";
		listItem2.Value = "0";
		this.DropDownListIsSaled.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "是";
		listItem3.Value = "1";
		this.DropDownListIsSaled.Items.Add(listItem3);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.returnProductCategory();
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		if (shopNum1_ProuductChecked_Action.Delete(this.CheckGuid.Value.ToString()) > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除商品",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "Prouduct_List.aspx",
				Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
			});
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
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		if (this.DropDownListOperate.SelectedValue == "-1" || this.DropDownListOperate.SelectedValue == "-2")
		{
			MessageBox.Show("请选择需要的操作！");
		}
		else
		{
			string[] array = this.DropDownListOperate.SelectedValue.ToString().Split(new char[]
			{
				','
			});
			if (array.Length >= 2)
			{
				ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
				int num = shopNum1_ProuductChecked_Action.UpdateProduct(this.CheckGuid.Value, array[0], array[1]);
				if (num > 0)
				{
					if (array[0] == "IsSaled" && array[1] == "0")
					{
						DataTable tableById = Common.GetTableById("Name,MemLoginId", "ShopNum1_Shop_Product", " And Guid=" + this.CheckGuid.Value);
						if (tableById.Rows.Count > 0)
						{
							ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
							shopNum1_MessageInfo.Guid = Guid.NewGuid();
							shopNum1_MessageInfo.Title = "商品被管理员下架";
							shopNum1_MessageInfo.Type = "1";
							shopNum1_MessageInfo.Content = "您的商品被管理员下架,商品名称为[" + tableById.Rows[0]["Name"].ToString() + "]。";
							shopNum1_MessageInfo.SendTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							shopNum1_MessageInfo.IsDeleted = 0;
							shopNum1_MessageInfo.MemLoginID = "Admin";
							List<string> list = new List<string>();
							list.Add(tableById.Rows[0]["MemloginId"].ToString());
							ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MessageInfo_Action();
							shopNum1_MessageInfo_Action.Add(shopNum1_MessageInfo, list);
							base.OperateLog(new ShopNum1_OperateLog
							{
								Record = "管理员下架商品",
								OperatorID = this.Session["AdminLoginCookie"].ToString(),
								IP = Globals.IPAddress,
								PageName = "Prouduct_List.aspx",
								Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
							});
						}
					}
					this.BindGrid();
					this.MessageShow.ShowMessage("OperateYes");
					this.MessageShow.Visible = true;
				}
				else
				{
					this.MessageShow.ShowMessage("OperateNo");
					this.MessageShow.Visible = true;
				}
				this.BindGrid();
			}
		}
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		DataTable list = shopNum1_ProuductChecked_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid2.Items.Clear();
		this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable list = shopNum1_ProuductChecked_Action.GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid3.Items.Clear();
		this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable list = shopNum1_ProuductChecked_Action.GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else if (object_0.ToString() == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
	public string ChangeIsSaled(string strIsSaled)
	{
		string result;
		if (strIsSaled == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else if (strIsSaled == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
	public string ChangeIsNew(string strIsNew)
	{
		string result;
		if (strIsNew == "0")
		{
			result = "×";
		}
		else if (strIsNew == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsBest(string strIsBest)
	{
		string result;
		if (strIsBest == "0")
		{
			result = "×";
		}
		else if (strIsBest == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsHot(string strIsHot)
	{
		string result;
		if (strIsHot == "0")
		{
			result = "×";
		}
		else if (strIsHot == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsPromotion(string strIsRecommend)
	{
		string result;
		if (strIsRecommend == "0")
		{
			result = "×";
		}
		else if (strIsRecommend == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public void returnProductCategory()
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	protected void ButtonSee_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProductSearchDetal.aspx?guid=" + this.CheckGuid.Value + "&Type=Other&Back=1");
	}
	protected void ButtonChangeOrderID_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ChangeOrder.aspx?guid=" + this.CheckGuid.Value + "&back=prouduct");
	}
	public string IsSell(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else if (object_0.ToString() == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ObjectDataSourceDate_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
	{
	}
}
