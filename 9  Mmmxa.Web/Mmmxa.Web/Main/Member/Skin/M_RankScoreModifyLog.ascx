<%@ Control Language="C#" EnableViewState="false" %>
<div id="content">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    时间：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSRegDate1" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        class="ss_nrduan"></asp:TextBox>
                </td>
                <td class="line_spac">
                    -
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSRegDate2" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        class="ss_nrduan"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonGet" name="12" runat="server" Text="搜索" CssClass="chax btn_spc" />
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th width="20%" class="th_le">
                变更日期
            </th>
            <th width="20%">
                变更类型
            </th>
            <th width="10%">
                当前积分
            </th>
            <th width="10%">
                变更积分
            </th>
            <th width="10%">
                变更后积分
            </th>
            <th width="30%" class="th_ri">
                备注
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Date") %>
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_RankScoreModifyLog.Type(Eval("OperateType").ToString())%>
                    </td>
                    <td>
                        <%#Eval("CurrentScore") %>
                    </td>
                    <td>
                    <%# ShopNum1.AccountWebControl.A_AdPayDetailList.GetMoney(Eval("CurrentScore").ToString(), Eval("LastOperateScore").ToString(), Eval("OperateScore").ToString())%>
                    </td>
                    <td>
                        <%#Eval("LastOperateScore") %>
                    </td>
                    <td>
                        <%#Eval("Memo") %>
                    </td>
                </tr>
                <%if (RepeaterShow.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="6" style="height: 16px;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <% }%>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>

    <script type="text/javascript">
            <!--
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
            //-->
    </script>

</div>
