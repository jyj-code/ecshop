using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Product_Action : IShop_Product_Action
	{
		public DataTable GetPanicList(string showcount, string ordertype, string shopid)
		{
			return null;
		}
		public DataTable AutoSearchProductName(string keyword)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@keyword";
			array2[0] = keyword;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchProductName", array, array2);
		}
		public DataTable AutoSearchShopName(string keyword)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@keyword";
			array2[0] = keyword;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchShopName", array, array2);
		}
		public DataTable AutoSearchProductName(string keyword, string type)
		{
			string[] paraName = new string[]
			{
				"@keyword",
				"@type"
			};
			string[] paraValue = new string[]
			{
				keyword,
				type
			};
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchProductName", paraName, paraValue);
		}
		public DataTable AutoSearchShopName(string keyword, string type)
		{
			string[] paraName = new string[]
			{
				"@keyword",
				"@type"
			};
			string[] paraValue = new string[]
			{
				keyword,
				type
			};
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchShopName", paraName, paraValue);
		}
		public DataTable AutoSearchSupplyName(string keyword)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@keyword";
			array2[0] = keyword;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchSupplyName", array, array2);
		}
		public DataTable GetShopProduct(string name, string productnum, string issaled, string beginprice, string endprice, string producttype, string productseriescode, string productcategorycode, string memloginid, string isAudit)
		{
			string[] array = new string[10];
			string[] array2 = new string[10];
			array[0] = "@name";
			array2[0] = name;
			array[1] = "@productnum";
			array2[1] = productnum;
			array[2] = "@issaled";
			array2[2] = issaled;
			array[3] = "@beginprice";
			array2[3] = beginprice;
			array[4] = "@endprice";
			array2[4] = endprice;
			array[5] = "@producttype";
			array2[5] = producttype;
			array[6] = "@productseriescode";
			array2[6] = productseriescode;
			array[7] = "@productcategorycode";
			array2[7] = productcategorycode;
			array[8] = "@memloginid";
			array2[8] = memloginid;
			array[9] = "@isAudit";
			array2[9] = isAudit;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProduct", array, array2);
		}
		public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string showcount, string ordertype, string shopid, string sort)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@showcount";
			array2[3] = showcount;
			array[4] = "@ordertype";
			array2[4] = ordertype;
			array[5] = "@shopid";
			array2[5] = shopid;
			array[6] = "@sort";
			array2[6] = sort;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsProduct", array, array2);
		}
		public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@ispanicbuy";
			array2[3] = ispanicbuy;
			array[4] = "@isspellbuy";
			array2[4] = isspellbuy;
			array[5] = "@showcount";
			array2[5] = showcount;
			array[6] = "@ordertype";
			array2[6] = ordertype;
			array[7] = "@shopid";
			array2[7] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsAllProduct", array, array2);
		}
		public DataTable GetIsProductAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid)
		{
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[8] = "@IsShopRecommend";
			array2[8] = IsShopRecommend;
			array[3] = "@ispanicbuy";
			array2[3] = ispanicbuy;
			array[4] = "@isspellbuy";
			array2[4] = isspellbuy;
			array[5] = "@showcount";
			array2[5] = showcount;
			array[6] = "@ordertype";
			array2[6] = ordertype;
			array[7] = "@shopid";
			array2[7] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsProductAndRecommend", array, array2);
		}
		public DataTable GetProductDetail(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductInfo", array, array2);
		}
		public DataSet GetProductInfoByGuidAndMemLoginID(string guid, string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetProductDetailByGuId", array, array2);
		}
		public DataTable GetSaleRankingProduct(string showcount, string shopid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showcount";
			array2[0] = showcount;
			array[1] = "@shopid";
			array2[1] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSaleRankingProduct", array, array2);
		}
		public DataTable GetProductDetailMeta(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductDetailMeta", array, array2);
		}
		public DataTable GetSpellInfoMeta(string shopid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellInfoMeta", array, array2);
		}
		public DataTable GetProductBrandAndOrderIdByCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetProductBrandAndOrderIdByCode]", array, array2);
		}
		public DataTable GetProductCategoryNameByCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetProductInfoByCode]", array, array2);
		}
		public DataTable SearchProductList(string memloginid, string kwyword, string pricestart, string priceend, string code, string sortstyle)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@kwyword";
			array2[1] = kwyword;
			array[2] = "@pricestart";
			array2[2] = pricestart;
			array[3] = "@priceend";
			array2[3] = priceend;
			array[4] = "@code";
			array2[4] = code;
			array[5] = "@sortstyle";
			array2[5] = sortstyle;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchProductList", array, array2);
		}
		public DataTable GetShopMetaByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaByGuid", array, array2);
		}
		public DataTable GetCollectRankingProduct(string showcount, string shopid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showcount";
			array2[0] = showcount;
			array[1] = "@shopid";
			array2[1] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCollectRankingProduct", array, array2);
		}
		public int UpdateClickCountByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateClickCountByGuid", array, array2);
		}
		public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (isnew != "-1")
			{
				text = " AND IsShopNew=" + isnew;
			}
			if (ishot != "-1")
			{
				text = text + " AND isShophot=" + ishot;
			}
			if (ispromotion != "-1")
			{
				text = text + " AND isShoppromotion=" + ispromotion;
			}
			text += " AND issell=1 AND IsAudit=1 and starttime<=getdate() and  ProductState=0 ";
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@columnnames";
			array2[3] = " Guid,Name,ProductNum,ShopPrice,MarketPrice,RepertoryCount,UnitName,CreateTime,Detail,Instruction,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,IsNew,IsHot,IsPromotion,OriginalImage,ThumbImage,multiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,Description,Keywords,starttime,endtime,MemLoginID,ShopName ";
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@ordertype";
			array2[5] = ordertype;
			array[6] = "@shopid";
			array2[6] = shopid;
			array[7] = "@sort";
			array2[7] = sort;
			array[8] = "@perpagenum";
			array2[8] = perpagenum;
			array[9] = "@current_page";
			array2[9] = current_page;
			array[10] = "@isreturcount";
			array2[10] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", array, array2);
		}
		public DataSet GetIsProductNewAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (isnew != "-1")
			{
				text = " AND IsShopNew=" + isnew;
			}
			if (ishot != "-1")
			{
				text = text + " AND isShophot=" + ishot;
			}
			if (ispromotion != "-1")
			{
				text = text + " AND isShoppromotion=" + ispromotion;
			}
			if (IsShopRecommend != "-1")
			{
				text = text + " AND IsShopRecommend=" + IsShopRecommend;
			}
			text += " AND issell=1 AND IsAudit=1 and  ProductState=0 ";
			string[] array = new string[12];
			string[] array2 = new string[12];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@columnnames";
			array2[3] = " Guid,Name,ProductNum,ShopPrice,MarketPrice,RepertoryCount,UnitName,CreateTime,Detail,Instruction,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,IsNew,IsHot,IsPromotion,OriginalImage,ThumbImage,multiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,Description,Keywords,starttime,endtime,MemLoginID,ShopName ";
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@ordertype";
			array2[5] = ordertype;
			array[6] = "@shopid";
			array2[6] = shopid;
			array[7] = "@sort";
			array2[7] = sort;
			array[8] = "@perpagenum";
			array2[8] = perpagenum;
			array[9] = "@current_page";
			array2[9] = current_page;
			array[10] = "@isreturcount";
			array2[10] = isreturcount;
			array[11] = "@IsShopRecommend";
			array2[11] = IsShopRecommend;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNewRecommend", array, array2);
		}
		public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (isnew != "-1")
			{
				text = " AND  IsNew=" + isnew;
			}
			if (ishot != "-1")
			{
				text = text + " AND ishot=" + ishot;
			}
			if (ispromotion != "-1")
			{
				text = text + " AND ispromotion=" + ispromotion;
			}
			text += " AND issell=1 AND IsAudit=1 and  ProductState=0  ";
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@columnnames";
			array2[3] = "Guid,Name,ProductNum,ShopPrice,MarketPrice,RepertoryCount,UnitName,CreateTime,Detail,Instruction,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,IsNew,IsHot,IsPromotion,OriginalImage,ThumbImage,multiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,Description,Keywords,starttime,endtime,MemLoginID,ShopName  ";
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@ordertype";
			array2[5] = ordertype;
			array[6] = "@shopid";
			array2[6] = shopid;
			array[7] = "@sort";
			array2[7] = sort;
			array[8] = "@perpagenum";
			array2[8] = perpagenum;
			array[9] = "@current_page";
			array2[9] = current_page;
			array[10] = "@isreturcount";
			array2[10] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", array, array2);
		}
		public DataSet GetIsProductNewProductState(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (isnew != "-1")
			{
				text = " AND  IsNew=" + isnew;
			}
			if (ishot != "-1")
			{
				text = text + " AND ishot=" + ishot;
			}
			if (ispromotion != "-1")
			{
				text = text + " AND ispromotion=" + ispromotion;
			}
			text += " AND issell=1 AND IsAudit=1 and  ProductState=1  ";
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@isnew";
			array2[0] = isnew;
			array[1] = "@ishot";
			array2[1] = ishot;
			array[2] = "@ispromotion";
			array2[2] = ispromotion;
			array[3] = "@columnnames";
			array2[3] = "Guid,Name,ProductNum,ShopPrice,MarketPrice,RepertoryCount,UnitName,CreateTime,Detail,Instruction,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,IsNew,IsHot,IsPromotion,OriginalImage,ThumbImage,multiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,Description,Keywords,starttime,endtime,MemLoginID,ShopName  ";
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@ordertype";
			array2[5] = ordertype;
			array[6] = "@shopid";
			array2[6] = shopid;
			array[7] = "@sort";
			array2[7] = sort;
			array[8] = "@perpagenum";
			array2[8] = perpagenum;
			array[9] = "@current_page";
			array2[9] = current_page;
			array[10] = "@isreturcount";
			array2[10] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", array, array2);
		}
		public DataTable GetShopProductDetailMeto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProductDetailMeto", array, array2);
		}
		public DataSet SearchProductListNew(string memloginid, string kwyword, string pricestart, string priceend, string code, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(kwyword))
			{
				text = "  AND Name like '%" + kwyword + "%'";
			}
			if (!string.IsNullOrEmpty(pricestart))
			{
				text = text + " AND ShopPrice>=" + pricestart;
			}
			if (!string.IsNullOrEmpty(priceend))
			{
				text = text + " AND ShopPrice<=" + priceend;
			}
			if (!string.IsNullOrEmpty(code))
			{
				text = text + " AND ProductSeriesCode like '%" + code + "%'";
			}
			text = text + " and issell=1 and issaled=1 and isaudit=1  and memloginId='" + memloginid + "'";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@searchname";
			array2[0] = text;
			array[1] = "@ordertype";
			array2[1] = ordertype;
			array[2] = "@sort";
			array2[2] = sort;
			array[3] = "@perpagenum";
			array2[3] = perpagenum;
			array[4] = "@current_page";
			array2[4] = current_page;
			array[5] = "@isreturcount";
			array2[5] = isreturcount;
			array[6] = "@shopid";
			array2[6] = memloginid;
			array[7] = "@columnnames";
			array2[7] = "  Guid,Name,ShopPrice,issell,ProductCategoryCode,OriginalImage,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,MemLoginID,ShopName   ";
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchProductListNew", array, array2);
		}
		public DataTable GetShopProductEdit(string guid)
		{
			string strSql = "SELECT * FROM ShopNum1_Shop_Product WHERE Guid in(" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateProductSaled(string strIds, string isSaled)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"UPDATE  ShopNum1_Shop_Product SET issell=",
				isSaled,
				" WHERE [id] in (",
				strIds,
				")"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int AddShopProduct(ShopNum1_Shop_Product shop_Product)
		{
			int result;
			try
			{
				string[] array = new string[51];
				string[] array2 = new string[51];
				array[0] = "@guid";
				array2[0] = shop_Product.Guid.ToString();
				array[1] = "@name";
				array2[1] = shop_Product.Name;
				array[2] = "@productnum";
				array2[2] = shop_Product.ProductNum;
				array[3] = "@ShopPrice";
				array2[3] = shop_Product.ShopPrice.ToString();
				array[4] = "@MarketPrice";
				array2[4] = shop_Product.MarketPrice.ToString();
				array[5] = "@RepertoryCount";
				array2[5] = shop_Product.RepertoryCount.ToString();
				array[6] = "@unitname";
				array2[6] = shop_Product.UnitName;
				array[7] = "@detail";
				array2[7] = shop_Product.Detail;
				array[8] = "@instruction";
				array2[8] = shop_Product.Instruction;
				array[9] = "@BrandGuid";
				array2[9] = shop_Product.BrandGuid.ToString();
				array[10] = "@BrandName";
				array2[10] = shop_Product.BrandName;
				array[11] = "@productseriescode";
				array2[11] = shop_Product.ProductSeriesCode;
				array[12] = "@productseriesname";
				array2[12] = shop_Product.ProductSeriesName;
				array[13] = "@productcategorycode";
				array2[13] = shop_Product.ProductCategoryCode;
				array[14] = "@productcategoryname";
				array2[14] = shop_Product.ProductCategoryName;
				array[15] = "@originalimage";
				array2[15] = shop_Product.OriginalImage;
				array[16] = "@thumbimage";
				array2[16] = shop_Product.ThumbImage;
				array[17] = "@SmallImage";
				array2[17] = shop_Product.SmallImage;
				array[18] = "@MultiImages";
				array2[18] = shop_Product.MultiImages;
				array[19] = "@description";
				array2[19] = shop_Product.Description;
				array[20] = "@keywords";
				array2[20] = shop_Product.Keywords;
				array[21] = "@AddressCode";
				array2[21] = shop_Product.AddressCode;
				array[22] = "@AddressValue";
				array2[22] = shop_Product.AddressValue;
				array[23] = "@memloginid";
				array2[23] = shop_Product.MemLoginID;
				array[24] = "@shopname";
				array2[24] = shop_Product.ShopName;
				array[25] = "@isaudit";
				array2[25] = shop_Product.IsAudit.ToString();
				array[26] = "@FeeType";
				array2[26] = shop_Product.FeeType.ToString();
				array[27] = "@Post_fee";
				array2[27] = shop_Product.Post_fee.ToString();
				array[28] = "@Express_fee";
				array2[28] = shop_Product.Express_fee.ToString();
				array[29] = "@Ems_fee";
				array2[29] = shop_Product.Ems_fee.ToString();
				array[30] = "@FeeTemplateID";
				array2[30] = shop_Product.FeeTemplateID.ToString();
				array[31] = "@FeeTemplateName";
				array2[31] = shop_Product.FeeTemplateName;
				array[32] = "@MinusFee";
				array2[32] = shop_Product.MinusFee.ToString();
				array[33] = "@IsReal";
				array2[33] = shop_Product.IsReal.ToString();
				array[34] = "@IsSell";
				array2[34] = shop_Product.IsSell.ToString();
				array[35] = "@CreateUser";
				array2[35] = shop_Product.CreateUser;
				array[36] = "@saletime";
				array2[36] = Convert.ToDateTime((!shop_Product.SaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.SaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[37] = "@DeSaleTime";
				array2[37] = Convert.ToDateTime((!shop_Product.DeSaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.DeSaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[38] = "@ModifyTime";
				array2[38] = Convert.ToDateTime((!shop_Product.ModifyTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[39] = "@StartTime";
				array2[39] = Convert.ToDateTime((!shop_Product.StartTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.StartTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[40] = "@EndTime";
				array2[40] = Convert.ToDateTime((!shop_Product.EndTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.EndTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[41] = "@ProductState";
				array2[41] = shop_Product.ProductState.ToString();
				array[42] = "@Ctype";
				array2[42] = shop_Product.Ctype.ToString();
				array[43] = "@IsShopNew";
				array2[43] = shop_Product.IsShopNew.ToString();
				array[44] = "@IsShopHot";
				array2[44] = shop_Product.IsShopHot.ToString();
				array[45] = "@IsShopPromotion";
				array2[45] = shop_Product.IsShopPromotion.ToString();
				array[46] = "@IsShopRecommend";
				array2[46] = shop_Product.IsShopRecommend.ToString();
				array[47] = "@SetStock";
				array2[47] = shop_Product.SetStock.ToString();
				array[48] = "@pulishtype";
				array2[48] = shop_Product.PulishType.ToString();
				array[49] = "@Wap_desc";
				array2[49] = shop_Product.Wap_desc.ToString();
				array[50] = "@RepertoryAlertCount";
				array2[50] = shop_Product.RepertoryAlertCount.ToString();
				result = DatabaseExcetue.RunProcedure("Pro_Shop_AddShopProduct", array, array2);
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int AddShopProductNew(ShopNum1_Shop_Product shop_Product)
		{
			int result;
			try
			{
				string[] array = new string[52];
				string[] array2 = new string[52];
				array[0] = "@guid";
				array2[0] = shop_Product.Guid.ToString();
				array[1] = "@name";
				array2[1] = shop_Product.Name;
				array[2] = "@productnum";
				array2[2] = shop_Product.ProductNum;
				array[3] = "@ShopPrice";
				array2[3] = shop_Product.ShopPrice.ToString();
				array[4] = "@MarketPrice";
				array2[4] = shop_Product.MarketPrice.ToString();
				array[5] = "@RepertoryCount";
				array2[5] = shop_Product.RepertoryCount.ToString();
				array[6] = "@unitname";
				array2[6] = shop_Product.UnitName;
				array[7] = "@detail";
				array2[7] = shop_Product.Detail;
				array[8] = "@instruction";
				array2[8] = shop_Product.Instruction;
				array[9] = "@BrandGuid";
				array2[9] = shop_Product.BrandGuid.ToString();
				array[10] = "@BrandName";
				array2[10] = shop_Product.BrandName;
				array[11] = "@productseriescode";
				array2[11] = shop_Product.ProductSeriesCode;
				array[12] = "@productseriesname";
				array2[12] = shop_Product.ProductSeriesName;
				array[13] = "@productcategorycode";
				array2[13] = shop_Product.ProductCategoryCode;
				array[14] = "@productcategoryname";
				array2[14] = shop_Product.ProductCategoryName;
				array[15] = "@originalimage";
				array2[15] = shop_Product.OriginalImage;
				array[16] = "@thumbimage";
				array2[16] = shop_Product.ThumbImage;
				array[17] = "@SmallImage";
				array2[17] = shop_Product.SmallImage;
				array[18] = "@MultiImages";
				array2[18] = shop_Product.MultiImages;
				array[19] = "@description";
				array2[19] = shop_Product.Description;
				array[20] = "@keywords";
				array2[20] = shop_Product.Keywords;
				array[21] = "@AddressCode";
				array2[21] = shop_Product.AddressCode;
				array[22] = "@AddressValue";
				array2[22] = shop_Product.AddressValue;
				array[23] = "@memloginid";
				array2[23] = shop_Product.MemLoginID;
				array[24] = "@shopname";
				array2[24] = shop_Product.ShopName;
				array[25] = "@isaudit";
				array2[25] = shop_Product.IsAudit.ToString();
				array[26] = "@FeeType";
				array2[26] = shop_Product.FeeType.ToString();
				array[27] = "@Post_fee";
				array2[27] = shop_Product.Post_fee.ToString();
				array[28] = "@Express_fee";
				array2[28] = shop_Product.Express_fee.ToString();
				array[29] = "@Ems_fee";
				array2[29] = shop_Product.Ems_fee.ToString();
				array[30] = "@FeeTemplateID";
				array2[30] = shop_Product.FeeTemplateID.ToString();
				array[31] = "@FeeTemplateName";
				array2[31] = shop_Product.FeeTemplateName;
				array[32] = "@MinusFee";
				array2[32] = shop_Product.MinusFee.ToString();
				array[33] = "@IsReal";
				array2[33] = shop_Product.IsReal.ToString();
				array[34] = "@IsSell";
				array2[34] = shop_Product.IsSell.ToString();
				array[35] = "@CreateUser";
				array2[35] = shop_Product.CreateUser;
				array[36] = "@saletime";
				array2[36] = Convert.ToDateTime((!shop_Product.SaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.SaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[37] = "@DeSaleTime";
				array2[37] = Convert.ToDateTime((!shop_Product.DeSaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.DeSaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[38] = "@ModifyTime";
				array2[38] = Convert.ToDateTime((!shop_Product.ModifyTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[39] = "@StartTime";
				array2[39] = Convert.ToDateTime((!shop_Product.StartTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.StartTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[40] = "@EndTime";
				array2[40] = Convert.ToDateTime((!shop_Product.EndTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.EndTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[41] = "@ProductState";
				array2[41] = shop_Product.ProductState.ToString();
				array[42] = "@Ctype";
				array2[42] = shop_Product.Ctype.ToString();
				array[43] = "@IsShopNew";
				array2[43] = shop_Product.IsShopNew.ToString();
				array[44] = "@IsShopHot";
				array2[44] = shop_Product.IsShopHot.ToString();
				array[45] = "@IsShopPromotion";
				array2[45] = shop_Product.IsShopPromotion.ToString();
				array[46] = "@IsShopRecommend";
				array2[46] = shop_Product.IsShopRecommend.ToString();
				array[47] = "@SetStock";
				array2[47] = shop_Product.SetStock.ToString();
				array[48] = "@pulishtype";
				array2[48] = shop_Product.PulishType.ToString();
				array[49] = "@Wap_desc";
				array2[49] = shop_Product.Wap_desc.ToString();
				array[50] = "@RepertoryAlertCount";
				array2[50] = shop_Product.RepertoryAlertCount.ToString();
				array[51] = "@SubstationID";
				array2[51] = shop_Product.SubstationID.ToString();
				result = DatabaseExcetue.RunProcedure("Pro_Shop_AddShopProductNew", array, array2);
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int UpdateShopProduct(ShopNum1_Shop_Product shop_Product)
		{
			int result;
			try
			{
				string[] array = new string[49];
				string[] array2 = new string[49];
				array[0] = "@guid";
				array2[0] = shop_Product.Guid.ToString();
				array[1] = "@name";
				array2[1] = shop_Product.Name;
				array[2] = "@productnum";
				array2[2] = shop_Product.ProductNum;
				array[3] = "@shopprice";
				array2[3] = shop_Product.ShopPrice.ToString();
				array[4] = "@MarketPrice";
				array2[4] = shop_Product.MarketPrice.ToString();
				array[5] = "@repertorycount";
				array2[5] = shop_Product.RepertoryCount.ToString();
				array[6] = "@unitname";
				array2[6] = shop_Product.UnitName;
				array[7] = "@detail";
				array2[7] = shop_Product.Detail;
				array[8] = "@instruction";
				array2[8] = shop_Product.Instruction;
				array[9] = "@productseriescode";
				array2[9] = shop_Product.ProductSeriesCode;
				array[10] = "@productseriesname";
				array2[10] = shop_Product.ProductSeriesName;
				array[11] = "@BrandGuid";
				array2[11] = shop_Product.BrandGuid.ToString();
				array[12] = "@BrandName";
				array2[12] = shop_Product.BrandName;
				array[13] = "@originalimage";
				array2[13] = shop_Product.OriginalImage;
				array[14] = "@thumbimage";
				array2[14] = shop_Product.ThumbImage;
				array[15] = "@SmallImage";
				array2[15] = shop_Product.SmallImage;
				array[16] = "@MultiImages";
				array2[16] = shop_Product.MultiImages;
				array[17] = "@description";
				array2[17] = shop_Product.Description;
				array[18] = "@keywords";
				array2[18] = shop_Product.Keywords;
				array[19] = "@AddressCode";
				array2[19] = shop_Product.AddressCode;
				array[20] = "@AddressValue";
				array2[20] = shop_Product.AddressValue;
				array[21] = "@IsAudit";
				array2[21] = shop_Product.IsAudit.ToString();
				array[22] = "@FeeType";
				array2[22] = shop_Product.FeeType.ToString();
				array[23] = "@Post_fee";
				array2[23] = shop_Product.Post_fee.ToString();
				array[24] = "@Express_fee";
				array2[24] = shop_Product.Express_fee.ToString();
				array[25] = "@Ems_fee";
				array2[25] = shop_Product.Ems_fee.ToString();
				array[26] = "@FeeTemplateID";
				array2[26] = shop_Product.FeeTemplateID.ToString();
				array[27] = "@FeeTemplateName";
				array2[27] = shop_Product.FeeTemplateName;
				array[28] = "@MinusFee";
				array2[28] = shop_Product.MinusFee.ToString();
				array[29] = "@IsReal";
				array2[29] = shop_Product.IsReal.ToString();
				array[30] = "@IsSell";
				array2[30] = shop_Product.IsSell.ToString();
				array[31] = "@CreateUser";
				array2[31] = shop_Product.CreateUser;
				array[32] = "@saletime";
				array2[32] = Convert.ToDateTime((!shop_Product.SaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.SaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[33] = "@DeSaleTime";
				array2[33] = Convert.ToDateTime((!shop_Product.DeSaleTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.DeSaleTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[34] = "@RepertoryAlertCount";
				array2[34] = shop_Product.RepertoryAlertCount.ToString();
				array[35] = "@StartTime";
				array2[35] = Convert.ToDateTime((!shop_Product.StartTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.StartTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[36] = "@EndTime";
				array2[36] = Convert.ToDateTime((!shop_Product.EndTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.EndTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[37] = "@ProductState";
				array2[37] = shop_Product.ProductState.ToString();
				array[38] = "@ModifyTime";
				array2[38] = Convert.ToDateTime((!shop_Product.ModifyTime.HasValue) ? new DateTime?(DateTime.Now) : shop_Product.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
				array[39] = "@IsShopNew";
				array2[39] = shop_Product.IsShopNew.ToString();
				array[40] = "@IsShopHot";
				array2[40] = shop_Product.IsShopHot.ToString();
				array[41] = "@IsShopPromotion";
				array2[41] = shop_Product.IsShopPromotion.ToString();
				array[42] = "@IsShopRecommend";
				array2[42] = shop_Product.IsShopRecommend.ToString();
				array[43] = "@SetStock";
				array2[43] = shop_Product.SetStock.ToString();
				array[44] = "@pulishtype";
				array2[44] = shop_Product.PulishType.ToString();
				array[45] = "@ProductCategoryCode";
				array2[45] = shop_Product.ProductCategoryCode.ToString();
				array[46] = "@ProductCategoryName";
				array2[46] = shop_Product.ProductCategoryName.ToString();
				array[47] = "@ctype";
				array2[47] = shop_Product.Ctype.ToString();
				array[48] = "@Wap_desc";
				array2[48] = shop_Product.Wap_desc.ToString();
				result = DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopProduct", array, array2);
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public DataTable GetProductList(string strPageSize, string strCurrentPage, string strCondition, string strResultNum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = strPageSize;
			array[1] = "@currentpage";
			array2[1] = strCurrentPage;
			array[2] = "@columns";
			array2[2] = "memloginid,productseriesname,RepertoryAlertCount,guid,name,productnum,shopprice,repertorycount,issell,isshopnew,isshophot,isshoppromotion,isshoprecommend,ModifyTime,productcategoryname,smallimage,originalimage,isaudit,id,productcategorycode,ctype,salenumber,(select top 1 id from ShopNum1_SpecProudctDetails where productguid=shopnum1_shop_product.guid And specid!=0)as vd,(select top 1 shopid from shopnum1_shopinfo where memloginid=shopnum1_shop_product.memloginid)shopid,Productstate";
			array[3] = "@tablename";
			array2[3] = "shopnum1_shop_product";
			array[4] = "@condition";
			array2[4] = strCondition;
			array[5] = "@ordercolumn";
			array2[5] = "modifytime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = strResultNum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int DeleteById(string strId)
		{
			string strSql = "Delete from  Shopnum1_Shop_Product WHERE Id IN (" + strId + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateSaleNumberByOrderGuid(string OrderGuidguid, string strSaleNumber)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = OrderGuidguid;
			array[1] = "@salenumber";
			array2[1] = strSaleNumber;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateSaleNumberByOrderGuid", array, array2);
		}
		public DataTable GetQgProduct(int start, int int_0)
		{
			string text = string.Empty;
			text += "   SELECT * FROM (select Guid,Name,ShopPrice,OriginalImage,MemLoginID, ROW_NUMBER()     ";
			text += "   over(order by CreateTime  DESC) as rows from ShopNum1_Shop_Product WHERE ProductState=1    ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   ) AS B WHERE  B.rows>=",
				start,
				" AND B.rows<=",
				int_0,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopproductCatetoryByCode(string code, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@code";
			array2[0] = code;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopproductCatetoryByCode", array, array2);
		}
		public DataTable CheckMenberBuyProduct(string guid, string memberid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@memberid";
			array2[1] = memberid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckMenberBuyProduct", array, array2);
		}
		public DataTable GetPanicInfoMeta(string shopid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetPanicInfoMeta", array, array2);
		}
		public DataTable GetSpellListFor(string shopid, string showcount, string ischeck)
		{
			string text = string.Empty;
			text = " select TOP " + showcount + "  b.ID,A.OriginalImage,A.shopprice,A.marketprice,A.name,A.guid,B.groupcount from ShopNum1_Shop_Product A inner join shopnum1_group_product B on B.productguid=A.guid where  B.aid in(select id from ShopNum1_Product_Activity where 1=1 ";
			if (ischeck == "0")
			{
				text += "  AND endtime>getdate() ";
			}
			else
			{
				text += "  AND endtime<getdate() ";
			}
			text += ")";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetSpellInfo(string shopid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellInfo", array, array2);
		}
		public DataTable GetSpellList(string showcount, string ordertype, string shopid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@showcount";
			array2[0] = showcount;
			array[1] = "@ordertype";
			array2[1] = ordertype;
			array[2] = "@shopid";
			array2[2] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellList", array, array2);
		}
		public DataSet GetPanicInfo(string shopid, string guid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@guid";
			array2[1] = guid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetPanicInfoNew", array, array2);
		}
		public DataTable GetPanicBuyList(string shopid, string showcount, string productguid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@showcount";
			array2[1] = showcount;
			array[2] = "@productguid";
			array2[2] = productguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetPanicBuyList", array, array2);
		}
		public int DeleteShopProduct(string guid, string memloginid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"delete from ShopNum1_Shop_Product where id='",
				guid,
				"' and memloginid='",
				memloginid,
				"';"
			}));
			stringBuilder.Append(string.Concat(new string[]
			{
				"delete from ShopNum1_ShopProduct_Browse where productguid int(select guid from ShopNum1_Shop_Product where id='",
				guid,
				"' and memloginid='",
				memloginid,
				"');"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public string CheckSpellPanicProduct(string memberid, string type)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memberid";
			array2[0] = memberid;
			array[1] = "@type";
			array2[1] = type;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckSpellPanicProduct", array, array2).Rows[0][0].ToString();
		}
		public DataTable GetShopCategroy(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategroy", array, array2);
		}
		public DataTable GetShopName(string memberID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memberid";
			array2[0] = memberID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopInfoByMemloginID", array, array2);
		}
		public DataTable SearchProductShopByGuid(string productguid)
		{
			string strSql = string.Empty;
			strSql = "SELECT MemLoginID,ShopName,Name,ProductNum,MarketPrice,ShopPrice,IsReal,OriginalImage,setstock  FROM ShopNum1_Shop_Product  WHERE Guid in(" + productguid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int GetLimitBuyCount(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT RepertoryCount FROM ShopNum1_Shop_Product WHERE Guid='" + guid + "'";
			return Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["RepertoryCount"].ToString());
		}
		public int ChangeCarByCook(string oldUser, string newUser)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"     UPDATE  ShopNum1_Shop_Cart  SET  MemLoginId='",
				newUser,
				"'   WHERE  MemLoginId='",
				oldUser,
				"'   and  ShopID <>'",
				newUser,
				"'    "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetTemplateFee(string strGuId)
		{
			string strSql = "SELECT FeeTemplateID,FeeType,isreal,Post_fee,Express_fee,Ems_fee FROM ShopNum1_Shop_Product where GuId in (" + strGuId + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
