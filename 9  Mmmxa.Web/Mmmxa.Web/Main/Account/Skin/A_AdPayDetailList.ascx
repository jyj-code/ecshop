<div id="list_main" class="list_main">
    <div id="Div1">
        <div id="content">
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            操作时间：
                        </td>
                        <td  >
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                           <td align="right" class="ss_nr_spac">
                            操作状态：
                        </td>
                        <td>
                            <select name="sel" size="1" class="tselect" id="sel_Type" runat="server">
                                <option value="-1">-全部-</option>
                                <option value="1">充值</option>
                                <option value="2">提现</option>
                                <option value="3">消费</option>
                                <option value="4">收入</option>
                                <option value="5">系统</option>
                                <option value="6">转账</option>
                            </select>
                        </td>
                        <td>
                              <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax" />
                        </td>
                    </tr>
                </table>
                <%--  操作类型--%>
                <input type="hidden" runat="server" id="hid_type" runat="server" value="-1" />
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top"
                style="margin-top: 10px;">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp;交易笔数：<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 变更金额： ￥<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayDetail" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        创建时间
                    </th>
                    <th>
                        变更前金额（元）
                    </th>
                    <th>
                        操作预存款（元）
                    </th>
                    <th>
                        变更后金额（元）
                    </th>
                    <th width="10%">
                        类型
                    </th>
                    <th>
                        备注
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayA_AdPayDetailList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td class="red">
                                <%# DataBinder.Eval(Container.DataItem, "CurrentAdvancePayment")%>
                            </td>
                            <td style="color: Red">
                                <%# ShopNum1.AccountWebControl.A_AdPayDetailList.GetMoney(Eval("CurrentAdvancePayment").ToString(),Eval("LastOperateMoney").ToString(),Eval("OperateMoney").ToString())%>
                            </td>
                            <td class="red">
                                <%# DataBinder.Eval(Container.DataItem, "LastOperateMoney")%>
                            </td>
                            <td>
                                <%# ShopNum1.AccountWebControl.A_AdPayDetailList.ChangeOperateType(Eval("OperateType").ToString())%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Memo")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (Rep_PayA_AdPayDetailList.Items.Count == 0)
          { %>
                <tfoot>
                    <tr>
                        <td colspan="6" style="height:86px;">
                            <div class="no_data">
                                暂无数据</div>
                        </td>
                    </tr>
                </tfoot>
                <% }%>
            </table>
            <!--分页-->
            <div class="fenye">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b">
                    <tr>
                        <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                            &nbsp;
                        </td>
                        <td style="border-left: none;">
                            <div id="pageDiv" runat="server" class="fy">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
 $(function (){
       $("#A_AdPayDetailList_ctl00_sel_Type").find("option[value='"+sel_Type+"']").attr("selected",true);
       $("#A_AdPayDetailList_ctl00_txt_StartTime").val(startTime);
       $("#A_AdPayDetailList_ctl00_txt_EndTime").val(endTime);
        $("#A_AdPayDetailList_ctl00_sel_Type").change(function (){
                var TypeValue=$("#A_AdPayDetailList_ctl00_sel_Type").find("option:selected").val();
             $("#A_AdPayDetailList_ctl00_hid_type").val(TypeValue);
        })
       $("#A_AdPayDetailList_ctl00_sel_Status").change(function (){
         var StatusValue=$("#A_AdPayDetailList_ctl00_sel_Status").find("option:selected").val();
         $("#A_AdPayDetailList_ctl00_hid_status").val(StatusValue);
       })
 })
</script>

