using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Shop_ScoreProduct_Action : IShopNum1_Shop_ScoreProduct_Action
	{
		public int Add(ShopNum1_Shop_ScoreProduct ScoreProductNew)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT ShopNum1_Shop_ScoreProduct(  Guid, Name, OriginalImge, ThumbImage, SmallImage, RepertoryNumber, ProductCategoryID, ProductCategoryName, Weight, RepertoryCount, UnitName, RepertoryWarnCount, Score, Brief, Detail, ClickCount, IsSaled, SaleTime, IsNew, IsHot, IsAudit, IsRecommend, Meto_Title, Meto_Description, Meto_Keywords, MemLoginID, ShopID, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime, ProductCategoryCode, MarketPrice, HaveSale, SubstationID, IsDeleted ) VALUES (  '",
				ScoreProductNew.Guid,
				"',  '",
				ScoreProductNew.Name,
				"',  '",
				ScoreProductNew.OriginalImge,
				"',  '",
				ScoreProductNew.ThumbImage,
				"',  '",
				ScoreProductNew.SmallImage,
				"',  '",
				ScoreProductNew.RepertoryNumber,
				"',  '",
				ScoreProductNew.ProductCategoryID,
				"',  '",
				ScoreProductNew.ProductCategoryName,
				"',  '",
				ScoreProductNew.Weight,
				"',  '",
				ScoreProductNew.RepertoryCount,
				"',  '",
				ScoreProductNew.UnitName,
				"',  '",
				ScoreProductNew.RepertoryWarnCount,
				"',  '",
				ScoreProductNew.Score,
				"',  '",
				ScoreProductNew.Brief,
				"',  '",
				ScoreProductNew.Detail,
				"',  '",
				ScoreProductNew.ClickCount,
				"',  '",
				ScoreProductNew.IsSaled,
				"',  '",
				ScoreProductNew.SaleTime,
				"',  '",
				ScoreProductNew.IsNew,
				"',  '",
				ScoreProductNew.IsHot,
				"',  '",
				ScoreProductNew.IsAudit,
				"',  '",
				ScoreProductNew.IsRecommend,
				"',  '",
				ScoreProductNew.Meto_Title,
				"',  '",
				ScoreProductNew.Meto_Description,
				"',  '",
				ScoreProductNew.Meto_Keywords,
				"',  '",
				ScoreProductNew.MemLoginID,
				"',  '",
				ScoreProductNew.ShopID,
				"',  '",
				ScoreProductNew.OrderID,
				"',  '",
				ScoreProductNew.CreateUser,
				"',  '",
				ScoreProductNew.CreateTime,
				"',   '",
				ScoreProductNew.ModifyUser,
				"',   '",
				ScoreProductNew.ModifyTime,
				"',   '",
				ScoreProductNew.ProductCategoryCode,
				"',   '",
				ScoreProductNew.MarketPrice,
				"',   '",
				ScoreProductNew.HaveSale,
				"',   '",
				ScoreProductNew.SubstationID,
				"',   ",
				ScoreProductNew.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "   delete ShopNum1_Shop_ScoreProduct where  Guid in (" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetScoreByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "   select  Score ,MemberRank from  ShopNum1_Member  where MemLoginID ='" + MemLoginID + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetPhotoByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "   SELECT   Photo FROM  ShopNum1_Member   WHERE  MemLoginID ='" + MemLoginID + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetDataTopWeb(int IsAudit, int IsDeleted, int IsSaled, int topNum)
		{
			string text = string.Empty;
			text = "   select  top   " + topNum + "  Guid,MemLoginID,Name,OriginalImge,Score,HaveSale,CreateTime,RepertoryCount,ProductCategoryName,RepertoryCount,MarketPrice   from  ShopNum1_Shop_ScoreProduct  where 1=1    ";
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = text + "    and  IsAudit=" + IsAudit;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "    and  IsDeleted=" + IsDeleted;
			}
			if (IsSaled == 0 || IsSaled == 1)
			{
				text = text + "    and  IsSaled=" + IsSaled;
			}
			text += "   order  by    HaveSale   desc      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataTopWeb(int IsAudit, int IsDeleted, int IsSaled, int topNum, string SubstationID)
		{
			string text = string.Empty;
			text = "   select  top   " + topNum + "  Guid,MemLoginID,Name,OriginalImge,Score,HaveSale,CreateTime,RepertoryCount,ProductCategoryName,RepertoryCount,MarketPrice   from  ShopNum1_Shop_ScoreProduct  where 1=1    ";
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = text + "    and  IsAudit=" + IsAudit;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "    and  IsDeleted=" + IsDeleted;
			}
			if (IsSaled == 0 || IsSaled == 1)
			{
				text = text + "    and  IsSaled=" + IsSaled;
			}
			if (SubstationID != "-1")
			{
				text = text + "    and   SubstationID='" + SubstationID + "' ";
			}
			text += "   order  by    HaveSale   desc      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataTopWeb(int IsAudit, int IsDeleted, int IsSaled)
		{
			string text = string.Empty;
			text = "   select Guid,MemLoginID,Name,OriginalImge,Score,HaveSale,CreateTime,RepertoryCount,ProductCategoryName,RepertoryCount,MarketPrice   from  ShopNum1_Shop_ScoreProduct  where 1=1    ";
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = text + "    and  IsAudit=" + IsAudit;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "    and  IsDeleted=" + IsDeleted;
			}
			if (IsSaled == 0 || IsSaled == 1)
			{
				text = text + "    and  IsSaled=" + IsSaled;
			}
			text += "   order  by    CreateTime   desc      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataShopWeb(int IsAudit, int IsDeleted, int IsSaled, string Guid)
		{
			string text = string.Empty;
			text = "   select *   from  ShopNum1_Shop_ScoreProduct  where 1=1    ";
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = text + "    and  IsAudit=" + IsAudit;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = text + "    and  IsDeleted=" + IsDeleted;
			}
			if (IsSaled == 0 || IsSaled == 1)
			{
				text = text + "    and  IsSaled=" + IsSaled;
			}
			text = text + "    and      Guid ='" + Guid + "'     ";
			text += "   order  by    CreateTime   desc      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetInfoByGuid(string guid)
		{
			string str = guid.Replace("'", "");
			string strSql = string.Empty;
			strSql = "   select  * from  ShopNum1_Shop_ScoreProduct  where Guid ='" + str + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetInfoByGuid(string guid, int IsSaled, int IsAudit, int IsDeleted)
		{
			string str = guid.Replace("'", "");
			string text = string.Empty;
			text = "   select  * from  ShopNum1_Shop_ScoreProduct  where Guid ='" + str + "'   ";
			if (IsSaled == 1 || IsSaled == 0)
			{
				text = text + "   and   IsSaled=" + IsSaled;
			}
			if (IsAudit == 1 || IsAudit == 0)
			{
				text = text + "   and   IsAudit=" + IsAudit;
			}
			if (IsDeleted == 1 || IsDeleted == 0)
			{
				text = text + "   and   IsDeleted=" + IsDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_Shop_ScoreProduct ScoreProductNew)
		{
			string strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Shop_ScoreProduct  SET \tName\t='",
				ScoreProductNew.Name,
				"', \tOriginalImge\t='",
				ScoreProductNew.OriginalImge,
				"', \tThumbImage\t='",
				ScoreProductNew.ThumbImage,
				"', \tSmallImage\t='",
				Operator.FilterString(ScoreProductNew.SmallImage),
				"',\tRepertoryNumber\t='",
				Operator.FilterString(ScoreProductNew.RepertoryNumber),
				"',\tProductCategoryID\t='",
				Operator.FilterString(ScoreProductNew.ProductCategoryID),
				"',\tProductCategoryName\t='",
				Operator.FilterString(ScoreProductNew.ProductCategoryName),
				"',\tWeight\t='",
				Operator.FilterString(ScoreProductNew.Weight),
				"',\tRepertoryCount\t='",
				Operator.FilterString(ScoreProductNew.RepertoryCount),
				"',\tUnitName\t='",
				Operator.FilterString(ScoreProductNew.UnitName),
				"',\tScore\t='",
				Operator.FilterString(ScoreProductNew.Score),
				"',\tBrief\t='",
				ScoreProductNew.Brief,
				"', \tDetail='",
				ScoreProductNew.Detail,
				"' ,\tIsNew\t='",
				Operator.FilterString(ScoreProductNew.IsNew),
				"',\tIsHot\t='",
				Operator.FilterString(ScoreProductNew.IsHot),
				"',\tMeto_Title\t='",
				Operator.FilterString(ScoreProductNew.Meto_Title),
				"',\tMeto_Description\t='",
				Operator.FilterString(ScoreProductNew.Meto_Description),
				"',\tMeto_Keywords\t='",
				Operator.FilterString(ScoreProductNew.Meto_Keywords),
				"',\tModifyUser\t='",
				Operator.FilterString(ScoreProductNew.ModifyUser),
				"',\tProductCategoryCode\t='",
				Operator.FilterString(ScoreProductNew.ProductCategoryCode),
				"',\tMarketPrice\t='",
				Operator.FilterString(ScoreProductNew.MarketPrice),
				"',\tModifyTime='",
				ScoreProductNew.ModifyTime,
				"'  WHERE Guid='",
				ScoreProductNew.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateIsIntegralShop(string Guid, int IsIntegralShop)
		{
			string text = string.Empty;
			if (IsIntegralShop == 1 || IsIntegralShop == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   update ShopNum1_ShopInfo  set IsIntegralShop=",
					IsIntegralShop,
					"    "
				});
				text = text + "   where Guid ='" + Guid + "'    ";
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetDataInfoInAdmin(string Name, string RepertoryNumber, int starJF, int endJF, int IsAudit, string ProductCategoryCode, int IsSaled, string MemLoginID)
		{
			string text = string.Empty;
			text += "    select * from ShopNum1_Shop_ScoreProduct where 1=1     ";
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "   and     Name like     '%" + Name + "%'   ";
			}
			if (!string.IsNullOrEmpty(RepertoryNumber))
			{
				text = text + "   and    RepertoryNumber='" + RepertoryNumber + "'   ";
			}
			if (starJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and    Score >  '",
					starJF,
					"'   "
				});
			}
			if (endJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   Score < '",
					endJF,
					"'   "
				});
			}
			if (IsAudit != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsAudit = '",
					IsAudit,
					"'   "
				});
			}
			if (ProductCategoryCode != "-1")
			{
				text = text + "   and   ProductCategoryCode like '" + ProductCategoryCode + "%'   ";
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsSaled = '",
					IsSaled,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and   MemLoginID = '" + MemLoginID + "'   ";
			}
			text += "   order  by    CreateTime     desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpOrDownSaled(string Guid, int IsSaled)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"   update ShopNum1_Shop_ScoreProduct set IsSaled='",
				IsSaled,
				"'  where  Guid  in (",
				Guid,
				")   "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int ClickProduct(string Guid)
		{
			string strSql = string.Empty;
			strSql = "   update ShopNum1_Shop_ScoreProduct set ClickCount=ClickCount+1  where  Guid ='" + Guid + "'   ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int IsAudit(string Guid, int IsAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"   update ShopNum1_Shop_ScoreProduct set IsAudit='",
				IsAudit,
				"',  ModifyTime='",
				DateTime.Now.ToString(),
				"'    where  Guid  in (",
				Guid,
				")   "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Operate(string ziduan, string value, string Guid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   update ShopNum1_Shop_ScoreProduct set ",
				ziduan,
				"='",
				value,
				"',  ModifyTime='",
				DateTime.Now.ToString(),
				"'    where  Guid  in (",
				Guid,
				")   "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetDataInfoInAdmin(string Name, string RepertoryNumber, int starJF, int endJF, int IsAudit, string ProductCategoryCode, int IsDeleted, int IsSaled, string MemLoginID, int IsNew, int IsHot)
		{
			string text = string.Empty;
			text += "    select * from ShopNum1_Shop_ScoreProduct where 1=1     ";
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "   and     Name like     '%" + Name + "%'   ";
			}
			if (!string.IsNullOrEmpty(RepertoryNumber))
			{
				text = text + "   and    RepertoryNumber='" + RepertoryNumber + "'   ";
			}
			if (starJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and    Score >  '",
					starJF,
					"'   "
				});
			}
			if (endJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   Score < '",
					endJF,
					"'   "
				});
			}
			if (IsAudit != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsAudit = '",
					IsAudit,
					"'   "
				});
			}
			if (ProductCategoryCode != "-1")
			{
				text = text + "   and   ProductCategoryCode like '" + ProductCategoryCode + "%'   ";
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsSaled = '",
					IsSaled,
					"'   "
				});
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsDeleted = '",
					IsDeleted,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and   MemLoginID = '" + MemLoginID + "'   ";
			}
			if (IsNew != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsNew = '",
					IsNew,
					"'   "
				});
			}
			if (IsHot != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsHot = '",
					IsHot,
					"'   "
				});
			}
			text += "   order  by    CreateTime     desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataInfoInAdmin(string Name, string RepertoryNumber, int starJF, int endJF, int IsAudit, string ProductCategoryCode, int IsDeleted, int IsSaled, string MemLoginID, int IsNew, int IsHot, string SubstationID)
		{
			string text = string.Empty;
			text += "    select * from ShopNum1_Shop_ScoreProduct where 1=1     ";
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "   and     Name like     '%" + Name + "%'   ";
			}
			if (!string.IsNullOrEmpty(RepertoryNumber))
			{
				text = text + "   and    RepertoryNumber='" + RepertoryNumber + "'   ";
			}
			if (starJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and    Score >  '",
					starJF,
					"'   "
				});
			}
			if (endJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   Score < '",
					endJF,
					"'   "
				});
			}
			if (IsAudit != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsAudit = '",
					IsAudit,
					"'   "
				});
			}
			if (ProductCategoryCode != "-1")
			{
				text = text + "   and   ProductCategoryCode like '" + ProductCategoryCode + "%'   ";
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsSaled = '",
					IsSaled,
					"'   "
				});
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsDeleted = '",
					IsDeleted,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and   MemLoginID = '" + MemLoginID + "'   ";
			}
			if (IsNew != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsNew = '",
					IsNew,
					"'   "
				});
			}
			if (IsHot != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsHot = '",
					IsHot,
					"'   "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + "   and    SubstationID = '" + SubstationID + "'   ";
			}
			text += "   order  by    CreateTime     desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataInfoInAdminNew(string Name, string RepertoryNumber, int starJF, int endJF, int IsAudit, string ProductCategoryCode, int IsDeleted, int IsSaled, string MemLoginID, int IsNew, int IsHot, string SubstationID)
		{
			string text = string.Empty;
			text += "    select * from ShopNum1_Shop_ScoreProduct where 1=1     ";
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + "   and     Name like     '%" + Name + "%'   ";
			}
			if (!string.IsNullOrEmpty(RepertoryNumber))
			{
				text = text + "   and    RepertoryNumber='" + RepertoryNumber + "'   ";
			}
			if (starJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and    Score >  '",
					starJF,
					"'   "
				});
			}
			if (endJF != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   Score < '",
					endJF,
					"'   "
				});
			}
			text += "   and   IsAudit     IN (0,2)   ";
			if (ProductCategoryCode != "-1")
			{
				text = text + "   and   ProductCategoryCode like '" + ProductCategoryCode + "%'   ";
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsSaled = '",
					IsSaled,
					"'   "
				});
			}
			if (IsSaled != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsDeleted = '",
					IsDeleted,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and   MemLoginID = '" + MemLoginID + "'   ";
			}
			if (IsNew != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsNew = '",
					IsNew,
					"'   "
				});
			}
			if (IsHot != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsHot = '",
					IsHot,
					"'   "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + "   and    SubstationID = '" + SubstationID + "'   ";
			}
			text += "   order  by    CreateTime     desc    ";
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
			array2[3] = "ShopNum1_Shop_ScoreProduct";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataSet SearchScoreProductList(string ordername, string soft, string perpagenum, string current_page, string isreturcount)
		{
			string text = " 1=1  ";
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = " *  ";
			array[3] = "@ordername";
			array2[3] = ordername;
			array[4] = "@searchname";
			array2[4] = text;
			array[5] = "@sdesc";
			array2[5] = soft;
			array[6] = "@isreturcount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchScoreProduct", array, array2);
		}
		public DataSet SearchScoreProductList(string ordername, string soft, string perpagenum, string current_page, string isreturcount, string searchwhere)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = " *  ";
			array[3] = "@ordername";
			array2[3] = ordername;
			array[4] = "@searchname";
			array2[4] = searchwhere;
			array[5] = "@sdesc";
			array2[5] = soft;
			array[6] = "@isreturcount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchScoreProduct", array, array2);
		}
	}
}
