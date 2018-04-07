<%@ page language="C#" autoeventwireup="true" inherits="Admin_backupDB"   CodeBehind="backupDB.aspx.cs"      %>

<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    数据库备份</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div class="sbtn">


                    <asp:LinkButton ID="ButtonBackup" runat="server"  CssClass="beifendq lmf_btn"
                        OnClick="ButtonBackup_Click"  ><span>备份当前</span></asp:LinkButton>


                </div>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="list_table" width="98%">
                <tr class="list_header">
                    <th style="width: 10%;">
                        文件名称
                    </th>
                    <th style="width: 10%;">
                        备份时间
                    </th>
                    <th style="width: 10%;">
                        操作
                    </th>
                </tr>
                <%  if (bakinfo != null && bakinfo.Count>0)
                    {
                        foreach (string[] fi in bakinfo)
                        {%>
                <tr class="list_hover">
                    <td align="center">
                        <div style="color: #0e659f">
                            <%=fi[0]%></div>
                    </td>
                    <td align="center">
                        <%=fi[1]%>
                    </td>
                    <td align="center">
                        <div class="caoz">
                            <a href="?action=reduction&file=<%=fi[0] %>" style="display:none;">还原</a> <a href="?action=del&file=<%=fi[0] %>">
                                删除</a> <a href="?action=download&file=<%=fi[0] %>">下载</a>
                        </div>
                    </td>
                </tr>
                <%}
                    }
                    else { 
                        %>
                        
                        <tr>
                            <td colspan="3" style="text-align:center; font-weight:bold; line-height:26px;">
                                <span id="Span11">无查询的记录！</span>
                            </td>
                        </tr>
                        
                        <%        
                    } %>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
