<%@ Control Language="C#" %>
<link href="Themes/Skin_Default/Style/shouyeindex.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .city_list li
    {
        display: block;
        float: left;
    }
    .hide_city_group .city_list ul li a
    {
        padding: 0 10px;
    }
    .hide_city_group .city_list
    {
        margin-left: 7px;
    }
    .hide_city_group .city_list
    {
        height: auto;
    }
    .hide_city_group .city_display
    {
        height: auto;
    }
    .hide_city_group
    {
        height: auto;
    }
    .city_more
    {
        text-align: right;
        padding-right: 10px;
    }
    .city_more a
    {
        color: #005ea7;
        font-size: 12px;
    }
    .hide_city_group .city_list ul li a{ white-space:nowrap;}

    .city_cut_text .lmf_sub_city
    {
        display: none;
    }
    .city_cut_text1 .lmf_sub_city
    {
        display: block;
    }
</style>
<script>
    function OnShow()
    {
        $("#Div1").show();
    }
    function OnHide()
    {
        $("#Div1").hide();
    }
</script>

<script>
$(function(){
    $(".city_cut_text").hover(
    
        function()
        {
            $(this).addClass("city_cut_text1");
        },
        function()
        {
            $(this).removeClass("city_cut_text1");
        }   
    )
});
</script>

<table cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<div class="city_cut_title" style="padding-top:0; position:relative;top:-5px;">
    <div class="city_cut_china" onmouseover="OnShow()" onmouseout="OnHide()" style="zoom: 1;">
        <asp:Label ID="LabelCity" runat="server" Text="全国站"></asp:Label></div>
    <div class="lmf_sub_city" style="margin-top: -55px; position: absolute;z-index:9000;">
        <div class="hide_city_group1" id="Div1" style="display: none;" onmouseover="OnShow()"
            onmouseout="OnHide()">
            <div class="chose_panel">
                <div class="in_box">
                    <div class="row1">
                        下级城市
                    </div>
                    <div class="arrow">
                    </div>
                </div>
            </div>
            <div class="city_display">
                <div class="city_list clearfix">
                    <div id="Div2">
                        <asp:Label ID="LabelIsEmtry" runat="server" Text="" Visible="false"></asp:Label>
                        <ul class="clearfix">
                            <asp:Repeater ID="RepeaterShowNextCity" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%#ShopNum1.WebControl.ChangeCity.GetSubHref(Eval("CityCode").ToString())%>'>
                                        <%#Eval("Name").ToString()%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</td>
<td>
<div class="city_cut_text" >
    <div class="lmf_city" style="height: 50px;">
        [ <a href="/SubstationCity.aspx">切换城市</a> ]
    </div>
    <div class="lmf_sub_city" style="margin-top: -55px; position:absolute;z-index:1000;">
        <div class="hide_city_group" id="JS_header_city_bar_box" style="display: block;">
            <div class="chose_panel">
                <div class="in_box">
                    <div class="row1">
                        <a class="site_all Left" runat="server" id="allUrl" runat="server">
                            【<asp:Label ID="LabelAllTotalCity" runat="server" Text="全国站"></asp:Label>】</a>
                    </div>
                    <div class="row2">
                        <span class="txt Left">热门城市：</span>
                    </div>
                    <div class="arrow">
                    </div>
                </div>
            </div>
            <div class="city_display">
                <div class="city_list clearfix">
                    <div id="JS_header_city_list">
                        <asp:Repeater ID="RepeaterShowCity" runat="server">
                            <HeaderTemplate>
                                <ul class="clearfix">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href='<%#ShopNum1.WebControl.ChangeCity.GetSubHref(Eval("CityCode").ToString())%>'>
                                    <%#Eval("Name").ToString().Replace("..",".")%></a></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="city_more"style="dispaly:none">
                        <a runat="server" id="MoreCity"></a></div>
                </div>
            </div>
        </div>
    </div>
</div>
</td>
</tr>
</table>
