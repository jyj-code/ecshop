using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Member_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSRealName;
	protected System.Web.UI.WebControls.TextBox TextBoxSRealName;
	protected Label Area;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode3;
	protected Label LabelSEmail;
	protected System.Web.UI.WebControls.TextBox TextBoxSEmail;
	protected Label Label3;
	protected System.Web.UI.WebControls.DropDownList DropDownListMemberRank;
	protected Label LabelMemberType;
	protected System.Web.UI.WebControls.DropDownList DropDownListMemberType;
	protected System.Web.UI.WebControls.TextBox TextMobile;
	protected Label LabelSSex;
	protected System.Web.UI.WebControls.DropDownList DropDownListSex;
	protected Label LabelCreditMoney;
	protected System.Web.UI.WebControls.TextBox TextBoxCreditMoney;
	protected Label LabelSIsForbid;
	protected System.Web.UI.WebControls.DropDownList DropdownListSIsForbid;
	protected Label LabelSRegDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSRegDate1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSRegDate2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAddMember;
	protected LinkButton ButtonAddShop;
	protected LinkButton ButtonCheck;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonIsForbid;
	protected LinkButton ButtonNoForbid;
	protected LinkButton ButtonAdvancePaymentModifyLog;
	protected LinkButton ButtonAdvancePaymentFreezeLog;
	protected LinkButton LinkBtnSetScore;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldRegionValue;
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
		if (!this.Page.IsPostBack)
		{
			this.DropDownListRegionCode1Bind();
			this.method_5();
			this.method_6();
		}
	}
	protected void LinkBtnSetScore_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("SetMemberScoreV82.aspx?mguid=" + this.CheckGuid.Value.ToString());
	}
	public string GetMemberRank(string guid)
	{
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		DataTable dataTable = shopNum1_MemberRank_Action.Search("'" + guid + "'", 0);
		string result;
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			result = dataTable.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "";
		}
		return result;
	}
	private void method_5()
	{
		this.DropDownListMemberRank.Items.Clear();
		this.DropDownListMemberRank.Items.Add(new ListItem("-全部-", "-1"));
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		DataTable dataTable = shopNum1_MemberRank_Action.Search("", 0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataTable.Rows[i]["Name"].ToString();
				listItem.Value = dataTable.Rows[i]["minScore"].ToString() + "/" + dataTable.Rows[i]["maxScore"].ToString();
				this.DropDownListMemberRank.Items.Add(listItem);
			}
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Member_Operate.aspx");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Member_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memTypeByGuid = shopNum1_Member_Action.GetMemTypeByGuid(this.CheckGuid.Value.ToString());
			foreach (DataRow dataRow in memTypeByGuid.Rows)
			{
				if (dataRow["MemberType"].ToString() == "2")
				{
					MessageBox.Show("无法删除,选择的会员是店铺会员!");
					this.MessageShow.ShowMessage("DelNo");
					this.MessageShow.Visible = true;
					return;
				}
			}
			int num = shopNum1_Member_Action.Delete(this.CheckGuid.Value.ToString());
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "删除成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Member_List.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
				this.method_6();
			}
		}
		catch (Exception)
		{
			MessageBox.Show("请勾选要删除的会员!");
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable memTypeByGuid = shopNum1_Member_Action.GetMemTypeByGuid(guids);
		foreach (DataRow dataRow in memTypeByGuid.Rows)
		{
			if (dataRow["MemberType"].ToString() == "2")
			{
				MessageBox.Show("无法删除,选择的会员是店铺会员!");
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
				return;
			}
		}
		int num = shopNum1_Member_Action.Delete(guids);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Member_List.aspx",
				Date = DateTime.Now
			});
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.method_6();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	public string ChangeIsForbid(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "已启用";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已禁用";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string ChangeLoginDate(object loginDate)
	{
		string result;
		if (loginDate.ToString() == "1900-1-1 0:00:00")
		{
			result = "";
		}
		else
		{
			result = loginDate.ToString();
		}
		return result;
	}
	protected string ChangeType(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "个人";
		}
		else if (object_0.ToString() == "2")
		{
			result = "店铺";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected string GetAdress(object AddressValue, object Address)
	{
		string result;
		try
		{
			string[] array = AddressValue.ToString().Split(new char[]
			{
				'|'
			});
			string text = array[0].ToString();
			string[] array2 = text.Split(new char[]
			{
				','
			});
			string str = string.Empty;
			if (array2.Length == 3)
			{
				str = array2[0] + array2[1] + array2[2];
			}
			else if (array2.Length == 2)
			{
				str = array2[0] + array2[1];
			}
			else if (array2.Length == 1)
			{
				str = array2[0];
			}
			else
			{
				str = Address.ToString();
			}
			result = str + Address.ToString();
		}
		catch
		{
			result = "";
		}
		return result;
	}
	protected string ChangeSex(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "男";
		}
		else if (object_0.ToString() == "1")
		{
			result = "女";
		}
		else
		{
			result = "保密";
		}
		return result;
	}
	private void method_6()
	{
		this.SetShopRegionCode();
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonIsForbid_Click(object sender, EventArgs e)
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		int num = shopNum1_Member_Action.UpdateemLoginTypeByMemLoginID(this.CheckGuid.Value.ToString(), 0);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			this.method_6();
		}
	}
	protected void ButtonNoForbid_Click(object sender, EventArgs e)
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		int num = shopNum1_Member_Action.UpdateemLoginTypeByMemLoginID(this.CheckGuid.Value.ToString(), 1);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			this.method_6();
		}
	}
	protected void ButtonAdvancePaymentModifyLog_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AdvancePaymentAlterOperate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonAdvancePaymentFreezeLog_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AdvancePaymentFreezeOperate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonAddMember_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("Member_Operate.aspx");
	}
	protected void ButtonCheck_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MemberInfo_Operate.aspx?guid=" + this.CheckGuid.Value.ToString());
	}
	protected void ButtonAddShop_Click(object sender, EventArgs e)
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable memTypeByGuid = shopNum1_Member_Action.GetMemTypeByGuid(this.CheckGuid.Value.ToString());
		if (memTypeByGuid != null && memTypeByGuid.Rows.Count > 0)
		{
			if (memTypeByGuid.Rows[0]["MemberType"].ToString() == "2")
			{
				MessageBox.Show("此会员已经有店铺");
			}
			else
			{
				base.Response.Redirect("OpenShop.aspx?guid=" + this.CheckGuid.Value.ToString());
			}
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
			this.HiddenFieldRegionCode.Value = "0";
		}
	}
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegionCode1.Items.Clear();
		this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
		ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
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
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
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
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
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
}
