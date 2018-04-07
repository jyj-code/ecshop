<%@ WebHandler Language="C#" Class="CheckAdminLogin" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Common;
using System.Web.UI.WebControls;
//using System.Web.HttpContext;

public class CheckAdminLogin : IHttpHandler
{

    string type;
    public void ProcessRequest(HttpContext context)
    {
        type = context.Request["type"];
        if (type == null)
        {
            return;
        }
        switch (type.ToLower().Trim())
        {
            //查询供求分类 
            case "checklogin":
                string loginID = HttpUtility.HtmlDecode(context.Request["loginID"].Trim());
                string pwd = context.Request["pwd"].Trim();
                string code = context.Request["code"].Trim();
                context.Response.Write(CheckLogin(loginID, Encryption.GetSHA1SecondHash(pwd), code));
                break;
            default:
                break;
        }
    }




    /// <summary>
    /// 判断用户名和密码是否正确
    /// </summary>
    /// <param name="loginID"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    protected string CheckLogin(string loginID, string pwd, string code)
    {
        string verifycodetype = HttpContext.Current.Request.Cookies["AdminLoginVerifyCode"].Value;
        if (code.ToLower() != verifycodetype.ToLower())
        {
            return "-2";
        }
        ShopNum1_User_Action userAction = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
        return userAction.CheckLogin(loginID, pwd, 0).ToString();
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}