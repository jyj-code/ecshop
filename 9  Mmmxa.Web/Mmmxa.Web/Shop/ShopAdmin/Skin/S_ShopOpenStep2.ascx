<script>
    function funCheckShopName()
    {
         var shopname =  $("#<%=TextBoxShopName.ClientID %>").val();
         if(shopname!="")
         {
            if(shopname.length>20)
            {
                $("#errShopName").html("店铺名称长度不能超过20的字符！");
                return false;
            }
            else
            {
                //求唯一店铺名称！
                $.ajax({
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                 async: true,
                 data: "type=ShopName&ShopName="+shopname,
                 dataType: "html",
                 success: function (ajaxData) {
                    if(ajaxData!="")
                    {
                        if(shopname!=$("#<%=HiddenShopNameValue.ClientID %>").val())
                        {
                            if(ajaxData=="false")
                            {
                            $("#errShopName").html("");
                            $("#S_ShopOpenStep2_ctl00_HiddenShopName").val("ok");
                            return true;
                             }
                             else if(ajaxData=="true")
                             {
                                $("#errShopName").html("店铺名称已存在！");
                                return false;
                             }
                        }
                        else
                        {
                            $("#S_ShopOpenStep2_ctl00_HiddenShopName").val("ok");
                            return true;
                        }
                         
                    }
                 }
                });
            }
         }
         else
         {
            $("#errShopName").html("店铺名称不能为空！");
            return false;
         }
    }
    
    
    //ajax上传图片
    function changfile(obj,type)
    {
    try{
         //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function(formData, jqForm, options){
                if(type==1){
                   
                    $("#IdentityCardImg").attr("src","images/loading.gif");}
                else if(type==2){
                    $("#Img1").attr("src","images/loading.gif");               
                }
            },
            success: function(data, textStatus) {
                 var imageinfo=eval('('+data+')');
                 
                 if(type==1){   
                                     
                    if(imageinfo.msg=="1"){   
                        $("#IdentityCardImg").attr("src",imageinfo.imagepath);
                        $("#IdentityCardImg").parent().attr("href",imageinfo.imagepath);
                        $("#S_ShopOpenStep2_ctl00_HiddenIdentityCardValue").val(imageinfo.imagepath);
                 }else{
                        $("#errIdentityCardimage").show().html(imageinfo.imagepath);
                 }
                }
                else if(type==2){
                    if(imageinfo.msg=="1"){   
                        $("#Img1").attr("src",imageinfo.imagepath);$("#S_ShopOpenStep2_ctl00_HiddenBusinessImageValue").val(imageinfo.imagepath);
                        $("#Img1").parent().attr("href",imageinfo.imagepath);
                 }else{
                        $("#errBusinessLicense").show().html(imageinfo.imagepath);
                 }
                }
                 
            },
            error: function(data, status, e) { alert("上传失败，错误信息：" + e); $(obj).val("");   },
            url: "/Api/ShopAdmin/S_OpenShop.ashx?type="+type,
            type: "post",
            dataType: "text",
            timeout: 600000
        });
        }catch(e){alert(e);}
    }
    
    //检查座机电话
    function funCheckTel()
    {
        var tel=$("#<%=TextBoxTel.ClientID %>").val();
        if(tel!="")
        {
            //表示座机电话
                var reg =/^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
                if (!reg.test(tel)){
                    $("#errTel").html("号码格式错误！");
                    return false;
                    }else{
                    $("#errTel").html("");
                    return true;
                }
        }
        $("#errTel").html("");
        return true;
        
    }
    
    //验证身份证
    function funCheckIDD()
    {
        var idd=$("#<%=TextBoxIdentityCard.ClientID %>").val();
        if(idd!="")
        {
            var partten = /^[\d]{6}((19[\d]{2})|(200[0-8]))((0[1-9])|(1[0-2]))((0[1-9])|([12][\d])|(3[01]))[\d]{3}[0-9xX]$/
            if(partten.test(idd))
            {
                //唯一
                $.ajax({
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                 async: true,
                 data: "type=IdentityCard&IdentityCard="+idd,
                 dataType: "html",
                 success: function (ajaxData) {
//                 var ajaxData=eval('('+ajaxData+')');
                    if(ajaxData!="")
                    {
                        if(idd!=$("#<%=HiddenIdentityValue.ClientID %>").val())
                        {
                            if(ajaxData=="false")
                             {
                                $("#errIdentityCard").html("");
                                $("#<%=HiddenIdentityCard.ClientID %>").val("ok");
                                return true;
                             }
                             else if(ajaxData=="true")
                             {
                                $("#errIdentityCard").html("身份证已存在！");
                                return false;
                             }
                        }
                        else
                        {
                            $("#<%=HiddenIdentityCard.ClientID %>").val("ok");
                            return true;
                        }
                         
                    }
                 }
                });
                 $("#errIdentityCard").html("");
                 return true;
            }
            else
            {
                $("#errIdentityCard").html("身份证格式错误！");
                 return false;
            }
        }
        else
        {
            $("#errIdentityCard").html("身份证不能为空！");
            return false;
        }
        return false;
    }
    
    function funButton(obj)
    {
        funCheckShopName();
        funCheckSubstationID();
        funCheckShopCategory();
        checkSumbit();
        funCheckAdress();
        funCheckIDD();
        
        funCheckTextBoxAddress();
        funCheckPhone();
        if($("#S_ShopOpenStep2_ctl00_RadioButtonPersonal").is(":checked"))
        {
            if($("#S_ShopOpenStep2_ctl00_HiddenIdentityCardValue").val()=="")
            {
               return false;
            }
        }
        else if($("#S_ShopOpenStep2_ctl00_RadioButtonBusiness").is(":checked"))
        {
            if($("#S_ShopOpenStep2_ctl00_HiddenBusinessImageValue").val()=="")
            {
               return false;
            }
        }
//        funUpdateImage();
        if(funCheckSubstationID()&&funCheckPhone()&&funCheckTextBoxAddress()&&funCheckTel()&&funCheckIDD()&&funCheckShopCategory()&&$("#S_ShopOpenStep2_ctl00_hid_Area").val()!="" &&funCheckAdress()&& $("#S_ShopOpenStep2_ctl00_HiddenShopName").val()=="ok")
        {
            if(!$("#selectAgress").is(":checked"))
            {
                alert("请同意协议！");
                return false;
            } $(".append_image").show();$(obj).hide();
            return true;
        }
        return false;
    }
    
    
    function funCheckShopCategory()
    {
        if($("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val()=="0")
        {
            $("#errShopCategory").html("店铺分类必填！");
            return false;
        }
        $("#errShopCategory").html("");
            return true;
    }
    
    
    
    function funCheckAdress()
    {
        if($("#S_ShopOpenStep2_ctl00_hid_Area").val()=="")
        {
            $("#errAdress").html("所在地区必须选择！");
            return false;
        }
        $("#errAdress").html("");
        return true;
    }
    
</script>
<script type="text/javascript" language="javascript">
          
         function funSelectValue1(val)
         {
             //-------------------------------------------
             var id=$(val).val().split('|')[0];
             $.ajax(
            {
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                 async: false,
                 data: "FatherID="+id+"&type=ShopCategory",
                 dataType: "Json",
                 success: function (ajaxData) 
                 {
                 var ajaxData=eval('('+ajaxData+')');
                    var code=$("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml=new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if(ajaxData!=null)
                    {
                        $.each(ajaxData,function(m,n)
                        {
                            var xcode=n.id+"|"+n.code;
                            if(code!="" && code.length>=6)
                            {
                                code=code.substring(0,6);
                                if(code==n.code)
                                {
                                    xhtml.push('<option value="'+xcode+'" selected="selected">'+n.name+'</option>');
                                }   
                                else
                                {
                                    xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                                }
                            }
                            else
                            {
                                xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                            }
                        });
//                        if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
//                        {
                            $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory1").val())
//                        }
                        
                        $("#DropDownListShopCategory2").html(xhtml.join(""));
                     }
                     else
                     {
                        $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory1").val())
                        $("#DropDownListShopCategory2").html(xhtml.join(""));
//                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                     }
                     funSelectValue2($("#DropDownListShopCategory2"))
                 }
             });
             
         }
         function funSelectValue2(val)
         {
             var id=$(val).val().split('|')[0];
             $.ajax(
            {
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                 async: false,
                 data: "FatherID="+id+"&type=ShopCategory",
                 dataType: "Json",
                 success: function (ajaxData) 
                 {
                 var ajaxData=eval('('+ajaxData+')');
                    var code=$("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml=new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if(ajaxData!=null)
                    {
                        $.each(ajaxData,function(m,n)
                        {
                            var xcode=n.id+"|"+n.code;
                            
                            if(code!="" && code.length>=9)
                            {
                                code=code.substring(0,9);
//                                alert(n.code);
//                                alert(code);
                                if(code==n.code)
                                {
                                    xhtml.push('<option value="'+xcode+'" selected="selected">'+n.name+'</option>');
                                }   
                                else
                                {
                                    xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                                }
                            }
                            else
                            {
                                xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                            }
                        });
//                        if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
//                        {
                            $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory2").val())
//                        }
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }
                    else
                    {
                        //$("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val("0")
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }
                    
                 }
             });
         }
         
         function funSelectValue3(val)
         {
            var id=$(val).val().split('|')[0];//ID
            if(id=="-1")
            {
                $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val($("#DropDownListShopCategory2").val());
            }
            else
            {
                $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val($(val).val());
            }
//            if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
//            {
                $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory3").val())
//            }
         }
         
        
    </script>
<script>
        $(function(){
            //求分类
            $.ajax(
            {
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                 async: false,
                 data: "FatherID=0&type=ShopCategory",
                 dataType: "Json",
                 success: function (ajaxData) 
                 {
                 var   ajaxData=eval('('+ajaxData+')');
                    var code=$("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml=new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    $.each(ajaxData,function(m,n)
                    {
                        var xcode=n.id+"|"+n.code;
                        if(code!="")
                        {
                            code=code.substring(0,3);
                            if(code==n.code)
                            {
                                xhtml.push('<option value="'+xcode+'" selected="selected">'+n.name+'</option>');
                            }   
                            else
                            {
                                xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                            }
                        }
                        else
                        {
                            xhtml.push('<option value="'+xcode+'">'+n.name+'</option>');
                        }
                    });
                    if(ajaxData!="")
                    {
                          $("#DropDownListShopCategory1").html(xhtml.join(""));
                    }
                 }
             });
             funSelectValue1($("#DropDownListShopCategory1"));
             funSelectValue2($("#DropDownListShopCategory2"))
             })
    </script>
<script language="javascript">
        $(function(){
            if($("#<%=HiddenIdEdit.ClientID %>").val()=="1")
            {
                $("#returnBut").hide();
            }
        })
        
        
    </script>
 
 <script>
    //检查详细地址
    function funCheckTextBoxAddress()
    {
        var TextBoxAddress=$("#S_ShopOpenStep2_ctl00_TextBoxAddress").val();
        if(TextBoxAddress!="")
        {
            $("#errTextBoxAddress").html("");
            return true;
        }
        else
        {
            $("#errTextBoxAddress").css("color","red")
            $("#errTextBoxAddress").html("详细地址不能为空！");
            return false;
        }
        return false;
    }
    
    //检查联系电话
    function funCheckPhone()
    {
        var phone=$("#<%=TextBoxPhone.ClientID %>").val();
        if(phone!="")
        {
            //表示手机
                var reg =/^1[358]\d{9}$/;
                if (!reg.test(phone)){
                    $("#errPhone").html("号码格式错误！");
                    return false;
                    }else{
                    $("#errPhone").html("");
                    return true;
                }
        }
        else
        {
            $("#errPhone").html("联系电话不能为空！");
            return false;
        }
        return false;
        
    }
    
    //检查分站
    function funCheckSubstationID()
    {
        if($("#<%=DropDownListSubstationID.ClientID %>").val()=="-1")
        {
            $("#SpanSubstationID").html("分站必须选择！");
            return false;
        }
        $("#SpanSubstationID").html("*");
            return true;
        
    }
    
    
   
    
    function funCheckGr()
    {
        $("#PanelTextBoxIdentityCardtr").show();
        $("#PanelBusinessLicensetr").hide();
        $("#PanelTextBoxIdentityCardtrWz").show();
        $("#PanelBusinessLicensetrWz").hide();
        $("#S_ShopOpenStep2_ctl00_FileUploadBusinessLicense").val("");
    }
    function funCheckQy()
    {
        $("#PanelTextBoxIdentityCardtr").show();
        $("#PanelBusinessLicensetr").show();
        $("#PanelTextBoxIdentityCardtrWz").show();
        $("#PanelBusinessLicensetrWz").show();
    }
    
    $(function(){
        if($("#S_ShopOpenStep2_ctl00_RadioButtonPersonal").is(":checked"))
        {
            $("#PanelTextBoxIdentityCardtr").show();
            $("#PanelBusinessLicensetr").hide();
            $("#PanelTextBoxIdentityCardtrWz").show();
        $("#PanelBusinessLicensetrWz").hide();
            $("#S_ShopOpenStep2_ctl00_FileUploadBusinessLicense").val("");
        }
        else
        {
            $("#PanelTextBoxIdentityCardtr").show();
            $("#PanelBusinessLicensetr").show();
            $("#PanelTextBoxIdentityCardtrWz").show();
            $("#PanelBusinessLicensetrWz").show();
        }
//           alert($("#IdentityCardImg").attr("src"));
            if($("#IdentityCardImg").attr("src")=="")
       {
		$("#IdentityCardImg").parent().hide();
	    }
             if($("#Img1").attr("src")=="")
           {
		    $("#Img1").parent().hide();
	    }
        
    })
    
 </script>
<div class="dpsc_mian" style="width:998px;">
 <div class="maijtitle2">
  </div>
 <table border="0" cellspacing="0" cellpadding="0" class="buzlb">
  <%--<tr>
    <td align="right" width="200">店铺等级：</td>
    <td>
        <asp:Label ID="LabelShopRank" runat="server" Text=""></asp:Label>
    </td>
  </tr>--%>
  <tr>
    <td align="right" width="200"><span class="red">*</span> 店铺类别：</td>
    <td>
        <asp:RadioButton ID="RadioButtonPersonal" runat="server" Width="60" onclick="funCheckGr()"  Text="个人" GroupName="type" Checked="true" AutoPostBack="false"/>
        <asp:RadioButton ID="RadioButtonBusiness" runat="server" Width="60" onclick="funCheckQy()"  Text="企业" GroupName="type" AutoPostBack="false" />
    </td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 店铺名称：</td>
    <td>
        <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="textwb" onblur="funCheckShopName()" MaxLength="50"></asp:TextBox>
        <span id="errShopName" style="color:Red"></span>
    </td>
  </tr>
  <tr>
    <td></td><td><div class="gray1" style=" line-height:16px;">店铺名称请控制在20个字符以内</div></td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 选择分站：</td>
    <td style=" line-height:40px;">
        <asp:DropDownList ID="DropDownListSubstationID" runat="server" CssClass="textwb">
        <asp:ListItem Value="-1" Text="-请选择-"></asp:ListItem>
        </asp:DropDownList>
        <span id="SpanSubstationID" style="color:Red"></span>
    </td>
  </tr>
  <tr>
    <td></td><td><div class="gray1" style=" line-height:16px;">分站选择之后不可更改，店铺属该分站管理</div></td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 店铺分类：</td>
    <td style=" line-height:40px;">
        <select id="DropDownListShopCategory1" onchange="funSelectValue1(this)" class="textwb" style=" width:130px">
            <option value="-1">-请选择-</option>
        </select>
        <select id="DropDownListShopCategory2" onchange="funSelectValue2(this)" class="textwb" style=" width:130px">
            <option value="-1">-请选择-</option>
        </select>
        <select id="DropDownListShopCategory3" onchange="funSelectValue3(this)" class="textwb" style=" width:130px">
            <option value="-1">-请选择-</option>
        </select>
        <span id="errShopCategory" style="color:Red"></span>
    </td>
  </tr>
  <tr>
    <td align="right">主营商品：</td>
    <td>
        <asp:TextBox ID="TextBoxMainGoods" runat="server" TextMode="MultiLine" MaxLength="500" Width="290" Height="90" CssClass="textwb" Font-Size="12px"></asp:TextBox>
     <br/>
     <span class="gray1">主营商品关键字（Tag）有助于搜索店铺时找到您的店铺</span>
    </td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 所在地区：</td>
    <td>
        <table>
            <tr>
                <td><div id="p_local"></div></td>
                <td><span class="gray1" id="errAdress" style="color:red; float:right"></span></td>
            </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 详细地址：</td>
    <td>
     <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="textwb" MaxLength="250" onblur="funCheckTextBoxAddress()"></asp:TextBox>
       <span class="gray1" id="errTextBoxAddress"></span>
       <%--<br/>--%>
     <span class="gray1">例如：湖北省武汉市XXXXXX</span>
    </td>
  </tr>
  <tr>
    <td align="right">邮政编码：</td>
    <td>
       <asp:TextBox ID="TextBoxPostalCode" runat="server" CssClass="textwb" MaxLength="6"></asp:TextBox>
       <span class="gray1">&nbsp;</span>
    </td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 手机号码：</td>
    <td>
      <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="textwb" onblur="funCheckPhone()" MaxLength="11"></asp:TextBox>
       <span class="gray1" id="errPhone" style=" color:red">&nbsp;</span>
    </td>
  </tr>
  <tr>
    <td align="right">座机号码：</td>
    <td>
      <asp:TextBox ID="TextBoxTel" runat="server" CssClass="textwb" onblur="funCheckTel()" MaxLength="50"></asp:TextBox>
       <span class="gray1" id="errTel" style=" color:red">&nbsp;</span>
    </td>
  </tr>
  <tr>
    <td align="right"><span class="red">*</span> 身份证号：</td>
    <td>
      <asp:TextBox ID="TextBoxIdentityCard" runat="server" CssClass="textwb" onblur="funCheckIDD()"></asp:TextBox>
      <span class="gray1" id="errIdentityCard" style=" color:red">&nbsp;</span>
    </td>
  </tr>
     <asp:Panel ID="PanelTextBoxIdentityCard" runat="server">
  <tr id="PanelTextBoxIdentityCardtr">
    <td align="right"><span class="red">*</span> 上传身份证：</td>
    <td>
        <input type="file" name="fileups1" id="FileUploadIdentityCard" onchange="changfile(this,1)" />
        <img width="200" id="imgIdCard" alt=""  style="display:none" /><span class="gray1" id="errIdentityCardimage" style=" color:red">&nbsp;</span>
        <a href="<%=HiddenIdentityCardValue.Value %>" target="_blank"> <img alt="" src="<%=HiddenIdentityCardValue.Value %>" id="IdentityCardImg" width="100" height="100" /></a>
        <%--//<asp:HiddenField ID="HiddenFieldIdentityCard" runat="server" />--%>
    </td>
  </tr>
  <tr id="PanelTextBoxIdentityCardtrWz">
    <td></td>
    <td style=" color:Silver">身份证为正反面复印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB</td>
  </tr>
  </asp:Panel>
     <asp:Panel ID="PanelBusinessLicense" runat="server">
     <tr id="PanelBusinessLicensetr" visible="false">
    <td align="right"><span class="red">*</span> 上传执照：</td>
    <td>
        <input type="file" name="fileups2" id="FileUploadBusinessLicense" onchange="changfile(this,2)" />
        <img width="200" id="imgBusiness" alt=""  style="display:none"  /><span class="gray1" id="errBusinessLicense" style=" color:red">&nbsp;</span>
        <a href="<%=HiddenBusinessImageValue.Value %>" target="_blank"> <img alt="" src="<%=HiddenBusinessImageValue.Value %>" id="Img1" width="100" height="100" /></a>
       <asp:HiddenField ID="HiddenField2" runat="server" />
    </td>
  </tr>
  <tr id="PanelBusinessLicensetrWz">
    <td></td>
    <td style=" color:Silver">营业执照复印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB</td>
  </tr>
     </asp:Panel>
  <tr>
    <td align="right"></td>
    <td>
      <input name="" type="checkbox" value="" id="selectAgress"  checked="checked"/>
    <span>我已认真阅读并同意<a target="_blank" style=" color:blue" href='<%= ShopUrlOperate.RetUrl("ShopRegProtocol") %>' class="blue">开店协议</a>中的所有条款</span>
    </td>
  </tr>
</table>
 <div class="maijtitle1">
     <asp:Button ID="ButtonOpen" runat="server" Text="立即开店"  OnClientClick="return funButton(this)" CssClass="sqjdbzj"/> <img class="append_image" alt="正在加载请稍等候" src="/Main/Themes/Skin_Default/Images/lodding.gif" style="display:none;" />
 <input name="12" type="button" class="sqjdbzj" value="返回重选"  onclick="javascript:location.href='S_ShopOpenStep1.aspx'"  id="returnBut"/>
  </div>
</div>
<input id="hid_Area" type="hidden" runat="server" value="" />
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="HiddenShopName" type="hidden" runat="server" value="" />
<input id="HiddenShopCategory" type="hidden" runat="server" value="0" />
<input id="HiddenShopCategoryValue" type="hidden" runat="server" value="0" />

<input id="HiddenIdentityCard" type="hidden" runat="server" value="" />

<input id="HiddenIdentityCardValue" type="hidden" runat="server" value="images/admin_pic.jpg"  />
<input id="HiddenBusinessImageValue" type="hidden" runat="server" value="images/logodfwe.jpg" />
<input id="HiddenIdEdit" type="hidden" runat="server" value="0" />
<input id="HiddenShopNameValue" type="hidden" runat="server" value="" />
<input id="HiddenIdentityValue" type="hidden" runat="server" value="" />