<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>快递单预览</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <style type="text/css">
        <! -- .hidden
        {
            display: none;
            width: 0;
        }

        .fl
        {
            float: left;    
        }

        .fr
        {
            floar: right;
        }

        .show
        {
            width: 58px;
            height: 21px;
            background: url(images/Bt_background.gif);
            background-repeat: no-repeat;
            border: 0;
            line-height: 21px;
            text-align: center;
        }

        .show2
        {
            width: 94px;
            height: 21px;
            background: url(images/Bg2_background.gif);
            background-repeat: no-repeat;
            border: 0;
            line-height: 21px;
            text-align: center;
        }

        -- > .style1
        {
            width: 20%;
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <ShopNum1ShopAdmin:S_PrintSingOrder ID="S_PrintSingOrder" runat="server" SkinFilename="Skin/S_PrintSingOrder.ascx" />
    </form>
</body>
</html>
