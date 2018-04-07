using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopVideoEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopVideoEdit.ascx";
		private Label label_0;
		private TextBox textBox_0;
		private DropDownList dropDownList_0;
		private TextBox textBox_1;
		private Panel panel_0;
		private Image image_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private Button button_0;
		private Button button_1;
		public S_ShopVideoEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListCategory");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxVideoAdd");
			this.panel_0 = (Panel)skin.FindControl("PanelShow");
			this.image_0 = (Image)skin.FindControl("InputImgPath");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxOrderID");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxKeyWords");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxDescription");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxContent");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldImgPath");
			this.textBox_2.Text = this.GetOrderID().ToString();
			this.GetShopVideoCategory();
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetDataInfo();
				this.label_0.Text = "编辑视频";
			}
			else
			{
				this.label_0.Text = "添加视频";
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopVideo.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.method_1();
			}
			else
			{
				this.method_0();
			}
		}
		public void GetDataInfo()
		{
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Video_Action();
			DataTable videoInfo = shop_Video_Action.GetVideoInfo(this.Page.Request.QueryString["guid"].ToString());
			if (videoInfo != null && videoInfo.Rows.Count > 0)
			{
				this.textBox_0.Text = videoInfo.Rows[0]["Title"].ToString();
				this.dropDownList_0.SelectedValue = videoInfo.Rows[0]["CategoryGuid"].ToString();
				this.textBox_1.Text = videoInfo.Rows[0]["VideoAdd"].ToString();
				this.image_0.ImageUrl = videoInfo.Rows[0]["ImgAdd"].ToString();
				this.hiddenField_1.Value = videoInfo.Rows[0]["ImgAdd"].ToString();
				this.textBox_2.Text = videoInfo.Rows[0]["OrderID"].ToString();
				this.textBox_3.Text = videoInfo.Rows[0]["KeyWords"].ToString();
				this.textBox_4.Text = videoInfo.Rows[0]["Description"].ToString();
				this.textBox_5.Text = videoInfo.Rows[0]["Content"].ToString();
			}
		}
		private void method_0()
		{
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo", "   AND  MemLoginID ='" + this.MemLoginID + "'  ");
				if (!string.IsNullOrEmpty(nameById))
				{
					int num = 0;
					string nameById2 = ShopNum1.Common.Common.GetNameById("MaxVedioCount", "ShopNum1_ShopRank", "   AND   Guid ='" + nameById + "'  ");
					if (!string.IsNullOrEmpty(nameById2))
					{
						num = Convert.ToInt32(nameById2);
					}
					int num2 = 0;
					string nameById3 = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Video", "   AND     MemLoginID ='" + this.MemLoginID + "'  ");
					if (!string.IsNullOrEmpty(nameById3))
					{
						num2 = Convert.ToInt32(nameById3);
					}
					if (num2 >= num)
					{
						MessageBox.Show("店铺添加视频数量已经达到最大值，如要添加更多视频，请及时升级店铺等级！");
						return;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Video_Action();
			ShopNum1_Shop_Video shopNum1_Shop_Video = new ShopNum1_Shop_Video();
			shopNum1_Shop_Video.CategoryGuid = this.dropDownList_0.SelectedValue;
			shopNum1_Shop_Video.Content = this.textBox_5.Text.Trim();
			shopNum1_Shop_Video.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_Video.CreateUser = this.MemLoginID;
			shopNum1_Shop_Video.Description = this.textBox_4.Text.Trim();
			shopNum1_Shop_Video.Guid = Guid.NewGuid();
			shopNum1_Shop_Video.ImgAdd = this.hiddenField_1.Value;
			shopNum1_Shop_Video.IsAudit = new int?(0);
			shopNum1_Shop_Video.IsRecommend = new int?(0);
			shopNum1_Shop_Video.KeyWords = this.textBox_3.Text.Trim();
			shopNum1_Shop_Video.MemLoginID = this.MemLoginID;
			shopNum1_Shop_Video.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_Video.ModifyUser = this.MemLoginID;
			shopNum1_Shop_Video.OrderID = new int?(Convert.ToInt32(this.textBox_2.Text.Trim()));
			shopNum1_Shop_Video.ShopID = this.GetShopID();
			shopNum1_Shop_Video.Title = this.textBox_0.Text.Trim();
			shopNum1_Shop_Video.VideoAdd = this.textBox_1.Text.Trim();
			shopNum1_Shop_Video.BroadcastCount = new int?(0);
			try
			{
				int num3 = shop_Video_Action.AddVideoInfo(shopNum1_Shop_Video);
				if (num3 > 0)
				{
					MessageBox.Show("添加成功！");
					this.textBox_2.Text = this.GetOrderID().ToString();
					this.dropDownList_0.SelectedValue = "-1";
					this.textBox_5.Text = "";
					this.textBox_4.Text = "";
					this.textBox_3.Text = "";
					this.textBox_0.Text = "";
					this.textBox_1.Text = "";
				}
				else
				{
					MessageBox.Show("添加失败！");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("添加失败！");
			}
		}
		private void method_1()
		{
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Video_Action();
			ShopNum1_Shop_Video shopNum1_Shop_Video = new ShopNum1_Shop_Video();
			shopNum1_Shop_Video.CategoryGuid = this.dropDownList_0.SelectedValue;
			shopNum1_Shop_Video.Content = this.textBox_5.Text.Trim();
			shopNum1_Shop_Video.Description = this.textBox_4.Text.Trim();
			shopNum1_Shop_Video.Guid = new Guid(this.Page.Request.QueryString["guid"].ToString());
			shopNum1_Shop_Video.ImgAdd = this.hiddenField_1.Value;
			shopNum1_Shop_Video.KeyWords = this.textBox_3.Text.Trim();
			shopNum1_Shop_Video.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_Video.ModifyUser = this.MemLoginID;
			shopNum1_Shop_Video.OrderID = new int?(Convert.ToInt32(this.textBox_2.Text.Trim()));
			shopNum1_Shop_Video.Title = this.textBox_0.Text.Trim();
			shopNum1_Shop_Video.VideoAdd = this.textBox_1.Text.Trim();
			try
			{
				int num = shop_Video_Action.UpdateVideoInfo(shopNum1_Shop_Video);
				if (num > 0)
				{
					MessageBox.Show("修改成功！");
					this.Page.Response.Redirect("S_ShopVideo.aspx");
				}
				else
				{
					MessageBox.Show("修改失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("修改失败！");
			}
			this.image_0.ImageUrl = this.hiddenField_1.Value;
		}
		public string GetShopID()
		{
			IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopIDByMemLoginID = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID);
			string result;
			if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
			{
				result = "";
			}
			else
			{
				result = shopIDByMemLoginID.Rows[0]["ShopID"].ToString();
			}
			return result;
		}
		public int GetOrderID()
		{
			int result = 1;
			try
			{
				Shop_Video_Action shop_Video_Action = (Shop_Video_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Video_Action();
				result = Convert.ToInt32(shop_Video_Action.GetMaxOrderID(this.MemLoginID)) + 1;
			}
			catch (Exception)
			{
				result = 1;
			}
			return result;
		}
		public void GetShopVideoCategory()
		{
			Shop_VideoCategory_Action shop_VideoCategory_Action = (Shop_VideoCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_VideoCategory_Action();
			DataTable videoCategoryList = shop_VideoCategory_Action.GetVideoCategoryList(this.MemLoginID, "1");
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			if (videoCategoryList != null && videoCategoryList.Rows.Count > 0)
			{
				foreach (DataRow dataRow in videoCategoryList.Rows)
				{
					this.dropDownList_0.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["Guid"].ToString()));
				}
			}
		}
	}
}
