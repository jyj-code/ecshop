<asp:Repeater ID="Rep_AoccountDetail" runat="server">
    <ItemTemplate>
        <div class="myzh">
            <div class="myzh_right">
                <div class="pxian">
                    欢迎！<span class="redht">
                        <%# DataBinder.Eval(Container.DataItem, "MemLoginID")%></span></div>
                <div style="padding-top: 10px;">
                    积分：<strong class="red"><%# DataBinder.Eval(Container.DataItem, "Score")%></strong>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                账户余额：<span class="redbold">￥<%# DataBinder.Eval(Container.DataItem, "AdvancePayment")%></span>
                            </td>
                            <td>
                                <input name="12" type="button" class="chax" value="充值" onclick="window.location.href='A_AdPayRecharge.aspx'" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                冻结预存款：<span class="redbold">￥<%# DataBinder.Eval(Container.DataItem, "LockAdvancePayment")%></span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
        <div class="tixq">
            <div class="ptitle2">
                买家提醒区：</div>
            <dl class="maij">
                <dt>买到的商品：</dt>
                <dd>
                    在最近30天内，您的购买订单<span class="red"><%# DataBinder.Eval(Container.DataItem, "buyOrder")%></span>个商品，请到
                    <a target="_parent" href="/main/member/m_index.aspx?tomurl=m_orderlist.aspx" onclick="subItem(this)"
                        class="lmf_act" style="color: #ff6600;">已买商品</a> 查看 。</dd>
            </dl>
            <div class="ptitle2">
                卖家提醒区：</div>
            <dl class="maij">
                <dt>卖出的商品：</dt>
                <dd>
                    在最近30天内，您的出售订单有<span class="red"><%# DataBinder.Eval(Container.DataItem, "shopOrder")%></span>个，请到
                    <a target="_parent" href="/shop/shopadmin/s_index.aspx?tosurl=s_order_list.aspx"
                        onclick="subItem(this)" class="lmf_act" style="color: #ff6600;">已卖商品</a> 查看。</dd>
            </dl>
        </div>
    </ItemTemplate>
</asp:Repeater>
