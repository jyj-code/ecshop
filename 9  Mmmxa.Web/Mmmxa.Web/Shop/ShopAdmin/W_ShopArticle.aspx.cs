using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System.Data;

public partial class Shop_ShopAdmin_W_ShopArticle : System.Web.UI.Page
{

    public string Article = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string articleid = Page.Request["id"] ?? string.Empty;

            IShopNum1_Weixin_ReplyRuleContent_Active shopnum1_weixin_replyrulecontent_active = new ShopNum1_Weixin_ReplyRuleContent_Active();

            Article = shopnum1_weixin_replyrulecontent_active.Get_Article(articleid);

        }
    }
}
