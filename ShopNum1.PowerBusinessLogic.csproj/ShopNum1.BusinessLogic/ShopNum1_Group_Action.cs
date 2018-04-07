using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Group_Action : IShopNum1_Group_Action
	{
		public int Add(ShopNum1_Group group, List<string> pageList, List<string> userList, List<ShopNum1_GroupPageWebControl> groupPageWebControlList)
		{
			List<string> list = new List<string>();
			string item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Group( Guid,  Name,  ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,  SubstationID,  Remarks ) VALUES (  '",
				group.Guid,
				"',  '",
				Operator.FilterString(group.Name),
				"',  '",
				Operator.FilterString(group.ShortName),
				"',  '",
				group.CreateUser,
				"', '",
				group.CreateTime,
				"',  '",
				group.ModifyUser,
				"' , '",
				group.ModifyTime,
				"',  '",
				group.IsDeleted,
				"',  '",
				group.SubstationID,
				"',  ",
				group.Remarks,
				")"
			});
			list.Add(item);
			if (pageList.Count > 0)
			{
				for (int i = 0; i < pageList.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,  Remarks ) VALUES (  '",
						group.Guid,
						"',  '",
						Operator.FilterString(pageList[i].ToString()),
						"',  '",
						group.CreateUser,
						"', '",
						group.CreateTime,
						"',  '",
						group.ModifyUser,
						"' , '",
						group.ModifyTime,
						"',  '",
						group.IsDeleted,
						"',  ",
						group.Remarks,
						")"
					});
					list.Add(item2);
					if (groupPageWebControlList.Count > 0)
					{
						for (int j = 0; j < groupPageWebControlList.Count; j++)
						{
							if (string.Equals(groupPageWebControlList[j].PageGuid.ToString(), pageList[i].ToString()))
							{
								string item3 = string.Concat(new object[]
								{
									"INSERT INTO ShopNum1_GroupPageWebControl( Guid, PageWebControlGuid,  PageGuid,  GroupGuid,  IsUse,  IsShow,  ControlID,  ControlType, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
									Guid.NewGuid(),
									"',  '",
									groupPageWebControlList[j].Guid,
									"',  '",
									groupPageWebControlList[j].PageGuid,
									"',  '",
									group.Guid,
									"',  ",
									groupPageWebControlList[j].IsUse,
									", ",
									groupPageWebControlList[j].IsShow,
									", '",
									groupPageWebControlList[j].ControlID,
									"',  '",
									groupPageWebControlList[j].ControlType,
									"',  '",
									group.CreateUser,
									"', '",
									group.CreateTime,
									"',  '",
									group.ModifyUser,
									"' , '",
									group.ModifyTime,
									"',  ",
									group.IsDeleted,
									")"
								});
								list.Add(item3);
							}
						}
					}
				}
			}
			if (userList.Count > 0)
			{
				for (int i = 0; i < userList.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,  Remarks ) VALUES (  '",
						group.Guid,
						"',  '",
						Operator.FilterString(userList[i].ToString()),
						"',  '",
						group.CreateUser,
						"', '",
						group.CreateTime,
						"',  '",
						group.ModifyUser,
						"' , '",
						group.ModifyTime,
						"',  '",
						group.IsDeleted,
						"',  ",
						group.Remarks,
						")"
					});
					list.Add(item2);
				}
			}
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
		public int Add(ShopNum1_Group group)
		{
			string strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Group( Guid,  Name,  ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,  SubstationID,  Remarks ) VALUES (  '",
				group.Guid,
				"',  '",
				Operator.FilterString(group.Name),
				"',  '",
				Operator.FilterString(group.ShortName),
				"',  '",
				group.CreateUser,
				"', '",
				group.CreateTime,
				"',  '",
				group.ModifyUser,
				"' , '",
				group.ModifyTime,
				"',  '",
				group.IsDeleted,
				"',  '",
				group.SubstationID,
				"',  '",
				group.Remarks,
				"')"
			});
			int result;
			try
			{
				DatabaseExcetue.RunNonQuery(strSql);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Add(List<ShopNum1_GroupPage> strPagelList)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_GroupPage WHERE GroupGuid IN ('" + strPagelList[0].GroupGuid + "')";
			list.Add(item);
			for (int i = 0; i < strPagelList.Count; i++)
			{
				item = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
					strPagelList[i].GroupGuid,
					"',  '",
					strPagelList[i].PageGuid,
					"',  '",
					strPagelList[i].CreateUser,
					"',  '",
					strPagelList[i].CreateTime,
					"', '",
					strPagelList[i].ModifyUser,
					"',  '",
					strPagelList[i].ModifyTime,
					"' , ",
					strPagelList[i].IsDeleted,
					")"
				});
				list.Add(item);
			}
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  '79B714FE-3DF9-4C90-A5A2-7331CC1E7316',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  '59BDE821-3AF5-48B8-8948-8D7BF92C34F7',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  '8460586B-3351-4413-9F4B-31CD1070EEDA',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  'F9936372-1807-45C4-B23A-2EB57AE894EA',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  'EE13DE9F-2095-495B-8C9D-60770902F8E9',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  '5AA848FA-607D-4D66-8AE1-555245FED6FD',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid,  CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				strPagelList[0].GroupGuid,
				"',  '3394BDAB-89E9-4F5C-A82C-44D759662390',  '",
				strPagelList[0].CreateUser,
				"',  '",
				strPagelList[0].CreateTime,
				"', '",
				strPagelList[0].ModifyUser,
				"',  '",
				strPagelList[0].ModifyTime,
				"' , ",
				strPagelList[0].IsDeleted,
				")"
			});
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
		public int Delete(string guids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "DELETE FROM ShopNum1_Group WHERE Guid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupUser WHERE GroupGuid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupPage WHERE GroupGuid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupPageWebControl WHERE GroupGuid IN (" + guids + ")";
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
		public DataTable Search(int IsDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,Remarks FROM ShopNum1_Group WHERE 0=0";
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					IsDeleted,
					" "
				});
			}
			text += "Order by CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int IsDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted,Remarks FROM ShopNum1_Group WHERE 0=0";
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					IsDeleted,
					" "
				});
			}
			if (SubstationID != "" && SubstationID != "-1")
			{
				text = text + " AND  SubstationID='" + SubstationID + "' ";
			}
			text += "Order by CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetGroupByGuid(string groupGuid, int IsDeleted)
		{
			string text = string.Empty;
			text = "SELECT  Guid, ShortName, Name, IsDeleted, Remarks FROM ShopNum1_Group WHERE 0=0";
			if (groupGuid != string.Empty)
			{
				text = text + " AND Guid= '" + groupGuid + "'";
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					IsDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetGroupByGuid(string GroupGuid)
		{
			string text = string.Empty;
			text = "SELECT  GroupGuid,PageGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,IsDeleted FROM ShopNum1_GroupPage WHERE 0=0";
			if (GroupGuid != string.Empty)
			{
				text = text + " AND GroupGuid='" + GroupGuid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetUserByGroupGuid(string groupGuid, int IsDeleted)
		{
			string text = string.Empty;
			text = "SELECT  A.GroupGuid, A.UserGuid, B.LoginID,B.RealName,B.IsDeleted FROM ShopNum1_GroupUser AS A LEFT JOIN ShopNum1_User AS B ON A.UserGuid=B.Guid WHERE 0=0";
			if (groupGuid != string.Empty)
			{
				text = text + "AND  A.GroupGuid=" + groupGuid;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					"AND  A.IsDeleted=",
					IsDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPageByGroupGuid(string groupGuid, int IsDeleted)
		{
			string text = string.Empty;
			text = "SELECT  A.GroupGuid, A.PageGuid, A.IsDeleted,B.Guid,B.Name FROM ShopNum1_GroupPage AS A LEFT JOIN ShopNum1_Page AS B ON A.PageGuid=B.Guid WHERE 0=0";
			if (groupGuid != string.Empty)
			{
				text = text + "AND  A.GroupGuid=" + groupGuid;
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					"AND  A.IsDeleted=",
					IsDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPageWebControlByGroupGuidPageGuid(string groupGuid, string pageGuid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, PageWebControlGuid, GroupGuid, IsUse, IsShow, PageGuid, ControlID, ControlType,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted FROM ShopNum1_GroupPageWebControl WHERE 0=0 ";
			if (pageGuid != string.Empty)
			{
				text = text + "AND PageGuid='" + pageGuid + "'";
			}
			if (groupGuid != string.Empty)
			{
				text = text + "AND GroupGuid='" + groupGuid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPageWebControlByPageGuid(string pageGuid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, PageGuid, Name, ControlID, ControlType, Description FROM ShopNum1_PageWebControl WHERE 0=0 ";
			if (pageGuid != string.Empty)
			{
				text = text + "AND PageGuid='" + pageGuid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetPageWebControlByGuid(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, PageGuid, Name, ControlID, ControlType, Description FROM ShopNum1_PageWebControl WHERE 0=0 ";
			if (guid != string.Empty)
			{
				text = text + "AND Guid='" + guid + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int CheckOperatePage(string userGuid, string pageName)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"Select Count(*) AS Count From ShopNum1_GroupPage Where GroupGuid In  (  Select GroupGuid From ShopNum1_GroupUser       Where UserGuid='",
				userGuid,
				"'  )  AND   PageGuid In   (   Select convert(nvarchar(200),Guid) From ShopNum1_Page      Where  PagePath ='",
				pageName,
				"'  )"
			});
			return Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Count"].ToString());
		}
		public DataTable GetOperateControl(string userGuid, string pageName)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"Select * From ShopNum1_GroupPageWebControl Where GroupGuid In  (  Select GroupGuid From ShopNum1_GroupUser       Where UserGuid='",
				userGuid,
				"'  )  AND   PageGuid In   (   Select Guid From ShopNum1_Page      Where  PagePath ='",
				Operator.FilterString(pageName),
				"'  )"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_Group group, List<string> pageList, List<string> userList, List<ShopNum1_GroupPageWebControl> groupPageWebControlList)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Group SET  Name='",
				Operator.FilterString(group.Name),
				"', ShortName='",
				Operator.FilterString(group.ShortName),
				"', ModifyUser='",
				group.ModifyUser,
				"', Remarks='",
				group.Remarks,
				"', ModifyTime='",
				group.ModifyTime,
				"' WHERE Guid='",
				group.Guid,
				"'"
			});
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupUser WHERE GroupGuid IN ('" + group.Guid + "')";
			list.Add(item);
			if (userList.Count > 0)
			{
				for (int i = 0; i < userList.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
						group.Guid,
						"',  '",
						Operator.FilterString(userList[i].ToString()),
						"',  '",
						group.CreateUser,
						"', '",
						group.CreateTime,
						"',  '",
						group.ModifyUser,
						"' , '",
						group.ModifyTime,
						"',  ",
						group.IsDeleted,
						")"
					});
					list.Add(item2);
				}
			}
			item = "DELETE FROM ShopNum1_GroupPage WHERE GroupGuid IN ('" + group.Guid + "')";
			list.Add(item);
			item = "DELETE FROM ShopNum1_GroupPageWebControl WHERE GroupGuid IN ('" + group.Guid + "')";
			list.Add(item);
			if (pageList.Count > 0)
			{
				for (int i = 0; i < pageList.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_GroupPage( GroupGuid,  PageGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
						group.Guid,
						"',  '",
						Operator.FilterString(pageList[i].ToString()),
						"',  '",
						group.CreateUser,
						"', '",
						group.CreateTime,
						"',  '",
						group.ModifyUser,
						"' , '",
						group.ModifyTime,
						"',  ",
						group.IsDeleted,
						")"
					});
					list.Add(item2);
					if (groupPageWebControlList.Count > 0)
					{
						for (int j = 0; j < groupPageWebControlList.Count; j++)
						{
							if (string.Equals(groupPageWebControlList[j].PageGuid.ToString(), pageList[i].ToString()))
							{
								string item3 = string.Concat(new object[]
								{
									"INSERT INTO ShopNum1_GroupPageWebControl( Guid, PageWebControlGuid,  PageGuid,  GroupGuid,  IsUse,  IsShow,  ControlID,  ControlType, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
									Guid.NewGuid(),
									"',  '",
									groupPageWebControlList[j].Guid,
									"',  '",
									groupPageWebControlList[j].PageGuid,
									"',  '",
									group.Guid,
									"',  ",
									groupPageWebControlList[j].IsUse,
									", ",
									groupPageWebControlList[j].IsShow,
									", '",
									groupPageWebControlList[j].ControlID,
									"',  '",
									groupPageWebControlList[j].ControlType,
									"',  '",
									group.CreateUser,
									"', '",
									group.CreateTime,
									"',  '",
									group.ModifyUser,
									"' , '",
									group.ModifyTime,
									"',  ",
									group.IsDeleted,
									")"
								});
								list.Add(item3);
							}
						}
					}
				}
			}
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
		public int CheckShotName(string shortName)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, ShortName FROM ShopNum1_Group WHERE ShortName='" + Operator.FilterString(shortName) + "'";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows.Count;
		}
	}
}
