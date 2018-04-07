<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:ProductCategoryMeto ID="ProductCategoryMeto" runat="server" SkinFilename="ProductCategoryMeto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: none;">
    <form id="form1" runat="server">
    <!-- main Start -->
     <ShopNum1:SubstationError runat="server" ID="SubstationError" SkinFilename="SubstationError.ascx" />
    <!-- //main End -->
    </form>
</html>
