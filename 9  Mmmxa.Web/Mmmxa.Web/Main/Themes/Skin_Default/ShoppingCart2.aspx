<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page Language="C#" enableEventValidation="false"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <ShopNum1:Meto ID="meto" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">    
  <!--    
  javascript:window.history.forward(1);    
  -->    
    </script>
</head>
<body>
    <form id="from1" runat="server" method="post"  autocomplete="off">
    <!--head start-->
    <!-- #include file="headShop.aspx" -->
    <!--main start-->
    <div class="FlowCat_cont">
        <div class="warp_site">首页 》<a>订单结算</a></div>
        <%--购物流程--%>
        <ShopNum1:ShoppingCart2_New ID="ShoppingCart2_New" runat="server" SkinFilename="ShoppingCart2_New.ascx" />
    </div>
    <!--foot start-->
    <!-- #include file="foot1.aspx" -->
    <!--       end                -->
    </form>
</body>
</html>
