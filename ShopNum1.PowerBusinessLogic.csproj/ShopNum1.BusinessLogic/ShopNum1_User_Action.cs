using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_User_Action : IShopNum1_User_Action
    {
        public int CheckLogin(string loginID, string string_0, int isDeleted)
        {
            string text = string.Empty;
            text = "SELECT Guid, LoginId,Pwd,RealName, IsDeleted, IsForbid,DeptGuid FROM ShopNum1_User WHERE 0=0";
            if (loginID != string.Empty)
            {
                text = text + " AND LoginID='" + Operator.FilterString(loginID) + "'";
            }
            if (string_0 != string.Empty)
            {
                text = text + " AND Pwd='" + Operator.FilterString(string_0) + "'";
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
            DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
            int result;
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                result = 0;
            }
            else
            {
                int count = dataTable.Rows.Count;
                if (count > 0)
                {
                    if (dataTable.Rows[0]["IsForbid"].ToString() == "1")
                    {
                        result = -1;
                    }
                    else
                    {
                        result = count;
                    }
                }
                else
                {
                    result = count;
                }
            }
            return result > 1 ? 1 : result;
        }
        public int CheckLogin(string loginID, string string_0, int isDeleted, string SubstationID)
        {
            string text = string.Empty;
            text = "SELECT Guid, LoginId,Pwd,RealName, IsDeleted, IsForbid,DeptGuid FROM ShopNum1_User WHERE 0=0";
            if (loginID != string.Empty)
            {
                text = text + " AND LoginID='" + Operator.FilterString(loginID) + "'";
            }
            if (string_0 != string.Empty)
            {
                text = text + " AND Pwd='" + Operator.FilterString(string_0) + "'";
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
            if (!string.IsNullOrEmpty(SubstationID))
            {
                text = text + " AND  SubstationID='" + SubstationID + "'";
            }
            DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
            int result;
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                result = 0;
            }
            else
            {
                int count = dataTable.Rows.Count;
                if (count > 0)
                {
                    if (dataTable.Rows[0]["IsForbid"].ToString() == "1")
                    {
                        result = -1;
                    }
                    else
                    {
                        result = count;
                    }
                }
                else
                {
                    result = count;
                }
            }
            return result;
        }
        public int Add(ShopNum1_User user, List<string> strGrouplList)
        {
            List<string> list = new List<string>();
            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_User( Guid,  LoginId, Pwd, RealName, Sex, DeptGuid, IsSuperAdmin, Age,WorkNumber, Email, Telephone, IsForbid, LoginTimes, LastLoginIP, LastLoginTime, LastModifyPasswordTime, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted,  SubstationID,   PeopleType ) VALUES (  '",
                user.Guid,
                "',  '",
                Operator.FilterString(user.LoginId),
                "',  '",
                Operator.FilterString(user.Pwd),
                "',  '",
                Operator.FilterString(user.RealName),
                "',  ",
                user.Sex,
                ",  '",
                user.DeptGuid,
                "',  0,  ",
                user.Age,
                ",  '",
                Operator.FilterString(user.WorkNumber),
                "',  '",
                Operator.FilterString(user.Email),
                "',  '",
                Operator.FilterString(user.Telephone),
                "',  ",
                user.IsForbid,
                ",  ",
                user.LoginTimes,
                ",  '",
                user.LastLoginTime,
                "',  '",
                Operator.FilterString(user.LastLoginIP),
                "',  '",
                user.LastModifyPasswordTime,
                "',  '",
                user.CreateUser,
                "', '",
                user.CreateTime,
                "',  '",
                user.ModifyUser,
                "' , '",
                user.ModifyTime,
                "',  '",
                user.IsDeleted,
                "',  '",
                user.SubstationID,
                "',  ",
                user.PeopleType,
                ")"
            });
            list.Add(item);
            for (int i = 0; i < strGrouplList.Count; i++)
            {
                string item2 = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
                    strGrouplList[i].ToString(),
                    "',  '",
                    user.Guid,
                    "',  '",
                    user.CreateUser,
                    "', '",
                    user.CreateTime,
                    "',  '",
                    user.ModifyUser,
                    "' , '",
                    user.ModifyTime,
                    "',  ",
                    user.IsDeleted,
                    ")"
                });
                list.Add(item2);
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
        public int Delete(string guids)
        {
            string item = string.Empty;
            List<string> list = new List<string>();
            item = "DELETE FROM ShopNum1_GroupUser WHERE UserGuid IN (" + guids + ")";
            list.Add(item);
            item = "DELETE FROM ShopNum1_User WHERE Guid IN (" + guids + ")";
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
        public DataTable Search(string realName, string deptGuid, int isForbid, int IsDeleted)
        {
            string text = string.Empty;
            text = "SELECT A.Guid, A.LoginId, A.Pwd, A.RealName, A.Sex, A.DeptGuid, A.Age, A.WorkNumber, A.Email, A.Telephone, A.IsForbid, A.LoginTimes, A.LastLoginTime, A.LastLoginIP,  A.LastModifyPasswordTime, A.CreateUser, A.CreateTime, A.ModifyUser, A.ModifyTime, A.IsDeleted, B.Name AS DeptName  FROM ShopNum1_User AS A LEFT JOIN ShopNum1_Dept  AS B ON  A.DeptGuid=B.Guid WHERE 0=0 ";
            if (realName != string.Empty && realName != "" && realName != null)
            {
                text = text + " AND A.loginid Like '%" + Operator.FilterString(realName) + "%'";
            }
            if (deptGuid != string.Empty && deptGuid != "-1")
            {
                text = text + " AND A.DeptGuid='" + deptGuid + "'";
            }
            if (isForbid == 0 || isForbid == 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    " AND A.IsForbid=",
                    isForbid,
                    " "
                });
            }
            if (IsDeleted == 0 || IsDeleted == 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    " AND A.IsDeleted=",
                    IsDeleted,
                    " "
                });
            }
            text += "Order by A.CreateTime Desc";
            return DatabaseExcetue.ReturnDataTable(text);
        }
        public DataTable Search(string realName, string deptGuid, int isForbid, int IsDeleted, string SubstationID)
        {
            string text = string.Empty;
            text = "SELECT A.Guid, A.LoginId, A.Pwd, A.RealName, A.Sex, A.DeptGuid, A.Age, A.WorkNumber, A.Email, A.Telephone, A.IsForbid, A.LoginTimes, A.LastLoginTime, A.LastLoginIP,  A.LastModifyPasswordTime, A.CreateUser, A.CreateTime, A.ModifyUser, A.ModifyTime, A.IsDeleted,A.SubstationID, B.Name AS DeptName  FROM ShopNum1_User AS A LEFT JOIN ShopNum1_Dept  AS B ON  A.DeptGuid=B.Guid WHERE 0=0 ";
            if (realName != string.Empty && realName != "" && realName != null)
            {
                text = text + " AND A.loginid Like '%" + Operator.FilterString(realName) + "%'";
            }
            if (deptGuid != string.Empty && deptGuid != "-1")
            {
                text = text + " AND A.DeptGuid='" + deptGuid + "'";
            }
            if (isForbid == 0 || isForbid == 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    " AND A.IsForbid=",
                    isForbid,
                    " "
                });
            }
            if (IsDeleted == 0 || IsDeleted == 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    " AND A.IsDeleted=",
                    IsDeleted,
                    " "
                });
            }
            if (!string.IsNullOrEmpty(SubstationID) && SubstationID != "-1")
            {
                text = text + " AND A.SubstationID='" + SubstationID + "'";
            }
            text += "Order by A.CreateTime Desc";
            return DatabaseExcetue.ReturnDataTable(text);
        }
        public DataTable GetUserByDept(string deptGuid, int IsDeleted)
        {
            string text = string.Empty;
            text = "SELECT Guid, LoginId, RealName, IsDeleted, DeptGuid FROM ShopNum1_User WHERE 0=0";
            if (deptGuid != string.Empty)
            {
                text = text + " AND DeptGuid='" + deptGuid + "'";
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
        public DataTable GetUserByGuid(string guid, int IsDeleted)
        {
            string text = string.Empty;
            text = "SELECT A.Guid, A.LoginId, A.Pwd, A.RealName, A.Sex, A.Age, A.WorkNumber, A.Email, A.Telephone, A.IsForbid, A.LoginTimes, A.LastLoginTime, A.LastLoginIP, A.LastModifyPasswordTime,  A.CreateUser, A.CreateTime, A.ModifyUser, A.ModifyTime, A.IsDeleted, A.DeptGuid,B.GroupGuid,A.peopletype FROM ShopNum1_User AS A LEFT JOIN ShopNum1_GroupUser AS B ON  A.Guid=B.UserGuid WHERE 0=0";
            if (guid != string.Empty)
            {
                text = text + " AND A.Guid='" + guid + "'";
            }
            if (IsDeleted == 0 || IsDeleted == 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    " AND A.IsDeleted=",
                    IsDeleted,
                    " "
                });
            }
            return DatabaseExcetue.ReturnDataTable(text);
        }
        public DataTable GetUserByLoginID(string loginID, int IsDeleted)
        {
            string text = string.Empty;
            text = "SELECT Guid, LoginId, RealName, IsDeleted, DeptGuid, PeopleType,SubstationID  FROM ShopNum1_User WHERE 0=0";
            if (loginID != string.Empty)
            {
                text = text + " AND LoginID='" + loginID + "'";
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
        public int Update(ShopNum1_User user, List<string> strGrouplList)
        {
            string item = string.Empty;
            List<string> list = new List<string>();
            if (user.Pwd != null)
            {
                item = string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_User SET  Pwd='",
                    Operator.FilterString(user.Pwd),
                    "', RealName='",
                    Operator.FilterString(user.RealName),
                    "', Sex=",
                    user.Sex,
                    ", DeptGuid='",
                    user.DeptGuid,
                    "', Age=",
                    user.Age,
                    ", WorkNumber='",
                    Operator.FilterString(user.WorkNumber),
                    "', Email='",
                    Operator.FilterString(user.Email),
                    "', Telephone='",
                    Operator.FilterString(user.Telephone),
                    "', IsForbid=",
                    user.IsForbid,
                    ", ModifyUser='",
                    user.ModifyUser,
                    "', LastModifyPasswordTime='",
                    user.LastModifyPasswordTime,
                    "', ModifyTime='",
                    user.ModifyTime,
                    "', PeopleType='",
                    user.PeopleType,
                    "'WHERE Guid='",
                    user.Guid,
                    "'"
                });
            }
            else
            {
                item = string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_User SET  RealName='",
                    Operator.FilterString(user.RealName),
                    "', Sex=",
                    user.Sex,
                    ", DeptGuid='",
                    user.DeptGuid,
                    "', Age=",
                    user.Age,
                    ", WorkNumber='",
                    Operator.FilterString(user.WorkNumber),
                    "', Email='",
                    Operator.FilterString(user.Email),
                    "', Telephone='",
                    Operator.FilterString(user.Telephone),
                    "', IsForbid=",
                    user.IsForbid,
                    ", ModifyUser='",
                    user.ModifyUser,
                    "', ModifyTime='",
                    user.ModifyTime,
                    "', PeopleType='",
                    user.PeopleType,
                    "'WHERE Guid='",
                    user.Guid,
                    "'"
                });
            }
            list.Add(item);
            item = "DELETE FROM ShopNum1_GroupUser WHERE  UserGuid='" + user.Guid + "'";
            list.Add(item);
            for (int i = 0; i < strGrouplList.Count; i++)
            {
                string item2 = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
                    strGrouplList[i].ToString(),
                    "',  '",
                    user.Guid,
                    "',  '",
                    user.ModifyUser,
                    "', '",
                    user.ModifyTime,
                    "',  '",
                    user.ModifyUser,
                    "' , '",
                    user.ModifyTime,
                    "',  ",
                    user.IsDeleted,
                    ")"
                });
                list.Add(item2);
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
        public int UpdateLoginInfo(ShopNum1_User user)
        {
            string strSql = string.Empty;
            strSql = string.Concat(new object[]
            {
                "UPDATE  ShopNum1_User SET LoginTimes=LoginTimes+1, LastLoginTime='",
                user.LastLoginTime,
                "', LastLoginIP='",
                user.LastLoginIP,
                "'WHERE LoginId='",
                user.LoginId,
                "'"
            });
            return DatabaseExcetue.RunNonQuery(strSql);
        }
        public int UpdatePwd(string name, string oldPwd, string newPwd)
        {
            string strSql = string.Empty;
            strSql = string.Concat(new string[]
            {
                "update ShopNum1_User set Pwd='",
                newPwd,
                "',LastModifyPasswordTime='",
                DateTime.Now.ToString(),
                "'  where Pwd='",
                oldPwd,
                "' and LoginId='",
                name,
                "'"
            });
            return DatabaseExcetue.RunNonQuery(strSql);
        }
        public string SearchSupperAdminName()
        {
            DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchSupperAdminName");
            string result;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                result = dataTable.Rows[0]["LoginId"].ToString();
            }
            else
            {
                result = "";
            }
            return result;
        }
        public int Add(ShopNum1_User user, ShopNum1_GroupUser GroupUser, List<string> strGrouplList)
        {
            List<string> list = new List<string>();
            string item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_User( Guid,  LoginId, Pwd, RealName, Sex, DeptGuid, IsSuperAdmin, Age,WorkNumber, Email, Telephone, IsForbid, LoginTimes, LastLoginIP, LastLoginTime, LastModifyPasswordTime, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted,   PeopleType ) VALUES (  '",
                user.Guid,
                "',  '",
                Operator.FilterString(user.LoginId),
                "',  '",
                Operator.FilterString(user.Pwd),
                "',  '",
                Operator.FilterString(user.RealName),
                "',  ",
                user.Sex,
                ",  '",
                user.DeptGuid,
                "',  0,  ",
                user.Age,
                ",  '",
                Operator.FilterString(user.WorkNumber),
                "',  '",
                Operator.FilterString(user.Email),
                "',  '",
                Operator.FilterString(user.Telephone),
                "',  ",
                user.IsForbid,
                ",  ",
                user.LoginTimes,
                ",  '",
                user.LastLoginTime,
                "',  '",
                Operator.FilterString(user.LastLoginIP),
                "',  '",
                user.LastModifyPasswordTime,
                "',  '",
                user.CreateUser,
                "', '",
                user.CreateTime,
                "',  '",
                user.ModifyUser,
                "' , '",
                user.ModifyTime,
                "',  '",
                user.IsDeleted,
                "',  ",
                user.PeopleType,
                ")"
            });
            list.Add(item);
            string item2 = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_GroupUser( GroupGuid,  UserGuid, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
                GroupUser.GroupGuid,
                "',  '",
                user.Guid,
                "',  '",
                user.CreateUser,
                "', '",
                user.CreateTime,
                "',  '",
                user.ModifyUser,
                "' , '",
                user.ModifyTime,
                "',  ",
                user.IsDeleted,
                ")"
            });
            list.Add(item2);
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
    }
}
