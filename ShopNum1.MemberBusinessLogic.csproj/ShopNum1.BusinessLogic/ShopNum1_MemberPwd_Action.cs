namespace ShopNum1.BusinessLogic
{
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public class ShopNum1_MemberPwd_Action : IShopNum1_MemberPwd_Action
    {
        public DataTable CheckLink(string pwdkey, string type)
        {
            return DatabaseExcetue.ReturnDataTable((((string.Empty + " select * from  ShopNum1_MemberPwd ") + " where type=" + type) + "   and pwdkey='" + pwdkey + "'") + "   and extireTime>'" + DateTime.Now.ToString() + "'");
        }

        public int MemberPwdInsert(ShopNum1_MemberPwd MemberPwd)
        {
            string[] paraName = new string[6];
            string[] paraValue = new string[6];
            paraName[0] = "@pwdkey";
            paraValue[0] = MemberPwd.pwdkey;
            paraName[1] = "@memberid";
            paraValue[1] = MemberPwd.MemberID;
            paraName[2] = "@pwd";
            paraValue[2] = MemberPwd.pwd;
            paraName[3] = "@email";
            paraValue[3] = MemberPwd.Email;
            paraName[4] = "@extiretime";
            paraValue[4] = MemberPwd.extireTime.ToString();
            paraName[5] = "@type";
            paraValue[5] = MemberPwd.type.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_MemberPwdInsert", paraName, paraValue);
        }

        public DataTable ShopNum1MemberPwdExec(string pwdkey, string type)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@pwdkey";
            paraValue[0] = pwdkey;
            paraName[1] = "@type";
            paraValue[1] = type;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberPwdExec", paraName, paraValue);
        }

        public int UpdatePwd(string pwdkey, string type, string string_0)
        {
            return DatabaseExcetue.RunNonQuery(((string.Empty + " update ShopNum1_MemberPwd set pwd='" + string_0 + "'") + " where type=" + type) + "   and pwdkey='" + pwdkey + "'");
        }
    }
}

