namespace ShopNum1.Interface
{
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public interface IShopNum1_Collect_Action
    {
        int Add(ShopNum1_ShopCollect collect);
        int Delete(string guids);
        int DeleteMemberProductCollect(string guid);
        int DeleteMemberShopCollect(string guid);
        DataTable GetMemberCollectList(string memLoginID);
        DataTable GetProductByGuid(string guid);
        DataTable Search(string memberLoginID, int isDeleted);
    }
}

