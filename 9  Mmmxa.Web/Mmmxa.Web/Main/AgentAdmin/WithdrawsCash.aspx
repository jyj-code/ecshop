<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_WithdrawsCash, ShopNum1.Deploy" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="GroupFly" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我要提现</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <style type="text/css">
        .shopth
        {
            margin: 0;
            margin-top: 1px;
        }
        .shoptd
        {
            margin: 0;
            margin-top: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTtitle" runat="server" Text="我要提现"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable" width="100%">
                    <tr>
                        <th align="right" width="150px">
                            <div class="shopth">
                                当前可提现金额：
                            </div>
                        </th>
                        <td valign="middle">
                            <div class="shoptd" style="color:#cc0000; font-weight:bold">
                                ￥<asp:Label ID="LabelMoney" runat="server" Text="0.00"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                提现金额：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <span style="color:#cc0000; font-weight:bold">￥</span><asp:TextBox ID="TextBoxMoney" runat="server"  CssClass="tinput" MaxLength="10" Width="100" Font-Size="13"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                提现方式：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:DropDownList ID="DropDownListOperateType" runat="server" AutoPostBack="true" CssClass="tselect"  OnSelectedIndexChanged="DropDownListOperateType_SelectedIndexChanged">
                                            <asp:ListItem Value="-1" Text="-请选择-"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="线下打款"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="网银在线"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="支付宝"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="财付通"></asp:ListItem>
                                            </asp:DropDownList><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelOne" runat="server" Visible="true">
                   <tr>
                        <th align="right">
                            <div class="shopth">
                                收款人账号：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxAccount" runat="server"  CssClass="tinput" MaxLength="50"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelOther" runat="server" Visible="false">
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                收款人姓名：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxRealName" runat="server"  CssClass="tinput" MaxLength="50"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                收款银行名称：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxBank" runat="server"  CssClass="tinput" MaxLength="50"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                收款人银行账号：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxConfirmBankID" runat="server"  CssClass="tinput" MaxLength="50"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    </asp:Panel>
                    
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                登录密码：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxPayPwd" runat="server"  CssClass="tinput" TextMode="Password"></asp:TextBox><span style="color:#cc0000;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" class="shopth">
                            <div>
                                备注：
                            </div>
                        </th>
                        <td>
                            <div>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxRemark" runat="server"  CssClass="tinput" MaxLength="50" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="sbtn" style="margin-left: 150px;">
                    <asp:Button ID="ButtonAdd" runat="server" Text="确定" CssClass="dele" OnClick="ButtonAdd_Click" />
                    <input type="reset" class="dele" value="重置" />
                    <GroupFly:MessageShow ID="MessageShow" Visible="false" runat="server" />
                       <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
