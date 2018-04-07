<%@ control language="C#" autoeventwireup="true" inherits="Admin_UserControl_ArticleRelateArticleSelect, ShopNum1.Deploy" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>



<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="10">&nbsp;</td>
  </tr>
  <tr>
    <td><table width="70%" border="0" cellspacing="0" cellpadding="0">
        <tr>
        <td colspan="7">
        	<table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr><td width="20%" align="right">资讯分类：</td>
          <td width="15%" align="left" ><asp:DropDownList ID="DropDownListSArticleCategory" runat="server" Width="180px" CssClass="tselect"  > </asp:DropDownList></td>
          <td width="11%"  align="right">资讯标题：</td>
          <td width="15%" align="left"><asp:TextBox ID="TextBoxSArticleTitle" runat="server" CssClass="tinput" ></asp:TextBox></td>
          <td width="10%"  align="right"> <asp:Button ID="ButtonSearch" runat="server" Text="查询" 
                                CausesValidation="False" onclick="ButtonSearch_Click" 
                  CssClass="dele" /></td>
          <td width="12%" ></td>
          <td  align="left"></td></tr>
            </table>
        
        <br />
        </td>
          
        </tr>
        <tr>
          <td  align="right">&nbsp;</td>
          <td>可选资讯：</td>
          <td>&nbsp;</td>
          <td>关联资讯：</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td  align="right">&nbsp;</td>  
          <td><asp:ListBox ID="ListBoxLeftArticleArticle" CssClass="tinput"  runat="server" Height="440px" 
                                            SelectionMode="Multiple" Width="300px" 
                                           >
                                        </asp:ListBox></td>
          <td><table width="100" border="0" cellspacing="3" cellpadding="0"  style=" text-align:center">
              <tr>
                <td style="height:50px;"> <asp:DropDownList ID="DropDownListRelatedArticleIsBoth" runat="server" Width="100" Height="30" CssClass="tselect"  >
                    </asp:DropDownList></td>
              </tr>
              <tr>
                <td style=" height:50px;"> <asp:Button ID="ButtonArticleAddAll" runat="server" onclick="ButtonArticleAddAll_Click" 
                                                Text="全部添加&gt;&gt;"  CausesValidation="False" CssClass="qb"/></td>
              </tr>
              <tr>
                <td style=" height:50px;"><asp:Button ID="ButtonAddArticle" runat="server" onclick="ButtonAddArticle_Click" 
                                                Text="添加&gt;&gt;" CausesValidation="False"  CssClass="dele"/></td>
              </tr>
              <tr>
                <td style=" height:50px;"><asp:Button ID="ButtonDeleteArticle" runat="server" onclick="ButtonDeleteArticle_Click" 
                                                Text="&lt;&lt;移除"  CausesValidation="False"  CssClass="dele"/></td>
              </tr>
              <tr>
              <td style=" height:50px;"><asp:Button ID="ButtonArticleDeleteAll" runat="server"  CssClass="qb"
                                                onclick="ButtonArticleDeleteAll_Click" Text="&lt;&lt;全部移除" 
                                                CausesValidation="False" /></td>
              </tr>
            </table></td>
          <td> <asp:ListBox ID="ListBoxRightArticleArticle" runat="server" Height="440px"  CssClass="tinput" 
                                            SelectionMode="Multiple" Width="300px" 
                                           >
                                        </asp:ListBox></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>



 </ContentTemplate>
</asp:UpdatePanel>