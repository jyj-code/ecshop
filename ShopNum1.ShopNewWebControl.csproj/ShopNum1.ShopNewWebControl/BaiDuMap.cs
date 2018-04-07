using System.Collections.Generic;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class BaiDuMap : BaseWebControl
    {
        private string string_0 = "BaiDuMap.ascx";
        private HiddenField hiddenField_0;
        private HiddenField hiddenField_1;
        private HiddenField hiddenField_2;

        private HiddenField hiddenCategory;

        private DropDownList dropDownList_0;
        private DropDownList dropDownList_1;
        private DropDownList dropDownList_2;

        private DropDownList ddlfirst;
        private DropDownList ddlsecond;
        private DropDownList ddlthird;

        private HiddenField dropAddress;
        private HiddenField categoryId;


        //public List<CategoryViewModel> CategoryViewModels = new List<CategoryViewModel>();
        public BaiDuMap()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = this.string_0;
            }
        }
        protected override void InitializeSkin(Control skin)
        {
            this.hiddenField_0 = (HiddenField)skin.FindControl("hdShopName");
            this.hiddenField_1 = (HiddenField)skin.FindControl("hdShopAdress");
            this.hiddenField_2 = (HiddenField)skin.FindControl("hdMapValue");

            this.categoryId = (HiddenField)skin.FindControl("hiddenCategoryId");
            this.dropAddress = (HiddenField)skin.FindControl("HiddenDropdownAddress");

            this.dropDownList_0 = (DropDownList)skin.FindControl("ddlProvince");
            this.dropDownList_1 = (DropDownList)skin.FindControl("dropdownlistCity");
            this.dropDownList_2 = (DropDownList)skin.FindControl("dropdownlistArea");
            this.hiddenCategory = (HiddenField)skin.FindControl("hiddenCategory");
            this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
            this.BindData();
            this.BandDropDownListCity(0, this.dropDownList_0);

            this.ddlfirst = (DropDownList)skin.FindControl("ddlfirst");
            this.ddlsecond = (DropDownList)skin.FindControl("ddlsecond");
            this.ddlthird = (DropDownList)skin.FindControl("ddlthird");
            this.ddlfirst.SelectedIndexChanged += new EventHandler(this.ddlfirst_SelectedIndexChanged);
            this.BandDropDownListCategory(0, this.ddlfirst);
        }
        public void BindData()
        {
            string str = (this.Page.Request.QueryString["MemLoginID"] == null) ? "0" : this.Page.Request.QueryString["MemLoginID"].ToString();
            DataTable tableById = ShopNum1.Common.Common.GetTableById("*", "ShopNum1_ShopInfo", " and memloginid='" + str + "'");
            if (tableById != null && tableById.Rows.Count > 0)
            {
                this.hiddenField_0.Value = tableById.Rows[0]["ShopName"].ToString();
                this.hiddenField_1.Value = tableById.Rows[0]["Address"].ToString();
                this.hiddenField_2.Value = tableById.Rows[0]["Longitude"].ToString() + "," + tableById.Rows[0]["Latitude"].ToString();
                this.categoryId.Value = tableById.Rows[0]["ShopCategoryID"].ToString();
                this.dropAddress.Value = tableById.Rows[0]["AddressValue"].ToString();
            }

            //CategoryViewModels.Clear();
            //this.BindCategory(0);
            //this.hiddenCategory.Value =
            //    new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(CategoryViewModels);
        }

        private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.dropDownList_0.SelectedValue == "-1"))
            {
                this.BandDropDownListCity(Convert.ToInt32(this.dropDownList_0.SelectedValue), this.dropDownList_1);
            }
        }
        public int BandDropDownListCity(int FatherID, DropDownList dropDownList_3)
        {
            ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            DataView defaultView = shopNum1_City_Action.Search(FatherID, 0).DefaultView;
            int result;
            if (defaultView.Table.Rows.Count > 0)
            {
                foreach (DataRow dataRow in defaultView.Table.Rows)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = dataRow["CityName"].ToString().Trim();
                    listItem.Value = dataRow["ID"].ToString().Trim();
                    dropDownList_3.Items.Add(listItem);
                }
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }


        private void ddlfirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.ddlfirst.SelectedValue == "-1"))
            {
                this.BandDropDownListCategory(Convert.ToInt32(this.ddlfirst.SelectedValue), this.ddlsecond);
            }
        }

        public void BandDropDownListCategory(int parentId, DropDownList ddl)
        {
            var shopNum1ShopCategoryAction = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
            var dt = shopNum1ShopCategoryAction.GetList(parentId.ToString());
            if (dt != null)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    var listItem = new ListItem
                    {
                        Text = dataRow["Name"].ToString().Trim(),
                        Value = dataRow["ID"].ToString().Trim()
                    };
                    listItem.Attributes.Add("Code", dataRow["Code"].ToString().Trim());
                    ddl.Items.Add(listItem);
                }
            }
        }

        /// <summary>
        /// 递归获取类别
        /// </summary>
        /// <param name="parentId"></param>
        //public void BindCategory(int parentId)
        //{
        //    var shopNum1ShopCategoryAction = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
        //    var dt = shopNum1ShopCategoryAction.GetListByParentId(parentId);
        //    if (dt != null)
        //    {
        //        CategoryViewModel category;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            category = new CategoryViewModel();
        //            category.Id = (int)dr["ID"];
        //            category.Name = dr["Name"].ToString();
        //            category.Code = dr["Code"].ToString();
        //            category.ParentId = (int)dr["FatherID"];

        //            DataTable dt2 = shopNum1ShopCategoryAction.GetListByParentId(category.Id);
        //            if (dt2 != null)
        //            {
        //                var itemlist = new List<CategoryViewModel>();
        //                CategoryViewModel category2;
        //                foreach (DataRow dr2 in dt2.Rows)
        //                {
        //                    category2 = new CategoryViewModel();
        //                    category2.Id = (int)dr2["ID"];
        //                    category2.Name = dr2["Name"].ToString();
        //                    category2.Code = dr2["Code"].ToString();
        //                    category2.ParentId = (int)dr2["FatherID"];
        //                    itemlist.Add(category2);
        //                }
        //                category.ItemList = itemlist;
        //            }
        //            CategoryViewModels.Add(category);
        //        }
        //    }
        //}

        #region category
        public class CategoryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Code { get; set; }
            public int ParentId { get; set; }
            public List<CategoryViewModel> ItemList = new List<CategoryViewModel>();
        }
        #endregion
    }
}
