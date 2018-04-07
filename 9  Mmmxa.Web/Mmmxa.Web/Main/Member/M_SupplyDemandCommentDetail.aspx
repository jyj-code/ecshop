<%@ Page Language="C#" EnableViewState="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供求评论详细</title>
        <link rel='stylesheet' type='text/css' href='style/style.css' />
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
     <div class="tjsp_mian">
        <p class="ptitle">
            <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="M_Comment.aspx?type=0&pageid=1">供求评论</a><span
                class="breadcrume_icon">>></span><span class="breadcrume_text">我的供求评论详细</span></p>
        <ShopNum1:M_SupplyDemandCommentDetail ID="M_SupplyDemandCommentDetail" runat="server" SkinFilename="Skin/M_SupplyDemandCommentDetail.ascx"/>
        </div>
    </form>
</body>
</html>
