<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="bBox bBoxnt" style="margin-bottom:20px;">
    <h2>
        <span style="float: left;">视频列表</span> <span style="float: right; margin-right: 10px;
            display: inline; font-size: 12px; font-weight: normal; width: 288px; *_padding-top: -1px;
            _padding-top: 3px; display: none;">视频关键字：<asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox><asp:Button
                ID="ButtonSearch" runat="server" Text="" CssClass="search_btn" Style="margin-top: 0px;
                margin-top: 4px\9; *margin-top: 0px; _margin-top: 0px; float: auto; float: right\9;
                _float: auto; *float: auto;" /></span>
    </h2>
    <div class="content" style="float: left; clear: both; border:none; padding:0px;">
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <div class="fquency">
                    <div class="filmes">
                        <a href='<%# GetPageName.RetUrl("VideoDetail",Eval("Guid"))%>'>
                            <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("ImgAdd")%>' onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" /></a>
                    </div>
                    <p class="voide_name">
                        <a href='<%# GetPageName.RetUrl("VideoDetail",Eval("Guid"))%>'>
                            <%# Eval("Title")%></a>
                    </p>
                    <%--<p class="method">
                        播放次数200000</p>--%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!-- 分页部分-->
    <div style="clear: both;">
    </div>
    <div style="border: #cccccc 1px solid; height: 25px; line-height: 25px; text-align: right;
        margin-top: 10px; display:none;">
        <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
        &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
        &nbsp;<span class="fpager">转到
            <asp:Literal ID="lnkTo" runat="server" />
            页</span>
    </div>
</div>
<div class="turn_page">
    <ul>
        <li><a class="curn" href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><a
            href="#">5</a><a class="pluto">...</a><a class="nextpg" href="#">下一页</a><span class="total">共15页</span>
        </li>
        <li class="ont"><span class="fl">到第</span><input type="text" class="txt_word fl" name="textnum" id="textnum" /><span class="fl">页</span><input
            type="button" class="tex_butn fl" id="uidconfire" name="uidconfire" />
        </li>
    </ul>
</div>
