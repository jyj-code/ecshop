﻿<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="ShopNum1.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>进入我的店铺</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />

    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"></script>

    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>

    <script type="text/javascript">
        function messageBox(msg)
        {
            if(confirm("您是否要"+msg+"该插件?"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">店铺支付方式</span></p>
        <ShopNum1ShopAdmin:S_ShowPaymentType ID="S_ShowPaymentType" runat="server" SkinFilename="Skin/S_ShowPaymentType.ascx" />
    </div>
    </form>
</body>
</html>
