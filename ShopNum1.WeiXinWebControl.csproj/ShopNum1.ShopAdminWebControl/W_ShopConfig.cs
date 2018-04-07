using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopConfig : BaseShopWebControl
	{
		private string string_0 = "W_ShopConfig.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Image image_0;
		private HiddenField hiddenField_0;
		private Repeater repeater_0;
		public W_ShopConfig()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("txt_weixin");
			this.textBox_1 = (TextBox)skin.FindControl("txt_mobile");
			this.image_0 = (Image)skin.FindControl("img_logo");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_log");
			this.repeater_0 = (Repeater)skin.FindControl("rep_flash");
            string nameById = ShopNum1.Common.Common.GetNameById("ShopId", "shopnum1_shopinfo", string.Format(" and memloginid='{0}'", this.MemLoginID));
			IShopNum1_Weixin_ShopConfig_Active shopNum1_Weixin_ShopConfig_Active = new ShopNum1_Weixin_ShopConfig_Active();
			DataTable dataTable = shopNum1_Weixin_ShopConfig_Active.Get_Config(nameById);
			DataTable dataTable2 = dataTable.Clone();
			if (dataTable.Rows.Count != 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					switch (Convert.ToInt32(dataRow["ConfigType"]))
					{
					case 0:
						this.hiddenField_0.Value = (this.image_0.ImageUrl = dataRow["Value"].ToString());
						break;
					case 1:
						dataTable2.Rows.Add(dataRow.ItemArray);
						break;
					case 2:
						this.textBox_0.Text = dataRow["Value"].ToString();
						break;
					case 3:
						this.textBox_1.Text = dataRow["Value"].ToString();
						break;
					}
				}
				this.repeater_0.DataSource = dataTable2;
				this.repeater_0.DataBind();
			}
		}
	}
}
