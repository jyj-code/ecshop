<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace=" System.Data" %>

<link href="/Main/Themes/Skin_Default/Style/tipswindows.css" rel="stylesheet" type="text/css" />
<script src="/Main/js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script src="/Main/js/tipswindown.js" type="text/javascript"></script>
<script language="javascript">
//弹出窗体
function showTipsWindown(title, id, width, height) {
    tipsWindown(title, "iframe:" +id, width, height, "true", "", "true", "");
}
function popTips() {
    showTipsWindown("系统退出", '/Main/loginOut.aspx' , 320, 105);
}
</script>
<!--头部Top-->
<div id="top">
    <!--登录-->
    <div class="fl_left">
        您好！<strong class="red"><asp:Label ID="LabelMemberID" runat="server" Text=""></asp:Label></strong> 
        [<span style="color: #005ea7;"> <a href="/Main/loginOut.aspx">退出</a><asp:LinkButton ID="ButtonOut" runat="server" Text="退出" Visible="false"></asp:LinkButton></span>]
    </div>
    <div class="top_list">
                <div class="top_mer fl">
                    <a target="_blank"  href='http://<%=ShopSettings.siteDomain  %>' class="top_a1">商城首页</a></div>
                <div class="top_hert allsort fl">
                    <a href="#" class="top_a">我的商城</a>
                    <div class="sub_customer">
                        <a  href="/main/member/m_index.aspx?tomurl=M_OrderList.aspx" class="lo1">购买的商品</a>
                        <a  href="/shop/ShopAdmin/s_index.aspx?tosurl=S_Order_List.aspx" class="lo2">卖出的商品</a> 
                    </div>
                </div>
                <div class="top_mer fl">
                    <a target="_blank" href="/main/MerchantsIn.aspx" class="top_a1">招商加盟</a></div>
                <div class="top_help fl">
                    <a target="_blank" href="/Main/HelpList.aspx?guid=326267b3-354f-47c7-b3fe-196498cadeab" class="top_a1">帮助中心</a></div>
            </div>
</div>
<div style="clear: both;">
</div>
<div id="top2">
    <!--会员中心Logo-->
    <div style="float: left;">
        <a target="_blank" href='http://<%=ShopSettings.siteDomain  %>'>
                    <asp:Image ID="ImageShopLogo" runat="server"  Width="329" Height="72"/></a>
    </div>
    <!--搜索Search-->
    <div class="lmf_searchs">
        <div class="lmf_search">
            <div class="lmf_search_text">
                <input name="tex1" type="text" value="请输入商品名称!" onfocus="this.value=''" onblur="if(!value){value=defaultValue;}"
                    class="lmf_nr" /></div>
            <div class="lmf_search_btn">
                <a href="#">
                    <input name="btn" type="button" class="lmf_btnss" value="搜索" /></a></div>
        </div>
    </div>
</div>
<div style="clear: both;">
</div>
<div id="nav_bg">
    <div id="nav">
        <!--菜单项nav-->
        <ul style="float: left;">
            <li><a href="/main/Member/m_index.aspx">我是买家</a></li>
            <li><a href="/shop/ShopAdmin/s_index.aspx">我是卖家</a></li>
            <li><a href="/main/account/A_Index.aspx" class="zh">账户管理</a></li>
        </ul>
        <!--消息提醒-->
      <%--  <div class="xiaoxi">
            消息提醒：您有( <span style="font-size: 14px; color: #ff6600; font-family: Arial;">0</span>
            )封未读信息......
        </div>--%>
          <div class="xiaoxi">
                     <a href="/main/member/m_index.aspx?tomurl=M_SysMsg.aspx?isread=0&pageid=1">
                    消息提醒：您有( <span style="font-size: 14px; color: #ff6600; font-family: Arial;">
                    <asp:Label ID="LabelMsg" runat="server" Text="0"></asp:Label></span>
                    )封未读系统信息......
                    </a>
                </div>
          <div id="gwc">
                    <a href="/Main/ShoppingCart1.aspx" target="_blank">
                    购物车 <span class="red">
                    <asp:Label ID="LabelGouWuChe" runat="server" Text="0"></asp:Label>
                    </span> 件</a>
                </div>
    </div>
</div>
<div style="clear: both;">
</div>
   <script type="text/javascript" language="javascript">
        $(function(){
        //处理搜索方法
               $(".lmf_btnss").click(function(){
                     if($(".lmf_nr").val()=="请输入商品名称!"){alert("请输入商品名称!");return false;}
                     location.href="/Search_productlist.html?search="+escape($(".lmf_nr").val());
               });
        });
        </script>