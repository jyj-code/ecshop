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
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="warp_site" style="margin-top: 10px;">
        首页 》<a href="/ZtcGoodslist.html">直通车</a>
    </div>
    <div class="searchpro">
        <div class="searchleft">
            <!--商品三级分类 全部分类-->
            <shopnum1:productthreecategory id="ProductThreeCategory1" runat="server" skinfilename="ProductThreeCategory.ascx"
                showcountone="10" showcounttwo="5" />
            <!--推荐商品-->
            <%--<shopnum1:productiscategoryshow id="ProductIsCategoryShow3" runat="server" skinfilename="ProductByProp.ascx"
                showcount="5" producttype="IsShopRecommend" />--%>
            <%--<shopnum1:ZtcGoods id="ZtcGoods" runat="server" skinfilename="ZtcGoods.ascx"
                startNum="5" endNum="10"/>--%>
        </div>
        <div class="searchright">
            <!-- 热销商品-->
            <%--<shopnum1:productiscategoryshow id="ProductIsCategoryShow4" runat="server" skinfilename="ProductByProperty.ascx"
                showcount="4" producttype="IsHot" title="热销商品" />--%>
            <%--<shopnum1:ZtcGoods id="ZtcGoods1" runat="server" skinfilename="ZtcGoods1.ascx"
                 startNum="1" endNum="4"/>--%>
            <!--商品属性-->
            <%--<shopnum1:productattribute id="ProductAttribute1" runat="server" skinfilename="ProductAttribute.ascx" />--%>
            <!--商品展示-->
            <shopnum1:ZtcGoodsMoreList id="ZtcGoodsMoreList" showcount="30" cityshowcount="10"
                runat="server" skinfilename="ZtcGoodsMoreList.ascx" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--       end                -->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>

