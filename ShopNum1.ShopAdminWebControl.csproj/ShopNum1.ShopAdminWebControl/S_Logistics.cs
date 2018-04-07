using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Logistics : BaseShopWebControl
	{
		private string string_0 = "S_Logistics.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private HtmlInputHidden htmlInputHidden_0;
		private DataView dataView_0;
		public S_Logistics()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("HiddenShowCount");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterFeeTemplate");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (!this.Page.IsPostBack && ShopNum1.Common.Common.ReqStr("sing") != "" && ShopNum1.Common.Common.ReqStr("delid") != "")
			{
				Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
				string path = this.method_2();
				if (!shop_FeeTemplate_Action.DelByTemplateID(ShopNum1.Common.Common.ReqStr("delid"), this.Page.Server.MapPath(path)))
				{
				}
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
			string path = this.method_2();
			string empty = string.Empty;
			DataTable feesByIDRegion = shop_FeeTemplate_Action.GetFeesByIDRegion(this.Page.Server.MapPath(path), "-1", "-1", "-1", out empty);
			if (feesByIDRegion != null && feesByIDRegion.Rows.Count != 0)
			{
				int num = int.Parse(this.htmlInputHidden_0.Value);
				this.dataView_0 = new DataView(feesByIDRegion);
				PagedDataSource pagedDataSource = new PagedDataSource();
				DataTable dataTable = this.dataView_0.ToTable(true, new string[]
				{
					"templateid",
					"templatename",
					"altertime"
				});
				pagedDataSource.DataSource = dataTable.DefaultView;
				pagedDataSource.AllowPaging = true;
				if (num < 1)
				{
					pagedDataSource.PageSize = 10;
				}
				else
				{
					pagedDataSource.PageSize = num;
				}
				int num2;
				if (this.Page.Request.QueryString.Get("page") != null)
				{
					num2 = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
				}
				else
				{
					num2 = 1;
				}
				pagedDataSource.CurrentPageIndex = num2 - 1;
				Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
				this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num2);
				this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num2);
				this.hyperLink_0.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num2 - 1);
				this.hyperLink_1.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=1";
				this.hyperLink_2.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num2 + 1);
				this.hyperLink_3.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + pagedDataSource.PageCount;
				if (num2 <= 1 && pagedDataSource.PageCount <= 1)
				{
					this.hyperLink_1.NavigateUrl = "";
					this.hyperLink_0.NavigateUrl = "";
					this.hyperLink_2.NavigateUrl = "";
					this.hyperLink_3.NavigateUrl = "";
				}
				if (num2 <= 1 && pagedDataSource.PageCount > 1)
				{
					this.hyperLink_1.NavigateUrl = "";
					this.hyperLink_0.NavigateUrl = "";
				}
				if (num2 >= pagedDataSource.PageCount)
				{
					this.hyperLink_2.NavigateUrl = "";
					this.hyperLink_3.NavigateUrl = "";
				}
				this.repeater_0.DataSource = pagedDataSource;
				this.repeater_0.DataBind();
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HtmlInputHidden htmlInputHidden = (HtmlInputHidden)e.Item.FindControl("hiddenTemplateid");
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterChildFeeTemplate");
				string format = "templateid='{0}'";
				string sort = "orderid DESC";
				DataTable dataTable = this.dataView_0.Table.Select(string.Format(format, htmlInputHidden.Value), sort).CopyToDataTable<DataRow>();
				if (dataTable != null && dataTable.Rows.Count != 0)
				{
					dataTable.Columns.Add("feename", typeof(string));
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						dataTable.Rows[i]["feename"] = this.method_1(dataTable.Rows[i]["feetype"].ToString());
					}
					repeater.DataSource = dataTable;
					repeater.DataBind();
				}
			}
		}
		private string method_1(string string_1)
		{
			string result;
			if (string_1 != null)
			{
				if (string_1 == "1")
				{
					result = "平邮";
					return result;
				}
				if (string_1 == "2")
				{
					result = "快递";
					return result;
				}
				if (string_1 == "3")
				{
					result = "EMS";
					return result;
				}
			}
			result = "";
			return result;
		}
		private string method_2()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			return string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/shop",
				text,
				"/xml/PostageTemplate.xml"
			});
		}
	}
}
