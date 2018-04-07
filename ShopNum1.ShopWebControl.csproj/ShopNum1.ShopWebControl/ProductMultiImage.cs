using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductMultiImage : BaseWebControl
	{
		private string string_0 = "ProductMultiImage.ascx";
		private Repeater repeater_0;
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ProductGuid
		{
			get;
			set;
		}
		public ProductMultiImage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.string_1 = ((this.Page.Request.QueryString["guid"] == null) ? this.ProductGuid : this.Page.Request.QueryString["guid"].ToString().Replace("'", ""));
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.Bind();
		}
		protected void Bind()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable productDetail = shop_Product_Action.GetProductDetail(this.string_1);
			if (productDetail.Rows.Count > 0)
			{
				string[] array = productDetail.Rows[0]["multiimages"].ToString().Split(new char[]
				{
					','
				});
				DataTable dataTable = new DataTable();
				DataColumn dataColumn = new DataColumn();
				dataColumn.ColumnName = "imgurl";
				dataColumn.DataType = Type.GetType("System.String");
				dataTable.Columns.Add(dataColumn);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "")
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow["imgurl"] = array[i];
						dataTable.Rows.Add(dataRow);
					}
				}
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
