//Jely 20130722整合js
 document.write('<script type="text/javascript" language="javascript" src="/js/jquery.cookie.js"></script>');
    if (top.location != location) top.location.href = location.href;
Date.prototype.Format = function(fmt)   
{ //author: meizz   
  var o = {   
    "M+" : this.getMonth()+1,                 //月份   
    "d+" : this.getDate(),                    //日   
    "h+" : this.getHours(),                   //小时   
    "m+" : this.getMinutes(),                 //分   
    "s+" : this.getSeconds(),                 //秒   
    "q+" : Math.floor((this.getMonth()+3)/3), //季度   
    "S"  : this.getMilliseconds()             //毫秒   
  };   
  if(/(y+)/.test(fmt))   
    fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));   
  for(var k in o)   
    if(new RegExp("("+ k +")").test(fmt))   
  fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));   
  return fmt;   
}  

function show_date_time(time, element){
window.setTimeout("show_date_time('"+time+"','"+element+"')", 1000);     
//AJAX获取服务器数据
//因程序执行耗费时间,所以时间并不十分准确,误差大约在2000毫秒以下
var xmlHttp = false;
//获取服务器时间
try {xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");} catch (e) {
try {xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");} catch (e2) {xmlHttp = false;}
}
if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
    xmlHttp = new XMLHttpRequest();
}
xmlHttp.open("GET", "/Api/newtime.txt?date=r"+Math.random, false);
xmlHttp.setRequestHeader("Range", "bytes=-1");
xmlHttp.send(null);
var pdate=new Date(xmlHttp.getResponseHeader("Date"));
var severtime = new Date(xmlHttp.getResponseHeader("Date"));//服务器时间
BirthDay = new Date(time);
today=new Date(severtime); 
timeold=(BirthDay.getTime()-today.getTime()); 
sectimeold=timeold/1000 
secondsold=Math.floor(sectimeold); 
msPerDay=24*60*60*1000 
e_daysold=timeold/msPerDay 
daysold=Math.floor(e_daysold); 
e_hrsold=(e_daysold-daysold)*24; 
hrsold=Math.floor(e_hrsold); 
e_minsold=(e_hrsold-hrsold)*60; 
minsold=Math.floor((e_hrsold-hrsold)*60); 
seconds=Math.floor((e_minsold-minsold)*60);  
  if(daysold<0)
    {
     document.getElementById(element).innerHTML="0天0小时0分0秒"+txt;
    } else{
document.getElementById(element).innerHTML=daysold+"天"+hrsold+"小时"+minsold+"分"+seconds+"秒"+txt;
}
}

$(function(){
        $("input[name='hidProductImg']").each(function(){
                if($(this).val()!="")
                {
                   $(this).parent().find("span").html("<img src=\""+$(this).val()+"_25x25.jpg\" lang=\""+$(this).val()+"\" alt=\""+$(this).parent().find("input[name='hidSpecValueName']").val()+"\" width=\"25px;\" height=\"25px\"/>");
                }else{
                   if($(this).parent().find("input[name='hidImgPath']").val()!=""){
                     $(this).parent().find("span").html("<img src=\""+$(this).parent().find("input[name='hidImgPath']").val()+"\" alt=\""+$(this).parent().find("input[name='hidSpecValueName']").val()+"\" width=\"25px;\" height=\"25px\"/>"); 
                   }
                   else{
                        $(this).parent().find("span").html($(this).parent().find("input[name='hidSpecValueName']").val());
                   }  
                }
        });

    
    //加
    $(".increase").click
    (function()
        {
            var BuyNum=parseInt($(TextBoxBuyNum).val());//购买数量
            $(TextBoxBuyNum).val(BuyNum+1)
        }
    );
    //减
    $(".decrease").click
    (
            function()
            {
                var BuyNum=parseInt($(TextBoxBuyNum).val());//购买数量
                if(BuyNum>1)
                {
                    $(TextBoxBuyNum).val(BuyNum-1)
                }
            }
     );
     
     $(TextBoxBuyNum).keyup(function(){
            $(this).val($(this).val().replace(/\D/g,''));
            if($(this).val()=="")
            {
               $(this).val("1");
            }
     });
///////////////////////<!--购买数量加减-->////////////////////////
			   $(".jqzoom").jqueryzoom({
					xzoom:400,
					yzoom:400,
					offset:10,
					position:"right",
					preload:1,
					lens:1
				});
				$("#tb_gallery").jdMarquee({
					deriction:"left",
					width:300,
					height:67,
					step:2,
					speed:4,
					delay:10,
					control:true,
					_front:"#spec-right",
					_back:"#spec-left"
				});
				$("#tb_gallery img").bind("mouseover",function(){
					var src=$(this).attr("lang");
					var NormalImg=src;
					if(src.indexOf("_300x300")==-1)
					    src+="_300x300.jpg";
					$("#spec-n1 img").eq(0).attr({
						src:src.replace("\/n5\/","\/n1\/"),
						jqimg:NormalImg.replace("\/n5\/","\/n0\/")
					});
					$(this).parent().parent().parent().addClass("tb_selected");
				}).bind("mouseout",function(){
		            $(this).parent().parent().parent().removeClass("tb_selected");
				});	
		

		
		var imgmultbf="";//多图备份
$(".b_colse").click(function(){  $("#loginbox").hide();});
$(".restrict ul li").not(".litit").each(function(i){ $(this).click(function()
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
   var prodguid=$(HiddenFieldGuid).val();  //商品guid
   var memloginid=$(hidMemloginId).val();//会员loginid
   if(imgmultbf=="")
   {
        imgmultbf=$("#tb_gallery").html();//多图备份
    }
   //开始处理多图
     nowprodspec=$(this).attr("spc");
     var specvx=$(this).attr("spcv");
     params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":escape(memloginid),"spec":escape(specvx),"type":"img"}; 
      $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
             if(json[0].imgsrc!=null)
             {
                   //绑定选择规格后的大图
                    $("#ProductImgurl").attr("src",""+json[0].imgsrc+"_300x300.jpg");
                    $("#ProductImgurl").attr("jqimg",""+json[0].imgsrc.replace("s_","")+"_300x300.jpg");
            }
            else{$("#tb_gallery").html(imgmultbf);}
			$("#tb_gallery img").bind("mouseover",function(){
				var src=$(this).attr("lang");
				var NormalImg=src;
			    if(src.indexOf("_300x300")==-1)
					    src+="_300x300.jpg";
				$("#spec-n1 img").eq(0).attr({
					src:src.replace("\/n5\/","\/n1\/"),
					jqimg:NormalImg.replace("\/n5\/","\/n0\/")
				});
				$(this).parent().parent().parent().addClass("tb_selected");
			}).bind("mouseout",function(){
	            $(this).parent().parent().parent().removeClass("tb_selected");
			});	
        });
   //处理多图结束
   //开始处理其它效果
   try{
   var prodspecv="",prodspecvalue="";
   var juls=$(".restrict ul");
    juls.each(function(i){
    if($(this).children("li").hasClass("liselect"))
        {
           isselect++;
           spenames+="\""+$(this).children(".liselect").find("span").html()+"\""+"  ";
           prodspecv=prodspecv+$(this).children(".liselect").attr("spcv")+";";
           prodspecvalue=prodspecvalue+$(this).children(".liselect").attr("specvalue")+";";
           prodspec=prodspec+$(this).children(".liselect").attr("spc")+";";
           // 添加的
           $(HiddenFieldGuiGev).val(prodspecv); $(HiddenFieldSpecName).val(prodspecvalue); $(HiddenFieldGuiGe).val(prodspec);
         }
  
     });}catch(e){alert(e);}
     $("#divSelect .selected").html(spenames);  //选择了
    //开始处理商品库存
    var saletype=$(hidSaleType).val();
    if(juls.length==isselect&&saletype!=1)
    {
       prodspecv=prodspecv.substring(0,prodspecv.length-1);
       params = {"prodguid":prodguid,"yz":"shopnum1ntbl","loginid":escape(memloginid),"spec":escape(prodspecv),"type":"prodspec"}; 
       $.getJSON("/Main/Api/shopproductspec.ashx",params,function(json){
             if(json!=null)
             {
                    var discount=$(hidDisCount).val();
                    if(discount!="")
                    {
                        $(lblPromotionPrice).text(price_format(json[0].price*discount,2));
                    }
                   $(LabelShopPrice).text(price_format(json[0].price,2));//商品价格
                   $(LabelRepertoryCount).text(json[0].RepertoryCount);//库存
             } 
        });
     }
 });})});
	  ///////////////////////////////////////////物流JS//////////////////////////////////////////////////////////
    function  checkSubmit(num)  //点击立刻购买时候检查参数是否正确
    {
         ///检查库存
         var buyNum=$(TextBoxBuyNum).val();
         var allcout=$(LabelRepertoryCount).text();
         if(parseInt(buyNum)>parseInt(allcout))
         {
               alert("库存不足!")
               return false;
         }
         //检查规格
         var juls=$(".restrict .tb_prop dt");
         var spenames="";
        juls.each(function(i){
         if($(this).next().find(".liselect").length==0)
         {
           spenames+="\""+$.trim($(this).text())+"\""+" ";
         }
     });
     if($(hidSaleType).val()=="4"&&parseInt(buyNum)>1)
     {
        alert("抢购商品一个用户只能购买一件!");return false;
     }
     if(spenames!="")
     {
        alert("请选择 "+spenames);
        return false;
     }
     var numyz=/^[0-9]{1,9}$/;
     if(!numyz.exec(buyNum))
     {
        $(TextBoxBuyNum).val("1")
        $(TextBoxBuyNum).get(0).focus();
        return false;
     }
     $("#hidgotoId").val(num);
     return loadLogin();
}
function checkSpec()
{
    ///检查库存
         var buyNum=$(TextBoxBuyNum).val();
         var allcout=$(LabelRepertoryCount).text();
         if(parseInt(buyNum)>parseInt(allcout))
         {
               alert("库存不足!")
               return false;
         }
         //检查规格
         var juls=$(".restrict .tb_prop dt");
         var spenames="";
        juls.each(function(i){
         if($(this).next().find(".liselect").length==0)
         {
           spenames+="\""+$.trim($(this).text())+"\""+" ";
         }
     });
     if(spenames!="")
     {
        alert("请选择 "+spenames);
        return false;
     }
     return true;
}
function loadLogin()
{
   if($("#hidlogin").val()=="0")
   {  
      $('#loginbox').attr("style","display:block");$('#mylogingo').attr('src',locurl);return false;
   }else{return true;}
}
//加载商品详细数据
function loadDetailData()
{
      $.get("/Api/Shop/shopProductDetail.ashx?vtype=getComment&guid="+$("#hidProductGuID").val(),null,function(data){
                        if(data!="")
                        {
                            var NewHtml=new Array();
                            var vdata=eval('('+data+')');
                            $.each(vdata,function(m,n){
                                  NewHtml.push(setCommentList(n));
                            });
                            $("#MessageBoxList").html(NewHtml.join(""));
                        }
        });
        $.get("/Api/Shop/shopProductDetail.ashx?vtype=showOrderlist&guid="+$("#hidProductGuID").val(),null,function(data){
                        if(data!="")
                        {
                            var NewHtml=new Array();
                            var vdata=eval('('+data+')');
                            $.each(vdata,function(m,n){
                                  NewHtml.push(setOrderList(n));
                            });
                            $("#showorderlist").html(NewHtml.join(""));
                        }
        });
}
$(function(){
      var bflag=true;
      //屏幕滚动显示
      $(window).scroll(function (){ 
           var menuYloc = $(window).scrollTop(); 
           if(menuYloc>200)
           {
                if(bflag)
                {
                    bflag=false;loadDetailData();//加载商品详细Ajax数据
                }
            }
      });
      $(".commentSubmit").live("click",function(){
	    var showtxt=$(this).parent().parent().parent().find("textarea").val();
            if(showtxt.length>200&showtxt.length<5)
            {
                 alert("留言内容不能超过200个字符且不能小于5个字符!");return false;
            }
            else
            {
		 var t_this=$(this).parent().parent().parent();
                 $.get("/Api/Shop/shopProductDetail.ashx?vtype=addComment&guid="+$("#hidProductGuID").val()+"&comment="+escape(showtxt.trim()),null,function(data){
                        if(data=="empty")
                        {
                            alert("对不起,您需要登录后才能留言!");loadLogin(); window.scrollTo(0,0);
                        }
                        else if(data=="common")
                        {
                           alert("不能对自己的商品进行留言!");return false;
                        }
                        else
                        {
try{
                            alert("留言成功!");window.location.reload(true); window.scrollTo(0,500);t_this.find("textarea").val("");}catch(e){alert(e);}
                        }
                 });
            }
    });
});
function setOrderList(data)
{
     var xhtml=new Array();
     xhtml.push('<table cellpadding="0" cellspacing="1" width="100%" class="OrderRecord_con">');
     xhtml.push('<tr>');
     xhtml.push('<td align="left" width="20%">');
     xhtml.push('   '+data.memloginid==""?"匿名":data.memloginid+'');
     xhtml.push('</td>');
     xhtml.push('<td align="left" width="30%">');
     xhtml.push('  '+data.productname+'');
     xhtml.push('   <br />');
     xhtml.push('  '+data.specificationname+'');
     xhtml.push('</td>');
     xhtml.push('<td align="left" width="10%">');
     xhtml.push('  '+data.shopprice+'元');
     xhtml.push('</td>');
     xhtml.push('<td align="left" width="10%">');
     xhtml.push('  '+data.buynumber+'');
     xhtml.push('</td>');
     xhtml.push('<td align="left" width="20%">');
     xhtml.push('   '+data.paytime+'');
     xhtml.push('</td>');
     xhtml.push('</tr>');
     xhtml.push('</table>');
     return xhtml.join("");
}
function setCommentList(data)
{
       var xhtml=new Array();
       xhtml.push('<div class="desc_list">');
       xhtml.push('     <div class="desc_list_top">');
       xhtml.push('         <div class="desc_name fl">留言人：'+data.consultpeople+'</div>');
       xhtml.push('         <div class="desc_date fr">'+data.sendtime+'</div>');
       xhtml.push('     </div>');
       xhtml.push('     <div class="desc_list_pl">');
       xhtml.push('         【留言内容】：'+data.content+'');
       xhtml.push('         <div class="glyhf">');
       xhtml.push('             <img alt="回复" src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />');
       xhtml.push('             '+data.replycontent+'&nbsp;&nbsp;&nbsp;&nbsp;'+data.replytime+'');
       xhtml.push('         </div>');
       xhtml.push('     </div>');
       xhtml.push(' </div>');
       return xhtml.join("");
}
//////////////////////邮费相关////////////////////////////////////////////////
$(function(){
//浏览记录 写入JSCookied    开始
    var img=$("#ProductImgurl").attr("jqimg");
    var name=$("#ProductDetail_ctl00_LabelName").text();
    var url=location.href;
    var price=$("#ProductDetail_ctl00_LabelShopPrice").text();
    var sellcount=$("#ProductDetail_ctl00_lblSaleNumber").text();
    var hc=img+"|"+name+"|"+url+"|"+price+"|"+sellcount;
try{
    var urlhost=document.location.host.split(".");
    if(urlhost.length>=3)
       urlhost="."+urlhost[2]+"."+urlhost[3];
    else
       urlhost=document.location.host.substring(document.location.host.indexOf("."),document.location.host.length);
    if($.cookie("history")!=null)
    {
          if($.cookie("history").indexOf(name)==-1)
          {
             $.cookie("history",hc+"*"+$.cookie("history"),{expires:8,domain:urlhost,path:"/"}); 
          }
    }
    else
    {
          $.cookie("history",hc,{expires:8,domain:urlhost,path:"/"});
    }}catch(e){alert(e);}
    //浏览记录 写入JSCookied    结束



 //如果是包邮就退出
 if(document.getElementById("ahrefregionname")==null) {return;}
 //绑定移除事件
   $("#divProvinceRegion").mouseout(function(){$(this).hide();$("#divProvinceRegion table tr td a").removeAttr("style");$("#divProvinceRegion table tr td a").parent().removeAttr("style");});
    $("#divProvinceRegion").mouseover(function(){$(this).show()});
    //地区鼠标移动事件
   $("#divProvinceRegion table tr td").each(function(i){ $(this).mouseover(function(){
    $("#divProvinceRegion table tr td a").removeAttr("style");
   $("#divProvinceRegion table tr td").removeAttr("style");
   $(this).find("s").css({display:"block"});
   $(this).find(".SubArea a").css({color:"#816957"});
   }) });
   $("#divProvinceRegion table tr td").each(function(i){ $(this).mouseout(function(){
    $(this).find("s").css({display:"none"});
   }) });
   $("#divProvinceRegion table tr td.other").each(function(i){ $(this).mouseover(function(){
    $(this).css({background:"none"});
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
     var feetemplateId=$("#ProductDetail_ctl00_hidFeeTemplate").val();//物流模板id
     var havefeetemplate=false;
   //根据地区读取 对应的邮费
   if(feetemplateId!="0"&&feetemplateId!="")
   {
        $("#spanFee").html("<span style='color:red;font-size:12px;'>读取中...</span>");//物流费用等待中显示的信息
    }
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
               }
             } 
             });
        return;
    }
     
   });
   //如果当前地区没有物流费用就取全国的物流
   if(!havefeetemplate)
   {
      if(feetemplateId==""||feetemplateId=="0"){return;}
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

               }
             } 
             });
     }
   }
 }); 
//配送显示隐藏		
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
//////////////////////邮费相关////////////////////////////////////////////////
//控制商品详细页面选项卡切换
function changeTab(count,index)
{
    for (var i = 1; i <= count; i++)
    {
     
      document.getElementById('content' + i).style.display ="none";
      document.getElementById("current" + i).className="";
    }
    if(index!="1")
        document.getElementById('content' + index).innerHTML=document.getElementById('tx' + index).innerHTML;
   document.getElementById('content' + index).style.display ="block";
   document.getElementById('current'+index).className="selected";
}

function price_format(num, ext){
    if(ext < 0){return num;}
    num = Number(num);
    if(isNaN(num)){num = 0;}
    var _str = num.toString();
    var _arr = _str.split('.');
    var _int = _arr[0];
    var _flt = _arr[1];
    if(_str.indexOf('.') == -1){
        /* 找不到小数点，则添加 */
        if(ext == 0){return _str;}
        var _tmp = '';
        for(var i = 0; i < ext; i++){ _tmp += '0'; }
        _str = _str + '.' + _tmp;
    }else{        if(_flt.length == ext){ return _str; }
        /* 找得到小数点，则截取 */
        if(_flt.length > ext){
            _str = _str.substr(0, _str.length - (_flt.length - ext));
            if(ext == 0){_str = _int;}
        }else{
            for(var i = 0; i < ext - _flt.length; i++){
                _str += '0';
            }
        }
    }
    return _str;
}

function resizepic(picObj)
{
	var defineScreenWidth = 1024;
	var defineScreenSideWidth = 42;

	var picWidth = parseInt(picObj.width);
	var picHeight = parseInt(picObj.height);
	var screenWidth = parseInt(window.screen.width);
	var screenHeight = parseInt(window.screen.height);

	var screenSideWidth = Math.ceil(screenWidth / defineScreenWidth * defineScreenSideWidth);

	var percent = (screenWidth - 2 * screenSideWidth) / picWidth;
	var picWidthResult = Math.floor(picWidth * percent);
	var picHeightResult = Math.floor(picHeight * percent);

	if(picObj.width > picWidthResult)
	{
		picObj.width = picWidthResult;
		picObj.height = picHeightResult;
	}
}
function NumTxt_Int(o)
{
   o.value=o.value.replace(/\D/g,'');
}

