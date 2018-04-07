<%@ Page Language="C#" EnableViewState="false" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账户管理-账户安全设置</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>

    <script src="js/jquery.pack.js" type="text/javascript"></script>

</head>
<body>
    <div class="dpsc_mian">
        <p class="ptitle">
            <span style="float: left; color: #666666; display: block;"><a href="A_Welcome.aspx">
                账户管理</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">收货地址列表</span>
            </span><span class="spanrig"><a href="A_AddressOpeater.aspx" class="tianjiafl lmf_btn">
                &nbsp;&nbsp;&nbsp;添加地址</a></span>
            <form id="fromAddress" runat="server">
            <ShopNum1Account:A_ShipAddress ID="A_ShipAddress" runat="server" SkinFilename="Skin/A_ShipAddress.ascx"
                PageSize="5" />
            </form>
    </div>
</body>
</html>

<script type="text/javascript" language="javascript">
         
              //跳转到制定的页码
        function ontoPage(o)
        {
           var pageindex=$(o).parent().parent().prev().prev().find("input").val();
           if(checknum(pageindex))
           {
                var pageEnd=parseInt($(".spanfy page_2 b:eq(0)").text());
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

