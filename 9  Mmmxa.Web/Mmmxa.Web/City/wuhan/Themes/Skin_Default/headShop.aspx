<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    var nofind='<%=GetPageName.RetUrl("nofindsearch")%>';
</script>
<script type="text/javascript" language="javascript" src="/Main/JS/jquery-1.6.2.min.js"></script>
<script type="text/javascript" language="javascript" src="/Main/JS/headtop.js"></script>
<!--��ҳ�����л�JS-->
<!--������������ ��ʾ����-->
<script type="text/javascript">
        $(document).ready(function(){
  $("#FlowCate").mouseover(function(){$("#ThrCategory").show();$("#ThrCategory").focus();	  
  }).mouseout(function(){$("#ThrCategory").hide();  });	
  $("#ThrCategory").mouseover(function(){$("#ThrCategory").show(); }).mouseout(function(){ $("#ThrCategory").hide(); }); });
</script>
<!--head Start ͷ����ʼ-->
<input type="hidden" id="hidv" value="" />
<!--site Start-->
<div id="site">
    <!--site_nav Start-->
    <div id="site_nav">
        <div class="sn_bg">
            <div class=" sn_bg_right"></div>
        </div>
        <div class="sn_bd">
            <b class="sn_edge"></b>
            <shopnum1:welcomecontrol id="WelcomeControl" runat="server" />
        </div>
    </div>
    <!--//site_nav End-->
    
    <!--mallHome Start-->
    <div id="mallHome">
        <div id="header">
            <div class="headerCon">
                <!--ͷ��Logo Start-->
                <h1 id="mallLogo">
                    <ShopNum1:Logo ID="Logo" runat="server" SkinFilename="Logo.ascx"  />
                </h1>
                <!--//ͷ��Logo End-->
                <!--�����л�-->
                <div style="display: block; float: left; width: 180px; position:relative; z-index:22;">
                    <ShopNum1:ChangeCity ID="ChangeCity" runat="server" SkinFilename="ChangeCity.ascx"
                        ShowCount="30" />
                </div>
                <!--ͷ������ Start-->
                <div class="topsearch">
                    <div class="mallSearch" id="mallSearch">
                        <div class="switchover">
                            <ul>
                                <li><a id="hh1" class="cur" onclick="chang(1)">����</a> </li>
                                <li><a id="hh2" class="" onclick="chang(2)">����</a> </li>
                                <li><a id="hh3" class="" onclick="chang(3)">��Ѷ</a> </li>
                                <li><a id="hh4" class="" onclick="chang(4)">����</a> </li>
                            </ul>
                        </div>
                        <div class="FormBox">
                            <div class="mallSearch_input clearfix">
                                <label for="mq" style="visibility: visible;">
                                </label>
                                <input class="txtinput" type="text" name="textfield" onkeydown="KeyEnter(event)" id="textfield" maxlength="50" onkeyup="showHint(this.value)" accesskey="s"  autocomplete="off" autofocus="true" x-webkit-speech="" x-webkit-grammar="builtin:search"  />
                                <input id="ButtonSearch" type="button" class="search_buttom" onclick="javascript:searchgo(0,'')"
                                    value="" />
                            </div>
                        </div>
                        <div class="KeyWords clearfix">
                        <ShopNum1:KeyWords ID="keyWords" runat="server" SkinFilename="KeyWords.ascx"/>
                    </div>
                    </div>
                     <!--������ʾ-->
                    <div class="ll_all_search">
                        <ul class="ll_xiala">
                        </ul>
                        <ul class="checktag">
                        </ul>
                    </div>
                    <asp:hiddenfield id="HiddenSwitchType" runat="server" value="1" />
                    <!--��������-->
                    
                </div>
                <!--//ͷ������ End-->
                <div class="lmf_top_ad">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <div class="lmf_zs">
                                    <a href="/MerchantsIn.aspx">���̼���</a></div>
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

<!--������������ Start-->
<div class="ny_headcate">
    <div class="ThrCategory_fwr">
        <div id="FlowCate"></div>
        <div class="FlowCategory_main" id="ThrCategory">
            <shopnum1:productthreecategorydefault id="ProductThreeCategory11" runat="server"
                ShowOneCount="10" ShowTwoCount="1000" ShowThreeCount="1000"  skinfilename="ProductFwThreeCategory.ascx" />
        </div>
    </div>
</div>
<!--//������������ End-->

<!--MiddleNavigationControl Start �в�������ʼ-->
<shopnum1:middlenavigationcontrol id="MiddleNavigationControl" runat="server" />
<!--//MiddleNavigationControl End �в���������-->

<!--//head End ͷ������-->