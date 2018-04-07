using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ServiceOnLineService_ManageShow : PageBase, IRequiresSessionState
{
	private ShopNum1_OnLineService_Action shopNum1_OnLineService_Action_0 = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
	protected HtmlHead Head1;
	protected Label LabelTtitle;
	protected RadioButton RadioButtonOpen;
	protected RadioButton RadioButtonClose;
	protected CheckBox CheckBoxQQ;
	protected CheckBox CheckBoxWW;
	protected CheckBox CheckBoxPhone;
	protected TextBox TextBoxServerPhone;
	protected Button ButtonAdd;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField HiddenFieldXmlPath;
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
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/City/" + base.SubstationID + "/Settings/ShopSetting.xml");
			this.method_5();
		}
	}
	private void method_5()
	{
		ShopSettings shopSettings = new ShopSettings();
		string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/City/" + base.SubstationID + "/Settings/ShopSetting.xml"), "ShowCustomer");
		string value2 = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/City/" + base.SubstationID + "/Settings/ShopSetting.xml"), "IsOpenPhone");
		string value3 = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/City/" + base.SubstationID + "/Settings/ShopSetting.xml"), "ServerPhone");
		if (value == "1")
		{
			this.RadioButtonOpen.Checked = true;
			this.RadioButtonClose.Checked = false;
		}
		else
		{
			this.RadioButtonOpen.Checked = false;
			this.RadioButtonClose.Checked = true;
		}
		this.TextBoxServerPhone.Text = value3;
		if (value2 == "1")
		{
			this.CheckBoxPhone.Checked = true;
		}
		else
		{
			this.CheckBoxPhone.Checked = false;
		}
		DataTable dataTable = this.shopNum1_OnLineService_Action_0.Search("-1", "-1", base.SubstationID);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				string text = dataRow["id"].ToString() + dataRow["IsShow"].ToString();
				if (text != null)
				{
					if (!(text == "11"))
					{
						if (text == "21")
						{
							this.CheckBoxWW.Checked = true;
						}
					}
					else
					{
						this.CheckBoxQQ.Checked = true;
					}
				}
			}
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		string string_ = string.Empty;
		string string_2 = string.Empty;
		if (this.RadioButtonOpen.Checked)
		{
			string_ = "1";
		}
		else
		{
			string_ = "0";
		}
		try
		{
			this.method_6(string_, "ShowCustomer");
			if (this.CheckBoxPhone.Checked)
			{
				string_2 = "1";
			}
			else
			{
				string_2 = "0";
			}
			this.method_6(string_2, "IsOpenPhone");
			this.method_6(this.TextBoxServerPhone.Text, "ServerPhone");
		}
		catch (Exception)
		{
		}
		string[] array = new string[3];
		string[] array2 = new string[3];
		for (int i = 0; i < 2; i++)
		{
			array[i] = (i + 1).ToString();
			array2[i] = "0";
		}
		if (this.CheckBoxQQ.Checked)
		{
			array2[0] = "1";
		}
		if (this.CheckBoxWW.Checked)
		{
			array2[1] = "1";
		}
		int num = this.shopNum1_OnLineService_Action_0.Update(array, array2, base.SubstationID);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("在线客服栏目编辑成功");
			this.MessageShow.Visible = true;
			this.method_5();
		}
		else
		{
			this.MessageShow.ShowMessage("在线客服编辑失败");
			this.MessageShow.Visible = true;
		}
	}
	private void method_6(string string_5, string string_6)
	{
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/" + string_6, string_5);
		ShopSettings.ResetShopSetting();
	}
}
