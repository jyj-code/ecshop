using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopCategoryAply_Audit : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode3;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSearchShop;
	protected LinkButton ButtonOperate;
	protected LinkButton ButtonOperate1;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSource;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField HiddenFieldCode;
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
			this.BindProductIsAudit();
			this.DropDownListShopCategoryCode1Bind();
			this.method_6();
		}
	}
	private DataTable method_5(string string_5, string string_6, string string_7, string string_8, string string_9, string string_10)
	{
		string text = string.Empty;
		text = "SELECT A.*,B.ShopName,B.ShopUrl FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID ";
		if (!string.IsNullOrEmpty(string_5))
		{
			text = text + " AND B.ShopName='" + string_5.Trim() + "'";
		}
		if (!string.IsNullOrEmpty(string_6))
		{
			text = text + " AND A.ShopID='" + string_6.Trim() + "'";
		}
		if (string_7.Trim() != "-1" && string_7.Trim() != "")
		{
			text = text + " AND A.OldShopCategoryCode='" + string_7.Trim() + "'";
		}
		if (!string.IsNullOrEmpty(string_8))
		{
			text = text + " AND A.IsAudit=" + string_8.Trim();
		}
		if (!string.IsNullOrEmpty(string_9))
		{
			text = text + " AND A.ApplyTime>='" + string_9.Trim() + "'";
		}
		if (!string.IsNullOrEmpty(string_10))
		{
			text = text + " AND A.ApplyTime<='" + string_10.Trim() + "'";
		}
		text += " AND A.IsAudit IN (0,2) ORDER BY A.ApplyTime DESC";
		return DatabaseExcetue.ReturnDataTable(text);
	}
	protected void BindProductIsAudit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		bool flag = false;
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdataShopCategoryApplyIsAudit(this.CheckGuid.Value, "1") > 0)
		{
			this.method_6();
			string[] array = this.CheckGuid.Value.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				DataTable shopCategoryInfoByGuid = shopNum1_ShopInfoList_Action.GetShopCategoryInfoByGuid(array[i]);
				if (shopCategoryInfoByGuid != null && shopCategoryInfoByGuid.Rows.Count > 0)
				{
					string shopCategoryName = shopCategoryInfoByGuid.Rows[i]["ShopCategoryName"].ToString();
					string shopCategoryCode = shopCategoryInfoByGuid.Rows[i]["NewShopCateGoryCode"].ToString();
					string brandName = shopCategoryInfoByGuid.Rows[i]["BrandName"].ToString();
					string brandGuid = shopCategoryInfoByGuid.Rows[i]["NewBrandGuid"].ToString();
					flag = (shopNum1_ShopInfoList_Action.UpdateShopCategoryAndBrandByGuids(array[i], shopCategoryName, shopCategoryCode, brandName, brandGuid) > 0);
				}
				else
				{
					flag = false;
				}
			}
		}
		else
		{
			flag = false;
		}
		if (flag)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdataShopCategoryApplyIsAudit(this.CheckGuid.Value, "2") > 0)
		{
			this.method_6();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_6()
	{
		this.SetShopCategoryCode();
		this.Num1GridViewShow.DataSource = this.method_5("", "", "", "", "", "").DefaultView;
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		int num = shopNum1_ShopInfoList_Action.DeleteShopCategoryApply(this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_6();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		int num = shopNum1_ShopInfoList_Action.DeleteShopCategoryApply(guids);
		if (num > 0)
		{
			this.method_6();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已通过";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void DropDownListShopCategoryCode1Bind()
	{
		this.DropDownListShopCategoryCode1.Items.Clear();
		this.DropDownListShopCategoryCode1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
		DataTable list = shopNum1_ShopCategory_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListShopCategoryCode1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListShopCategoryCode2.Items.Clear();
		this.DropDownListShopCategoryCode2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListShopCategoryCode1.SelectedValue != "-1")
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable list = shopNum1_ShopCategory_Action.GetList(this.DropDownListShopCategoryCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListShopCategoryCode2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListShopCategoryCode3.Items.Clear();
		this.DropDownListShopCategoryCode3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListShopCategoryCode2.SelectedValue != "-1")
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable list = shopNum1_ShopCategory_Action.GetList(this.DropDownListShopCategoryCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void SetShopCategoryCode()
	{
		if (this.DropDownListShopCategoryCode3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListShopCategoryCode2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListShopCategoryCode1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopCategoryAply_SearchDetail.aspx?guid=" + this.CheckGuid.Value);
	}
}
