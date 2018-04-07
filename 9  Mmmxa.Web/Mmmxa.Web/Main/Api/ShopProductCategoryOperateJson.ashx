<%@ WebHandler Language="C#" Class="ShopProductCategoryOperateJson" %>

using System;
using System.Web;


public class ShopProductCategoryOperateJson : IHttpHandler {
    
    public delegate void GetJson(string catype,string category);//定义委托
    public void ProcessRequest (HttpContext context) {
        //定义方法
        GetJson GetCategory = (a,b) => 
        {

            System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();

            //如果是品牌
            if (a == "brand")
            {
                ShopNum1.BusinessLogic.ShopNum1_Brand_Action shopNum1_Brand_Action = new ShopNum1.BusinessLogic.ShopNum1_Brand_Action();
                System.Data.DataTable datatableBrand = shopNum1_Brand_Action.Search(0);
                //ShopNum1.ShopBusinessLogic.Shop_Product_Action product_Action = (ShopNum1.ShopBusinessLogic.Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
                //System.Data.DataTable datatableBrand = product_Action.GetProductBrandAndOrderIdByCode(b);
                if (datatableBrand == null || datatableBrand.Rows.Count == 0)
                {

                    sbuilder.Append("[");
                    sbuilder.Append("{\"Name\":\"" + "其它" + "\",\"Value\":\"00000000-0000-0000-0000-000000000000\"}");
                    sbuilder.Append("]");
                }
                else
                {
                    sbuilder.Append("[");
                    for (int i = 0; i < datatableBrand.Rows.Count; i++)
                    {
                        sbuilder.Append("{\"Name\":\"" + datatableBrand.Rows[i]["Name"].ToString() + "\",\"Value\":\"" + datatableBrand.Rows[i]["Guid"].ToString() + "\"},");
                    }

                    sbuilder.Remove(sbuilder.Length - 1, 1);
                    sbuilder.Append("]");
                }
            }
            //操作商品
            else
            {
                ShopNum1.ShopBusinessLogic.Shop_ProductCategory_Action productCategory_Action = (ShopNum1.ShopBusinessLogic.Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
                productCategory_Action.TableName = a == "shop" ? "ShopNum1_Shop_ProductCategory" : "ShopNum1_ProductCategory";
                System.Data.DataTable dataTable = null;
                if (a == "shop")
                {
                    string mlogin = GetMemLoginID(context);
                    if (mlogin == "")
                    {
                        return;
                    }
                    dataTable = productCategory_Action.GetShopProductCategoryCode(b, mlogin);
                }
                else
                {
                    dataTable = productCategory_Action.GetProductCategoryCode(b);
                }
                
                if (dataTable == null || dataTable.Rows.Count == 0)
                    return;
                else
                {
                    sbuilder.Append("[");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        sbuilder.Append("{\"Name\":\"" + dataTable.Rows[i]["Name"].ToString() + "\",\"Value\":\"" + dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString() + "\"},");
                    }

                    sbuilder.Remove(sbuilder.Length - 1, 1);
                    sbuilder.Append("]");
                }
              
            }
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(sbuilder.ToString());
        };

        object getyz = context.Request["yz"];
        if (getyz == null || getyz.ToString() != "shopnum1ntbl" )
        {
            context.Response.Write("error");
            return;
        } 
        string category=context.Request["category"].ToString();
        string ctype=context.Request["ctype"].ToString();
        ///返回json数据
        GetCategory(ctype, category);

      
    }
    /// <summary>
    /// 获取memloginid
    /// </summary>
    /// <returns></returns>
    private string GetMemLoginID(HttpContext context)
    {

        HttpCookie cookieShopMemberLogin = context.Request.Cookies["MemberLoginCookie"];
        if (cookieShopMemberLogin == null)
        {
            return "";
        }
        HttpCookie decodedCookieShopMemberLogin = ShopNum1.Common.HttpSecureCookie.Decode(cookieShopMemberLogin);
       return decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
         
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}