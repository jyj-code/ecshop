using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopInfoList_Manage : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberName;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopRank;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsRecommend;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopCategoryCode3;
	protected System.Web.UI.UpdatePanel UpdatePanel2;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopReputation;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsVisits;
	protected System.Web.UI.WebControls.DropDownList DropDownListIshot;
	protected System.Web.UI.WebControls.DropDownList DropDownListShopEnsure;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIdentityIsAudit;
	protected System.Web.UI.WebControls.DropDownList DropDownListCompanIsAudit;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperate;
	protected LinkButton ButtonOperate;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonUpdateRank;
	protected LinkButton ButtonManagerShop;
	protected LinkButton ButtonUpataShopURL;
	protected LinkButton ButtonChangeOrderID;
	protected LinkButton ButtonShopPayMent;
	protected LinkButton LinkButton1;
	protected AgentAdmin_MessageShow MessageShow;
	protected System.Web.UI.WebControls.Button ButtonSearchShop;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSource;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldSubstationID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsExpires;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.GetSubstationID();
			this.DropDownListShopCategoryCode1Bind();
			this.DropDownListRegionCode1Bind();
			this.BindDropDownListShopRank();
			this.BindDropDownListShopReputation();
			this.BindDropDownListShopEnsure();
			this.method_5();
			if (ShopSettings.GetValue("IsManagerShop") == "1")
			{
				this.ButtonManagerShop.Visible = true;
			}
			if (ShopSettings.GetValue("PayMentType") == "2")
			{
				this.ButtonShopPayMent.Visible = true;
			}
			this.ButtonManagerShop.Attributes.Add("onclick", "this.form.target='_blank'");
		}
	}
	protected void ButtonWxPayMent_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SetWxInfo_V82.aspx?guid=" + this.CheckGuid.Value);
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
	}
	public string GetListImageStatus(string isshow)
	{
		string result;
		if (isshow == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "images/shopNum1Admin-right.gif";
		}
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		string text = this.DropDownListOperate.SelectedValue;
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (text == "2")
		{
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsExpires", "1") > 0 && shopNum1_ShopInfoList_Action.UpdateMemberType(this.CheckGuid.Value, 1) > 0)
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
		if (text == "11")
		{
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsExpires", "0") > 0 && shopNum1_ShopInfoList_Action.UpdateMemberType(this.CheckGuid.Value, 2) > 0)
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
		if (text == "3")
		{
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsClose", "1") > 0 && shopNum1_ShopInfoList_Action.UpdateMemberType(this.CheckGuid.Value, 1) > 0)
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
		if (text == "12")
		{
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsClose", "0") > 0 && shopNum1_ShopInfoList_Action.UpdateMemberType(this.CheckGuid.Value, 2) > 0)
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
		if (text == "5" || text == "8")
		{
			if (text == "5")
			{
				text = "1";
			}
			else
			{
				text = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsRecommend", text) > 0)
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
		if (text == "6" || text == "9")
		{
			if (text == "6")
			{
				text = "1";
			}
			else
			{
				text = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsVisits ", text) > 0)
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
		if (text == "7" || text == "10")
		{
			if (text == "7")
			{
				text = "1";
			}
			else
			{
				text = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsHot", text) > 0)
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
		if (text == "15" || text == "17")
		{
			if (text == "15")
			{
				text = "1";
			}
			else
			{
				text = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IdentityIsAudit", text) > 0)
			{
				this.method_5();
				shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IdentityAuditTime", DateTime.Now.ToString());
				this.MessageShow.ShowMessage("Audit2Yes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
		if (text == "16" || text == "18")
		{
			if (text == "16")
			{
				text = "1";
			}
			else
			{
				text = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "CompanIsAudit", text) > 0)
			{
				this.method_5();
				shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "CompanAuditTime", DateTime.Now.ToString());
				this.MessageShow.ShowMessage("Audit2Yes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
		if (text == "19" || text == "20")
		{
			string string_;
			if (text == "19")
			{
				string_ = "1";
			}
			else
			{
				string_ = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsIntegralShop", string_) > 0)
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
		if (text == "21" || text == "22")
		{
			string string_;
			if (text == "21")
			{
				string_ = "1";
			}
			else
			{
				string_ = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsWeixin", string_) > 0)
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
		if (text == "23" || text == "24")
		{
			string string_;
			if (text == "23")
			{
				string_ = "1";
			}
			else
			{
				string_ = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsHot", string_) > 0)
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
		if (text == "30" || text == "31")
		{
			string string_;
			if (text == "31")
			{
				string_ = "1";
			}
			else
			{
				string_ = "0";
			}
			if (shopNum1_ShopInfoList_Action.UpdateShopState(this.CheckGuid.Value, "IsProductAduit", string_) > 0)
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
		this.DropDownListOperate.SelectedValue = "-1";
	}
	private void method_5()
	{
		this.SetShopCategoryCode();
		this.SetShopRegionCode();
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value.IndexOf(",") != -1)
		{
			MessageBox.Show("一次只能选择一条记录操作！");
		}
		else
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable shopInfoByGuid = shopNum1_ShopInfoList_Action.GetShopInfoByGuid(this.CheckGuid.Value);
			string value = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
			string str = shopInfoByGuid.Rows[0]["ShopID"].ToString();
			string str2 = shopInfoByGuid.Rows[0]["MemLoginID"].ToString();
			string path = "~/Shop/Shop/" + Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + str;
			string path2 = "~/ImgUpload/" + Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + str;
			this.method_6(base.Server.MapPath(path2));
			this.method_6(base.Server.MapPath(path));
			shopNum1_Member_Action.UpdateMemberType(this.CheckGuid.Value, 1);
			int num = shopNum1_ShopInfoList_Action.Delete(this.CheckGuid.Value, "'" + str2 + "'");
			if (num > 0)
			{
				this.method_5();
				this.Session["AdminLoginCookie"] = "Admin";
				this.MessageShow.ShowMessage("Audit2Yes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string text = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
		DataTable shopInfoByGuid = shopNum1_ShopInfoList_Action.GetShopInfoByGuid(text);
		string value = shopInfoByGuid.Rows[0]["OpenTime"].ToString();
		string str = shopInfoByGuid.Rows[0]["ShopID"].ToString();
		string str2 = shopInfoByGuid.Rows[0]["MemLoginID"].ToString();
		string path = "~/Shop/Shop/" + Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + str;
		string path2 = "~/ImgUpload/" + Convert.ToDateTime(value).ToString("yyyy/MM/dd").Replace('-', '/') + "/Shop" + str;
		this.method_6(base.Server.MapPath(path2));
		this.method_6(base.Server.MapPath(path));
		shopNum1_Member_Action.UpdateMemberType(text, 1);
		int num = shopNum1_ShopInfoList_Action.Delete(text, "'" + str2 + "'");
		if (num > 0)
		{
			this.method_5();
			this.Session["AdminLoginCookie"] = "Admin";
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	private void method_6(string string_5)
	{
		try
		{
			if (Directory.Exists(string_5))
			{
				string[] fileSystemEntries = Directory.GetFileSystemEntries(string_5);
				for (int i = 0; i < fileSystemEntries.Length; i++)
				{
					string text = fileSystemEntries[i];
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					else
					{
						this.method_6(text);
					}
				}
				Directory.Delete(string_5, true);
			}
		}
		catch
		{
		}
	}
	public string YesOrNo(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "是";
		}
		else
		{
			result = "否";
		}
		return result;
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未通过";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string IsExpires(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未过期";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已过期";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string IsClose(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未关闭";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已关闭";
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
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
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
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
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
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
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
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegionCode1.Items.Clear();
		this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
		ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
		DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(0, 0);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListRegionCode1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
		}
		this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode2.Items.Clear();
		this.DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
		if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1].ToString()), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode3.Items.Clear();
		this.DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
		if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1].ToString()), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode3.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
	}
	protected void BindDropDownListShopRank()
	{
		this.DropDownListShopRank.Items.Clear();
		this.DropDownListShopRank.Items.Add(new ListItem("-全部-", "-1"));
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
		DataTable shopRank = shop_Rank_Action.GetShopRank();
		if (shopRank != null && shopRank.Rows.Count > 0)
		{
			for (int i = 0; i < shopRank.Rows.Count; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = shopRank.Rows[i]["Name"].ToString();
				listItem.Value = shopRank.Rows[i]["Guid"].ToString();
				this.DropDownListShopRank.Items.Add(listItem);
			}
		}
	}
	protected void BindDropDownListShopReputation()
	{
		this.DropDownListShopReputation.Items.Clear();
		this.DropDownListShopReputation.Items.Add(new ListItem("-全部-", "-1"));
		Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action();
		DataTable dataTable = shop_Reputation_Action.Search("", -1);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataTable.Rows[i]["Name"].ToString();
				listItem.Value = dataTable.Rows[i]["minScore"].ToString() + "/" + dataTable.Rows[i]["maxScore"].ToString();
				this.DropDownListShopReputation.Items.Add(listItem);
			}
		}
	}
	protected void BindDropDownListShopEnsure()
	{
		this.DropDownListShopEnsure.Items.Clear();
		this.DropDownListShopEnsure.Items.Add(new ListItem("-全部-", "-1"));
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		DataTable shopEnsureList = shop_Ensure_Action.GetShopEnsureList("");
		if (shopEnsureList != null && shopEnsureList.Rows.Count > 0)
		{
			for (int i = 0; i < shopEnsureList.Rows.Count; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = shopEnsureList.Rows[i]["Name"].ToString();
				listItem.Value = shopEnsureList.Rows[i]["ID"].ToString();
				this.DropDownListShopEnsure.Items.Add(listItem);
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
	public void SetShopRegionCode()
	{
		if (this.DropDownListRegionCode3.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldRegionCode.Value = "-1";
		}
	}
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopInfo_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonUpdateRank_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("UptateRank_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonManagerShop_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable memberInfoByGuid = shopNum1_ShopInfoList_Action.GetMemberInfoByGuid(this.CheckGuid.Value);
		if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
		{
			HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			string a = httpCookie.Values["MemberType"].ToString();
			if (a == "2")
			{
				base.Response.Write("<script>alert(\"当前已有管理的店铺，请退出后再管理该店铺！\");window.opener=null;window.open('','_self');window.close();</script>");
				base.Response.End();
				return;
			}
		}
		HttpCookie httpCookie2 = new HttpCookie("MemberLoginCookie");
		httpCookie2.Values.Add("Name", memberInfoByGuid.Rows[0]["Name"].ToString());
		httpCookie2.Values.Add("MemLoginID", memberInfoByGuid.Rows[0]["MemLoginID"].ToString());
		httpCookie2.Values.Add("MemberType", memberInfoByGuid.Rows[0]["MemberType"].ToString());
		if (memberInfoByGuid.Rows[0]["MemberType"].ToString() == "2")
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopRankByMemLoginID = shop_ShopInfo_Action.GetShopRankByMemLoginID(memberInfoByGuid.Rows[0]["MemLoginID"].ToString());
			if (shopRankByMemLoginID != null && shopRankByMemLoginID.Rows.Count > 0)
			{
				httpCookie2.Values.Add("ShopRank", shopRankByMemLoginID.Rows[0]["ShopRank"].ToString());
			}
			HttpCookie httpCookie3 = HttpSecureCookie.Encode(httpCookie2);
			httpCookie3.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
			this.Page.Response.AppendCookie(httpCookie3);
			this.Page.Response.Redirect("http://" + ShopSettings.siteDomain + "/shop/shopadmin/s_index.aspx");
		}
		else
		{
			base.Response.Write("<script type='text/javascript'>alert(\"店铺已过期或者已关闭!\");window.opener=null;window.open('','_self');window.close();</script>");
			base.Response.End();
		}
	}
	protected void ButtonChangeOrderID_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ChangeOrder.aspx?guid=" + this.CheckGuid.Value + "&back=shop");
	}
	protected void ButtonUpataShopURL_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("UpdateShopURL.aspx?guid=" + this.CheckGuid.Value + "&type=List");
	}
	protected void ButtonShopPayMent_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ManagerShopPayMent.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonUpdateCreditSum_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("UpdateShopCreditSum.aspx?guid=" + this.CheckGuid.Value);
	}
}
