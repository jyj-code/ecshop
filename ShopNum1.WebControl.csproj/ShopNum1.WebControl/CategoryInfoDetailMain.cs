using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CategoryInfoDetailMain : BaseWebControl
	{
		private string string_0 = "CategoryInfoDetail.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private string string_1 = "上一篇：";
		private string string_2 = "下一篇：";
		[CompilerGenerated]
		private string string_3;
		public string Guid
		{
			get;
			set;
		}
		public string OnCategoryName
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
		public string NextCategoryName
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public CategoryInfoDetailMain()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataUpDown");
			if (this.Page.IsPostBack)
			{
			}
			this.Guid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable categoryDetails = shopNum1_CategoryChecked_Action.GetCategoryDetails(this.Guid);
			if (categoryDetails.Rows.Count > 0)
			{
				this.repeater_0.DataSource = categoryDetails.DefaultView;
				this.repeater_0.DataBind();
			}
			DataTable categoryOnAndNext = shopNum1_CategoryChecked_Action.GetCategoryOnAndNext(this.Guid, this.OnCategoryName, this.NextCategoryName);
			if (categoryOnAndNext.Rows.Count > 0)
			{
				this.repeater_1.DataSource = categoryOnAndNext.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		public static string returnType(object type)
		{
			string text = type.ToString();
			string result;
			switch (text)
			{
			case "1":
				result = "卖";
				return result;
			case "2":
				result = "买";
				return result;
			case "3":
				result = "招聘";
				return result;
			case "4":
				result = "求职";
				return result;
			case "5":
				result = "出租";
				return result;
			case "6":
				result = "求租";
				return result;
			case "7":
				result = "合租";
				return result;
			case "8":
				result = "出售";
				return result;
			case "9":
				result = "求购";
				return result;
			case "10":
				result = "女找男";
				return result;
			case "11":
				result = "男找女";
				return result;
			case "12":
				result = "性别不限";
				return result;
			case "13":
				result = "提供";
				return result;
			case "14":
				result = "需求";
				return result;
			}
			result = "无";
			return result;
		}
		public static string ShowAddress(object object_0)
		{
			string[] array = object_0.ToString().Split(new char[]
			{
				' '
			});
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text = text + array[i] + ">>";
			}
			return text.Substring(0, text.Length - 2);
		}
	}
}
