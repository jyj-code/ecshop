<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link href="style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
           <ShopNum1ShopAdmin:S_ShipperOperate ID="S_ShipperList" runat="server" SkinFilename="Skin/S_ShipperOperate.ascx" />
    </form>
</body>
</html>
