<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

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
    <link type="text/css" rel="Stylesheet" href='Themes/Skin_Default/Style/index-red.css' />
    <link href="/Main/Themes/Skin_Default/Style/indexshop1.css" rel="stylesheet" type="text/css" />
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
                        <h3>
                            商品排行</h3>
                      <p class="gd_more" style="display:none;"><a href="/ProductSearchList.html"></a></p>
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
                                   <div class="clearfix ProductComment">留言信息</div>
                                    <div class="MessageBox" id="MessageBoxList"></div>
                                    <div class="clearfix"></div>
                                    <!--分页预留方法-->
                                    <div class="clearfix"></div>
                                <div id="MessageBarod">
                                    <div id="ProductComment" class="clearfix ProductComment">
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
                                                <td><input type="button" id="btnConfirm" class="fl commentSubmit" value="确定" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <input type="hidden" id="hidProductGuID" value="<%=Request.QueryString["guid"] %>" />
                                <script type="text/javascript" language="javascript">
                                       
                                </script>
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
                                        <td><input type="button" id="Button1" class="fl commentSubmit" value="确定" />
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
    <%-- </ShopNum1:Form>--%>
    </ShopNum1:Form>
    <!--js-->

    <script type="text/javascript" language="javascript" src="/Main/js/shop1/zoom.js"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.4"></script>
<script type="text/javascript" language="javascript" src="/Main/js/shop1/ProductListOp.js"></script>
    <script type="text/javascript" language="javascript" src="/Main/js/shop1/ShopDetail.js"></script>

</body>
</html>
