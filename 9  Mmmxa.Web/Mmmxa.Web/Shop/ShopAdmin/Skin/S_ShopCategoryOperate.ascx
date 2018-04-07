<%@ Control Language="C#" AutoEventWireup="true" %>
<script type="text/javascript" language="javascript">
     function funSelectValue1(val)
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
                    var code=$("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val();
                    var xhtml=new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if(ajaxData!=null)
                    {
                       ajaxData=eval('('+ajaxData+')');
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
                        $("#DropDownListShopCategory2").html(xhtml.join(""));
                     }
                     else
                     {
                        $("#DropDownListShopCategory2").html(xhtml.join(""));
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
                   
                    var code=$("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val();
                    var xhtml=new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if(ajaxData!=null)
                    {
                        ajaxData=eval('('+ajaxData+')');
                        $.each(ajaxData,function(m,n)
                        {
                            var xcode=n.id+"|"+n.code;
                            
                            if(code!="" && code.length>=9)
                            {
                                code=code.substring(0,9);
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
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }
                    else
                    {
                        //$("#S_ShopCategoryOperate_ctl00_hidShopCategoryCodeValue").val("0")
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }
                    
                 }
             });
         }
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
                        ajaxData=eval('('+ajaxData+')');
                        var code=$("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val();
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
         function funSelectValue3(val)
         {
            var id=$(val).val();//ID
            if(id!="-1")
            {
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val($(val).find("option:selected").val().split('|')[1]);
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryName").val($(val).find("option:selected").text());
            }
         }
         function SetShopCategory()
         {
            var shopcatetype3=$("#DropDownListShopCategory3").find("option:selected");
            var shopcatetype2=$("#DropDownListShopCategory2").find("option:selected");
            var shopcatetype1=$("#DropDownListShopCategory1").find("option:selected");
            if(shopcatetype3.val()!="-1")
            {
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val(shopcatetype3.val().split('|')[1]);
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryName").val(shopcatetype1.text()+"/"+shopcatetype2.text()+"/"+shopcatetype3.text());
            }
            else if(shopcatetype2.val()!="-1")
            {
                $("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val(shopcatetype2.val().split('|')[1]);
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryName").val(shopcatetype1.text()+"/"+shopcatetype2.text());
            }
            else if(shopcatetype1.val()!="-1")
            {
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryCode").val(shopcatetype1.val().split('|')[1]);
                 $("#S_ShopCategoryOperate_ctl00_hidShopCategoryName").val(shopcatetype1.text());
            }
            else
            {
               alert("请选择分类!");return false;
            }
            return true;
         }
</script>

<input type="hidden" id="hidShopCategoryCode" runat="server" />
<input type="hidden" id="hidShopCategoryName" runat="server" />
    <div class="biaogenr">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="biaod">
            <tbody><tr>
                <th colspan="2">
                    修改店铺分类
                </th>
            </tr>
            <tr>
                <td class="bordleft">
                    店铺分类：
                </td>
                <td style="padding-top: 8px;" class="bordrig">
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
                    <span id="errNewsCategory" class="red">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    备注：
                </td>
                <td style="padding-top: 8px;" class="bordrig">
                    <asp:TextBox ID="TextBoxRemarks" TextMode="MultiLine" runat="server" CssClass="op_area"></asp:TextBox>
                </td>
            </tr>
        </tbody></table>
        <div class="op_btn">
            <asp:Button ID="ButtonEnsure" runat="server" Text="申请修改" CssClass="baocbtn" OnClientClick="return SetShopCategory()" />
                        <asp:Button ID="ButtonLink" runat="server" Text="返回列表" CssClass="baocbtn" CausesValidation="false" />
        </div>
    </div>