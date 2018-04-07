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
/*
  fromName 是要打开的窗口,子窗体的名称
  text是父窗体text的id
  img是父窗体img的id
  */
  function openDialog(formName,text,img){ 
    var k = window.showModalDialog(formName,window,"dialogWidth:800px;status:no;dialogHeight:800px"); 
    if(k != null) 
    document.getElementById(text).value = k; 
   document.getElementById(img).src=k; 
   //document.getElementById("img1").v 
    } 













////打开模式对话框（图片选择）
//function OpenDialog(ObjID){
//    if (navigator.appVersion.indexOf("MSIE") == -1){
//        this.returnAction=function(strResult){
//            if(strResult!=null && document.getElementById(ObjID)){
//                document.getElementById(ObjID).value = strResult;
//                if(document.getElementById(ObjID + "View")){
//                    document.getElementById(ObjID + "View").src = "../" + strResult;
//                    document.getElementById(ObjID + "View").style.display = "block";
//                }
//            }
//        }
////        window.open('Picture_Picture_Manage_Dialog.aspx?d=' + Date(),'newWin','modal=yes,width=620,height=620,top=200,left=300,resizable=no,scrollbars=no');
// window.open('Admin/Image_List_Dialog.aspx','newWin','modal=yes,width=620,height=620,top=200,left=300,resizable=no,scrollbars=no');
//        return;
//    }else{
////        var GetValue = showModalDialog('Image_List.aspx?d=' + Date(),'','dialogWidth:620px;dialogHeight:620px;')
// var GetValue = showModalDialog('Admin/Image_List_Dialog.aspx','dialogWidth:620px;dialogHeight:620px;')
//        if (GetValue != null && document.getElementById(ObjID)) {
//            document.getElementById(ObjID).value = GetValue;
//            if(document.getElementById(ObjID + "View")){
//                document.getElementById(ObjID + "View").src = "../" + GetValue;
//                document.getElementById(ObjID + "View").style.display = "block";
//            }
//        } 
//    }
//}
////将选中的图片放入父窗体的控件中
////function InitPicture(obj){
////    if (navigator.appVersion.indexOf("MSIE") == -1){
////        window.opener.returnAction(obj.title.replace("双击选择该图片，图片地址是",""));
////        window.close();
////    }else{
////        window.returnValue = obj.title.replace("双击选择该图片，图片地址是","");
////        window.close();
////    }
////}

////将选中的图片放入父窗体的控件中
//function InitPicture(txt){
//    if (navigator.appVersion.indexOf("MSIE") == -1){
//        window.opener.returnAction(txt);
//        window.close();
//    }else{
//        window.returnValue = txt;
//        window.close();
//    }
//}