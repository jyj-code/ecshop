<%@ page language="C#" autoeventwireup="true" inherits="Admin_AdvancePaymentApplyLog_Operate"   CodeBehind="AdvancePaymentApplyLog_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>提款审核</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="充值审核"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label10" runat="server" Text="会员名："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <font class="font1">
                                <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label></font>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelCurrentAdvancePayment" runat="server" Text="当前预存款："></asp:Label>
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                            ￥<asp:Label ID="LabelCurrentAdvancePaymentValue" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelDate" runat="server" Text="操作日期："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelDateValue" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOperateType" runat="server" Text="操作类型："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelOperateTypeValue" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label3" runat="server" Text="充值方式："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelPaymentName" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOperateMoney" runat="server" Text="金  额："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            ￥<asp:Label ID="LabelOperateMoneyValue" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label1" runat="server" Text="开户银行名称："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="TextBox_Bank" runat="server"></asp:TextBox>
                                <span>开户银行名称</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label11" runat="server" Text="开户人真实姓名："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="TextBoxTrueName" runat="server" Enabled="false"></asp:TextBox>
                                <span>开户人真实姓名</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label12" runat="server" Text="个人银行账号："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="TextBoxAccount" runat="server" Enabled="false"></asp:TextBox>
                                <span>个人银行账号</span>
                            </div>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 150px;">
                            <asp:Label ID="LabelMemo" runat="server" Text="会员备注："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 150px;">
                            <asp:TextBox ID="TextBoxMemo" runat="server" Enabled="False" Height="100px" TextMode="MultiLine"
                                Width="500px" CssClass="tinput"></asp:TextBox>
                            <span>会员备注内容</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 150px;">
                            <asp:Label ID="LabelUserMemo" runat="server" Text="管理员备注："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 150px;">
                            <asp:TextBox ID="TextBoxUserMemo" runat="server" Height="100px" TextMode="MultiLine"
                                Width="500px" CssClass="tinput" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemo" runat="server"
                                ControlToValidate="TextBoxUserMemo" Display="Dynamic" ErrorMessage="备注最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            <span>管理员备注内容(输入字符不得大于50个)</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOperateStatus" runat="server" Text="到款状态："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListOperateStatus" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">未处理</asp:ListItem>
                                <asp:ListItem Value="1">已完成</asp:ListItem>
                                <asp:ListItem Value="2">拒绝申请</asp:ListItem>
                            </asp:DropDownList>
                            <span>到款状态</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <span style="color: Red">*&nbsp;&nbsp;提示：操作前请确保已完成订单流程，提交后状态不可修改！</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    Width="80px" CausesValidation="False" ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="ResetGoBack" runat="server" Text="返回列表"  CssClass="fanh" ValidationGroup="other"   onclick="ResetGoBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow0" runat="server" Visible="False" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldOperateTypeValue" runat="server" />
    </form>
</body>
</html>
