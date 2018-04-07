<%@ Page Language="C#"  EnableViewState="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>账户管理-账户安全设置</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>
    <link type="text/css"  href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>
      <script src="js/jquery.pack.js" type="text/javascript"></script>
     <link href="style/Msafe_uc-base-css.css" rel="stylesheet" type="text/css" />
    <link href="style/Mpassport_safe_center_css.css" rel="stylesheet" type="text/css" />
      <script src="js/Common.js" type="text/javascript"></script>
     
    
</head>
<body>
<div class="dpsc_mian">
  <p class="ptitle" ><a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><a href="A_PwdSer.aspx">账户安全设置</a><span class="breadcrume_icon">>></span>
  <span class="breadcrume_text">绑定手机</span></p>
<form id="fromBindMobile" runat="server" autocomplete="off" method="post">
       <ShopNum1Account:A_BindMobile    ID="A_BindMobile" runat="server" SkinFilename="Skin/A_BindMobile.ascx"  /> 
</form>
</div>
</body>
</html>
