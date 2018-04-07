using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class LinkListImage : BaseWebControl
	{
		private string string_0 = "LinkListImage.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public LinkListImage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.BindData();
		}
		public void BindData()
		{
			ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
			DataTable linkListImage = shopNum1_Link_Action.GetLinkListImage(this.ShowCount.ToString(), this.string_1);
			if (linkListImage != null && linkListImage.Rows.Count > 0)
			{
				this.repeater_0.DataSource = linkListImage.DefaultView;
				this.repeater_0.DataBind();
				HtmlImage htmlImage = (HtmlImage)this.repeater_0.Items[this.repeater_0.Items.Count - 1].FindControl("img1");
				htmlImage.Style.Add(HtmlTextWriterStyle.Margin, "0");
			}
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
		public static string LinkUrl(string string_2)
		{
			string result;
			if (string_2.ToString().Contains("http://"))
			{
				result = string_2;
			}
			else
			{
				result = GetPageName.RetDomainUrl(string_2 ?? "");
			}
			return result;
		}
	}
}
