<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="ShopNum1.Common" %>

<%@ Register TagPrefix="skm" Namespace="ActionlessForm" Assembly="ActionlessForm" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
    <ShopNum1Shop:ShopMeto ID="ShopMeta" runat="server" SkinFilename="SetMeta.ascx" />
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
</head>
<body>
    <skm:Form ID="from1" runat="server" method="post">
        <!--head start-->
        <!-- #include file="AgentHead.aspx" -->
        <div id="content">
            <!-- #include file="head.aspx" -->
            <div class="warp clearfix">
                <!--main start-->
                <!--left is start-->
                <div>
                    <div class="sidebar leftn_hot">
                        <!--店铺信息-->
                        <ShopNum1Shop:ShopInfo ID="ShopInfo" runat="server" SkinFilename="ShopInfo.ascx" />
                        <!--商品搜索-->
                        <ShopNum1Shop:ProduceSearch ID="ProduceSearch" runat="server" SkinFilename="ProduceSearch.ascx" />
                        <!--商品分类-->
                        <ShopNum1Shop:ProductCategory ID="productCategory" runat="server" SkinFilename="ProductCategory.ascx" />
                        <!-- 宝贝排行-->
                        <div class="ks_panel">
                            <div class="storn_hd">
                                <h3>商品排行</h3>
                                <p class="gd_more"><a href="/ProductSearchList.html"></a></p>
                            </div>
                            <ul class="sellor">
                                <li id="a0" class="aa" onmouseover="tab('a','b',0,2,'aa','bb')">热销宝贝排行</li>
                                <li id="a1" class="bb" onmouseover="tab('a','b',1,2,'aa','bb')">热门收藏排行</li>
                            </ul>
                            <div class="ktlist">
                                <input type="hidden" id="hidShopId" value="<%=Request.QueryString["ShopID"]%>" />
                        	<script type="text/javascript" language="javascript" src="/main/js/shop1/ProductListOp.js"></script>
                       	 	<!--热销排行-->
                        	<div id="b0" style="display: block"></div>
                        	<!--收藏排行-->
                        	<div id="b1" style="display: none"></div>
                            </div>
                       </div>
                    </div>
                    <div class="main">
                        <div class="str_advt">
                            <ShopNum1Shop:Advertisements ID="topadvertisement" runat="server" SkinFilename="Advertisements.ascx" PageName="ProductListHot.aspx"/>
                        </div>
                        <!--商品列表-->
                        <ShopNum1ShopNew:ProductListIndexShowMore ID="ProductListIndexShowMore1" ShowCount="12" runat="server" SkinFilename="ProductListIndexShowMore.ascx" />
                                <!--猜你喜欢-->
                                <style type="text/css">
                                        #mylike #tipshow {
	                                        background-color: #B30C02;
	                                        position: relative;
	                                        height: 480px;
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
                               
                                <div id="mydiv" style="height:890px; display:none;" >
                                    <div id="mylike" style="position:absolute;background:#fff;min-height:200px;">
                                             <div id="tipshow"><span> － </span><span>猜你喜欢</span></div>
                                             <div id="loveright" style="border:1px dotted #B30C02;text-align:center;width:100px; height:100%;float:left;">
                                             </div>
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
                                                    $(this).find("span:eq(0)").html("－");$("#loveright").slideDown();
                                                }
                                                else
                                                {
                                                    bflag=true;
                                                    $(this).find("span:eq(0)").html("+");$("#loveright").slideUp();
                                                }
                                         });
                                  });
                                  function setLoveProductList(data)
                                  {
                                     var xhtml=new Array();
                                     xhtml.push('<div class="loveProduct">');
                                     xhtml.push('<div class="tjname"><a href="http://'+document.location.host+'/ProductDetail/'+data.guid+'.html">'+data.name+'</a></div>');
                                     xhtml.push('<div class="tjimga"><a href="http://'+document.location.host+'/ProductDetail/'+data.guid+'.html"><img alt="'+data.name+'" src="'+data.originalimage+'_60x60.jpg"></a><p>￥'+data.shopprice+'</p></div>');
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
                                                ad.style.top=posY+200+"px";
                                                ad.style.right=posX+"px";
                                  }
                                </script>
                                <!--猜你喜欢-->
                    </div>
                </div>
            </div>
        </div>
        <!--foot start-->
        <!-- #include file="foot.aspx" -->
        <!--end-->
    </skm:Form>
</body>
</html>