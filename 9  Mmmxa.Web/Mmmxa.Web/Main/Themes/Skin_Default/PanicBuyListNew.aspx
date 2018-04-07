<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <ShopNum1:Meto ID="meto1" runat="server" Type="1" SkinFilename="Meto.ascx" />
    <link href="Themes/Skin_Default/Style/index.css" rel="stylesheet" type="text/css" />

    <script src="Themes/Skin_Default/Js/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
function show_date_time(time, element){
window.setTimeout("show_date_time('"+time+"','"+element+"')", 1000);
BirthDay = new Date(time);
today=new Date(); 
timeold=(BirthDay.getTime()-today.getTime()); 
sectimeold=timeold/1000 
secondsold=Math.floor(sectimeold); 
msPerDay=24*60*60*1000 
e_daysold=timeold/msPerDay 
daysold=Math.floor(e_daysold); //返回小于等于数字参数的最大整数
hrsold=Math.floor(e_hrsold); 
e_minsold=(e_hrsold-hrsold)*60; 
minsold=Math.floor((e_hrsold-hrsold)*60); 
seconds=Math.floor((e_minsold-minsold)*60);  
  if(daysold<0)
    {
     document.getElementById(element).innerHTML="0天0小时0分0秒";
    } else{
document.getElementById(element).innerHTML=daysold+"天"+hrsold+"小时"+minsold+"分"+seconds+"秒" ;
}
};


  var pageIndex1=1;
  var pageIndex2=1;
  var pageIndex3=1;
  var pageIndex4=1;
  var pageIndex5=1;
  var pageIndex6=1;
$(function(){
        separatePage1();
        separatePage2();
        separatePage3();
        separatePage4();
        separatePage5();
        separatePage6();
});
var ConfigJs={"pcode1":"004","pcode2":"002","pcode3":"003","pcode4":"009","pcode5":"008","pcode6":"007"};

function prevPage(obj)
{
   var code;
   var Vindex=$(obj).attr("lang");
   switch(Vindex)
   {
      case "1":code=ConfigJs.pcode1; break;
      case "2":code=ConfigJs.pcode2; break;
      case "3":code=ConfigJs.pcode3; break;
      case "4":code=ConfigJs.pcode4; break;
      case "5":code=ConfigJs.pcode5; break;
      case "6":code=ConfigJs.pcode6; break;
   }
        switch(code)
        {
            case ConfigJs.pcode1:
               if(pageIndex1<=1){return;}
               pageIndex1--;
               separatePage1();
            break;
            case ConfigJs.pcode2:
               if(pageIndex2<=1){return;}
               pageIndex2--;
               separatePage2();
            break;
            case ConfigJs.pcode3:
               if(pageIndex3<=1){return;}
               pageIndex3--;
               separatePage3();
            break;
            case ConfigJs.pcode4:
               if(pageIndex4<=1){return;}
               pageIndex4--;
               separatePage4();
            break;
            case ConfigJs.pcode5:
               if(pageIndex5<=1){return;}
               pageIndex5--;
               separatePage5();
            break;
            case ConfigJs.pcode6:
               if(pageIndex6<=1){return;}
               pageIndex6--;
               separatePage6();
            break;
         }

}
function nextPage(obj)
{
   var code;
   var Vindex=$(obj).attr("lang");
   switch(Vindex)
   {
      case "1":code=ConfigJs.pcode1; break;
      case "2":code=ConfigJs.pcode2; break;
      case "3":code=ConfigJs.pcode3; break;
      case "4":code=ConfigJs.pcode4; break;
      case "5":code=ConfigJs.pcode5; break;
      case "6":code=ConfigJs.pcode6; break;
   }
   
    switch(code)
    {
        case ConfigJs.pcode1:
            if(pageIndex1>=parseInt($("#lbPageCount1").text()))
            {
                   return;
            }
            else
            {
                   pageIndex1++;
                   separatePage1();       
            }
        break;
        case ConfigJs.pcode2:
           if(pageIndex2>=parseInt($("#lbPageCount2").text()))
            {
                   return;
            }
            else
            {
                   pageIndex2++;
                   separatePage2();       
            }
        break;
        case ConfigJs.pcode3:
           if(pageIndex3>=parseInt($("#lbPageCount3").text()))
            {
                   return;
            }
            else
            {
                   pageIndex3++;
                   separatePage3();       
            }
        break;
        case ConfigJs.pcode4:
           if(pageIndex4>=parseInt($("#lbPageCount4").text()))
            {
                   return;
            }
            else
            {
                   pageIndex4++;
                   separatePage4();       
            }
        break;
        case ConfigJs.pcode5:
           if(pageIndex5>=parseInt($("#lbPageCount5").text()))
            {
                   return;
            }
            else
            {
                   pageIndex5++;
                   separatePage5();       
            }
        break;
        case ConfigJs.pcode6:
           if(pageIndex6>=parseInt($("#lbPageCount6").text()))
            {
                   return;
            }
            else
            {
                   pageIndex6++;
                   separatePage6();       
            }
        break;
    }
}

         //分页
        function separatePage1() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode1+"&type=g&pageIndex=" + pageIndex1, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                        $("#divPageBar").show();
                        $("#divPanicList1").html(jsObj.data.PageData);
                        $("#lbTotalCount1").text(jsObj.data.RowCount);
                        $("#lbPageIndex1").text(jsObj.data.PageIndex);
                        $("#lbPageCount1").text(jsObj.data.PageCount);
                    }
                    else if(jsObj.statu == "noData"&&pageIndex1==1)
                    {
                        $("#divPageBar1").hide();
                    }
                    
                }
            });
        }
        
            function separatePage2() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode2+"&type=g&pageIndex=" + pageIndex2, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                       
                        $("#divPanicList2").html(jsObj.data.PageData);
                        $("#lbTotalCount2").text(jsObj.data.RowCount);
                        $("#lbPageIndex2").text(jsObj.data.PageIndex);
                        $("#lbPageCount2").text(jsObj.data.PageCount);
                    }
                    else if(jsObj.statu == "noData"&&pageIndex2==1)
                    {
                    $("#divPageBar2").hide();
                    }
                   
                    
                }
            });
        }
         function separatePage3() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode3+"&type=g&pageIndex=" + pageIndex3, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                        $("#divPanicList3").html(jsObj.data.PageData);
                        $("#lbTotalCount3").text(jsObj.data.RowCount);
                        $("#lbPageIndex3").text(jsObj.data.PageIndex);
                        $("#lbPageCount3").text(jsObj.data.PageCount);
                    }
                    else if(jsObj.statu == "noData"&&pageIndex3==1)
                    {
                        $("#divPageBar3").hide();
                    }
                }
            });
        }
        
           function separatePage4() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode4+"&type=g&pageIndex=" + pageIndex4, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                       
                        $("#divPanicList4").html(jsObj.data.PageData);
                        $("#lbTotalCount4").text(jsObj.data.RowCount);
                        $("#lbPageIndex4").text(jsObj.data.PageIndex);
                        $("#lbPageCount4").text(jsObj.data.PageCount);
                    }
                    else if(jsObj.statu == "noData"&&pageIndex4==1)
                    {
                    $("#divPageBar4").hide();
                    }
                   
                    
                }
            });
        }
        
          function separatePage5() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode5+"&type=g&pageIndex=" + pageIndex5, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                       
                        $("#divPanicList5").html(jsObj.data.PageData);
                        $("#lbTotalCount5").text(jsObj.data.RowCount);
                        $("#lbPageIndex5").text(jsObj.data.PageIndex);
                        $("#lbPageCount5").text(jsObj.data.PageCount);
                    }
                     else if(jsObj.statu == "noData"&&pageIndex5==1)
                    {
                        $("#divPageBar5").hide();
                    }
                    
                }
            });
        }
        
               
          function separatePage6() {
            $.ajax("Api/PanicProductOpreate.ashx", {
                type: "get", data: "categoryCode="+ConfigJs.pcode6+"&type=g&pageIndex=" + pageIndex6, dataType: "json",
                cache: false, success: function (jsObj) {
                    if (jsObj.statu == "ok") {
                       
                        $("#divPanicList6").html(jsObj.data.PageData);
                        $("#lbTotalCount6").text(jsObj.data.RowCount);
                        $("#lbPageIndex6").text(jsObj.data.PageIndex);
                        $("#lbPageCount6").text(jsObj.data.PageCount);
                    }
                    else if(jsObj.statu == "noData"&&pageIndex6==1)
                    {
                        $("#divPageBar6").hide();
                    }
                }
            });
        }



    </script>

    <style type="text/css">
        body
        {
            background: url(Themes/Skin_Default/Images/tuan_bg.png);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--head Start-->
    <!-- #include file="headShop.aspx" -->
    <!--//head End-->
    <!--main Start-->
    <div class="FlowCat_cont">
        <div class="article_cont">
            <div class="panic">
                <!--抢购幻灯-->
                <div class="panic_aa">
                    <div class="panic_adv">
                        <div id="focus" class="panic_focus">
                            <div id="Rleft">
                                <div id='ad9' runat='server'>
                                </div>
                                <ShopNum1:AdvertisementPPTStyle ID="AdvertisementPPTStyle1" runat="server" SkinFilename="AdvertisementPPT.ascx"
                                    AdID="ad9" AdType="2" />

                                <script src="Themes/Skin_Default/js/hp.js" type="text/javascript"></script>

                            </div>
                        </div>
                    </div>
                    <ShopNum1:PanicBuyNews ID="PanicBuyNews" ArticleCategoryID="154" ShowCount="4" SkinFilename="PanicBuyNews.ascx"
                        runat="server" />
                </div>
                <!--抢购1 美容珠宝专场-->
                <div class="panic_se">
                    <div class="panic_se_left_top">
                        <div class="psl_left">
                            美容珠宝专场</div>
                        <div class="psl_right" id="divPageBar1">
                            共<b class="totle"><label id="lbTotalCount1"></label></b>个商品 <b><span style="color: #ff6400;">
                                <label id="lbPageIndex1">
                                </label>
                            </span>/
                                <label id="lbPageCount1">
                                </label>
                            </b><a class="page_up_true" onclick="prevPage(this)" lang="1">上一页</a> <a class="page_down_true"
                                onclick="nextPage(this)" lang="1">下一页</a>
                        </div>
                    </div>
                    <div class="panic_cont">
                        <div class="panic_se_right">
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage16" runat="server" AdImgId="16" SkinFilename="AdSimpleImage.ascx" />
                        </div>
                        <div class="panic_se_left" id="divPanicList1">
                            <div class="clear">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!--抢购1 美容 珠宝专场-->
                <!--抢购2 服饰内衣-->
                <div class="panic_se">
                    <div class="panic_se_left_top">
                        <div class="psl_left">
                            服饰内衣专场</div>
                        <div class="psl_right" id="divPageBar2">
                            共<b class="totle"><label id="lbTotalCount2"></label></b>个商品 <b><span style="color: #ff6400;">
                                <label id="lbPageIndex2">
                                </label>
                            </span>/
                                <label id="lbPageCount2">
                                </label>
                            </b><a class="page_up_true" onclick="prevPage(this)" lang="2">上一页</a> <a class="page_down_true"
                                onclick="nextPage(this)" lang="2">下一页</a>
                        </div>
                    </div>
                    <div class="panic_cont">
                        <div class="panic_se_right">
                            <ShopNum1:AdSimpleImage ID="AdSimpleImage17" runat="server" AdImgId="17" SkinFilename="AdSimpleImage.ascx" />
                        </div>
                        <div class="panic_se_left" id="divPanicList2">
                            <div class="clear">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!--抢购2 服饰内衣-->
                <!--广告-->
                <div class="panic_Midadv">
                    <ShopNum1:AdSimpleImage ID="AdSimpleImage18" runat="server" AdImgId="18" SkinFilename="AdSimpleImage.ascx" />
                </div>
            </div>
            <!--抢购3 鞋包运动-->
            <div class="panic_se">
                <div class="panic_se_left_top">
                    <div class="psl_left">
                        鞋包运动专场</div>
                    <div class="psl_right" id="divPageBar3">
                        共<b class="totle"><label id="lbTotalCount3"></label></b>个商品 <b><span style="color: #ff6400;">
                            <label id="lbPageIndex3">
                            </label>
                        </span>/
                            <label id="lbPageCount3">
                            </label>
                        </b><a class="page_up_true" onclick="prevPage(this)" lang="3">上一页</a> <a class="page_down_true"
                            onclick="nextPage(this)" lang="3">下一页</a>
                    </div>
                </div>
                <div class="panic_cont">
                    <div class="panic_se_right">
                        <ShopNum1:AdSimpleImage ID="AdSimpleImage19" runat="server" AdImgId="19" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="panic_se_left" id="divPanicList3">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <!--抢购3 鞋包运动-->
            <!--抢购4 母婴用品-->
            <div class="panic_se">
                <div class="panic_se_left_top">
                    <div class="psl_left">
                        母婴用品专场</div>
                    <div class="psl_right" id="divPageBar4">
                        共<b class="totle"><label id="lbTotalCount4"></label></b>个商品 <b><span style="color: #ff6400;">
                            <label id="lbPageIndex4">
                            </label>
                        </span>/
                            <label id="lbPageCount4">
                            </label>
                        </b><a class="page_up_true" onclick="prevPage(this)" lang="4">上一页</a> <a class="page_down_true"
                            onclick="nextPage(this)" lang="4">下一页</a>
                    </div>
                </div>
                <div class="panic_cont">
                    <div class="panic_se_right">
                        <ShopNum1:AdSimpleImage ID="AdSimpleImage20" runat="server" AdImgId="20" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="panic_se_left" id="divPanicList4">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <!--抢购4 母婴用品-->
            <!--广告-->
            <div class="panic_Midadv">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage21" runat="server" AdImgId="21" SkinFilename="AdSimpleImage.ascx" />
            </div>
            <!--抢购5 数码家电-->
            <div class="panic_se">
                <div class="panic_se_left_top">
                    <div class="psl_left">
                        食品保健专场</div>
                    <div class="psl_right" id="divPageBar5">
                        共<b class="totle"><label id="lbTotalCount5"></label></b>个商品 <b><span style="color: #ff6400;">
                            <label id="lbPageIndex5">
                            </label>
                        </span>/
                            <label id="lbPageCount5">
                            </label>
                        </b><a class="page_up_true" onclick="prevPage(this)" lang="5">上一页</a> <a class="page_down_true"
                            onclick="nextPage(this)" lang="5">下一页</a>
                    </div>
                </div>
                <div class="panic_cont">
                    <div class="panic_se_right">
                        <ShopNum1:AdSimpleImage ID="AdSimpleImage22" runat="server" AdImgId="22" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="panic_se_left" id="divPanicList5">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <!--抢购5 数码家电-->
            <!--抢购6 日常用品专场-->
            <div class="panic_se">
                <div class="panic_se_left_top">
                    <div class="psl_left">
                        家居家装专场</div>
                    <div class="psl_right" id="divPageBar6">
                        共<b class="totle"><label id="lbTotalCount6"></label></b>个商品 <b><span style="color: #ff6400;">
                            <label id="lbPageIndex6">
                            </label>
                        </span>/
                            <label id="lbPageCount6">
                            </label>
                        </b><a class="page_up_true" onclick="prevPage(this)" lang="6">上一页</a> <a class="page_down_true"
                            onclick="nextPage(this)" lang="6">下一页</a>
                    </div>
                </div>
                <div class="panic_cont">
                    <div class="panic_se_right">
                        <ShopNum1:AdSimpleImage ID="AdSimpleImage23" runat="server" AdImgId="23" SkinFilename="AdSimpleImage.ascx" />
                    </div>
                    <div class="panic_se_left" id="divPanicList6">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <!--foot Start-->
    <!-- #include file="foot1.aspx" -->
    <!--//foot End-->
    <!--图片广告模块调用  幻灯片 -->
    </form>
</body>
</html>
