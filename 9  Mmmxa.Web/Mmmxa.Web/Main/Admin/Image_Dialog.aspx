﻿<%@ page language="C#" autoeventwireup="true" inherits="Admin_Image_Dialog"   CodeBehind="Image_Dialog.aspx.cs"      %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="ImagePack" ImageUrl="" onerror="javascript:this.src='../../ImgUpload/noImage.gif'" runat="server" />
    
    </div>
    </form>
</body>
</html>
