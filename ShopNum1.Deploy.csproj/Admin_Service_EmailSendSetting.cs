using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_Service_EmailSendSetting : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPayIsEmail;
	protected DropDownList DropDownListPayIsEmail;
	protected Label LabelShipmentIsEmail;
	protected DropDownList DropDownListShipmentIsEmail;
	protected Label LabelShipmentOKIsEmail;
	protected DropDownList DropDownListShipmentOKIsEmail;
	protected Label LabelOrderIsEmail;
	protected DropDownList DropDownListOrderIsEmail;
	protected Label Label1;
	protected DropDownList DropDownListOrderToShopIsEmail;
	protected Label LabelCancelOrderIsEmail;
	protected DropDownList DropDownListCancelOrderIsEmail;
	protected Label LabelMemberRegister;
	protected DropDownList DropDownListMemberRegister;
	protected Label Label28;
	protected DropDownList DropDownListRegIsActivationEmail;
	protected Label LabelApplyOpenShopIsEmail;
	protected DropDownList DropDownListApplyOpenShopIsEmail;
	protected Label LabelAuditOpenShopIsEmail;
	protected DropDownList DropDownListAuditOpenShopIsEmail;
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
				case "PayIsEmail":
					this.DropDownListPayIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShipmentIsEmail":
					this.DropDownListShipmentIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "ShipmentOKIsEmail":
					this.DropDownListShipmentOKIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "CancelOrderIsEmail":
					this.DropDownListCancelOrderIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "OrderIsEmail":
					this.DropDownListOrderIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "OrderToShopIsEmail":
					this.DropDownListOrderToShopIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "RegIsEmail":
					this.DropDownListMemberRegister.SelectedValue = xmlNode2.InnerText;
					break;
				case "RegIsActivationEmail":
					this.DropDownListRegIsActivationEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "ApplyOpenShopIsEmail":
					this.DropDownListApplyOpenShopIsEmail.SelectedValue = xmlNode2.InnerText;
					break;
				case "AuditOpenShopIsEmail":
					this.DropDownListAuditOpenShopIsEmail.SelectedValue = xmlNode2.InnerText;
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
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "邮件发送设置",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Service_EmailSendSetting.aspx",
				Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
			});
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
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PayIsEmail", this.DropDownListPayIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentIsEmail", this.DropDownListShipmentIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ShipmentOKIsEmail", this.DropDownListShipmentOKIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CancelOrderIsEmail", this.DropDownListCancelOrderIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderIsEmail", this.DropDownListOrderIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegIsEmail", this.DropDownListMemberRegister.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RegIsActivationEmail", this.DropDownListRegIsActivationEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ApplyOpenShopIsEmail", this.DropDownListApplyOpenShopIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/OrderToShopIsEmail", this.DropDownListOrderToShopIsEmail.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/AuditOpenShopIsEmail", this.DropDownListAuditOpenShopIsEmail.SelectedValue);
		ShopSettings.ResetShopSetting();
	}
}
