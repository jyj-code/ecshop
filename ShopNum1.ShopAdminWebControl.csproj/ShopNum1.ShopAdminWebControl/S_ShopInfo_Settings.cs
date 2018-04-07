using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.QRCode;
using ShopNum1.QRCode.Codec;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopInfo_Settings : BaseShopWebControl
	{
		private string string_0 = "S_ShopInfo_Settings.ascx";
		private Repeater repeater_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlTextArea htmlTextArea_0;
		private HtmlTextArea htmlTextArea_1;
		private Button button_0;
		private HtmlInputText htmlInputText_5;
		private HtmlInputText htmlInputText_6;
		private HtmlInputHidden htmlInputHidden_0;
		private Button button_1;
		private Label label_0;
		private System.Web.UI.WebControls.Image image_0;
		private System.Web.UI.WebControls.Image image_1;
		private System.Web.UI.WebControls.Image image_2;
		private System.Web.UI.WebControls.Image image_3;
		private System.Web.UI.WebControls.Image image_4;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private HtmlAnchor htmlAnchor_0;
		private Label label_1;
		private string string_1;
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		protected string ShopID
		{
			get;
			set;
		}
		public string StrPath
		{
			get;
			set;
		}
		public string imageSpec
		{
			get;
			set;
		}
		public S_ShopInfo_Settings()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("currLink");
			this.label_1 = (Label)skin.FindControl("LabelCurrLink");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("TextBoxPhone");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("TextBoxTel");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldLogo");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldBackGround");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldSign");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBaoz");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("TextBoxName");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("TextBoxShopName");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("TextBoxMainGoods");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("TextBoxIdentityCard");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("TextBoxAdress");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("TextBoxMemo");
			this.htmlTextArea_1 = (HtmlTextArea)skin.FindControl("TextBoxShopIntroduce");
			this.button_0 = (Button)skin.FindControl("ButtonSave");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Area");
			this.button_1 = (Button)skin.FindControl("ButtonUpdateTwo");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.image_0 = (System.Web.UI.WebControls.Image)skin.FindControl("twoImage");
			this.image_1 = (System.Web.UI.WebControls.Image)skin.FindControl("ImageMyLogo");
			this.image_2 = (System.Web.UI.WebControls.Image)skin.FindControl("ImageBoxBackGround");
			this.image_3 = (System.Web.UI.WebControls.Image)skin.FindControl("ImageSign");
			this.image_4 = (System.Web.UI.WebControls.Image)skin.FindControl("ImageShopRank");
			this.label_0 = (Label)skin.FindControl("LabelShopRank");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("HiddenShopName");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("HiddenIdentityValue");
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			this.string_1 = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID).Rows[0]["ShopID"].ToString();
			this.string_2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			this.imageSpec = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				this.string_2.Replace("-", "/"),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				this.string_1,
				"/Site_Settings.xml"
			});
			this.StrPath = this.imageSpec;
			this.image_0.ImageUrl = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				this.string_2.Replace("-", "/"),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				this.string_1,
				"/Themes/Skin_Default/images/qrcode.png"
			});
			this.label_1.Text = this.GetUrl();
			this.htmlAnchor_0.HRef = this.GetUrl();
			this.GetBaoz();
			if (!this.Page.IsPostBack)
			{
				this.method_1();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.CreateTwoDimension();
			this.method_1();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath(this.StrPath));
			DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
			dataRow["ShopLogo"] = this.hiddenField_0.Value;
			dataRow["ShopScroll"] = this.hiddenField_1.Value;
			dataSet.AcceptChanges();
			dataSet.WriteXml(this.Page.Server.MapPath(this.StrPath));
			ShopNum1_ShopInfo shopNum1_ShopInfo = new ShopNum1_ShopInfo();
			shopNum1_ShopInfo.Name = this.htmlInputText_1.Value.Trim();
			shopNum1_ShopInfo.ShopName = this.htmlInputText_0.Value.Trim();
		 ShopNum1.Common.Common.UpdateInfo("shopname='" + shopNum1_ShopInfo.ShopName + "'", "shopnum1_shop_product", " and memloginid='" + this.MemLoginID + "'");
			shopNum1_ShopInfo.MainGoods = this.htmlInputText_2.Value.Trim();
			shopNum1_ShopInfo.Banner = this.hiddenField_2.Value;
			shopNum1_ShopInfo.IdentityCard = this.htmlInputHidden_2.Value.Trim();
			shopNum1_ShopInfo.Address = this.htmlInputText_4.Value.Trim();
			shopNum1_ShopInfo.Memo = this.htmlTextArea_0.Value.Trim();
			string pattern = "<(?!img|br|a|p|/p).*?>";
			string shopIntroduce = Regex.Replace(this.htmlTextArea_1.Value.Trim(), pattern, string.Empty, RegexOptions.IgnoreCase);
			shopNum1_ShopInfo.ShopIntroduce = shopIntroduce;
			shopNum1_ShopInfo.MemLoginID = this.MemLoginID;
			shopNum1_ShopInfo.Tel = this.htmlInputText_6.Value.Trim();
			shopNum1_ShopInfo.Phone = this.htmlInputText_5.Value.Trim();
			if (this.htmlInputHidden_0.Value.IndexOf('|') > -1)
			{
				shopNum1_ShopInfo.AddressCode = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[1];
				shopNum1_ShopInfo.AddressValue = this.htmlInputHidden_0.Value.Split(new char[]
				{
					'|'
				})[0].ToString();
			}
			try
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
				int num = shop_ShopInfo_Action.UpdateShop(shopNum1_ShopInfo);
				if (num > 0)
				{
					MessageBox.Show("店铺更新成功！");
				}
				else
				{
					MessageBox.Show("店铺更新失败！");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("店铺更新失败！");
			}
			this.method_1();
		}
		private void method_1()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable dataInfoByMemLoginID = shop_ShopInfo_Action.GetDataInfoByMemLoginID(this.MemLoginID);
			if (dataInfoByMemLoginID != null && dataInfoByMemLoginID.Rows.Count > 0)
			{
				this.htmlInputHidden_1.Value = dataInfoByMemLoginID.Rows[0]["ShopName"].ToString();
				this.htmlInputText_0.Value = dataInfoByMemLoginID.Rows[0]["ShopName"].ToString();
				this.htmlInputText_1.Value = dataInfoByMemLoginID.Rows[0]["Name"].ToString();
				this.htmlInputText_2.Value = dataInfoByMemLoginID.Rows[0]["MainGoods"].ToString();
				this.htmlInputText_3.Value = dataInfoByMemLoginID.Rows[0]["IdentityCard"].ToString();
				this.htmlInputHidden_2.Value = dataInfoByMemLoginID.Rows[0]["IdentityCard"].ToString();
				this.htmlInputText_4.Value = dataInfoByMemLoginID.Rows[0]["Address"].ToString();
				this.htmlTextArea_0.Value = dataInfoByMemLoginID.Rows[0]["Memo"].ToString();
				this.htmlTextArea_1.Value = dataInfoByMemLoginID.Rows[0]["ShopIntroduce"].ToString();
				this.htmlInputHidden_0.Value = dataInfoByMemLoginID.Rows[0]["AddressValue"].ToString() + "|" + dataInfoByMemLoginID.Rows[0]["AddressCode"].ToString();
				this.image_3.ImageUrl = dataInfoByMemLoginID.Rows[0]["Banner"].ToString();
				this.hiddenField_2.Value = dataInfoByMemLoginID.Rows[0]["Banner"].ToString();
				this.htmlInputText_5.Value = dataInfoByMemLoginID.Rows[0]["Phone"].ToString();
				this.htmlInputText_6.Value = dataInfoByMemLoginID.Rows[0]["Tel"].ToString();
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(this.imageSpec));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				this.image_1.ImageUrl = dataRow["ShopLogo"].ToString();
				this.hiddenField_0.Value = dataRow["ShopLogo"].ToString();
				this.image_2.ImageUrl = dataRow["ShopScroll"].ToString();
				this.hiddenField_1.Value = dataRow["ShopScroll"].ToString();
				Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
				DataTable shopRankByGuid = shop_Rank_Action.GetShopRankByGuid("'" + dataInfoByMemLoginID.Rows[0]["ShopRank"].ToString() + "'");
				if (shopRankByGuid != null && shopRankByGuid.Rows.Count > 0)
				{
					this.label_0.Text = shopRankByGuid.Rows[0]["Name"].ToString();
					this.image_4.ImageUrl = shopRankByGuid.Rows[0]["Pic"].ToString();
				}
			}
		}
		public void GetBaoz()
		{
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
			DataTable dataTable = shop_Ensure_Action.SearchShopEnsureListNew(this.MemLoginID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public string GetUrl()
		{
			IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopIDByMemLoginID = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID);
			string text = string.Empty;
			string text2 = string.Empty;
			if (shopIDByMemLoginID.Rows.Count > 0)
			{
				text = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
				text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			}
			string text3 = string.Empty;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "  and  MemLoginID='" + this.MemLoginID + "'  ");
				text3 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "  and   SubstationID='" + nameById + "'  ");
			}
			catch (Exception)
			{
			}
			return string.Concat(new string[]
			{
				"http://",
				text,
				".",
				text3,
				text2
			});
		}
		public void CreateTwoDimension()
		{
			string uRL = string.Empty;
			uRL = this.GetUrl();
			try
			{
				new ChartImage();
				string text = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					this.string_2.Replace("-", "/"),
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					this.string_1,
					"/Themes/Skin_Default/images"
				});
				if (!Directory.Exists(this.Page.Server.MapPath(text)))
				{
					Directory.CreateDirectory(this.Page.Server.MapPath(text));
				}
				this.CreateChartImage(text + "/qrcode.png", uRL, 230, 230);
				this.image_0.ImageUrl = text + "/qrcode.png";
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(this.StrPath));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				dataRow["TwoCode"] = this.image_0.ImageUrl;
				dataSet.AcceptChanges();
				dataSet.WriteXml(this.Page.Server.MapPath(this.StrPath));
				MessageBox.Show("生成成功！");
			}
			catch
			{
				MessageBox.Show("生成失败！");
			}
		}
		public void CreateChartImage(string saveImagePath, string URL, int Totalwidth, int Totalheight)
		{
			if (!string.IsNullOrEmpty(URL))
			{
				QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
				string a = "NUMERIC";
				if (a == "Byte")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
				}
				else if (a == "AlphaNumeric")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
				}
				else if (a == "Numeric")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
				}
				try
				{
					qRCodeEncoder.QRCodeScale = 5;
				}
				catch (Exception)
				{
					return;
				}
				try
				{
					int qRCodeVersion = (int)Convert.ToInt16(7);
					qRCodeEncoder.QRCodeVersion = qRCodeVersion;
				}
				catch (Exception)
				{
					return;
				}
				string a2 = "H";
				if (a2 == "L")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
				}
				else if (a2 == "M")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
				}
				else if (a2 == "Q")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
				}
				else if (a2 == "H")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
				}
				new MemoryStream();
				System.Drawing.Image image = qRCodeEncoder.Encode(URL, Encoding.UTF8);
				Bitmap bitmap = new Bitmap(Totalwidth, Totalheight);
				Graphics graphics = Graphics.FromImage(bitmap);
				SolidBrush solidBrush = new SolidBrush(Color.White);
				graphics.DrawImage(image, 1, 1);
				if (File.Exists(this.Page.Server.MapPath(saveImagePath)))
				{
					bitmap.Save(this.Page.Server.MapPath(saveImagePath));
					solidBrush.Dispose();
					graphics.Dispose();
					bitmap.Dispose();
				}
			}
		}
	}
}
