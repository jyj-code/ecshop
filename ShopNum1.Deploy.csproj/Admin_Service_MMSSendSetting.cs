using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_Service_MMSSendSetting : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPayIsMMS;
	protected DropDownList DropDownListPayIsMMS;
	protected Label LabelShipmentIsMMS;
	protected DropDownList DropDownListShipmentIsMMS;
	protected Label LabelShipmentOKIsMMS;
	protected DropDownList DropDownListShipmentOKIsMMS;
	protected Label LabelOrderIsMMS;
	protected DropDownList DropDownListOrderIsMMS;
	protected Label Label2;
	protected DropDownList DropDownListOrderToShopIsMMS;
	protected Label LabelCancelOrderIsMMS;
	protected DropDownList DropDownListCancelOrderIsMMS;
	protected Label Label25;
	protected DropDownList DropDownListRegistOrderIsMMS;
	protected Label LabelApplyOpenShopIsMMS;
	protected DropDownList DropDownListApplyOpenShopIsMMS;
	protected Label LabelAuditOpenShopIsMMS;
	protected DropDownList DropDownListAuditOpenShopIsMMS;
	protected Label Label1;
	protected DropDownList DropDownListMobileCheck;
	protected Button ButtonEdit;
	protected MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			this.BindSetting();
		}
	}
	protected void BindSetting()
	{
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				switch (name)
				{
				case "PayIsMMS":
					this.DropDownListPayIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShipmentIsMMS":
					this.DropDownListShipmentIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShipmentOKIsMMS":
					this.DropDownListShipmentOKIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "CancelOrderIsMMS":
					this.DropDownListCancelOrderIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "OrderIsMMS":
					this.DropDownListOrderIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "RegistOrderIsMMS":
					this.DropDownListRegistOrderIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "ApplyOpenShopIsMMS":
					this.DropDownListApplyOpenShopIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "AuditOpenShopIsMMS":
					this.DropDownListAuditOpenShopIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				case "IsMobileCheckPay":
					this.DropDownListMobileCheck.SelectedValue = xmlNode2.InnerText;
					break;
				case "OrderToShopIsMMS":
					this.DropDownListOrderToShopIsMMS.SelectedValue = xmlNode2.InnerText;
					break;
				}
			}
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		int num = 1;
		try
		{
			this.Updata();
		}
		catch (Exception)
		{
			num = 0;
		}
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			ShopSettings.ResetShopSetting();
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Updata()
	{
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayIsMMS", this.DropDownListPayIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentIsMMS", this.DropDownListShipmentIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentOKIsMMS", this.DropDownListShipmentOKIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CancelOrderIsMMS", this.DropDownListCancelOrderIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderIsMMS", this.DropDownListOrderIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegistOrderIsMMS", this.DropDownListRegistOrderIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ApplyOpenShopIsMMS", this.DropDownListApplyOpenShopIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AuditOpenShopIsMMS", this.DropDownListAuditOpenShopIsMMS.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IsMobileCheckPay", this.DropDownListMobileCheck.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderToShopIsMMS", this.DropDownListOrderToShopIsMMS.SelectedValue);
		ShopSettings.ResetShopSetting();
	}
}
