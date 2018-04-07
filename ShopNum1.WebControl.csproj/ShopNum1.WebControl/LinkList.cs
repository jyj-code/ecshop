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
	public class LinkList : BaseWebControl
	{
		private string string_0 = "LinkList.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public LinkList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.BindData();
		}
		public void BindData()
		{
			ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
			DataTable link = shopNum1_Link_Action.GetLink();
			this.repeater_0.DataSource = ((this.ShowCount == 0) ? link : this.Top(link, this.ShowCount));
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
		public DataTable Top(DataTable dataTable_0, int count)
		{
			int num = (dataTable_0.Rows.Count > count) ? count : dataTable_0.Rows.Count;
			DataTable dataTable = dataTable_0.Clone();
			for (int i = 0; i < num; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < dataTable_0.Columns.Count; j++)
				{
					dataRow[j] = dataTable_0.Rows[i][j].ToString();
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
	}
}
