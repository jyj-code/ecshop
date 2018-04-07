using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Album_2 : BaseShopWebControl
	{
		private string string_0 = "S_Album_2.ascx";
		private Button button_0;
		private HtmlSelect htmlSelect_0;
		private string string_1 = string.Empty;
		private HiddenField hiddenField_0;
		private RadioButtonList radioButtonList_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlImage htmlImage_0;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private string string_2;
		public S_Album_2()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidPath");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidSelectFont");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidCheck");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidImg_potisiton");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidTxt_potisiton");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("imgsrc");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtFontSize");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtFontTxt");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txtColor");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txtImageWaterMarkClarity");
			this.radioButtonList_0 = (RadioButtonList)skin.FindControl("RadioButtonListIfSetWaterMark");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenAlbumPic");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("selectfont");
			this.string_1 = "";
			this.button_0 = (Button)skin.FindControl("btnSave");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			try
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(this.htmlInputHidden_3.Value));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				dataRow["IfSetWaterMark"] = this.htmlInputHidden_2.Value;
				try
				{
					string text = this.hiddenField_0.Value + "_60x60.jpg";
					int num = ImageOperator.CreateThumbnailAutoAlbum(HttpContext.Current.Server.MapPath(this.hiddenField_0.Value), HttpContext.Current.Server.MapPath(text), 60, 60);
					if (num != 0)
					{
						dataRow["WaterMarkOriginalImge"] = text;
					}
					else
					{
						dataRow["WaterMarkOriginalImge"] = this.hiddenField_0.Value;
					}
					this.htmlImage_0.Src = dataRow["WaterMarkOriginalImge"].ToString();
				}
				catch
				{
				}
				dataRow["WaterMarkImagePosition"] = this.htmlInputHidden_0.Value;
				dataRow["ImageWaterMarkClarity"] = this.htmlInputText_3.Value;
				dataRow["WaterMarkWords"] = this.htmlInputText_1.Value;
				dataRow["WaterMarkWordsFont"] = this.htmlInputHidden_4.Value;
				dataRow["WaterMarkWordsFontSize"] = this.htmlInputText_0.Value;
				dataRow["WaterMarkWordsColor"] = this.htmlInputText_2.Value;
				dataRow["WordsWaterMarkPosition"] = this.htmlInputHidden_1.Value;
				dataSet.AcceptChanges();
				dataSet.WriteXml(this.Page.Server.MapPath(this.htmlInputHidden_3.Value));
				this.method_0();
				MessageBox.Show("修改成功！");
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message);
			}
		}
		private void method_0()
		{
			try
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
				if (memLoginInfo != null && memLoginInfo.Rows.Count > 0 && this.htmlInputHidden_3.Value == "")
				{
					string text = memLoginInfo.Rows[0]["ShopID"].ToString();
					string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
					new XmlDataSource();
					string text3 = string.Concat(new string[]
					{
						"/Shop/Shop/",
						text2.Replace("-", "/"),
						"/shop",
						text,
						"/Site_Settings.xml"
					});
					this.string_2 = text3;
					this.htmlInputHidden_3.Value = this.string_2;
				}
				if (this.htmlInputHidden_3.Value != "")
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(this.Page.Server.MapPath(this.htmlInputHidden_3.Value));
					DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
					this.htmlInputHidden_2.Value = dataRow["IfSetWaterMark"].ToString();
					this.htmlImage_0.Src = dataRow["WaterMarkOriginalImge"].ToString();
					this.hiddenField_0.Value = dataRow["WaterMarkOriginalImge"].ToString();
					this.htmlInputHidden_0.Value = dataRow["WaterMarkImagePosition"].ToString();
					this.htmlInputText_3.Value = dataRow["ImageWaterMarkClarity"].ToString();
					this.htmlInputText_1.Value = dataRow["WaterMarkWords"].ToString();
					this.htmlInputText_0.Value = dataRow["WaterMarkWordsFontSize"].ToString();
					this.htmlInputText_2.Value = dataRow["WaterMarkWordsColor"].ToString();
					this.htmlInputHidden_1.Value = dataRow["WordsWaterMarkPosition"].ToString();
					this.htmlInputHidden_4.Value = dataRow["WaterMarkWordsFont"].ToString();
					ArrayList arrayList = WaterMarkFont.Font();
					for (int i = 0; i < arrayList.Count; i++)
					{
						this.htmlSelect_0.Items.Add(arrayList[i].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message);
			}
		}
	}
}
