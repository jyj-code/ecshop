using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductImageMore : BaseWebControl
	{
		private string string_0 = "ProductImageMore.ascx";
		private Repeater repeater_0;
		private Image image_0;
		public ProductImageMore()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.image_0 = (Image)skin.FindControl("ProductBigImage");
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable productDetail = shop_Product_Action.GetProductDetail(this.Page.Request.QueryString["guid"]);
			if (productDetail.Rows.Count > 0)
			{
				string[] array = productDetail.Rows[0]["Images"].ToString().Split(new char[]
				{
					','
				});
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("imgurl", Type.GetType("string"));
				for (int i = 0; i < array.Length; i++)
				{
					if (i == 0)
					{
						this.image_0.ImageUrl = array[i];
					}
					DataRow dataRow = dataTable.NewRow();
					dataRow["imgurl"] = array[i];
				}
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
