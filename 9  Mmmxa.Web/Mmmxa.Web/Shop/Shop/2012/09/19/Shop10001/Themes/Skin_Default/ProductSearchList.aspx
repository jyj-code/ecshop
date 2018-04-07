﻿<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<%@ Page Language="C#" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" runat="server" SkinFilename="SetMeta.ascx" />
    <script type="text/javascript">
        function tab(selfid,targetid,index,count,selfclass,otherclass) {
            for(var i=0;i<count;i++) {
                if(i == index) {
                    document.getElementById(selfid + i).className = selfclass;
                    document.getElementById(targetid + i).style.display = "block";
                }
                else {
                    document.getElementById(selfid + i).className = otherclass;
                    document.getElementById(targetid + i).style.display = "none";
                }
            }
        }
    </script>
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="content">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <!--main start-->
            <!--left is start-->
            <div class="sidebar leftn_hot">
                <!--店铺信息-->
                <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                <!--商品搜索-->
                <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
                <!--商品分类-->
                <ShopNum1Shop:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                <!-- 宝贝排行-->
                <div class="ks_panel">
                    <div class="storn_hd">
                        <h3>商品排行</h3>  <p class="gd_more"><a href="/ProductSearchList.html"></a></p>
                    </div>
                    <ul class="sellor">
                        <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')">热销宝贝排行</li>
                        <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')">热门收藏排行</li>
                    </ul>
                    <div class="ktlist">
                        <input type="hidden" id="hidShopId" value="<%=Request.QueryString["ShopID"]%>" />
                        <script type="text/javascript" language="javascript" src="/main/js/shop1/ProductListOp.js"></script>
                        <!--热销排行-->
                        <div id="b0" style="display: block"></div>
                        <!--收藏排行-->
                        <div id="b1" style="display: none"></div>
                    </div>
               </div>
            </div>
            <!--Right start-->
            <div class="main">
                <div class="str_advt">
                    <img src="Themes/Skin_Default/Images/advt1.jpg" />
                </div>
                <!--商品搜索列表-->
                <ShopNum1ShopNew:ProductSearchList ID="ProductSearchList1" runat="server" ShowCount="12" SkinFilename="ProductSearchListNew.ascx" />
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
    </ShopNum1:Form>
</body>
</html>