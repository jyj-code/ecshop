﻿<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ShopCategoryMeto ID="ShopCategoryMeto" runat="server" SkinFilename="ShopCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />

    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>

   <%-- <script src="/JS/baiduTemplate.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
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
    
    <style type="text/css">
        body{background: url(Themes/Skin_Default/Images/tuan_bg.png);}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <!-- main Start -->
    <div class="FlowCat_cont">
      <ShopNum1:ThreeLogin ID="ThreeLogin" runat="server" SkinFilename="ThreeLogin.ascx" />
    </div>
    </form>
</body>
</html>
