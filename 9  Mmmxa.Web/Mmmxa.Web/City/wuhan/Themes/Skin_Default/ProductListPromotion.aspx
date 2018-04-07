<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <shopnum1:productcategorymeto id="ProductCategoryMeto" runat="server" skinfilename="ProductCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.6.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="warp_site">首页 》<a href="/Search_productlist.html">促销商品</a></div>
        <div class="article_cont">
            <div class="list_left fl">
                <!--商品三级分类 全部分类-->
                <shopnum1:productthreecategory id="ProductThreeCategory1" runat="server" skinfilename="ProductThreeCategory.ascx"
                    showcountone="10" showcounttwo="5" />
                <!--推荐商品-->
                <shopnum1:productiscategoryshow id="ProductIsCategoryShow3" runat="server" skinfilename="ProductByProp.ascx"
                    showcount="5" producttype="IsShopRecommend" />
            </div>
            <div class="list_right fr">
                <!-- 热销商品-->
                <shopnum1:productiscategoryshow id="ProductIsCategoryShow4" runat="server" skinfilename="ProductByProperty.ascx"
                    showcount="4" producttype="IsHot" title="热销商品" />
                 <!--商品属性-->
                <shopnum1:productattribute id="ProductAttribute1" runat="server" skinfilename="ProductAttribute.ascx" />
                <!--商品展示-->
                <%--<shopnum1:search_productlist id="ProductSearch" showcount="30" cityshowcount="10" 
                    runat="server" skinfilename="ProductListPromotion.ascx" />--%>
                    <shopnum1:Search_productlistNew id="Search_productlistNew" showcount="30" cityshowcount="10" 
                    runat="server" skinfilename="Search_productlistNew.ascx" />
            </div>
        </div>
    </div>
    <!--//main End-->
    
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>

