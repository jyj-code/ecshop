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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopNum1_ShopProductProp_Operate : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Label LabelName;
	protected TextBox TextBoxProductPropName;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelMemo;
	protected TextBox TextBoxContent;
	protected Label LabelShowType;
	protected RadioButtonList RadioButtonListShowType;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorSort;
	protected RangeValidator RangeValidatorSort;
	protected HtmlInputButton ButtonValueAdd;
	protected HtmlTableCell trProp;
	protected Button ButtonAdd;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldID;
	protected HiddenField HiddenFieldGuid;
	protected HiddenField HiddenFieldValues;
	protected HtmlForm form1;
	public DataTable dt_Prop = null;
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
		this.HiddenFieldGuid.Value = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
		if (!base.IsPostBack)
		{
			if (Common.ReqStr("id") != "0" && Common.ReqStr("sign") == "del")
			{
				ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action = (ShopNum1_ShopProductPropValue_Action)LogicFactory.CreateShopNum1_ShopProductPropValue_Action();
				shopNum1_ShopProductPropValue_Action.DeleteShopPropValue(Common.ReqStr("id"));
			}
			if (this.HiddenFieldGuid.Value != "-1")
			{
				this.method_5();
				this.ButtonAdd.Text = "确认修改";
				this.LabelTitle.Text = "编辑商品属性";
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.GetOrderID("OrderID", "ShopNum1_ShopProductProp"));
			}
		}
	}
	private void method_5()
	{
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = new ShopNum1_ShopProductProp_Action();
		ShopNum1_ShopProductProp propModelByID = shopNum1_ShopProductProp_Action.GetPropModelByID(int.Parse(this.HiddenFieldGuid.Value));
		if (propModelByID != null)
		{
			this.TextBoxProductPropName.Text = propModelByID.PropName;
			this.TextBoxContent.Text = propModelByID.Content;
			this.RadioButtonListShowType.SelectedValue = propModelByID.ShowType.ToString();
			if (propModelByID.ShowType.ToString() == "4")
			{
				this.ButtonValueAdd.Visible = false;
				this.trProp.Visible = false;
			}
			this.TextBoxOrderID.Text = propModelByID.OrderID.ToString();
			ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action = new ShopNum1_ShopProductPropValue_Action();
			this.dt_Prop = shopNum1_ShopProductPropValue_Action.GetPropValuesByPropID(this.HiddenFieldGuid.Value);
			if (this.dt_Prop.Rows.Count == 0)
			{
				this.dt_Prop = null;
			}
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.Operate();
	}
	protected void Operate()
	{
		ShopNum1_ShopProductProp shopNum1_ShopProductProp = new ShopNum1_ShopProductProp();
		if (base.Request.QueryString["guid"] == null)
		{
			shopNum1_ShopProductProp.ID = this.GetOrderID("ID", "ShopNum1_ShopProductProp");
		}
		else
		{
			shopNum1_ShopProductProp.ID = Convert.ToInt32(this.HiddenFieldGuid.Value);
		}
		shopNum1_ShopProductProp.OrderID = int.Parse(this.TextBoxOrderID.Text);
		shopNum1_ShopProductProp.PropName = this.TextBoxProductPropName.Text.Trim();
		shopNum1_ShopProductProp.ShowType = Convert.ToByte(this.RadioButtonListShowType.SelectedValue);
		shopNum1_ShopProductProp.Content = this.TextBoxContent.Text.Trim();
		shopNum1_ShopProductProp.IsImport = false;
		List<ShopNum1_ShopProductPropValue> list = new List<ShopNum1_ShopProductPropValue>();
		if (this.RadioButtonListShowType.SelectedValue == "4")
		{
			list.Add(new ShopNum1_ShopProductPropValue
			{
				PropId = shopNum1_ShopProductProp.ID,
				Name = string.Empty,
				OrderID = new int?(this.GetOrderID("OrderID", "ShopNum1_ShopProductPropValue"))
			});
		}
		else if (this.HiddenFieldValues.Value != "0")
		{
			string value = this.HiddenFieldValues.Value;
			string[] array = value.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "" && array[i] != "-1")
				{
					list.Add(new ShopNum1_ShopProductPropValue
					{
						ID = Convert.ToInt32(array[i].Split(new char[]
						{
							','
						})[2]),
						PropId = shopNum1_ShopProductProp.ID,
						OrderID = new int?(Convert.ToInt32(array[i].Split(new char[]
						{
							','
						})[0])),
						Name = array[i].Split(new char[]
						{
							','
						})[1]
					});
				}
			}
		}
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
		int num;
		if (this.HiddenFieldGuid.Value != "-1")
		{
			num = shopNum1_ShopProductProp_Action.Update(shopNum1_ShopProductProp, list);
		}
		else
		{
			num = shopNum1_ShopProductProp_Action.Add(shopNum1_ShopProductProp, list);
		}
		if (num > 0)
		{
			this.Page.Response.Redirect("ShopNum1_ShopProductProp_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Update()
	{
		ShopNum1_ShopProductProp shopNum1_ShopProductProp = new ShopNum1_ShopProductProp();
		shopNum1_ShopProductProp.ID = int.Parse(this.HiddenFieldGuid.Value);
		shopNum1_ShopProductProp.PropName = this.TextBoxProductPropName.Text.Trim();
		shopNum1_ShopProductProp.ShowType = Convert.ToByte(this.RadioButtonListShowType.SelectedValue);
		shopNum1_ShopProductProp.Content = this.TextBoxContent.Text.Trim();
		shopNum1_ShopProductProp.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		List<ShopNum1_ShopProductPropValue> list = new List<ShopNum1_ShopProductPropValue>();
		int orderID = this.GetOrderID("OrderID", "ShopNum1_ShopProductPropValue");
		if (this.RadioButtonListShowType.SelectedValue == "4")
		{
			list.Add(new ShopNum1_ShopProductPropValue
			{
				PropId = shopNum1_ShopProductProp.ID,
				Name = string.Empty,
				OrderID = new int?(orderID)
			});
		}
		ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
		int num = shopNum1_ShopProductProp_Action.Update(shopNum1_ShopProductProp, list);
		if (num > 0)
		{
			this.Page.Response.Redirect("ShopNum1_ShopProductProp_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected int GetOrderID(string filed, string table)
	{
		return 1 + ShopNum1_Common_Action.ReturnMaxID(filed, table);
	}
}
