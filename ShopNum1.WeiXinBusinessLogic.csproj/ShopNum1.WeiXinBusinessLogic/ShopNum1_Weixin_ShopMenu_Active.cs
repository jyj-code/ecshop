using ShopNum1.DataAccess;
using ShopNum1.WeiXinCommon.model;
using ShopNum1.WeiXinInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.WeiXinBusinessLogic
{
	public class ShopNum1_Weixin_ShopMenu_Active : IShopNum1_Weixin_ShopMenu_Active
	{
		public bool Add_Menu(List<MenuButton> menulist, string shopmemloginid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
			stringBuilder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
			stringBuilder.AppendFormat("DELETE [dbo].[ShopNum1_Weixin_ShopMenu] WHERE [ShopMemLoginId] = '{0}'", shopmemloginid).AppendLine();
			if (menulist != null)
			{
				stringBuilder.AppendFormat("DECLARE @pid  int;", new object[0]).AppendLine();
				foreach (MenuButton current in menulist)
				{
					stringBuilder.AppendFormat("INSERT INTO [dbo].[ShopNum1_Weixin_ShopMenu]([ShopMemLoginId],[Name],[PId],[value],[Sort])\r\n                                      VALUES('{0}','{1}',0,'{2}','{3}')", new object[]
					{
						shopmemloginid,
						current.Name,
						current.Value,
						current.Sort
					}).AppendLine();
					stringBuilder.AppendFormat("SELECT @pid = @@IDENTITY", new object[0]).AppendLine();
					foreach (MenuButton current2 in current.SubButton)
					{
						stringBuilder.AppendFormat("INSERT INTO [dbo].[ShopNum1_Weixin_ShopMenu]([ShopMemLoginId],[Name],[PId],[value],[Sort])\r\n                                      VALUES('{0}','{1}',@pid,'{2}','{3}')", new object[]
						{
							shopmemloginid,
							current2.Name,
							current2.Value,
							current2.Sort
						}).AppendLine();
					}
				}
			}
			stringBuilder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString()) > 0;
		}
		public DataTable Select_MenuByPid(string shopmemloginid, int int_0)
		{
			string strSql = string.Format("SELECT [ID],[ShopMemLoginId],[Name],[PId],[value],[Sort] FROM [dbo].[ShopNum1_Weixin_ShopMenu] WHERE ShopMemLoginId = '{0}' AND PId = '{1}' Order by Sort", shopmemloginid, int_0);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Select_AllMenu(string shopmemloginid)
		{
			string strSql = string.Format("SELECT [ID],[ShopMemLoginId],[Name],[PId],[value],[Sort] FROM [dbo].[ShopNum1_Weixin_ShopMenu] WHERE ShopMemLoginId = '{0}' Order by Sort", shopmemloginid);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string Add_menu(string menu_name, string menu_pid, string shopmemloginid)
		{
			string strSql = string.Format("Insert into ShopNum1_Weixin_ShopMenu(Name,PId,ShopMemLoginId)\r\n                                            values('{0}','{1}','{2}');SELECT @@IDENTITY", menu_name, menu_pid, shopmemloginid);
			return DatabaseExcetue.ReturnString(strSql);
		}
		public bool Edit_menu(string menu_name, string string_0)
		{
			string strSql = string.Format("update  ShopNum1_Weixin_ShopMenu set Name = '{0}' where ID = '{1}'", menu_name, string_0);
			return DatabaseExcetue.RunNonQuery(strSql) > 0;
		}
		public bool Del_menu(string string_0)
		{
			string strSql = string.Format("delete dbo.ShopNum1_Weixin_ReplyRule where Id in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}'))\r\n                                            delete dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}')) \r\n                                            delete dbo.ShopNum1_Weixin_ReplyRuleKey where ruleid in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}')) \r\n                                            delete  ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}';", string_0);
			return DatabaseExcetue.RunNonQuery(strSql) > 0;
		}
		public DataTable Get_menubypid(string shopmemloginid, string string_0)
		{
			string strSql = string.Format("with tab as\r\n                                            (\r\n                                            SELECT [ID],[ShopMemLoginId],[Name],[PId],[Type],[Sort],[Key],[Url]\r\n                                            FROM [dbo].[ShopNum1_Weixin_ShopMenu] Where ShopMemLoginId = '{0}' and PId = '{1}'\r\n                                            ) \r\n\r\n                                            select tab.[ID],[ShopMemLoginId],[Name],[PId],[Sort],IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url,IsNull(taba.ruleid,'0') as ruleid from tab \r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleKey as taba on tab.[key]=taba.keyword", shopmemloginid, string_0);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Get_menubyid(string shopmemloginid, string string_0)
		{
			string strSql = string.Format("with tab as\r\n                                            (\r\n                                            SELECT [ID],[ShopMemLoginId],[Name],[PId],[Type],[Sort],[Key],[Url]\r\n                                            FROM [dbo].[ShopNum1_Weixin_ShopMenu] Where ShopMemLoginId = '{0}' and ID = '{1}'\r\n                                            ) \r\n\r\n                                            select tab.[ID],[ShopMemLoginId],[Name],[PId],[Sort],IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url,IsNull(taba.ruleid,'0') as ruleid from tab \r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleKey as taba on tab.[key]=taba.keyword", shopmemloginid, string_0);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public bool UpdateView(string string_0, string string_1)
		{
			string strSql = string.Format("update [ShopNum1_Weixin_ShopMenu] set Type = 'view',url='{0}' where id = '{1}'", string_1, string_0);
			return DatabaseExcetue.RunNonQuery(strSql) > 0;
		}
		public DataTable GetAllMenu(string shopmemloginid)
		{
			string strSql = string.Format("select id,[name],pid,IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url from dbo.ShopNum1_Weixin_ShopMenu where shopmemloginid = '{0}'", shopmemloginid);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
