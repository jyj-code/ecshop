<%@ page language="C#" autoeventwireup="true" inherits="Admin_VideoComment_List"   CodeBehind="VideoComment_List.aspx.cs"      %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主站视频评论</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

    <script type='text/javascript' src='js/resolution-test.js'></script>

    
</head>
<body style="padding: 0; background-image: url(images/Bg_right.gif); background-repeat: repeat;">
    <form id="form1" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="主站视频评论"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                    <%--<td class="lmf_padding" align="right">
                            分站名称：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSubstationID" runat="server" AutoPostBack="true" Width="207px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>--%>
                        <td style="text-align: right;">
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="评论人："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSMemLoginID" runat="server" CssClass="tinput" Width="196"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="LabelSIsAudit0" runat="server" Text="审核状态："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSIsAudit" runat="server" CssClass="tselect" Width="224">
                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">审核通过</asp:ListItem>
                            <asp:ListItem Value="2">审核未通过</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            <asp:Label ID="LabelSIsAudit1" runat="server" Text="评论视频："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSVideoGuid" runat="server" CssClass="tinput" Width="196"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="LabelSSendTime" runat="server" Text="评论时间："></asp:Label>
                        </td>
                        <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td><asp:TextBox ID="TextBoxSSendTime1" runat="server" CssClass="tinput" Width="68"></asp:TextBox></td>
                        <td style="padding-left:4px; "><img id="imgCalendarSSendTime1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                height: 18px;" /></td>
                        <td><asp:RegularExpressionValidator ID="RegularExpressionValidatorSendTime1" runat="server"
                                ControlToValidate="TextBoxSSendTime1" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator></td>
                        <td><ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                EnableScriptLocalization="True">
                            </ShopNum1:ToolkitScriptManager></td>
                        <td><ShopNum1:CalendarExtender Format="yyyy-MM-dd" ID="CalendarExtender1" runat="server"
                                TargetControlID="TextBoxSSendTime1" PopupButtonID="imgCalendarSSendTime1" CssClass="ajax__calendar">
                            </ShopNum1:CalendarExtender></td>
                        <td class="lmf_px">-</td>
                        <td><asp:TextBox ID="TextBoxSSendTime2" runat="server" CssClass="tinput" Width="68"></asp:TextBox></td>
                        <td style="padding-left:4px;"><img id="imgCalendarSSendTime2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                height: 18px;" /></td>
                        <td><asp:RegularExpressionValidator ID="RegularExpressionValidatorSendTime2" runat="server"
                                ControlToValidate="TextBoxSSendTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator></td>
                        <td><asp:CompareValidator ID="CompareTextBoxSSendTime2" runat="server" ControlToValidate="TextBoxSSendTime2"
                                Display="Dynamic" ErrorMessage="结束时间必须大于开始时间" Operator="GreaterThan" Type="Date"
                                ControlToCompare="TextBoxSSendTime1"></asp:CompareValidator></td>
                        <td><ShopNum1:CalendarExtender Format="yyyy-MM-dd" ID="CalendarExtender2" runat="server"
                                TargetControlID="TextBoxSSendTime2" PopupButtonID="imgCalendarSSendTime2" CssClass="ajax__calendar">
                            </ShopNum1:CalendarExtender></td>
                        </tr>
                        </table>
                        </td>
                        <td><asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" /></td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="if(Page_ClientValidate()) return DeleteButton();return false;"
                                    CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonIsAudit1" runat="server" OnClick="ButtonIsAudit1_Click"
                                    OnClientClick="if(Page_ClientValidate()) return AuditButton();return false;"
                                    CausesValidation="False" CssClass="shtg lmf_btn"><span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonIsAudit0" runat="server" OnClick="ButtonIsAudit0_Click"
                                    OnClientClick="if(Page_ClientValidate()) return EditButton();return false;" CausesValidation="False"
                                    CssClass="shwtg lmf_btn"><span>审核未通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display:none;">
                                <asp:LinkButton ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick="if(Page_ClientValidate()) return EditButton();return false;"
                                    OnClick="ButtonReply_Click" CssClass="chakanpl lmf_btn"><span>查看评论</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" GridLines="Vertical" Style="margin-top: 15px;">
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
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="评论视频" DataField="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="CreateTime" HeaderText="评论时间" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="评论人" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeAudit(DataBinder.Eval(Container, "DataItem(IsAudit)","{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评论" SortExpression="IsAudit">
                        <ItemTemplate>
                            <span title='<%#Eval("Content")%>'>
                            <%#Eval("Content").ToString().Length > 26 ? Eval("Content").ToString().Substring(0, 26) : Eval("Content").ToString()%></span>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </cc1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_VideoComment_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="MemLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSVideoGuid" Name="VideoTitle" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListSIsAudit" Name="IsAudit" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxSSendTime1" Name="SendTime1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSSendTime2" Name="SendTime2" PropertyName="Text"
                Type="String" />
            <asp:Parameter DefaultValue="all" Name="SubstationID"   Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
