<%@ WebHandler Language="C#" Class="Appshopfeetemplate" %>

using System;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using System.Data;
using ShopNum1.BusinessLogic;

public class Appshopfeetemplate : IHttpHandler
{
    public delegate void GetJson(string path, string memlgoid, string postid, string regioncode, string type, bool ishavcache);//定义委托
    public void ProcessRequest(HttpContext context)
    {
        //定义方法
        GetJson GetShopFeeTemplate = (a, m, b, c, d, g) =>
        {

            System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();

            //
            if (d == "fee")
            {
                //prod

                ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                string strerror = string.Empty;//错误提示
                if (b.Length > 1)
                { b = "'" + b + "'"; }
                System.Data.DataTable datatableFee = FeeTemplate_Action.GetFeesByFrontCache(a, m, b, c, "-1", false);
                if (datatableFee == null || datatableFee.Rows.Count == 0)
                {
                    sbuilder.Append("[{}]");
                }
                else
                {
                    string ordernumber = context.Request["ordernumber"].ToString();
                    sbuilder.Append("[{");
                    for (int i = 0; i < datatableFee.Rows.Count; i++)
                    {
                        decimal Price = Convert.ToDecimal(datatableFee.Rows[i]["fee"].ToString()) + (int.Parse(ordernumber) - 1) * Convert.ToDecimal(datatableFee.Rows[i]["oneadd"].ToString());
                        if (datatableFee.Rows[i]["feetype"].ToString() == "1")
                        {
                            sbuilder.Append("\"post\":\"" + Price + "\",");
                        }
                        if (datatableFee.Rows[i]["feetype"].ToString() == "2")
                        {
                            sbuilder.Append("\"express\":\"" + Price + "\",");
                        }
                        if (datatableFee.Rows[i]["feetype"].ToString() == "3")
                        {
                            sbuilder.Append("\"ems\":\"" + Price + "\",");
                        }
                    }

                    sbuilder.Remove(sbuilder.Length - 1, 1);
                    sbuilder.Append("}]");

                }
            }

            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(sbuilder.ToString());
        };

        ////验证合法性
        object getyz = context.Request["yz"];//
        if (getyz == null || getyz.ToString() != "shopnum1ntbl")
        {

            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write("[{}]");
            return;
        }
        #region 更改地区显示不同邮费
        string ProductGuid = context.Request["productguid"].ToString();//ProductGuid，BuyNumber|ProductGuid，BuyNumber
        string callback = context.Request["callback"].ToString();
        string[] ProductGuidArry = ProductGuid.Split('|');

        int IsFeeType = 0;
        decimal Post_fee = Convert.ToDecimal(0.00), Express_fee = Convert.ToDecimal(0.00), Ems_fee = Convert.ToDecimal(0.00);
        for (int i = 0; i < ProductGuidArry.Length; i++)
        {
            Shop_ShopInfo_Action shopinfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            DataTable dt = shopinfo_Action.GetShopOpentimeByProductGuid(ProductGuidArry[i].Split(',')[0]);
            string shopUrl = string.Empty;
            string shoppath = string.Empty;
            if (null != dt && dt.Rows.Count > 0)
            {
                shopUrl = dt.Rows[0]["ShopUrl"].ToString();
                string shopmonth = dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[1].Length == 1 ? "0" + dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[1] : dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[1];
                string shopday = dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[2].Length == 1 ? "0" + dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[2] : dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[2];
                shoppath = "~/Shop/Shop/" + dt.Rows[0]["opentime"].ToString().Substring(0, 10).Split('-')[0].Trim() + "/" + shopmonth.Trim() + "/" + shopday.Trim() + "/" + shopUrl.Trim() + "/";

                string path = shoppath + "xml/PostageTemplate.xml";
                string provincecode = context.Request["code"].ToString();
                if (!string.IsNullOrEmpty(provincecode))
                {
                    provincecode = provincecode.Substring(0, 3);
                }
                //有邮费
                if (dt.Rows[0]["FeeTemplateID"].ToString() != null && dt.Rows[0]["FeeTemplateID"].ToString() != "" && dt.Rows[0]["FeeTemplateID"].ToString() != "0")
                {
                    IsFeeType = 1;
                    ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                    DataTable datatableFee = FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1", "'" + dt.Rows[0]["FeeTemplateID"].ToString() + "'", provincecode, "-1", false);
                    if (datatableFee != null)
                    {
                        foreach (DataRow row in datatableFee.Rows)
                        {
                            decimal Price = Convert.ToDecimal(row["fee"].ToString()) + (int.Parse(ProductGuidArry[i].Split(',')[1]) - 1) * Convert.ToDecimal(row["oneadd"].ToString());
                            if (row["feetype"].ToString() == "1")
                            {
                                Post_fee += Price;
                            }
                            else if (row["feetype"].ToString() == "2")
                            {
                                Express_fee += Price;
                            }
                            else if (row["feetype"].ToString() == "3")
                            {
                                Ems_fee += Price;
                            }
                        }
                    }
                }
                else
                {
                    IsFeeType = 1;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Post_fee"].ToString()))
                    {
                        Post_fee += Convert.ToDecimal(dt.Rows[0]["Post_fee"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Express_fee"].ToString()))
                    {
                        Express_fee += Convert.ToDecimal(dt.Rows[0]["Express_fee"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Ems_fee"].ToString()))
                    {
                        Ems_fee += Convert.ToDecimal(dt.Rows[0]["Ems_fee"].ToString());
                    }
                    if (Post_fee == 0 && Express_fee == 0 && Ems_fee == 0)
                    {
                        IsFeeType = 0;//包邮
                    }
                }
            }
        }
        System.Text.StringBuilder strFeeTemplate = new System.Text.StringBuilder();
        if (IsFeeType == 1)//有邮费
        {
            strFeeTemplate.Append(callback + "([{\"Express\":\"" + Express_fee + "\",\"Ems\":\"" + Ems_fee + "\",\"Post\":\"" + Post_fee + "\"}])");
        }
        else
        {
            strFeeTemplate.Append(callback + "([{}])");
        }
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Write(strFeeTemplate.ToString());
        ///返回json数据
        //GetShopFeeTemplate(HttpContext.Current.Server.MapPath(path), "", feetemplateid, provincecode, "fee", false);
        #endregion

    }

    /// <summary>
    /// 检查模板名称重复性
    /// </summary>
    /// <param name="feename"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public void IsFeeNameSame(string feename)
    {

        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {                //退出

            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = ShopNum1.Common.HttpSecureCookie.Decode(cookieShopMemberLogin);
            string MemberType = decodedCookieShopMemberLogin.Values["MemberType"].ToString();
            if (MemberType == "2")
            {
                string memlogid = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
                ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                string path = GetFeeTemplatePath(memlogid);///xml路径
                if (FeeTemplate_Action.CheckTemplateName(feename, HttpContext.Current.Server.MapPath(path)))
                {
                    HttpContext.Current.Response.Write("1");
                }
                else
                {
                    HttpContext.Current.Response.Write("0");
                }

            }
            //会员登录ID
            return;
        }
        HttpContext.Current.Response.Write("-1");

    }

    /// <summary>
    /// 调用邮费模板xml所在位置
    /// </summary>
    /// <returns></returns>
    private string GetFeeTemplatePath(string memlogid)
    {
        ShopNum1.ShopBusinessLogic.Shop_ShopInfo_Action shopInfo_Action = (ShopNum1.ShopBusinessLogic.Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
        System.Data.DataTable dataTable = shopInfo_Action.GetMemLoginInfo(memlogid);
        string shopid = dataTable.Rows[0]["ShopID"].ToString();
        string OpenTime = DateTime.Parse(dataTable.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
        return "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid + "/xml/PostageTemplate.xml";

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}