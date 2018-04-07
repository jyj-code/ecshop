<%@ Page Language="C#" AutoEventWireup="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布平台付费广告</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <script type="text/javascript" src="/JS/jquery-1.6.2.min.js"></script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="uploadify/swfobject.js"></script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">营销管理</span><span class="breadcrume_icon">>></span><span class="breadcrume_text">发布平台付费广告</span></p>
        <script type="text/javascript" src="js/Page_ClientValidate.js"></script>
        <ShopNum1ShopAdmin:S_TerracePay_Operate ID="S_TerracePay_Operate" runat="server" SkinFilename="skin/S_TerracePay_Operate.ascx" />
    </div>
    </form>
</body>
</html>
