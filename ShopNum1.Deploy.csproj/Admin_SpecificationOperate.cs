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
public class Admin_SpecificationOperate : PageBase, IRequiresSessionState
{
	public DataTable dt_Spec = null;
	public string strIsPic = string.Empty;
	protected Label lblSpec;
	protected Label LabelName;
	protected TextBox TextBoxSpecificationName;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorSort;
	protected RangeValidator RangeValidatorSort;
	protected Label LabelShowType;
	protected RadioButtonList RadioButtonListShowType;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected Button ButtonAdd;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldValues;
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
			if (Common.ReqStr("id") != "0" && Common.ReqStr("sign") == "del")
			{
				ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
				shopNum1_Spec_Action.DeleteValue(Common.ReqStr("id"));
			}
			this.TextBoxOrderID.Text = Convert.ToString(this.method_6() + 1);
			if (base.Request.QueryString["id"] != null)
			{
				this.method_5();
				this.lblSpec.Text = "编辑商品规格";
				this.ButtonAdd.Text = "确定编辑";
			}
		}
	}
	private void method_5()
	{
		ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
		DataTable dataTable = shopNum1_Spec_Action.SearchName(base.Request.QueryString["Id"].ToString());
		this.dt_Spec = shopNum1_Spec_Action.SearchByGuid(base.Request.QueryString["Id"].ToString());
		if (dataTable != null && dataTable.Rows.Count != 0)
		{
			this.TextBoxSpecificationName.Text = dataTable.Rows[0]["SpecName"].ToString();
			this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
			this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
			this.strIsPic = dataTable.Rows[0]["ShowType"].ToString();
			this.RadioButtonListShowType.SelectedValue = dataTable.Rows[0]["ShowType"].ToString();
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
		ShopNum1_Spec shopNum1_Spec = new ShopNum1_Spec();
		shopNum1_Spec.SpecName = this.TextBoxSpecificationName.Text.ToString().Trim();
		shopNum1_Spec.Memo = this.TextBoxMemo.Text.ToString().Trim();
		shopNum1_Spec.ShowType = new int?(Convert.ToInt32(this.RadioButtonListShowType.SelectedValue.ToString()));
		shopNum1_Spec.OrderID = new int?(int.Parse(this.TextBoxOrderID.Text.ToString()));
		List<ShopNum1_SpecValue> list = new List<ShopNum1_SpecValue>();
		if (this.HiddenFieldValues.Value != "-1")
		{
			string value = this.HiddenFieldValues.Value;
			if (base.Request.QueryString["id"] != null)
			{
				int value2 = Convert.ToInt32(base.Request.QueryString["id"]);
				shopNum1_Spec.ID = new int?(value2);
			}
			else
			{
				shopNum1_Spec.ID = new int?(shopNum1_Spec_Action.GetMaxGuid());
			}
			string[] array = value.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "")
				{
					if (this.RadioButtonListShowType.SelectedValue == "0")
					{
						list.Add(new ShopNum1_SpecValue
						{
							OrderId = new int?(Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[0])),
							Name = array[i].Split(new char[]
							{
								','
							})[1].Replace("*", "x"),
							ID = Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[2]),
							Imagepath = ""
						});
					}
					else
					{
						list.Add(new ShopNum1_SpecValue
						{
							OrderId = new int?(Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[0])),
							Name = array[i].Split(new char[]
							{
								','
							})[1].Replace("*", "x"),
							Imagepath = array[i].Split(new char[]
							{
								','
							})[2],
							ID = Convert.ToInt32(array[i].Split(new char[]
							{
								','
							})[3])
						});
					}
				}
			}
		}
		int num;
		if (base.Request.QueryString["id"] == null)
		{
			num = shopNum1_Spec_Action.Add(shopNum1_Spec, list);
		}
		else
		{
			num = shopNum1_Spec_Action.Update(shopNum1_Spec, list);
		}
		if (num > 0)
		{
			base.Response.Redirect("Specification_List.aspx");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	private int method_6()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Spec");
	}
	protected int GetOrderID(string filed, string table)
	{
		return 1 + ShopNum1_Common_Action.ReturnMaxID(filed, table);
	}
	private void method_7()
	{
		this.TextBoxSpecificationName.Text = string.Empty;
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
		this.MessageShow.ShowMessage("AddYes");
	}
}
