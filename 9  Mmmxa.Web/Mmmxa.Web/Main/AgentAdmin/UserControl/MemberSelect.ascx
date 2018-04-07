<%@ control language="C#" autoeventwireup="true" inherits="AgentAdmin_UserControl_MemberSelect, ShopNum1.Deploy" %>
       <style type="text/css">
           .style1{width: 4%; }
           .bt2{height: 26px;}
       </style>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
   <div id="content1" >             
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <!-- 相关会员 -->  
<table align="center" style="width:100%">
         <tr>
                <td align="right" style="display:none">
                    <asp:Label ID="LabelSRelatedProductName" runat="server" Text="会员姓名：" ></asp:Label>
                </td>
                <td align="left" style="display:none">
                      <asp:TextBox ID="TextBoxSMemberID" runat="server" CssClass="tinput" Width="150" ></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelSRelatedProductCategoryID" runat="server" Text="会员ID："></asp:Label>
                </td>
                <td align="left"><asp:TextBox ID="TextBoxSMemberName" runat="server"  CssClass="tinput" Width="150" ></asp:TextBox>
                  
                </td>
                <td align="right" style="display:none">
                    <asp:Label ID="LabelSRelatedProductBrandGuid" runat="server" Text="会员等级："></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="DropDownListSMemberRank" runat="server" Width="180px" CssClass="tselect" Visible="false">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="ButtonSearchRelatedProduct" runat="server" Text="查询" onclick="ButtonSearchRelatedProduct_Click" CssClass="dele" 
                        CausesValidation="False" />
                </td>
            </tr>
            </table>
             <table>
            <tr>
                <td align="right" style="width:25%;padding-right:120px;">
                    <asp:Label ID="LabelShowLeftRelatedProduct" runat="server" Text="可选会员"></asp:Label>
                </td>
                <td align="center" class="style1">
                </td>
                <td align="left" style="width:25%;padding-left:120px">
                    <asp:Label ID="LabelShowRightRelatedProduct" runat="server" Text="已选会员"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:25%">
                    <asp:ListBox ID="ListBoxLeftMember" runat="server" CssClass="tinput"  Height="441px" 
                        SelectionMode="Multiple" Width="294px" ></asp:ListBox>
                </td>
                <td align="center" class="style1">
                <table cellpadding="0" cellspacing="3" border="0" width="80">
                        <tr>
                        <td><asp:Button ID="ButtonAddAllMember" runat="server" CausesValidation="False" 
                         Text="&gt;&gt;"   onclick="ButtonAddAllMember_Click" CssClass="dele"  /></td>
                        </tr>
                <tr><td><asp:Button ID="ButtonAddMember" runat="server" CausesValidation="False" 
                         Text="&gt;"  CssClass="dele"   onclick="ButtonAddMember_Click" /></td></tr>
                <tr><td><asp:Button ID="ButtonDeleteMember" runat="server" CausesValidation="False" 
                         Text="&lt;"  CssClass="dele"   onclick="ButtonDeleteMember_Click" /></td></tr>
                <tr><td><asp:Button ID="ButtonDeleteAllMember" runat="server" CausesValidation="False" 
                         Text="&lt;&lt;"  CssClass="dele"   onclick="ButtonDeleteAllMember_Click" /></td></tr>
                </table>
                </td>
                <td align="left" colspan="1" style="width:25%">
                    <asp:ListBox ID="ListBoxRightMember" runat="server" CssClass="tinput"  Height="441px" 
                        SelectionMode="Multiple" Width="272px"></asp:ListBox>
                </td>
            </tr>
             </table>
                     </ContentTemplate>
    </asp:UpdatePanel>
    </div>