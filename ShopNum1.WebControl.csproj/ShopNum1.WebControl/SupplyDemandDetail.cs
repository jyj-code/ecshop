using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyDemandDetail : BaseWebControl
	{
		private Repeater repeater_0;
		private Repeater repeater_1;
		private string string_0 = "SupplyDemandDetail.ascx";
		private string string_1 = "上一篇：";
		private string string_2 = "下一篇：";
		[CompilerGenerated]
		private string string_3;
		public string Guid
		{
			get;
			set;
		}
		public string OnSupplyDemandName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string NextSupplyDemandName
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public SupplyDemandDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataUpDown");
			if (this.Page.IsPostBack)
			{
			}
			this.Guid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.Bind();
			string nameById = ShopNum1.Common.Common.GetNameById("IsAudit", "ShopNum1_SupplyDemand", "  AND  ID='" + this.Page.Request.QueryString["guid"].ToString() + "'   ");
			string nameById2 = ShopNum1.Common.Common.GetNameById("MemberID", "ShopNum1_SupplyDemand", "  AND  ID='" + this.Page.Request.QueryString["guid"].ToString() + "'   ");
			string b = string.Empty;
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				b = httpCookie.Values["MemLoginID"].ToString();
			}
			if (nameById != "3" && nameById2 != b)
			{
				this.Page.Response.Redirect("http://" + ShopSettings.siteDomain);
			}
		}
		public void Bind()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable supplyDemandDetail = shopNum1_SupplyDemandCheck_Action.GetSupplyDemandDetail(this.Guid);
			if (supplyDemandDetail.Rows.Count > 0)
			{
				this.repeater_0.DataSource = supplyDemandDetail.DefaultView;
				this.repeater_0.DataBind();
			}
			DataTable supplyDemandDetailOnAndNext = shopNum1_SupplyDemandCheck_Action.GetSupplyDemandDetailOnAndNext(this.Guid, this.OnSupplyDemandName, this.NextSupplyDemandName);
			if (supplyDemandDetailOnAndNext.Rows.Count > 0)
			{
				this.repeater_1.DataSource = supplyDemandDetailOnAndNext.DefaultView;
				this.repeater_1.DataBind();
			}
		}
	}
}
