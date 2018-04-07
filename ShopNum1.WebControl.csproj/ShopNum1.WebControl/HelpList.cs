using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class HelpList : BaseWebControl
	{
		private string string_0 = "HelpList.ascx";
		private DataList dataList_0;
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private int int_0;
		public string DefaultHelp
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public HelpList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dataList_0 = (DataList)skin.FindControl("DataListHelpList");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterRemark");
			this.dataList_0.ItemDataBound += new DataListItemEventHandler(this.dataList_0_ItemDataBound);
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				string text = ShopNum1.Common.Common.ReqStr("guid");
				if (text != "0")
				{
					this.method_1(text);
				}
				else
				{
					this.method_1(this.DefaultHelp);
				}
			}
		}
		private void dataList_0_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
			DataTable dataTable = shopNum1_Help_Action.Search(hiddenField.Value, 0);
			if (e.Item.ItemIndex == 0 && dataTable.Rows.Count > 0)
			{
				this.DefaultHelp = dataTable.Rows[0]["Guid"].ToString();
			}
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterHelp");
			repeater.DataSource = dataTable.DefaultView;
			repeater.DataBind();
		}
		private void method_0()
		{
			ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
			DataTable dataTable = shopNum1_HelpType_Action.Search("0", this.ShowCount);
			this.dataList_0.DataSource = dataTable.DefaultView;
			this.dataList_0.DataBind();
		}
		private void method_1(string string_2)
		{
			ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
			DataTable dataTable = shopNum1_Help_Action.SearchRemark(string_2, 0);
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
