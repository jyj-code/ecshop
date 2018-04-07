using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SubstationManage_Action : IShopNum1_SubstationManage_Action
	{
		public int Add(ShopNum1_SubstationManage SubstationManage)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert ShopNum1_SubstationManage( Guid,SubstationID,Name,CityCode,People,DomainName,Phone,Remarks,IsDisabled,CreateUser,CreateTime,ModifyUser,ModifyTime,IsHot,Letter,AdvancePayment,IsDeleted ) VALUES (  '",
				SubstationManage.Guid,
				"',  '",
				Operator.FilterString(SubstationManage.SubstationID),
				"',  '",
				Operator.FilterString(SubstationManage.Name),
				"',  '",
				Operator.FilterString(SubstationManage.CityCode),
				"',  '",
				Operator.FilterString(SubstationManage.People),
				"',  '",
				Operator.FilterString(SubstationManage.DomainName),
				"',  '",
				Operator.FilterString(SubstationManage.Phone),
				"',  '",
				Operator.FilterString(SubstationManage.Remarks),
				"',  '",
				Operator.FilterString(SubstationManage.IsDisabled),
				"',  '",
				Operator.FilterString(SubstationManage.CreateUser),
				"',  '",
				Operator.FilterString(SubstationManage.CreateTime),
				"',  '",
				Operator.FilterString(SubstationManage.ModifyUser),
				"',  '",
				Operator.FilterString(SubstationManage.ModifyTime),
				"',  '",
				Operator.FilterString(SubstationManage.IsHot),
				"',  '",
				Operator.FilterString(SubstationManage.Letter),
				"',  '",
				Operator.FilterString(SubstationManage.AdvancePayment),
				"',  '",
				Operator.FilterString(SubstationManage.IsDeleted),
				"'    )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_SubstationManage SubstationManage)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_SubstationManage SET  Name ='",
				Operator.FilterString(SubstationManage.Name),
				"', People ='",
				Operator.FilterString(SubstationManage.People),
				"', DomainName ='",
				Operator.FilterString(SubstationManage.DomainName),
				"', Phone ='",
				SubstationManage.Phone,
				"', Remarks ='",
				SubstationManage.Remarks,
				"', ModifyTime ='",
				SubstationManage.ModifyTime,
				"', IsHot ='",
				SubstationManage.IsHot,
				"', Letter ='",
				SubstationManage.Letter,
				"', IsDisabled ='",
				SubstationManage.IsDisabled,
				"' WHERE Guid='",
				SubstationManage.Guid,
				"' "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string Guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_SubstationManage WHERE Guid IN (" + Guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteUserBySubstationID(string SubstationID)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM    ShopNum1_User    WHERE   SubstationID  ='" + SubstationID + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetDataBySubstationID(string SubstationID)
		{
			string strSql = string.Empty;
			strSql = "   select  *  from  ShopNum1_SubstationManage where SubstationID='" + SubstationID + "'     ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchByDomainName(string DomainName)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_SubstationManage WHERE 0=0";
			text = text + " AND DomainName='" + DomainName + "' ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search()
		{
			string strSql = string.Empty;
			strSql = "SELECT  *  FROM ShopNum1_SubstationManage WHERE 0=0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int IsDisabled)
		{
			string strSql = string.Empty;
			strSql = "SELECT  *  FROM ShopNum1_SubstationManage WHERE 0=0  and IsDisabled=" + IsDisabled;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string Guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  *  FROM ShopNum1_SubstationManage WHERE 0=0   and  Guid='" + Guid + "' ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string SubstationID, string CityCode)
		{
			string text = string.Empty;
			text = "SELECT  *  FROM ShopNum1_SubstationManage WHERE 0=0";
			if (!string.IsNullOrEmpty(SubstationID))
			{
				text = text + "  and    SubstationID='" + SubstationID + "'  ";
			}
			if (!string.IsNullOrEmpty(CityCode))
			{
				text = text + "  and    CityCode='" + CityCode + "'  ";
			}
			text += "  order by  CreateTime   desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCityNameByCode(string Code)
		{
			string text = string.Empty;
			text = "SELECT  *  FROM ShopNum1_Region  WHERE 0=0";
			text = text + "  and    Code='" + Code + "'  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetSubstationIDByDomainName(string DomainName)
		{
			string text = string.Empty;
			text = "SELECT  SubstationID  FROM ShopNum1_SubstationManage  WHERE 0=0";
			text = text + "  and    DomainName='" + DomainName + "' ";
			string result;
			try
			{
				result = DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
				return result;
			}
			catch (Exception)
			{
			}
			result = "";
			return result;
		}
		public string GetSubstationIDByDomainName(string DomainName, int IsDisabled)
		{
			string text = string.Empty;
			text = "SELECT  SubstationID  FROM ShopNum1_SubstationManage  WHERE 0=0";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"  and    DomainName='",
				DomainName,
				"'  AND   IsDisabled=",
				IsDisabled,
				"  "
			});
			string result;
			try
			{
				result = DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
				return result;
			}
			catch (Exception)
			{
			}
			result = "";
			return result;
		}
		public string GetDomainNameBySubstationID(string SubstationID)
		{
			string result;
			try
			{
				if (SubstationID.IndexOf(",") != -1)
				{
					SubstationID = SubstationID.Split(new char[]
					{
						','
					})[0];
				}
				string text = string.Empty;
				text = "SELECT  DomainName  FROM ShopNum1_SubstationManage  WHERE 0=0";
				text = text + "  and    SubstationID='" + SubstationID + "'  ";
				result = DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public string GetCityNameBySubstationID(string SubstationID)
		{
			string text = string.Empty;
			text = "select Name from ShopNum1_Region  where   Code in  ";
			text += "  (  ";
			text = text + "  select CityCode from ShopNum1_SubstationManage  where  SubstationID='" + SubstationID + "'  ";
			text += "  )  ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string GetCityNameBySubstationIDNew(string SubstationID)
		{
			string str = string.Empty;
			if (SubstationID.Split(new char[]
			{
				','
			}).Length > 0)
			{
				str = SubstationID.Split(new char[]
				{
					','
				})[0].ToString();
			}
			string text = string.Empty;
			text = text + "  select Name from ShopNum1_SubstationManage  where  SubstationID='" + str + "'  ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public DataTable GetFenByCityCode(string CityCode, int type)
		{
			string text = string.Empty;
			text = "select * from ShopNum1_SubstationManage  where   CityCode   like   ";
			text = text + "  '" + CityCode.Substring(0, type) + "%'  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCityNameHaveOpen(int Tops, int IsHot)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   select top  ",
				Tops,
				" * from  ShopNum1_Region     "
			});
			text += "   where Code in    ";
			text += "   (   ";
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   select CityCode from ShopNum1_SubstationManage where IsHot=",
				IsHot,
				"     "
			});
			text += "   )   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCityNameHaveOpenNew(int Tops, int IsHot)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   select top  ",
				Tops,
				"  * from ShopNum1_SubstationManage where IsHot=",
				IsHot,
				"     "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCityNameHaveOpenNew(int Tops, int IsHot, int IsDisabled)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   select top  ",
				Tops,
				"  * from ShopNum1_SubstationManage where IsHot=",
				IsHot,
				"  and IsDisabled=",
				IsDisabled,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSubstationByCityCode(string CityCode)
		{
			string text = string.Empty;
			text = text + "   select * from ShopNum1_SubstationManage  where CityCode ='" + CityCode + "'   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSubstationByShopInfo(string MemLoginID)
		{
			string text = string.Empty;
			text = text + "   select * from ShopNum1_ShopInfo  where MemLoginID ='" + MemLoginID + "'   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetFenCityName()
		{
			string text = string.Empty;
			text += "  select A.SubstationID,A.CityCode,B.Name from ShopNum1_SubstationManage as A    ";
			text += "  left join ShopNum1_Region as B on A.CityCode=B.Code   and  A.IsDisabled=0 ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSfData()
		{
			string text = string.Empty;
			text += "   select * from ShopNum1_Region where  Code in (   ";
			text += "   select CityCode from  ShopNum1_SubstationManage  where len(CityCode)=3 )   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSfDataNew()
		{
			string text = string.Empty;
			text += "   select *  from  ShopNum1_SubstationManage  where len(CityCode)=3    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetNextCityBySubstationID(string SubstationID)
		{
			string text = string.Empty;
			text += "  select * from ShopNum1_Region where  Code in(    ";
			text += "  select CityCode from ShopNum1_SubstationManage where    ";
			text += "   CityCode in (   ";
			text += "   select Code from ShopNum1_Region where FatherID in (   ";
			text += "   select  ID from ShopNum1_Region where   ";
			text += "    Code in (  ";
			text = text + "    select CityCode from  ShopNum1_SubstationManage  where SubstationID='" + SubstationID + "'  ";
			text += "    ))))  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetNextCityBySubstationIDNew(string SubstationID)
		{
			string text = string.Empty;
			text += "  select * from ShopNum1_SubstationManage where    ";
			text += "   CityCode in (   ";
			text += "   select Code from ShopNum1_Region where FatherID in (   ";
			text += "   select  ID from ShopNum1_Region where   ";
			text += "    Code in (  ";
			text = text + "    select CityCode from  ShopNum1_SubstationManage  where SubstationID='" + SubstationID + "'  ";
			text += "    )))  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDomainNameByShopID(string ShopID)
		{
			string text = string.Empty;
			text += "   select DomainName from ShopNum1_SubstationManage where SubstationID   ";
			text += "   in   ";
			text += "    (  ";
			text += "    select SubstationID from ShopNum1_ShopInfo  ";
			text = text + "    where ShopID='" + ShopID + "'  ";
			text += "    )  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDomainNameByShopMemLoginID(string MemLoginID)
		{
			string text = string.Empty;
			text += "   select DomainName from ShopNum1_SubstationManage where SubstationID   ";
			text += "   in   ";
			text += "    (  ";
			text += "    select SubstationID from ShopNum1_ShopInfo  ";
			text = text + "    where MemLoginID='" + MemLoginID + "'  ";
			text += "    )  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetLetterByName(string Name)
		{
			string text = string.Empty;
			text = text + "  select dbo.fun_getPY ('" + Name + "')   ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public DataTable GetLetterOrderByLetter(string CityCode)
		{
			string text = string.Empty;
			text += "  SELECT distinct  Letter  FROM ShopNum1_SubstationManage    ";
			text += "  WHERE 1=1 and IsDisabled=0     ";
			if (CityCode != "-1")
			{
				text = text + "  and CityCode  like  '" + CityCode + "%'     ";
			}
			text += "  ORDER BY Letter ASC    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetNameByLetter(string Letter)
		{
			string text = string.Empty;
			text += "  select B.Name as CityName,A.* from  ShopNum1_SubstationManage  as A left join ShopNum1_Region as B on A.CityCode=B.Code  ";
			text = text + "  where Letter='" + Letter.Substring(0, 1).ToString() + "' and IsDisabled=0  order by CreateTime asc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByName(string Name)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_SubstationManage WHERE 0=0";
			text = text + " AND Name='" + Name + "' ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int InsertSubstationManageNav(string SubstationID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@SubstationID";
			array2[0] = SubstationID;
			return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_InsertSubstationManageNav", array, array2));
		}
		public int DeleteSubstationManageNav(string SubstationID)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM    ShopNum1_UserDefinedColumn       WHERE   SubstationID    ='" + SubstationID + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
