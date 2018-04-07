using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ProductCategory_Operate : BaseShopWebControl
	{
		private string string_0 = "S_ProductCategory_Operate.ascx";
		protected string strSapce = "\u3000\u3000";
		protected char charSapce = '\u3000';
		private HtmlSelect htmlSelect_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputText htmlInputText_2;
		private CheckBox checkBox_0;
		private Button button_0;
		private HtmlTableRow htmlTableRow_0;
		private Label label_0;
		private Shop_ProductCategory_Action shop_ProductCategory_Action_0 = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
		private ShopNum1_Shop_ProductCategory shopNum1_Shop_ProductCategory_0 = new ShopNum1_Shop_ProductCategory();
		public S_ProductCategory_Operate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lblShopCategory");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trIv");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("selectCategory");
			this.button_0 = (Button)skin.FindControl("btnConfrim");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtKeyWord");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtDesc");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txtOrderId");
			this.checkBox_0 = (CheckBox)skin.FindControl("cbIsshow");
			this.button_0.Click += new EventHandler(this.btnConfrim_Click);
			this.method_0();
			this.method_2();
		}
		private void method_0()
		{
			this.htmlSelect_0.Items.Clear();
			ListItem listItem = new ListItem();
			listItem.Text = "顶级分类";
			listItem.Value = "0";
			this.htmlSelect_0.Items.Add(listItem);
			string a = ShopNum1.Common.Common.ReqStr("parentid");
			if (a == "")
			{
				this.htmlSelect_0.Disabled = true;
			}
			DataTable shopProductCategoryCode = this.shop_ProductCategory_Action_0.GetShopProductCategoryCode("0", this.MemLoginID);
			if (shopProductCategoryCode.Rows.Count > 0)
			{
				foreach (DataRow dataRow in shopProductCategoryCode.Rows)
				{
					ListItem listItem2 = new ListItem();
					listItem2.Text = dataRow["Name"].ToString();
					listItem2.Value = dataRow["ID"].ToString();
					this.htmlSelect_0.Items.Add(listItem2);
					if (ShopNum1.Common.Common.ReqStr("parentid") == dataRow["ID"].ToString())
					{
						this.htmlSelect_0.Disabled = true;
						this.htmlSelect_0.Items[this.htmlSelect_0.SelectedIndex].Value = ShopNum1.Common.Common.ReqStr("parentid");
						this.htmlSelect_0.Items[this.htmlSelect_0.SelectedIndex].Text = dataRow["Name"].ToString();
						this.htmlSelect_0.Items[this.htmlSelect_0.SelectedIndex].Selected = true;
					}
				}
			}
		}
		private void method_1(string string_1)
		{
			DataTable shopProductCategoryCode = this.shop_ProductCategory_Action_0.GetShopProductCategoryCode(string_1, this.MemLoginID);
			if (shopProductCategoryCode.Rows.Count > 0)
			{
				foreach (DataRow dataRow in shopProductCategoryCode.Rows)
				{
					string str = string.Empty;
					for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
					{
						str += this.strSapce;
					}
					ListItem listItem = new ListItem();
					listItem.Text = str + dataRow["Name"].ToString();
					listItem.Value = dataRow["ID"].ToString();
					this.htmlSelect_0.Items.Add(listItem);
				}
			}
		}
		protected void btnConfrim_Click(object sender, EventArgs e)
		{
			this.method_3();
		}
		private void method_2()
		{
			if (ShopNum1.Common.Common.ReqStr("id") != "" && ShopNum1.Common.Common.ReqStr("op") == "edit")
			{
				this.htmlSelect_0.Disabled = true;
				DataTable productCategoryInfoByCode = this.shop_ProductCategory_Action_0.GetProductCategoryInfoByCode(ShopNum1.Common.Common.ReqStr("id"), this.MemLoginID);
				if (productCategoryInfoByCode.Rows.Count > 0)
				{
					this.htmlInputText_0.Value = productCategoryInfoByCode.Rows[0]["name"].ToString();
					this.htmlInputText_1.Value = productCategoryInfoByCode.Rows[0]["keywords"].ToString();
					this.htmlTextArea_0.Value = productCategoryInfoByCode.Rows[0]["description"].ToString();
					this.htmlInputText_2.Value = productCategoryInfoByCode.Rows[0]["orderid"].ToString();
					if (productCategoryInfoByCode.Rows[0]["isshow"].ToString() == "1")
					{
						this.checkBox_0.Checked = true;
					}
					else
					{
						this.checkBox_0.Checked = false;
					}
				}
				this.htmlTableRow_0.Disabled = true;
				this.label_0.Text = "修改店铺商品分类";
			}
			else
			{
				this.htmlInputText_2.Value = this.shop_ProductCategory_Action_0.GetMaxID(this.MemLoginID).ToString();
				this.label_0.Text = "添加店铺商品分类";
			}
			if (ShopNum1.Common.Common.ReqStr("id") != "" && ShopNum1.Common.Common.ReqStr("op") == "add")
			{
				this.htmlTableRow_0.Disabled = true;
				this.label_0.Text = "添加店铺商品分类";
			}
		}
		private void method_3()
		{
			if (ShopNum1.Common.Common.ReqStr("op") == "add")
			{
				this.shopNum1_Shop_ProductCategory_0.Name = Operator.FilterString(this.htmlInputText_0.Value);
				this.shopNum1_Shop_ProductCategory_0.Keywords = Operator.FilterString(this.htmlInputText_1.Value);
				this.shopNum1_Shop_ProductCategory_0.Description = Operator.FilterString(this.htmlTextArea_0.Value);
				if (this.checkBox_0.Checked)
				{
					this.shopNum1_Shop_ProductCategory_0.IsShow = 1;
				}
				else
				{
					this.shopNum1_Shop_ProductCategory_0.IsShow = 0;
				}
				this.shopNum1_Shop_ProductCategory_0.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
				if (this.htmlSelect_0.Value == "0")
				{
					this.shopNum1_Shop_ProductCategory_0.CategoryLevel = 1;
				}
				else
				{
					string[] array = this.htmlSelect_0.Items[this.htmlSelect_0.SelectedIndex].Text.Split(new char[]
					{
						this.charSapce
					});
					if (array.Length > 0)
					{
						this.shopNum1_Shop_ProductCategory_0.CategoryLevel = (array.Length + 1) / 2 + 1;
						if (this.shopNum1_Shop_ProductCategory_0.CategoryLevel >= 3)
						{
							MessageBox.Show("商品分类为二级分类!");
							return;
						}
					}
					else
					{
						this.shopNum1_Shop_ProductCategory_0.CategoryLevel = 2;
					}
				}
				if (ShopNum1.Common.Common.ReqStr("id") != "")
				{
					this.shopNum1_Shop_ProductCategory_0.FatherID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("id"));
				}
				else
				{
					this.shopNum1_Shop_ProductCategory_0.FatherID = Convert.ToInt32(this.htmlSelect_0.Items[this.htmlSelect_0.SelectedIndex].Value);
				}
				this.shopNum1_Shop_ProductCategory_0.MemLoginID = this.MemLoginID;
				this.shop_ProductCategory_Action_0.Add(this.shopNum1_Shop_ProductCategory_0);
				Random random = new Random();
				this.method_2();
				MessageBox.Show("分类添加成功！");
				this.Page.Response.Redirect("S_ProductCategory.aspx?r=" + random.Next(0, 10000).ToString());
			}
			else
			{
				this.shopNum1_Shop_ProductCategory_0.ID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("id"));
				this.shopNum1_Shop_ProductCategory_0.Name = Operator.FilterString(this.htmlInputText_0.Value);
				this.shopNum1_Shop_ProductCategory_0.Keywords = Operator.FilterString(this.htmlInputText_1.Value);
				this.shopNum1_Shop_ProductCategory_0.Description = Operator.FilterString(this.htmlTextArea_0.Value);
				if (this.checkBox_0.Checked)
				{
					this.shopNum1_Shop_ProductCategory_0.IsShow = 1;
				}
				else
				{
					this.shopNum1_Shop_ProductCategory_0.IsShow = 0;
				}
				this.shopNum1_Shop_ProductCategory_0.OrderID = Convert.ToInt32(this.htmlInputText_2.Value);
				this.shopNum1_Shop_ProductCategory_0.MemLoginID = this.MemLoginID;
				this.shop_ProductCategory_Action_0.Update(this.shopNum1_Shop_ProductCategory_0);
				Random random = new Random();
				this.Page.Response.Redirect("S_ProductCategory.aspx?r=" + random.Next(0, 10000).ToString());
			}
		}
	}
}
