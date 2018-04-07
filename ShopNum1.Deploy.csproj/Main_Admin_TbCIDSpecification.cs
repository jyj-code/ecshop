using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbBusinessEntity;
using ShopNum1.TbTopCommon;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_TbCIDSpecification : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	protected HtmlHead Head1;
	protected ListBox ListBoxTop;
	protected ListBox lbox1;
	protected ListBox lbox2;
	protected ListBox lbox3;
	protected ListBox lbox4;
	protected ListBox lbox5;
	protected Button ButtonCatetory;
	protected Button Button1;
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
		if (!base.IsPostBack)
		{
			this.lbox1.Visible = false;
		}
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
		if (this.ViewState["cid"] == null)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "msg", "alert(\"还没选择分类\")", true);
		}
		else
		{
			string text = string.Empty;
			text = this.ViewState["cid"].ToString();
			shopNum1_Spec_Action.GetTbCid(text);
			string text2 = string.Empty;
			if (this.ViewState["cName1"] != null)
			{
				text2 = this.ViewState["cName1"].ToString();
			}
			if (this.ViewState["cName2"] != null)
			{
				text2 += this.ViewState["cName2"].ToString();
			}
			if (this.ViewState["cName3"] != null)
			{
				text2 += this.ViewState["cName3"].ToString();
			}
			if (this.ViewState["cName4"] != null)
			{
				text2 += this.ViewState["cName4"].ToString();
			}
			if (this.ViewState["cName5"] != null)
			{
				text2 += this.ViewState["cName5"].ToString();
			}
			this.ChangeCname(text2);
			this.method_5(text, this.string_5.Trim());
		}
	}
	private void method_5(string string_6, string string_7)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("fields", "pid,name,must,multi,prop_values,is_sale_prop,is_enum_prop");
		dictionary.Add("cid", string_6);
		string itemcatsPost = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemprops.get", dictionary);
		List<ShopNum1_TbPropValue> list = new List<ShopNum1_TbPropValue>();
		ErrorRsp errorRsp = new ErrorRsp();
		new Parser().XmlToObject2<ShopNum1_TbPropValue>(itemcatsPost, "itemprops_get", "item_props/item_prop", list, errorRsp);
		if (!errorRsp.IsError)
		{
			ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
			ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
			ShopNum1_Spec shopNum1_Spec = new ShopNum1_Spec();
			int num = 0;
			if (list.Count == 0)
			{
				MessageBox.Show("该分类下没有规格属性!");
			}
			else
			{
				foreach (ShopNum1_TbPropValue current in list)
				{
					if (current.is_sale_prop)
					{
						shopNum1_Spec.SpecName = current.name;
						shopNum1_Spec.Memo = string_7;
						shopNum1_Spec.ShowType = new int?(0);
						int maxGuid = shopNum1_Spec_Action.GetMaxGuid();
						shopNum1_Spec.ID = new int?(maxGuid);
						shopNum1_Spec.OrderID = new int?(maxGuid);
						shopNum1_Spec.tbProp = current.pid.ToString();
						List<ShopNum1_TbPropValue> list2 = new List<ShopNum1_TbPropValue>();
						new Parser().NewXmlToObject2<ShopNum1_TbPropValue>(itemcatsPost, "itemprops_get", "item_props/item_prop/prop_values/prop_value", list2, errorRsp, current.pid.ToString(), "pid");
						List<ShopNum1_SpecValue> list3 = new List<ShopNum1_SpecValue>();
						foreach (ShopNum1_TbPropValue current2 in list2)
						{
							string tbPropvalue = current.pid.ToString() + ":" + current2.vid.ToString();
							if (!this.CheckSpecDetailExist(tbPropvalue))
							{
								ShopNum1_SpecValue shopNum1_SpecValue = new ShopNum1_SpecValue();
								shopNum1_SpecValue.Name = current2.name;
								shopNum1_SpecValue.Imagepath = "";
								shopNum1_SpecValue.tbPropValue = current2.vid.ToString();
								shopNum1_SpecValue.OrderId = new int?(shopNum1_SpecValue.ID);
								list3.Add(shopNum1_SpecValue);
							}
						}
						int num2 = shopNum1_Spec_Action.Add(shopNum1_Spec, list3);
						num += num2;
					}
					else if (!current.is_sale_prop)
					{
						ShopNum1_ShopProductProp shopNum1_ShopProductProp = new ShopNum1_ShopProductProp();
						shopNum1_ShopProductProp.ID = this.GetOrderID("ID", "ShopNum1_ShopProductProp");
						shopNum1_ShopProductProp.OrderID = this.GetOrderID("ID", "ShopNum1_ShopProductProp");
						shopNum1_ShopProductProp.PropName = current.name;
						if (current.is_enum_prop)
						{
							shopNum1_ShopProductProp.ShowType = Convert.ToByte("2");
						}
						else
						{
							shopNum1_ShopProductProp.ShowType = Convert.ToByte("4");
						}
						shopNum1_ShopProductProp.Content = string_7;
						shopNum1_ShopProductProp.IsImport = false;
						List<ShopNum1_TbPropValue> list4 = new List<ShopNum1_TbPropValue>();
						new Parser().NewXmlToObject2<ShopNum1_TbPropValue>(itemcatsPost, "itemprops_get", "item_props/item_prop/prop_values/prop_value", list4, errorRsp, current.pid.ToString(), "pid");
						List<ShopNum1_ShopProductPropValue> list5 = new List<ShopNum1_ShopProductPropValue>();
						foreach (ShopNum1_TbPropValue current2 in list4)
						{
							string tbPropvalue = current.pid.ToString() + ":" + current2.vid.ToString();
							if (!this.CheckSpecDetailExist(tbPropvalue))
							{
								ShopNum1_ShopProductPropValue shopNum1_ShopProductPropValue = new ShopNum1_ShopProductPropValue();
								shopNum1_ShopProductPropValue.PropId = shopNum1_ShopProductProp.ID;
								shopNum1_ShopProductPropValue.OrderID = new int?(shopNum1_ShopProductPropValue.ID);
								shopNum1_ShopProductPropValue.Name = current2.name;
								list5.Add(shopNum1_ShopProductPropValue);
							}
						}
						int num2 = shopNum1_ShopProductProp_Action.Add(shopNum1_ShopProductProp, list5);
						num += num2;
					}
				}
				if (num > 0)
				{
					MessageBox.Show("导入成功!");
				}
			}
		}
	}
	public void ChangeCname(string name)
	{
		string text = string.Empty;
		text = name.Replace(" ", "");
		if (text.Contains(' '))
		{
			this.ChangeCname(text);
		}
		this.string_5 = text;
	}
	public bool CheckSpecDetailExist(string tbPropvalue)
	{
		ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
		DataTable dataTable = shopNum1_Spec_Action.SpecificationDetailsGetByTbPropValue(tbPropvalue);
		return dataTable != null && dataTable.Rows.Count != 0;
	}
	protected int GetOrderID(string filed, string table)
	{
		return 1 + ShopNum1_Common_Action.ReturnMaxID(filed, table);
	}
	protected void lbox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.lbox1.SelectedValue;
		this.ViewState["cName1"] = this.lbox1.SelectedItem.Text;
		List<ShopNum1_TbSysItemCat> list = this.method_6(this.lbox1.SelectedValue);
		if (list != null && list.Count != 0)
		{
			foreach (ShopNum1_TbSysItemCat current in list)
			{
				if (current.is_parent)
				{
					current.name += "           ->";
				}
			}
			this.lbox2.Visible = true;
			this.lbox3.Visible = false;
			this.lbox4.Visible = false;
			this.lbox5.Visible = false;
			this.lbox2.DataSource = list;
			this.lbox2.DataTextField = "name";
			this.lbox2.DataValueField = "cid";
			this.lbox2.DataBind();
			this.lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
		}
		else
		{
			this.lbox2.Visible = false;
			this.lbox3.Visible = false;
			this.lbox4.Visible = false;
			this.lbox5.Visible = false;
			this.ViewState["cid"] = this.lbox1.SelectedValue;
			this.ViewState["cName1"] = this.lbox1.SelectedItem.Text;
		}
	}
	protected void lbox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.lbox2.SelectedValue;
		this.ViewState["cName2"] = this.lbox2.SelectedItem.Text;
		List<ShopNum1_TbSysItemCat> list = this.method_6(this.lbox2.SelectedValue);
		if (list != null && list.Count != 0)
		{
			foreach (ShopNum1_TbSysItemCat current in list)
			{
				if (current.is_parent)
				{
					current.name += "           ->";
				}
			}
			this.lbox3.Visible = true;
			this.lbox4.Visible = false;
			this.lbox5.Visible = false;
			this.lbox3.DataSource = list;
			this.lbox3.DataTextField = "name";
			this.lbox3.DataValueField = "cid";
			this.lbox3.DataBind();
			this.lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
		}
		else
		{
			this.lbox3.Visible = false;
			this.lbox4.Visible = false;
			this.lbox5.Visible = false;
			this.ViewState["cid"] = this.lbox2.SelectedValue;
			this.ViewState["cName2"] = this.lbox2.SelectedItem.Text;
		}
	}
	protected void lbox3_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.lbox3.SelectedValue;
		this.ViewState["cName3"] = this.lbox3.SelectedItem.Text;
		List<ShopNum1_TbSysItemCat> list = this.method_6(this.lbox3.SelectedValue);
		if (list != null && list.Count != 0)
		{
			foreach (ShopNum1_TbSysItemCat current in list)
			{
				if (current.is_parent)
				{
					current.name += "           ->";
				}
			}
			this.lbox4.Visible = true;
			this.lbox5.Visible = false;
			this.lbox4.DataSource = list;
			this.lbox4.DataTextField = "name";
			this.lbox4.DataValueField = "cid";
			this.lbox4.DataBind();
			this.lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
		}
		else
		{
			this.lbox4.Visible = false;
			this.lbox5.Visible = false;
			this.ViewState["cid"] = this.lbox3.SelectedValue;
			this.ViewState["cName3"] = this.lbox3.SelectedItem.Text;
		}
	}
	protected void lbox4_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.lbox4.SelectedValue;
		this.ViewState["cName4"] = this.lbox4.SelectedItem.Text;
		List<ShopNum1_TbSysItemCat> list = this.method_6(this.lbox4.SelectedValue);
		if (list != null && list.Count != 0)
		{
			foreach (ShopNum1_TbSysItemCat current in list)
			{
				if (current.is_parent)
				{
					current.name += "           ->";
				}
			}
			this.lbox5.Visible = true;
			this.lbox5.DataSource = list;
			this.lbox5.DataTextField = "name";
			this.lbox5.DataValueField = "cid";
			this.lbox5.DataBind();
			this.lbox2.Style.Add(HtmlTextWriterStyle.Display, "block");
		}
		else
		{
			this.lbox5.Visible = false;
			this.ViewState["cid"] = this.lbox4.SelectedValue;
			this.ViewState["cName4"] = this.lbox4.SelectedItem.Text;
		}
	}
	protected void lbox5_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.lbox5.SelectedValue;
		this.ViewState["cName5"] = this.lbox5.SelectedItem.Text;
	}
	private List<ShopNum1_TbSysItemCat> method_6(string string_6)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("fields", "cid,parent_cid,name,parent_name,is_parent,status,sort_order");
		dictionary.Add("parent_cid", string_6);
		string itemcatsPost = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemcats.get", dictionary);
		List<ShopNum1_TbSysItemCat> list = new List<ShopNum1_TbSysItemCat>();
		Parser parser = new Parser();
		ErrorRsp errorRsp = new ErrorRsp();
		parser.XmlToObject2<ShopNum1_TbSysItemCat>(itemcatsPost, "itemcats_get", "item_cats/item_cat", list, errorRsp);
		List<ShopNum1_TbSysItemCat> result;
		if (errorRsp.IsError)
		{
			result = null;
		}
		else
		{
			result = list;
		}
		return result;
	}
	private List<ShopNum1_TbSysItemCat> method_7(string string_6, string string_7)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("fields", "cid,parent_cid,name,parent_name,is_parent,status,sort_order");
		dictionary.Add("parent_cid", string_6);
		dictionary.Add("cids", string_7);
		string itemcatsPost = TopAPI.GetItemcatsPost(TopConfig.AdminAppkey, TopConfig.AdminSecret, "taobao.itemcats.get", dictionary);
		List<ShopNum1_TbSysItemCat> list = new List<ShopNum1_TbSysItemCat>();
		Parser parser = new Parser();
		ErrorRsp errorRsp = new ErrorRsp();
		parser.XmlToObject2<ShopNum1_TbSysItemCat>(itemcatsPost, "itemcats_get", "item_cats/item_cat", list, errorRsp);
		List<ShopNum1_TbSysItemCat> result;
		if (errorRsp.IsError)
		{
			result = null;
		}
		else
		{
			result = list;
		}
		return result;
	}
	protected void ListBoxTop_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.ViewState["cid"] = this.ListBoxTop.SelectedValue;
		this.ViewState["cName1"] = this.ListBoxTop.SelectedItem.Text;
		string string_ = string.Empty;
		if (this.ListBoxTop.SelectedValue == "1")
		{
			string_ = "40,50011665,50008907,99";
		}
		if (this.ListBoxTop.SelectedValue == "2")
		{
			string_ = "30,16,50011740,50006843,50006842,1625,50010404";
		}
		if (this.ListBoxTop.SelectedValue == "3")
		{
			string_ = "50023904,1512,14,1201,1101,50019780,50018222,11,50018264,50008090,50012164,50007218,50018004,20";
		}
		if (this.ListBoxTop.SelectedValue == "4")
		{
			string_ = "50022703,50011972,50012100,50012082,50002768";
		}
		if (this.ListBoxTop.SelectedValue == "5")
		{
			string_ = "50010788,1801,50023282,50011397,28,50013864,50468001";
		}
		if (this.ListBoxTop.SelectedValue == "6")
		{
			string_ = "35,50014812,50022517,50008165,25";
		}
		if (this.ListBoxTop.SelectedValue == "7")
		{
			string_ = "50020808,50020857,50008164,50020611,27,50020332,50020485,50020579,50008163,50023804";
		}
		if (this.ListBoxTop.SelectedValue == "8")
		{
			string_ = "21,50016349,50016348,50020275,50002766,50016422,2813,50025705,50026316,50026800,50050359";
		}
		if (this.ListBoxTop.SelectedValue == "9")
		{
			string_ = "50010728,50013886,50011699,50012029,50510002";
		}
		if (this.ListBoxTop.SelectedValue == "10")
		{
			string_ = "50025707,50011949,23,33,34,50017300,29,50014442,50454031";
		}
		if (this.ListBoxTop.SelectedValue == "11")
		{
			string_ = "120950001,50026555,50026523,50008075,50019095,50014927,26,50050471,50007216,50018252,50014811,50023575,50024451,50024971,50025004,50025110,50074001,50158001,50025111";
		}
		if (this.ListBoxTop.SelectedValue == "12")
		{
			string_ = "121266001,50488001,120894001,50016350,50023724,50230002,50690010";
		}
		List<ShopNum1_TbSysItemCat> list = this.method_7("0", string_);
		try
		{
			foreach (ShopNum1_TbSysItemCat current in list)
			{
				if (current.is_parent)
				{
					current.name += "           ->";
				}
			}
		}
		catch
		{
			MessageBox.Show("淘宝系统参数设置不正确！");
		}
		this.lbox1.Visible = true;
		this.lbox2.Visible = false;
		this.lbox3.Visible = false;
		this.lbox4.Visible = false;
		this.lbox5.Visible = false;
		this.lbox1.DataSource = list;
		this.lbox1.DataTextField = "name";
		this.lbox1.DataValueField = "cid";
		this.lbox1.DataBind();
	}
	protected void ButtonCatetory_Click(object sender, EventArgs e)
	{
		if (this.ViewState["cid"] == null)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "msg", "alert(\"还没选择分类\")", true);
		}
		else
		{
			int num = 0;
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			ShopNum1_CategoryType_Action shopNum1_CategoryType_Action = new ShopNum1_CategoryType_Action();
			if (!string.IsNullOrEmpty(this.ListBoxTop.SelectedValue) && string.IsNullOrEmpty(this.lbox1.SelectedValue) && string.IsNullOrEmpty(this.lbox2.SelectedValue))
			{
				int value = shopNum1_CategoryType_Action.Add_CategoryTypeInto(new ShopNum1_CategoryType
				{
					Name = Operator.FilterString(this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()),
					OrderID = new int?(0),
					CreateUser = "admin",
					ModifyUser = "admin",
					Description = Operator.FilterString(this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()),
					IsShow = new int?(1)
				});
				object value2 = shopNum1_ProductCategory_Action.Add1(new ShopNum1_ProductCategory
				{
					Name = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
					Keywords = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
					Description = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim(),
					OrderID = 0,
					logoimg = "",
					IsShow = 1,
					CategoryLevel = 1,
					FatherID = 0,
					CreateUser = "admin",
					CreateTime = DateTime.Now,
					ModifyUser = "admin",
					ModifyTime = DateTime.Now,
					IsDeleted = 0,
					CategoryType = new int?(value),
					CategoryTypeName = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
				});
				num++;
				string string_ = string.Empty;
				if (this.ListBoxTop.SelectedValue == "1")
				{
					string_ = "40,50011665,50008907,99";
				}
				if (this.ListBoxTop.SelectedValue == "2")
				{
					string_ = "30,16,50011740,50006843,50006842,1625,50010404";
				}
				if (this.ListBoxTop.SelectedValue == "3")
				{
					string_ = "50023904,1512,14,1201,1101,50019780,50018222,11,50018264,50008090,50012164,50007218,50018004,20";
				}
				if (this.ListBoxTop.SelectedValue == "4")
				{
					string_ = "50022703,50011972,50012100,50012082,50002768";
				}
				if (this.ListBoxTop.SelectedValue == "5")
				{
					string_ = "50010788,1801,50023282,50011397,28,50013864,50468001";
				}
				if (this.ListBoxTop.SelectedValue == "6")
				{
					string_ = "35,50014812,50022517,50008165,25";
				}
				if (this.ListBoxTop.SelectedValue == "7")
				{
					string_ = "50020808,50020857,50008164,50020611,27,50020332,50020485,50020579,50008163,50023804";
				}
				if (this.ListBoxTop.SelectedValue == "8")
				{
					string_ = "21,50016349,50016348,50020275,50002766,50016422,2813,50025705,50026316,50026800,50050359";
				}
				if (this.ListBoxTop.SelectedValue == "9")
				{
					string_ = "50010728,50013886,50011699,50012029,50510002";
				}
				if (this.ListBoxTop.SelectedValue == "10")
				{
					string_ = "50025707,50011949,23,33,34,50017300,29,50014442,50454031";
				}
				if (this.ListBoxTop.SelectedValue == "11")
				{
					string_ = "120950001,50026555,50026523,50008075,50019095,50014927,26,50050471,50007216,50018252,50014811,50023575,50024451,50024971,50025004,50025110,50074001,50158001,50025111";
				}
				if (this.ListBoxTop.SelectedValue == "12")
				{
					string_ = "121266001,50488001,120894001,50016350,50023724,50230002,50690010";
				}
				List<ShopNum1_TbSysItemCat> list = this.method_7("0", string_);
				if (list != null && list.Count != 0)
				{
					foreach (ShopNum1_TbSysItemCat current in list)
					{
						object value3 = shopNum1_ProductCategory_Action.Add1(new ShopNum1_ProductCategory
						{
							Name = current.name,
							Keywords = current.name,
							Description = current.name,
							OrderID = 0,
							logoimg = "",
							IsShow = 1,
							CategoryLevel = 2,
							FatherID = Convert.ToInt32(value2),
							CreateUser = "admin",
							CreateTime = DateTime.Now,
							ModifyUser = "admin",
							ModifyTime = DateTime.Now,
							IsDeleted = 0,
							CategoryType = new int?(value),
							CategoryTypeName = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
						});
						num++;
						List<ShopNum1_TbSysItemCat> list2 = this.method_6(current.cid);
						if (list2 != null && list2.Count != 0)
						{
							List<ShopNum1_ProductCategory> list3 = new List<ShopNum1_ProductCategory>();
							foreach (ShopNum1_TbSysItemCat current2 in list2)
							{
								list3.Add(new ShopNum1_ProductCategory
								{
									Name = current2.name,
									Keywords = current2.name,
									Description = current2.name,
									OrderID = 0,
									logoimg = "",
									IsShow = 1,
									CategoryLevel = 3,
									FatherID = Convert.ToInt32(value3),
									CreateUser = "admin",
									CreateTime = DateTime.Now,
									ModifyUser = "admin",
									ModifyTime = DateTime.Now,
									IsDeleted = 0,
									CategoryType = new int?(value),
									CategoryTypeName = this.ListBoxTop.SelectedItem.Text.Replace("->", "").Trim()
								});
							}
							shopNum1_ProductCategory_Action.AddList(list3);
							num++;
						}
					}
				}
				if (num > 0)
				{
					MessageBox.Show("分类导入成功！");
				}
				else
				{
					MessageBox.Show("分类导入失败！");
				}
			}
		}
	}
}
