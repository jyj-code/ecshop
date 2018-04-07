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
	public class CategoryInfoByType : BaseWebControl
	{
		private Repeater repeater_0;
		private Repeater repeater_1;
		private string string_0 = "CategoryInfoByType.ascx";
		private bool bool_0 = false;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public int ShowCount
		{
			get;
			set;
		}
		public string Code
		{
			get;
			set;
		}
		public string CfTitle
		{
			get;
			set;
		}
		public string Href
		{
			get;
			set;
		}
		public string Release
		{
			get;
			set;
		}
		public bool IsShowRepeaterTitle
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public CategoryInfoByType()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterTitle");
			this.BindData();
		}
		public void BindData()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Href", Type.GetType("System.String"));
			dataTable.Columns.Add("CfTitle", Type.GetType("System.String"));
			dataTable.Columns.Add("Release", Type.GetType("System.String"));
			DataRow dataRow = dataTable.NewRow();
			dataRow["Href"] = this.Href;
			dataRow["CfTitle"] = this.CfTitle;
			dataRow["Release"] = this.Release;
			dataTable.Rows.Add(dataRow);
			this.repeater_1.DataSource = dataTable;
			this.repeater_1.DataBind();
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable dataSource = shopNum1_CategoryChecked_Action.SearchByType(this.Code, this.ShowCount.ToString());
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
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
