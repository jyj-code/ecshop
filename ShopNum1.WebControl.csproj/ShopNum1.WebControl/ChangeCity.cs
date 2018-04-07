using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ChangeCity : BaseWebControl
	{
		private string string_0 = "ChangeCity.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private HtmlAnchor htmlAnchor_0;
		private HtmlAnchor htmlAnchor_1;
		private Repeater repeater_1;
		private Label label_1;
		private Label label_2;
		private string string_1 = "all";
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public ChangeCity()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_2 = (Label)skin.FindControl("LabelAllTotalCity");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterShowNextCity");
			this.label_1 = (Label)skin.FindControl("LabelIsEmtry");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			this.label_0 = (Label)skin.FindControl("LabelCity");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShowCity");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("allUrl");
			this.htmlAnchor_1 = (HtmlAnchor)skin.FindControl("MoreCity");
			this.htmlAnchor_0.Attributes["href"] = "http://" + ShopSettings.siteDomain;
			string str = string.Empty;
			if (this.string_1 != "all")
			{
				str = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(this.string_1);
				this.htmlAnchor_1.Attributes["href"] = "http://" + str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.')) + "/City.aspx";
			}
			else
			{
				this.htmlAnchor_1.Attributes["href"] = "http://" + ShopSettings.siteDomain + "/City.aspx";
			}
			if (!(this.string_1 == "all"))
			{
				this.label_0.Text = shopNum1_SubstationManage_Action.GetCityNameBySubstationIDNew(this.string_1);
				if (ShopSettings.GetValue("SubstationCityMode") == "1")
				{
					this.label_2.Text = this.label_0.Text;
					this.htmlAnchor_0.HRef = "http://" + str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
				}
			}
			this.GetCityData();
			this.BindNextCity();
		}
		public void GetCityData()
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable cityNameHaveOpenNew = shopNum1_SubstationManage_Action.GetCityNameHaveOpenNew(this.ShowCount, 1, 0);
			if (cityNameHaveOpenNew != null && cityNameHaveOpenNew.Rows.Count > 0)
			{
				this.repeater_0.DataSource = cityNameHaveOpenNew.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public void BindNextCity()
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			if (this.string_1 == "all")
			{
				DataTable sfDataNew = shopNum1_SubstationManage_Action.GetSfDataNew();
				if (sfDataNew != null && sfDataNew.Rows.Count > 0)
				{
					this.repeater_1.DataSource = sfDataNew.DefaultView;
					this.repeater_1.DataBind();
				}
				else
				{
					this.label_1.Visible = true;
				}
			}
			else
			{
				DataTable nextCityBySubstationIDNew = shopNum1_SubstationManage_Action.GetNextCityBySubstationIDNew(this.string_1);
				if (nextCityBySubstationIDNew != null && nextCityBySubstationIDNew.Rows.Count > 0)
				{
					this.repeater_1.DataSource = nextCityBySubstationIDNew.DefaultView;
					this.repeater_1.DataBind();
				}
				else
				{
					this.label_1.Visible = true;
				}
			}
		}
		public static string GetSubHref(string code)
		{
			string text = string.Empty;
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable substationByCityCode = shopNum1_SubstationManage_Action.GetSubstationByCityCode(code);
			if (substationByCityCode != null && substationByCityCode.Rows.Count == 1)
			{
				text = "http://" + substationByCityCode.Rows[0]["DomainName"].ToString() + "." + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
			}
			return text.Replace("..", ".");
		}
	}
}
