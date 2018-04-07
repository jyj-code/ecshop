namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;

    public class ShopNum1_MemberActivate_Action : IShopNum1_MemberActivate_Action
    {
        public bool CheckKey(string type, string MemberID, string key, string typeinfo)
        {
            string strSql = ("SELECT * From ShopNum1_MemberActivate WHERE MemberID='" + MemberID + "'") + " AND [key]='" + key + "'";
            if (Operator.FilterString(type) != string.Empty)
            {
                if (type == "Email")
                {
                    strSql = strSql + " AND Email='" + typeinfo + "'";
                }
                if (type == "Mobile")
                {
                    strSql = strSql + " AND phone='" + typeinfo + "'";
                }
            }
            return (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0);
        }

        public string CheckMobileCode(string strkey, string mobile, string Type)
        {
            return DatabaseExcetue.ReturnString("SELECT COUNT([key]) FROM ShopNum1_MemberActivate   WHERE [key]='" + Operator.FilterString(strkey) + "' and phone='" + mobile + "' AND ExtireTime>GETDATE()");
        }

        public int DeleteKey(string MemberID, string Key)
        {
            return DatabaseExcetue.RunNonQuery(("Delete ShopNum1_MemberActivate WHERE MemberID='" + MemberID + "'") + "AND [key]='" + Key + "'");
        }

        public int DeleteKey(string MemberID, string strPhoneEmail, string strType)
        {
            string strSql = "Delete ShopNum1_MemberActivate WHERE Isinvalid = '0' And MemberID='" + MemberID + "'";
            if (strType.Equals("phone"))
            {
                strSql = strSql + " AND Type= '1' AND Phone = '" + Operator.FilterString(strPhoneEmail) + "'";
            }
            else
            {
                strSql = strSql + " AND Type = '0' AND Email = '" + Operator.FilterString(strPhoneEmail) + "'";
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public int InsertforGetMobileCode(ShopNum1_MemberActivate MemberActivate)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "insert into ShopNum1_MemberActivate([Guid],Phone,[key],MemberID,pwd ,Email,extireTime,isinvalid,type)Values('", MemberActivate.Guid, "','", MemberActivate.Phone, "','", MemberActivate.key, "','", MemberActivate.MemberID, "','", MemberActivate.pwd, "','", MemberActivate.Email, "','", MemberActivate.extireTime, "',", MemberActivate.isinvalid, 
                ",", MemberActivate.type, ")"
             }));
        }

        public int UpdateIsinvalid(string mobile, string MemberID, string key)
        {
            return DatabaseExcetue.RunNonQuery(" update  ShopNum1_MemberActivate set Isinvalid=1 where  [key]='" + key + "'  and phone='" + mobile + "' AND ExtireTime>GETDATE()  and type=1   and MemberID='" + MemberID + "'");
        }
    }
}
