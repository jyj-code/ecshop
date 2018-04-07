using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_CouponType_Action : IShop_CouponType_Action
    {
        public Shop_CouponType_Action()
        {
        }

        public int Add(ShopNum1MultiEntity.ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType)
        {
            string empty = string.Empty;
            object[] name = new object[] { "INSERT INTO ShopNum1_Shop_CouponType (\tName\t,\tOrderID\t,\tIsShow\t,\tCreateUser\t,\tCreateTime\t,\tComment\t,\tIsDeleted\t) VALUES ('", ShopNum1_Shop_CouponType.Name, "', ", ShopNum1_Shop_CouponType.OrderID, " , ", ShopNum1_Shop_CouponType.IsShow, " ,'", ShopNum1_Shop_CouponType.CreateUser, "','", ShopNum1_Shop_CouponType.CreateTime, "','", ShopNum1_Shop_CouponType.Comment, "', ", ShopNum1_Shop_CouponType.IsDeleted, " )" };
            return DatabaseExcetue.RunNonQuery(string.Concat(name));
        }

        public int Delete(string ids)
        {
            int num;
            string empty = string.Empty;
            try
            {
                empty = string.Concat("DELETE FROM ShopNum1_Shop_CouponType WHERE ID IN (", ids, ")");
                DatabaseExcetue.RunNonQuery(empty);
                empty = string.Concat("DELETE FROM ShopNum1_Shop_Coupon WHERE Type IN (", ids, ")");
                DatabaseExcetue.RunNonQuery(empty);
                num = 1;
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public DataTable search(int id, int isshow)
        {
            string empty = string.Empty;
            empty = "SELECT * FROM ShopNum1_Shop_CouponType WHERE 1=1 ";
            if (id != -1)
            {
                empty = string.Concat(empty, " and ID=", id);
            }
            if (isshow != -1)
            {
                empty = string.Concat(empty, " and IsShow=", isshow);
            }
            empty = string.Concat(empty, " ORDER BY OrderID");
            return DatabaseExcetue.ReturnDataTable(empty);
        }

        public int Update(ShopNum1MultiEntity.ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType)
        {
            string empty = string.Empty;
            object[] name = new object[] { "UPDATE ShopNum1_Shop_CouponType SET Name='", ShopNum1_Shop_CouponType.Name, "', IsShow=", ShopNum1_Shop_CouponType.IsShow, ", OrderID=", ShopNum1_Shop_CouponType.OrderID, ", ModifyUser='", ShopNum1_Shop_CouponType.ModifyUser, "', ModifyTime='", ShopNum1_Shop_CouponType.ModifyTime, "', Comment='", ShopNum1_Shop_CouponType.Comment, "'  WHERE ID=", ShopNum1_Shop_CouponType.id, " " };
            return DatabaseExcetue.RunNonQuery(string.Concat(name));
        }
    }
}