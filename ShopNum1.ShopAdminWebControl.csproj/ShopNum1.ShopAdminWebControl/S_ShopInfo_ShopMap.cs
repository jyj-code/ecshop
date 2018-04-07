using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopInfo_ShopMap : BaseShopWebControl
	{
		private string string_0 = "S_ShopInfo_ShopMap.ascx";
		private TextBox textBox_0;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		public S_ShopInfo_ShopMap()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMapValue");
			this.button_0 = (Button)skin.FindControl("ButtonSave");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hdShopName");
			this.hiddenField_1 = (HiddenField)skin.FindControl("hdShopAdress");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.BindData();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.textBox_0.Text == "")
			{
				MessageBox.Show("请点击一个地区！");
			}
			else
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				int num = shop_ShopInfo_Action.UpdateLongLat(this.textBox_0.Text.Split(new char[]
				{
					','
				})[0], this.textBox_0.Text.Split(new char[]
				{
					','
				})[1], this.MemLoginID);
				if (num > 0)
				{
					MessageBox.Show("修改成功！");
				}
				else
				{
					MessageBox.Show("修改失败！");
				}
			}
		}
		public void BindData()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopInfo = shop_ShopInfo_Action.GetShopInfo(this.MemLoginID);
			if (shopInfo != null && shopInfo.Rows.Count > 0 && shopInfo.Rows[0]["Longitude"].ToString() != "")
			{
				this.textBox_0.Text = shopInfo.Rows[0]["Longitude"].ToString() + "," + shopInfo.Rows[0]["Latitude"].ToString();
				this.hiddenField_0.Value = shopInfo.Rows[0]["ShopName"].ToString();
				this.hiddenField_1.Value = shopInfo.Rows[0]["Address"].ToString();
			}
		}
	}
}
