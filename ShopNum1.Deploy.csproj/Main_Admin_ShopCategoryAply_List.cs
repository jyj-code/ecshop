using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopCategoryAply_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode3;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
	protected System.Web.UI.WebControls.Button ButtonSearchShop;
	protected System.Web.UI.WebControls.Button ButtonOperate;
	protected System.Web.UI.WebControls.Button ButtonOperate1;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSource;
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
			this.method_5();
		}
	}
	protected void BindProductIsAudit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("审核通过", "1"));
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		bool flag = false;
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdataShopCategoryApplyIsAudit(this.CheckGuid.Value, "1") > 0)
		{
			this.method_5();
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
			this.method_5();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5()
	{
		this.SetShopCategoryCode();
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		int num = shopNum1_ShopInfoList_Action.DeleteShopCategoryApply(this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_5();
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
