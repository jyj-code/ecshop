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
	public class ShopSearch : BaseWebControl
	{
		private string string_0 = "ShopSearch.ascx";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private DropDownList dropDownList_3;
		private DropDownList dropDownList_4;
		private DropDownList dropDownList_5;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Button button_0;
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_1;
		private Label label_2;
		private TextBox textBox_2;
		private Button button_1;
		private bool bool_0 = false;
		[CompilerGenerated]
		private int int_0;
		public int PageCount
		{
			get;
			set;
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxShopName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxMemberID");
			this.label_0 = (Label)skin.FindControl("LabelShopProductName");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.dropDownList_3 = (DropDownList)skin.FindControl("DropDownListShopCategoryCode1");
			this.dropDownList_3.SelectedIndexChanged += new EventHandler(this.DropDownListShopCategoryCode1_SelectedIndexChanged);
			this.dropDownList_4 = (DropDownList)skin.FindControl("DropDownListShopCategoryCode2");
			this.dropDownList_4.SelectedIndexChanged += new EventHandler(this.DropDownListShopCategoryCode2_SelectedIndexChanged);
			this.dropDownList_5 = (DropDownList)skin.FindControl("DropDownListShopCategoryCode3");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListRegionCode1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode1_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListRegionCode2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode2_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListRegionCode3");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonFirst");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonEnd");
			this.label_1 = (Label)skin.FindControl("LabelPageIndex");
			this.label_2 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxPageNum");
			this.button_1 = (Button)skin.FindControl("ButtonGo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.button_1.Click += new EventHandler(this.button_1_Click);
			if (this.Page.IsPostBack)
			{
			}
			this.DropDownListShopCategoryCode1Bind();
			this.DropDownListRegionCode1Bind();
			if (ShopNum1.Common.Common.ReqStr("code") != "")
			{
				string text = ShopNum1.Common.Common.ReqStr("code");
				if (text.Length >= 3)
				{
					for (int i = 0; i < this.dropDownList_3.Items.Count; i++)
					{
						if (this.dropDownList_3.Items[i].Value.ToString().StartsWith(text.Substring(0, 3) + "/"))
						{
							this.dropDownList_3.SelectedValue = this.dropDownList_3.Items[i].Value.ToString();
                            //IL_383:
							this.DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
							goto IL_38B;
						}
					}
                    //goto IL_383;
				}
				IL_38B:
				if (text.Length >= 6)
				{
					for (int i = 0; i < this.dropDownList_4.Items.Count; i++)
					{
						if (this.dropDownList_4.Items[i].Value.ToString().StartsWith(text.Substring(0, 6) + "/"))
						{
							this.dropDownList_4.SelectedValue = this.dropDownList_4.Items[i].Value.ToString();
                            //IL_415:
							this.DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
							goto IL_41D;
						}
					}
                    //goto IL_415;
				}
				IL_41D:
				if (text.Length >= 9)
				{
					for (int i = 0; i < this.dropDownList_5.Items.Count; i++)
					{
						if (this.dropDownList_5.Items[i].Value.ToString().StartsWith(text.Substring(0, 9) + "/"))
						{
							this.dropDownList_5.Items[i].Selected = true;
							break;
						}
					}
				}
			}
			this.BindData();
			this.label_0.Text = ((this.GetShopCategoryName() == "-1") ? "全部" : this.GetShopCategoryName());
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)e.Item.FindControl("spanMemLoginID");
			Repeater repeater = e.Item.FindControl("RepeaterImg") as Repeater;
			Repeater repeater2 = e.Item.FindControl("RepeaterProduct") as Repeater;
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable ensureImagePathBymemberLoginID = shopNum1_ShopInfoList_Action.GetEnsureImagePathBymemberLoginID(this.htmlGenericControl_0.InnerText.Trim());
			if (ensureImagePathBymemberLoginID != null && ensureImagePathBymemberLoginID.Rows.Count > 0)
			{
				repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
				repeater.DataBind();
			}
			string value = ShopSettings.GetValue("ShopMainProductCount");
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable dataTable = shopNum1_ProuductChecked_Action.SearchProductByMemLoginID(this.htmlGenericControl_0.InnerText.Trim(), value);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				repeater2.DataSource = dataTable.DefaultView;
				repeater2.DataBind();
			}
			Image image = (Image)e.Item.FindControl("ImageReputation");
			this.hiddenField_0 = (HiddenField)e.Item.FindControl("HiddenFieldReputation");
			ShopNum1_Reputation_Action shopNum1_Reputation_Action = (ShopNum1_Reputation_Action)LogicFactory.CreateShopNum1_Reputation_Action();
			DataTable dataTable2 = shopNum1_Reputation_Action.ShopReputationSearch(this.hiddenField_0.Value.ToString(), "0", "1");
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				image.ImageUrl = "~/" + shopNum1_Reputation_Action.ShopReputationSearch(this.hiddenField_0.Value.ToString(), "0", "1").Rows[0]["Pic"].ToString();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.label_1.Text = "1";
			this.bool_0 = true;
			this.ViewState["PageData"] = null;
			this.BindData();
			this.label_0.Text = ((this.GetShopCategoryName() == "-1") ? "全部" : this.GetShopCategoryName());
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.label_1.Text = this.textBox_2.Text;
			this.BindData();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.label_1.Text = this.label_2.Text;
			this.BindData();
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.label_1.Text = (int.Parse(this.label_1.Text) + 1).ToString();
			this.BindData();
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.label_1.Text = (int.Parse(this.label_1.Text) - 1).ToString();
			this.BindData();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.label_1.Text = "1";
			this.BindData();
		}
		protected void BindData()
		{
			string regioncode = this.SetShopRegionCode();
			int num = int.Parse(this.label_1.Text);
			string shopcategoryid;
			if (this.Page.Request.QueryString["code"] != null && !this.bool_0)
			{
				shopcategoryid = this.Page.Request.QueryString["code"];
			}
			else
			{
				shopcategoryid = this.SetShopCategoryCode();
			}
			string name;
			if (this.Page.Request.QueryString["search"] != null && !this.bool_0)
			{
				name = this.Page.Server.UrlDecode(this.Page.Request.QueryString["search"]);
			}
			else
			{
				name = Operator.FilterString((this.textBox_0.Text == "") ? "-1" : this.textBox_0.Text);
			}
			string memberloginid = Operator.FilterString((this.textBox_1.Text == "") ? "-1" : this.textBox_1.Text);
			if (this.ViewState["PageData"] == null)
			{
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
				DataSet value = shopNum1_ShopInfoList_Action.SearchShopList(num.ToString(), this.PageCount.ToString(), regioncode, shopcategoryid, name, memberloginid);
				this.ViewState["PageData"] = value;
			}
			else if ((num / 10).ToString() != ((DataSet)this.ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
			{
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
				DataSet value = shopNum1_ShopInfoList_Action.SearchShopList(num.ToString(), this.PageCount.ToString(), regioncode, shopcategoryid, name, memberloginid);
				this.ViewState["PageData"] = value;
			}
			this.label_2.Text = ((((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString() == "0") ? "1" : ((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString());
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = this.PageCount;
			pagedDataSource.DataSource = ((DataSet)this.ViewState["PageData"]).Tables[0].DefaultView;
			pagedDataSource.CurrentPageIndex = (num - 1) % 10;
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
			this.linkButton_0.Enabled = true;
			this.linkButton_1.Enabled = true;
			this.linkButton_2.Enabled = true;
			this.linkButton_3.Enabled = true;
			if (num == 1)
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_1.Enabled = false;
			}
			if (num.ToString() == this.label_2.Text)
			{
				this.linkButton_2.Enabled = false;
				this.linkButton_3.Enabled = false;
			}
		}
		protected void DropDownListShopCategoryCode1Bind()
		{
			this.dropDownList_3.Items.Clear();
			this.dropDownList_3.Items.Add(new ListItem("-全部-", "-1"));
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable list = shopNum1_ShopCategory_Action.GetList("0");
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.dropDownList_3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
			this.DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
		}
		protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_4.Items.Clear();
			this.dropDownList_4.Items.Add(new ListItem("-全部-", "-1"));
			if (this.dropDownList_3.SelectedValue != "-1")
			{
				ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
				DataTable list = shopNum1_ShopCategory_Action.GetList(this.dropDownList_3.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < list.Rows.Count; i++)
				{
					this.dropDownList_4.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
		}
		protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_5.Items.Clear();
			this.dropDownList_5.Items.Add(new ListItem("-全部-", "-1"));
			if (this.dropDownList_4.SelectedValue != "-1")
			{
				ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
				DataTable list = shopNum1_ShopCategory_Action.GetList(this.dropDownList_4.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < list.Rows.Count; i++)
				{
					this.dropDownList_5.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
				}
			}
		}
		public string SetShopCategoryCode()
		{
			string result;
			if (this.dropDownList_5.SelectedValue != "-1")
			{
				result = this.dropDownList_5.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_4.SelectedValue != "-1")
			{
				result = this.dropDownList_4.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_3.SelectedValue != "-1")
			{
				result = this.dropDownList_3.SelectedValue.Split(new char[]
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
		public string GetShopCategoryName()
		{
			string result;
			if (this.dropDownList_5.SelectedValue != "-1")
			{
				result = this.dropDownList_5.SelectedItem.Text;
			}
			else if (this.dropDownList_4.SelectedValue != "-1")
			{
				result = this.dropDownList_4.SelectedItem.Text;
			}
			else if (this.dropDownList_3.SelectedValue != "-1")
			{
				result = this.dropDownList_3.SelectedItem.Text;
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		protected void DropDownListRegionCode1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-省级-", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
			}
			this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Items.Clear();
			this.dropDownList_1.Items.Add(new ListItem("-市级-", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("-县级-", "-1"));
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
		}
		public string SetShopRegionCode()
		{
			string result;
			if (this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_0.SelectedValue != "-1")
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
		public static string GetSubstr(object title, int length, bool isEllipsis)
		{
			string text = title.ToString();
			if (text.Length > length)
			{
				text = text.Substring(0, length);
			}
			if (isEllipsis)
			{
				text += "...";
			}
			return text;
		}
	}
}
