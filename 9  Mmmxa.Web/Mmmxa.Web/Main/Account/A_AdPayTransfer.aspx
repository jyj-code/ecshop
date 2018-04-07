<%@ Page Language="C#"  EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>财务管理-预存款转账</title>
  <link rel='stylesheet' type='text/css' href='style/style.css' />
  <script src="js/jquery.pack.js" type="text/javascript"></script>
  <script type="text/javascript" src="js/SpryTabbedPanels.js"></script>
  <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
  
</head>
<body>
<div class="dpsc_mian">
     <p class="ptitle">
      <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">预存款转账</span></p>
  <form runat="server" id="fromA_AdPayTiXian">
       <ShopNum1Account:A_AdPayTransfer    ID="A_AdPayTransfer" runat="server" SkinFilename="Skin/A_AdPayTransfer.ascx"  PageSize="10" /> 
  </form>
</div>
<script type="text/javascript" language="javascript">
      // 判断是否是数字
        function checknum(str)
        {
            var re = /^[0-9]+.?[0-9]*$/; 
            if (!re.test(str))
            {
                alert("请输入正确的数字！");
                return false;
            }else{return true;}
        }
         //跳转到制定的页码
         function ontoPage(txtId)
         { var pageindex=$(o).parent().parent().prev().prev().find("input").val();
           if(checknum(pageindex))
           {
                location.href='?sort=<%=Common.ReqStr("sort")%>&StartTime=<%=Common.ReqStr("StartTime")%>&EndTime=<%=Common.ReqStr("EndTime")%>&type=1&pageid='+pageindex;
           }
                 
         }
  </script>
</body>
</html>