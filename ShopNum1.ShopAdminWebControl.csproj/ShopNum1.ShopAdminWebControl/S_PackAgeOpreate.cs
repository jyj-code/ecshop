using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_PackAgeOpreate : BaseShopWebControl
	{
		private string string_0 = "S_PackAgeOpreate.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private Button button_0;
		private string string_1 = string.Empty;
		private Repeater repeater_0;
		private Label label_0;
		public S_PackAgeOpreate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lblShopPrice");
			this.repeater_0 = (Repeater)skin.FindControl("repSp");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtSalePrice");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtDesc");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidCheckIsOpen");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidProductGuId");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidPrice");
			this.button_0 = (Button)skin.FindControl("btnSub");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidPic");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.string_1 = ShopNum1.Common.Common.ReqStr("packid");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			Shop_PackAge_Action shop_PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();
			DataSet packAgeInfo = shop_PackAge_Action.GetPackAgeInfo(this.string_1, this.MemLoginID);
			if (packAgeInfo != null)
			{
				if (packAgeInfo.Tables[0].Rows.Count > 0)
				{
					this.htmlInputText_0.Value = packAgeInfo.Tables[0].Rows[0]["name"].ToString();
					this.htmlInputText_1.Value = packAgeInfo.Tables[0].Rows[0]["SalePrice"].ToString();
					this.htmlTextArea_0.Value = packAgeInfo.Tables[0].Rows[0]["Desc"].ToString();
					this.htmlInputHidden_1.Value = packAgeInfo.Tables[0].Rows[0]["Price"].ToString();
					this.label_0.Text = packAgeInfo.Tables[0].Rows[0]["Price"].ToString();
					this.htmlInputHidden_3.Value = packAgeInfo.Tables[0].Rows[0]["Pic"].ToString();
					this.htmlInputHidden_0.Value = packAgeInfo.Tables[0].Rows[0]["state"].ToString();
				}
				this.repeater_0.DataSource = packAgeInfo.Tables[1].DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			Shop_PackAge_Action shop_PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();
			string nameById = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginID='" + this.MemLoginID + "'");
			ShopNum1_PackAge shopNum1_PackAge = new ShopNum1_PackAge();
			shopNum1_PackAge.Name = Operator.FilterString(this.htmlInputText_0.Value);
			shopNum1_PackAge.Desc = this.htmlTextArea_0.Value;
			shopNum1_PackAge.Price = new decimal?(decimal.Parse(this.htmlInputHidden_1.Value));
			shopNum1_PackAge.SalePrice = new decimal?(decimal.Parse(this.htmlInputText_1.Value));
			shopNum1_PackAge.Pic = this.htmlInputHidden_3.Value;
			shopNum1_PackAge.State = new int?(Convert.ToInt32(this.htmlInputHidden_0.Value));
			shopNum1_PackAge.MemloginId = this.MemLoginID;
			shopNum1_PackAge.ShopName = nameById;
			shopNum1_PackAge.CreateTime = new DateTime?(DateTime.Now);
			if (ShopNum1.Common.Common.ReqStr("packid") == "")
			{
				shopNum1_PackAge.Id = 0;
			}
			else
			{
				shopNum1_PackAge.Id = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("packid"));
			}
			List<ShopNum1_PackAgeRalate> list = new List<ShopNum1_PackAgeRalate>();
			if (this.htmlInputHidden_2.Value != "")
			{
				string[] array = (this.htmlInputHidden_2.Value + ",0").Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != "0")
					{
						list.Add(new ShopNum1_PackAgeRalate
						{
							ProductGuid = new Guid?(new Guid(array[i]))
						});
					}
				}
			}
			shop_PackAge_Action.OpPackAge(shopNum1_PackAge, list);
			this.Page.Response.Redirect("S_PackAgeList.aspx");
		}
	}
}
