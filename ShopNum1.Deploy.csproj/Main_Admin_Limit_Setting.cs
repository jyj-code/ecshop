using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Main_Admin_Limit_Setting : PageBase, IRequiresSessionState
{
	protected HtmlInputText txtMoney;
	protected HtmlInputText txtMonthActivity;
	protected HtmlInputText txtGoodsCount;
	protected Button btnSub;
	protected Label lblMsg;
	protected HtmlInputHidden HiddenFieldXmlPath;
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
			this.method_5();
		}
	}
	private void method_5()
	{
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				if (name != null)
				{
					if (!(name == "Limit_Money"))
					{
						if (!(name == "Limit_ActivityCount"))
						{
							if (name == "Limit_GoodsCount")
							{
								this.txtGoodsCount.Value = xmlNode2.InnerText;
							}
						}
						else
						{
							this.txtMonthActivity.Value = xmlNode2.InnerText;
						}
					}
					else
					{
						this.txtMoney.Value = xmlNode2.InnerText;
					}
				}
			}
		}
	}
	protected void btnSub_Click(object sender, EventArgs e)
	{
		this.lblMsg.Visible = true;
		try
		{
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Limit_Money", this.txtMoney.Value);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Limit_ActivityCount", this.txtMonthActivity.Value);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Limit_GoodsCount", this.txtGoodsCount.Value);
			ShopSettings.ResetShopSetting();
			this.lblMsg.Text = "操作成功！";
		}
		catch (Exception ex)
		{
			this.lblMsg.Text = ex.Message;
		}
	}
}
