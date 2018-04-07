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
        <div class="warp_site">首页 》<a href="/Search_productlist.html">商品搜索</a></div>
        <div class="article_cont">
            <div class="list_left fl">
                <!--商品三级分类 全部分类-->
                <shopnum1:productthreecategory id="ProductThreeCategory1" runat="server" skinfilename="ProductThreeCategory.ascx"
                    showcountone="10" showcounttwo="5" />
                <!--推荐商品-->
              <%--  <shopnum1:productiscategoryshow id="ProductIsCategoryShow3" runat="server" skinfilename="ProductByProp.ascx"
                    showcount="5" producttype="IsShopRecommend" />--%>
              <ShopNum1:ZtcGoods id="ZtcGoods" runat="server" skinfilename="ZtcGoods.ascx" startNum="1" endNum="6"/>
              <div class="tuijianpro">
                                <h1>浏览历史</h1>
                                <div class="tuijiancont" id="MyHistory">
                                </div>
            </div>
            </div>
            <div class="list_right fr">
                <!-- 热销商品-->
                <shopnum1:productiscategoryshow id="ProductIsCategoryShow4" runat="server" skinfilename="ProductByProperty.ascx"
                    showcount="4" producttype="IsSystemHot" title="热销商品" />
                 <!--商品属性-->
                <shopnum1:productattribute id="ProductAttribute1" runat="server" skinfilename="ProductAttribute.ascx"  />
                <!--商品展示-->
                <ShopNum1:Search_productlistNew_V8_2 ID="Search_productlistNew_V8_2" runat="server" ShowCount="30" CityShowCount="10" SkinFilename="Search_productlistNew_V8_2.ascx"/>
               <%-- <shopnum1:search_productlist id="ProductSearch" showcount="30" cityshowcount="10" 
                    runat="server" skinfilename="Search_productlist.ascx" />--%>
            </div>
        </div>
    </div>
    <!--//main End-->
    <script src="/js/load.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/js/jquery.cookie.js"></script>
        <script type="text/javascript" charset="utf-8">
        //读取cookied历史记录
$(function(){

var hc=$.cookie("history");
if(hc!=null)
{
if(hc.indexOf("*")!=-1)
{
     var splithtml=hc.split("*");
     var xhtml=new Array();
     var hlength=splithtml.length;
     if(parseInt(hlength)>4)
         hlength=4;
     for(var i=0;i<parseInt(hlength);i++)
     {
         xhtml.push('<div class="tuijian"><div class="tjname"><a href="'+splithtml[i].split("|")[2]+'">'+splithtml[i].split("|")[1].substr(0, 17)+'</a></div>');
         xhtml.push('<div class="tjimga"><a href="'+splithtml[i].split("|")[2]+'"><img src="'+splithtml[i].split("|")[0]+'_160x160.jpg" alt="'+splithtml[i].split("|")[1]+'" /></a><p>￥'+splithtml[i].split("|")[3]+'</p></div>');
         xhtml.push('<div class="otherInfo clearfix"><span>已销售<b>'+splithtml[i].split("|")[4]+'</b>笔</span><a href="'+splithtml[i].split("|")[2]+'">再看看</a></div></div>');
     }
     xhtml.push('<div class="tr"><a href="javascript:clearcookied();">清空记录</a></div>');
     $("#MyHistory").append(xhtml.join(""));
}
else{
     var xhtml=new Array();
     xhtml.push('<div class="tuijian"><div class="tjname"><a href="'+hc.split("|")[2]+'">'+hc.split("|")[1].substr(0, 17)+'</a></div>');
         xhtml.push('<div class="tjimga"><a href="'+hc.split("|")[2]+'"><img src="'+hc.split("|")[0]+'_160x160.jpg" alt="'+hc.split("|")[1]+'" /></a><p>￥'+hc.split("|")[3]+'</p></div>');
         xhtml.push('<div class="otherInfo clearfix"><span>已销售<b>'+hc.split("|")[4]+'</b>笔</span><a href="'+hc.split("|")[2]+'">再看看</a></div></div>');
         xhtml.push('<div class="tr"><a href="javascript:clearcookied();">清空记录</a></div>');
    $("#MyHistory").append(xhtml.join(""));
}
}
else
{
    $("#MyHistory").append("<li>暂无浏览记录</li>");
}
});

function clearcookied()
{
  var domainhost=document.location.host.substring(document.location.host.indexOf("."),document.location.host.length);
    $.cookie('history',null,{expires:1,domain:domainhost});
    $("#MyHistory").html("<li>暂无浏览记录</li>");
}
          $(function() {
              $("img").each(function(){$(this).attr("src",$(this).attr("original"));});
          });
        </script>
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    </form>
</body>
</html>
<script src="/JS/baiduTemplate.js" type="text/javascript"></script>

