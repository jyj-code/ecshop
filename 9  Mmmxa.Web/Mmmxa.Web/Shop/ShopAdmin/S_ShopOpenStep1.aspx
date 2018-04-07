﻿<%@ Page Language="C#"  EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开店-步骤1</title>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="/Main/js/areas.js" type="text/javascript"></script>
    <script src="/Main/js/location.js" type="text/javascript"></script>
      <script type="text/javascript" language="javascript" > 
      window.onerror=function(){return true;};
$(function (){
      // 加载区域
    $("#p_local").LocationSelect();
})
</script>

<script type="text/javascript" language=   "javascript">
    function  checkSumbit()
    {
             //提交地区信息
             var info = $("#p_local").getLocation();
             if(info.pcode=="0")
             {
                 $("#p_local").next().show();
             }
             $("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val(info.province+","+info.city+","+info.district+"|"+info.pcode+","+info.ccode+","+info.dcode);
        
    }
</script>
   
<script type="text/javascript" language="javascript">
 $(document).ready(
 function (){
   var area=$("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val().split("|");
   if($("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_hid_Area").val()!="")
   {
            var areacode=area[1].split(",");
            var areaname=area[0].split(",");
            $("select[name='province']").append("<option value=\""+areacode[0]+"\" selected=\"selected\">"+areaname[0]+"</option>");
            $("select[name='city']").append("<option value=\""+areacode[1]+"\" selected=\"selected\">"+areaname[1]+"</option>");
            $("select[name='district']").append("<option value=\""+areacode[2]+"\" selected=\"selected\">"+areaname[2]+"</option>");
   }
 
 }
 );
</script>

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
    <ShopNum1ShopAdmin:S_ShopOpenStep1 ID="S_ShopOpenStep1" runat="server" SkinFilename="skin/S_ShopOpenStep1.ascx" />
    </form>
</body>
</html>