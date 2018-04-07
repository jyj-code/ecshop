using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ShopInfo_Action : IShop_ShopInfo_Action
	{
		public DataTable GetShopInfo(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopInfo", array, array2);
		}
		public int UpdateShopInfo(ShopNum1_ShopInfo shopInfo)
		{
			string[] array = new string[15];
			string[] array2 = new string[15];
			array[0] = "@name";
			array2[0] = shopInfo.Name;
			array[1] = "@shopname";
			array2[1] = shopInfo.ShopName;
			array[2] = "@salesrange";
			array2[2] = shopInfo.SalesRange;
			array[3] = "@tel";
			array2[3] = shopInfo.Tel;
			array[4] = "@address";
			array2[4] = shopInfo.Address;
			array[5] = "@addresscode";
			array2[5] = shopInfo.AddressCode;
			array[6] = "@addressvalue";
			array2[6] = shopInfo.AddressValue;
			array[7] = "@companyintroduce";
			array2[7] = shopInfo.CompanyIntroduce;
			array[8] = "@banner";
			array2[8] = shopInfo.Banner;
			array[9] = "@modifyuser";
			array2[9] = shopInfo.ModifyUser;
			array[10] = "@modifytime";
			array2[10] = shopInfo.ModifyTime.ToString();
			array[11] = "@memloginid";
			array2[11] = shopInfo.MemLoginID;
			array[12] = "@email";
			array2[12] = shopInfo.Email;
			array[13] = "@phone";
			array2[13] = shopInfo.Phone;
			array[14] = "@ShopIntroduce";
			array2[14] = shopInfo.ShopIntroduce;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopInfo", array, array2);
		}
		public int UpdateLoginDate(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateLoginDate", array, array2);
		}
		public DataTable GetMemLoginInfo(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemLoginInfo", array, array2);
		}
		public DataTable GetShopNameByMemloginID(string memLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNameByMemloginID", array, array2);
		}
		public int UpdateShopCategory(string shopcategory, string memloginid, string brandguid, string brandname)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shopcategory";
			array2[0] = shopcategory;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			array[2] = "@brandguid";
			array2[2] = brandguid;
			array[3] = "@brandname";
			array2[3] = brandname;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopCategory", array, array2);
		}
		public DataSet GetWelcome(string memberloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memberloginid";
			array2[0] = memberloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetWelcome", array, array2);
		}
		public DataTable GetShopRank(string memberloginid)
		{
			string strSql = string.Empty;
			strSql = "select B.Name,A.ShopReputation,A.ShopRank,B.Pic from ShopNum1_ShopInfo AS A,ShopNum1_ShopRank AS B where A.ShopRank=B.Guid AND MemLoginID='" + memberloginid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetMemberLoginidByShopid(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMemberLoginidByShopid", array, array2);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0]["MemLoginID"].ToString();
			}
			return "";
		}
		public string GetShopNameByShopid(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNameByShopid", array, array2);
			return dataTable.Rows[0]["ShopName"].ToString();
		}
		public DataTable GetShopMetaInfo(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaInfo", array, array2);
		}
		public DataTable GetCateGoryNameBycode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCateGoryNameBycode", array, array2);
		}
		public DataTable GetCatetoryNamebycode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCatetoryNamebycode", array, array2);
		}
		public int AddApplyCateGory(ShopNum1_Shop_ApplyCateGory shopApplyCateGory)
		{
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@guid";
			array2[0] = shopApplyCateGory.Guid.ToString();
			array[1] = "@shopcategoryname";
			array2[1] = shopApplyCateGory.ShopCategoryName;
			array[2] = "@newshopcategorycode";
			array2[2] = shopApplyCateGory.NewShopCateGoryCode;
			array[3] = "@brandname";
			array2[3] = shopApplyCateGory.BrandName;
			array[4] = "@newbrandguid";
			array2[4] = shopApplyCateGory.NewBrandGuid.ToString();
			array[5] = "@Remarks";
			array2[5] = shopApplyCateGory.Remarks.ToString();
			array[6] = "@shopid";
			array2[6] = shopApplyCateGory.ShopID;
			array[7] = "@OldShopCategoryName";
			array2[7] = shopApplyCateGory.OldShopCategoryName;
			array[8] = "@OldBrandName";
			array2[8] = shopApplyCateGory.OldBrandName;
			array[9] = "@OldShopCategoryCode";
			array2[9] = shopApplyCateGory.OldShopCategoryCode;
			array[10] = "@OldBrandGuid";
			array2[10] = shopApplyCateGory.OldBrandGuid.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_Shop_ApplyCateGory", array, array2);
		}
		public DataTable GetApplyCatetoryList(string shopid, string state, string audtitetime1, string audtitetime2)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@state";
			array2[1] = state;
			array[2] = "@audtitetime1";
			array2[2] = audtitetime1;
			array[3] = "@audtitetime2";
			array2[3] = audtitetime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetApplyCatetoryList", array, array2);
		}
		public int DelApplyCatetoryByGuid(string guid, string memloginId)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@shopid";
			array2[1] = memloginId;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DelApplyCatetoryByGuid", array, array2);
		}
		public DataTable GetShopRankImage(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopRankImage", array, array2);
		}
		public DataTable GetStarGuide(string shopid, int int_0)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@num";
			array2[1] = int_0.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShop_StarGuide", array, array2);
		}
		public DataTable CheckMemLoginName(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckMemLoginID", array, array2);
		}
		public int UpdateCompanyIsAudit(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCompanyIsAudit", array, array2);
		}
		public int UpdateMemberPwd(string memloginid, string oldpwd, string string_0)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@oldpwd";
			array2[1] = oldpwd;
			array[2] = "@pwd";
			array2[2] = string_0;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemberPwd", array, array2);
		}
		public DataTable GetMemInfoByShopID(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemInfoByShopID", array, array2);
		}
		public DataTable GetMemSimpleByShopID(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemSimpleByShopID", array, array2);
		}
		public DataTable GetShopSimpleByMemID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopSimpleByMemID", array, array2);
		}
		public DataTable GetShopRankScoreScope()
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankImg");
		}
		public DataTable GetShopRankByMemLoginID(string MemLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = MemLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByMemLoginID", array, array2);
		}
		public string IsAllowToAddProduct(string memloginid, string rankguid, string type)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@rankguid";
			array2[1] = rankguid;
			array[2] = "@type";
			array2[2] = type;
			return DatabaseExcetue.ReturnProcedureString("Pro_Shop_GetAddProductCountByMemLoginID", array, array2).ToString();
		}
		public DataTable GetMaxCountByShopRank(string shoprank, string file)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shoprank";
			array2[0] = shoprank;
			array[1] = "@file";
			array2[1] = file;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMaxProductCountByShopRank", array, array2);
		}
		public DataTable GetOpenTimeByShopID(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOpenTimeByShopID", array, array2);
		}
		public DataTable GetShopIDAndOpenTimeByMemLoginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopIDAndOpenTimeByMemLoginID", array, array2);
		}
		public DataTable GetShopCategoryInfoByMemLoginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopCategoryInfoByMemLoginID", array, array2);
		}
		public int UploadingCardPic(ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_ShopInfo SET RegistrationNum='",
				shopNum1_ShopInfo.RegistrationNum,
				"',CompanName='",
				shopNum1_ShopInfo.CompanName,
				"',LegalPerson='",
				shopNum1_ShopInfo.LegalPerson,
				"',BusinessTerm='",
				shopNum1_ShopInfo.BusinessTerm,
				"',BusinessScope='",
				shopNum1_ShopInfo.BusinessScope,
				"',CompanIsAudit=0  WHERE MemLoginID='",
				shopNum1_ShopInfo.MemLoginID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchIsAudit(string shopID, string shopName, string legalPerson, string registrationNum)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ");
			stringBuilder.Append("GUID,ShopID,ShopName,LegalPerson,RegistrationNum,MemLoginID ");
			stringBuilder.Append("from ");
			stringBuilder.Append("ShopNum1_ShopInfo");
			stringBuilder.Append(" where CompanIsAudit=0");
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				stringBuilder.Append(" AND shopID LIKE '%" + Operator.FilterString(shopID) + "%'");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder.Append(" AND shopName LIKE '%" + Operator.FilterString(shopName) + "%'");
			}
			if (Operator.FormatToEmpty(legalPerson) != string.Empty)
			{
				stringBuilder.Append(" AND legalPerson = '" + Operator.FilterString(legalPerson) + "'");
			}
			if (Operator.FormatToEmpty(registrationNum) != string.Empty)
			{
				stringBuilder.Append(" AND registrationNum = '" + Operator.FilterString(registrationNum) + "'");
			}
			stringBuilder.Append(" ORDER BY ApplyTime DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int UpdateCompanAudit(string Guid, string CompanIsAudit, string strCompanAuditFailedReason)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_ShopInfo set CompanIsAudit=",
				Operator.FilterString(CompanIsAudit),
				",CompanAuditFailedReason='",
				Operator.FilterString(strCompanAuditFailedReason),
				"', CompanAuditTime='",
				DateTime.Now.ToString(),
				"' where Guid in('",
				Guid,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopUrlByAddressCode(string AddressCode)
		{
			string text = string.Empty;
			text = "select ShopUrl from  ShopNum1_ShopInfo where AddressCode ='" + AddressCode + "'";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public int UpdateLongLat(string Longitude, string Latitude, string MemberLoginID)
		{
			string strSql = string.Concat(new string[]
			{
				"Update ShopNum1_ShopInfo set Longitude='",
				Longitude,
				"' ,Latitude='",
				Latitude,
				"'  where MemLoginID='",
				MemberLoginID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateClickCount(string strShopId)
		{
			return DatabaseExcetue.RunNonQuery("Update ShopNum1_ShopInfo set ClickCount=ClickCount+1 where shopid='" + strShopId + "'");
		}
		public DataTable GetDataInfoByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "   SELECT * FROM   ShopNum1_ShopInfo  WHERE  MemLoginID ='" + MemLoginID + "'  ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateShop(ShopNum1_ShopInfo ShopInfo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_ShopInfo set   Name='",
				Operator.FilterString(ShopInfo.Name),
				"',      Tel='",
				Operator.FilterString(ShopInfo.Tel),
				"',      Phone='",
				Operator.FilterString(ShopInfo.Phone),
				"',      ShopName='",
				Operator.FilterString(ShopInfo.ShopName),
				"',      MainGoods='",
				Operator.FilterString(ShopInfo.MainGoods),
				"',      Banner='",
				ShopInfo.Banner,
				"',      IdentityCard='",
				Operator.FilterString(ShopInfo.IdentityCard),
				"',      Address='",
				Operator.FilterString(ShopInfo.Address),
				"',      Memo='",
				ShopInfo.Memo,
				"',      ShopIntroduce='",
				ShopInfo.ShopIntroduce,
				"',      AddressCode='",
				Operator.FilterString(ShopInfo.AddressCode),
				"',      AddressValue='",
				Operator.FilterString(ShopInfo.AddressValue),
				"',      ModifyTime='",
				Operator.FilterString(ShopInfo.ModifyTime),
				"'     where MemLoginID ='",
				ShopInfo.MemLoginID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetMyBuyShop(string MemLoginID, int rows)
		{
			string text = string.Empty;
			text += "   SELECT * FROM (SELECT Guid,ShopName,Phone,AddressValue ,MemLoginID, Banner,  ROW_NUMBER() over(order by ApplyTime) as rows    ";
			text += "   FROM (SELECT Guid,ShopName,Phone,AddressValue,ApplyTime ,MemLoginID ,Banner  ";
			text += "   FROM  ShopNum1_ShopInfo WHERE  MemLoginID IN   ";
			text += "   (SELECT ShopID FROM  ShopNum1_OrderInfo   ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"    WHERE MemLoginID='",
				MemLoginID,
				"' GROUP  BY ShopID    ) ) AS A ) AS  B WHERE B.rows=",
				rows,
				"  "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetMyBuyShopProduct(string MemLoginID, string ShopID, int int_0)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   SELECT TOP ",
				int_0,
				"  Name,OriginalImage,Guid,ShopPrice,MemLoginID    FROM  ShopNum1_Shop_Product  "
			});
			text += "   WHERE Guid  ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"   IN(SELECT ProductGuid FROM  ShopNum1_OrderProduct WHERE  ShopID='",
				ShopID,
				"'and MemLoginID='",
				MemLoginID,
				"')  "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public bool IsClose(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "   SELECT IsClose FROM ShopNum1_ShopInfo WHERE MemLoginID='" + MemLoginID + "'  ";
			bool result;
			try
			{
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
					{
						if (dataTable.Rows[0][0].ToString() == "1")
						{
							result = false;
						}
						else if (dataTable.Rows[0][0].ToString() == "0")
						{
							result = true;
						}
						else
						{
							result = false;
						}
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public DataTable GetShopOpentimeByProductGuid(string ProductGuid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select B.opentime,B.ShopID,A.FeeTemplateID,A.Post_fee,A.Express_fee,A.Ems_fee from shopnum1_shop_product A,shopnum1_shopinfo B ");
			stringBuilder.Append(" where A.memloginid=B.memloginid ");
			stringBuilder.Append(" and A.guid='" + ProductGuid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopIsrecom(int showcount)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"select top ",
				showcount,
				" shopid,shopname,[name],maingoods,banner from shopnum1_shopinfo"
			});
			text += " where isrecommend = 1 and isaudit = 1 ";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopIsrecom(int showcount, string SubstationID)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"select top ",
				showcount,
				" shopid,shopname,[name],maingoods,banner from shopnum1_shopinfo"
			});
			text += " where isrecommend = 1 and isaudit = 1 ";
			if (SubstationID != "all")
			{
				text = text + "   and    SubstationID='" + SubstationID + "'     ";
			}
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopByOpenTime(int showcount)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"select top ",
				showcount,
				" shopid,shopname,[name],maingoods,banner from shopnum1_shopinfo"
			});
			text += " where    IsSystemRecommend= 1 and isaudit = 1 ";
			text += " order by opentime DESC";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopByOpenTime(int showcount, string SubstationID)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"select top ",
				showcount,
				" shopid,shopname,[name],maingoods,banner from shopnum1_shopinfo"
			});
			text += " where isrecommend = 1 and isaudit = 1 ";
			if (SubstationID != "all")
			{
				text = text + "   and    SubstationID='" + SubstationID + "'     ";
			}
			text += " order by opentime DESC";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopHot(int showcount)
		{
			string text = string.Empty;
			text += "select shopid,shopname,[name],maingoods,opentime,banner from shopnum1_shopinfo ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  where [guid] in (select [guid] from (select top ",
				showcount,
				" [guid],a=max(ClickCount+CollectCount) from shopnum1_shopinfo"
			});
			text += " where isaudit = 1 group by [guid] order by a desc) b)";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopHot(int showcount, string SubstationID)
		{
			string text = string.Empty;
			text += "select shopid,shopname,[name],maingoods,opentime,banner from shopnum1_shopinfo ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  where [guid] in (select [guid] from (select top ",
				showcount,
				" [guid],a=max(ClickCount+CollectCount) from shopnum1_shopinfo  where  1=1  and    SubstationID='",
				SubstationID,
				"'"
			});
			text += " where isaudit = 1 group by [guid] order by a desc) b)";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
	}
}
