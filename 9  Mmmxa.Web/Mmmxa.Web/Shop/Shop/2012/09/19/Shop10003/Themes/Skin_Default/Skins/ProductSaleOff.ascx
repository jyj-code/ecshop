<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>

<script type="text/javascript">
  function ShowHideRegion( hre)
  {
  if(hre=="hide")
  {
   $("#divProvinceRegion").hide();
   }
   else
   {
   $("#divProvinceRegion").show();
   }
  }
  
  
 $(document).ready(function(){
 //如果是包邮就退出
 if(document.getElementById("ahrefregionname")==null)
 {
  return;
  }
  
 //绑定移除事件
   $("#divProvinceRegion").mouseout(function(){$(this).hide();$("#divProvinceRegion table tr td a").removeAttr("style");$("#divProvinceRegion table tr td a").parent().removeAttr("style");});
   
    $("#divProvinceRegion").mouseover(function(){$(this).show()});
    
    //地区鼠标移动事件
   $("#divProvinceRegion table tr td").each(function(i){ $(this).mouseover(function(){
    $("#divProvinceRegion table tr td a").removeAttr("style");
   $("#divProvinceRegion table tr td").removeAttr("style");
   $(this).find("a").css({color:"#FFF"});
   $(this).css({background:"#ffbf69"});
   
   }) });
   
   //地区鼠标点击事件
    $("#divProvinceRegion table tr td").each(function(i){ $(this).click(function(){
    //所选地区
    $("#ahrefregionname").html($(this).find("a").html());//改变所选地区
     $("#divProvinceRegion").hide();
    //没有启用模板或者为空的时候
    if(feetemplateId==""||feetemplateId=="0")
    {
         return;
    }
   
    $("#spanFee").html("<span style='color:red;font-size:12px;'>读取中...</span>");//物流费用等待中显示的信息
      provCode=$(this).find("a").attr("code");
       params = {"code":provCode,"yz":"shopnum1ntbl","path":shoppath,"feetemplateid":feetemplateId,"type":"fee"}; 
        $.getJSON("/Main/Api/shopfeetemplate.ashx",params,function(json){
          
             if(json!=null)
             {
       
                 var spanCon="";
                 var spanfeetemp1="";
                 var spanfeetemp2="";
                 var spanfeetemp3="";
                for(var j=0;j<json.length;j++)
                {
                   //平邮
                   if(json[j].feetype==1)
                   {
                     spanfeetemp1="<span style='font-size:12px;'> 平邮 </span>"+"<span> "+json[j].fee+" </span>";
                   }
                   //快递
                   else if(json[j].feetype==2)
                  {
                   spanfeetemp2="<span style='font-size:12px;'> 快递 </span>"+"<span> "+json[j].fee+" </span>";
                  }
                  //ems
                  else if(json[j].feetype==3)
                  {
                     spanfeetemp3="<span style='font-size:12px;'> EMS </span>"+"<span> "+json[j].fee+" </span>";
                  }
                }
                spanCon=spanfeetemp1+spanfeetemp2+spanfeetemp3;
               if(spanCon!="")
               {
                 $("#spanFee").html(spanCon);
               }
               else
               {
                $("#spanFee").html(spanallfee);
               }
                
             }
             else
             {
             $("#spanFee").html(spanallfee);
             } 
             });
        
        
        
    })
    });
  
      //全国默认物流
      spanallfee="";
     var feetemplateId=$("#shopFeeTemplateHidden").val();//物流模板id
     var havefeetemplate=false;
   //根据地区读取 对应的邮费
   if(feetemplateId!="0"&&feetemplateId!="")
   {
  $("#spanFee").html("<span style='color:red;font-size:12px;'>读取中...</span>");//物流费用等待中显示的信息
    
    }
    
    var shoppath='<%=ShopUrlOperate.GetShopPath() %>';//店铺路径
    
    var ycity='<%=ShopUrlOperate.GetUserCity() %>';
    var vcity1=$.trim(ycity).substring(0,2);

   $("#divProvinceRegion table tr td a").each(function(i){
     
       
    if($.trim($(this).html()).substring(0,2)==vcity1)
    {
       
       
       $("#ahrefregionname").html($(this).html());//设置当前地区
        //店铺模板为空的时候 
        if(feetemplateId==""||feetemplateId=="0")
        {
           return;
        }
        ///开始计算当前地区的邮费
         var provCode=$(this).attr("code");  //地区code
         params = {"code":provCode,"yz":"shopnum1ntbl","path":shoppath,"feetemplateid":feetemplateId,"type":"fee"}; 
         $.getJSON("/Main/Api/shopfeetemplate.ashx",params,function(json){
           
           $("#spanFee").html(spanallfee);//当前物流费用
             if(json!=null)
             {
               
                 var spanCon="";
                 var spanfeetemp1="";
                 var spanfeetemp2="";
                 var spanfeetemp3="";
                for(var j=0;j<json.length;j++)
                {
                   //平邮
                   if(json[j].feetype==1)
                   {
                     spanfeetemp1="<span style='font-size:12px;'> 平邮 </span>"+"<span> "+json[j].fee+" </span>";
                   }
                   //快递
                   else if(json[j].feetype==2)
                  {
                   spanfeetemp2="<span style='font-size:12px;'> 快递 </span>"+"<span> "+json[j].fee+" </span>";
                  }
                  //ems
                  else if(json[j].feetype==3)
                  {
                     spanfeetemp3="<span style='font-size:12px;'> EMS </span>"+"<span> "+json[j].fee+" </span>";
                  }
                }
                spanCon=spanfeetemp1+spanfeetemp2+spanfeetemp3;
               if(spanCon!="")
               {
                 $("#spanFee").html(spanCon);
                 havefeetemplate=true;
                // spanallfee=spanCon;//存储
               }
                
             } 
             });
        return;
    }
     
   });
   //如果当前地区没有物流费用就取全国的物流
   if(!havefeetemplate)
   {
      if(feetemplateId==""||feetemplateId=="0")
     {
           return;
     }
     else
     {
       ///取全国物流
         params = {"code":"000","yz":"shopnum1ntbl","path":shoppath,"feetemplateid":feetemplateId,"type":"fee"}; 
         $.getJSON("/Main/Api/shopfeetemplate.ashx",params,function(json){
           
           
             if(json!=null)
             {
                
                 var spanCon="";
                 var spanfeetemp1="";
                 var spanfeetemp2="";
                 var spanfeetemp3="";
                for(var j=0;j<json.length;j++)
                {
                   //平邮
                   if(json[j].feetype==1)
                   {
                     spanfeetemp1="<span style='font-size:12px;'> 平邮 </span>"+"<span> "+json[j].fee+" </span>";
                   }
                   //快递
                   else if(json[j].feetype==2)
                  {
                   spanfeetemp2="<span style='font-size:12px;'> 快递 </span>"+"<span> "+json[j].fee+" </span>";
                  }
                  //ems
                  else if(json[j].feetype==3)
                  {
                     spanfeetemp3="<span style='font-size:12px;'> EMS </span>"+"<span> "+json[j].fee+" </span>";
                  }
                }
                spanCon=spanfeetemp1+spanfeetemp2+spanfeetemp3;
               if(spanCon!="")
               {
                 $("#spanFee").html(spanCon);
                 //全国默认物流
                 spanallfee=spanCon;
             
                // spanallfee=spanCon;//存储
               }
                
             } 
             });
     }
   }
    
    
 
 
 }); 
</script>

<script type="text/javascript">

var imgmultbf="";//多图备份
$(document).ready(function(){

$(".product_size").mouseout(function(){ $(this).removeAttr("style"); })
$(".product_size").mouseover(function(){$(".product_size").attr("style","border:1px solid #fcbb29;background:#FFF3D9;")});

$(".product_size_session ul li").not(".litit").each(function(i){ $(this).click(function()
{ 
    
   $(this).siblings().not(".litit").children("img").remove();
   $(this).siblings().not(".litit").removeAttr("class");
   $(this).attr("class","liselect");
   $(this).append($("<img class=\"sico\" src=\"Themes/Skin_Default/Images/ii1.gif\" />"));
   $("#divnoSelect").hide();
   $("#divSelect").show();
   var spenames="";
   var isselect=0; //规格选择的个数
   var prodspec="";//选择的规格值（所有已勾选的规格值）
   var nowprodspec="";//当前选择的规格值
   var prodguid=$("#ProductDetail_ctl00_HiddenFieldGuid").val();  //商品guid
   var memloginid=$("#ProductDetail_ctl00_HiddenFieldMemloginID").val();//会员loginid
   if(imgmultbf=="")
   {
    imgmultbf=$("#spec-list").html();//多图备份
    }
   //开始处理多图
     nowprodspec=$(this).attr("spc");
     params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":memloginid,"spec":nowprodspec,"type":"img"}; 
      $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
     
             if(json[0].imgsrc!=null)
             {

            $(".list-h li").remove();
            $.each(json,function(i){$(".list-h").append($("<li></li>").append($("<img />").css({width:"50px",height:"50px"}).attr("src",json[i].imgsrc)))});

				
             }
             else
             {
  
              $("#spec-list").html(imgmultbf);

             }
             $("#spec-list img").bind("mouseover",function(){
					var src=$(this).attr("src");
					$("#spec-n1 img").eq(0).attr({
						src:src.replace("\/n5\/","\/n1\/"),
						jqimg:src.replace("\/n5\/","\/n0\/")
					});
					$(this).css({
						"border":"2px solid #ff6600",
						"padding":"1px"
					});
				}).bind("mouseout",function(){
					$(this).css({
						"border":"1px solid #ccc",
						"padding":"2px"
					});
				});	
             });
   //处理多图结束
   //开始处理其它效果
   var juls=$(".product_size_session ul")  
    juls.each(function(i){
     if($(this).children(".liselect").length==1)
     {
       isselect++;
       spenames+="\""+$(this).children(":first-child").find("span").html()+"\""+"  ";
       prodspec=prodspec+$(this).children(".liselect").attr("spc")+";";
       
       // 添加的
       document.getElementById('<%=HiddenFieldGuiGe.ClientID %>').value=prodspec;
     }
  
     });
     $("#divSelect .selected").html(spenames)  //选择了
    //开始处理商品库存
    if(juls.length==isselect)
    {
     
       prodspec=prodspec.substring(0,prodspec.length-1);
       params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":memloginid,"spec":prodspec,"type":"prodspec"}; 
       $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
             if(json!=null)
             {

               $("#ProductDetail_ctl00_RepeaterData_ctl00_LabelShopPrice").text(json[0].price);//商品价格
               $("#ProductDetail_ctl00_RepeaterData_ctl00_LabelRepertoryCount").text(json[0].RepertoryCount);//库存
             } });

     }
     
     
     });})});

function  checkSubmit()  //检查数量
{

 ///检查库存
 var buyNum=$("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val();
 var numyz=/^[0-9]{1,9}$/;
if(!numyz.exec(buyNum))
{
   alert("购买数量格式不正确!")
   $("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").get(0).focus();
   return false;
}
 var allcout=$("#ProductDetail_ctl00_RepeaterData_ctl00_LabelRepertoryCount").text();
 if(parseInt(buyNum)>=parseInt(allcout))
 {
   alert("库存不足!")
   return false;
 }
 
 //检查规格
 var juls=$(".product_size_session ul")  
 var spenames="";
    juls.each(function(i){
     if($(this).children(".liselect").length==0)
     {

       spenames+="\""+$.trim($(this).children(":first-child").find("span").text())+"\""+" ";
      //  prodspec=prodspec+$(this).children(".liselect").attr("spc")+";";
     }
  
     });
 if(spenames!="")
 {
   alert("请选择  "+spenames);
   return false;
 }
 
}

</script>

<div class="detail">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="DetailImage">
                <table>
                    <tr>
                        <td colspan="2" style="height: 22px;">
                            <span style="color: #010101; font-size: 16px; padding-left: 8px; font-weight: bold;
                                height: 28px; line-height: 28px;">
                                <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td rowspan="10">
                                        <div id="preview" style="margin-bottom: 0px;">
                                            <div id="spec-n1" class="jqzoom">
                                                <img id="ProductImgurl" runat="server" src='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>'
                                                    width="310" height="310" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'"
                                                    jqimg='<%# Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())%>' /></div>
                                            <div style="clear: both;">
                                            </div>
                                            <div id="spec-n5" class="tb_thumb">
                                                <div class="control" id="spec-left">
                                                </div>
                                                <div class="control" id="spec-right">
                                                </div>
                                                <div class="tb_gallery">
                                                    <ul>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="#">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="#">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="#">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                        <li class="tb_diply tb_selected">
                                                            <div class="tb_pic tb_stn">
                                                                <a href="#">
                                                                    <img src="Themes/Skin_Default/Images/potu2.jpg" /></a></div>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <%--<div id="spec-list">
                                                    <ShopNum1Shop:ProductMultiImage ID="ProductMultiImage" runat="server" SkinFilename="ProductMultiImage.ascx" />
                                                </div>--%>
                                            </div>
                                        </div>
                                        <asp:Literal ID="LiteralShopName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ShopName"]%>'
                                            Visible="false"></asp:Literal>
                                        <asp:Literal ID="LiteralMemLoginID" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%>'
                                            Visible="false"></asp:Literal>
                                    </td>
                                    <!--邮递-->
                                    <td>
                                        <asp:Label ID="LabelFeeType" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["FeeType"]%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="rtrict_cont">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="padding-left: 20px; height: 22px;">
                                        <span class="enshrine"><a href="#">收藏该商品</a></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px; height: 22px;">
                                        <span style="width: 150px;">市 场 价：</span><span style="font-size: 14px;"><b class="jg_mark">￥<asp:Label
                                            ID="LabelMarketPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>'></asp:Label></b>元</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px; height: 22px;">
                                        <span style="width: 150px;">本 店 价：</span><strong><b class="jg_store">￥<asp:Label
                                            ID="LabelShopPrice" runat="server" Text=' <%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>'></asp:Label></b></strong>
                                    </td>
                                </tr>
                                <tr id="cellFee1" runat="server">
                                    <td style="padding-left: 20px;">
                                        <span style="color: #3C3C3C; width: 150px;">运&nbsp;&nbsp;&nbsp;&nbsp;费：</span><span
                                            style="color: #D40000; font-size: 13px;"><asp:Label ID="Label1" runat="server" Text=' <%# ProductDetail.IsFeeType(((DataRowView)Container.DataItem).Row["FeeType"])+"承担"%>'></asp:Label></span>
                                    </td>
                                </tr>
                                <tr id="cellFee2" runat="server">
                                    <td style="padding-left: 20px; height: 40px;">
                                        <span style="width: 150px;">配&nbsp;&nbsp;&nbsp;&nbsp;送：</span> <span class="area_tn"
                                            style="font-size: 12px;">至<span><a href="javascript:ShowHideRegion('show')" id="ahrefregionname">全国</a>
                                                <img src="Themes/Skin_Default/Images/dp_bg.png" alt="xl" onclick="javascript:ShowHideRegion('show')" />
                                            </span>
                                            <div id="divProvinceRegion" style="display: none; position: absolute; border: 2px solid #ffbf69;
                                                width: 265px; height: 230px; height: 245px\9; _height: 230px; background: #fdffee;
                                                z-index: 3; font-size: 12px; text-align: center; _margin-left: -65px; _margin-top: 20px;
                                                cursor: pointer;">
                                                <table width="100%" height="200" border="0" cellspacing="5" cellpadding="0">
                                                    <tr>
                                                        <td style="background: #ffbf69">
                                                            <a href="javascript:void(0)" style="color: #FFF;" title="所有地区" code="000">全国</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="北京市" code="001">北京</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="天津市" code="002">天津</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="河北省" code="003">河北</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="山西省" code="004">山西</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="内蒙古区" code="005">内蒙古</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="辽宁省" code="006">辽宁</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="吉林省" code="007">吉林</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="黑龙江省" code="008">黑龙江</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="上海市" code="009">上海</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="江苏省" code="010">江苏</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="浙江省" code="011">浙江</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="安徽省" code="012">安徽</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="福建省" code="013">福建</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="江西省" code="014">江西</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="山东省" code="015">山东</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="河南省" code="016">河南</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="湖北省" code="017">湖北</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="湖南省" code="018">湖南</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="广东省" code="019">广东</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="广西区" code="020">广西</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="海南省" code="021">海南</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="重庆市" code="022">重庆市</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="四川省" code="023">四川</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="贵州省" code="024">贵州</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="云南省" code="025">云南</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="西藏区" code="026">西藏</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="陕西省" code="027">陕西</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="甘肃省" code="028">甘肃</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="青海省" code="029">青海</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="宁夏区" code="030">宁夏</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="新疆区" code="031">新疆</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" title="台湾省" code="032">台湾</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="香港特区" code="033">香港</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="澳门特区" code="034">澳门</a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" title="海外" code="035">海外</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <input type="hidden" id="shopFeeTemplateHidden" value="<%#((DataRowView)Container.DataItem).Row["FeeTemplateID"]%>" />
                                            </div>
                                        </span><span id="spanFee" class="stamp_tn">
                                            <asp:Label ID="LabelPost" runat="server" Text='平邮' Visible="false"></asp:Label>
                                            <asp:Label ID="LabelPost_Fee" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Post_fee"]%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="LabelExpress" runat="server" Text='快递' Visible="false"></asp:Label>
                                            <asp:Label ID="LabelExpress_fee" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Express_fee"]%>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="LabelEms" runat="server" Text='EMS' Visible="false"></asp:Label>
                                            <asp:Label ID="LabelEms_fee" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Ems_fee"]%>'
                                                Visible="false"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td style="padding-left: 20px;">
                                        <span style="color: #3C3C3C; font-size: 12px; width: 150px;">购物返积分：</span><span style="color: #D40000;
                                            font-size: 13px;">
                                            <%# string.IsNullOrEmpty(((DataRowView)Container.DataItem).Row["Socre"].ToString()) == true ? "0" : ((int)(decimal.Parse(((DataRowView)Container.DataItem).Row["Socre"].ToString()) * decimal.Parse(Eval("ShopPrice").ToString())) / 100).ToString()%></span>分/<%# Eval("UnitName")%>
                                        <span style="color: #3C3C3C; font-size: 12px; width: 150px;">单 &nbsp;&nbsp; 位</span>：
                                        <%# Eval("UnitName")%>
                                        <asp:Label ID="LabelShopName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ShopName"]%>'
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="stock">
                                        <span class="rerve">库&nbsp;&nbsp;&nbsp;&nbsp;存：</span>
                                        <asp:Label ID="LabelRepertoryCount" CssClass="storage" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["RepertoryCount"]%>'></asp:Label>件
                                        <asp:Label ID="Label2" runat="server" Text='<%#  Eval("UnitName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="padding-left: 20px;">
                                        <span style="color: #3C3C3C; font-size: 12px; width: 150px;">产品型号：</span>
                                        <asp:Label ID="Label6" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ProductNum"]%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px; height: 34px;">
                                        <span>浏览次数：</span><span class="scan">10000</span>次
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px; height: 26px;">
                                        <span>收&nbsp;&nbsp;&nbsp;&nbsp;藏：</span> <span class="stow">
                                            <%# ((DataRowView)Container.DataItem).Row["CollectCount"]%></span>次
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px; height: 26px;">
                                        <span>总&nbsp;销&nbsp;量：</span> <span class="tovole">1000</span>件
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px;">
                                    </td>
                                </tr>
                                <!-- 商品规格 -->
                                <tr>
                                    <td>
                                        <asp:Repeater ID="RepeaterProductSepc" runat="server" EnableViewState="false">
                                            <HeaderTemplate>
                                                <div class="product_size">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="product_size_session">
                                                    <ul>
                                                        <li class="litit"><span style="color: #3C3C3C; font-size: 12px;">
                                                            <%#((DataRowView)Container.DataItem).Row["SpecificationName"]%></span>：</li>
                                                        <asp:Repeater ID="RepeaterProductSepcDetail" runat="server" EnableViewState="false">
                                                            <ItemTemplate>
                                                                <li spc='<%#((DataRowView)Container.DataItem).Row["SpecDetail"]%>'><a href="javascript:void(0)">
                                                                    <%#((DataRowView)Container.DataItem).Row["Name"]%></a></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div id="divnoSelect" style="clear: both; padding-top: 6px; padding-top: 0px\9;">
                                                    <span style="font-weight: bold; clear: both;">请选择</span>：<span id="spanNoSelect"
                                                        style="font-weight: bold; clear: both;" runat="server">"颜色" </span>
                                                </div>
                                                <div id="divSelect" style="clear: both; display: none;">
                                                    <span style="font-weight: bold; clear: both;">已选择</span>：<span class="selected"></span></div>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px;">
                                        <div class="restrict sold_out">
                                        此商品已下架<span class="sold_mak">（<b></b>）</span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 20px;">
                                        <asp:Button ID="ButtonBuy" runat="server" title="立刻购买" CssClass="bnt_buynow downself"
                                            OnClientClick="return checkSubmit()" />
                                        <asp:Button ID="ButtonShopCar" runat="server" title="加入购物车" CssClass="bnt_addcart"
                                            OnClientClick="return checkSubmit()" />
                                        <asp:Button ID="ButtonCollect" runat="server" title="加入收藏" CssClass="bnt3" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <asp:Repeater ID="RepeaterDateImage" runat="server" Visible="false">
                        <ItemTemplate>
                            <img id="Img1" runat="server" src='<%# ((DataRowView)Container.DataItem).Row["imgurl"] %>'
                                width="100" height="100" />
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="clear: both;">
                </div>
            </div>
            <asp:Literal ID="LiteralIsReal" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["IsReal"] %>'
                Visible="false"></asp:Literal>
            <asp:Literal ID="LiteralProductNum" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ProductNum"] %>'
                Visible="false"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMemloginID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldGuiGe" runat="server" Value="0" />
</div>
