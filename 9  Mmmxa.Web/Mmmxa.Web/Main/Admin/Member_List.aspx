<%@ page language="C#" autoeventwireup="true" inherits="Admin_Member_List"   CodeBehind="Member_List.aspx.cs"      %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="GroupFly" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

    <script type='text/javascript' src='js/resolution-test.js'></script>

    <script src="/Main/js/location.js" type="text/javascript"></script>

    <script src="/Main/js/areas.js" type="text/javascript"></script>

</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    会员列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelSRealName" runat="server" Text="会员姓名："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSRealName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="Area" runat="server" Text="地区："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListRegionCode1_SelectedIndexChanged"
                                Width="90">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListRegionCode2_SelectedIndexChanged"
                                Width="90">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" Width="90" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelSEmail" runat="server" Text="电子邮件："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSEmail" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none">
                            <asp:Label ID="Label3" runat="server" Text="会员等级："></asp:Label>
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListMemberRank" runat="server" Width="207px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelMemberType" runat="server" Text="会员类型："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListMemberType" runat="server" Width="207px" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">个人会员</asp:ListItem>
                                <asp:ListItem Value="2">店铺会员</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            手机号码：
                        </td>
                        <td>
                            <asp:TextBox ID="TextMobile" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px; display: none;">
                        <td align="right">
                            <asp:Label ID="LabelSSex" runat="server" Text="性别："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSex" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="0">男</asp:ListItem>
                                <asp:ListItem Value="1">女</asp:ListItem>
                                <asp:ListItem Value="2">保密</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="85" style="text-align: right; padding-right: 5px;">
                            <asp:Label ID="LabelCreditMoney" runat="server" Text="会员信用额度："></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TextBoxCreditMoney" runat="server" CssClass="tinput" Width="190"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            <asp:Label ID="LabelSIsForbid" runat="server" Text="禁用状态："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropdownListSIsForbid" runat="server" Width="207px" CssClass="tselect">
                                <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">已禁用</asp:ListItem>
                                <asp:ListItem Value="0">已启用</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" class="lmf_padding">
                            <asp:Label ID="LabelSRegDate" runat="server" Text="注册日期："></asp:Label>
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxSRegDate1" runat="server" CssClass="tinput" Style="width: 68px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                            ControlToValidate="TextBoxSRegDate1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 3px;" />
                                    </td>
                                    <td>
                                        <GroupFly:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSRegDate1"
                                            PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </GroupFly:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxSRegDate2" runat="server" CssClass="tinput" Style="width: 68px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                            ControlToValidate="TextBoxSRegDate2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 3px;" />
                                    </td>
                                    <td>
                                        <GroupFly:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSRegDate2"
                                            PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </GroupFly:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                            CssClass="dele" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAddMember" runat="server" CausesValidation="False" CssClass="tianjiafl lmf_btn"
                                    OnClick="ButtonAddMember_Click"><span>添加会员</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonAddShop" runat="server" CssClass="shezhidp lmf_btn" CausesValidation="false"
                                    OnClick="ButtonAddShop_Click" OnClientClick=" return EditButton()"><span>设置店铺</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonCheck" OnClientClick=" return EditButton()" runat="server"
                                    CssClass="dele" CausesValidation="false" OnClick="ButtonCheck_Click" Visible="false"><span>编辑</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                                    CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonIsForbid" runat="server" OnClientClick="return EditButton()"
                                    CssClass="qiyong lmf_btn" OnClick="ButtonIsForbid_Click"><span>启用</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonNoForbid" runat="server" OnClientClick="return EditButton()"
                                    CssClass="jnyong lmf_btn" OnClick="ButtonNoForbid_Click"><span>禁用</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonAdvancePaymentModifyLog" runat="server" OnClick="ButtonAdvancePaymentModifyLog_Click"
                                    OnClientClick="return EditButton()" CssClass="biangeng lmf_btn"><span>变更预存款</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonAdvancePaymentFreezeLog" runat="server" OnClick="ButtonAdvancePaymentFreezeLog_Click"
                                    OnClientClick="return EditButton()" CssClass="dongjie1 lmf_btn"><span>冻结/解冻预存款</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="LinkBtnSetScore" runat="server" OnClick="LinkBtnSetScore_Click" 
                                    OnClientClick="return EditButton()" CssClass="dongjie lmf_btn"><span>赠送积分</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <GroupFly:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" ShowHeader="False" />
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="会员姓名" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="会员等级" SortExpression="MemberType">
                        <ItemTemplate>
                            <%# GetMemberRank(Eval("MemberRankGuid").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="个人/店铺" SortExpression="MemberType">
                        <ItemTemplate>
                            <asp:Label ID="LabelMemberType" runat="server" Text='<%# ChangeType(Eval("MemberType")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所在地区" SortExpression="AddressValue">
                        <ItemTemplate>
                            <asp:Label ID="LabelAddressValue" runat="server" Text='<%# GetAdress(Eval("AddressValue"),"") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="电子邮件" DataField="Email" SortExpression="Email">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="手机号码" DataField="Mobile" SortExpression="Mobile">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="推荐会员" DataField="PromotionMemLoginID" SortExpression="PromotionMemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AdvancePayment" HeaderText="当前预存款" SortExpression="AdvancePayment">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="启用状态" SortExpression="IsForbid">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsForbid" runat="server" src='<%#PageOperator.GetListImageStatus(Eval("IsForbid").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%#"MemberInfo_Operate.aspx?guid="+"'"+Eval("Guid")+"'"%>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid")%>'
                                OnClientClick="return window.confirm('您确定要删除吗?');" OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                            <a href="<%#"MemberInfo_SendMsg.aspx?guid="+"'"+Eval("Guid")+"'"%>" style="color: #4482b4;">
                                通知</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </cc1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search1"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="memLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSRealName" Name="name" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSEmail" Name="email" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSRegDate1" Name="regDate1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSRegDate2" Name="regDate2" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListSex" Name="sex" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropdownListSIsForbid" Name="isForbid" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="HiddenFieldRegionCode" Name="AreaCode" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListMemberType" Name="MemberType" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListMemberRank" Name="MemberRank" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxCreditMoney" Name="CreditMoney" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextMobile" Name="Mobile" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionValue" runat="server" Value="-1" />
    </form>
</body>
</html>
