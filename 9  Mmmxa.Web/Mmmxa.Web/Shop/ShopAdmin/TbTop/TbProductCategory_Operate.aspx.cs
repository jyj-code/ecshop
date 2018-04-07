/************************************************************
Design:By GroupFly(武汉群翔)
WebSite:http://www.groupfly.com
ShopNum1 WebSite:http://www.shopnum1.cn
Coder:WFK
Date:2008-12-21
************************************************************/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ShopNum1.BusinessLogic;
using ShopNum1.ShopFactory;
//using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1.Common;
using System.Collections.Generic;
using ShopNum1.TbTopCommon;
using System.IO;
using System.Text;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using ShopNum1.Factory;
using ShopNum1.TbLinq;

public partial class TbProductCategory_Operate : System.Web.UI.Page
{ 
    

    protected void Page_Load(object sender, EventArgs e)
    {

        this.hiddenFieldGuid.Value = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"];
        if (Page.Request.Cookies["MemberLoginCookie"] == null)
        {                //退出
            GetUrl.RedirectTopLogin();
        }
        else
        {
            HttpCookie cookieShopMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            string MemberType = decodedCookieShopMemberLogin.Values["MemberType"].ToString();
            if (MemberType != "2")
            {
                //退出
                GetUrl.RedirectTopLogin();
                return;
            }
            //会员登录ID
            MemLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();

            BindCateGory();

            if (!TopClient.IsAgentLogin)
            {
                CheckBoxTb.Enabled = false;

            }

            if (hiddenFieldGuid.Value != "0")
            {
                if (!Page.IsPostBack)
                {
                    this.LabelTitle.Text = "编辑商品分类";
                    GetEditInfo();
                    ///淘宝同步状态
                    if (CheckCatExists(Convert.ToInt32(hiddenFieldGuid.Value)))
                    {
                        //MessageBox.Show("sss");
                        spanTb.InnerText = "(已同步)";
                    }
                }
            }
            else
            {
                GetOrderID();
            }
        }
    }




    //两个空格
    protected string strSapce = "　　";
    //一个空格
    protected char charSapce = '　';
    private void BindCateGory()
    {
        ListItem listitems = new ListItem();
        listitems.Text = "顶级分类";
        listitems.Value = "0";
        this.DropDownListFatherCateGory.Items.Add(listitems);
        Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
        shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
        DataTable dataTable = shop_ProductCategory_Action.GetShopProductCategoryCode("0", MemLoginID);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            ListItem items = new ListItem();
            items.Text = dataRow["Name"].ToString();
            items.Value = dataRow["ID"].ToString();
            this.DropDownListFatherCateGory.Items.Add(items);
         

        }
    }





    /// <summary>
    /// 检查分类下面是否有商品（有商品就返回false否则返回true）
    /// </summary>
    /// <param name="cid"></param>
    /// <returns></returns>
    private bool CheckItemSetItem(string cid)
    {
        //if (!TopClient.isAdminSessionTrue)
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"您还没有获取授权\")", true);
        //    return false;
        //}
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "cid");
        param.Add("cid", cid);
        param.Add("nicks", TopClient.AdminUserNick);
        string strXml = TopAPI.Post("taobao.items.search", TopClient.AdminSession, param);
        Parser parser = new Parser();
        int i = parser.XmlToTotalResults(strXml, "item_search");//如：解析XML的数量
        if (i == 0)
        {
            return true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"上一级中有商品\")", true);
            return false;
        }

    }

    private void SearchCategory(string ID)
    {
        Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
        shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
        DataTable datatable = shop_ProductCategory_Action.GetShopProductCategoryCode(ID, MemLoginID);
        foreach (DataRow dataRow in datatable.Rows)
        {
            string str = string.Empty;
            for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
            {
                //strSpace是两个空格
                str = str + strSapce;
            }
            //str = str + dataRow["Name"].ToString().Trim(); 
            ListItem items = new ListItem();
            items.Text = str + dataRow["Name"].ToString();
            items.Value = dataRow["ID"].ToString();
            this.DropDownListFatherCateGory.Items.Add(items);
            SearchCategory(dataRow["ID"].ToString());
        }
    }


    protected void GetOrderID()
    {
        Shop_Common_Action shopcomm = (Shop_Common_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Common_Action();
        //string order_id = "OrderID", shopnum1_productcategory = "ShopNum1_ProductCategory";
        //this.TextBoxOrderID.Text = Convert.ToString(1 + shopNum1_Common_Action.ReturnMaxID(order_id, shopnum1_productcategory));

        this.TextBoxOrderID.Text = Convert.ToString(shopcomm.ReturnMaxIDByMemLoginID(MemLoginID) + 1);
    }

    private void GetEditInfo()
    {
        Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
        shop_ProductCategory_Action.TableName = "ShopNum1_shop_ProductCategory";
        DataTable dataTable = shop_ProductCategory_Action.GetProductCategoryInfoByCode(this.hiddenFieldGuid.Value.ToString(), MemLoginID);
        this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
        this.TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
        this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
        this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
        this.DropDownListFatherCateGory.Text = dataTable.Rows[0]["FatherID"].ToString();
        this.DropDownListFatherCateGory.Enabled = false;
        if (dataTable.Rows[0]["IsShow"].ToString() == "1")
        {
            this.CheckBoxIsShow.Checked = true;
        }
        else
        {
            this.CheckBoxIsShow.Checked = false;
        }
        // this.TextBoxProduceMemLoginID.Text = dataTble.Rows[0]["ProduceMemLoginID"].ToString();
        this.ButtonConfirm.Text = "更新";
        this.ButtonConfirm.ToolTip = "Update";
    }

    /// <summary>
    /// 检查分类是否存在
    /// </summary>
    /// <returns></returns>
    private bool CheckCatExists(int id)
    {
        ShopNum1_TbSellCat_Action sellCatOperate = (ShopNum1_TbSellCat_Action)ShopNum1.Factory.LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        decimal tbcid = sellCatOperate.CheckSiteSellCat(id);
        if (tbcid > 0)
        {

            return true;
        }
        else
        {
            return false;
        }
    }


    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        if (this.ButtonConfirm.ToolTip == "Submit")
        {
            #region 添加
            ///检查分类是否存在
            CheckSellCat();
            Shop_ProductCategory_Action ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
           //ShopNum1_Shop_ProductCategory
            ShopNum1_Shop_ProductCategory productCategory = new ShopNum1_Shop_ProductCategory();
            productCategory.Name = this.TextBoxName.Text.Trim();
            productCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            productCategory.Keywords = this.TextBoxKeywords.Text.Trim();
            productCategory.Description = this.TextBoxDescription.Text.Trim();
            productCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
            if (this.CheckBoxIsShow.Checked)
            {
                productCategory.IsShow = 1;
            }
            else
            {
                productCategory.IsShow = 0;
            }
            productCategory.ID = ProductCategory_Action.GetMaxID(MemLoginID);
            //得到级别
            //先根据一个空格分字符串，如果有4个空格，就是3级，因为2个空格为1级
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                //如果为顶级分类
                productCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strLevel = this.DropDownListFatherCateGory.SelectedItem.Text.Split(charSapce);
                //  this.Response.Write(strLevel.Length.ToString());
                if (strLevel.Length > 0)
                {
                    productCategory.CategoryLevel = ((strLevel.Length + 1) / 2) + 1;

                }
                else
                {
                    productCategory.CategoryLevel = 2;
                }
                productCategory.CategoryLevel = 2;

            }
            productCategory.Family = string.Empty;
            productCategory.MemLoginID = this.MemLoginID;
          
            int check = 0;

            if (CheckBoxTb.Checked)
            {
                ///和淘宝同步
                InsertTb(productCategory.ID);

            }

            check = ProductCategory_Action.Add(productCategory);
         
            //更新
            if (check > 0)
            {
                //#region  操作日志部分
                //ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
                //operateLog.Record = "新增" + this.TextBoxName.Text.Trim() + "成功";
                //operateLog.OperatorID = this.MemLoginID;
                //operateLog.IP = Globals.IPAddress;
                //operateLog.PageName = "ProductCategory_Operate.aspx";
                //operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //int log = OperateLog(operateLog);
                //#endregion
                //显示操作信息
                
                //this.MessageShowTb.ShowMessage("AddYes");
                //this.MessageShowTb.Visible = true;
                //绑定商品分类
                BindProductCategory();
                //清空控件
                ClearControl();
                GetOrderID();
                MessageBox.Show("添加商品分类成功");
                this.Response.Redirect("TbProductCategory_List.aspx");
             
            }
            else
            {
                //显示操作信息
                //this.MessageShowTb.ShowMessage("AddNo");
                //this.MessageShowTb.Visible = true;
            }
            #endregion
        }
        else if (this.ButtonConfirm.ToolTip == "Update")
        {
            #region 编辑
            if (this.hiddenFieldGuid.Value.ToString() == this.DropDownListFatherCateGory.SelectedValue)
            {
                //this.MessageShowTb.ShowMessage("EditError");
                //this.MessageShowTb.Visible = true;
                return;
            }

            ShopNum1_Shop_ProductCategory productCategory = new ShopNum1_Shop_ProductCategory();
            productCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString());
            productCategory.Name = this.TextBoxName.Text.Trim();
            productCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            productCategory.Keywords = this.TextBoxKeywords.Text.Trim();
            productCategory.Description = this.TextBoxDescription.Text.Trim();
            productCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
            if (this.CheckBoxIsShow.Checked)
            {
                productCategory.IsShow = 1;
            }
            else
            {
                productCategory.IsShow = 0;
            }

            //得到级别
            //先根据一个空格分字符串，如果有4个空格，就是3级，因为2个空格为1级
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                //如果为顶级分类
                productCategory.CategoryLevel = 1;
            }
            else
            {
                string[] strLevel = this.DropDownListFatherCateGory.SelectedItem.Text.Split(charSapce);
                //  this.Response.Write(strLevel.Length.ToString());
                if (strLevel.Length > 0)
                {
                    productCategory.CategoryLevel = ((strLevel.Length + 1) / 2) + 1;

                }
                else
                {
                    productCategory.CategoryLevel = 2;
                }
            }
            productCategory.Family = string.Empty;
            productCategory.MemLoginID = this.MemLoginID;

            if (CheckBoxTb.Checked)
            {
                if (CheckCatExists(Convert.ToInt32(this.hiddenFieldGuid.Value)))
                {
                    UpdateTb();
                }
                else
                {
                    //以前不存在就插入
                    InsertTb(productCategory.ID);
                }
            }
         
            int check = 0;
            Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            shop_ProductCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
            check = shop_ProductCategory_Action.Update(productCategory);
            
            //更新
            if (check > 0)
            {

                //#region  操作日志部分
                //ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog();
                //operateLog.Record = "编辑" + this.TextBoxName.Text.Trim() + "成功";
                //operateLog.OperatorID = this.MemLoginID;
                //operateLog.IP = Globals.IPAddress;
                //operateLog.PageName = "TbProductCategory_Operate.aspx";
                //operateLog.Date = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //int log = OperateLog(operateLog);
                //#endregion
                this.Response.Redirect("TbProductCategory_List.aspx");
            }
            else
            {
                ////显示操作信息
                //this.MessageShowTb.ShowMessage("EditNo");
                //this.MessageShowTb.Visible = true;
            }
            #endregion
        }
    }



    //#region  淘宝TOP 操作
    /// <summary>
    /// 向淘宝添加类目
    /// </summary>
    /// <returns></returns>
    private void InsertTb(int siteid)
    {
      
        if (CheckTbUse())
        {
          
            Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
            //需返回的字段列表。
            param.Add("name", TextBoxName.Text.Trim());
            int fatherId = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            string parent_cid = string.Empty;
            ShopNum1_TbSellCat_Action sellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
            parent_cid = fatherId == 0 ? "0" : sellCatOperate.CheckSiteSellCat(fatherId).ToString();
       
            param.Add("parent_cid", parent_cid);
            string sortOrder = this.TextBoxOrderID.Text.Trim();
            param.Add("sort_order", "0");
            string strXml = TopAPI.Post("taobao.sellercats.list.add", TopClient.AgentSession, param);
            ErrorRsp errItem = new ErrorRsp();//定义错误对象
            Parser parser = new Parser();
            SellCatResponse sellcatResponse = new SellCatResponse();


            ////解析完整的SellCatResponse对象
            parser.XmlToObject2(strXml, "sellercats_list_add", "seller_cat", sellcatResponse, errItem);//如：解析XML对象到sellcatResponse
            ///////如果有错的就跳出
            if (!errItem.IsError)
           {
                //decimal cid = decimal.Parse(sellcatResponse.Cid);
            decimal d=0;
            if (decimal.TryParse(sellcatResponse.Cid, out d))
            {
                d = decimal.Parse(sellcatResponse.Cid);
            
            }
                InsertTbSellCat(d, decimal.Parse(parent_cid), siteid, fatherId);
                return;

          }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"同步淘宝错误：错误代码{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");window.location.href=\"/index.aspx\";", errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg), true);
                ClientScript.RegisterClientScriptBlock(typeof(Page), "error", "<script type='text/javascript'>alert('淘宝同步失败')</script>");
                return;
            }
        }
    }

    /// <summary>@
    /// 修改淘宝类目
    /// </summary>
    private void UpdateTb()
    {
        decimal tbcid = 0;
        if (CheckTbUse())
        {

            Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
            //需返回的字段列表。
            int ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString());
            ShopNum1_TbSellCat_Action sellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();

            tbcid = sellCatOperate.CheckSiteSellCat(ID);
            if (tbcid != 0)
            {
                param.Add("cid", tbcid.ToString());
                param.Add("name", TextBoxName.Text.Trim());
                string sortOrder = this.TextBoxOrderID.Text.Trim();
                param.Add("sort_order", "0");
                string strXml = TopAPI.Post("taobao.sellercats.list.update", TopClient.AdminSession, param);
                ErrorRsp errItem = new ErrorRsp();//定义错误对象
                Parser parser = new Parser();
                SellCatResponse sellcatResponse = new SellCatResponse();
                ////解析完整的SellCatResponse对象
                parser.XmlToObject2(strXml, "sellercats_list_update", "seller_cat", sellcatResponse, errItem);//如：解析XML对象到sellcatResponse
                if (errItem.IsError)
                {
                    ClientScript.RegisterClientScriptBlock(typeof(Page), "msg", "<script type='text/javascript'>alert('淘宝同步暂时不能进行')</script>", true);
                }
                else
                {
                    UpdateTbSellCat(0, ID);
                }
                /////如果有错的就跳出
                //if (errItem.IsError)
                //{
                //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");window.location.href=\"/index.aspx\";", errItem.code, errItem.msg, errItem.sub_code, errItem.sub_msg), true);
                //    return 0;
                //}
                

            }

        }
    }


    /// <summary>
    /// 操作中间表插入
    /// </summary>
    /// <returns></returns>
    private bool InsertTbSellCat(decimal cid, decimal fathercid, int siteCid, int sitefatherid)
    {
        ShopNum1_TbSellCat sellCat = new ShopNum1_TbSellCat();
        ShopNum1_TbSellCat_Action tbSellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        //if (fatherId != 0)
        //{
        //    fatherId = ()tbSellCatOperate.CheckSiteSellCat(siteCid);
        //}
        sellCat.cid = cid;
        sellCat.name = TextBoxName.Text.Trim();
        sellCat.pic_url = "";
        sellCat.parent_cid = fathercid;
        sellCat.site_cid = siteCid;
        sellCat.site_parent_cid = sitefatherid;
        sellCat.sort_order = int.Parse(TextBoxOrderID.Text.Trim());
        sellCat.shopname = TopClient.AgentUserNick;
        sellCat.isTaobao = false;
        sellCat.MemloginId = MemLoginID;
      
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+cid.ToString()+"\r\n");
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+TextBoxName.Text.Trim() + "\r\n");
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_"+fathercid.ToString() + "\r\n");
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + siteCid.ToString() + "\r\n");
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + sitefatherid.ToString() + "\r\n");
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "d_" + TopClient.AgentUserNick + "\r\n");

        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "B");
        if (tbSellCatOperate.InsertSellCat(sellCat))
        {
            //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "C");
            return true;
        }
        //System.IO.File.AppendAllText(Page.Server.MapPath("~/log/log.txt"), "D");
        return false;
    }

    /// <summary>
    /// 更新中间表
    /// </summary>
    /// <param name="cid"></param>
    /// <param name="siteCid"></param>
    /// <returns></returns>
    private bool UpdateTbSellCat(decimal cid,int siteCid)
    {
        ShopNum1_TbSellCat sellCat = new ShopNum1_TbSellCat();
        ShopNum1_TbSellCat_Action tbSellCatOperate = (ShopNum1_TbSellCat_Action)LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        //if (fatherId != 0)
        //{
        //    fatherId = ()tbSellCatOperate.CheckSiteSellCat(siteCid);
        //}
        sellCat.cid = cid;
        sellCat.name = TextBoxName.Text.Trim();
        sellCat.pic_url = "";
        sellCat.site_cid = siteCid;
        sellCat.sort_order = int.Parse(TextBoxOrderID.Text.Trim());
        return tbSellCatOperate.UpdateSellCat(sellCat);
    }


    protected void CheckBoxTb_CheckedChanged(object sender, EventArgs e)
    {
        CheckSellCat();
    }

    /// <summary>
    /// 检查分类是否存在
    /// </summary>
    private void CheckSellCat()
    {

        DropDownListFatherCateGory.Enabled = true;
        if (this.ButtonConfirm.ToolTip == "Update")
        {
            if (CheckBoxTb.Checked)
            {
                DropDownListFatherCateGory.Enabled = false;
            }
        }
        ShopNum1_TbSellCat_Action sellCatOperate = (ShopNum1_TbSellCat_Action)ShopNum1.Factory.LogicTbFactory.CreateShopNum1_TbSellCat_Action();
        int fatherId = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
        decimal fatherCid = sellCatOperate.CheckSiteSellCat(fatherId);
        if (fatherId != 0)
        {
            if (fatherCid == 0 && CheckBoxTb.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert('上级分类并没有和淘宝同步')", true);
                CheckBoxTb.Checked = false;
                DropDownListFatherCateGory.Enabled = true;
                return;
            }
            if (!CheckItemSetItem(fatherCid.ToString()))
            {
                CheckBoxTb.Checked = false;
                DropDownListFatherCateGory.Enabled = true;
                return;
            }
        }

    }



    /// <summary>
    /// 检查淘宝api是否可用
    /// </summary>
    private bool CheckTbUse()
    {
        //if (!TopClient.isAdminSessionTrue)
        //{
        //    return false;
        //}
        return true;
        // ShopNum1_TbSystem_Action tbSystemOperate = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
        // DataTable dt = tbSystemOperate.GetTbSysem(TopClient.AdminUserNick);
        //if (dt == null && dt.Rows.Count == 0)
        //{

        //    Num1GridViewShow.Columns[15].Visible = false;
        //    return;
        //}
        //else
        //{
        //    if (Convert.ToBoolean(dt.Rows[0]["isOpen"]))
        //    {
        //        Num1GridViewShow.Columns[15].Visible = true;
        //        btnTbSite.Enabled = true;
        //    }
        //    else
        //    {
        //        Num1GridViewShow.Columns[15].Visible = false;

        //    }

        //}
    }





    /// 绑定商品分类
    /// </summary>
    private void BindProductCategory()
    {
        this.DropDownListFatherCateGory.Items.Clear();

        //添加顶级分类
        ListItem item = new ListItem();
        item.Text = LocalizationUtil.GetCommonMessage("OneCategory");
        item.Value = "0";   //顶级分类
        this.DropDownListFatherCateGory.Items.Add(item);

        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
        //取顶级分类
        DataView dataView = productCategoryAction.Search(0, 0).DefaultView;

        foreach (DataRow dr in dataView.Table.Rows)
        {
            ListItem listItem = new ListItem();
            DataTable dataTable;
            ////如果是一级一分类
            //if (dr["FatherID"].ToString().Trim() == "0")
            //{       
            listItem.Text = dr["Name"].ToString().Trim();
            listItem.Value = dr["ID"].ToString().Trim();

            this.DropDownListFatherCateGory.Items.Add(listItem);
            //如果有子分类
            dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
            if (dataTable.Rows.Count > 0)
            {
                AddSubProductCategory(dataTable);
            }
            //}

            //else
            //{
            //    //子分类
            //    dataTable = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
            //    if (dataTable.Rows.Count > 0)
            //    {
            //        AddSubProductCategory(dataTable);
            //    }
            //    else
            //    {
            //        listItem.Text = "├ " + dr["Name"].ToString().Trim();
            //        listItem.Value = dr["ID"].ToString().Trim();
            //        this.DropDownListFatherCateGory.Items.Add(listItem);
            //    }
            //}

            //this.DropDownListFatherCateGory.Items.Add(listItem);
        }
    }
    //添加子分类
    private void AddSubProductCategory(DataTable dataTable)
    {
        ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
        foreach (DataRow dr in dataTable.Rows)
        {
            ListItem listItem = new ListItem();
            //listItem.Text = dr["Name"].ToString().Trim();
            string str = string.Empty;
            for (int i = 0; i < Convert.ToInt32(dr["CategoryLevel"].ToString()) - 1; i++)
            {
                //strSpace是两个空格
                str = str + strSapce;
            }
            //for (int i = 0; i < 2; i++)
            //{
            //    str = str + strSapce;
            //}
            str = str + dr["Name"].ToString().Trim();
            listItem.Text = str;
            listItem.Value = dr["ID"].ToString().Trim();

            this.DropDownListFatherCateGory.Items.Add(listItem);
            DataTable dataTable1 = productCategoryAction.Search(Convert.ToInt32(dr["ID"].ToString().Trim()), 0);
            if (dataTable1.Rows.Count > 0)
            {
                AddSubProductCategory(dataTable1);
            }
        }

    }



    //清空控件
    private void ClearControl()
    {
        this.TextBoxName.Text = string.Empty;
        //this.TextBoxOrderID.Text = string.Empty;
        this.DropDownListFatherCateGory.SelectedValue = "0";
        this.TextBoxKeywords.Text = string.Empty;
        this.TextBoxDescription.Text = string.Empty;
        this.CheckBoxIsShow.Checked = true;

    }


    ///<summary>
    ///会员ID
    /// </summary>
    public string MemLoginID { get; set; }
}
