﻿namespace ShopNum1.Interface
{
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public interface IShopNum1_MemberRank_Action
    {
        int Add(ShopNum1_MemberRank memberRank);
        DataTable Check(string guid);
        int Delete(string guids);
        DataTable Search(int isDeleted);
        DataTable Search(string guid, int isDeleted);
        DataTable Search(string MemberRank, string isDeleted);
        string SearchDiscountByGuid(string guid);
        DataTable SearchGuidName(int isDeleted);
        DataTable SearchGuidNameDiscount();
        string SearchNameByGuid(string guid);
        int Update(ShopNum1_MemberRank memberRank);
    }
}
