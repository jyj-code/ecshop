<%@ WebHandler Language="C#" Class="shopfeetemplate" %>

using System;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

public class shopfeetemplate : IHttpHandler
{
    public delegate void GetJson(string path, string memlgoid, string postid, string regioncode, string type, bool ishavcache);//定义委托
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
        context.Response.Expires = 0;
        context.Response.CacheControl = "no-cache";
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

                    sbuilder.Append("[");
                    for (int i = 0; i < datatableFee.Rows.Count; i++)
                    {

                        sbuilder.Append("{\"feetype\":\"" + datatableFee.Rows[i]["feetype"].ToString() + "\",\"fee\":\"" + Convert.ToDecimal(datatableFee.Rows[i]["fee"]) + "\",\"oneadd\":\"" + datatableFee.Rows[i]["oneadd"].ToString() + "\"},");
                    }

                    sbuilder.Remove(sbuilder.Length - 1, 1);
                    sbuilder.Append("]");
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
        ///要返回数据的类型
        string feetype = context.Request["type"].ToString();
        //传来地区处理数据
        if (feetype == "fee")
        {
            string path = context.Request["path"].ToString() + "xml/PostageTemplate.xml";
            string provincecode = context.Request["code"].ToString();
            string feetemplateid = context.Request["feetemplateid"].ToString();
            ///返回json数据
            GetShopFeeTemplate(HttpContext.Current.Server.MapPath(path), "", feetemplateid, provincecode, feetype, false);
        }
        ///处理模板名称
        else if (feetype == "feename")
        {
            string templatename = context.Request["templatename"].ToString();
            IsFeeNameSame(templatename);
        }
        else if (feetype == "GetFreeTemplate")//立即购买
        {
            #region 更改地区显示不同邮费
            string ProductGuid = context.Request["productguid"].ToString();
            Shop_ShopInfo_Action shopinfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            DataTable dt = shopinfo_Action.GetShopOpentimeByProductGuid(ProductGuid);
            string shopUrl = string.Empty;
            string shoppath = string.Empty;
            if (null != dt && dt.Rows.Count > 0)
            {
                shopUrl = dt.Rows[0]["ShopId"].ToString();
                string openTime = DateTime.Parse(dt.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                shoppath = "~/Shop/Shop/" + openTime.Replace("-", "/") + "/Shop" + shopUrl.Trim() + "/";
            }
            string path = shoppath + "xml/PostageTemplate.xml";
            string provincecode = context.Request["code"].ToString().Substring(0, 3);
            string feetemplateid = context.Request["feetemplateid"].ToString();
            ///返回json数据
            GetShopFeeTemplate(HttpContext.Current.Server.MapPath(path), "", feetemplateid, provincecode, "fee", false);
            #endregion
        }
        else if (feetype == "GetMoreFreeTemplate")//加入购物车
        {
            #region 更改地区显示不同邮费
            string MemloginId = context.Request["productguid"].ToString();//多个店铺的MemloginId
            string provincecode =Common.cut(context.Request["code"], 3);
            string feetemplateid = context.Request["feetemplateid"].ToString();//feetemplateid,Express_fee,Ems_fee,Post_fee,BuyNumber

            string[] MemloginIdArry = MemloginId.Split(',');
            
            int IsFeeType = 0;
            System.Text.StringBuilder strFeeTemplate = new System.Text.StringBuilder();
            strFeeTemplate.Append("[");
            for (int i = 0; i < MemloginIdArry.Length; i++)
            {
                decimal Post_fee = Convert.ToDecimal(0.00), Express_fee = Convert.ToDecimal(0.00), Ems_fee = Convert.ToDecimal(0.00);
                ShopNum1_ShopInfoList_Action shopinfo_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
                DataTable dt = shopinfo_Action.GetShopIDByMemLoginID(MemloginIdArry[i]);
                string shopUrl = string.Empty;
                string shoppath = string.Empty;
                if (null != dt && dt.Rows.Count > 0)
                {
                    shopUrl = dt.Rows[0]["ShopId"].ToString();
                    string openTime = DateTime.Parse(dt.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    shoppath = "~/Shop/Shop/" + openTime.Replace("-", "/") + "/Shop" + shopUrl.Trim() + "/";
                }
                string path = shoppath + "xml/PostageTemplate.xml";

                #region 首先判断是用邮费模版还是填写的邮费
                string[] feetemplateArry = feetemplateid.Split('|');
                for (int j = 0; j < feetemplateArry.Length; j++)
                {
                    if (feetemplateArry[j] == "")
                    {
                        IsFeeType = 1;
                        //有邮费模版
                        if (feetemplateArry[j].Split(',')[0] != null && feetemplateArry[j].Split(',')[0] != "" && feetemplateArry[j].Split(',')[0] != "0")
                        {
                            ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                            DataTable datatableFee = FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1", "'" + feetemplateArry[j].Split(',')[0] + "'", provincecode, "-1", false);
                            if (datatableFee != null)
                            {
                                foreach (DataRow row in datatableFee.Rows)
                                {
                                    decimal Price = Convert.ToDecimal(row["fee"].ToString()) + (int.Parse(feetemplateArry[j].Split(',')[4]) - 1) * Convert.ToDecimal(row["oneadd"].ToString());
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
                            if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[1]))
                            {
                                Express_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[1]);
                            }
                            if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[2]))
                            {
                                Ems_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[2]);
                            }
                            if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[3]))
                            {
                                Post_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[3]);
                            }
                        }
                    }
                    strFeeTemplate.Append("{\"Express\":\"" + Express_fee + "\",\"Ems\":\"" + Ems_fee + "\",\"Post\":\"" + Post_fee + "\"},");
                }
                #endregion
            }

         
            if (IsFeeType == 1)
            {
                //strFeeTemplate.Append("[{\"Express\":\"" + Express_fee + "\",\"Ems\":\"" + Ems_fee + "\",\"Post\":\"" + Post_fee + "\"}]");
                strFeeTemplate.Remove(strFeeTemplate.Length - 1, 1);
                strFeeTemplate.Append("]");
            }
            else
            {
                strFeeTemplate.Append("[{}]");
            }
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(strFeeTemplate.ToString());
            #endregion

        }
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