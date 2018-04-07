<%@ Page Language="C#" EnableViewState="false" Buffer="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户管理</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
    <p class="ptitle">
   <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">我的账户</span></p>
         <ShopNum1Account:A_Welcome ID="A_Welcome" runat="server" SkinFilename="Skin/A_Welcome.ascx" />
    </div>
    </form>
</body>
</html>
