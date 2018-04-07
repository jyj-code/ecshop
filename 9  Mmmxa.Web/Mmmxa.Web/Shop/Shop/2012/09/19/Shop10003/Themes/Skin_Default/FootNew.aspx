

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' /> 
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeto" SkinFilename="SetMeta.ascx" runat="server" />
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Ysv2U4rRH9zYrFltfyl73WbB"></script>

<div id="site">
    <ShopNum1ShopNew:FootNew ID="Foot" runat="server" SkinFilename="FootNew.ascx" />
</div>
    </ShopNum1:Form>
<!--[if lte IE 6]>
<script src="/Main/Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
</body>
</html> 
