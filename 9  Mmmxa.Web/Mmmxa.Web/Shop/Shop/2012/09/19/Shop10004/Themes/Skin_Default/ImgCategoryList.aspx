<%@ Page Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相册展示</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto1" runat="server" SkinFilename="SetMeta.ascx" />

   
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="Div1">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <!--main start-->
            <!--left is start-->
            <div class="sidebar leftn_hot">
                <!--自定义导航-->
                <!--店铺信息-->
                <ShopNum1Shop:ShopInfo ID="ShopInfo1" runat="server" SkinFilename="ShopInfo.ascx" />
                <!--商品搜索-->
                <ShopNum1Shop:ProduceSearch ID="ProduceSearch1" runat="server" SkinFilename="ProduceSearch.ascx" />
                <!--商品分类-->
                <ShopNum1Shop:ProductCategory ID="ProductCategory1" runat="server" SkinFilename="ProductCategory.ascx" />
               <!-- 宝贝排行-->
                <div class="ks_panel">
                    <div class="storn_hd">
                        <h3>商品排行</h3>
                        <p class="gd_more"><a href="/ProductSearchList.html">更多>></a></p>
                    </div>
                    <ul class="sellor">
                        <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')">热销宝贝排行</li>
                        <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')">热门收藏排行</li>
                    </ul>
                    <div class="ktlist">
                        <!--热销排行-->
                        <div id="b0" style="display: block">                                
                            <ShopNum1Shop:ProductListSaleRanking ID="ProductListSaleRanking" runat="server" SkinFilename="ProductListSaleRanking.ascx"
                                ShowCount="10" />
                        </div>
                        <!--收藏排行-->
                        <div id="b1" style="display: none">
                            <ShopNum1Shop:ProductListCollectRanking ID="ProductListCollectRanking" runat="server"
                                SkinFilename="ProductListCollectRanking.ascx" ShowCount="10" />
                        </div>
                    </div>
               </div>
            </div>
            <!--Right start-->
            <div class="main">
                <div class="intge">
                      <ShopNum1Shop:Advertisements ID="topadvertisement" runat="server" SkinFilename="Advertisements.ascx" PageName="ProductIsSpell_List.aspx"/>
                </div>
                <!--团购商品-->
                <shopNum1ShopNew:ImgCategoryList ID="ImgCategoryList" runat="server" SkinFilename="ImgCategoryList.ascx" ShowCount="12" />
            </div>
            <!--is the end-->
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
    </ShopNum1:Form>
</body>
</html>
