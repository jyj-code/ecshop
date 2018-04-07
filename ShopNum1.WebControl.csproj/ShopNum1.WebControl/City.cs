using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class City : BaseWebControl
	{
		private string string_0 = "City.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private Button button_0;
		private string string_1 = "11";
		public string ShowCount
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public City()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.button_0 = (Button)skin.FindControl("ButtonEnter");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterHotCity");
			this.dropDownList_0 = (DropDownList)skin.FindControl("dropdownlistProvince");
			this.dropDownList_1 = (DropDownList)skin.FindControl("dropdownlistCity");
			this.dropDownList_2 = (DropDownList)skin.FindControl("dropdownlistArea");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterCityLetter");
			this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.method_1();
			this.BandDropDownListCity(0, this.dropDownList_0);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string addressCode = this.dropDownList_2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
			string str = string.Empty;
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopUrlByAddressCode = shopNum1_ShopInfoList_Action.GetShopUrlByAddressCode(addressCode);
			if (shopUrlByAddressCode != null && shopUrlByAddressCode.Rows.Count > 0)
			{
				str = shopUrlByAddressCode.Rows[0]["ShopUrl"].ToString();
			}
			string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			this.Page.Response.Redirect("http://" + str + str2);
		}
		private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterCityLetterChild");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldLetter");
			repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_0);
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			DataTable dataTable = shopNum1_City_Action.SearchCityByLetter(hiddenField.Value);
			repeater.DataSource = dataTable.DefaultView;
			repeater.DataBind();
		}
		private void method_0(object sender, RepeaterItemEventArgs e)
		{
			Panel panel = (Panel)e.Item.FindControl("PanelCityName");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			DataTable dataTable = shopNum1_City_Action.IsHost(hiddenField.Value);
			if (dataTable.Rows.Count > 0)
			{
				panel.Style["color"] = "red";
			}
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.dropDownList_0.SelectedValue == "-1"))
			{
				this.BandDropDownListCity(Convert.ToInt32(this.dropDownList_0.SelectedValue), this.dropDownList_1);
			}
		}
		private void method_1()
		{
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			DataTable dataTable = shopNum1_City_Action.SearchHotCity(this.string_1);
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
			DataTable dataTable2 = shopNum1_City_Action.SearchCityLetter();
			this.repeater_1.DataSource = dataTable2.DefaultView;
			this.repeater_1.DataBind();
		}
		public int BandDropDownListCity(int FatherID, DropDownList dropDownList_3)
		{
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			DataView defaultView = shopNum1_City_Action.Search(FatherID, 0).DefaultView;
			int result;
			if (defaultView.Table.Rows.Count > 0)
			{
				foreach (DataRow dataRow in defaultView.Table.Rows)
				{
					ListItem listItem = new ListItem();
					listItem.Text = dataRow["CityName"].ToString().Trim();
					listItem.Value = dataRow["ID"].ToString().Trim();
					dropDownList_3.Items.Add(listItem);
				}
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public int BandDropDownListArea(int FatherID, DropDownList dropDownList_3)
		{
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			DataView defaultView = shopNum1_City_Action.Search(FatherID, 0).DefaultView;
			int result;
			if (defaultView.Table.Rows.Count > 0)
			{
				foreach (DataRow dataRow in defaultView.Table.Rows)
				{
					ListItem listItem = new ListItem();
					listItem.Text = dataRow["CityName"].ToString().Trim();
					listItem.Value = dataRow["ID"].ToString().Trim();
					dropDownList_3.Items.Add(listItem);
				}
				result = 1;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
