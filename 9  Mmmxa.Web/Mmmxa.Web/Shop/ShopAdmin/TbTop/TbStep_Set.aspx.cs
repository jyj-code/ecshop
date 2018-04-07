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
using ShopNum1.Factory;
using ShopNum1.TbTopCommon;
using ShopNum1.Common;
using ShopNum1.TbLinq;


public partial class Admin_TbTop_TbSetp_Set : System.Web.UI.Page
{

    ShopNum1_TbSystem_Action tbSystemOperate = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
    protected void Page_Load(object sender, EventArgs e)
    {

        //验证会员中心的cookies
        if (Page.Request.Cookies["MemberLoginCookie"] == null)
        {      //退出
            GetUrl.RedirectTopLogin();
        }
        else
        {
            HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
            string MemberType = decodedCookieMemberLogin.Values["MemberType"].ToString();
            if (MemberType != "2")
            {
                //退出
                GetUrl.RedirectTopLogin();
                return;
            }
            //会员登录ID
            MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"].ToString();
        }
        if (Session["access_token"] == null)
        {
            Response.Redirect("TbAuthorization.aspx");
        }
        if (!IsPostBack)
        {
            tbSetBind();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShopNum1_TbSystem tbSystem = new ShopNum1_TbSystem();
        tbSystem.isOpen = radStepOpen.Checked ? true : false;
        tbSystem.hasTbOrder = radOrderOpen.Checked ? true : false;
        tbSystem.hasTbRate = RadioButtonPlOpen.Checked ? true : false;
        tbSystem.tbItemName = tTitleTtS.Checked ? true : false;
        //tbSystem.siteItemName = tTileStT.Checked ? true : false;
        tbSystem.tbItemPrice = tPriceTtS.Checked ? true : false;
        //tbSystem.siteItemPrice = tPriceStT.Checked ? true : false;
        tbSystem.tbSellCat = tTypeTtS.Checked ? true : false;
        //tbSystem.siteSellCat = tTypeStT.Checked ? true : false;
        tbSystem.tbCount = tCountTtS.Checked ? true : false;
        //tbSystem.siteCount = tCountStT.Checked ? true : false;

        //tbSystem.tbImg = RadioButtonTimg.Checked ? true : false;
        //由于缩略图需要在本地读取使用，所以图片默认下载到本地
        tbSystem.tbImg = true;
        // tbSystem.siteImg = true;
        tbSystem.tbDesc = tDescTtS.Checked ? true : false;
        // tbSystem.siteDesc = tDescStT.Checked ? true : false;
        tbSystem.tbShopName = TopClient.AgentUserNick;
        tbSystem.Memlogid = MemLoginID;

        if (tbSystemOperate.UpdateTbSystem(tbSystem))
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "msg", "alert('修改成功')", true);
            tbSetBind();
            return;
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "msg", "alert('修改失败')", true);
            tbSetBind();
            return;
        }


    }

    /// <summary>
    /// 初始权限
    /// </summary>
    private void tbSetBind()
    {
        if (TopClient.AgentUserNick != "")
        {
            spanShopName.InnerText = TopClient.AgentUserNick;

            ShopNum1_TbSystem tbSystem = tbSystemOperate.GetTbSysem(MemLoginID, TopClient.AgentUserNick);

            if (tbSystem != null)
            {
                if (tbSystem.isOpen == null)
                {
                    tbSystem.isOpen = false;
                }
                if ((bool)tbSystem.isOpen)
                {
                    radStepOpen.Checked = true;
                }
                else
                {
                    radStepClose.Checked = true;
                }
                RadioButtonPlOpen.Checked = (bool)tbSystem.hasTbRate;
                radOrderOpen.Checked = (bool)tbSystem.hasTbOrder;
                tTitleTtS.Checked = (bool)tbSystem.tbItemName;
                //tTileStT.Checked = (bool)tbSystem.siteItemName;
                tPriceTtS.Checked = (bool)tbSystem.tbItemPrice;
                // tPriceStT.Checked = (bool)tbSystem.siteItemPrice;
                tTypeTtS.Checked = (bool)tbSystem.tbSellCat;
                //tTypeStT.Checked = (bool)tbSystem.siteSellCat;
                tCountTtS.Checked = (bool)tbSystem.tbCount;
                //tCountStT.Checked = (bool)tbSystem.siteCount;
                if ((bool)tbSystem.tbImg)
                {
                    RadioButtonTimg.Checked = true;
                    RadioButtonTimgNo.Checked = false;
                }
                else
                {
                    RadioButtonTimg.Checked = false;
                    RadioButtonTimgNo.Checked = true;
                }

                tDescTtS.Checked = (bool)tbSystem.tbDesc;
                //tDescStT.Checked = (bool)tbSystem.siteDesc;
            }

        }

    }

    /// <summary>
    /// 会员名
    /// </summary>
    private string MemLoginID { get; set; }

    private string ShopName; //店铺名称

    private bool CheckMemberID(string MemLoginID)
    {
        try
        {
            ShopName = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"].ToString());
        }
        catch
        {
            ShopName = "";
        }

        ShopNum1_TbSystem_Action tbSystem = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
        if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}