<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" %>

<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href="Themes/Skin_Default/Style/index-black.css" />
    <ShopNum1Shop:ProductIsSpellMeta ID="ProductIsSpellMeta" runat="server" SkinFilename="SetMeta.ascx" />
    <link href="/Main/Themes/Skin_Default/Style/indexshop.css" rel="stylesheet" type="text/css" />   
    <link type="text/css" rel="Stylesheet" href="Themes/Skin_Default/Style/jqzoom.css" />

    <script type="text/javascript">

function show_date_time(time, element){
window.setTimeout("show_date_time('"+time+"','"+element+"')", 1000);     
//AJAX获取服务器数据
//因程序执行耗费时间,所以时间并不十分准确,误差大约在2000毫秒以下
var xmlHttp = false;
//获取服务器时间
try {xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");} catch (e) {
try {xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");} catch (e2) {xmlHttp = false;}
}
if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
    xmlHttp = new XMLHttpRequest();
}
xmlHttp.open("GET", "/Api/newtime.txt?date="+(-new Date), false);
xmlHttp.setRequestHeader("Range", "bytes=-1");
xmlHttp.send(null);
var severtime = new Date(xmlHttp.getResponseHeader("Date"));//服务器时间
        BirthDay = new Date(time);
        today=new Date(severtime); 
timeold=(BirthDay.getTime()-today.getTime()); 
sectimeold=timeold/1000 
secondsold=Math.floor(sectimeold); 
msPerDay=24*60*60*1000 
e_daysold=timeold/msPerDay 
daysold=Math.floor(e_daysold); 
e_hrsold=(e_daysold-daysold)*24; 
hrsold=Math.floor(e_hrsold); 
e_minsold=(e_hrsold-hrsold)*60; 
minsold=Math.floor((e_hrsold-hrsold)*60); 
seconds=Math.floor((e_minsold-minsold)*60);  
  if(daysold<0)
    {
     document.getElementById(element).innerHTML="0天0小时0分0秒";
    } else{
document.getElementById(element).innerHTML=daysold+"天"+hrsold+"小时"+minsold+"分"+seconds+"秒" ;
}
}


function Sethtml(n)
{
    var xhtml=new Array();
    xhtml.push(' <div class="CommentListBox">');
    xhtml.push('                <div class="MemberPhoto fl">');
    xhtml.push('                    <p><img src="'+n.pic+'" /></p>');
    xhtml.push('                    <p>'+n.memloginid+'</p>');
    xhtml.push('                    <p>'+opPY(n.commenttype)+'</p>');
    xhtml.push('                </div>');
    xhtml.push('                <div class="fl">');
    xhtml.push('                    <p>content</p>');
    xhtml.push('                    <p class="grey">'+n.commenttime+' '+n.specvalue+'</p>');
    if(n.reply!=""){
            xhtml.push('                    <div class="ReplyBg">');
            xhtml.push('                        <i></i>');
            xhtml.push('                         <div class="ShoperRe">');
            xhtml.push('                            <div class="fl">');
            xhtml.push('                                <p><b>【掌柜解释】</b></p>');
            xhtml.push('                                <p class="time">'+n.replytime+'</p>');
            xhtml.push('                            </div>');
            xhtml.push('                            <div class="fl">'+n.reply+'</div>');
            xhtml.push('                            <div class="clear"></div>');
            xhtml.push('                        </div>');
            if(n.continuecomment!=""){
                    xhtml.push('                       <div class="AddComment">');
                    xhtml.push('                            <div class="fl">');
                    xhtml.push('                                <p><b>【追加评论】</b></p>');
                    xhtml.push('                                <p class="time">'+n.continuetime+'</p>');
                    xhtml.push('                            </div>');
                    xhtml.push('                            <div class="fl">'+n.continuecomment+'</div>');
                    xhtml.push('                            <div class="clear"></div>');
                    xhtml.push('                        </div>');
                    xhtml.push('                    </div>');
            }
    }
    xhtml.push('                </div>');
    xhtml.push('                <div class="clear"></div>');
    xhtml.push('            </div>');
    return xhtml.join("");
}
    </script>

</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
    <!--head start-->
    <!-- #include file="AgentHead.aspx" -->
    <div id="content">
        <!-- #include file="head.aspx" -->
        <div class="warp clearfix">
            <!--left is start-->
            <div class="spell_left">
                <!--拼购商品列表-->
                <ShopNum1ShopNew:ProductIsSpellDetail ID="ProductIsSpellDetail" runat="server" SkinFilename="ProductIsSpellDetailNew.ascx" />
                
                <!--商品评论-->
                <div class="bBox Cbox">
                    <div class="tuan-title bBoxnt">
                        <h2><span>商品评价</span></h2>
                    </div>
                    <ShopNum1Shop:ProductCommentList ID="ProductCommentList" Type="2" runat="server" SkinFilename="ProductCommentList.ascx" PageCount="1" />
                   <%-- <div class="MemberDiscuss clearfix">
                        <div class="ComScore">
                            <table width="100%">
                                <tr>
                                    <td class="title" width="100">宝贝与描述相符</td>
                                    <td class="count">
                                        <img id="c1" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c2" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c3" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c4" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <img id="c5" src="Themes/Skin_Default/Images/icon_star_2.gif" />
                                        <span>55</span>分
                                    </td>
                                    <td width="100">共有<b>100</b>条评论</td>
                                </tr>
                            </table>
                        </div>
                        <div class="flower">
                            <table width="100%">
                                <tr>
                                    <td><input type="radio" />全部</td>
                                    <td><input type="radio" /><img src="Themes/Skin_Default/Images/gds_dp.png" />好评(333)</td>
                                    <td><input type="radio" /><img src="Themes/Skin_Default/Images/gds_dp1.png" />中评(333)</td>
                                    <td><input type="radio" /><img src="Themes/Skin_Default/Images/gds_dp2.png" />差评(333)</td>
                                    <td><input type="radio" />追加评论(333)</td>
                                </tr>
                            </table>
                        </div>
                        <div class="CommentListBox">
                        <center><img src="Themes/Skin_Default/Images/loading.gif" /></center>
                            <div class="MemberPhoto fl">
                                <p><img src="Themes/Skin_Default/Images/touxiang.jpg" /></p>
                                <p>小明</p>
                                <p><img src="Themes/Skin_Default/Images/gds_dp.png" />好评</p>
                            </div>
                            <div class="fl">
                                <p>sdafsfsdafdsda</p>
                                <p class="grey">2013-8-23 颜色分类：黑色 尺码：L</p>
                                <div class="ReplyBg">
                                    <i></i>
                                    <div class="ShoperRe">
                                        <div class="fl">
                                            <p><b>【掌柜解释】</b></p>
                                            <p class="time">2013-8-23</p>
                                        </div>
                                        <div class="fl">谢谢亲的好评</div>
                                        <div class="clear"></div>
                                    </div>
                                    <div class="AddComment">
                                        <div class="fl">
                                            <p><b>【追加评论】</b></p>
                                            <p class="time">2013-8-23</p>
                                        </div>
                                        <div class="fl">客服心心的服务很满意 有问必答</div>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div class="spell_right">
              <!--本期热门团购-->
                <ShopNum1ShopNew:ProductIsPanicDetailNow ID="ProductIsSpellDetail2" runat="server"
                    ShowCount="2" SkinFilename="ProductIsPanicDetailNow.ascx" />
                      <!--往期热门团购-->
                <ShopNum1ShopNew:ProductIsPanicDetailAgo ID="ProductIsSpellDetail1" runat="server"
                  ShowCount="3"   SkinFilename="ProductIsPanicDetailAgo.ascx" />
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <!--foot start-->
    <!-- #include file="foot.aspx" -->
    <!--end-->
   </ShopNum1:Form>
    <!--js-->
</body>
</html>
