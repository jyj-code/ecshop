namespace ShopNum1.Interface
{
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public interface IShopNum1_OrderComplaintsReplyList_Action
    {
        int Add(ShopNum1_OrderComplaint OrderComplaint);
        int addReply(ShopNum1_OrderComplaint OrderComplaint);
        DataTable CheckIsOrderComplainByID(string id);
        DataTable GetComplainListByComplainShop(string shopid);
        DataTable GetOrderComplainDetailByID(string id);
        DataTable Search(string memberLoginID);
        DataTable Search(string memLoginID, string type);
        DataTable SearchComplaint(string id);
        int UpdateOrderComplainInfoByID(string id, string appealimage, string appealcontent);
        int UpdateProcessingStatus(int ProcessingStatus, string ID);
    }
}

