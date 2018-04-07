<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"%>
<%@ Register TagPrefix="ShopNum1" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if lt IE 7]> <html class="ie6 oldie" lang="en"> <![endif]-->
<!--[if IE 7]>    <html class="ie7 oldie" lang="en"> <![endif]-->
<!--[if IE 8]>    <html class="ie8 oldie" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-black.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/qzoom.css' />
    <ShopNum1Shop:ShopProductDetailMeto ID="ShopProductDetailMeto" runat="server" SkinFilename="ShopProductDetailMeto.ascx" />
</head>
<body>
    <ShopNum1:Form ID="Form1" method="post" runat="server">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--left is start-->
                <div class="sidebar leftn_hot">
                    <!--店铺信息-->
                    <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                    <!--图片-->
                    <ShopNum1Shop:ShopCollect ID="ShopCollect" runat="server" SkinFilename="ShopCollect.ascx" />
                    <!--店内搜索-->
                    <ShopNum1Shop:ProduceSearch ID="ProduceSearch1" runat="server" SkinFilename="ProduceSearch.ascx" />
                    <!--商品分类-->
                    <ShopNum1Shop:ProductCategory ID="ProductCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                    <!-- 宝贝排行-->
                    <div class="ks_panel">
                        <div class="storn_hd">
                            <h3>商品排行</h3>
                            <p class="gd_more"><a href="/ProductSearchList.html">更多>></a></p>
                        </div>
                        <ul class="sellor">
                            <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')">热销宝贝排行</li>
                            <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')">热门收藏排行</li>
                        </ul>
                        <div class="ktlist">
                            <!--热销排行-->
                            <div id="b0" style="display: block">                                
                                <ShopNum1Shop:ProductListSaleRanking ID="ProductListSaleRanking" runat="server" SkinFilename="ProductListSaleRanking.ascx"
                                    ShowCount="10" />
                            </div>
                            <!--收藏排行-->
                            <div id="b1" style="display: none">
                                <ShopNum1Shop:ProductListCollectRanking ID="ProductListCollectRanking" runat="server"
                                    SkinFilename="ProductListCollectRanking.ascx" ShowCount="10" />
                            </div>
                        </div>
                   </div>
                </div>
                <!--main start-->
                <div class="main">
                <!--商品详细-->
                <ShopNum1Shop:ProductDetail ID="ProductDetail" runat="server" SkinFilename="ProductDetail.ascx" />
                <!-- tab 切换 -->
                <div class="tab_qh">
                    <ul>
                        <!-- 注意这里是点了以后的样式,恢复后的就是默认的请看样式看tab_qh ul li -->
                        <li id="current1" class="selected"><a onclick="changeTab(4,1);">商品详细</a></li>
                        <li id="current2"><a onclick="changeTab(4,2);">商品评论</a></li>
                        <li id="current3"><a onclick="changeTab(4,3);">订单记录</a></li>
                        <li id="current4"><a onclick="changeTab(4,4);">在线留言</a></li>
                        <li style="width:130px;padding-top:5px;"><a class="bshareDiv" style="display:inline-block" href="http://www.bshare.cn/share">分享按钮</a><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#uuid=9ee7b05f-76fc-433d-ac79-2f2fb72f4622&amp;style=1&amp;bp=qqmb,bsharesync,sinaminiblog,qzone,189share,sohuminiblog,renren,xinhuamb,tianya,shouji,ifengmb,neteasemb,qqxiaoyou,kaixin001,weixin,douban,qqim"></script></li>
                    </ul>
                </div>
                <div class="content tab_con" id="content1" style="display: block;">
                    <!--商品详细-->
                    <div class="aBox11 clearfix">
                        <div class="content">
                            <ShopNum1ShopNew:ProductProp_V82 ID="ProductProp_V82" runat="server" SkinFilename="ProductProp_V82.ascx" />
                            <div id="tx2">
                                <ShopNum1Shop:ProductCommentList ID="ProductCommentList" Type="1" runat="server"
                                    SkinFilename="ProductCommentList.ascx" PageCount="1" />
                            </div>
                            <div id="tx3">
                                    <div class="aBox11 clearfix">
                                        <div class="content">
                                            <div class="RecordNum">
                                                <span id="spanOrderCount" runat="server"></span>
                                            </div>
                                            <table cellpadding="0" cellspacing="1" width="100%" class="OrderRecord_th">
                                                <tr class="MemberTr">
                                                    <td align="left" width="20%">买家</td>
                                                    <td align=" left" width="30%">宝贝名称</td>
                                                    <td align="left" width="10%">出价</td>
                                                    <td align="left" width="10%">购买数量</td>
                                                    <td align="left" width="20%">付款时间</td>
                                                    <td align="left" width="10%" style="display:none;">状态</td>
                                                </tr>
                                            </table>
                                    </div>
                                </div>
                                <div id="showorderlist"></div>
                            </div>
                            <div id="tx4">
                                   <div class="amatera"><h2><span>留言信息</span></h2></div>
                                    <div class="dwarfe" id="MessageBoxList"></div>
                                    <div class="clearfix"></div>
                                    <!--分页预留方法-->
                                    <div class="clearfix"></div>
                                <div id="MessageBarod" class="amatera">
                                        <h2><span>在线留言</span></h2>
                                    <div  class="dwarfe">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="5">
                                            <tr>
                                                <td align="right" width="15%" valign="middle">
                                                    留言内容：
                                                </td>
                                                <td width="85%">
                                                    <textarea name="txtContent" class="allinput1 allinputon" style="width: 450px; height: 60px;"></textarea>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td><input type="button" id="btnConfirm" class="fl bnt1 commentSubmit" value="确定" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <input type="hidden" id="hidProductGuID" value="<%=Request.QueryString["guid"] %>" />
            <div class="clear"></div> 
                                <!--猜你喜欢-->
                                <style type="text/css">
                                    /*看了还看*/
.RelatedPro{float:right;width:160px;}
.RelatedPro .layer1{height: 50px;line-height: 50px;overflow: hidden; padding-top:20px; position: relative;}
.RelatedPro .layer1 s{border-top: 1px dotted #C9C9C9;height: 0;left: 0;position: absolute;text-decoration: none;top: 46px;width: 100%;}
.RelatedPro .layer1 span{ background-color: #fff;color: #999999;left: 50%;margin-left: -3em;position: absolute;text-align: center;top: 20px;width: 6em;}
.RelatedPro .layer2{width:100px; height:390px; overflow:hidden; position:relative;}
.RelatedPro .layer2 ul{width:100px; overflow:hidden; position:relative;}
.RelatedPro .layer2 ul li{width:100px; height:130px; overflow:hidden;}
.RelatedPro .layer2 ul li a{width:100px; height:100px;overflow:hidden;display: table-cell;text-align:center; vertical-align:middle;*display: block; *font-size:87px; *font-family:Arial;}
.RelatedPro .layer2 ul li a img{ vertical-align:middle;width:100px;height:100px;}
.RelatedPro .layer2 ul li p{ height:20px; line-height:20px; overflow:hidden;}
.RelatedPro .layer2 ul li p span{color:#D10C13;}
.RelatedPro .layer3{height:25px; text-align:center;}
.RelatedPro .layer3 a{ display:inline-block;width:25px; height:25px; margin-left:10px;}
.RelatedPro .layer3 a.prev{background:url(../images/prev.jpg) no-repeat;}
.RelatedPro .layer3 a.next{background:url(../images/next.jpg) no-repeat;}
                                    
                                        #mylike #tipshow {
	                                        background-color: #B30C02;
	                                        position: relative;
	                                        height: 520px;
	                                        width: 20px;
	                                        color: #FFFFFF;
	                                        text-align: center;
	                                        float: left;
	                                        top:0px;
                                        }
                                        #mylike #tipshow span{float:left; text-align:center; width:20px;}
                                        .loveProduct{border-bottom: 1px dashed #DDDDDD; margin-bottom:3px;}
                                        .tjname{ height: 36px;line-height: 18px;overflow: hidden;}
                                        .tjimga{overflow: hidden; position: relative;}
                                        .tjimga p{ background: none repeat scroll 0 0 #CC0000;bottom:1px; color: #FFFFFF; display: block; font-size: 10px; height: 15px; left: 5px;line-height: 15px; position: absolute; width:100%;}
                                </style>
                               
                                <div id="mydiv" style="height:890px; display:none;">
                                    <div id="mylike" style="position:absolute;background:#fff;min-height:200px;">
                                             <div id="tipshow"><span style="cursor:pointer;"> － </span><span>猜你喜欢</span></div>
                                             <div id="loveright" style="border:1px dotted #B30C02;text-align:center;width:110px; height:100%;float:left;"></div>
                                    </div>
                                </div>
                                
                                <script type="text/javascript" language="javascript">
                                  $(function(){
                                        loadScrollLike();loadLoveProduct();
                                         $(window).scroll(function (){ 
                                               loadScrollLike();
                                         });
                                         var bflag=false;
                                         $("#tipshow").click(function(){
                                                if(bflag)
                                                {   
                                                    bflag=false;
                                                    $(this).find("span:eq(0)").html("－");$("#loveright").show();
                                                }
                                                else
                                                {
                                                    bflag=true;
                                                    $(this).find("span:eq(0)").html("+");$("#loveright").hide("slow");
                                                }
                                         });
                                  });
                                  function setLoveProductList(data)
                                  {
                                     var xhtml=new Array();
                                     xhtml.push('<div class="loveProduct">');
                                     xhtml.push('<div class="tjimga"><a href="http://'+document.location.host+'/ProductDetail/'+data.guid+'.html" title="'+data.name+'"><img alt="'+data.name+'" src="'+data.originalimage+'_100x100.jpg"/></a><p>￥'+data.shopprice+'</p></div>');
                                     xhtml.push('</div>');
                                     return xhtml.join("");
                                  }
                                  function loadLoveProduct()
                                  {
                                       $.get("/Api/Shop/showloveproduct.ashx?guid="+$("#hidProductGuID").val()+"&shopid="+$("#hidShopId").val(),null,function(data){
                                                if(data!="")
                                                {
                                                    var NewHtml=new Array();
                                                    var vdata=eval('('+data+')');
                                                    $.each(vdata,function(m,n){
                                                          NewHtml.push(setLoveProductList(n));
                                                    });
                                                    $("#loveright").html(NewHtml.join(""));
                                                }
                                       });
                                  }
                                  function loadScrollLike()
                                  {
                                        var posX,posY;
                                                if (window.innerHeight) {
                                                    posX = window.pageXOffset;
                                                    posY = window.pageYOffset;
                                                }
                                                else if (document.documentElement && document.documentElement.scrollTop) {
                                                    posX = document.documentElement.scrollLeft;
                                                    posY = document.documentElement.scrollTop;
                                                }
                                                else if (document.body) {
                                                    posX = document.body.scrollLeft;
                                                    posY = document.body.scrollTop;
                                                }
                                                var ad=document.getElementById("mylike");
                                                ad.style.top=posY+30+"px";
                                                ad.style.right=posX+"px";
                                  }
                                </script>
                                <!--猜你喜欢-->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content tab_con" id="content2">
                    <!--商品评论-->
                </div>
                <div class="content tab_con" id="content3">
                    <!--订单记录-->
                </div>
                <div class="content  tab_con" id="content4">
                    <!-- 在线留言 -->
                            <div  class="clearfix ProductComment">
                                在线留言</div>
                            <div class="MessageBox">
                                <table width="100%" border="0" cellpadding="0" cellspacing="5">
                                    <tr>
                                        <td align="right" width="15%" valign="middle">
                                            留言内容：
                                        </td>
                                        <td width="85%">
                                            <textarea name="txtContent" class="allinput1 allinputon" style="width: 450px; height: 60px;"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td><input type="button" id="Button1" class="fl bnt1 commentSubmit" value="确定" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                </div>
             </div>
            </div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </ShopNum1:Form>
    <!--js-->
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/zoom.js"></script> 
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/ShopDetail.js"></script>   
</body>
</html>
