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
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_ShipAddress : BaseMemberWebControl
	{
		private string string_0 = "A_ShipAddress.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string pageid
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public string Hid_GuidValue
		{
			get;
			set;
		}
		public A_ShipAddress()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((Common.ReqStr("PageID") == "") ? "1" : Common.ReqStr("PageID"));
			this.repeater_0 = (Repeater)skin.FindControl("rep_Address");
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.Rep_Address_ItemCommand);
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
			try
			{
				string text = string.Empty;
				if (!string.IsNullOrEmpty(this.MemLoginID))
				{
					text = text + "  AND  MemLoginID=  '" + this.MemLoginID + "'   ";
				}
				CommonPageModel commonPageModel = new CommonPageModel();
				commonPageModel.Condition = "  AND   1=1   " + text + "     AND  IsDeleted=0";
				commonPageModel.Currentpage = this.pageid.ToString();
				commonPageModel.Tablename = "ShopNum1_Address";
				commonPageModel.Resultnum = "0";
				commonPageModel.PageSize = this.PageSize.ToString();
				DataTable dataTable = shopNum1_Address_Action.SelectAddress_List(commonPageModel);
				PageList1 pageList = new PageList1();
				pageList.PageSize = Convert.ToInt32(this.PageSize);
				pageList.PageID = Convert.ToInt32(this.pageid.ToString());
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
				}
				else
				{
					pageList.RecordCount = 0;
				}
				PageListBll pageListBll = new PageListBll("main/Account/A_ShipAddress.aspx", true);
				this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
				commonPageModel.Resultnum = "1";
				DataTable dataTable2 = shopNum1_Address_Action.SelectAddress_List(commonPageModel);
				int count = dataTable2.Rows.Count;
				if (count > 0)
				{
					this.repeater_0.DataSource = dataTable2.DefaultView;
					this.repeater_0.DataBind();
				}
				else
				{
					this.repeater_1.Visible = true;
					this.repeater_0.Visible = false;
					DataTable dataTable3 = new DataTable();
					dataTable3.Columns.Add("NoValue", typeof(string));
					DataRow dataRow = dataTable3.NewRow();
					dataRow["NoValue"] = "暂无信息";
					dataTable3.Rows.Add(dataRow);
					this.repeater_1.DataSource = dataTable3;
					this.repeater_1.DataBind();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		protected void Rep_Address_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenField_Guid");
			this.Hid_GuidValue = hiddenField.Value;
			if (e.CommandName == "delete")
			{
				ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
				shopNum1_Address_Action.Delete("'" + this.Hid_GuidValue + "'");
				this.Page.Response.Redirect("A_ShipAddress.aspx");
			}
			if (e.CommandName == "defalut")
			{
				ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
				shopNum1_Address_Action.ChangeDefaultAddress(this.MemLoginID, this.Hid_GuidValue);
				this.method_0();
			}
		}
		public static string GetAddressDetil(string area, string address)
		{
			string[] array = area.Split(new char[]
			{
				'|'
			});
			string[] array2 = array[0].Split(new char[]
			{
				','
			});
			string str = string.Empty;
			if (array2.Length > 2)
			{
				str = array2[0].ToString() + array2[1].ToString() + array2[2].ToString();
			}
			else if (array2.Length > 1)
			{
				str = array2[0].ToString() + array2[1].ToString();
			}
			else if (array2.Length > 0)
			{
				str = array2[0].ToString();
			}
			return str + address;
		}
	}
}
