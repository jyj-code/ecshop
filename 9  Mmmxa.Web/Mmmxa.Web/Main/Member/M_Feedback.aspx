<%@ Page Language="C#" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信用评价</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>

    <script type="text/javascript" language="javascript" src="/Shop/shopadmin/js/dshow.js"></script>

    <link rel='stylesheet' type='text/css' href='/Shop/shopadmin/style/dshow.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle"><a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">信用评价</span></p>
        <ShopNum1:M_FeedBack ID="M_FeedBack" runat="server" SkinFilename="skin/M_FeedBack.ascx" />
    </div>
    </form>
</body>
</html>
