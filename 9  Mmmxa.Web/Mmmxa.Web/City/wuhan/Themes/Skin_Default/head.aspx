<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    var nofind='<%=GetPageName.RetUrl("nofindsearch")%>';
</script>
<script type="text/javascript" language="javascript" src="/Main/JS/jquery-1.6.2.min.js"></script>
<script type="text/javascript" language="javascript" src="/Main/JS/headtop.js"></script>
<!--head Start 头部开始-->
<input type="hidden" id="hidv" value="" />
<!--site Start-->
<div id="site" >
    <!--site_nav Start-->
    <div id="site_nav">
        <div class="sn_bg">
            <div class="sn_bg_right"></div>
        </div>
        <div class="sn_bd">
            <b class="sn_edge"></b>
            <ShopNum1:WelcomeControl ID="WelcomeControl" runat="server" />
        </div>
    </div>
    <!--//site_nav End-->
    
    <!--mallHome Start-->
    <div id="mallHome">
        <div id="header">
            <div class="headerCon" >
                <!--头部Logo Start-->
                <h1 id="mallLogo">
                    <ShopNum1:Logo ID="Logo" runat="server" SkinFilename="Logo.ascx" />
                </h1>
                <!--//头部Logo End-->
                <!--城市切换-->
                <div style="display: block; float: left; width: 180px; position:relative; z-index:22;">
                    <ShopNum1:ChangeCity ID="ChangeCity" runat="server" SkinFilename="ChangeCity.ascx"
                        ShowCount="30" />
                </div>
                <!--头部搜索 Start-->
                <div class="topsearch">
                    <div class="mallSearch" id="mallSearch" >
                        <div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">宝贝</a></li>
                                <li><a id="hh2" class="" onclick="chang(2)">店铺</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">资讯</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">供求</a> </li>
                            </ul>
                        </div>
                        <div class="FormBox">
                            <div class="mallSearch_input clearfix">
                                <label for="mq"></label>
                                <input class="txtinput" type="text" name="textfield" onkeydown="KeyEnter(event)" id="textfield" maxlength="50" onkeyup="showHint(this.value)"  accesskey="s"  autocomplete="off" autofocus="true" x-webkit-speech="" x-webkit-grammar="builtin:search" />
                                <input id="ButtonSearch" type="button" class="search_buttom" onclick="javascript:searchgo(0,'')"
                                    value="" />
                            </div>
                        </div>
                        <div class="KeyWords clearfix">
                        <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx"/>
                    </div>
                    </div>
                     <!--搜索提示-->
                    <div class="ll_all_search">
                        <ul class="ll_xiala">
                        </ul>
                        <ul class="checktag">
                        </ul>
                    </div>
                    <asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
                    <!--热门搜索-->
                    
                </div>
                <!--//头部搜索 End-->
                <div class="lmf_top_ad">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <div class="lmf_zs">
                                    <a href="/MerchantsIn.aspx">招商加盟</a></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!--//mallHome End-->
</div>
<!--//site End-->

<!--MiddleNavigationControl Start 中部导航开始-->
<ShopNum1:MiddleNavigationControl ID="MiddleNavigationControl" runat="server" />
<!--//MiddleNavigationControl End 中部导航结束-->

<!--//head End 头部结束-->

<!--[if lte IE 6]>
<script src="Themes/Skin_Default/Js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
        DD_belatedPNG.fix('div, ul, img, li, input , a, *');
    </script>
<![endif]-->
