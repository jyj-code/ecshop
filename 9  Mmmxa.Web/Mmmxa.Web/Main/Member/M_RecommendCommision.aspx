﻿<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员推荐返利</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />

    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="js/Common.js"></script>

    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">推荐会员返利列表</span></p>
        <ShopNum1:M_RecommendCommision ID="M_RecommendCommision" runat="server" SkinFilename="Skin/M_RecommendCommision.ascx"
            PageSize="10" />
    </div>

    <script type="text/javascript" language="javascript">
         //跳转到制定的页码
         function ontoPage(txtId)
         {
               location.href='?isread=<%= Common.ReqStr("isread") %>&pageid='+$("#txtIndex").val();
         }
    </script>

    </form>
</body>
</html>