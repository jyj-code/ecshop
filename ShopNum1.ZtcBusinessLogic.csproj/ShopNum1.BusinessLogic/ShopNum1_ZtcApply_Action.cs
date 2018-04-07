using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ZtcApply_Action : IShopNum1_ZtcApply_Action
	{
		public int Add(ShopNum1_ZtcApply ZtcApply)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT ShopNum1_ZtcApply(  ProductGuid, ProductName, MemberID, ShopID, ShopName, Ztc_Money, Remark, StartTime, ApplyTime, PayState, AuditState, AuditTime, OperateUser, OperateRemark, Type, CreateUser, CreateTime, SubstationID, IsDeleted ) VALUES (  '",
				Operator.FilterString(ZtcApply.ProductGuid),
				"',  '",
				Operator.FilterString(ZtcApply.ProductName),
				"',  '",
				Operator.FilterString(ZtcApply.MemberID),
				"',  '",
				Operator.FilterString(ZtcApply.ShopID),
				"',  '",
				Operator.FilterString(ZtcApply.ShopName),
				"',  '",
				Operator.FilterString(ZtcApply.Ztc_Money),
				"',  '",
				Operator.FilterString(ZtcApply.Remark),
				"',  '",
				Operator.FilterString(ZtcApply.StartTime),
				"',  '",
				Operator.FilterString(ZtcApply.ApplyTime),
				"',  '",
				Operator.FilterString(ZtcApply.PayState),
				"',  '",
				Operator.FilterString(ZtcApply.AuditState),
				"',  '",
				Operator.FilterString(ZtcApply.AuditTime),
				"',  '",
				Operator.FilterString(ZtcApply.OperateUser),
				"',  '",
				Operator.FilterString(ZtcApply.OperateRemark),
				"',  '",
				Operator.FilterString(ZtcApply.Type),
				"',  '",
				Operator.FilterString(ZtcApply.CreateUser),
				"',  '",
				Operator.FilterString(ZtcApply.CreateTime),
				"',  '",
				Operator.FilterString(ZtcApply.SubstationID),
				"',  ",
				ZtcApply.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "   DELETE ShopNum1_ZtcApply where  ID IN  (" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetInfoByGuid(string guid)
		{
			string str = guid.Replace("'", "");
			string strSql = string.Empty;
			strSql = "   SELECT  * FROM  ShopNum1_ZtcApply  WHERE ID ='" + str + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int IsDeleted)
		{
			string text = string.Empty;
			text = "   SELECT   * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "   and   IsDeleted=" + IsDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetInfo(string ProductName, string MemberID, string ShopName, string Type, string AuditState, string Time1, string Time2)
		{
			string text = string.Empty;
			text = "   SELECT  * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
			if (!string.IsNullOrEmpty(ProductName))
			{
				text = text + "    AND    ProductName LIKE  '%" + ProductName + "%'  ";
			}
			if (!string.IsNullOrEmpty(MemberID))
			{
				text = text + "    AND    MemberID  ='" + MemberID + "'  ";
			}
			if (!string.IsNullOrEmpty(ShopName))
			{
				text = text + "    AND    ShopName  ='" + ShopName + "'  ";
			}
			if (Type != "-1")
			{
				text = text + "    AND    Type  ='" + Type + "'  ";
			}
			if (AuditState != "-1")
			{
				text = text + "    AND    AuditState  ='" + AuditState + "'  ";
			}
			if (!string.IsNullOrEmpty(Time1))
			{
				text = text + "    AND    StartTime  >'" + Time1 + "'  ";
			}
			if (!string.IsNullOrEmpty(Time2))
			{
				text = text + "    AND    StartTime  <'" + Time2 + "'  ";
			}
			text += "    ORDER  BY   CreateTime  DESC        ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetInfo(string ProductName, string MemberID, string ShopName, string Type, string AuditState, string Time1, string Time2, string SubstationID)
		{
			string text = string.Empty;
			text = "   SELECT  * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
			if (!string.IsNullOrEmpty(ProductName))
			{
				text = text + "    AND    ProductName LIKE  '%" + ProductName + "%'  ";
			}
			if (!string.IsNullOrEmpty(MemberID))
			{
				text = text + "    AND    MemberID  ='" + MemberID + "'  ";
			}
			if (!string.IsNullOrEmpty(ShopName))
			{
				text = text + "    AND    ShopName  ='" + ShopName + "'  ";
			}
			if (Type != "-1")
			{
				text = text + "    AND    Type  ='" + Type + "'  ";
			}
			if (AuditState != "-1")
			{
				text = text + "    AND    AuditState  ='" + AuditState + "'  ";
			}
			if (!string.IsNullOrEmpty(Time1))
			{
				text = text + "    AND    StartTime  >'" + Time1 + "'  ";
			}
			if (!string.IsNullOrEmpty(Time2))
			{
				text = text + "    AND    StartTime  <'" + Time2 + "'  ";
			}
			if (SubstationID != "-1")
			{
				text = text + "    AND     SubstationID  ='" + SubstationID + "'  ";
			}
			text += "    ORDER  BY   CreateTime  DESC        ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int ChangeAuditState(string ID, int AuditState)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"  UPDATE  ShopNum1_ZtcApply  SET AuditState=",
				AuditState,
				",AuditTime='",
				DateTime.Now,
				"' WHERE ID =",
				ID,
				"     "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string ProductName, int AuditState, string MemberID, int Type)
		{
			string text = string.Empty;
			text = "   SELECT   * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
			if (AuditState == 0 || AuditState == 1)
			{
				text = text + "   AND   AuditState=" + AuditState;
			}
			if (Type != -1)
			{
				text = text + "   AND   Type=" + Type;
			}
			if (!string.IsNullOrEmpty(ProductName))
			{
				text = text + "   AND   ProductName like'%" + ProductName + "%'";
			}
			text = text + "    AND  MemberID='" + MemberID + "'      ";
			text += "   ORDER BY   CreateTime DESC   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Select_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ZtcApply";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "ApplyTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
