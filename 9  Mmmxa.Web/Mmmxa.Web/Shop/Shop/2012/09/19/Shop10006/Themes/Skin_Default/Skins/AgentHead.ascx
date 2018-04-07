<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<link href="/Main/Themes/Skin_Default/Style/indexshop.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript">
var sitedomain='<%=ShopUrlOperate.GetSiteDomain() %>';
</script>
<script type="text/javascript">
   $(function(){
    $(".cademon").hover(function(){
        $(this).addClass("tosiris");
        },function(){
        $(this).removeClass("tosiris");
        })
    $("#nav .nav_cs li").eq(0).css("margin-left","0")    
    });
    </script>
    <script type="text/javascript">
    $(function(){
//    document.title=$(".shopkper").text()+"  "+document.title;
//var defaultOpts = { interval: 5000, fadeInTime: 300, fadeOutTime: 200 };
//Iterate over the current set of matched elements
	
//	var _titles_bg = $("ul.op li");
//	var _bodies = $("ul.slide-pic li");
	
//	var _current = 0;
//	var _intervalID = null;
//	var stop = function() { window.clearInterval(_intervalID); };
//	var slide = function(opts) {
//		if (opts) {
//			_current = opts.current || 0;
//		} else {
//			_current = (_current >= (_count - 1)) ? 0 : (++_current);
//		};
//		_bodies.filter(":visible").fadeOut(defaultOpts.fadeOutTime, function() {
//			_bodies.eq(_current).fadeIn(defaultOpts.fadeInTime);
//			_bodies.removeClass("cur").eq(_current).addClass("cur");
//		});
//		_titles.removeClass("cur").eq(_current).addClass("cur");
//		_titles_bg.removeClass("cur").eq(_current).addClass("cur");
//	}; //endof slide
//		
//	var go = function() {
//		stop();
//		_intervalID = window.setInterval(function() { slide(); }, defaultOpts.interval);
//	}; //endof go
//	var itemMouseOver = function(target, items) {
//		stop();
//		var i = $.inArray(target, items);
//		slide({ current: i });
//	}; //endof itemMouseOver
//	_titles.hover(function() { if($(this).attr('class')!='cur'){itemMouseOver(this, _titles); }else{stop();}}, go);

//	//_titles_bg.hover(function() { itemMouseOver(this, _titles_bg); }, go);
//	_bodies.hover(stop, go);
//	//trigger the slidebox
//			go();		
	var _titles = $("div.suibian>ul>li");
	var _count = _titles.length;
    var target = $('ul.slide-pic').children();
    var ctrl = $('ul.op').children();
    var text_ctrl = $('ul.slide-txt').children();
        						 
    $("a.np1").click(function(){
    var index = $("ul.op li.cur").prev().index();
    target.eq(index).addClass('cur').fadeIn(800);
    target.eq(index + 1).removeClass('cur').fadeOut(200);
    ctrl.removeClass('cur');
    ctrl.eq(index).addClass('cur');
    text_ctrl.removeClass('cur');
    text_ctrl.eq(index).addClass('cur');    
    });

    $("a.np2").click(function(){
    var index = $("ul.op li.cur").next().index();
    var length = $("ul.op li.cur").index();
    if( _count == length + 1 ){
    target.eq(0).addClass('cur').fadeIn(800);
    target.eq(_count).removeClass('cur').fadeOut(200);
    ctrl.removeClass('cur');
    ctrl.eq(0).addClass('cur');
    text_ctrl.removeClass('cur');
    text_ctrl.eq(0).addClass('cur');   
    }else{
    target.eq(index).addClass('cur').fadeIn(800);
    target.eq(index - 1).removeClass('cur').fadeOut(200);
    ctrl.removeClass('cur');
    ctrl.eq(index).addClass('cur');
    text_ctrl.removeClass('cur');
    text_ctrl.eq(index).addClass('cur');
    }
      
    });
function Marquee(){
  $("a.np2").click();
                    }
var MyMar=setInterval(Marquee,5000)
$("a.np1").mouseover(function(){clearInterval(MyMar);});
$("a.np1").mouseout(function(){MyMar=setInterval(Marquee,5000);});
$("a.np2").mouseover(function(){clearInterval(MyMar);});
$("a.np2").mouseout(function(){MyMar=setInterval(Marquee,5000);});

})
    </script>
    
        
    <script type="text/javascript">
        function tab(selfid,targetid,index,count,selfclass,otherclass) {
            for(var i=0;i<count;i++) {
                if(i == index) {
                    document.getElementById(selfid + i).className = selfclass;
                    document.getElementById(targetid + i).style.display = "block";
                }
                else {
                    document.getElementById(selfid + i).className = otherclass;
                    document.getElementById(targetid + i).style.display = "none";
                }
            }
        }
    </script>    
    
<script type="text/javascript" language="javascript" src="/main/js/shop1/head.js"></script>
<script type="text/javascript">
//<![CDATA[
var theForm = document.forms[0];
if (!theForm) {
    theForm = document.form1;
}
function RedirectCart(eventTarget) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.secondEVENTTARGET.value = eventTarget;
        theForm.submit();
    }
}
//]]>
</script>
<div id="site_nav">
    <div class="sn_bg">
        <div class="sn_bg_right"></div>
    </div>
    <div class="warp sn_bd">
        <b class="sn_edge"></b>
        <div class="sn_container">
            <div class="sn_login_info">
                <div id="islogin" runat="server">
                    欢迎光临！<asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>，您可以登录<a href="http://<%=ShopSettings.siteDomain %>/main/member/m_index.aspx">【个人中心】</a>      <a href="http://<%=ShopSettings.siteDomain %>/main/loginOut.aspx">【退出】</a>
                </div>
                <span id="unlogin" runat="server">
                    <span class="sog">欢迎光临！请<a href='<%= ShopUrlOperate.GetShopLoginGoBack() %>'>登录</a></span>
                    <span><a href='<%= AgentHead.SetUrl("MemberRegister") %>' class="register">免费注册</a></span>
                </span>
            </div>
            <ul class="sn_quick_menu">
		        <li class="sn_mytaobao menu_item">
                    <div class="menu_hd menu_fh">
                        <a href='<%= ShopUrlOperate.RetUrl("default") %>'"><s></s>返回首页</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div class="menu_hd">
                        <a href="javascript:void(0)" onclick="addFav()">添加收藏</a>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item">
                      <div class="menu_hd">
                        <a href='<%= ShopUrlOperate.RetUrl("HelpListIndex") %>'>帮助中心</a></div>
                </li>
                <li class="sn_mytaobao menu_item">
                    <div id="headtest2" class="menu_hd menu_hd1 ie6top">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的商城</a>
                        <div class="wdsc fl">
                            <!--已经退出状态-->
                            <div class="sub_wdsc" runat="server" visible="true" id="loginTwo">
                                <div class="qdl" style="display:none;">
                                    您好，请登录！
                                    <a class="btn_login" href='<%= ShopUrlOperate.RetUrl("Login") %>'>
                                        <img src="Themes/Skin_Default/Images/lmf_denglu.jpg" /></a>
                                    <a class="btn_register" href='<%= ShopUrlOperate.RetUrl("MemberRegister") %>'>
                                        <img src="Themes/Skin_Default/Images/lmf_zhuce.jpg" /></a>
                                </div>
                                <div class="qd_bg">
                                    <div class="cldd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_OrderList.aspx'>待处理订单</a></div>
                                    <div class="zxhf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=MemberProductCommentList.aspx'>咨询回复</a></div>
                                    <div class="wddd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=OrderList.aspx'>我的订单</a></div>
                                    <div class="wdjf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurls=ChangeScoreModifyLog.aspx'>我的积分</a></div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                            <!--已经登录状态-->
                            <div runat="server" visible="true" id="loginOutTwo" class="lambert_sub">
                                <div class="qdl2" style="display:none;">
                                    您好，<a class="memberName" href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>'>
                                        <asp:Label ID="LabelMemLoginIDTwo" runat="server" /></a>，欢迎来到本商城！
                                    <a href="loginOut.aspx" style="display: none">退出</a>
                                </div>
                                <div class="qd_bg">
                                    <div class="cldd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_OrderList.aspx'>待处理订单</a></div>
                                    <div class="zxhf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_OrderList.aspx'>我的订单</a></div>
                                    <div class="wddd">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_MyMessageBoard.aspx'>咨询回复</a></div>
                                    <div class="wdjf">
                                        <a href='<%= ShopUrlOperate.RetMemberUrl("m_index") %>?tomurl=M_CreditDetails.aspx'>我的积分</a></div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="sn_mytaobao menu_item" style="background: none;">
                    <div id="headtest3" class="menu_hd menu_hd2 ie6top">
                        <a href='<%= ShopUrlOperate.RetUrl("Login") %>'>我的购物车</a>
                        <div class="wdgwc fr">
                            <div class="sub_wdsc1">
                                <a class="cartenet" href="<%= ShopUrlOperate.RetUrl("ShoppingCart1") %>">
                                    <div class="qdl1" id="shopcart1" runat="server">
                                        购物车中还没有商品，赶紧选购吧！
                                    </div>
                                    <div id="shopcart2" class="qdl1" runat="server">
                                        购物车共<asp:Literal ID="LiteralCartCount" runat="server" Text="0"></asp:Literal><span>件商品</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
<div id="mallHome">
    <div id="header">
        <div class="warp headerCon">
            <h1 id="mallLogo">
            <asp:Image ID="ImageShopLogo" runat="server" />
            </h1> <div class="cademon">
            <ShopNum1Shop:ShopInfo ID="ShopInfos" runat="server" SkinFilename="ShopInfos.ascx" />
            </div>         
            <div class="mallSearch" id="mallSearch">
                <ShopNum1Shop:TopSearch ID="TopSearch" runat="server" SkinFilename="AgentAllSearch.ascx" />
            </div>
        </div>
    </div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
</div>
