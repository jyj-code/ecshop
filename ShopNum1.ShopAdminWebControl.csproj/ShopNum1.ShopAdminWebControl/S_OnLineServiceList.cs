using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
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
	public class S_OnLineServiceList : BaseShopWebControl
	{
		private string string_0 = "S_OnLineServiceList.ascx";
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputCheckBox htmlInputCheckBox_0;
		private HtmlInputCheckBox htmlInputCheckBox_1;
		private HtmlInputCheckBox htmlInputCheckBox_2;
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HiddenField hiddenField_0;
		private LinkButton linkButton_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Button button_0;
		private string string_1 = string.Empty;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
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
		public string StrPath
		{
			get;
			set;
		}
		private string ShopSite
		{
			get;
			set;
		}
		public S_OnLineServiceList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_OnOff");
			this.htmlInputCheckBox_0 = (HtmlInputCheckBox)skin.FindControl("checkbox_QQ");
			this.htmlInputCheckBox_1 = (HtmlInputCheckBox)skin.FindControl("checkbox_WW");
			this.htmlInputCheckBox_2 = (HtmlInputCheckBox)skin.FindControl("checkbox_Phone");
			this.button_0 = (Button)skin.FindControl("Btn_OK");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_SelectGuid");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_PhoneOff");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkDelete");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_Phone");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			shop_OnLineService_Action.StrPath = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				text,
				"/xml/OnLineServer.xml"
			});
			this.ShopSite = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				text,
				"/Site_Settings.xml"
			});
			this.StrPath = shop_OnLineService_Action.StrPath;
			this.method_0();
			this.method_1();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			string value = this.hiddenField_0.Value;
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			if (shop_OnLineService_Action.DeleteOnLineService(value) > 0)
			{
				MessageBox.Show("删除成功！");
				this.Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			string[] array = new string[2];
			string[] array2 = new string[2];
			for (int i = 0; i < 2; i++)
			{
				array[i] = (i + 1).ToString();
				array2[i] = "0";
			}
			if (this.htmlInputCheckBox_0.Checked)
			{
				array2[0] = "1";
			}
			if (this.htmlInputCheckBox_1.Checked)
			{
				array2[1] = "1";
			}
			int num = shop_OnLineService_Action.Update(array, array2, this.StrPath, this.MemLoginID);
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath(this.ShopSite));
			DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
			if (this.htmlInputHidden_0.Value == "1")
			{
				dataRow["ShowCustomer"] = "1";
			}
			else
			{
				dataRow["ShowCustomer"] = "0";
			}
			if (this.htmlInputCheckBox_2.Checked)
			{
				dataRow["IsOpenServicePhone"] = "1";
				dataRow["ServicePhone"] = this.htmlInputText_0.Value;
			}
			else
			{
				dataRow["IsOpenServicePhone"] = "0";
			}
			dataSet.AcceptChanges();
			try
			{
				dataSet.WriteXml(this.Page.Server.MapPath(this.ShopSite));
			}
			catch
			{
				MessageBox.Show("文件读写权限不够");
				return;
			}
			if (num > 0)
			{
				MessageBox.Show("修改成功！");
			}
			else
			{
				MessageBox.Show("修改失败！");
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			HtmlInputHidden htmlInputHidden = (HtmlInputHidden)e.Item.FindControl("HiddenField_Guid");
			string value = htmlInputHidden.Value;
			if (e.CommandName == "delete")
			{
				Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
				shop_OnLineService_Action.DeleteOnLineService("'" + value + "'");
				this.Page.Response.Redirect("S_OnLineServiceList.aspx?type=1");
			}
		}
		private void method_0()
		{
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			DataTable dataTable = shop_OnLineService_Action.Search("-1", "-1", this.StrPath);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					string text = dataRow["id"].ToString() + dataRow["IsShow"].ToString();
					if (text != null)
					{
						if (!(text == "11"))
						{
							if (text == "21")
							{
								this.htmlInputCheckBox_1.Checked = true;
							}
						}
						else
						{
							this.htmlInputCheckBox_0.Checked = true;
						}
					}
				}
			}
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath(this.ShopSite));
			DataRow dataRow2 = dataSet.Tables["Setting"].Rows[0];
			this.htmlInputText_0.Value = dataRow2["ServicePhone"].ToString();
			if (dataRow2["ShowCustomer"].ToString() == "1")
			{
				this.htmlInputHidden_0.Value = "1";
			}
			else if (dataRow2["ShowCustomer"].ToString() == "0")
			{
				this.htmlInputHidden_0.Value = "0";
			}
			if (dataRow2["IsOpenServicePhone"].ToString() == "1")
			{
				this.htmlInputCheckBox_2.Checked = true;
			}
		}
		private void method_1()
		{
			Shop_OnLineService_Action shop_OnLineService_Action = (Shop_OnLineService_Action)LogicFactory.CreateShop_OnLineService_Action();
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.MemLoginID))
			{
				text = text + "  AND  MemLoginID=  '" + this.MemLoginID + "' ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = "   " + text + "  ";
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Tablename = "ShopNum1_Shop_OnlineService";
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_OnLineService_Action.SelectOnLineService_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("/Shop/ShopAdmin/S_OnLineServiceList.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_OnLineService_Action.SelectOnLineService_List(commonPageModel);
			if (dataTable2.Rows.Count > 0)
			{
				this.repeater_1.Visible = false;
				this.repeater_0.DataSource = dataTable2;
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
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
		private int method_2()
		{
			return ShopNum1.Common.Common.ReturnMaxID("OrderID", "MemLoginID", this.MemLoginID, "ShopNum1_Shop_OnlineService");
		}
	}
}
