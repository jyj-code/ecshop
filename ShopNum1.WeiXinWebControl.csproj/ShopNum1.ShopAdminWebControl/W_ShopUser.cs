using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopUser : BaseShopWebControl
	{
		private string string_0 = "W_ShopUser.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Image image_0;
		private HiddenField hiddenField_0;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private Image image_1;
		private HiddenField hiddenField_1;
		public W_ShopUser()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.image_1 = (Image)skin.FindControl("ImgShopShow");
			this.hiddenField_1 = (HiddenField)skin.FindControl("hidShopShowPic");
			this.textBox_0 = (TextBox)skin.FindControl("txt_weixinName");
			this.textBox_1 = (TextBox)skin.FindControl("txt_PublicNo");
			this.image_0 = (Image)skin.FindControl("img_TwoDimensionalPic");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_TwoDimensionalPic");
			this.button_0 = (Button)skin.FindControl("Btn_OK");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidDataCheck");
			this.method_0();
		}
		private void method_0()
		{
			IShopNum1_WeiXin_ShopUser_Active shopNum1_WeiXin_ShopUser_Active = new ShopNum1_WeiXin_ShopUser_Active();
			DataTable dataTable = shopNum1_WeiXin_ShopUser_Active.SelectWeiXinHao(this.MemLoginID);
			if (dataTable.Rows.Count != 0)
			{
				this.htmlInputHidden_0.Value = "ok";
				this.textBox_0.Text = dataTable.Rows[0]["WeiXinName"].ToString();
				this.textBox_1.Text = dataTable.Rows[0]["PublicNo"].ToString();
				if (dataTable.Rows[0]["ShopPic"].ToString() != "" && dataTable.Rows[0]["ShopPic"].ToString().ToLower().IndexOf("noimg") != -1)
				{
					this.hiddenField_1.Value = dataTable.Rows[0]["ShopPic"].ToString();
					this.image_1.ImageUrl = this.hiddenField_1.Value;
				}
				if (dataTable.Rows[0]["TwoDimensionalPic"].ToString() != "" && dataTable.Rows[0]["TwoDimensionalPic"].ToString().ToLower().IndexOf("noimg") != -1)
				{
					this.hiddenField_0.Value = (this.image_0.ImageUrl = dataTable.Rows[0]["TwoDimensionalPic"].ToString());
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_WeiXin_ShopUser_Active shopNum1_WeiXin_ShopUser_Active = new ShopNum1_WeiXin_ShopUser_Active();
			ShopNum1_WeiXin_ShopUser shopNum1_WeiXin_ShopUser = new ShopNum1_WeiXin_ShopUser();
			if (this.htmlInputHidden_0.Value == "ok")
			{
				shopNum1_WeiXin_ShopUser.ShopLoginID = this.MemLoginID.ToString();
				shopNum1_WeiXin_ShopUser.WeiXinName = this.textBox_0.Text.Trim().ToString();
				shopNum1_WeiXin_ShopUser.PublicNo = this.textBox_1.Text.Trim().ToString();
				shopNum1_WeiXin_ShopUser.TwoDimensionalPic = this.hiddenField_0.Value.ToString();
				shopNum1_WeiXin_ShopUser.CreateTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_WeiXin_ShopUser.ModifyTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_WeiXin_ShopUser.ShopPic = this.hiddenField_1.Value;
				int num = shopNum1_WeiXin_ShopUser_Active.UpdateWeiXinHao(shopNum1_WeiXin_ShopUser);
				if (num > 0)
				{
					MessageBox.Show("修改成功！");
				}
				else
				{
					MessageBox.Show("修改失败！");
				}
			}
			else
			{
				shopNum1_WeiXin_ShopUser.ShopLoginID = this.MemLoginID.ToString();
				shopNum1_WeiXin_ShopUser.WeiXinName = this.textBox_0.Text.Trim().ToString();
				shopNum1_WeiXin_ShopUser.PublicNo = this.textBox_1.Text.Trim().ToString();
				shopNum1_WeiXin_ShopUser.TwoDimensionalPic = this.hiddenField_0.Value.ToString();
				shopNum1_WeiXin_ShopUser.CreateTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_WeiXin_ShopUser.ModifyTime = DateTime.Parse(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_WeiXin_ShopUser.ShopPic = this.hiddenField_1.Value;
				int num2 = shopNum1_WeiXin_ShopUser_Active.AddWeiXinHao(shopNum1_WeiXin_ShopUser);
				if (num2 > 0)
				{
					MessageBox.Show("添加成功！");
				}
			}
			this.method_0();
		}
	}
}
