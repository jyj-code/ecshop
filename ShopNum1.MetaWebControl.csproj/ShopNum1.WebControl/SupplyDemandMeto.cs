using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyDemandMeto : BaseWebControl
	{
		private string string_0 = "SupplyDemandMeto.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		public SupplyDemandMeto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
			this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
			this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
			if (this.Page.IsPostBack)
			{
			}
			Shop_SupplyDemand_Action shop_SupplyDemand_Action = (Shop_SupplyDemand_Action)LogicFactory.CreateShop_SupplyDemand_Action();
			string text = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			if (text != "0")
			{
				DataTable supplyDemandMeto = shop_SupplyDemand_Action.GetSupplyDemandMeto(text);
				if (supplyDemandMeto.Rows.Count > 0)
				{
					this.literal_0.Text = "\n<title>" + supplyDemandMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
					if (supplyDemandMeto.Rows[0]["Keywords"].ToString() != string.Empty)
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + supplyDemandMeto.Rows[0]["Keywords"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					else
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + supplyDemandMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					if (supplyDemandMeto.Rows[0]["Description"].ToString() != string.Empty)
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + supplyDemandMeto.Rows[0]["Description"].ToString() + "\">\n";
					}
					else
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + supplyDemandMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
				}
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer2 = new HtmlTextWriter(stringWriter);
			this.literal_0.RenderControl(writer2);
			this.literal_1.RenderControl(writer2);
			this.literal_2.RenderControl(writer2);
			writer.Write(stringWriter.ToString());
		}
	}
}
