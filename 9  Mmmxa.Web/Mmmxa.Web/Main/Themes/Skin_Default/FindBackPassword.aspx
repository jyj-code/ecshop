<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link type="text/css" href="Themes/Skin_Default/Style/index.css" rel="Stylesheet" />
    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
      if (top.location != location) top.location.href = location.href;
        $(document).ready(function(){
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

</head>
<body>
    <form id="from1" runat="server">
        <!--head Start-->
        <!-- #include file="headShop.aspx" -->
        <!--//head End-->
        
        <!--main Start-->
        <div class="FlowCat_cont">
            <div class="position">����λ��:<a href="Default.aspx">��ҳ</a> > �һ�����</div>
            <ShopNum1:PasswordReset ID="PasswordReminderUrl" runat="server" SkinFilename="PasswordReset.ascx" />
        </div>
        <!--//main End-->
       
        <!--foot Start-->
        <!-- #include file="foot1.aspx" -->
        <!--//foot End-->
    </form>
</body>
</html>