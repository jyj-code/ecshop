<%@ Page Language="C#" EnableViewState="false" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的收藏</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />

    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="js/Common.js"></script>

    <script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript">
     function sethash(){
            var hashH = document.documentElement.scrollHeight;
            parent.document.getElementById("mainFrame").style.height=hashH+"px";
    }
    window.onload=sethash;
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="dpsc_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">我的收藏</span></p>
        <ShopNum1:M_MyCollect ID="M_MyCollect" runat="server" SkinFilename="Skin/M_MyCollect.ascx" />
    </div>

    <script type="text/javascript" language="javascript">
         //跳转到制定的页码
         function ontoPage(txtId)
         {
               location.href='?pageid='+$("#txtIndex").val();
         }
    </script>

    </form>
</body>
</html>
