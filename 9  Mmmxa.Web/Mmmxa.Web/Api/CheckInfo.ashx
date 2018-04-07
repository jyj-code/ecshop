<%@ WebHandler Language="C#" Class="CheckInfo" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Factory;
using ShopNum1.Email;
using ShopNum1.BusinessLogic;
/// <summary>
/// 手机验证     邮箱验证相关操作
/// </summary>
public class CheckInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.QueryString["type"] != null)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            string strtype = context.Request.QueryString["type"].ToString();
            string strTel = null, strEmail = null, strkey = null;
            switch (strtype)
            {
                case "1":
                    strTel = context.Request.QueryString["mobile"].ToString();
                    context.Response.Write(ExistMobileForFind(strTel));
                    break;
                case "2":
                    strTel = context.Request.QueryString["mobile"].ToString();
                    context.Response.Write(SendCodeForCheck(strTel)); break;
                case "3":
                    strkey = context.Request.QueryString["key"].ToString();
                    strTel = context.Request.QueryString["mobile"].ToString();
                    context.Response.Write(MemberMobileExec(strkey, strTel));
                    break;
                case "4":
                    strEmail = context.Request.QueryString["email"].ToString();
                    context.Response.Write(BindEmail(strEmail));
                    break;
                case "5":
                    strEmail = context.Request.QueryString["email"].ToString();
                    strkey = context.Request.QueryString["key"].ToString();
                    context.Response.Write(CheckEmalCode(strkey, strEmail, "0"));
                    break;
                case "6":
                    context.Response.Write(SendCodeForCheck()); break;
                case "7":
                    context.Response.Write(ExistMobileByMemloginId()); break;
                case "8":
                    strkey = context.Request.QueryString["key"].ToString();
                    context.Response.Write(MemberMobileExec(strkey)); break;
                case "9":
                    context.Response.Write(SendCodeForCheck()); break;
                case "10":
                    context.Response.Write(ExistMobileByMemloginId()); break;
                case "11":
                    strkey = context.Request.QueryString["key"].ToString();
                    context.Response.Write(MemberMobileExec(strkey)); break;
                case "12":
                    strEmail = context.Request.QueryString["email"].ToString();
                    context.Response.Write(CheckEmail(strEmail));
                    break;
                default: context.Response.Write("error"); break;
            }
        }

    }
    #region   邮箱绑定方法
    public string CheckEmail(string email)
    {
        ShopNum1_Member_Action Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

        int checkEmailCount = Member_Action.CheckmemEmail(email);
        if (checkEmailCount > 0)
        {
            checkEmailCount = Member_Action.CheckEmail(email, GetMemLoginId());
            if (checkEmailCount > 0)
            {
                //是这个会员邮箱 没有进行绑定
                return "1";
            }
            else
            {
                return "0";
            }


        }
        else
        {  //没有进行过绑定，可以进行绑定
            return "1";
        }
    }


    public string CheckEmalCode(string key, string email, string type)
    {
        string strEmailCode = Common.GetNameById("[key]", "shopNum1_MemberActivate", " and [key]='" + key + "' and email='" + email + "' and type='0' and extiretime>getdate()");
        if (strEmailCode != "")
        {
            Common.UpdateInfo("email='" + email + "',isemailactivation=1", "ShopNum1_Member", " and memloginid='" + GetMemLoginId() + "'");
            CheckEmail(email);
            return "1";
        }
        else { return "0"; }
    }

    protected void GetEmailSetting()
    {
        strEmailServer = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailServer"));
        strSMTP = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("SMTP"));
        strServerPort = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("ServerPort"));
        strEmailAccount = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailAccount"));
        strEmailPassword = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailPassword"));
        strRestoreEmail = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("RestoreEmail"));
        strEmailCode = HttpContext.Current.Server.HtmlDecode(ShopSettings.GetValue("EmailCode"));
    }
    #region 邮件设置
    string strEmailServer = string.Empty;
    string strSMTP = string.Empty;
    string strEmailAccount = string.Empty;
    string strServerPort = string.Empty;
    string strEmailPassword = string.Empty;
    string strRestoreEmail = string.Empty;
    string strEmailCode = string.Empty;
    //记录发送邮件的Title
    string strTitle = string.Empty;
    #endregion
    //从XML文档中读相应的参数
    //发邮件部分----从XML文档中读相应的参数,同时查询邮件发送记录参数
    public string BindEmail(string email)
    {
        ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = new ShopNum1_MemberActivate_Action();
        shopNum1_MemberActivate_Action.DeleteKey(GetMemLoginId(), email, "email");

        string strresult = "0";
        ShopNum1.Interface.IShopNum1_Member_Action memberAction = LogicFactory.CreateShopNum1_Member_Action();
        //发送邮件
        //调用模板邮件
        GetEmailSetting();
        NetMail netMail = new NetMail();
        HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie memlogincookie = ShopNum1.Common.HttpSecureCookie.Decode(cookie);
        string strMemLoginID = memlogincookie.Values["MemLoginID"];
        ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
        shopNum1_MemberActivate.Guid = Guid.NewGuid();
        shopNum1_MemberActivate.MemberID = GetMemLoginId();
        shopNum1_MemberActivate.pwd = "";
        shopNum1_MemberActivate.key = Encryption.GetMd5SecondHash(System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + new Random().Next().ToString()).Substring(0, 8);
        shopNum1_MemberActivate.type = 0;
        shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
        shopNum1_MemberActivate.Email = email;
        shopNum1_MemberActivate.isinvalid = 0;
        shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
        // 收件人姓名
        string strcontent = string.Empty;
        string emailTitle = string.Empty;
        string emailTemplentGuid;
        emailTemplentGuid = "fd885ca6-1624-4927-a080-6bcbc298d7fd";
        ShopNum1_Email_Action emailAction = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
        DataTable dataTabelemailAction = emailAction.GetEditInfo("'" + emailTemplentGuid + "'", 0);
        netMail.RecipientEmail = email;
        //邮件内容,从模块中读出来
        if (dataTabelemailAction.Rows.Count > 0)
        {
            strcontent = dataTabelemailAction.Rows[0]["Remark"].ToString();
            emailTitle = dataTabelemailAction.Rows[0]["Title"].ToString();
        }
        strcontent = strcontent.Replace("{$Name}", GetMemLoginId());
        strcontent = strcontent.Replace("{$ActivateKey}", shopNum1_MemberActivate.key);
        netMail.Subject = emailTitle;
        netMail.Body = HttpContext.Current.Server.HtmlDecode(strcontent);

        if (netMail.Send() != true)
        {
            ////发送失败,发送状态为0
            ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 0, netMail.Body);
            emailGroupSend.EmailTitle = "账户安全设置-绑定邮箱";
            //邮件发送历史的添加
            int check = emailAction.AddEmailGroupSend(emailGroupSend);
        }
        else
        {
            //发送成功,发送状态为2
            ShopNum1_EmailGroupSend emailGroupSend = Add(strMemLoginID, email, 2, netMail.Body);
            emailGroupSend.EmailTitle = "账户安全设置-绑定邮箱";
            //邮件发送历史的添加
            int check = emailAction.AddEmailGroupSend(emailGroupSend);
            //成功跳转页面  
            strresult = "1";
        }
        return strresult;
    }
    /// <summary>
    /// 建立ShopNum1_EmailGroupSend对象
    /// </summary>
    /// <param name="memLoginID">用户名</param>
    /// <param name="email">Email</param>
    /// <returns></returns>
    protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state, string sconts)
    {
        ShopNum1_EmailGroupSend emailGroupSend = new ShopNum1_EmailGroupSend();

        emailGroupSend.Guid = Guid.NewGuid();
        emailGroupSend.EmailTitle = strTitle;
        emailGroupSend.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        emailGroupSend.EmailGuid = new Guid("9d7b9b03-dfe5-4bd5-9eee-e0a1a86e347b");
        emailGroupSend.SendObjectEmail = sconts;
        emailGroupSend.SendObject = memLoginID + "-" + email;
        emailGroupSend.State = state;
        return emailGroupSend;
    }
    #endregion

    #region 手机绑定方法
    private int ExistMobileCode(string key, string mobile)
    {
        if (MemberMobileExec(key, mobile) != "")
        {
            Common.UpdateInfo("ismobileactivation=1", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
            return 1;
        }
        else
        {
            return 0;
        }
    }
    //检查验证码是否存在
    public string MemberMobileExec(string key)
    {
        try
        {
            string strMobile = Common.GetNameById("Mobile", "ShopNum1_Member", " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            if (shopNum1_MemberActivate_Action.CheckMobileCode(key, strMobile, "1") != "0")
            {
                return "1";
            }
            else
                return "0";
        }
        catch { return "0"; }
    }

    public string MemberMobileExec(string key, string mobile)
    {
        ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
        string check = shopNum1_MemberActivate_Action.CheckMobileCode(key, mobile, "1").ToString();
        return check;
    }

    //判断号码是否存在，如果存在并且状态的话，返回false 
    public string ExistMobileForFind(string mobile)
    {
        ShopNum1_Member_Action Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //是否存在
        int checkMobile = Member_Action.CheckBindMobile(mobile, "");
        if (checkMobile > 0)
        {
            //存在后，看这个号码是否绑定过
            checkMobile = Member_Action.CheckBindMobile(mobile, GetMemLoginId());
            {
                if (checkMobile > 0)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        else
        {
            return "1";
        }
    }


    private string ExistMobileByMemloginId()
    {
        string strMobile = Common.GetNameById("Mobile", "select Mobile from ShopNum1_Member ", " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
        if (strMobile != "")
        {
            return "1";

        }
        else
        {
            return "0";
        }
    }
    /// <summary>
    /// 获得登录名的方法
    /// </summary>
    /// <returns></returns>
    private string GetMemLoginId()
    {
        string name = "";
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
            name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
        }
        return name;
    }
    private string SendCodeForCheck()
    {
        try
        {
            string strMobile = Common.GetNameById("Mobile", "ShopNum1_Member ", " and memloginId='" + GetMemLoginId() + "' and mobile!=''");
            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
            if (strMobile != "")
            {
                shopNum1_MemberActivate.Guid = Guid.NewGuid();
                shopNum1_MemberActivate.key = new Random().Next(111111, 999999).ToString();
                shopNum1_MemberActivate.MemberID = GetMemLoginId();
                shopNum1_MemberActivate.Email = "";
                shopNum1_MemberActivate.Phone = strMobile;
                shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                shopNum1_MemberActivate.type = Convert.ToByte(2);
                shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
                shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);

                string strresult = "false";
                #region 模板读取
                string TempelteGuId = "1d6e0281-077d-4991-a53c-06ece146a07a";
                IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
                DataTable dataTableMMS = shopNum1_MMS_Action.GetEditInfo("'" + TempelteGuId + "'", 0);
                string strMsg = string.Empty;
                string strTitleMMS = string.Empty;
                if (dataTableMMS != null && dataTableMMS.Rows.Count > 0)
                {
                    strMsg = dataTableMMS.Rows[0]["Remark"].ToString();
                    strTitleMMS = dataTableMMS.Rows[0]["Title"].ToString();
                }
                strMsg = strMsg.Replace("{$Name}", GetMemLoginId());
                strMsg = strMsg.Replace("{$ActivateKey}", shopNum1_MemberActivate.key);
                #endregion
                string outstr = "";
                SMS sms = new SMS();
                sms.Send(strMobile.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strTitleMMS, strMsg, 2);
                }
                else
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strTitleMMS, strMsg, 0);
                }
                return "1";
            }
            else { return "0"; }
        }
        catch (Exception ex) { return ex.Message; }
    }
    /// <summary>
    /// 发送手机验证码
    /// </summary>
    /// <param name="strtel"></param>
    /// <returns></returns>
    private string SendCodeForCheck(string strMobile)
    {
        try
        {
            ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
            shopNum1_MemberActivate_Action.DeleteKey(GetMemLoginId(), strMobile, "phone");
            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
            if (strMobile != "")
            {
                shopNum1_MemberActivate.Guid = Guid.NewGuid();
                shopNum1_MemberActivate.key = new Random().Next(111111, 999999).ToString();
                shopNum1_MemberActivate.MemberID = GetMemLoginId();
                shopNum1_MemberActivate.Email = "";
                shopNum1_MemberActivate.Phone = strMobile;
                shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                shopNum1_MemberActivate.type = Convert.ToByte(2);
                shopNum1_MemberActivate.isinvalid = Convert.ToByte(0);
                shopNum1_MemberActivate_Action.InsertforGetMobileCode(shopNum1_MemberActivate);
                string strresult = "false";
                #region 模板读取
                string TempelteGuId = "1d6e0281-077d-4991-a53c-06ece146a07a";
                IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
                DataTable dataTableMMS = shopNum1_MMS_Action.GetEditInfo("'" + TempelteGuId + "'", 0);
                string strMsg = string.Empty;
                string strTitleMMS = string.Empty;
                if (dataTableMMS != null && dataTableMMS.Rows.Count > 0)
                {
                    strMsg = dataTableMMS.Rows[0]["Remark"].ToString();
                    strTitleMMS = dataTableMMS.Rows[0]["Title"].ToString() + "-绑定手机";
                }
                strMsg = strMsg.Replace("{$Name}", GetMemLoginId());
                strMsg = strMsg.Replace("{$ActivateKey}", shopNum1_MemberActivate.key);
                #endregion
                string outstr = "";
                SMS sms = new SMS();
                sms.Send(strMobile.Trim(), strMsg, out outstr);
                strresult = outstr;
                if (outstr.IndexOf("发送成功") != -1)
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strTitleMMS, strMsg, 2);
                }
                else
                {
                    InsertData(GetMemLoginId() + "-" + strMobile.Trim(), strMobile, strTitleMMS, strMsg, 0);


                }
                return "1";
            }
            else { return "0"; }

        }
        catch (Exception ex) { return ex.Message; }
    }
    /// <summary>
    /// 保存短信记录
    /// </summary>
    public void InsertData(string sendObject, string strMoible,string strTitle, string sendObjectMMS, int resultState)
    {
        ShopNum1_MMSGroupSend mms = new ShopNum1_MMSGroupSend();
        mms.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        mms.Guid = Guid.NewGuid();
        mms.IsTime = 0;
        mms.MMSGuid = new Guid("464595bb-4e2a-4240-9b5e-03871e8b1409");
        mms.MMSTitle = strTitle;
        mms.SendObject = sendObject;
        mms.SendObjectMMS = sendObjectMMS;
        mms.State = resultState;
        mms.TimeSendTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        ShopNum1_MMSGroupSend_Action MMSGroupSend_Action = new ShopNum1_MMSGroupSend_Action();
        MMSGroupSend_Action.Add(mms);

    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}