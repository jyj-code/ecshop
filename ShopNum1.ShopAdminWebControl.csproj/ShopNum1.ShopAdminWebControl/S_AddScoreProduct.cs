using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_AddScoreProduct : BaseShopWebControl
	{
		private string string_0 = "S_AddScoreProduct.ascx";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private TextBox textBox_0;
		private CheckBox checkBox_0;
		private CheckBox checkBox_1;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private HtmlTextArea htmlTextArea_0;
		private TextBox textBox_6;
		private TextBox textBox_7;
		private TextBox textBox_8;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HtmlImage htmlImage_0;
		[CompilerGenerated]
		private string string_1;
		public string ShopRank
		{
			get;
			set;
		}
		public S_AddScoreProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListProductCategoryCode1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListProductCategoryCode2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListProductCategoryCode3");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsNew");
			this.checkBox_1 = (CheckBox)skin.FindControl("CheckBoxIsHot");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxProductNum");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxUnitName");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxRepertoryCount");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxMarketPrice");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxIntegral");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("FCKeditorDetail");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_7 = (TextBox)skin.FindControl("TextBoxDescription");
			this.textBox_8 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.button_0 = (Button)skin.FindControl("ButtonAdd");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldProduct");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("ImgOrganizImg");
			this.DropDownListProductCategoryCode1Bind();
			if (this.Page.Request.QueryString["guid"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["guid"].ToString()))
			{
				this.button_0.Text = "编辑商品";
				this.GetEditInfo();
			}
			else
			{
				this.button_0.Text = "上架商品";
			}
		}
		public void GetEditInfo()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			DataTable infoByGuid = shopNum1_Shop_ScoreProduct_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				string text = infoByGuid.Rows[0]["ProductCategoryCode"].ToString();
				if (text.Length >= 3)
				{
					for (int i = 0; i < this.dropDownList_0.Items.Count; i++)
					{
						if (this.dropDownList_0.Items[i].Value.ToString().StartsWith(text.Substring(0, 3) + "/"))
						{
							this.dropDownList_0.SelectedValue = this.dropDownList_0.Items[i].Value.ToString();
						}
					}
					this.dropDownList_0_SelectedIndexChanged(null, null);
				}
				if (text.Length >= 6)
				{
					for (int i = 0; i < this.dropDownList_1.Items.Count; i++)
					{
						if (this.dropDownList_1.Items[i].Value.ToString().StartsWith(text.Substring(0, 6) + "/"))
						{
							this.dropDownList_1.SelectedValue = this.dropDownList_1.Items[i].Value.ToString();
						}
					}
					this.dropDownList_1_SelectedIndexChanged(null, null);
				}
				if (text.Length >= 9)
				{
					for (int i = 0; i < this.dropDownList_2.Items.Count; i++)
					{
						if (this.dropDownList_2.Items[i].Value.ToString().StartsWith(text.Substring(0, 9) + "/"))
						{
							this.dropDownList_2.SelectedValue = this.dropDownList_2.Items[i].Value.ToString();
						}
					}
				}
				if (!this.Page.IsPostBack)
				{
					this.ViewState["ProductCategoryID"] = this.GetDropDownListProductCategoryID();
				}
				this.textBox_0.Text = infoByGuid.Rows[0]["Name"].ToString();
				if (infoByGuid.Rows[0]["IsNew"].ToString() == "1")
				{
					this.checkBox_0.Checked = true;
				}
				else
				{
					this.checkBox_0.Checked = false;
				}
				if (infoByGuid.Rows[0]["IsHot"].ToString() == "1")
				{
					this.checkBox_1.Checked = true;
				}
				else
				{
					this.checkBox_1.Checked = false;
				}
				this.textBox_1.Text = infoByGuid.Rows[0]["RepertoryNumber"].ToString();
				this.textBox_2.Text = infoByGuid.Rows[0]["UnitName"].ToString();
				this.textBox_3.Text = infoByGuid.Rows[0]["RepertoryCount"].ToString();
				this.textBox_4.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
				this.textBox_5.Text = infoByGuid.Rows[0]["Score"].ToString();
				this.htmlTextArea_0.Value = infoByGuid.Rows[0]["Detail"].ToString();
				this.hiddenField_0.Value = infoByGuid.Rows[0]["OriginalImge"].ToString();
				this.textBox_6.Text = infoByGuid.Rows[0]["Meto_Title"].ToString();
				this.textBox_8.Text = infoByGuid.Rows[0]["Meto_Keywords"].ToString();
				this.textBox_7.Text = infoByGuid.Rows[0]["Meto_Description"].ToString();
				this.htmlImage_0.Src = infoByGuid.Rows[0]["OriginalImge"].ToString();
				this.textBox_4.Text = infoByGuid.Rows[0]["MarketPrice"].ToString();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (!this.CheckNumber(this.textBox_3.Text.Trim(), "int"))
			{
				MessageBox.Show("库存必须为整数,请填写正确格式！");
			}
			else if (!this.CheckNumber(this.textBox_4.Text.Trim(), "Decimal"))
			{
				MessageBox.Show("市场价格式错误，请填写正确格式！");
			}
			else if (!this.CheckNumber(this.textBox_5.Text.Trim(), "int"))
			{
				MessageBox.Show("兑换积分必须为整数，请填写正确格式！");
			}
			else if (this.Page.Request.QueryString["guid"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["guid"].ToString()))
			{
				this.Edit();
			}
			else
			{
				try
				{
					this.Add();
				}
				catch (Exception)
				{
				}
			}
		}
		public void Add()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			ShopNum1_Shop_ScoreProduct shopNum1_Shop_ScoreProduct = new ShopNum1_Shop_ScoreProduct();
			shopNum1_Shop_ScoreProduct.Brief = this.textBox_8.Text.Trim();
			shopNum1_Shop_ScoreProduct.ClickCount = new int?(0);
			shopNum1_Shop_ScoreProduct.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_ScoreProduct.CreateUser = this.MemLoginID;
			shopNum1_Shop_ScoreProduct.Detail = this.htmlTextArea_0.Value.Replace("'", "");
			shopNum1_Shop_ScoreProduct.Guid = new Guid?(Guid.NewGuid());
			shopNum1_Shop_ScoreProduct.IsAudit = new byte?(0);
			shopNum1_Shop_ScoreProduct.IsDeleted = new int?(0);
			if (this.checkBox_1.Checked)
			{
				shopNum1_Shop_ScoreProduct.IsHot = new byte?(1);
			}
			else
			{
				shopNum1_Shop_ScoreProduct.IsHot = new byte?(0);
			}
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_ScoreProduct.IsNew = new byte?(1);
			}
			else
			{
				shopNum1_Shop_ScoreProduct.IsNew = new byte?(0);
			}
			shopNum1_Shop_ScoreProduct.IsRecommend = new byte?(0);
			shopNum1_Shop_ScoreProduct.IsSaled = new int?(1);
			shopNum1_Shop_ScoreProduct.MemLoginID = this.MemLoginID;
			shopNum1_Shop_ScoreProduct.Meto_Description = this.textBox_7.Text.Trim();
			shopNum1_Shop_ScoreProduct.Meto_Keywords = this.textBox_8.Text.Trim();
			shopNum1_Shop_ScoreProduct.Meto_Title = this.textBox_6.Text.Trim();
			shopNum1_Shop_ScoreProduct.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_ScoreProduct.ModifyUser = this.MemLoginID;
			shopNum1_Shop_ScoreProduct.Name = this.textBox_0.Text.Trim();
			shopNum1_Shop_ScoreProduct.OrderID = new int?(this.GetMaxOrderID());
			shopNum1_Shop_ScoreProduct.OriginalImge = this.hiddenField_0.Value;
			shopNum1_Shop_ScoreProduct.ProductCategoryCode = this.GetDropDownListProductCategoryCode();
			shopNum1_Shop_ScoreProduct.ProductCategoryID = new int?(Convert.ToInt32(this.GetDropDownListProductCategoryID()));
			shopNum1_Shop_ScoreProduct.ProductCategoryName = this.GetDropDownListProductCategoryName();
			shopNum1_Shop_ScoreProduct.RepertoryCount = new int?(Convert.ToInt32(this.textBox_3.Text.Trim()));
			shopNum1_Shop_ScoreProduct.RepertoryNumber = this.textBox_1.Text.Trim();
			shopNum1_Shop_ScoreProduct.RepertoryWarnCount = new int?(0);
			shopNum1_Shop_ScoreProduct.SaleTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_ScoreProduct.Score = new int?(Convert.ToInt32(this.textBox_5.Text.Trim()));
			shopNum1_Shop_ScoreProduct.ShopID = "";
			shopNum1_Shop_ScoreProduct.SmallImage = "";
			shopNum1_Shop_ScoreProduct.ThumbImage = "";
			shopNum1_Shop_ScoreProduct.UnitName = this.textBox_2.Text.Trim();
			shopNum1_Shop_ScoreProduct.Weight = new decimal?(0m);
			string substationID = string.Empty;
			try
			{
				substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'   ");
			}
			catch (Exception)
			{
			}
			shopNum1_Shop_ScoreProduct.SubstationID = substationID;
			shopNum1_Shop_ScoreProduct.MarketPrice = new decimal?(Convert.ToDecimal(this.textBox_4.Text.Trim()));
			shopNum1_Shop_ScoreProduct.HaveSale = new int?(0);
			try
			{
				int num = shopNum1_Shop_ScoreProduct_Action.Add(shopNum1_Shop_ScoreProduct);
				if (num > 0)
				{
					MessageBox.Show("积分商品添加成功");
					this.ClearControl();
				}
			}
			catch (Exception)
			{
			}
		}
		public void Edit()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			ShopNum1_Shop_ScoreProduct shopNum1_Shop_ScoreProduct = new ShopNum1_Shop_ScoreProduct();
			shopNum1_Shop_ScoreProduct.Brief = "";
			shopNum1_Shop_ScoreProduct.Detail = this.htmlTextArea_0.Value.Replace("'", "");
			if (this.checkBox_1.Checked)
			{
				shopNum1_Shop_ScoreProduct.IsHot = new byte?(1);
			}
			else
			{
				shopNum1_Shop_ScoreProduct.IsHot = new byte?(0);
			}
			if (this.checkBox_0.Checked)
			{
				shopNum1_Shop_ScoreProduct.IsNew = new byte?(1);
			}
			else
			{
				shopNum1_Shop_ScoreProduct.IsNew = new byte?(0);
			}
			shopNum1_Shop_ScoreProduct.MarketPrice = new decimal?(Convert.ToDecimal(this.textBox_4.Text.Trim()));
			shopNum1_Shop_ScoreProduct.Meto_Description = this.textBox_7.Text.Trim();
			shopNum1_Shop_ScoreProduct.Meto_Keywords = this.textBox_8.Text.Trim();
			shopNum1_Shop_ScoreProduct.Meto_Title = this.textBox_6.Text.Trim();
			shopNum1_Shop_ScoreProduct.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_ScoreProduct.ModifyUser = this.MemLoginID;
			shopNum1_Shop_ScoreProduct.Name = this.textBox_0.Text.Trim();
			shopNum1_Shop_ScoreProduct.OriginalImge = this.hiddenField_0.Value;
			shopNum1_Shop_ScoreProduct.ProductCategoryCode = this.GetDropDownListProductCategoryCode();
			shopNum1_Shop_ScoreProduct.ProductCategoryID = new int?(Convert.ToInt32(this.GetDropDownListProductCategoryID()));
			shopNum1_Shop_ScoreProduct.ProductCategoryName = this.GetDropDownListProductCategoryName();
			shopNum1_Shop_ScoreProduct.RepertoryCount = new int?(Convert.ToInt32(this.textBox_3.Text.Trim()));
			shopNum1_Shop_ScoreProduct.RepertoryNumber = this.textBox_1.Text.Trim();
			shopNum1_Shop_ScoreProduct.Score = new int?(Convert.ToInt32(this.textBox_5.Text.Trim()));
			shopNum1_Shop_ScoreProduct.SmallImage = "";
			shopNum1_Shop_ScoreProduct.ThumbImage = "";
			shopNum1_Shop_ScoreProduct.UnitName = this.textBox_2.Text.Trim();
			shopNum1_Shop_ScoreProduct.Weight = new decimal?(0m);
			shopNum1_Shop_ScoreProduct.Guid = new Guid?(new Guid(this.Page.Request.QueryString["guid"].ToString()));
			try
			{
				int num = shopNum1_Shop_ScoreProduct_Action.Update(shopNum1_Shop_ScoreProduct);
				if (num > 0)
				{
					MessageBox.Show("积分商品更新成功");
					this.GetEditInfo();
				}
				else
				{
					MessageBox.Show("积分商品更新失败");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("积分商品更新失败");
			}
		}
		public void ClearControl()
		{
			this.dropDownList_0.SelectedValue = "-1";
			this.dropDownList_1.Visible = false;
			this.dropDownList_2.Visible = false;
			this.textBox_0.Text = "";
			this.textBox_1.Text = "";
			this.textBox_2.Text = "";
			this.textBox_3.Text = "";
			this.textBox_4.Text = "";
			this.textBox_5.Text = "";
			this.htmlTextArea_0.Value = "";
			this.textBox_6.Text = "";
			this.textBox_8.Text = "";
			this.textBox_7.Text = "";
		}
		public bool CheckNumber(string value, string valueType)
		{
			bool result;
			if (valueType != null)
			{
				if (valueType == "int")
				{
					int num = 0;
					result = int.TryParse(value, out num);
					return result;
				}
				if (valueType == "Decimal")
				{
					decimal num2 = 0m;
					result = decimal.TryParse(value, out num2);
					return result;
				}
			}
			result = false;
			return result;
		}
		public string GetDropDownListProductCategoryCode()
		{
			string result;
			if (this.dropDownList_2.Visible && this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_1.Visible && this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_0.Visible && this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public string GetDropDownListProductCategoryID()
		{
			string result;
			if (this.dropDownList_2.Visible && this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (this.dropDownList_1.Visible && this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (this.dropDownList_0.Visible && this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public string GetDropDownListProductCategoryName()
		{
			string result;
			if (this.dropDownList_2.Visible && this.dropDownList_2.SelectedValue != "-1")
			{
				result = string.Concat(new string[]
				{
					this.dropDownList_0.SelectedItem.Text,
					"/",
					this.dropDownList_1.SelectedItem.Text,
					"/",
					this.dropDownList_2.SelectedItem.Text
				});
			}
			else if (this.dropDownList_1.Visible && this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedItem.Text + "/" + this.dropDownList_1.SelectedItem.Text;
			}
			else if (this.dropDownList_0.Visible && this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedItem.Text;
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public int GetMaxOrderID()
		{
			int result;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("Max(OrderID)", "ShopNum1_Shop_ScoreProduct", " and  1=1");
				if (!string.IsNullOrEmpty(nameById))
				{
					result = Convert.ToInt32(nameById) + 1;
					return result;
				}
			}
			catch (Exception)
			{
				result = 0;
				return result;
			}
			result = 0;
			return result;
		}
		protected void DropDownListProductCategoryCode1Bind()
		{
			this.dropDownList_1.Visible = false;
			this.dropDownList_2.Visible = false;
			this.method_0("0", this.dropDownList_0);
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Visible = false;
			this.dropDownList_2.Visible = false;
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				this.method_0(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1], this.dropDownList_1);
			}
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Visible = false;
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				this.method_0(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1], this.dropDownList_2);
			}
		}
		private void method_0(string string_2, DropDownList dropDownList_3)
		{
			ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
			DataTable category = shopNum1_ScoreProductCategory_Action.GetCategory(string_2);
			dropDownList_3.Visible = true;
			dropDownList_3.Items.Clear();
			dropDownList_3.Items.Add(new ListItem("-请选择-", "-1"));
			if (category != null && category.Rows.Count > 0)
			{
				for (int i = 0; i < category.Rows.Count; i++)
				{
					dropDownList_3.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(), category.Rows[i]["Code"].ToString() + "/" + category.Rows[i]["ID"].ToString()));
				}
			}
			else
			{
				dropDownList_3.Visible = false;
			}
		}
	}
}
