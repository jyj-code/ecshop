<%@ page language="C#" autoeventwireup="true" inherits="Admin_SubstationManage_Operate"   CodeBehind="SubstationManage_Operate.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增分站</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />

    <script type="text/javascript">
   
    //选择单图
   function openSingleChild()
    { 
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if(k != null) 
        {
        var imgvalue = new Array();
            imgvalue = k.split(",");
          var strLen=k.length;
          var lastIndex=k.lastIndexOf('/');
          document.getElementById("TextBoxLogo").value = k.substring(lastIndex+1,strLen); 
         document.getElementById("ImageOriginalImge").src =imgvalue[1]; 
        }
    } 
    
        var lock=0;
      //品牌分类
     function ProductBrandCategory()
    { 
    if(lock==0)
      {
       lock=1;
       var BrandGuid=document.getElementById("hiddenFieldGuid").value;
       var  memlogid= document.getElementById("LabelProductBrandCategory").innerHTML;
        var k = window.showModalDialog("ProductCategoryList_Seleted.aspx?BrandGuid="+BrandGuid+"&date="+new Date(),window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if(k!=null)
        {
            document.getElementById("spanProductCategoryName").value=k.split(";")[0];
            document.getElementById("hiddenProductCategoryCode").value=k.split(";")[1];
        }
      
         lock=0;
     }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增分站"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            选择分站地区：
                        </th>
                        <td>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Width="100">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label><span>分站所在地，新增分站时必选，选择后不可更改。</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownListProductGuid3"
                                Display="Dynamic" ErrorMessage="请选择分站所在地区"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Label ID="LabelCity" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelID" runat="server" Text="分站ID："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxID" runat="server" CssClass="tinput" MaxLength="20"  onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z]/g,'')"   ></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoName" runat="server"
                                ControlToValidate="TextBoxID" Display="Dynamic" ErrorMessage="分站ID最多20个字符"
                                ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator><span> 分站的标志，每次访问分站后台必填，请输入少于20个英文字符。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="分站名称："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" MaxLength="5"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoWebSite" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="分站名称最多5个字符"
                                ValidationExpression="^[\s\S]{0,6}$"></asp:RegularExpressionValidator>
                            <asp:HiddenField ID="HiddenFieldSubstationName" runat="server" /><span>分站名称建议取2到5个字符，过长可能会导致首页换行。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="分站域名："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDomainName" runat="server" CssClass="tinput" MaxLength="30" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')" onpaste="value=value.replace(/[^\a-\z\A-\Z]/g,'')" oncontextmenu = "value=value.replace(/[^\a-\z\A-\Z]/g,'')"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDomainName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKeywords" runat="server"
                                ControlToValidate="TextBoxDomainName" Display="Dynamic" ErrorMessage="分站域名最多30个字符"
                                ValidationExpression="^[\s\S]{0,30}$"></asp:RegularExpressionValidator><span> 分站域名只能输入英文，请输入少于30个字符</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPeople" runat="server" Text="负责人姓名："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPeople" MaxLength="50" runat="server"  CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxPeople"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator><span>分站负责人真实姓名。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPhone" runat="server" Text="电话号码：" ></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPhone" runat="server" MaxLength="11" CssClass="tinput" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPhone"
                                Display="Dynamic" ErrorMessage="该处只能输入数字且该值不能为空" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="TextBoxPhone" Display="Dynamic" ErrorMessage="分站域名最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span>分站负责人联系电话，该处只能填入数字</span>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelShowRegiesr" runat="server" Visible="true">
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="分站管理员账号：" ></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxManageNumber" runat="server" MaxLength="50" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')"  CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxManageNumber"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="TextBoxManageNumber" Display="Dynamic" ErrorMessage="管理员账号最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator><span> 分站管理员账号只能输入英文!</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label8" runat="server" Text="分站管理员密码："   ></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxManagePwd" runat="server" MaxLength="50" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxManagePwd"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            是否启用：
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsDisabled" runat="server" Checked="true" /><span>是否启用。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            设为热门：
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsHot" runat="server"  /><span>设为热门。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRemarks" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRemarks" runat="server" CssClass="tinput" TextMode="MultiLine" Width="400" Height="150" MaxLength="200"></asp:TextBox>(限定在200个字符内)
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="TextBoxRemarks" Display="Dynamic" ErrorMessage="备注最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="" OnClick="ButtonConfirm_Click"
                    CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/SubstationManage_List.aspx" Text="返回列表" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" />
    </form>
</body>
</html>
