namespace ShopNum1.BusinessLogic
{
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public class ShopNum1_Collect_Action : IShopNum1_Collect_Action
    {
        public int Add(ShopNum1_ShopCollect collect)
        {
            return 0;
        }

        public int AddProductCollect(string memloginid, string productguid, string collecttime, string shopid, string isattention, string shopprice, string productname)
        {
            string[] paraName = new string[7];
            string[] paraValue = new string[7];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@productguid";
            paraValue[1] = productguid;
            paraName[2] = "@collecttime";
            paraValue[2] = collecttime;
            paraName[3] = "@shopid";
            paraValue[3] = shopid;
            paraName[4] = "@isattention";
            paraValue[4] = isattention;
            paraName[5] = "@shopprice";
            paraValue[5] = shopprice;
            paraName[6] = "@productname";
            paraValue[6] = productname;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddProductCollect", paraName, paraValue);
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Collect WHERE  Guid IN(" + guids + ")");
        }

        public int DeleteMemberProductCollect(string guid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteMemberProductCollect", paraName, paraValue);
        }

        public int DeleteMemberShopCollect(string guid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteMemberShopCollect", paraName, paraValue);
        }

        public DataTable GetMemberCollectList(string memloginid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberCollectList", paraName, paraValue);
        }

        public DataTable GetMemberShopCollectList(string memLoginID)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberShopCollectList", paraName, paraValue);
        }

        public DataTable GetProductByGuid(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT *    FROM ShopNum1_Shop_Product    WHERE  Guid = '" + guid + "' ");
        }

        public DataTable Search(string memberLoginID, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT A.Guid, A.MemLoginID, A.ProductGuid, B.Name As ProductName, B.ShopPrice, A.CollectTime, A.IsDeleted  FROM ShopNum1_Collect AS A,ShopNum1_Product AS B   WHERE  A.ProductGuid = B.Guid ";
            if (memberLoginID != string.Empty)
            {
                str = str + " AND A.MemLoginID='" + memberLoginID + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by CollectTime Desc");
        }
    }
}

