﻿<%@ Page Language="C#" EnableViewState="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店铺资讯管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script language="javascript" type="text/javascript" src="js/jquery.pack.js"></script>
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ShopNum1ShopAdmin:S_ShopNewsEdit ID="S_ShopNewsEdit" runat="server" SkinFilename="Skin/S_ShopNewsEdit.ascx"/>
    </form>
</body>
</html>