<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #l-map
        {
            height: 80%;
            text-align: center;
        }
    </style>
    <title>°Ù¶ÈµØÍ¼</title>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Ysv2U4rRH9zYrFltfyl73WbB"></script>

</head>
<body>
    <form runat="server">
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
