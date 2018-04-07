<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="gmcg">
    <div class="chengcg">感谢您本次购物！您的订单已提交成功，请尽快付款。</div>
    <div class="chengtable">
        <table border="0" cellpadding="0" cellspacing="0" width="95%">
            <tr>
                <th>订单号</th>
                <th>店铺名称</th>
                <th>邮费</th>
                <th>应付总金额</th>
            </tr>
            <asp:Repeater ID="RepeaterOrder" runat="server">
                <ItemTemplate>
                    <tr style="display: none;">
                        <asp:Repeater ID="RepeaterOrderProduct" runat="server">
                            <ItemTemplate>
                            <%--    <%# ((DataRowView)Container.DataItem).Row["Name"]%>--%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelOrderNumber" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["OrderNumber"]%>'></asp:Label>
                        </td>
                        <td>
                            <%# ((DataRowView)Container.DataItem).Row["ShopName"]%>
                        </td>
                         <td>
                            <%# ((DataRowView)Container.DataItem).Row["DispatchPrice"]%>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenFieldOrderGuid" Value='<%# ((DataRowView)Container.DataItem).Row["guid"]%>'
                                runat="server" />
                            <asp:Label ID="LabelShouldPayPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ShouldPayPrice"]%>'></asp:Label>
                            <a href="javascript:location.reload();" style="color:Blue;">刷新</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div class="cgzhifubao clearfix">
            您选择的支付方式为：<b><asp:Label ID="LabelPaymentName" runat="server"></asp:Label></b>
            <div class="yingfue">
                <span style="margin-right: 20px;">您应付总额：<b>￥<asp:Label ID="LabelPayPrice" runat="server"></asp:Label></b></span>
                <div class=" yingfubtn">
                    <asp:Button ID="ButtonPay" runat="server" Text="" class="quzhifu" />
                    <asp:Button ID="Button1" runat="server" CssClass="backindex" PostBackUrl="~/Default.aspx" />
                </div>
            </div>
        </div>
        <div class="wenxin">
              <b>温馨提示：请尽快完成支付，祝您购物愉快！</b>
        </div>
    </div>
    <div class="clear"></div>
</div>
<asp:HiddenField ID="HiddenFieldPaymentGuid" Value='' runat="server" />
<asp:HiddenField ID="HiddenFieldProductNames" Value="" runat="server" />
<asp:HiddenField ID="HiddenFieldTradeID" Value="0" runat="server" />
<asp:Literal ID="LiteralPayMemLoginID" Visible="false" runat="server"></asp:Literal>
