<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-black.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop.css" rel="stylesheet" type="text/css" />
    <title>°Ù¶ÈµØÍ¼</title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Ysv2U4rRH9zYrFltfyl73WbB"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <!--head Start-->
        <!-- #include file="AgentHead.aspx" -->
        <!--//head End-->
    
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp">
                <ShopNum1ShopNew:BaiDuMap ID="BaiDuMap" runat="server" SkinFilename="BaiDuMap.ascx" />
            </div>   
        </div> 
        
        <div class="clearfix">
            <ShopNum1ShopNew:FootNew ID="Foot" runat="server" SkinFilename="FootNew.ascx" />
        </div>
        
    </form>
</body>
</html>
