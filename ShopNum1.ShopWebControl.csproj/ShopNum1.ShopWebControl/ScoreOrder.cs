using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ScoreOrder : BaseWebControl
	{
		private string string_0 = "ScoreOrder.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private DropDownList dropDownList_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		public ScoreOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxNumber");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListAddress1");
			this.DropDownListAddress1Bind();
		}
		protected void DropDownListAddress1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			this.method_0("0", this.dropDownList_0);
		}
		private void method_0(string string_1, DropDownList dropDownList_1)
		{
			Shop_Category_Action shop_Category_Action = (Shop_Category_Action)LogicFactory.CreateShop_Category_Action();
			DataTable regionFatherID = shop_Category_Action.GetRegionFatherID(string_1);
			for (int i = 0; i < regionFatherID.Rows.Count; i++)
			{
				dropDownList_1.Items.Add(new ListItem(regionFatherID.Rows[i]["Name"].ToString(), regionFatherID.Rows[i]["Code"].ToString() + "/" + regionFatherID.Rows[i]["ID"].ToString()));
			}
		}
	}
}
