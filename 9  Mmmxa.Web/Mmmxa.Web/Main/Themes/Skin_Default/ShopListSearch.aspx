<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head> 
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ShopCategoryMeto ID="ShopCategoryMeto" runat="server" SkinFilename="ShopCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />

    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    
    <!-- main Start -->
     <div class="FlowCat_cont">
        <div class="warp_site">首页 》<a href="/ShopListSearch.html">店铺</a></div>
        <div class="shopsearch">
            <!--店铺分类 店铺类目-->
            <ShopNum1:ShopCategoryCount ID="ShopCategoryCount2" runat="server" SkinFilename="ShopCategoryCount.ascx" ShowCountOne="60" />
            <div>
                <!--店铺搜索结果-->
                <ShopNum1:ShopListSearch ID="ShopListSearch1" ShowCount="15" runat="server" SkinFilename="ShopListSearch.ascx" ShowRelatedProduct="-1" />
                <div class="shoplistR">
                     <%--<ShopNum1:ShopListControl  id="ShopListControl" runat="server" ShopType="1" ShowCount="5" SkinFilename="ShopListControl.ascx" />--%>
                    <ShopNum1:ShopListControl  id="ShopListControl1" runat="server" ShopType="2" ShowCount="10" SkinFilename="ShopListControl.ascx" IsSub="0" />
                    <%--<ShopNum1:ShopListControl  id="ShopListControl2" runat="server" ShopType="3" ShowCount="5" SkinFilename="ShopListControl.ascx" />--%>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <!-- //main End -->
    
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>

<script src="/JS/baiduTemplate.js" type="text/javascript"></script>

