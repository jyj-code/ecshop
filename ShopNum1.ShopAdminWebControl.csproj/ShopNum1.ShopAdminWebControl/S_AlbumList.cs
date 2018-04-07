using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_AlbumList : BaseShopWebControl
	{
		private string string_0 = "S_AlbumList.ascx";
		public static DataTable dt_Album_List = null;
		private string string_1 = null;
		private string string_2 = null;
		private string string_3 = null;
		private string string_4 = null;
		public static string pageDiv;
		public static string typeName;
		private HtmlInputHidden htmlInputHidden_0;
		private LinkButton linkButton_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_AlbumList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidArryId");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidPath");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkDel_Select");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.string_1 = ShopNum1.Common.Common.ReqStr("sort");
			this.string_3 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("name"));
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.string_4 = ShopNum1.Common.Common.ReqStr("typeid");
			if (!this.Page.IsPostBack)
			{
				this.method_1();
				this.method_0();
				this.htmlInputHidden_0.Value = this.MemLoginID;
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("act") == "del" && ShopNum1.Common.Common.ReqStr("Imgpath") != "" && ShopNum1.Common.Common.ReqStr("id") != "" && ShopNum1.Common.Common.ReqStr("sign") == "del")
			{
				List<ShopNum1_Shop_Image> list = new List<ShopNum1_Shop_Image>();
				Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
				list.Add(new ShopNum1_Shop_Image
				{
					Id = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("id"))
				});
				try
				{
					string text = HttpContext.Current.Server.MapPath(ShopNum1.Common.Common.ReqStr("Imgpath").Replace("-", "/"));
					if (File.Exists(text))
					{
						File.Delete(text);
						string path = text + "_25x25.jpg";
						File.Delete(path);
						string path2 = text + "_60x60.jpg";
						File.Delete(path2);
						string path3 = text + "_100x100.jpg";
						File.Delete(path3);
						string path4 = text + "_160x160.jpg";
						File.Delete(path4);
						string path5 = text + "_300x300.jpg";
						File.Delete(path5);
					}
				}
				catch
				{
				}
				int num = shop_Image_Action.DeleteSelectImg(list);
				if (num > 0)
				{
					MessageBox.Show("您成功删除该图片!");
					this.Page.Response.Redirect("/shop/ShopAdmin/S_AlbumList.aspx?typeid=" + ShopNum1.Common.Common.ReqStr("typeid"));
				}
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			List<ShopNum1_Shop_Image> list = new List<ShopNum1_Shop_Image>();
			Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
			string[] array = this.htmlInputHidden_1.Value.Split(new char[]
			{
				','
			});
			string[] array2 = this.htmlInputHidden_2.Value.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(new ShopNum1_Shop_Image
				{
					Id = Convert.ToInt32(array[i])
				});
				try
				{
					string path = HttpContext.Current.Server.MapPath(array2[i]);
					if (File.Exists(path))
					{
						File.Delete(path);
					}
				}
				catch
				{
				}
			}
			int num = shop_Image_Action.DeleteSelectImg(list);
			if (num > 0)
			{
				MessageBox.Show("您成功删除" + array.Length + "张图片!");
				this.method_1();
			}
			else
			{
				MessageBox.Show("删除失败!");
			}
		}
		private void method_1()
		{
			int num = Convert.ToInt32(this.string_2);
			Shop_ImageCategory_Action shop_ImageCategory_Action = (Shop_ImageCategory_Action)LogicFactory.CreateShop_ImageCategory_Action();
			Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
			S_AlbumList.typeName = shop_ImageCategory_Action.Get_TypeName(this.string_4);
			DataTable dataTable = shop_Image_Action.Select_List(this.PageSize, num, 0, this.string_3, this.string_1, this.string_4, this.MemLoginID);
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = num;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (num > pageList.PageCount)
			{
				num = pageList.PageCount;
			}
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_AlbumList.aspx", true);
			S_AlbumList.pageDiv = pageListBll.GetPageListNew(pageList);
			S_AlbumList.dt_Album_List = shop_Image_Action.Select_List(this.PageSize, num, 1, this.string_3, this.string_1, this.string_4, this.MemLoginID);
		}
	}
}
