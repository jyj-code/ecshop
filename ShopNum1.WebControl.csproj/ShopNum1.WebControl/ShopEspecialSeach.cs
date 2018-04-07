using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
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
	public class ShopEspecialSeach : BaseWebControl
	{
		private string string_0 = "ShopEspecialSeach.ascx";
		private Repeater repeater_0;
		private Localize localize_0;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string ShopType
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public ShopEspecialSeach()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.localize_0 = (Localize)skin.FindControl("localizeTitle");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)e.Item.FindControl("spanshopid");
			Repeater repeater = e.Item.FindControl("RepeaterImg") as Repeater;
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable ensureImagePathBymemberLoginID = shopNum1_ShopInfoList_Action.GetEnsureImagePathBymemberLoginID(this.htmlGenericControl_0.InnerText.Trim());
			if (ensureImagePathBymemberLoginID != null && ensureImagePathBymemberLoginID.Rows.Count > 0)
			{
				repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
				repeater.DataBind();
			}
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable dataTable = shopNum1_ShopInfoList_Action.SearchEspecialShopList(this.ShowCount, this.ShopType);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
			if (Operator.FormatToEmpty(this.Title) != string.Empty)
			{
				this.localize_0.Text = this.Title;
			}
		}
	}
}
