<%@ page language="C#" autoeventwireup="true" inherits="Admin_Link_Operate"   CodeBehind="Link_Operate.aspx.cs"      %>


<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增友情链接</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script src="../Themes/Skin_Default/Js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var has_showModalDialog = !!window.showModalDialog;//定义一个全局变量判定是否有原生showModalDialog方法  
        if (!has_showModalDialog && !!(window.opener)) {
            window.onbeforeunload = function () {
                window.opener.hasOpenWindow = false;        //弹窗关闭时告诉opener：它子窗口已经关闭  
            }
        }
        //定义window.showModalDialog如果它不存在  
        if (window.showModalDialog == undefined) {
            window.showModalDialog = function (url, mixedVar, features) {
                if (window.hasOpenWindow) {
                    alert("您已经打开了一个窗口！请先处理它");//避免多次点击会弹出多个窗口  
                    window.myNewWindow.focus();
                }
                window.hasOpenWindow = true;
                if (mixedVar) var mixedVar = mixedVar;
                //因window.showmodaldialog 与 window.open 参数不一样，所以封装的时候用正则去格式化一下参数  
                if (features) var features = features.replace(/(dialog)|(px)/ig, "").replace(/;/g, ',').replace(/\:/g, "=");
                //window.open("Sample.htm",null,"height=200,width=400,status=yes,toolbar=no,menubar=no");  
                //window.showModalDialog("modal.htm",obj,"dialogWidth=200px;dialogHeight=100px");   
                var left = (window.screen.width - parseInt(features.match(/width[\s]*=[\s]*([\d]+)/i)[1])) / 2;
                var top = (window.screen.height - parseInt(features.match(/height[\s]*=[\s]*([\d]+)/i)[1])) / 2;
                window.myNewWindow = window.open(url, "_blank", features);
            }
        }
     //选择单图
   function openSingleChild()
    { 
        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if (k == undefined) {k = window.returnValue; }
        if(k != null) 
        {
        var imgvalue = new Array();
            imgvalue = k.split(",");
          var strLen=k.length;
          var lastIndex=k.lastIndexOf('/');
          document.getElementById("textBoxImgAddress").value =imgvalue[0]; 
         document.getElementById("ImageOriginalImge").src =imgvalue[1]; 
        }
    } 
    
    function geturl()
    {
      var radioButtonImgType=$("#radioButtonImgType_1:checked").val()
      if(radioButtonImgType=="1")
      {
      var imgAddress= document.getElementById("textBoxImgAddress").value;
      document.getElementById("ImageOriginalImge").src =imgAddress;
      }
     else
     {
     
     }
    }
    </script>
    
    <script type="text/javascript" language="javascript">
        function checkSub()
        {            
            if($("#textBoxDescription").val().trim().length>150)
            {
               alert("站点介绍不能超过150个字符");return false;
            }
            if($("#textBoxMemo").val().trim().length>150)
            {
              alert("备注不能超过150个字符");return false;
            }
            return true;
        }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增友情链接"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>


        <div class="welcon clearfix">

            <div class="inner_page_list">
           <table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th align="right" width="150px">
                        
                            <asp:Label ID="lblLinkType" runat="server" Text="链接类型："></asp:Label>
                     
                    </th>
                    <td>
                       
                            <asp:DropDownList ID="DropListLinkType" CssClass="tselect" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="DropListLinkType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            <asp:Label ID="lblTitle" runat="server">链接名称：</asp:Label>
                      
                    </th>
                    <td>
                       
                            <asp:TextBox ID="textBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                ControlToValidate="textBoxTitle" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="textBoxTitle"
                                Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        
                            <asp:Label ID="lblLinkAddress" runat="server" Text="链接地址："></asp:Label>
                        
                    </th>
                    <td>
                       
                            <asp:TextBox ID="textBoxLinkAddress" runat="server" CssClass="tinput">http://</asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:Label ID="Label11" runat="server" Text="（格式：http://...）"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="textBoxLinkAddress" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxLinkAddress"
                                ErrorMessage="地址格式错误" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        
                            <asp:Label ID="lblOrderID" runat="server" Text="排序号："></asp:Label>
                        
                    </th>
                    <td>
                    
                        <asp:TextBox ID="textBoxOrderID" runat="server" CssClass="tinput"></asp:TextBox>
                        <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="textBoxOrderID"
                            ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxOrderID"
                            ErrorMessage="只能为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            
                    </td>
                </tr>
                <asp:Panel ID="PanelPic" runat="server">
                    <tr>
                        <th align="right">
                           
                                <asp:Label ID="lblIMGTYPE" runat="server" Text="图片类型："></asp:Label>
                            
                        </th>
                        <td>
                           
                                <asp:RadioButtonList ID="radioButtonImgType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radioButtonIMGTYPE_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow" ForeColor="Black">
                                    <asp:ListItem Selected="True" Value="0"  >本地图片</asp:ListItem>
                                    <asp:ListItem Value="1" >远程图片</asp:ListItem>
                                </asp:RadioButtonList>
                           
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                           
                                <asp:Label ID="lblImgAddress" runat="server" Text="本地上传："></asp:Label>
                          
                        </th>
                        <td>
                           
                                <asp:TextBox ID="textBoxImgAddress" runat="server" CssClass="tinput"  onafterpaste="geturl()" onblur="geturl()"></asp:TextBox><asp:Label
                                    ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidatorImgAddress" runat="server" ControlToValidate="textBoxImgAddress"
                                        ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:Panel ID="Panelimage" runat="server">
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="选择图片" onclick="openSingleChild()"  />
                                    </asp:Panel>
                                    <img  id="ImageOriginalImge" runat="server" alt="" src="" width="60" height="60"  />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPackImagePath" runat="server"
                                    ControlToValidate="textBoxImgAddress" Display="Dynamic" ErrorMessage="路径最多250个字符"
                                    ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                           
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <th align="right">
                        
                            <asp:Label ID="lblDescription" runat="server" Text="站点介绍："></asp:Label>
                        
                    </th>
                    <td>
                       
                            <asp:TextBox ID="textBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            <span>站点介绍不能超过150字</span>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                       
                            <asp:Label ID="lblIsShow" runat="server" Text="是否前台显示："></asp:Label>
                      
                    </th>
                    <td>
                        
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="是" />
                        
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        
                            <asp:Label ID="lblRemark" runat="server" Text="备注："></asp:Label>
                        
                    </th>
                    <td>
                        
                            <asp:TextBox ID="textBoxMemo" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            <span>备注不能超过150字</span>
                    </td>
                    
                </tr>
            </table>
             </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    CssClass="fanh" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/Link_Manage.aspx"
                    Text="返回列表" CausesValidation="False" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
