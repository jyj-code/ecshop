﻿<%@ Import Namespace="ShopNum1.Common" %>
<div class="biaogenr">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                <tr>
                    <th colspan="2" scope="col">
                        投诉详细
                    </th>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="text-align:right;padding-right:5px;">
                        会员投诉信息：
                    </td>
                    <td style="padding: 0; border-right: none; border-bottom: none;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="text-align:right;padding-right:5px;">
                                    投诉商家的ID号：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ID") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    订单编号：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("OrderID") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    投诉类型：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ComplaintType") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    投诉证据：
                                </td>
                                <td style="padding-top: 8px;" class="bordrig">
                                    <%#Eval("Evidence") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    投诉证据图片：
                                </td>
                                <td class="bordrig">
                                    <asp:Image ID="ImageUrl" ImageUrl='<%#Eval("EvidenceImage") %>' runat="server" Width="100"
                                        Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="text-align:right;padding-right:5px;">
                        店铺申诉信息：
                    </td>
                    <td style="padding: 0; border-right: none; border-bottom: none;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="text-align:right;padding-right:5px;">
                                    是否申诉：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("IsAppeal").ToString()=="1"?"已申诉":"未申诉" %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    申诉内容：
                                </td>
                                <td class="bordrig">
                                    <textarea id="txtContent" style="width:460px;border:0px;"> <%#Eval("AppealContent") %></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    申诉图片：
                                </td>
                                <td class="bordrig">
                                    <asp:Image ID="ImageProductImage" runat="server" ImageUrl='<%#Eval("AppealImage") %>'
                                        Width="100" Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    申诉时间：
                                </td>
                                <td class="bordrig" style="padding-top: 8px;">
                                    <%#Eval("AppealTime") %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="text-align:right;padding-right:5px;">
                        平台处理信息：
                    </td>
                    <td style="padding: 0; border-right: none; border-bottom: none;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="text-align:right;padding-right:5px;">
                                    处理状态：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ProcessingStatus").ToString()=="0"?"未处理":"已处理" %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    处理结果：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ProcessingResults") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    处理时间：
                                </td>
                                <td class="bordrig" style="padding-top: 8px;">
                                    <%#Eval("ProcessingTime") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:5px;">
                                    处理人：
                                </td>
                                <td class="bordrig" style="padding-top: 8px;">
                                    <%#Eval("OperateUser") %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="op_btn">
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
