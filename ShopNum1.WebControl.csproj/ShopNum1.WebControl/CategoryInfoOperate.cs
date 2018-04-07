using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CategoryInfoOperate : BaseWebControl
	{
		private string string_0 = "CategoryInfoOperate.ascx";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private RadioButtonList radioButtonList_0;
		private DropDownList dropDownList_3;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HtmlInputReset htmlInputReset_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public CategoryInfoOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
			}
			this.radioButtonList_0 = (RadioButtonList)skin.FindControl("RadioButtonListType");
			this.dropDownList_3 = (DropDownList)skin.FindControl("DropDownListValidTime");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxContent");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxTel");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxEmail");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxOtherWay");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hiddenGuid");
			this.htmlInputReset_0 = (HtmlInputReset)skin.FindControl("inputReset");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListCategoryCf");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListCategoryCs");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListCategoryCt");
			Button button = (Button)skin.FindControl("ButtonBack");
			button.Click += new EventHandler(this.ButtonBack_Click);
			this.button_0.Click += new EventHandler(this.ButtonConfirm_Click);
			this.BindValidTime();
			this.BindCategoryCf();
			if (!this.Page.IsPostBack)
			{
				this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
				if (this.hiddenField_0.Value != "0")
				{
					this.GetEditInfo();
				}
			}
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			string text = this.method_0(this.dropDownList_0, this.dropDownList_1, this.dropDownList_2);
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			shopNum1_Member_Action.GetMemberQuery(this.MemLoginID);
			if (this.hiddenField_0.Value == "0")
			{
				ShopNum1_CategoryInfo shopNum1_CategoryInfo = new ShopNum1_CategoryInfo();
				shopNum1_CategoryInfo.Title = this.textBox_0.Text.Trim();
				shopNum1_CategoryInfo.Type = this.radioButtonList_0.SelectedValue;
				shopNum1_CategoryInfo.Content = this.textBox_1.Text.Replace("'", "''");
				shopNum1_CategoryInfo.Keywords = this.textBox_2.Text.Trim();
				shopNum1_CategoryInfo.ValidTime = this.GetValidTime(this.dropDownList_3.SelectedValue);
				shopNum1_CategoryInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
				shopNum1_CategoryInfo.Tel = this.textBox_3.Text;
				shopNum1_CategoryInfo.Email = this.textBox_4.Text;
				shopNum1_CategoryInfo.OtherContactWay = this.textBox_5.Text;
				shopNum1_CategoryInfo.AssociatedCategoryGuid = text;
				shopNum1_CategoryInfo.AssociatedMemberID = this.MemLoginID;
				ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
				int num = shopNum1_CategoryChecked_Action.AddCategoryInfo(shopNum1_CategoryInfo);
				if (num > 0)
				{
					MessageBox.Show("添加成功！");
					MessageBox.Show(text);
				}
			}
			else if (this.hiddenField_0.Value != "0")
			{
				ShopNum1_CategoryInfo shopNum1_CategoryInfo = new ShopNum1_CategoryInfo();
				shopNum1_CategoryInfo.Guid = new Guid(this.hiddenField_0.Value);
				MessageBox.Show(shopNum1_CategoryInfo.Guid.ToString());
				shopNum1_CategoryInfo.Title = this.textBox_0.Text.Trim();
				shopNum1_CategoryInfo.Type = this.radioButtonList_0.SelectedValue;
				shopNum1_CategoryInfo.Content = this.textBox_1.Text.Replace("'", "''");
				shopNum1_CategoryInfo.Keywords = this.textBox_2.Text.Trim();
				shopNum1_CategoryInfo.ValidTime = this.GetValidTime(this.dropDownList_3.SelectedValue);
				shopNum1_CategoryInfo.Tel = this.textBox_3.Text;
				shopNum1_CategoryInfo.Email = this.textBox_4.Text;
				shopNum1_CategoryInfo.OtherContactWay = this.textBox_5.Text;
				shopNum1_CategoryInfo.AssociatedCategoryGuid = this.ViewState["cose"].ToString();
				ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
				int num = shopNum1_CategoryChecked_Action.UpdateCategoryInfo(shopNum1_CategoryInfo);
				if (num > 0)
				{
					this.Page.Response.Redirect("CategoryInfoList.aspx");
				}
			}
		}
		public void ButtonBack_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("../CategoryCheckedList.aspx");
		}
		protected void GetEditInfo()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable dataTable = shopNum1_CategoryChecked_Action.EditCategoryInfo(this.hiddenField_0.Value.Replace("'", ""));
			string text = dataTable.Rows[0]["Code"].ToString();
			DataTable categoryByCode = shopNum1_CategoryChecked_Action.GetCategoryByCode(text.Substring(0, 3));
			this.dropDownList_0.SelectedValue = categoryByCode.Rows[0]["ID"].ToString();
			DataTable categoryByCode2 = shopNum1_CategoryChecked_Action.GetCategoryByCode(text.Substring(0, 6));
			this.dropDownList_1.Items.Add(new ListItem(categoryByCode2.Rows[0]["Name"].ToString(), categoryByCode2.Rows[0]["ID"].ToString()));
			this.dropDownList_1.SelectedValue = categoryByCode2.Rows[0]["ID"].ToString();
			DataTable categoryByCode3 = shopNum1_CategoryChecked_Action.GetCategoryByCode(text);
			this.dropDownList_2.Items.Add(new ListItem(categoryByCode3.Rows[0]["Name"].ToString(), categoryByCode3.Rows[0]["Code"].ToString()));
			this.dropDownList_2.SelectedValue = dataTable.Rows[0]["Code"].ToString();
			this.ViewState["cose"] = this.method_0(this.dropDownList_0, this.dropDownList_1, this.dropDownList_2);
			this.radioButtonList_0.SelectedValue = dataTable.Rows[0]["Type"].ToString();
			this.textBox_0.Text = dataTable.Rows[0]["Title"].ToString();
			this.textBox_1.Text = dataTable.Rows[0]["Content"].ToString();
			this.textBox_2.Text = dataTable.Rows[0]["Keywords"].ToString();
			this.textBox_3.Text = dataTable.Rows[0]["Tel"].ToString();
			this.textBox_4.Text = dataTable.Rows[0]["Email"].ToString();
			this.textBox_5.Text = dataTable.Rows[0]["OtherContactWay"].ToString();
			this.button_0.Text = "更新";
		}
		protected void BindValidTime()
		{
			this.dropDownList_3.Items.Clear();
			this.dropDownList_3.Items.Add(new ListItem("一周", "Day,7"));
			this.dropDownList_3.Items.Add(new ListItem("一个月", "Month,1"));
			this.dropDownList_3.Items.Add(new ListItem("三个月", "Month,3"));
			this.dropDownList_3.Items.Add(new ListItem("半年", "Month,6"));
			this.dropDownList_3.Items.Add(new ListItem("一年", "Year,1"));
			this.dropDownList_3.Items.Add(new ListItem("长期", "Year,100"));
		}
		protected string GetValidTime(string validTime)
		{
			string result = "";
			DateTime now = DateTime.Now;
			string[] array = validTime.Split(new char[]
			{
				','
			});
			string text = array[0];
			if (text != null)
			{
				if (!(text == "Year"))
				{
					if (!(text == "Month"))
					{
						if (text == "Day")
						{
							result = now.AddDays((double)int.Parse(array[1])).ToString("yyyy-MM-dd");
						}
					}
					else
					{
						result = now.AddMonths(int.Parse(array[1])).ToString("yyyy-MM-dd");
					}
				}
				else
				{
					result = now.AddYears(int.Parse(array[1])).ToString("yyyy-MM-dd");
				}
			}
			return result;
		}
		public void BindCategoryCf()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["ID"].ToString()));
			}
			this.dropDownList_0_SelectedIndexChanged(null, null);
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Items.Clear();
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			this.dropDownList_1.Items.Add(new ListItem("-全部-", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_0.SelectedValue);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.dropDownList_1_SelectedIndexChanged(null, null);
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("-全部-", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_1.SelectedValue);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString()));
				}
			}
		}
		private string method_0(DropDownList dropDownList_4, DropDownList dropDownList_5, DropDownList dropDownList_6)
		{
			string result;
			if (dropDownList_6.SelectedValue != "-1")
			{
				result = dropDownList_6.SelectedValue;
			}
			else if (dropDownList_5.SelectedValue != "-1")
			{
				result = dropDownList_5.SelectedValue;
			}
			else if (dropDownList_4.SelectedValue != "-1")
			{
				result = dropDownList_4.SelectedValue;
			}
			else
			{
				result = "-1";
			}
			return result;
		}
	}
}
