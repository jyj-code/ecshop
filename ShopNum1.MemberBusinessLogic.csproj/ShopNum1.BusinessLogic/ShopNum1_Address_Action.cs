namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;
    using System.Text;

    public class ShopNum1_Address_Action : IShopNum1_Address_Action
    {
        public int Add(ShopNum1_Address address)
        {
            if ((DatabaseExcetue.ReturnDataTable("SELECT Count(*) FROM ShopNum1_Address WHERE IsDefault=1 AND MemLoginID ='" + address.MemLoginID + "'").Rows.Count > 0) && (address.IsDefault == 1))
            {
                DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_Address SET  IsDefault =", 0, "  WHERE IsDefault =", 1, " AND MemLoginID ='", address.MemLoginID, "'" }));
            }
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "INSERT INTO ShopNum1_Address( \tGuid\t, \tName\t, \tEmail\t, \tAddress\t, \tArea\t, \tAddressCode\t  ,    AddressValue  ,\tPostalcode\t, \tTel\t, \tMobile\t, \tIsDefault\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '", address.Guid, "',  '", Operator.FilterString(address.Name), "',  '", Operator.FilterString(address.Email), "',  '", Operator.FilterString(address.Address), "',  '", Operator.FilterString(address.Area), "',  '", Operator.FilterString(address.AddressCode), "',  '", Operator.FilterString(address.AddressValue), "|',  '", Operator.FilterString(address.Postalcode), 
                "',  '", Operator.FilterString(address.Tel), "',  '", Operator.FilterString(address.Mobile), "',  ", address.IsDefault, ",  '", address.MemLoginID, "', '", Operator.FilterString(address.CreateUser), "', '", address.CreateTime, "',  '", Operator.FilterString(address.ModifyUser), "' , '", address.ModifyTime, 
                "',  ", address.IsDeleted, ")"
             }));
        }

        public int ChangeDefaultAddress(string MemLoginID, string Guid)
        {
            StringBuilder builder;
            ShopNum1_Address_Action action = new ShopNum1_Address_Action();
            if (action.SearchDefault(Guid) == "0")
            {
                builder = new StringBuilder();
                builder.Append(" UPDATE ShopNum1_Address SET IsDefault='" + 1 + "'");
                builder.Append(" WHERE Guid='" + Guid + "'");
                builder.Append(" and  MemLoginID='" + MemLoginID + "'");
                try
                {
                    if (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0)
                    {
                        StringBuilder builder2 = new StringBuilder();
                        builder2.Append(" UPDATE ShopNum1_Address set IsDefault=0  ");
                        builder2.Append(" WHERE Guid not in ('" + Guid + "')");
                        builder2.Append(" and  MemLoginID= '" + MemLoginID + "'");
                        return DatabaseExcetue.RunNonQuery(builder2.ToString());
                    }
                    return 0;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Address SET IsDefault='" + 0 + "'");
            builder.Append(" WHERE Guid='" + Guid + "'");
            builder.Append(" and  MemLoginID='" + MemLoginID + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int CheckDefaultAddress(string MemLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("select IsDefault From ShopNum1_Address WHERE MemLoginID ='" + MemLoginID + "' AND IsDefault =1 AND IsDeleted =0").Rows.Count;
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Address WHERE  Guid IN(" + guids + ")");
        }

        public DataTable GetAreaByCode(string code)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tArea  FROM ShopNum1_Address   WHERE  0=0";
            if (code != string.Empty)
            {
                strSql = strSql + " AND AddressCode='" + Operator.FilterString(code) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetRegionCode(string code)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionCode", paraName, paraValue);
        }

        public DataTable Search(string guid)
        {
            string str = string.Empty;
            str = "SELECT Guid, Name\t, Email\t, Area\t, Address\t, AddressCode , AddressValue , Postalcode\t, Tel\t, Mobile\t, IsDefault\t, MemLoginID\t, CreateUser\t, CreateTime\t, ModifyUser\t, ModifyTime\t, IsDeleted  FROM ShopNum1_Address ";
            if (guid != string.Empty)
            {
                str = str + " WHERE Guid='" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "order by IsDefault desc  ");
        }

        public DataTable Search(string memberLoginID, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tName\t, \tEmail\t, \tAddress\t, \tAddressCode\t,    AddressValue, \tArea\t, \tPostalcode\t, \tTel\t, \tMobile\t, \tIsDefault\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_Address   WHERE  0=0";
            if (memberLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + memberLoginID + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by IsDefault desc ");
        }

        public string SearchDefault(string guid)
        {
            return DatabaseExcetue.ReturnString("Select  isdefault from ShopNum1_Address where guid='" + guid + "'");
        }

        public DataTable SelectAddress_List(CommonPageModel commonModel)
        {
            string[] paraName = new string[8];
            string[] paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int Update(ShopNum1_Address address)
        {
            if ((DatabaseExcetue.ReturnDataTable("SELECT Count(*) FROM ShopNum1_Address WHERE IsDefault=1 AND MemLoginID ='" + address.MemLoginID + "'").Rows.Count > 0) && (address.IsDefault == 1))
            {
                DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_Address SET  IsDefault =", 0, "  WHERE IsDefault =", 1, " AND MemLoginID ='", address.MemLoginID, "'" }));
            }
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "UPDATE  ShopNum1_Address SET  Name ='", Operator.FilterString(address.Name), "', Email\t='", Operator.FilterString(address.Email), "', Address ='", Operator.FilterString(address.Address), "', Postalcode ='", Operator.FilterString(address.Postalcode), "', AddressCode='", Operator.FilterString(address.AddressCode), "', AddressValue ='", Operator.FilterString(address.AddressValue), "', Tel\t= '", Operator.FilterString(address.Tel), "', Mobile ='", Operator.FilterString(address.Mobile), 
                "', Area ='", Operator.FilterString(address.Area), "', ModifyUser ='", Operator.FilterString(address.ModifyUser), "', ModifyTime ='", address.ModifyTime, "' WHERE Guid ='", address.Guid, "' AND MemLoginID ='", address.MemLoginID, "'"
             }));
        }
    }
}

