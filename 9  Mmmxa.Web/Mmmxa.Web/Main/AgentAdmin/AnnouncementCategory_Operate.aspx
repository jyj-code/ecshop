﻿<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_AnnouncementCategory_Operate, ShopNum1.Deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增公告分类</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增公告分类"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
             <div class="inner_page_list">

            <table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th align="right" width="150px">
                        
                            <asp:Label ID="Label1" runat="server" Text="分类名称："></asp:Label>
                        
                    </th>
                    <td>
                       
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
ControlToValidate="TextBoxName"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="标题最多50个字符" 
ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>



                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        
                            <asp:Label ID="LabelFatherID" runat="server" Text="上级分类："></asp:Label>
                        
                    </th>
                    <td>
                        
                            <asp:DropDownList ID="DropDownListFatherID" runat="server" Width="183px" CssClass="tselect"></asp:DropDownList>
                            <span>请选择</span>
                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            <asp:Label ID="LabelKeywords" runat="server" Text="分类关键字："></asp:Label>
                        
                    </th>
                    <td>
                       
                            <asp:TextBox ID="TextBoxKeywords" runat="server"  CssClass="tinput" TextMode="MultiLine" Width="440"
                    Height="60"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle0" runat="server"
                    ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="关键字最多200个字符"
                    ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>


                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            <asp:Label ID="LabelDescription" runat="server" Text="分类描述："></asp:Label>
                        
                    </th>
                    <td>
                        
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput"  Height="60px" 
TextMode="MultiLine"
                    Width="440"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle1" runat="server"
                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="描述最多150个字符"
                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>



                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                      
                            <asp:Label ID="Label2" runat="server" Text="分类排序：" ></asp:Label>
                       
                    </th>
                    <td>
                     
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput" ></asp:TextBox>
                <asp:Label ID="Label5" runat="server" ForeColor="red" Text="*"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                    ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字" 
ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" 
ControlToValidate="TextBoxOrderID"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>




                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            <asp:Label ID="LabelIsShow" runat="server" Text="是否前台显示：" CssClass="allinput2"></asp:Label>
            
                        
                    </th>
                    <td>
                        
                           <asp:CheckBox ID="CheckBoxIsShow" runat="server" Text="是" Checked="True" />
                        
                    </td>
                </tr>
               
                       
            </table>
           </div>

            <div class="tablebtn">
               
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                        ToolTip="Submit" CssClass="fanh"/>
                
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/AnnouncementCategory_List.aspx" Text="返回列表" />
                        



            </div>
        </div>
    </div>









    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
