using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_websites_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode1;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode2;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegionCode3;
	protected CompareValidator CompareValidatorDropDownListRegionCode1;
	protected Localize Localizereplacement;
	protected ShopNum1.Control.TextBox TextBoxDomain;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.RadioButtonList RadioButtonListOpen;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action_0 = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", ""));
		this.shopNum1_DispatchRegion_Action_0.TableName = "ShopNum1_DispatchRegion";
		if (!base.IsPostBack)
		{
			this.DropDownListRegionCode1Bind();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelTitle.Text = "编辑站点";
				this.GetEditInfo();
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void GetEditInfo()
	{
		IShopNum1_WebSite_Action shopNum1_WebSite_Action = LogicFactory.CreateShopNum1_WebSite_Action();
		IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();
		DataTable siteByID = shopNum1_WebSite_Action.GetSiteByID(this.hiddenFieldGuid.Value);
		if (siteByID != null && siteByID.Rows.Count > 0)
		{
			this.TextBoxDomain.Text = siteByID.Rows[0]["domain"].ToString();
			this.RadioButtonListOpen.SelectedValue = (Convert.ToBoolean(siteByID.Rows[0]["isAvailable"]) ? "1" : "0");
			this.ViewState["addressName"] = siteByID.Rows[0]["addressName"].ToString();
			string text = siteByID.Rows[0]["addressCode"].ToString();
			if (text.Length >= 3)
			{
				DataTable regionCode = shopNum1_Address_Action.GetRegionCode(text.Substring(0, 3));
				if (regionCode != null && regionCode.Rows.Count > 0)
				{
					this.DropDownListRegionCode1.SelectedValue = regionCode.Rows[0]["Code"].ToString() + "/" + regionCode.Rows[0]["ID"].ToString();
					this.DropDownLis1_SelectedIndexChanged(null, null);
				}
			}
			if (text.Length >= 6)
			{
				DataTable regionCode2 = shopNum1_Address_Action.GetRegionCode(text.Substring(0, 6));
				if (regionCode2 != null && regionCode2.Rows.Count > 0)
				{
					this.DropDownListRegionCode2.Visible = true;
					this.DropDownListRegionCode2.SelectedValue = regionCode2.Rows[0]["Code"].ToString() + "/" + regionCode2.Rows[0]["ID"].ToString();
					this.DropDownList2_SelectedIndexChanged(null, null);
				}
			}
			if (text.Length == 9)
			{
				DataTable regionCode3 = shopNum1_Address_Action.GetRegionCode(text);
				if (regionCode3 != null && regionCode3.Rows.Count > 0)
				{
					this.DropDownListRegionCode3.Visible = true;
					this.DropDownListRegionCode3.SelectedValue = regionCode3.Rows[0]["Code"].ToString() + "/" + regionCode3.Rows[0]["ID"].ToString();
				}
			}
		}
	}
	protected void Add()
	{
		ShopNum1_WebSite shopNum1_WebSite = new ShopNum1_WebSite();
		shopNum1_WebSite.addressName = this.GetDropDownListDispatchRegionName();
		shopNum1_WebSite.addressCode = this.GetDropDownListRegionCode();
		shopNum1_WebSite.domain = this.TextBoxDomain.Text.Trim().ToLower();
		shopNum1_WebSite.isAvailable = (this.RadioButtonListOpen.SelectedValue == "1");
		IShopNum1_WebSite_Action shopNum1_WebSite_Action = LogicFactory.CreateShopNum1_WebSite_Action();
		if (shopNum1_WebSite_Action.CheckAddressName(shopNum1_WebSite.addressName))
		{
			MessageBox.Show("选择的地区已经添加过站点了!");
		}
		else if (shopNum1_WebSite_Action.Insert(shopNum1_WebSite))
		{
			this.method_5();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Edit()
	{
		ShopNum1_WebSite shopNum1_WebSite = new ShopNum1_WebSite();
		shopNum1_WebSite.ID = int.Parse(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_WebSite.addressName = this.GetDropDownListDispatchRegionName();
		shopNum1_WebSite.addressCode = this.GetDropDownListRegionCode();
		shopNum1_WebSite.domain = this.TextBoxDomain.Text.Trim().ToLower();
		shopNum1_WebSite.isAvailable = (this.RadioButtonListOpen.SelectedValue == "1");
		IShopNum1_WebSite_Action shopNum1_WebSite_Action = LogicFactory.CreateShopNum1_WebSite_Action();
		if (this.ViewState["addressName"] != shopNum1_WebSite.addressName && shopNum1_WebSite_Action.CheckAddressName(this.TextBoxDomain.Text.Trim()))
		{
			MessageBox.Show("选择的地区已经添加过站点了!");
		}
		else if (shopNum1_WebSite_Action.Update(shopNum1_WebSite))
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_5()
	{
		this.TextBoxDomain.Text = string.Empty;
	}
	private void method_6(string string_5, System.Web.UI.WebControls.DropDownList dropDownList_0)
	{
		DataTable dispatchRegionName = this.shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(string_5);
		for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
		{
			if (!(string_5 == "0") || !(dispatchRegionName.Rows[i]["Name"].ToString().Trim() == "所有地区"))
			{
				dropDownList_0.Items.Add(new ListItem(dispatchRegionName.Rows[i]["Name"].ToString(), dispatchRegionName.Rows[i]["Code"].ToString() + "/" + dispatchRegionName.Rows[i]["ID"].ToString()));
			}
		}
	}
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegionCode1.Items.Clear();
		this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
		DataTable dispatchRegionName = this.shopNum1_DispatchRegion_Action_0.GetDispatchRegionName("0");
		for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
		{
			this.DropDownListRegionCode1.Items.Add(new ListItem(dispatchRegionName.Rows[i]["Name"].ToString(), dispatchRegionName.Rows[i]["Code"].ToString() + "/" + dispatchRegionName.Rows[i]["ID"].ToString()));
		}
	}
	protected void DropDownLis1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			DataTable dispatchRegionName = this.shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			if (dispatchRegionName != null && dispatchRegionName.Rows.Count != 0)
			{
				this.DropDownListRegionCode2.Visible = true;
				this.DropDownListRegionCode2.Items.Clear();
				this.DropDownListRegionCode2.Items.Add(new ListItem("-请选择-", "-1"));
				this.method_6(this.DropDownListRegionCode1.SelectedValue.Split(new char[]
				{
					'/'
				})[1], this.DropDownListRegionCode2);
				this.DropDownList2_SelectedIndexChanged(null, null);
			}
		}
		else
		{
			this.DropDownListRegionCode2.Visible = false;
			this.DropDownListRegionCode2.Items.Clear();
		}
	}
	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			DataTable dispatchRegionName = this.shopNum1_DispatchRegion_Action_0.GetDispatchRegionName(this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			if (dispatchRegionName != null && dispatchRegionName.Rows.Count != 0)
			{
				this.DropDownListRegionCode3.Visible = true;
				this.DropDownListRegionCode3.Items.Clear();
				this.DropDownListRegionCode3.Items.Add(new ListItem("-请选择-", "-1"));
				this.method_6(this.DropDownListRegionCode2.SelectedValue.Split(new char[]
				{
					'/'
				})[1], this.DropDownListRegionCode3);
			}
		}
		else
		{
			this.DropDownListRegionCode3.Visible = false;
			this.DropDownListRegionCode3.Items.Clear();
		}
	}
	public string GetDropDownListRegionCode()
	{
		string result;
		if (this.DropDownListRegionCode3.SelectedValue != "" && this.DropDownListRegionCode3.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode2.SelectedValue != "" && this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListRegionCode1.SelectedValue != "" && this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			result = "-1";
		}
		return result;
	}
	public string GetDropDownListDispatchRegionName()
	{
		string result;
		if (this.DropDownListRegionCode3.SelectedValue != "" && this.DropDownListRegionCode3.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode1.SelectedItem.Text + this.DropDownListRegionCode2.SelectedItem.Text + this.DropDownListRegionCode3.SelectedItem.Text;
		}
		else if (this.DropDownListRegionCode2.SelectedValue != "" && this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode1.SelectedItem.Text + this.DropDownListRegionCode2.SelectedItem.Text;
		}
		else if (this.DropDownListRegionCode1.SelectedValue != "" && this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			result = this.DropDownListRegionCode1.SelectedItem.Text;
		}
		else
		{
			result = "-1";
		}
		return result;
	}
}
