using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Ensure_Action : IShop_Ensure_Action
	{
		public DataTable GetShopEnsureList(string name)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@name";
			array2[0] = name;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureList", array, array2);
		}
		public int Add(ShopNum1_ShopEnsure shopNum1_ShopEnsure)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"INSERT INTO ShopNum1_ShopEnsure( Name, ImagePath, Href, Remark, EnsureMoney  ) VALUES (  '",
				Operator.FilterString(shopNum1_ShopEnsure.Name),
				"',  '",
				shopNum1_ShopEnsure.ImagePath,
				"',  '",
				Operator.FilterString(shopNum1_ShopEnsure.Href),
				"',  '",
				Operator.FilterString(shopNum1_ShopEnsure.Remark),
				"',  '",
				Operator.FilterString(shopNum1_ShopEnsure.EnsureMoney),
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_ShopEnsure shopNum1_ShopEnsure)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopEnsure SET  Name='",
				Operator.FilterString(shopNum1_ShopEnsure.Name),
				"', ImagePath='",
				shopNum1_ShopEnsure.ImagePath,
				"', Href='",
				Operator.FilterString(shopNum1_ShopEnsure.Href),
				"', Remark='",
				Operator.FilterString(shopNum1_ShopEnsure.Remark),
				"', EnsureMoney='",
				Operator.FilterString(shopNum1_ShopEnsure.EnsureMoney),
				"'WHERE id=",
				shopNum1_ShopEnsure.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Del(string string_0)
		{
			string strSql = "delete from ShopNum1_ShopEnsure where ID IN (" + string_0 + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchEnsureApply_List(string name, string isAudit, string shopid)
		{
			string text = string.Empty;
			text = "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.SubstationID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + "AND B.Name='" + name + "'";
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					text += "AND A.IsAudit IN ('0','2') ";
				}
				else
				{
					text = text + "AND A.IsAudit='" + isAudit + "'";
				}
			}
			if (Operator.FormatToEmpty(shopid) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopid + "' ";
			}
			text += "ORDER BY ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchEnsureApply_ListNew(string name, string isAudit, string shopid, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.SubstationID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + "AND B.Name='" + name + "'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  c.SubstationID='" + SubstationID + "'";
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					text += "AND A.IsAudit IN ('0','2') ";
				}
				else
				{
					text = text + "AND A.IsAudit='" + isAudit + "'";
				}
			}
			if (Operator.FormatToEmpty(shopid) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopid + "' ";
			}
			text += "ORDER BY ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchEnsureApply_List(string name, string MemberLoginID, string isAudit, string shopid)
		{
			string text = string.Empty;
			text = "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + "AND B.Name='" + name + "'";
			}
			if (Operator.FormatToEmpty(MemberLoginID) != string.Empty)
			{
				text = text + "AND  a.MemberLoginID='" + MemberLoginID + "'";
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					text += "AND A.IsAudit IN ('0','2') ";
				}
				else
				{
					text = text + "AND A.IsAudit='" + isAudit + "'";
				}
			}
			if (Operator.FormatToEmpty(shopid) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopid + "' ";
			}
			text += "ORDER BY ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchEnsureApply_ListNew(string name, string MemberLoginID, string isAudit, string shopid, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT a.Guid, b.Name, a.ApplyTime, a.IsAudit, a.Remarks, a.PaymentName, a.IsPayMent, a.ShopID, c.SubstationID, c.ShopID as ShopUrlID from ShopNum1_Shop_ApplyEnsure as a  left join ShopNum1_ShopEnsure as b on a.EnsureID=b.ID  left join shopnum1_shopinfo as c on a.MemberLoginID=c.MemLoginID WHERE 1=1 ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + "AND B.Name='" + name + "'";
			}
			if (Operator.FormatToEmpty(MemberLoginID) != string.Empty)
			{
				text = text + "AND  a.MemberLoginID='" + MemberLoginID + "'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  c.SubstationID='" + SubstationID + "'";
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					text += "AND A.IsAudit IN ('0','2') ";
				}
				else
				{
					text = text + "AND A.IsAudit='" + isAudit + "'";
				}
			}
			if (Operator.FormatToEmpty(shopid) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopid + "' ";
			}
			text += "ORDER BY ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdataIsAuditByGuid(string guid, int isAudit)
		{
			string strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_ApplyEnsure SET IsAudit=",
				isAudit,
				" WHERE Guid in (",
				guid,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchShopEnsureListNew(string memberLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memberLoginID";
			array2[0] = memberLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetShopapplyEnsureListNew]", array, array2);
		}
		public DataTable GetShopEnsure(int int_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = int_0.ToString();
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsure", array, array2);
		}
		public int UpdateShopEnsureList(string memloginid, string ensureid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@ensureid";
			array2[1] = ensureid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopEnsureList", array, array2);
		}
		public DataTable SearchShopEnsureList(string string_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = string_0;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchShopEnsureList", array, array2);
		}
		public DataTable GetShopEnsureListNew(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureListNew", array, array2);
		}
		public int ApplyShopEnsure(ShopNum1_Shop_ApplyEnsure applyEnsure)
		{
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@guid";
			array2[0] = applyEnsure.Guid.ToString();
			array[1] = "@ensureid";
			array2[1] = applyEnsure.EnsureID.ToString();
			array[2] = "@applytime";
			array2[2] = applyEnsure.ApplyTime.ToString();
			array[3] = "@createuser";
			array2[3] = applyEnsure.CreateUser;
			array[4] = "@shopid";
			array2[4] = applyEnsure.ShopID;
			array[5] = "@memberLoginID";
			array2[5] = applyEnsure.MemberLoginID;
			array[6] = "@ispayment";
			array2[6] = applyEnsure.IsPayMent.ToString();
			array[7] = "@IsAudit";
			array2[7] = applyEnsure.IsAudit.ToString();
			array[8] = "@paymentname";
			array2[8] = applyEnsure.PaymentName;
			array[9] = "@paymenttype";
			array2[9] = applyEnsure.PaymentType.ToString();
			array[10] = "@remarks";
			array2[10] = applyEnsure.Remarks;
			return DatabaseExcetue.RunProcedure("Pro_Shop_ApplyShopEnsure", array, array2);
		}
		public DataTable GetCheckedShopEnsureList(string ensureid, string shopid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ensureid";
			array2[0] = ensureid;
			array[1] = "@shopid";
			array2[1] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCheckedShopEnsureList", array, array2);
		}
		public int DelShopEnsureList(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DelShopEnsureList", array, array2);
		}
		public DataTable SearchEnsureApply(string shopid)
		{
			string strSql = string.Empty;
			strSql = "SELECT b.Name, b.ImagePath, a.ShopID FROM ShopNum1_Shop_ApplyEnsure AS a ,ShopNum1_ShopEnsure AS b  WHERE a.EnsureID=b.ID AND IsAudit=1 AND ShopID='" + shopid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdataEnsurePayStatusByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataEnsurePayStatusByGuid", array, array2);
		}
		public int UpdataEnsurePayMentByGuid(string guid, string PayMentType, string PayMentName)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@PayMentType";
			array2[1] = PayMentType;
			array[2] = "@PayMentName";
			array2[2] = PayMentName;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataEnsurePayMentByGuid", array, array2);
		}
		public int CheckIsPayMentByID(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = new Guid(guid).ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_CheckEnsureIsPayMentByGuid", array, array2);
		}
		public DataTable GetShopEnsureListByMemberLoginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopEnsureListByMemberLoginID", array, array2);
		}
		public DataTable GetShopapplyEnsureList(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyEnsureList", array, array2);
		}
		public DataTable GetShopapplyEnsureListNew(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyEnsureListNew", array, array2);
		}
		public DataTable GetShopapplyEnsure(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopApplyEnsure", array, array2);
		}
		public DataTable GetShopNotApplyEnsure(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopNotApplyEnsure", array, array2);
		}
		public DataTable GetShopapplyNoRegShopEnsureList(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopapplyNoRegShopEnsureList", array, array2);
		}
		public DataTable GetEnsureMoney(Guid guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  SELECT   a.EnsureID ,a.MemberLoginID , b.EnsureMoney  ");
			stringBuilder.Append("  FROM  ShopNum1_Shop_ApplyEnsure  as a ,");
			stringBuilder.Append("   ShopNum1_ShopEnsure as b ");
			stringBuilder.Append("  where a.Guid='" + guid + "'");
			stringBuilder.Append("  and a.EnsureID=b.id   ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
