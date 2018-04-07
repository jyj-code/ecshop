<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="TbProductCategory_List" Codebehind="TbProductCategory_List.aspx.cs" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/MessageShowTb.ascx" TagName="MessageShowTb" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link rel='stylesheet' type='text/css' href='../style/style.css' />
    <link rel="stylesheet" type="text/css" href="style/index.css" />
    <script src="/JS/CommonJS.js" type="text/javascript"></script>
    <script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript"> 
function DeleteButton()
{
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择要删除的记录！");
        return false;
    }else if(window.confirm("您确定要删除吗?"))
    {
          document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
        return true;
    }else
    {
        return false;
    }
}
    </script>

</head>
<body class="right_body">
    <form id="form1" runat="server">

 <div class="dpsc_mian">
      <p class="ptitle" ><a href="../S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">本地商品分类</span></p>
       <div style=" width: 740px; padding-top: 8px;
            padding-left: 8px; line-height: 30px;">
            <p class="ultit">商品分类，这里是和淘宝商家自定义分类相对应。</p>
            <asp:TreeView ID="TreeViewData" runat="server" ShowCheckBoxes="All">
            </asp:TreeView>

           <table width="270">
               <tr>
                   <td><asp:linkButton ID="ButtonAdd" runat="server"  CssClass="tjbtn1" PostBackUrl="" OnClick="ButtonAdd_Click">添加分类</asp:linkButton></td>
                   <td><asp:linkButton runat="server" ID="ButtonEdit"  CssClass="tjbtn" OnClick="ButtonEdit_Click" >编辑</asp:linkButton></td>
                   <td><asp:linkButton runat="server" ID="ButtonDelete" CssClass="tjbtn" OnClientClick="return DeleteButton()" OnClick="ButtonDelete_Click">删除</asp:linkButton></td>
                   <td><asp:linkButton ID="ButtonNodeOperate" runat="server"  CausesValidation="False"
                CssClass="tjbtn1" ToolTip="NoExpand" OnClick="ButtonNodeOperate_Click">全部展开</asp:linkButton></td>

                   <td><asp:HiddenField ID="CheckGuid" runat="server" Value="0" /></td>
               </tr>
           </table>

            
           
        </div>

</div>
    

    </form>
</body>
</html>
