namespace ShopNum1.Interface
{
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public interface IShopNum1_MemberReport_Action
    {
        int Add(ShopNum1_MemberReport MemberReport);
        DataTable CheckIsComplainByID(string id);
        DataTable GetReportDetailByID(string id);
        DataTable GetReportListByReportShop(string shopid);
        DataTable Search(string memLoginID);
        DataTable Search(string memLoginID, string type);
        DataTable SearchReport(string id);
        bool SearchReportName(string name);
        bool SearchReportProduct(string product, string name);
        int UpdateComplainInfoByID(string id, string complainimage, string complaintcontent);
    }
}

