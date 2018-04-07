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
	public class S_ScoreProductList : BaseShopWebControl
	{
		private string string_0 = "S_ScoreProductList.ascx";
		private DropDownList dropDownList_0;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private TextBox textBox_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
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
		public S_ScoreProductList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListIsAudit");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		public static string GetProductCategoryCode(string code)
		{
			string text = string.Empty;
			if (code != "")
			{
				int length = code.Length;
				if (length > 0 && length <= 9)
				{
					int num = length / 3;
					string code2 = string.Empty;
					for (int i = 1; i <= num; i++)
					{
						code2 = code.Substring(0, 3 * i);
						ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
						DataTable dataInfoByCode = shopNum1_ScoreProductCategory_Action.GetDataInfoByCode(code2);
						if (dataInfoByCode != null && dataInfoByCode.Rows.Count > 0)
						{
							if (text == string.Empty)
							{
								text = dataInfoByCode.Rows[0]["Name"].ToString();
							}
							else
							{
								text = text + "/" + dataInfoByCode.Rows[0]["Name"].ToString();
							}
						}
					}
				}
			}
			return text;
		}
		private void method_0()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			string text = string.Empty;
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				text = text + "  AND  IsAudit=  '" + this.dropDownList_0.SelectedValue + "'   ";
			}
			if (!string.IsNullOrEmpty(this.textBox_0.Text))
			{
				text = text + "  AND  Name   LIKE   '%" + this.textBox_0.Text.Trim() + "%'   ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				"  AND   1=1   ",
				text,
				"     AND    MemLoginID='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shopNum1_Shop_ScoreProduct_Action.Select_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("Shop/ShopAdmin/S_ScoreProduct.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shopNum1_Shop_ScoreProduct_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
		public static string IsAudit(string IsAudit)
		{
			string result;
			if (IsAudit == "0")
			{
				result = "<span style=\" color:red\">未审核</span>";
			}
			else if (IsAudit == "1")
			{
				result = "审核通过";
			}
			else if (IsAudit == "2")
			{
				result = "<span style=\" color:red\">审核未通过</span>";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
