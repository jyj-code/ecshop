using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
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
	public class S_TerracePayList : BaseMemberWebControl
	{
		private string string_0 = "S_TerracePayList.ascx";
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
		public S_TerracePayList()
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.method_0();
		}
		public static string IsAudit(string IsAudit)
		{
			string result;
			if (IsAudit == "0")
			{
				result = "未审核";
			}
			else if (IsAudit == "1")
			{
				result = "审核通过";
			}
			else if (IsAudit == "2")
			{
				result = "审核未通过";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string BeginDate(string BeginDate)
		{
			string result;
			if (Convert.ToDateTime("1900-1-1") == Convert.ToDateTime(BeginDate))
			{
				result = "未审核";
			}
			else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(BeginDate)) <= 0)
			{
				result = "未开始";
			}
			else
			{
				result = BeginDate;
			}
			return result;
		}
		public static string EndDate(string EndDate)
		{
			string result;
			if (Convert.ToDateTime("1900-1-1") == Convert.ToDateTime(EndDate))
			{
				result = "未审核";
			}
			else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(EndDate)) > 0)
			{
				result = "已过期";
			}
			else
			{
				result = EndDate;
			}
			return result;
		}
		public static string IsCancel(string IsCancel)
		{
			string result;
			if (IsCancel == "0")
			{
				result = "未撤销";
			}
			else if (IsCancel == "1")
			{
				result = "已撤销";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetAdId(string ID, string SubstationID)
		{
			DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath = new DefaultAdvertPayOperateNoPath();
			string result;
			try
			{
				if (SubstationID == "all")
				{
					defaultAdvertPayOperateNoPath.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
				}
				else
				{
					defaultAdvertPayOperateNoPath.Path = "~/City/" + SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml";
				}
				DataTable dataTable = defaultAdvertPayOperateNoPath.SelecByID(ID);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = dataTable.Rows[0]["title"].ToString();
				}
				else
				{
					result = "";
				}
			}
			catch (Exception)
			{
				result = "分站不存在或者已被删除";
			}
			return result;
		}
		private void method_0()
		{
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = "  AND   1=1   AND   MemLoginID='" + this.MemLoginID + "'  ";
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shopNum1_AdvertPay_Action.Select_List(commonPageModel);
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
			PageListBll pageListBll = new PageListBll("Shop/ShopAdmin/S_TerracePayList.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shopNum1_AdvertPay_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
