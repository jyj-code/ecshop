<%@ Page Language="C#" EnableViewState="false"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>前台导航栏</title>
       <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
         <link rel='stylesheet' type='text/css' href='style/style.css' />
       <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
</head>
<body>
    <form id="form1" runat="server">
          <div class="dpsc_mian">
           <p class="ptitle" ><a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">前台导航栏</span></p>
           <ShopNum1ShopAdmin:S_UserDefinedColumnList  ID="S_UserDefinedColumnList" runat="server" SkinFilename="skin/S_UserDefinedColumnList.ascx"  PageSize="10" />
         </div>
    </form>
    <script type="text/javascript" language="javascript">
           //跳转到制定的页码
        function ontoPage(o)
        {
           var pageindex=$(o).parent().parent().prev().prev().find("input").val();
           if(checknum(pageindex))
           {
                var pageEnd=parseInt($(" page_2 b:eq(0)").text());
                if(pageEnd<=pageindex)
                    pageindex=pageEnd;
               location.href='?isread=<%= Common.ReqStr("isread") %>&pageid='+pageindex;
           }
       }
       
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
  </script>
</body>
</html>
