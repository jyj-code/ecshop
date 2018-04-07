<%@ Page Language="C#" EnableViewState="true"%>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>财务管理-预存款详细</title>
  <link rel='stylesheet' type='text/css' href='style/style.css' />
  <script src="js/jquery.pack.js" type="text/javascript"></script>
  <script src="/JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
  <script src="js/areas.js" type="text/javascript"></script>
   
</head>
<body>
<div class="dpsc_mian">
  <p class="ptitle">
      <a href="A_Welcome.aspx">账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">预存款明细</span></p>
 
  <form runat="server" id="fromA_AdPayDetail">
       <ShopNum1Account:A_AdPayDetailList    ID="A_AdPayDetailList" runat="server" SkinFilename="Skin/A_AdPayDetailList.ascx"   PageSize="10" /> 
  </form>
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
        //页面跳转
        function ontoPage(o)
        {
           var pageindex=$(o).parent().parent().prev().prev().find("input").val();
           if(checknum(pageindex))
           {
                var pageEnd=parseInt($(".page_2 b:eq(0)").text());
                if(pageEnd<=pageindex)
                    pageindex=pageEnd;
                location.href='A_AdPayDetailList.aspx?sort=<%=Common.ReqStr("sort")%>&StartTime=<%=Common.ReqStr("StartTime")%>&EndTime=<%=Common.ReqStr("EndTime")%>&PayType=<%=Common.ReqStr("PayType")%>&type=1&pageid='+pageindex;
           }
        }
        var sel_Type='<%=Request.QueryString["PayType"]%>';
        var startTime='<%=Request.QueryString["StartTime"]%>';
        var endTime='<%=Request.QueryString["EndTime"]%>';
  </script>
  
</div>
</body>