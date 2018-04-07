using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CategoryType_Add : PageBase, IRequiresSessionState
{
	protected HtmlLink cssfile2;
	protected Label lblSpec;
	protected HtmlInputText txtTypeName;
	protected HtmlInputText txtSortId;
	protected HtmlTextArea txtDesc;
	protected CheckBox IsShow;
	protected HtmlInputHidden hidSpec;
	protected HtmlInputHidden hidBrand;
	protected HtmlInputHidden hidProp;
	protected Button butSub;
	protected HtmlGenericControl spanHtml;
	protected HtmlForm form1;
	public DataTable dt_Spec = null;
	public DataTable dt_Prop = null;
	public DataTable dt_Brand = null;
	private string string_5 = null;
	private ShopNum1_CategoryType_Action shopNum1_CategoryType_Action_0 = new ShopNum1_CategoryType_Action();
	private ShopNum1_CategoryType shopNum1_CategoryType_0 = new ShopNum1_CategoryType();
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
		this.string_5 = Common.ReqStr("t_id");
		if (!this.Page.IsPostBack)
		{
			if (!string.IsNullOrEmpty(this.string_5))
			{
				this.butSub.Text = "更新";
				this.method_6();
				this.lblSpec.Text = "编辑商品类型";
			}
			else
			{
				this.txtSortId.Value = this.method_5();
			}
			this.method_7(this.string_5);
			this.method_8(this.string_5);
			this.method_9(this.string_5);
		}
	}
	private string method_5()
	{
		return Common.GetNameById("max(OrderID)+1", "ShopNum1_CategoryType", " and isdeleted=0");
	}
	public string setProp(string strType)
	{
		string result;
		if (strType != null)
		{
			if (strType == "0")
			{
				result = "文字输入";
				return result;
			}
			if (strType == "1")
			{
				result = "列表单选";
				return result;
			}
			if (strType == "2")
			{
				result = "下拉框单选";
				return result;
			}
			if (strType == "3")
			{
				result = "多选";
				return result;
			}
		}
		result = "自定义属性";
		return result;
	}
	private void method_6()
	{
		ShopNum1_CategoryType shopNum1_CategoryType = this.shopNum1_CategoryType_Action_0.Select_CategoryType(this.string_5);
		this.txtTypeName.Value = shopNum1_CategoryType.Name;
		this.txtDesc.Value = shopNum1_CategoryType.Description;
		this.txtSortId.Value = shopNum1_CategoryType.OrderID.ToString();
		if (shopNum1_CategoryType.IsShow == 1)
		{
			this.IsShow.Checked = true;
		}
		else
		{
			this.IsShow.Checked = false;
		}
		this.hidProp.Value = shopNum1_CategoryType.Pro_Ids;
		this.hidSpec.Value = shopNum1_CategoryType.Spec_Ids;
	}
	protected void butSub_Click(object sender, EventArgs e)
	{
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		new ShopNum1_TypeBrand();
		if (this.hidBrand.Value != "")
		{
			List<ShopNum1_TypeBrand> list = new List<ShopNum1_TypeBrand>();
			int value;
			if (string.IsNullOrEmpty(this.string_5))
			{
				value = this.shopNum1_CategoryType_Action_0.Get_TypeMaxId();
			}
			else
			{
				value = Convert.ToInt32(this.string_5);
			}
			shopNum1_Brand_Action.Delete_TypeBrand(value.ToString());
			string[] array = this.hidBrand.Value.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "")
				{
					list.Add(new ShopNum1_TypeBrand
					{
						BrandGuid = new Guid?(new Guid(array[i])),
						TypeID = new int?(value)
					});
				}
			}
			shopNum1_Brand_Action.Add_TypeBrand(list);
		}
		this.shopNum1_CategoryType_0.Name = Operator.FilterString(this.txtTypeName.Value);
		try
		{
			this.shopNum1_CategoryType_0.OrderID = new int?(Convert.ToInt32(this.txtSortId.Value));
		}
		catch
		{
			this.shopNum1_CategoryType_0.OrderID = new int?(1);
		}
		this.shopNum1_CategoryType_0.CreateUser = base.ShopNum1LoginID;
		this.shopNum1_CategoryType_0.ModifyUser = base.ShopNum1LoginID;
		this.shopNum1_CategoryType_0.Description = Operator.FilterString(this.txtDesc.Value);
		if (this.IsShow.Checked)
		{
			this.shopNum1_CategoryType_0.IsShow = new int?(1);
		}
		else
		{
			this.shopNum1_CategoryType_0.IsShow = new int?(0);
		}
		this.shopNum1_CategoryType_0.Spec_Ids = this.hidSpec.Value;
		this.shopNum1_CategoryType_0.Pro_Ids = this.hidProp.Value;
		int num;
		if (string.IsNullOrEmpty(this.string_5))
		{
			num = this.shopNum1_CategoryType_Action_0.Add_CategoryType(this.shopNum1_CategoryType_0);
		}
		else
		{
			this.shopNum1_CategoryType_0.ID = Convert.ToInt32(this.string_5);
			num = this.shopNum1_CategoryType_Action_0.Update_CategoryType(this.shopNum1_CategoryType_0);
		}
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增或修改商品类型",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "CategoryType_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("CategoryType.aspx");
		}
		else
		{
			this.spanHtml.InnerHtml = "操作失败！";
		}
	}
	public string IsCheck(string strvId, int Type)
	{
		string result;
		if (!string.IsNullOrEmpty(this.string_5))
		{
			string value;
			if (Type == 1)
			{
				value = this.hidSpec.Value;
			}
			else
			{
				value = this.hidProp.Value;
			}
			if (value.IndexOf(strvId) != -1)
			{
				result = "checked='checked'";
			}
			else
			{
				result = "";
			}
		}
		else
		{
			result = "";
		}
		return result;
	}
	private void method_7(string string_6)
	{
		ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
		this.dt_Spec = shopNum1_Spec_Action.Search_Type_Spec(string_6);
	}
	private void method_8(string string_6)
	{
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
		this.dt_Prop = shopNum1_ShopProductProp_Action.Search_Type_Prop(string_6);
	}
	private void method_9(string string_6)
	{
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		this.dt_Brand = shopNum1_Brand_Action.Search_Type_Brand(string_6);
	}
}
