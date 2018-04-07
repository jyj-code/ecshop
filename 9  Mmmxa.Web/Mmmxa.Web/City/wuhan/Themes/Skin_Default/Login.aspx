<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
     <meta http-equiv="pragma" content="no-cache"  />
   <meta http-equiv="content-type" content="no-cache, must-revalidate" />
   <meta http-equiv="expires" content="Wed, 26 Feb 1997 08:21:57 GMT"/>
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function(){
    if($("#Login_ctl00_LabelMemLoginID").text()!="")
{
document.getElementById('denglu').style.display="none";
   
}
      $("#FlowCate").mouseover(function(){								
              $("#ThrCategory").show();
		      $("#ThrCategory").focus();	  
      }).mouseout(function(){
	      $("#ThrCategory").hide();
      });	
      $("#ThrCategory").mouseover(function(){
		     $("#ThrCategory").show();		  
	  }).mouseout(function(){
        $("#ThrCategory").hide();	
	  });
    });
    </script>
    <!--[if lte IE 6]>
    <script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a');
    </script>
    <![endif]-->
</head>
<body style="background:#f6f6f6;" onLoad="javascript:document.form1.reset()">
    <form id="form1" runat="server">
    <!--head Start-->
    <div class="wrapBox LogoMessage">
        <a href="Default.aspx"><img src="Themes/Skin_Default/Images/newLogo.png" /></a>
    </div>
    <!--//head End-->
    
    <!--main Start-->
    <div class="LoginBox">
        <ShopNum1:Login ID="Login" runat="server" SkinFilename="Login.ascx" />
    </div>
    <div class="wrapBox OtherMess" id="denglu">
        <p>如果您还没有登录账号，请先<a target="_blank" href="MemberRegister.aspx" class="RegisLink">注册会员</a>然后登录</p>
        <p>如果您<a target="_blank" href="FindBackPassword.aspx" class="FindLink">忘了密码？</a>请申请找回密码</p>
    </div>
    <!--//main End-->
    
    <!--foot Start-->
    <div class="wrapBox FootMessage">
<%--        <p><a href="#">关于我们</a> | <a href="#">联系我们</a> | <a href="#">招贤纳士</a> | <a href="#">诚招代理</a> | 
        <a href="#">如何购买</a> | <a href="#">法律声明</a> | <a href="#">常见问题</a> | <a href="#">软件著作权</a> | <a href="#">官方论坛</a></p>
        <p>Copyright©2004-2013 Groupfly 武汉群翔软件有限公司 版权所有</p>--%>
        <ShopNum1:Bottom ID="Bottom" runat="server" SkinFilename="Bottom.ascx" class="foot_bg" />

    </div>
    <!--//foot End-->
    </form>
</body>
</html>
