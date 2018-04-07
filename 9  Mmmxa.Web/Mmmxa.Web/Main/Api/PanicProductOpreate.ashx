<%@ WebHandler Language="C#" Class="PanicProductOpreate" %>

using System;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;
using System.Data;
using ShopNum1MultiEntity;
using System.Collections.Generic;


public class PanicProductOpreate :PageBase, IHttpHandler
{
    ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
    HttpContext Context = null;
    
    public void ProcessRequest (HttpContext context) 
    {
        this.Context = context;
        string type=context.Request.Params["type"];
        switch (type)
        {
            case "g":
                GetData();
                break;
            case "c":
                GetPageCount();
                break;
        }
        
        
    }

    void GetData()
    {
        //起始页
        int pageIndex = 1;
        //总页数
        int pageCount = 0;
        //数据总条数
        int rowCount = 0;
        //页容量
        string pageSize = "10";

        string strPageIndex = Context.Request.QueryString["pageIndex"];

        if (int.TryParse(strPageIndex,out pageIndex))
        {
            
        }
        
        string strCategoryCode = Context.Request.QueryString["categoryCode"];

        //得到总页数
        ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Common_Action();
        string searchName = " ProductState=1  and IsAudit=1 and IsSell=1 and EndTime>getdate() and starttime<=getdate() ";
        if (strCategoryCode != "-1")
        {
            searchName += "  and productcategorycode like '" + strCategoryCode + "%'";
        }
        rowCount = Convert.ToInt32( shopNum1_Common_Action.CommonGetPageCount(pageSize, "ShopNum1_Shop_Product", searchName).Tables[0].Rows[0][0].ToString());
        pageCount = Convert.ToInt32( shopNum1_Common_Action.CommonGetPageCount(pageSize, "ShopNum1_Shop_Product", searchName).Tables[1].Rows[0][0].ToString());

        
        DataTable datatable = shopNum1_ProuductChecked_Action.GetPanceProductByCategoryCode(strCategoryCode, pageSize, strPageIndex);

        if (datatable != null && datatable.Rows.Count > 0)
        {
            DataColumn dcURL = new DataColumn("URL", Type.GetType("System.String"));
            DataColumn dcNewName = new DataColumn("dcNewName", Type.GetType("System.String"));
            DataColumn dcResolveUrl = new DataColumn("ResolveUrl", Type.GetType("System.String"));
            datatable.Columns.Add(dcURL);
            datatable.Columns.Add(dcNewName);
            datatable.Columns.Add(dcResolveUrl);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < datatable.Rows.Count; i++)
            {

                datatable.Rows[i]["URL"] = ShopUrlOperate.shopDetailHrefByShopIDNew(datatable.Rows[i]["Guid"].ToString(), datatable.Rows[i]["ShopID"].ToString(), "ProductIsPanic_Detail");
                datatable.Rows[i]["dcNewName"] = ShopNum1.Common.Utils.GetUnicodeSubString(datatable.Rows[i]["Name"].ToString(), 19, "");
                datatable.Rows[i]["ResolveUrl"] = Page.ResolveUrl(datatable.Rows[i]["ThumbImage"].ToString()) + "_160x160.jpg";



                sb.AppendLine("<div class='psld_de'>");
                
                sb.AppendLine("<div class='panic_img'>");
                sb.AppendLine("<a href='"+datatable.Rows[i]["URL"]+"' target='blank'>");
                sb.AppendLine("<img alt='' src='"+datatable.Rows[i]["ResolveUrl"]+"' /></a>");
                sb.AppendLine("</div>");

                sb.AppendLine("<div class='panic_name'>");
                sb.AppendLine("<a href='" + datatable.Rows[i]["URL"] + "' target='blank'>");
                sb.AppendLine(datatable.Rows[i]["dcNewName"]+"</a>");
                sb.AppendLine("</div>");

                sb.AppendLine("<div class='panic_price'>");
                sb.AppendLine(" <span class='f1'>抢购价：<span class='qgjia'>￥" + datatable.Rows[i]["ShopPrice"] + "</span><del>" + datatable.Rows[i]["MarketPrice"] + "</del>");
                sb.AppendLine("<a href='" + datatable.Rows[i]["URL"] + "' target='blank' style='display: none;'></a>");
                sb.AppendLine("<div class='clear'></div>");
                sb.AppendLine("</div>");


                sb.AppendLine("</div>");
               

            }
            
            PagedData pagedData = new PagedData()
            {
                PageIndex = pageIndex,
                PageCount = pageCount,
                PageData = sb.ToString(),
                RowCount = rowCount
            };
            string strPagedData = JsonHelper.ObjToJson(pagedData);
            AjaxMsgHelper.AjaxMsg("ok", "", strPagedData);
        }
        else
        {
            AjaxMsgHelper.AjaxMsg("noData","");
        }
        
    }


    void GetPageCount()
    {
        int pageIndex = 0;
        string pageSize = "5";
        int pageCount = 0;
        
        string strPageIndex = Context.Request.QueryString["pageIndex"];
        string strCategoryCode = Context.Request.QueryString["code"];

        if (int.TryParse(strPageIndex, out pageIndex))
        {
            ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Common_Action();
            string searchName = " ProductState=1  and IsAudit=1 and IsSell=1 ";
            if (strCategoryCode != "-1")
            {
                searchName += "  and productcategorycode like '" + strCategoryCode + "%'";
            }
            pageCount = Convert.ToInt32(shopNum1_Common_Action.CommonGetPageCount(pageSize, "ShopNum1_Shop_Product", searchName).Tables[1].Rows[0][0].ToString());
            AjaxMsgHelper.AjaxMsg("ok", "", pageCount.ToString());
            
        }
        
        
    }


 
    public bool IsReusable {
        get {
            return false;
        }
    }

}