<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_ImageCategory_List, ShopNum1.Deploy" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片分类管理</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />
</head>
<body style="height:600px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabeTitle" runat="server" Text="图片分类管理"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="table1" style="margin-bottom: 20px;">
              <div class="btnlist btnadd">
                <div class=" fl">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                            <a href='ImageCategory_Operate.aspx?width=700&height=450' class="tianjiafl lmf_btn dialog"><span>添加分类</span></a>
                                                      </td>
                            <td valign="top" class="lmf_app">
                            </td>
                            <td valign="top" class="lmf_app" style="display:none;">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClick="ButtonDelete_Click"
                                    OnClientClick="return DeleteButton()" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">(默认分类不可删除)
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
             <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" colspan="2">
                    <cc1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False" ascendingimageurl="~/images/SortAsc.gif" 
                        descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                        Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                        PagingStyle="None" TableName=""  AllowMultiColumnSorting="False"
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0"
                        CellPadding="4" GridLines="Vertical" Style="margin-top: 15px;" AllowPaging="true" OnPageIndexChanging="Page_Changing">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--分页--%>
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' style='display:<%# Eval("ID").ToString()=="1"?"none":"block"%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="类型名称">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a href='ImageCategory_Operate.aspx?width=700&height=450&id=<%# Eval("ID")%>' style="color:#4482b4;" class="dialog">编辑</a>
                                
                                <asp:LinkButton ID="LinkDelte" Visible='<%# Eval("ID").ToString()=="1"?false:true%>' runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID")%>' CausesValidation="false"  OnClientClick="return window.confirm('您确定要删除吗?');" OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        </Columns>
                    </cc1:Num1GridView>
                </td>
            </tr>
        </table>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
