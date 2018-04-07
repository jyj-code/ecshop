<%@ Page Language="C#" EnableViewState="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>我是买家</title>
       <link rel='stylesheet' type='text/css' href='style/m.css' />
        <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
       <script type="text/javascript" language="javascript" src="js/M_Index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="containe_bg">
        <ShopNum1:M_Head ID="M_Head" runat="server"  SkinFilename="Skin/M_Head.ascx" />
        <!--内容部分Content-->
        <div id="content_bg">
            <div id="content1">
                <div id="content2">
                    <!--左边导航nav-->
                     <ShopNum1:M_Left ID="M_Left" runat="server" SkinFilename="Skin/M_Left.ascx" />
                    <!--右边框架-->
                    <div class="ifr_right">
                     <%string strURL = string.Empty;
                      if (Page.Request.QueryString["tomurl"] != null)
                      {
                          strURL = Server.UrlDecode(Page.Request.QueryString["tomurl"].ToString());
                      }
                      else {
                          strURL ="M_Welcome.aspx";
                      }
                 %>
                        <iframe width="100%" frameborder="0" height="100%"  allowTransparency="true" id="mainFrame"
                            name="win" src='<%=strURL %>' scrolling="no"></iframe>
                    </div>
                </div>
            </div>
        </div>
         <!--底部文件调用--> 
         <!-- #include file="m_bottom.aspx" -->
          <!--底部文件调用--> 
    </div>
    </form>
</body>
</html>
