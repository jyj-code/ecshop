using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Coupon_Action : IShop_Coupon_Action
    {
        public Shop_Coupon_Action()
        {
        }

        public int Add(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            string empty = string.Empty;
            object[] guid = new object[] { "INSERT INTO ShopNum1_Shop_Coupon (\tGuid\t,\tCouponName\t,\tShopName\t,\tMemLoginID\t,\tType  \t,\tStartTime\t,\tEndTime \t,\tIsEffective\t,\tImgPath\t,\tContent\t,\tAdressCode\t,\tAdressName\t,\tSaleTitle\t,\tIsAudit\t,\tCreateUser\t,\tCreateTime\t,\tIsDeleted\t,\tIsShow\t,\tIsHot\t,\tIsNew\t,\t SubstationID\t,\tIsRecommend\t) VALUES ('", shopNum1_Shop_Coupon.Guid, "', '", shopNum1_Shop_Coupon.CouponName, "' , '", shopNum1_Shop_Coupon.ShopName, "' ,'", shopNum1_Shop_Coupon.MemLoginID, "', ", shopNum1_Shop_Coupon.Type, " ,'", shopNum1_Shop_Coupon.StartTime, "','", shopNum1_Shop_Coupon.EndTime, "', ", shopNum1_Shop_Coupon.IsEffective, " , '", shopNum1_Shop_Coupon.ImgPath, "' ,'", shopNum1_Shop_Coupon.Content, "','", shopNum1_Shop_Coupon.AdressCode, "','", shopNum1_Shop_Coupon.AdressName, "','", shopNum1_Shop_Coupon.SaleTitle, "',", shopNum1_Shop_Coupon.IsAudit, ", '", shopNum1_Shop_Coupon.CreateUser, "' , '", shopNum1_Shop_Coupon.CreateTime, "' ,", shopNum1_Shop_Coupon.IsDeleted, ",", shopNum1_Shop_Coupon.IsShow, ",", shopNum1_Shop_Coupon.IsHot, ",", shopNum1_Shop_Coupon.IsNew, ",'", shopNum1_Shop_Coupon.SubstationID, "', ", shopNum1_Shop_Coupon.IsRecommend, " )" };
            return DatabaseExcetue.RunNonQuery(string.Concat(guid));
        }

        public int Delete(string ids)
        {
            string empty = string.Empty;
            return DatabaseExcetue.RunNonQuery(string.Concat("DELETE FROM ShopNum1_Shop_Coupon WHERE Guid IN (", ids, ")"));
        }

        public DataTable GetCouponInfoById(string guid)
        {
            string empty = string.Empty;
            return DatabaseExcetue.ReturnDataTable(string.Concat("SELECT A.SaleTitle,A.CouponName,A.Type,A.StartTime,A.EndTime,A.ImgPath,A.Content,A.MemLoginID,A.AdressCode,A.AdressName,A.IsShow,A.IsHot,A.IsNew,A.IsRecommend,C.Name FROM ShopNum1_Shop_Coupon AS A,ShopNum1_Shop_CouponType AS C WHERE A.Type=C.id AND A.Guid='", guid, "'"));
        }

        public DataTable GetCouponTitleByAdressCode(string adresscode, string showcount)
        {
            string[] strArrays = new string[2];
            string[] strArrays1 = new string[2];
            strArrays[0] = "@adresscode";
            strArrays1[0] = adresscode;
            strArrays[1] = "@showcount";
            strArrays1[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByAdressCode", strArrays, strArrays1);
        }

        public DataTable GetCouponTitleByBrowserCount(string showcount)
        {
            string[] strArrays = new string[1];
            string[] strArrays1 = new string[1];
            strArrays[0] = "@showcount";
            strArrays1[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByBrowserCount", strArrays, strArrays1);
        }

        public DataTable SearchCoupon(string name, string type, string isshow, string starttime1, string starttime2, string endtime1, string endtime2, string memloginid)
        {
            string[] strArrays = new string[8];
            string[] strArrays1 = new string[8];
            strArrays[0] = "@name";
            strArrays1[0] = name;
            strArrays[1] = "@type";
            strArrays1[1] = type;
            strArrays[2] = "@isshow";
            strArrays1[2] = isshow;
            strArrays[3] = "@starttime1";
            strArrays1[3] = starttime1;
            strArrays[4] = "@starttime2";
            strArrays1[4] = starttime2;
            strArrays[5] = "@endtime1";
            strArrays1[5] = endtime1;
            strArrays[6] = "@endtime2";
            strArrays1[6] = endtime2;
            strArrays[7] = "@memloginid";
            strArrays1[7] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCoupon", strArrays, strArrays1);
        }

        public DataSet SearchCouponByCategory(string category, string pagesize, string current_page)
        {
            string[] strArrays = new string[3];
            string[] currentPage = new string[3];
            strArrays[0] = "@category";
            currentPage[0] = category;
            strArrays[1] = "@pagesize";
            currentPage[1] = pagesize;
            strArrays[2] = "@current_page";
            currentPage[2] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchCouponByCategory", strArrays, currentPage);
        }

        public DataTable SearchCouponByGuid(string guid, string shopid)
        {
            string[] strArrays = new string[2];
            string[] strArrays1 = new string[2];
            strArrays[0] = "@guid";
            strArrays1[0] = guid;
            strArrays[1] = "@shopid";
            strArrays1[1] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCouponByGuid", strArrays, strArrays1);
        }

        public DataTable SearchCouponByMemloginID(string showcount, string memloginid)
        {
            string[] strArrays = new string[2];
            string[] strArrays1 = new string[2];
            strArrays[0] = "@showcount";
            strArrays1[0] = showcount;
            strArrays[1] = "@memloginid";
            strArrays1[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchCouponByMemloginID", strArrays, strArrays1);
        }

        public DataSet SearchCouponByMemloginID(string shopid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
        {
            string empty = string.Empty;
            string[] strArrays = new string[8];
            string[] currentPage = new string[8];
            strArrays[0] = "@columnnames";
            currentPage[0] = " CouponName,Guid,ImgPath,BrowserCount,UseCount,DownloadCount,IsEffective,StartTime,MemLoginID,EndTime ";
            strArrays[1] = "@searchname";
            currentPage[1] = empty;
            strArrays[2] = "@ordertype";
            currentPage[2] = ordertype;
            strArrays[3] = "@shopid";
            currentPage[3] = shopid;
            strArrays[4] = "@sort";
            currentPage[4] = sort;
            strArrays[5] = "@perpagenum";
            currentPage[5] = perpagenum;
            strArrays[6] = "@current_page";
            currentPage[6] = current_page;
            strArrays[7] = "@isreturcount";
            currentPage[7] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchCouponByMemloginIDNew", strArrays, currentPage);
        }

        public DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize, string current_page, string isReturCount)
        {
            string str = "";
            if (!string.IsNullOrEmpty(category) && category != "-1")
            {
                str = string.Concat(" AND A.type=", category);
            }
            if (!string.IsNullOrEmpty(addcode) && addcode != "-1")
            {
                str = string.Concat(str, " AND A.AdressCode like '", addcode, "%' ");
            }
            string[] strArrays = new string[7];
            string[] currentPage = new string[7];
            strArrays[0] = "@perPageNum";
            currentPage[0] = pagesize;
            strArrays[1] = "@current_page";
            currentPage[1] = current_page;
            strArrays[2] = "@ColumnNames";
            currentPage[2] = " A.Guid,A.CouponName,A.MemLoginID,A.BrowserCount,A.Type,A.SaleTitle,A.ImgPath,B.shopID ";
            strArrays[3] = "@OrderName";
            currentPage[3] = ordername;
            strArrays[4] = "@searchName";
            currentPage[4] = str;
            strArrays[5] = "@sDesc";
            currentPage[5] = sDesc;
            strArrays[6] = "@isReturCount";
            currentPage[6] = isReturCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponByType", strArrays, currentPage);
        }

        public DataTable SearchCouponInfo(string name, string type, string isshow, string starttime1, string starttime2, string endtime1, string endtime2, string shopid, string adresscode)
        {
            string[] strArrays = new string[9];
            string[] strArrays1 = new string[9];
            strArrays[0] = "@name";
            strArrays1[0] = name;
            strArrays[1] = "@type";
            strArrays1[1] = type;
            strArrays[2] = "@isshow";
            strArrays1[2] = isshow;
            strArrays[3] = "@starttime1";
            strArrays1[3] = starttime1;
            strArrays[4] = "@starttime2";
            strArrays1[4] = starttime2;
            strArrays[5] = "@endtime1";
            strArrays1[5] = endtime1;
            strArrays[6] = "@endtime2";
            strArrays1[6] = endtime2;
            strArrays[7] = "@shopid";
            try
            {
                if (string.IsNullOrEmpty(shopid))
                {
                    shopid = "-1";
                }
            }
            catch
            {
                shopid = "-1";
            }
            strArrays1[7] = shopid;
            strArrays[8] = "@adresscode";
            strArrays1[8] = adresscode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponInfo", strArrays, strArrays1);
        }

        public DataTable SearchCouponInfo(string name, string type, string isshow, string starttime1, string starttime2, string endtime1, string endtime2, string shopid, string adresscode, string SubstationID)
        {
            string[] strArrays = new string[10];
            string[] substationID = new string[10];
            strArrays[0] = "@name";
            substationID[0] = name;
            strArrays[1] = "@type";
            substationID[1] = type;
            strArrays[2] = "@isshow";
            substationID[2] = isshow;
            strArrays[3] = "@starttime1";
            substationID[3] = starttime1;
            strArrays[4] = "@starttime2";
            substationID[4] = starttime2;
            strArrays[5] = "@endtime1";
            substationID[5] = endtime1;
            strArrays[6] = "@endtime2";
            substationID[6] = endtime2;
            strArrays[7] = "@shopid";
            try
            {
                if (string.IsNullOrEmpty(shopid))
                {
                    shopid = "-1";
                }
            }
            catch
            {
                shopid = "-1";
            }
            substationID[7] = shopid;
            strArrays[8] = "@adresscode";
            substationID[8] = adresscode;
            strArrays[9] = "@SubstationID";
            substationID[9] = SubstationID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponInfo1", strArrays, substationID);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            string[] strArrays = new string[8];
            string[] pageSize = new string[8];
            strArrays[0] = "@pagesize";
            pageSize[0] = commonModel.PageSize;
            strArrays[1] = "@currentpage";
            pageSize[1] = commonModel.Currentpage;
            strArrays[2] = "@columns";
            pageSize[2] = " * ";
            strArrays[3] = "@tablename";
            pageSize[3] = "ShopNum1_Shop_Coupon";
            strArrays[4] = "@condition";
            pageSize[4] = commonModel.Condition;
            strArrays[5] = "@ordercolumn";
            pageSize[5] = "CreateTime";
            strArrays[6] = "@sortvalue";
            pageSize[6] = "desc";
            strArrays[7] = "@resultnum";
            pageSize[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", strArrays, pageSize);
        }

        public int UpdataDownloadCountByGuid(string guid, string count)
        {
            string[] strArrays = new string[2];
            string[] strArrays1 = new string[2];
            strArrays[0] = "@guid";
            strArrays1[0] = guid;
            strArrays[1] = "@count";
            strArrays1[1] = count;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdataDownloadCountByGuid", strArrays, strArrays1);
        }

        public int UpdateAudit(string field, string value, string guids)
        {
            string empty = string.Empty;
            string[] strArrays = new string[] { "update ShopNum1_Shop_Coupon set ", field, "=", value, " where guid in (", guids, ")" };
            return DatabaseExcetue.RunNonQuery(string.Concat(strArrays));
        }

        public int UpdateBrowserCount(string guid)
        {
            string[] strArrays = new string[1];
            string[] strArrays1 = new string[1];
            strArrays[0] = "@guid";
            strArrays1[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateBrowserCount", strArrays, strArrays1);
        }

        public int UpdateCoupon(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            string[] strArrays = new string[19];
            string[] str = new string[19];
            strArrays[0] = "@guid";
            str[0] = shopNum1_Shop_Coupon.Guid.ToString();
            strArrays[1] = "@name";
            str[1] = shopNum1_Shop_Coupon.CouponName;
            strArrays[2] = "@shopname";
            str[2] = shopNum1_Shop_Coupon.ShopName;
            strArrays[3] = "@memloginid";
            str[3] = shopNum1_Shop_Coupon.MemLoginID;
            strArrays[4] = "@type";
            str[4] = shopNum1_Shop_Coupon.Type.ToString();
            strArrays[5] = "@adresscode";
            str[5] = shopNum1_Shop_Coupon.AdressCode;
            strArrays[6] = "@adressname";
            str[6] = shopNum1_Shop_Coupon.AdressName;
            strArrays[7] = "@isshow";
            str[7] = shopNum1_Shop_Coupon.IsShow.ToString();
            strArrays[8] = "@statrtime";
            str[8] = shopNum1_Shop_Coupon.StartTime.ToString();
            strArrays[9] = "@endtime";
            str[9] = shopNum1_Shop_Coupon.EndTime.ToString();
            strArrays[10] = "@imagepath";
            str[10] = shopNum1_Shop_Coupon.ImgPath;
            strArrays[11] = "@content";
            str[11] = shopNum1_Shop_Coupon.Content;
            strArrays[12] = "@isnew";
            str[12] = shopNum1_Shop_Coupon.IsNew.ToString();
            strArrays[13] = "@ishot";
            str[13] = shopNum1_Shop_Coupon.IsHot.ToString();
            strArrays[14] = "@isrecommend";
            str[14] = shopNum1_Shop_Coupon.IsRecommend.ToString();
            strArrays[15] = "@modifyuser";
            str[15] = shopNum1_Shop_Coupon.ModifyUser;
            strArrays[16] = "@modifytime";
            str[16] = shopNum1_Shop_Coupon.ModifyTime.ToString();
            strArrays[17] = "@isaudit";
            str[17] = shopNum1_Shop_Coupon.IsAudit.ToString();
            strArrays[18] = "@SaleTitle";
            str[18] = shopNum1_Shop_Coupon.SaleTitle;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCoupon", strArrays, str);
        }

        public int UpdateCoupon1(ShopNum1_Shop_Coupon shopNum1_Shop_Coupon)
        {
            string[] strArrays = new string[14];
            string[] str = new string[14];
            strArrays[0] = "@guid";
            str[0] = shopNum1_Shop_Coupon.Guid.ToString();
            strArrays[1] = "@name";
            str[1] = shopNum1_Shop_Coupon.CouponName;
            strArrays[2] = "@shopname";
            str[2] = shopNum1_Shop_Coupon.ShopName;
            strArrays[3] = "@type";
            str[3] = shopNum1_Shop_Coupon.Type.ToString();
            strArrays[4] = "@adresscode";
            str[4] = shopNum1_Shop_Coupon.AdressCode;
            strArrays[5] = "@adressname";
            str[5] = shopNum1_Shop_Coupon.AdressName;
            strArrays[6] = "@isshow";
            str[6] = shopNum1_Shop_Coupon.IsShow.ToString();
            strArrays[7] = "@statrtime";
            str[7] = shopNum1_Shop_Coupon.StartTime.ToString();
            strArrays[8] = "@endtime";
            str[8] = shopNum1_Shop_Coupon.EndTime.ToString();
            strArrays[9] = "@imagepath";
            str[9] = shopNum1_Shop_Coupon.ImgPath;
            strArrays[10] = "@content";
            str[10] = shopNum1_Shop_Coupon.Content;
            strArrays[11] = "@modifyuser";
            str[11] = shopNum1_Shop_Coupon.ModifyUser;
            strArrays[12] = "@modifytime";
            str[12] = shopNum1_Shop_Coupon.ModifyTime.ToString();
            strArrays[13] = "@SaleTitle";
            str[13] = shopNum1_Shop_Coupon.SaleTitle;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateCoupon1", strArrays, str);
        }
    }
}