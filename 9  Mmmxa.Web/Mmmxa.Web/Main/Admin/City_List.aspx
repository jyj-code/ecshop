<%@ page language="C#" autoeventwireup="true" inherits="MainAdmin_City_List, ShopNum1.Deploy" %>

<%@ Register assembly="ShopNum1.Control" namespace="ShopNum1.Control" tagprefix="cc1" %>

<%@ Register src="UserControl/MessageShow.ascx" tagname="MessageShow" tagprefix="ShopNum1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
            <link type="text/css" rel="Stylesheet" href="css/index.css" /> 
<script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body style="padding:0; background-image: url(images/Bg_right.gif); background-repeat:repeat;" 
    alink="200%">
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <div class="navigator">【 城市管理  】</div>
   <table  cellpadding="10" cellspacing="0" borer="0" width="100%">
                    <tr>
                        <td >
                            <asp:TreeView ID="TreeViewCategory"  runat="server" ShowCheckBoxes="All" 
                                ShowLines="True" >
                                <RootNodeStyle Font-Bold="False" Font-Size="14px" />
                            </asp:TreeView>
                        </td>
                    </tr>
                       <tr>
                        <td align="left">
                        <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
                                onclientclick="GetCheckedBoxValues()" Text="添加" CausesValidation="False" 
                                CssClass="bt2" />
                            &nbsp;<asp:Button ID="ButtonEdit" runat="server" onclick="ButtonEdit_Click"  onclientclick="return EditButton()" 
                                Text="编辑" CausesValidation="False" CssClass="bt2" />
                            &nbsp;<asp:Button ID="ButtonDelete" runat="server" onclick="ButtonDelete_Click" 
                                onclientclick="return DeleteButton()" Text="删除" CausesValidation="False" CssClass="bt2"/>&nbsp;                       
    <asp:Button ID="ButtonNodeOperate" runat="server" Text="全部展开" 
                                CausesValidation="False" CssClass="bt3" onclick="ButtonNodeOperate_Click" 
                                ToolTip="NoExpand"/>
        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </td>                    
                    </tr>
</table>
        <%--                   <input ID="checkboxItem"   onclick="GetItmeValue(this)" type="checkbox" />--%><br />
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
