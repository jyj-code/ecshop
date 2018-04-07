using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SubstationCity : BaseWebControl
	{
		private string string_0 = "SubstationCity.ascx";
		private Repeater repeater_0;
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		public SubstationCity()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("dropdownlistProvince");
			this.dropDownList_1 = (DropDownList)skin.FindControl("dropdownlistCity");
			this.dropDownList_2 = (DropDownList)skin.FindControl("dropdownlistArea");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCityLetter");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.BandDropDownListCity(0, this.dropDownList_0);
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterCityLetterChild");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldLetter");
				DataTable nameByLetter = shopNum1_SubstationManage_Action.GetNameByLetter(hiddenField.Value);
				if (nameByLetter != null && nameByLetter.Rows.Count > 0)
				{
					repeater.DataSource = nameByLetter.DefaultView;
					repeater.DataBind();
				}
			}
		}
		private void method_0()
		{
			string dropDownListCityCode = this.GetDropDownListCityCode();
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable letterOrderByLetter = shopNum1_SubstationManage_Action.GetLetterOrderByLetter(dropDownListCityCode);
			if (letterOrderByLetter != null && letterOrderByLetter.Rows.Count > 0)
			{
				this.repeater_0.DataSource = letterOrderByLetter.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public int BandDropDownListCity(int FatherID, DropDownList dropDownList_3)
		{
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_City_Action();
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
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_City_Action();
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
		public string GetDropDownListCityCode()
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
		private void method_1(object sender, EventArgs e)
		{
			if (!(this.dropDownList_0.SelectedValue == "-1"))
			{
				this.BandDropDownListCity(Convert.ToInt32(this.dropDownList_0.SelectedValue), this.dropDownList_1);
			}
		}
	}
}
