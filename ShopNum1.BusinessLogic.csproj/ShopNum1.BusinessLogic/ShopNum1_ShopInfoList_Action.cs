using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopInfoList_Action : IShopNum1_ShopInfoList_Action
	{
		public int Add(ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			throw new NotImplementedException();
		}
		public int Delete(string guid)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_ShopInfo  WHERE Guid = " + guid;
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteMore(string guid)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_ShopInfo  WHERE   Guid    IN (" + guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string memberLoginId)
		{
			string strSql = string.Empty;
			strSql = "select * from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memberLoginId + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchInfoList2(string ShopName, string Name, string memberLoginID, string type, string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit, string startTime, string endTime, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  A.*,(select  Name from ShopNum1_ShopRank where  Guid=A.ShopRank) RankName  from ShopNum1_ShopInfo as A  where   1=1 ");
			if (Operator.FormatToEmpty(ShopName) != string.Empty)
			{
				stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
			}
			if (Operator.FormatToEmpty(Name) != string.Empty)
			{
				stringBuilder.Append(" AND A.Name like '%" + Operator.FilterString(Name) + "%'");
			}
			if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND A.ShopCategoryID like '" + type + "%'");
			}
			if (Operator.FormatToEmpty(addressCode) != "-1")
			{
				stringBuilder.Append(" AND A.AddressCode like '" + Operator.FilterString(addressCode) + "%'");
			}
			if (Operator.FormatToEmpty(Ishot) != "-1")
			{
				stringBuilder.Append(" AND A.Ishot = " + Ishot + " ");
			}
			if (Operator.FormatToEmpty(IsVisits) != "-1")
			{
				stringBuilder.Append(" AND A.IsVisits = " + IsVisits + " ");
			}
			if (Operator.FormatToEmpty(IsRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsRecommend = " + IsRecommend + " ");
			}
			if (Operator.FormatToEmpty(IsExpires) != "-1")
			{
				stringBuilder.Append(" AND A.IsExpires = " + IsExpires + " ");
			}
			if (Operator.FormatToEmpty(IdentityIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.IdentityIsAudit = " + IdentityIsAudit + " ");
			}
			if (Operator.FormatToEmpty(CompanIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.CompanIsAudit = " + CompanIsAudit + " ");
			}
			if (Operator.FormatToEmpty(shoprank) != "-1")
			{
				stringBuilder.Append(" AND A.shoprank like '%" + Operator.FilterString(shoprank) + "%'");
			}
			switch (IsAudit)
			{
			case "-1":
				stringBuilder.Append(" AND A.IsAudit= 1");
				break;
			case "0":
				stringBuilder.Append(" AND A.IsAudit= 0");
				break;
			case "1":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 0");
				break;
			case "2":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 1 AND A.IsClose = 0");
				break;
			case "3":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 1");
				break;
			case "-2":
				stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				break;
			}
			if (Operator.FormatToEmpty(startTime) != string.Empty)
			{
				stringBuilder.Append(" AND   A.OpenTime >='" + startTime + "'");
			}
			if (Operator.FormatToEmpty(endTime) != string.Empty)
			{
				stringBuilder.Append("  AND A.OpenTime<='" + endTime + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append("  AND  A.SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchInfoList(string ShopName, string Name, string memberLoginID, string type, string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit, string startTime, string endTime, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select A.*,C.Name as CName,B.Name AS RankName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopRank AS B on A.ShopRank=B.Guid ");
			if (Operator.FormatToEmpty(ShopName) != string.Empty)
			{
				stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
			}
			if (Operator.FormatToEmpty(Name) != string.Empty)
			{
				stringBuilder.Append(" AND A.Name like '%" + Operator.FilterString(Name) + "%'");
			}
			if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND A.ShopCategoryID like '" + type + "%'");
			}
			if (Operator.FormatToEmpty(addressCode) != "-1")
			{
				stringBuilder.Append(" AND A.AddressCode like '" + Operator.FilterString(addressCode) + "%'");
			}
			if (Operator.FormatToEmpty(Ishot) != "-1")
			{
				stringBuilder.Append(" AND A.Ishot = " + Ishot + " ");
			}
			if (Operator.FormatToEmpty(IsVisits) != "-1")
			{
				stringBuilder.Append(" AND A.IsVisits = " + IsVisits + " ");
			}
			if (Operator.FormatToEmpty(IsRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsRecommend = " + IsRecommend + " ");
			}
			if (Operator.FormatToEmpty(IsExpires) != "-1")
			{
				stringBuilder.Append(" AND A.IsExpires = " + IsExpires + " ");
			}
			if (Operator.FormatToEmpty(IdentityIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.IdentityIsAudit = " + IdentityIsAudit + " ");
			}
			if (Operator.FormatToEmpty(CompanIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.CompanIsAudit = " + CompanIsAudit + " ");
			}
			if (Operator.FormatToEmpty(shoprank) != "-1")
			{
				stringBuilder.Append(" AND A.shoprank like '%" + Operator.FilterString(shoprank) + "%'");
			}
			switch (IsAudit)
			{
			case "-1":
				stringBuilder.Append(" AND A.IsAudit= 1");
				break;
			case "0":
				stringBuilder.Append(" AND A.IsAudit= 0");
				break;
			case "1":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 0");
				break;
			case "2":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 1 AND A.IsClose = 0");
				break;
			case "3":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 1");
				break;
			case "-2":
				stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				break;
			}
			if (Operator.FormatToEmpty(startTime) != string.Empty)
			{
				stringBuilder.Append(" AND   A.OpenTime >='" + startTime + "'");
			}
			if (Operator.FormatToEmpty(endTime) != string.Empty)
			{
				stringBuilder.Append("  AND A.OpenTime<='" + endTime + "'");
			}
			if (Operator.FormatToEmpty(shoprepution) != "-1")
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					" AND A.ShopReputation BETWEEN ",
					shoprepution.Split(new char[]
					{
						'/'
					})[0],
					" AND ",
					shoprepution.Split(new char[]
					{
						'/'
					})[1],
					" "
				}));
			}
			stringBuilder.Append(" left join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
			if (Operator.FormatToEmpty(shopensure) != "-1")
			{
				stringBuilder.Append(" inner join  ShopNum1_Shop_ApplyEnsure AS D on a.MemLoginID=d.MemberLoginID AND d.IsPayMent=1 AND D.EnsureID = '" + Operator.FilterString(shopensure) + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append("   WHERE 1=1     ");
				stringBuilder.Append("  AND  A.SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string ShopName, string Name, string memberLoginID, string type, string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit, string startTime, string endTime)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select A.*,C.Name as CName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
			if (Operator.FormatToEmpty(ShopName) != string.Empty)
			{
				stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
			}
			if (Operator.FormatToEmpty(Name) != string.Empty)
			{
				stringBuilder.Append(" AND A.Name like '%" + Operator.FilterString(Name) + "%'");
			}
			if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND A.ShopCategoryID like '" + type + "%'");
			}
			if (Operator.FormatToEmpty(addressCode) != "-1")
			{
				stringBuilder.Append(" AND A.AddressCode like '" + Operator.FilterString(addressCode) + "%'");
			}
			if (Operator.FormatToEmpty(Ishot) != "-1")
			{
				stringBuilder.Append(" AND A.Ishot = " + Ishot + " ");
			}
			if (Operator.FormatToEmpty(IsVisits) != "-1")
			{
				stringBuilder.Append(" AND A.IsVisits = " + IsVisits + " ");
			}
			if (Operator.FormatToEmpty(IsRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsRecommend = " + IsRecommend + " ");
			}
			if (Operator.FormatToEmpty(IsExpires) != "-1")
			{
				stringBuilder.Append(" AND A.IsExpires = " + IsExpires + " ");
			}
			if (Operator.FormatToEmpty(IdentityIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.IdentityIsAudit = " + IdentityIsAudit + " ");
			}
			if (Operator.FormatToEmpty(CompanIsAudit) != "-1")
			{
				stringBuilder.Append(" AND A.CompanIsAudit = " + CompanIsAudit + " ");
			}
			if (Operator.FormatToEmpty(shoprank) != "-1")
			{
				stringBuilder.Append(" AND A.shoprank like '%" + Operator.FilterString(shoprank) + "%'");
			}
			switch (IsAudit)
			{
			case "-1":
				stringBuilder.Append(" AND A.IsAudit= 1");
				break;
			case "0":
				stringBuilder.Append(" AND A.IsAudit= 0");
				break;
			case "1":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 0");
				break;
			case "2":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 1 AND A.IsClose = 0");
				break;
			case "3":
				stringBuilder.Append(" AND A.IsAudit= 1 AND A.IsExpires = 0 AND A.IsClose = 1");
				break;
			case "-2":
				stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				break;
			}
			if (Operator.FormatToEmpty(startTime) != string.Empty)
			{
				stringBuilder.Append(" AND   A.OpenTime >='" + startTime + "'");
			}
			if (Operator.FormatToEmpty(endTime) != string.Empty)
			{
				stringBuilder.Append("  AND A.OpenTime<='" + endTime + "'");
			}
			if (Operator.FormatToEmpty(shoprepution) != "-1")
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					" AND A.ShopReputation BETWEEN ",
					shoprepution.Split(new char[]
					{
						'/'
					})[0],
					" AND ",
					shoprepution.Split(new char[]
					{
						'/'
					})[1],
					" "
				}));
			}
			if (Operator.FormatToEmpty(shopensure) != "-1")
			{
				stringBuilder.Append(" inner join  ShopNum1_Shop_ApplyEnsure AS D on a.MemLoginID=d.MemberLoginID AND d.IsPayMent=1 AND D.EnsureID = '" + Operator.FilterString(shopensure) + "'");
			}
			stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Update(string guid, ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopInfo SET  Name  ='",
				Operator.FilterString(shopNum1_ShopInfo.Name),
				"', SalesRange  ='",
				Operator.FilterString(shopNum1_ShopInfo.SalesRange),
				"', Address  ='",
				Operator.FilterString(shopNum1_ShopInfo.Address),
				"', ShopCategoryID  ='",
				shopNum1_ShopInfo.ShopCategoryID,
				"', AddressCode  ='",
				shopNum1_ShopInfo.AddressCode,
				"', ModifyUser  ='",
				shopNum1_ShopInfo.ModifyUser,
				"', ModifyTime  ='",
				shopNum1_ShopInfo.ModifyTime,
				"', IsAudit  ='",
				shopNum1_ShopInfo.IsAudit,
				"'  IsDeleted  ='",
				shopNum1_ShopInfo.IsDeleted,
				"' WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(string guid, string string_0, string field)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_ShopInfo SET ",
				field,
				"=",
				string_0,
				" where Guid IN (",
				guid,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchShopClickCount(string shophost, string shopname, string startdate, string enddate)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shophost";
			array2[0] = shophost;
			array[1] = "@shopname";
			array2[1] = shopname;
			array[2] = "@startdate";
			array2[2] = startdate;
			array[3] = "@enddate";
			array2[3] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopClickCount", array, array2);
		}
		public DataTable SearchShopClickCount(string shophost, string shopname, string startdate, string enddate, string SubstationID)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@shophost";
			array2[0] = shophost;
			array[1] = "@shopname";
			array2[1] = shopname;
			array[2] = "@SubstationID";
			array2[2] = SubstationID;
			array[3] = "@startdate";
			array2[3] = startdate;
			array[4] = "@enddate";
			array2[4] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopClickCount1", array, array2);
		}
		public DataTable SearchShopAmount(string startdate, string enddate)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@startdate";
			array2[0] = startdate;
			array[1] = "@enddate";
			array2[1] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopAmount", array, array2);
		}
		public int GetShopIdMax()
		{
			return DatabaseExcetue.ReturnMaxID("ShopId", "ShopNum1_ShopInfo");
		}
		public string GetOpenTime(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "select OpenTime from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public string GetMemberType(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "select MemberType from ShopNum1_Member  WHERE MemLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetShopInfoByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "select ShopID,OpenTime,MemLoginID from ShopNum1_ShopInfo WHERE Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateMemberType(string guids, int memberType)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Member SET MemberType=",
				memberType,
				" WHERE MemLoginID in(select MemLoginID from dbo.ShopNum1_ShopInfo where Guid in(",
				guids,
				"))"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int RegistShopMember(ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string strProcedureName = "Pro_ShopNum1_RegistShopMember";
			string[] array = new string[41];
			string[] array2 = new string[41];
			array[0] = "@ShopName";
			array[1] = "@salesRange";
			array[2] = "@addressValue";
			array[3] = "@banner";
			array[4] = "@collectCount";
			array[5] = "@applyTime";
			array[6] = "@openTime";
			array[7] = "@modifyUser";
			array[8] = "@modifyTime";
			array[9] = "@shopCategoryID";
			array[10] = "@memberLoginID";
			array[11] = "@IsAudit";
			array[12] = "@IsDeleted";
			array[13] = "@regionCode";
			array[14] = "@shopID";
			array[15] = "@Name";
			array[16] = "@IdentityCard";
			array[17] = "@DetailAddress";
			array[18] = "@PostalCode";
			array[19] = "@Tel";
			array[20] = "@shopTemplateType";
			array[21] = "@CardImage";
			array[22] = "@shopRank";
			array[23] = "@RegistrationNum";
			array[24] = "@CompanName";
			array[25] = "@LegalPerson";
			array[26] = "@RegisteredCapital";
			array[27] = "@BusinessTerm";
			array[28] = "@BusinessScope";
			array[29] = "@BusinessLicense";
			array[30] = "@OrderID";
			array[31] = "@ShopUrl";
			array[32] = "@IdentityIsAudit";
			array[33] = "@CompanIsAudit";
			array[34] = "@Phone";
			array[35] = "@IsIntegralShop";
			array[36] = "@ShopType";
			array[37] = "@MainGoods";
			array[38] = "@Longitude";
			array[39] = "@Latitude";
			array[40] = "@SubstationID";
			array2[0] = shopNum1_ShopInfo.ShopName;
			array2[1] = shopNum1_ShopInfo.SalesRange;
			array2[2] = shopNum1_ShopInfo.AddressValue;
			array2[3] = shopNum1_ShopInfo.Banner;
			array2[4] = shopNum1_ShopInfo.CollectCount.ToString();
			array2[5] = shopNum1_ShopInfo.ApplyTime.ToString();
			array2[6] = shopNum1_ShopInfo.OpenTime.ToString();
			array2[7] = shopNum1_ShopInfo.ModifyUser;
			array2[8] = shopNum1_ShopInfo.ModifyTime.ToString();
			array2[9] = shopNum1_ShopInfo.ShopCategoryID.ToString();
			array2[10] = shopNum1_ShopInfo.MemLoginID;
			array2[11] = shopNum1_ShopInfo.IsAudit.ToString();
			array2[12] = shopNum1_ShopInfo.IsDeleted.ToString();
			array2[13] = shopNum1_ShopInfo.AddressCode.ToString();
			array2[14] = shopNum1_ShopInfo.ShopID.ToString();
			array2[15] = shopNum1_ShopInfo.Name;
			array2[16] = shopNum1_ShopInfo.IdentityCard;
			array2[17] = shopNum1_ShopInfo.Address;
			array2[18] = shopNum1_ShopInfo.PostalCode;
			array2[19] = shopNum1_ShopInfo.Tel;
			array2[20] = shopNum1_ShopInfo.TemplateType;
			array2[21] = shopNum1_ShopInfo.CardImage;
			array2[22] = shopNum1_ShopInfo.ShopRank.ToString();
			array2[23] = shopNum1_ShopInfo.RegistrationNum;
			array2[24] = shopNum1_ShopInfo.CompanName;
			array2[25] = shopNum1_ShopInfo.LegalPerson;
			array2[26] = shopNum1_ShopInfo.RegisteredCapital.ToString();
			array2[27] = shopNum1_ShopInfo.BusinessTerm;
			array2[28] = shopNum1_ShopInfo.BusinessScope;
			array2[29] = shopNum1_ShopInfo.BusinessLicense;
			array2[30] = shopNum1_ShopInfo.OrderID.ToString();
			array2[31] = shopNum1_ShopInfo.ShopUrl;
			array2[32] = shopNum1_ShopInfo.IdentityIsAudit.ToString();
			array2[33] = shopNum1_ShopInfo.CompanIsAudit.ToString();
			array2[34] = shopNum1_ShopInfo.Phone.ToString();
			array2[35] = shopNum1_ShopInfo.IsIntegralShop.ToString();
			array2[36] = shopNum1_ShopInfo.ShopType.ToString();
			array2[37] = shopNum1_ShopInfo.MainGoods.ToString();
			array2[38] = shopNum1_ShopInfo.Longitude.ToString();
			array2[39] = shopNum1_ShopInfo.Latitude.ToString();
			array2[40] = shopNum1_ShopInfo.SubstationID.ToString();
			return DatabaseExcetue.RunProcedure(strProcedureName, array, array2);
		}
		public int UpdateShopInfo(ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string[] array = new string[23];
			string[] array2 = new string[23];
			array[0] = "@shopname";
			array2[0] = shopNum1_ShopInfo.ShopName;
			array[1] = "@addressvalue";
			array2[1] = shopNum1_ShopInfo.AddressValue;
			array[2] = "@modifyuser";
			array2[2] = shopNum1_ShopInfo.ModifyUser;
			array[3] = "@modifytime";
			array2[3] = shopNum1_ShopInfo.ModifyTime.ToString();
			array[4] = "@shopcategory";
			array2[4] = shopNum1_ShopInfo.ShopCategory;
			array[5] = "@shopcategoryid";
			array2[5] = shopNum1_ShopInfo.ShopCategoryID;
			array[6] = "@addresscode";
			array2[6] = shopNum1_ShopInfo.AddressCode;
			array[7] = "@isaudit";
			array2[7] = shopNum1_ShopInfo.IsAudit.ToString();
			array[8] = "@name";
			array2[8] = shopNum1_ShopInfo.Name;
			array[9] = "@identitycard";
			array2[9] = shopNum1_ShopInfo.IdentityCard;
			array[10] = "@detailaddress";
			array2[10] = shopNum1_ShopInfo.Address;
			array[11] = "@postalcode";
			array2[11] = shopNum1_ShopInfo.PostalCode;
			array[12] = "@tel";
			array2[12] = shopNum1_ShopInfo.Tel;
			array[13] = "@cardimage";
			array2[13] = shopNum1_ShopInfo.CardImage;
			array[14] = "@memloginid";
			array2[14] = shopNum1_ShopInfo.MemLoginID;
			array[15] = "@RegistrationNum";
			array[16] = "@CompanName";
			array[17] = "@LegalPerson";
			array[18] = "@RegisteredCapital";
			array[19] = "@BusinessTerm";
			array[20] = "@BusinessScope";
			array[21] = "@BusinessLicense";
			array[22] = "@SubstationID";
			array2[15] = shopNum1_ShopInfo.RegistrationNum;
			array2[16] = shopNum1_ShopInfo.CompanName;
			array2[17] = shopNum1_ShopInfo.LegalPerson;
			array2[18] = shopNum1_ShopInfo.RegisteredCapital.ToString();
			array2[19] = shopNum1_ShopInfo.BusinessTerm;
			array2[20] = shopNum1_ShopInfo.BusinessScope;
			array2[21] = shopNum1_ShopInfo.BusinessLicense;
			array2[22] = shopNum1_ShopInfo.SubstationID;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopInfo", array, array2);
		}
		public int UpdateShopInfoDetail(ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string[] array = new string[22];
			string[] array2 = new string[22];
			array[0] = "@Name";
			array2[0] = shopNum1_ShopInfo.Name;
			array[1] = "@ShopName";
			array2[1] = shopNum1_ShopInfo.ShopName;
			array[2] = "@SalesRange";
			array2[2] = shopNum1_ShopInfo.SalesRange;
			array[3] = "@Email";
			array2[3] = shopNum1_ShopInfo.Email.ToString();
			array[4] = "@Tel";
			array2[4] = shopNum1_ShopInfo.Tel;
			array[5] = "@Phone";
			array2[5] = shopNum1_ShopInfo.Phone;
			array[6] = "@PostalCode";
			array2[6] = shopNum1_ShopInfo.PostalCode;
			array[7] = "@IdentityCard";
			array2[7] = shopNum1_ShopInfo.IdentityCard.ToString();
			array[8] = "@RegistrationNum";
			array2[8] = shopNum1_ShopInfo.RegistrationNum;
			array[9] = "@CompanName";
			array2[9] = shopNum1_ShopInfo.CompanName;
			array[10] = "@LegalPerson";
			array2[10] = shopNum1_ShopInfo.LegalPerson;
			array[11] = "@RegisteredCapital";
			array2[11] = shopNum1_ShopInfo.RegisteredCapital.ToString();
			array[12] = "@BusinessTerm";
			array2[12] = shopNum1_ShopInfo.BusinessTerm;
			array[13] = "@BusinessScope";
			array2[13] = shopNum1_ShopInfo.BusinessScope;
			array[14] = "@Address";
			array2[14] = shopNum1_ShopInfo.Address;
			array[15] = "@IsExpires";
			array2[15] = shopNum1_ShopInfo.IsExpires.ToString();
			array[16] = "@IsClose";
			array2[16] = shopNum1_ShopInfo.IsClose.ToString();
			array[17] = "@CompanyIntroduce";
			array2[17] = shopNum1_ShopInfo.CompanyIntroduce;
			array[18] = "@ShopIntroduce";
			array2[18] = shopNum1_ShopInfo.ShopIntroduce.ToString();
			array[19] = "@MemLoginID";
			array2[19] = shopNum1_ShopInfo.MemLoginID;
			array[20] = "@MainGoods";
			array2[20] = shopNum1_ShopInfo.MainGoods;
			array[21] = "@Memo";
			array2[21] = shopNum1_ShopInfo.Memo;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopInfoDetail", array, array2);
		}
		public int CheckShopName(string name)
		{
			string strProcedureName = "Pro_ShopNum1_CheckShopName";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@name";
			array2[0] = name;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, array, array2);
			int result;
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}
		public DataTable SearchEspecialShopList(string pagesize, string field)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialShopList", array, array2);
		}
		public DataTable SearchNewsShopList(string pagesize)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchNewsShopList", array, array2);
		}
		public int UpdateShopState(string guid, string field, string string_0)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@field";
			array2[1] = field;
			array[2] = "@num";
			array2[2] = string_0;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateShopState ", array, array2);
		}
		public bool SearchShop(string memloginID)
		{
			string strSql = string.Empty;
			strSql = "select MemLoginID from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memloginID + "'";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			return dataTable != null && dataTable.Rows.Count != 0;
		}
		public DataTable GetShopIDByMemLoginID(string MemLogin)
		{
			DataTable result = null;
			Dictionary<string, DataTable> shopInfoMessgae = this.GetShopInfoMessgae();
			if (shopInfoMessgae != null && shopInfoMessgae.ContainsKey(MemLogin))
			{
				result = shopInfoMessgae[MemLogin];
			}
			return result;
		}
		public string GetShopUrlByMemLoginID(string MemLogin)
		{
			Dictionary<string, DataTable> shopInfoMessgae = this.GetShopInfoMessgae();
			string result;
			if (shopInfoMessgae != null && shopInfoMessgae.ContainsKey(MemLogin))
			{
				DataTable dataTable = shopInfoMessgae[MemLogin];
				if (dataTable != null)
				{
					result = dataTable.Rows[0]["ShopUrl"].ToString();
					return result;
				}
			}
			result = "";
			return result;
		}
		public DataTable GetShopOpenShow(string ShopUrl)
		{
			Dictionary<string, DataTable> defaultShopMessgae = this.GetDefaultShopMessgae();
			DataTable result;
			if (defaultShopMessgae != null && defaultShopMessgae.ContainsKey(ShopUrl))
			{
				result = defaultShopMessgae[ShopUrl];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public Dictionary<string, DataTable> GetDefaultShopMessgae()
		{
			Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
			Cache cache = HttpRuntime.Cache;
			Dictionary<string, DataTable> result;
			try
			{
				if (cache["GetDefaultShopMessgae"] != null)
				{
					dictionary = (cache["GetDefaultShopMessgae"] as Dictionary<string, DataTable>);
				}
				else
				{
					string strSql = string.Empty;
					strSql = "select IsExpires,ShopUrl,IsClose,OpenTime,ShopID from ShopNum1_ShopInfo WHERE isclose=0 And IsAudit=1";
					DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
					if (dataTable != null && dataTable.Rows.Count > 0)
					{
						foreach (DataRow dataRow in dataTable.Rows)
						{
							string key = dataRow["ShopUrl"].ToString();
							if (!dictionary.ContainsKey(key))
							{
								DataTable dataTable2 = dataTable.Clone();
								DataRow dataRow2 = dataTable2.NewRow();
								dataRow2["ShopID"] = dataRow["ShopID"];
								dataRow2["ShopUrl"] = dataRow["ShopUrl"];
								dataRow2["OpenTime"] = dataRow["OpenTime"];
								dataRow2["IsExpires"] = dataRow["IsExpires"];
								dataRow2["IsClose"] = dataRow["IsClose"];
								dataTable2.Rows.Add(dataRow2);
								dictionary.Add(key, dataTable2);
							}
						}
					}
					cache.Add("GetDefaultShopMessgae", dictionary, null, DateTime.Now.AddHours(20.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
				result = dictionary;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public Dictionary<string, DataTable> GetShopInfoMessgae()
		{
			Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
			Cache cache = HttpRuntime.Cache;
			Dictionary<string, DataTable> result;
			try
			{
				if (cache["GetShopInfoMessgae"] != null)
				{
					dictionary = (cache["GetShopInfoMessgae"] as Dictionary<string, DataTable>);
				}
				else
				{
					string strSql = string.Empty;
					strSql = "select ShopID,ShopUrl,OpenTime,ShopName,MemLoginID from ShopNum1_ShopInfo WHERE isclose=0 And IsAudit=1";
					DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
					if (dataTable != null && dataTable.Rows.Count > 0)
					{
						foreach (DataRow dataRow in dataTable.Rows)
						{
							string key = dataRow["MemLoginID"].ToString();
							if (!dictionary.ContainsKey(key))
							{
								DataTable dataTable2 = dataTable.Clone();
								DataRow dataRow2 = dataTable2.NewRow();
								dataRow2["ShopID"] = dataRow["ShopID"];
								dataRow2["ShopUrl"] = dataRow["ShopUrl"];
								dataRow2["OpenTime"] = dataRow["OpenTime"];
								dataRow2["ShopName"] = dataRow["ShopName"];
								dataRow2["MemLoginID"] = dataRow["MemLoginID"];
								dataTable2.Rows.Add(dataRow2);
								dictionary.Add(key, dataTable2);
							}
						}
					}
					cache.Add("GetShopInfoMessgae", dictionary, null, DateTime.Now.AddHours(20.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
				result = dictionary;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public string GetShopURLByShopID(string shopid)
		{
			Dictionary<string, DataTable> shopInfoIdMessgae = this.GetShopInfoIdMessgae();
			string result;
			if (shopInfoIdMessgae != null && shopInfoIdMessgae.ContainsKey(shopid))
			{
				DataTable dataTable = shopInfoIdMessgae[shopid];
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = dataTable.Rows[0]["ShopUrl"].ToString();
					return result;
				}
			}
			result = "";
			return result;
		}
		public string GetShopOpenTimeByShopID(string shopid)
		{
			Dictionary<string, DataTable> shopInfoIdMessgae = this.GetShopInfoIdMessgae();
			string result;
			if (shopInfoIdMessgae != null && shopInfoIdMessgae.ContainsKey(shopid))
			{
				DataTable dataTable = shopInfoIdMessgae[shopid];
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = dataTable.Rows[0]["OpenTime"].ToString();
					return result;
				}
			}
			result = "";
			return result;
		}
		public string GetShopMemLoginIdByShopID(string MemloginId)
		{
			Dictionary<string, DataTable> shopInfoIdMessgae = this.GetShopInfoIdMessgae();
			string result;
			if (shopInfoIdMessgae != null && shopInfoIdMessgae.ContainsKey(MemloginId))
			{
				DataTable dataTable = shopInfoIdMessgae[MemloginId];
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = dataTable.Rows[0]["MemLoginID"].ToString();
					return result;
				}
			}
			result = "";
			return result;
		}
		public Dictionary<string, DataTable> GetShopInfoIdMessgae()
		{
			Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
			Cache cache = HttpRuntime.Cache;
			Dictionary<string, DataTable> result;
			try
			{
				if (cache["shopnum1_shopinfoIdCache"] != null)
				{
					dictionary = (cache["shopnum1_shopinfoIdCache"] as Dictionary<string, DataTable>);
				}
				else
				{
					string strSql = string.Empty;
					strSql = "select ShopID,ShopUrl,OpenTime,MemloginID from ShopNum1_ShopInfo  WHERE isclose=0 And IsAudit=1";
					DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
					if (dataTable != null && dataTable.Rows.Count > 0)
					{
						foreach (DataRow dataRow in dataTable.Rows)
						{
							string key = dataRow["ShopID"].ToString();
							if (!dictionary.ContainsKey(key))
							{
								DataTable dataTable2 = dataTable.Clone();
								DataRow dataRow2 = dataTable2.NewRow();
								dataRow2["ShopID"] = dataRow["ShopID"];
								dataRow2["ShopUrl"] = dataRow["ShopUrl"];
								dataRow2["OpenTime"] = dataRow["OpenTime"];
								dataRow2["MemloginID"] = dataRow["MemloginID"];
								dataTable2.Rows.Add(dataRow2);
								dictionary.Add(key, dataTable2);
							}
						}
					}
					cache.Add("shopnum1_shopinfoIdCache", dictionary, null, DateTime.Now.AddHours(12.0), TimeSpan.Zero, CacheItemPriority.High, null);
				}
				result = dictionary;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public string GetShopYuMingByShopID(string ShopID)
		{
			string text = string.Empty;
			text += "  select  DomainName from ShopNum1_SubstationManage where SubstationID   ";
			text += "  in    ";
			text += "  (    ";
			text += "  select  SubstationID from ShopNum1_ShopInfo      ";
			text = text + "  where ShopID ='" + ShopID + "'    ";
			text += "  )    ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public DataTable GetEnsureImagePathBymemberLoginID(string memberLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memberLoginID";
			array2[0] = memberLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetEnsureImagePathBymemberLoginID", array, array2);
		}
		public DataTable GetAllShopInfoByGuid(string guids)
		{
			string strSql = string.Empty;
			strSql = "select * from ShopNum1_ShopInfo where Guid IN(" + guids + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetNewShopInfoByShowCount(string ShowCount)
		{
			string strSql = string.Empty;
			strSql = "Select Top " + ShowCount + "  ShopID,ShopName,Banner,ShopReputation from ShopNum1_ShopInfo Where IsAudit=1 And IsDeleted=0 Order by OrderID";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateShopReputationByMemLoginID(string memLoginID, int score)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE dbo.ShopNum1_ShopInfo SET ShopReputation=ShopReputation+(",
				score,
				") WHERE MemLoginID='",
				memLoginID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetMemberInfoByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "select A.Name,A.MemLoginID,A.MemberType from ShopNum1_Member AS A,ShopNum1_ShopInfo AS B where A.MemLoginID=B.MemLoginID AND B.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public void UpdateDate(string guid, string time)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_ShopInfo SET OpenTime ='",
				time,
				"' where Guid IN(",
				guid,
				")"
			});
			DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CheckShopURLIsRepeat(string shopurl)
		{
			string strSql = string.Empty;
			strSql = "SELECT COUNT(*) AS ShopUrl FROM ShopNum1_ShopInfo WHERE ShopUrl ='" + shopurl + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdataShopURLByGuid(string guid, string shopurl)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_ShopInfo SET ShopUrl ='",
				shopurl,
				"' where Guid ='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopCategoryApplyInfo(string ShopName, string memberLoginID, string ShopCategoryCode, string IsAudit, string StartTime, string EndTime)
		{
			string text = string.Empty;
			text = "SELECT A.*,B.ShopName,B.ShopUrl FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID ";
			if (!string.IsNullOrEmpty(ShopName))
			{
				text = text + " AND B.ShopName='" + ShopName.Trim() + "'";
			}
			if (!string.IsNullOrEmpty(memberLoginID))
			{
				text = text + " AND A.ShopID='" + memberLoginID.Trim() + "'";
			}
			if (ShopCategoryCode.Trim() != "-1")
			{
				text = text + " AND A.OldShopCategoryCode='" + ShopCategoryCode.Trim() + "'";
			}
			if (!string.IsNullOrEmpty(IsAudit))
			{
				if (IsAudit == "-2")
				{
					text += " AND A.IsAudit IN (0,2) ";
				}
				else
				{
					text = text + " AND A.IsAudit=" + IsAudit.Trim();
				}
			}
			if (!string.IsNullOrEmpty(StartTime))
			{
				text = text + " AND A.ApplyTime>='" + StartTime.Trim() + "'";
			}
			if (!string.IsNullOrEmpty(EndTime))
			{
				text = text + " AND A.ApplyTime<='" + EndTime.Trim() + "'";
			}
			text += " ORDER BY A.ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteShopCategoryApply(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_ApplyCateGory WHERE GUID IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdataShopCategoryApplyIsAudit(string guids, string isAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Shop_ApplyCateGory SET IsAudit=",
				isAudit,
				" WHERE Guid IN (",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopCategoryInfoByGuid(string guids)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.*,B.ShopName FROM ShopNum1_Shop_ApplyCateGory AS A,ShopNum1_ShopInfo AS B WHERE B.MemLoginID=A.ShopID AND A.Guid IN (" + guids + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateShopCategoryAndBrandByGuids(string guids, string ShopCategoryName, string ShopCategoryCode, string BrandName, string BrandGuid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_ShopInfo SET ShopBrandName='",
				BrandName,
				"', ShopBrandGuid='",
				BrandGuid,
				"', ShopCategory='",
				ShopCategoryName,
				"', ShopCategoryID='",
				ShopCategoryCode,
				"' where MemLoginID = (SELECT ShopID FROM ShopNum1_Shop_ApplyCateGory WHERE Guid =",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetShopPayMentType(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_GetShopPayMentType", array, array2).ToString();
		}
		public int InsertShopNav(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_InsertShopNav", array, array2));
		}
		public string GetShopGuid(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "select Guid from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public int Delete(string guid, string memLoginID)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "delete from ShopNum1_ShopProductRelationProp  WHERE Memlogid = '" + memLoginID + "'";
			item = "delete from ShopNum1_ShopInfo  WHERE Guid = " + guid;
			list.Add(item);
			item = "delete from ShopNum1_OrderInfo  WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_OrderOperateLog WHERE CreateUser = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_OrderProduct WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Refund WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ApplyCateGory WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ApplyEnsure WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ApplyShopRank WHERE MemberLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Cart WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Coupon WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Image WHERE CreateUser = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ImageCategory WHERE CreateUser = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Link WHERE ShopMemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_MessageBoard WHERE ReplyUser = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_News WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_NewsCategory WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_OnlineService WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_OtherOrderInfo WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Product WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ProductCategory WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ProductComment WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ScoreProduct WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_ScoreProductCategory WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_StarGuide WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_UserDefinedColumn WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_Video WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_Shop_VideoCategory WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ShopCollect WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ShopPayment WHERE memloginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ShopProductConsult WHERE ShopID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ShopURLManage WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_SpecificationProductImage WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_SpecificationProudct WHERE MemLoginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_SpecificationProudctPropName WHERE memloginID = '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ZtcApply    WHERE   MemberID= '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ZtcGoods    WHERE   MemberID= '" + memLoginID + "'";
			list.Add(item);
			item = "delete from ShopNum1_ScoreOrderInfo    WHERE   ShopMemLoginID= '" + memLoginID + "'";
			item = "update ShopNum1_member set membertype=1  WHERE Memlogid = '" + memLoginID + "'";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int GetShopCountByCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			object value = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_ShopInfoGetShopCountByCode", array, array2);
			return Convert.ToInt32(value);
		}
		public int GetShopCountByCode(string code, string SubstationID)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@code";
			array2[0] = code;
			array[1] = "@SubstationID";
			array2[1] = SubstationID;
			object value = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_ShopInfoGetShopCountByCode1", array, array2);
			return Convert.ToInt32(value);
		}
		public DataTable Search(string memberLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select A.*, B.Name AS RankName,B.MaxFileCount as BmaxFileCount  from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopRank AS B on A.ShopRank=B.Guid ");
			stringBuilder.Append(" AND A.MemLoginID = '" + memberLoginID + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopOpentimeByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "select ShopID,OpenTime from ShopNum1_ShopInfo WHERE MemLoginID ='" + MemLoginID + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetShopURLByAddressCode(string addressCode)
		{
			string text = string.Empty;
			text = "SELECT  ShopUrl  FROM  ShopNum1_ShopInfo where 1=1 ";
			if (!string.IsNullOrEmpty(addressCode))
			{
				text = text + "  AND AddressCode='" + addressCode + "'";
			}
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
			string result;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0]["ShopUrl"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public DataSet SearchShopList(string pageindex, string pagesize, string regioncode, string shopcategoryid, string name, string memberloginid)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@pageindex";
			array2[0] = pageindex;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@AddressCode";
			array2[2] = regioncode;
			array[3] = "@ShopCategoryID";
			array2[3] = shopcategoryid;
			array[4] = "@Name";
			array2[4] = name;
			array[5] = "@MemLoginID";
			array2[5] = memberloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchShopList", array, array2);
		}
		public DataSet SearchShopList(string addresscode, string ShopCategoryID, string ordername, string soft, string shopName, string memberid, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername == "SaleSum")
			{
				ordername = "B.SaleSum";
			}
			if (ordername == "CreateTime")
			{
				ordername = "A.CreateTime";
			}
			if (ordername == "ClickCount")
			{
				ordername = "A.ClickCount";
			}
			if (ordername == "ShopReputation")
			{
				ordername = "A.ShopReputation";
			}
			if (ShopCategoryID != "-1")
			{
				text = " A.ShopCategoryID like '" + Operator.FilterString(ShopCategoryID) + "%'";
			}
			else
			{
				text = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (shopName != "-1" && !string.IsNullOrEmpty(shopName))
			{
				text = text + " And A.ShopName like '%" + Operator.FilterString(shopName) + "%' ";
			}
			if (memberid != "-1")
			{
				text = text + "And A.MemLoginID like '%" + Operator.FilterString(memberid) + "%' ";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = "(select pic from ShopNum1_ShopRank where guid=a.ShopRank)AS mrankpic,isnull(HaoPingLV,0) AS HaoPingLV,ShopSpeed,ShopAttitude,ShopCharacter,isnull(SpeedBL,0) AS SpeedBL,isnull(AttitudeBL,0) AS AttitudeBL,isnull(CharacterBL,0) AS CharacterBL,ProductNum,SaleSum,pic,A.Guid,A.ShopName,A.ShopUrl,A.SalesRange,A.ShopID,A.Name,A.Banner,A.MemLoginID,A.AddressValue,A.AddressCode,A.MainGoods ";
			array[3] = "@ordername";
			array2[3] = ordername;
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@sdesc";
			array2[5] = soft;
			array[6] = "@isreturcount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageShops", array, array2);
		}
		public DataSet SearchShopList(string addresscode, string ShopCategoryID, string ordername, string soft, string shopName, string memberid, string perpagenum, string current_page, string isreturcount, string SubstationID)
		{
			string text = SubstationID;
			if (SubstationID.IndexOf(',') != -1)
			{
				text = SubstationID.Split(new char[]
				{
					','
				})[0].ToString();
			}
			string text2 = string.Empty;
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername == "SaleSum")
			{
				ordername = "B.SaleSum";
			}
			if (ordername == "CreateTime")
			{
				ordername = "A.CreateTime";
			}
			if (ordername == "ClickCount")
			{
				ordername = "A.ClickCount";
			}
			if (ordername == "ShopReputation")
			{
				ordername = "A.ShopReputation";
			}
			if (ShopCategoryID != "-1")
			{
				text2 = " A.ShopCategoryID like '" + Operator.FilterString(ShopCategoryID) + "%'";
			}
			else
			{
				text2 = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text2 = text2 + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (text != "-1")
			{
				text2 = text2 + "And A.SubstationID = '" + text + "' ";
			}
			if (shopName != "-1" && !string.IsNullOrEmpty(shopName))
			{
				text2 = text2 + " And A.ShopName like '%" + Operator.FilterString(shopName) + "%' ";
			}
			if (memberid != "-1")
			{
				text2 = text2 + "And A.MemLoginID like '%" + Operator.FilterString(memberid) + "%' ";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = "(select pic from ShopNum1_ShopRank where guid=a.ShopRank)AS mrankpic,isnull(HaoPingLV,0) AS HaoPingLV,ShopSpeed,ShopAttitude,ShopCharacter,isnull(SpeedBL,0) AS SpeedBL,isnull(AttitudeBL,0) AS AttitudeBL,isnull(CharacterBL,0) AS CharacterBL,ProductNum,SaleSum,pic,A.Guid,A.ShopName,A.ShopUrl,A.SalesRange,A.ShopID,A.Name,A.Banner,A.MemLoginID,A.AddressValue,A.AddressCode,A.MainGoods ";
			array[3] = "@ordername";
			array2[3] = ordername;
			array[4] = "@searchname";
			array2[4] = text2;
			array[5] = "@sdesc";
			array2[5] = soft;
			array[6] = "@isreturcount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageShops", array, array2);
		}
		public DataTable SearchEspecialShop(string pagesize, string field)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialShop", array, array2);
		}
		public DataTable SearchEspecialShop(string pagesize, string field, string SubstationID)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			array[2] = "@SubstationID";
			array2[2] = SubstationID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialShop1", array, array2);
		}
		public string CheckType(string strtype)
		{
			string strSql = "select shopcategoryid from ShopNum1_ShopInfo  WHERE  shopcategoryid  = '" + strtype + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetTypeCategoryId()
		{
			string strSql = "select shopcategoryid from ShopNum1_ShopInfo";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetShopid(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "select Shopid from ShopNum1_ShopInfo  WHERE MemLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable Search2(string ShopName, string memberLoginID, string IsAudit, string ShopType, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ShopType,shopcategoryid,*  from  ShopNum1_ShopInfo  a  where 1=1 ");
			if (Operator.FormatToEmpty(ShopName) != string.Empty)
			{
				stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
			}
			if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
			}
			stringBuilder.Append(" AND A.IsAudit=" + IsAudit);
			if (ShopType != "-1")
			{
				stringBuilder.Append(" AND A.ShopType =" + ShopType);
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND A.SubstationID ='" + SubstationID + "'");
			}
			stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string ShopName, string memberLoginID, string IsAudit, string ShopType, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select A.*,C.Name as CName,IsVisits from ShopNum1_ShopInfo AS A inner join ShopNum1_ShopCategory AS C ON a.shopcategoryid=c.code  ");
			if (Operator.FormatToEmpty(ShopName) != string.Empty)
			{
				stringBuilder.Append(" AND A.ShopName like '%" + Operator.FilterString(ShopName) + "%'");
			}
			if (Operator.FormatToEmpty(memberLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID like '%" + memberLoginID + "%'");
			}
			stringBuilder.Append(" AND A.IsAudit=" + IsAudit);
			if (ShopType != "-1")
			{
				stringBuilder.Append(" AND A.ShopType =" + ShopType);
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND A.SubstationID ='" + SubstationID + "'");
			}
			stringBuilder.Append("  ORDER BY A.ApplyTime DESC  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int UpdateShopState(string guid, string AuditFailedReason, string OperateUser, string AuditTime, int IsAudit)
		{
			string text = string.Empty;
			text = text + "   UPDATE    ShopNum1_ShopInfo    SET  AuditFailedReason='" + Operator.FilterString(AuditFailedReason) + "',   ";
			text = text + "   OperateUser='" + OperateUser + "',     ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   IsAudit='",
				IsAudit,
				"',     "
			});
			text = text + "   AuditTime='" + AuditTime + "'     ";
			text = text + "   WHERE   Guid='" + guid + "'       ";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetShopByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "SELECT  *   FROM  ShopNum1_ShopInfo WHERE     MemLoginID ='" + MemLoginID + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateShop(string MemLoginID, ShopNum1_ShopInfo shopNum1_ShopInfo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopInfo   SET  AddressCode  ='",
				Operator.FilterString(shopNum1_ShopInfo.AddressCode),
				"', ShopCategoryID  ='",
				Operator.FilterString(shopNum1_ShopInfo.ShopCategoryID),
				"', ShopName  ='",
				Operator.FilterString(shopNum1_ShopInfo.ShopName),
				"', SalesRange  ='",
				Operator.FilterString(shopNum1_ShopInfo.SalesRange),
				"', AddressValue  ='",
				Operator.FilterString(shopNum1_ShopInfo.AddressValue),
				"', ModifyUser  ='",
				shopNum1_ShopInfo.ModifyUser,
				"', ModifyTime  ='",
				shopNum1_ShopInfo.ModifyTime,
				"', ShopCategory  ='",
				shopNum1_ShopInfo.ShopCategory,
				"',  IdentityCard  ='",
				shopNum1_ShopInfo.IdentityCard,
				"',  Address  ='",
				Operator.FilterString(shopNum1_ShopInfo.Address),
				"',  MainGoods  ='",
				Operator.FilterString(shopNum1_ShopInfo.MainGoods),
				"',  PostalCode  ='",
				Operator.FilterString(shopNum1_ShopInfo.PostalCode),
				"',  CardImage  ='",
				shopNum1_ShopInfo.CardImage,
				"',  TemplateType  ='",
				shopNum1_ShopInfo.TemplateType,
				"',  BusinessLicense  ='",
				shopNum1_ShopInfo.BusinessLicense,
				"',  Phone  ='",
				Operator.FilterString(shopNum1_ShopInfo.Phone),
				"',  Tel  ='",
				Operator.FilterString(shopNum1_ShopInfo.Tel),
				"',   SubstationID  ='",
				Operator.FilterString(shopNum1_ShopInfo.SubstationID),
				"',  ShopType  ='",
				shopNum1_ShopInfo.ShopType,
				"',  AuditFailedReason  ='',  OperateUser  ='',  IsAudit  =0 WHERE MemLoginID='",
				MemLoginID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopUrlByAddressCode(string AddressCode)
		{
			string text = string.Empty;
			text = "select ShopUrl from  ShopNum1_ShopInfo where AddressCode ='" + AddressCode + "'";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetShopRankByMemLoginID(string MemLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = MemLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopRankByMemLoginID", array, array2);
		}
		public DataTable GetOpenTimeByShopID(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOpenTimeByShopID", array, array2);
		}
		public DataTable SearchShopSalesClickCount(string shophost, string shopname, string startdate, string enddate)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shophost";
			array2[0] = shophost;
			array[1] = "@shopname";
			array2[1] = shopname;
			array[2] = "@startdate";
			array2[2] = startdate;
			array[3] = "@enddate";
			array2[3] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopSalesClickCount", array, array2);
		}
		public DataTable SearchShopSalesClickCount(string shophost, string shopname, string startdate, string enddate, string SubstationID)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@shophost";
			array2[0] = shophost;
			array[1] = "@shopname";
			array2[1] = shopname;
			array[2] = "@SubstationID";
			array2[2] = SubstationID;
			array[3] = "@startdate";
			array2[3] = startdate;
			array[4] = "@enddate";
			array2[4] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopSalesClickCount1", array, array2);
		}
		public DataTable GetSystemRecommendShop(string IsSystemRecommend, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsSystemRecommend != "-1")
			{
				text = text + "       AND IsSystemRecommend=" + IsSystemRecommend + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetAgentRecommendShop(string IsRecommend, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount, string SubstationID)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsRecommend != "-1")
			{
				text = text + "       AND  IsRecommend=" + IsRecommend + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			if (SubstationID != "-1")
			{
				text = text + "       AND     SubstationID='" + SubstationID + "'      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetSystemHotShop(string IsSystemHot, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsSystemHot != "-1")
			{
				text = text + "       AND   IsSystemHot=" + IsSystemHot + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetAgentHotShop(string IsSystemHot, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount, string SubstationID)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsSystemHot != "-1")
			{
				text = text + "       AND     IsHot=" + IsSystemHot + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			if (SubstationID != "-1")
			{
				text = text + "       AND     SubstationID='" + SubstationID + "'      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetAllShopList(string ShopCategoryID, string SubstationID, int int_0, int IsRecommend, string orderWord, string orderType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top " + int_0 + " * from ShopNum1_ShopInfo where 1=1 And IsAudit=1 And isclose=0 ");
			if (Operator.FormatToEmpty(ShopCategoryID) != string.Empty)
			{
				stringBuilder.Append(" AND ShopCategoryID like '" + Operator.FilterString(ShopCategoryID) + "%'");
			}
			if (Operator.FormatToEmpty(SubstationID) != string.Empty)
			{
				stringBuilder.Append(" AND SubstationID  ='" + Operator.FilterString(SubstationID) + "'");
			}
			if (IsRecommend != -1)
			{
				stringBuilder.Append(" AND  IsRecommend =" + IsRecommend + "    ");
			}
			stringBuilder.Append(string.Concat(new string[]
			{
				"  ORDER BY ",
				orderWord,
				"  ",
				orderType,
				"    "
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchAllMemID(int IsDeleted)
		{
			return DatabaseExcetue.ReturnDataTable("select MemLoginID from ShopNum1_ShopInfo where IsDeleted=" + IsDeleted);
		}
		public DataTable GetSystemRecommendShop(string IsSystemRecommend, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount, string shoptype)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsSystemRecommend != "-1")
			{
				text = text + "       AND IsSystemRecommend=" + IsSystemRecommend + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			if (shoptype != "-1")
			{
				text = text + "       AND     ShopType=" + shoptype + "      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable GetAgentRecommendShop(string IsRecommend, string IsAudit, string IsDeleted, string IsClose, string orderWord, string orderType, string showCount, string SubstationID, string shoptype)
		{
			string text = string.Empty;
			text = "      SELECT TOP " + showCount + "  Name,ShopName,ShopID,ShopUrl,Address,Banner,MemLoginID,MainGoods,SubstationID  FROM ShopNum1_ShopInfo  WHERE 1=1           ";
			if (IsRecommend != "-1")
			{
				text = text + "       AND  IsRecommend=" + IsRecommend + "      ";
			}
			if (IsAudit != "-1")
			{
				text = text + "       AND  IsAudit=" + IsAudit + "      ";
			}
			if (IsDeleted != "-1")
			{
				text = text + "       AND   IsDeleted=" + IsDeleted + "      ";
			}
			if (IsClose != "-1")
			{
				text = text + "       AND    IsClose=" + IsClose + "      ";
			}
			if (SubstationID != "-1")
			{
				text = text + "       AND     SubstationID='" + SubstationID + "'      ";
			}
			if (shoptype != "-1")
			{
				text = text + "       AND     ShopType=" + shoptype + "      ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"        ORDER  BY  ",
				orderWord,
				"    ",
				orderType,
				"      "
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
	}
}
