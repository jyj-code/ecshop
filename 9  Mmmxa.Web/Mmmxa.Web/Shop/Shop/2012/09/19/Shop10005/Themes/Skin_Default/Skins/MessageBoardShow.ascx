<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="bBox bBoxnt">
    <div class="alltins">
        <h2>
            <div class="alltson">
                <asp:LinkButton ID="LinkButtonAll" runat="server" CausesValidation="false">网友留言 </asp:LinkButton></div>
            <div class="alosltn">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="alofour">
                            <div id="div1" runat="server">
                                <asp:LinkButton ID="LinkButton0" runat="server" CausesValidation="false">售后 </asp:LinkButton>
                            </div>
                        </td>
                         <td class="alofour">
                            <div id="div2" runat="server">
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false">询问</asp:LinkButton>
                            </div>
                        </td>
                         <td class="alofour">
                            <div id="div3" runat="server">
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false">一般消息</asp:LinkButton>
                            </div>
                        </td>
                         <td class="alofour">
                            <div id="div4" runat="server">
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false">求购</asp:LinkButton>
                            </div>
                        </td>
                         <td class="alofour">
                            <div id="div5" runat="server">
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false">留言</asp:LinkButton>
                            </div>
                        </td>
                         <td class="alofour">
                            <div id="div6" runat="server">
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false">重要消息</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </h2>
    </div>
    <div class="content guestext" style="border: none;">
        <asp:Repeater ID="RepeaterBoardList" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">
                            <b style="color: #b10b02">【<%# MessageBoardShow.GetValue(Eval("MessageType"))%>】</b>
                            留言人：<%# Eval("MemberName")%>
                        </div>
                        <div class="desc_date fr">
                            <%# Eval("SendTime")%></div>
                    </div>
                    <div class="desc_list_pl">
                        <div class="glyhf" style="background: none;">
                            <%--【留言标题】：<%# Eval("Title")%><br />--%>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 26px; vertical-align: top;">
                                        <p class="reply">
                                            <img src="Themes/Skin_Default/Images/quest.png" /></p>
                                    </td>
                                    <td>
                                        <p class="revert">
                                            <%# Eval("Content")%></p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="glyhf">
                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td style="width: 82px; vertical-align: top;">
                                        <p class="merchant">
                                            商家回复：<%--<%# Eval("ReplyTime")%>--%>
                                        </p>
                                    </td>
                                    <td>
                                        <p class="mercont">
                                            <%# Eval("ReplyContent")%></p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!-- 分页部分-->
<div class="pager" style="display: none;">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
<div class="turn_page" style="margin-bottom: 20px;">
    <ul>
        <li><a class="curn" href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><a
            href="#">5</a><a class="pluto">...</a><a class="nextpg" href="#">下一页</a><span class="total">共15页</span>
        </li>
        <li class="ont"><span class="fl">到第</span><input type="text" class="txt_word fl" name="textnum" id="textnum" /><span class="fl">页</span><input
            type="button" class="tex_butn fl" id="uidconfire" name="uidconfire" />
        </li>
    </ul>
</div>
