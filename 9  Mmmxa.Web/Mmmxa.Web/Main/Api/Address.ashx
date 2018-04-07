<%@ WebHandler Language="C#" Class="Address" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Common;
//using System.Web.HttpContext;

public class Address : IHttpHandler
{
    #region category
    public class CategoryVModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
        public int ParentId { get; set; }
    }
    #endregion

    #region shopinfo
    public class ShopInfo
    {
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string ShopPic { get;set;}
        public string Phone { get; set; }

        public string Lat { get; set; }
        public string Lon { get; set; }
    }
    
    #endregion

    string type;
    ShopNum1_DispatchRegion_Action dispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();

    static readonly ShopNum1.Interface.IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = LogicFactory.CreateShopNum1_ShopInfoList_Action();

    public void ProcessRequest(HttpContext context)
    {
        type = context.Request["type"];
        if (type == null)
        {
            return;
        }
        switch (type.ToLower().Trim())
        {
            //查询城市 SearchCity.
            case "searchcity":
                string shengid = context.Request["shengid"].Trim();
                context.Response.Write(Search(shengid, 0));
                break;
            //查询区域 SearchArea.
            case "searcharea":

                string cityid = context.Request["cityid"].Trim();
                context.Response.Write(Search(cityid, 1));
                break;

            //查询区域 SearchArea.
            case "searcharea1":

                string cityid1 = context.Request["cityid"].Trim();
                context.Response.Write(SearchArea(cityid1));
                break;

            //查询区域 addresscode.
            case "addresscode":

                string addresscode = context.Request["addresscode"].Trim();
                context.Response.Write(SearchShopUrl(addresscode));
                break;
            case "category":
                int parentId = Convert.ToInt32(context.Request["categoryId"].Trim());
                var shopNum1ShopCategoryAction = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
                var dt = shopNum1ShopCategoryAction.GetList(parentId.ToString());
                var result = new List<CategoryVModel>();
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var category = new CategoryVModel
                        {
                            Id = (int)dr["ID"],
                            Name = dr["Name"].ToString(),
                            Code = dr["Code"].ToString()
                            //,
                            //ParentId = (int)dr["FatherID"]
                        };
                        result.Add(category);
                    }
                }
                context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(result));
                break;
            case "baidumap":
                
                var ddlfirst = context.Request["ddlfirst"].Trim();
                var ddlsecond = context.Request["ddlsecond"].Trim();
                var ddlthird = context.Request["ddlthird"].Trim();
                var ddlProvice = context.Request["ddlprovince"].Trim();
                var ddlCity = context.Request["ddlcity"].Trim();
                var ddlArea = context.Request["ddlarea"].Trim();

                var address = string.IsNullOrEmpty(ddlProvice) ? string.Empty : (ddlProvice + "," + (string.IsNullOrEmpty(ddlCity) ? string.Empty : (ddlCity+","+(string.IsNullOrEmpty(ddlArea)?string.Empty:ddlArea))));
                var categoryCode = string.IsNullOrEmpty(ddlfirst) ? string.Empty : (ddlfirst  + (string.IsNullOrEmpty(ddlsecond) ? string.Empty : (ddlsecond  + (string.IsNullOrEmpty(ddlthird) ? string.Empty : ddlthird))));
                DataTable tableById = ShopNum1.Common.Common.GetTableById("*", "ShopNum1_ShopInfo", (string.IsNullOrEmpty(address)?string.Empty:" and AddressValue like '"+address+"%' ")+(string.IsNullOrEmpty(categoryCode)?string.Empty:" and ShopCategoryID like '"+categoryCode+"%' "));

                var resultShop = new List<ShopInfo>();
                if (tableById != null)
                {
                    foreach (DataRow dr in tableById.Rows)
                    {
                        var shopItem = new ShopInfo()
                        {
                            ShopName = dr["ShopName"].ToString(),
                            Address = dr["Address"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            ShopPic = dr["Banner"].ToString().Replace("~",""),
                            Lat = dr["Latitude"].ToString(),
                            Lon = dr["Longitude"].ToString()
                        };
                        resultShop.Add(shopItem);
                    }
                }

                context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(resultShop));
                break;
            default:
                break;
        }
    }




    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="ShengID"></param>
    /// <param name="type">0:获取城市 1：获取地区</param>
    /// <returns></returns>
    private string Search(string ShengID, int type)
    {
        string all_data = string.Empty;
        //获取数据
        dispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
        DataTable dataTable = dispatchRegion_Action.SearchtDispatchRegion(Convert.ToInt32(ShengID), 0);
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                if (type == 0)
                {
                    all_data += "<li><div id=\"AllArea\" onmouseleave=\"city2_hidden(this)\"  ><span style=\"height:30px; line-height:30px;\" onmouseover=\"city2_show(this)\" cityid='" + dataTable.Rows[j]["ID"].ToString() + "'>" + dataTable.Rows[j]["Name"].ToString() + "</span><div id=\"DivArea\" class=\"hidden\"><div class=\"prefecture\"><ul class=\"san clearfix\" id='area" + dataTable.Rows[j]["ID"].ToString() + "'></ul></div> </div></div></li>";
                }
                else if (type == 1)
                {
                    all_data += "<li><a href='" + ShopUrlOperate.GetDeShopUrl(dataTable.Rows[j]["Code"].ToString()) + "'>" + dataTable.Rows[j]["Name"].ToString() + "</a> </li>";
                }
            }

            //MessageBox.Show(all_data);

            return all_data;
        }
        else
        {
            return "";
        }
    }


    private string SearchArea(string CityID)
    {
        string all_data = string.Empty;
        //获取数据
        //dispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
        ShopNum1_City_Action city_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
        DataTable dataTable = city_Action.Search(Convert.ToInt32(CityID), 0);
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                all_data += "<li><a href='" + ShopUrlOperate.GetDeShopUrl(dataTable.Rows[j]["AddressCode"].ToString()) + "'>" + dataTable.Rows[j]["CityName"].ToString() + "</a> </li>";
            }

            return all_data;
        }
        else
        {
            return "";
        }


    }

    private string SearchShopUrl(string addresscode)
    {
        string all_data = string.Empty;
        //获取数据
        ShopNum1_ShopInfoList_Action shopInfoList = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
        string shopurl = shopInfoList.GetShopURLByAddressCode(addresscode);
        string domain = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
        if (shopurl != null && shopurl != "")
        {

            all_data = "http://" + shopurl + domain;
            return all_data;

        }
        else
        {
            return "";
        }


    }




    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}