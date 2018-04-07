namespace ShopNum1.Interface
{
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public interface IShopNum1_MemberPwd_Action
    {
        DataTable CheckLink(string pwdkey, string type);
        int MemberPwdInsert(ShopNum1_MemberPwd MemberPwd);
        DataTable ShopNum1MemberPwdExec(string pwdkey, string type);
        int UpdatePwd(string pwdkey, string type, string pwd);
    }
}

