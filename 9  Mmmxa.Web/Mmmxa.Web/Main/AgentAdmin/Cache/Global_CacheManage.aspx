﻿<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_Global_Global_CacheManage, ShopNum1.Deploy" %>
<%@ Register Src="~/Main/Admin/UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>缓存管理</title>
    <link href="../style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/dcommon.js"></script>

    <script src="../js/CommonJS.js" type="text/javascript"></script>

    <script type="text/javascript">	       
	var result = 1; 
	var bar = 0;    
	function runstatic()
	{  
	  if(result > -1)
	  {
		 document.getElementById('Layer5').innerHTML =  '<BR /><table><tr><td valign=top><img border=\"0\" src=\"/images/ajax_loading.gif\"  /></td><td valign=middle style=\"font-size: 14px;\" >'+getcachename()+', 请稍等...<BR /></td></tr></table><BR />';
		 document.getElementById('Layer5').style.witdh='350';
		 document.getElementById('success').style.witdh='400';
		 document.getElementById('success').style.display ="block"; 
		 result=getReturn('global_refreshallcache.ashx?opnumber='+result);
		 if(result==null)
		 {
			document.getElementById('Layer5').innerHTML="<br />提交成功, 请稍等...";
			document.getElementById('success').style.display = "block";
			count(); 
			document.getElementById('Form1').submit();
		 }
	  }
	  else
	  {
		 document.getElementById('Layer5').innerHTML="<br />提交成功, 请稍等...";
		 document.getElementById('success').style.display = "block";
		 count(); 
		 document.getElementById('Form1').submit();
	  }
   }
   
	function getcachename()
	{
	   var cachename='';
	   switch(result)
	   {
			case '1': cachename='正在重设ShopSetting缓存';break;
			case '2': cachename='更新店铺分类缓存';break;
			case '3': cachename='更新店铺展现缓存';break;
			case '4': cachename='更新商品分类缓存';break;
			case '5': cachename='更新商品展现缓存';break;
			case '6': cachename='更新供求分类缓存';break;
			case '7': cachename='更新供求展现缓存';break;
			case '8': cachename='更新分类缓存';break;
			case '9': cachename='更新分类展现缓存';break;
			case '10': cachename='更新资讯分类缓存';break;
			case '11': cachename='更新资讯展现缓存';break;
			case '12': cachename='更新店铺前台缓存';break;
			case '13': cachename='更新店铺后台缓存';break;
			case '14': cachename='更新店铺前台Meto缓存';break;
			case '15': cachename='更新平台前台Meto缓存';break;
			case '16': cachename='更新在线会员缓存';break;
			case '17': cachename='更新在线店铺缓存';break;
			case '18': cachename='更新平台前台广告缓存';break;
			default : cachename='正在重设系统缓存';break; 
	   }
	   return cachename;//+' ,请稍等...';
   }
	 
   function clearflag()
   {
		bar=0;
		document.getElementById('Layer5').innerHTML="<br />提交成功, 请稍等...";
		document.getElementById('success').style.display = "block";
		count(); 
   }
	
   function count()
   { 
		bar=bar+2;
		if (bar<99) {setTimeout("count()",100);} 
		else { document.getElementById('success').style.display ="none"; } 
   }
   
   function run()
   {

	  bar=0;
	  document.getElementById('Layer5').innerHTML="<br />正在处理数据, 请稍等...";
	  document.getElementById('success').style.display = "block";
	  setInterval('runstatic()',2000); //每次提交时间为2秒
   }
    </script>

    <script type="text/javascript">
    var Page_ValidationVer = "125";
var Page_IsValid = true;
var Page_BlockSubmit = false;
var Page_InvalidControlToBeFocused = null;
function ValidatorUpdateDisplay(val) {
    if (typeof(val.display) == "string") {
        if (val.display == "None") {
            return;
        }
        if (val.display == "Dynamic") {
            val.style.display = val.isvalid ? "none" : "inline";
            return;
        }
    }
    if ((navigator.userAgent.indexOf("Mac") > -1) &&
        (navigator.userAgent.indexOf("MSIE") > -1)) {
        val.style.display = "inline";
    }
    val.style.visibility = val.isvalid ? "hidden" : "visible";
}
function ValidatorUpdateIsValid() {
    Page_IsValid = AllValidatorsValid(Page_Validators);
}
function AllValidatorsValid(validators) {
    if ((typeof(validators) != "undefined") && (validators != null)) {
        var i;
        for (i = 0; i < validators.length; i++) {
            if (!validators[i].isvalid) {
                return false;
            }
        }
    }
    return true;
}
function ValidatorHookupControlID(controlID, val) {
    if (typeof(controlID) != "string") {
        return;
    }
    var ctrl = document.getElementById(controlID);
    if ((typeof(ctrl) != "undefined") && (ctrl != null)) {
        ValidatorHookupControl(ctrl, val);
    }
    else {
        val.isvalid = true;
        val.enabled = false;
    }
}
function ValidatorHookupControl(control, val) {
    if (typeof(control.tagName) != "string") {
        return;  
    }
    if (control.tagName != "INPUT" && control.tagName != "TEXTAREA" && control.tagName != "SELECT") {
        var i;
        for (i = 0; i < control.childNodes.length; i++) {
            ValidatorHookupControl(control.childNodes[i], val);
        }
        return;
    }
    else {
        if (typeof(control.Validators) == "undefined") {
            control.Validators = new Array;
            var eventType;
            if (control.type == "radio") {
                eventType = "onclick";
            } else {
                eventType = "onchange";
                if (typeof(val.focusOnError) == "string" && val.focusOnError == "t") {
                    ValidatorHookupEvent(control, "onblur", "ValidatedControlOnBlur(event); ");
                }
            }
            ValidatorHookupEvent(control, eventType, "ValidatorOnChange(event); ");
            if (control.type == "text" ||
                control.type == "password" ||
                control.type == "file") {
                ValidatorHookupEvent(control, "onkeypress", 
                    "if (!ValidatedTextBoxOnKeyPress(event)) { event.cancelBubble = true; if (event.stopPropagation) event.stopPropagation(); return false; } ");
            }
        }
        control.Validators[control.Validators.length] = val;
    }
}
function ValidatorHookupEvent(control, eventType, functionPrefix) {
    var ev;
    eval("ev = control." + eventType + ";");
    if (typeof(ev) == "function") {
        ev = ev.toString();
        ev = ev.substring(ev.indexOf("{") + 1, ev.lastIndexOf("}"));
    }
    else {
        ev = "";
    }
    var func;
    if (navigator.appName.toLowerCase().indexOf('explorer') > -1) {
        func = new Function(functionPrefix + " " + ev);
    }
    else {
        func = new Function("event", functionPrefix + " " + ev);
    }
    eval("control." + eventType + " = func;");
}
function ValidatorGetValue(id) {
    var control;
    control = document.getElementById(id);
    if (typeof(control.value) == "string") {
        return control.value;
    }
    return ValidatorGetValueRecursive(control);
}
function ValidatorGetValueRecursive(control)
{
    if (typeof(control.value) == "string" && (control.type != "radio" || control.checked == true)) {
        return control.value;
    }
    var i, val;
    for (i = 0; i<control.childNodes.length; i++) {
        val = ValidatorGetValueRecursive(control.childNodes[i]);
        if (val != "") return val;
    }
    return "";
}
function Page_ClientValidate(validationGroup) {
    Page_InvalidControlToBeFocused = null;
    if (typeof(Page_Validators) == "undefined") {
        return true;
    }
    var i;
    for (i = 0; i < Page_Validators.length; i++) {
        ValidatorValidate(Page_Validators[i], validationGroup, null);
    }
    ValidatorUpdateIsValid();
    ValidationSummaryOnSubmit(validationGroup);
    Page_BlockSubmit = !Page_IsValid;
    return Page_IsValid;
}
function ValidatorCommonOnSubmit() {
    Page_InvalidControlToBeFocused = null;
    var result = !Page_BlockSubmit;
    if ((typeof(window.event) != "undefined") && (window.event != null)) {
        window.event.returnValue = result;
    }
    Page_BlockSubmit = false;
    return result;
}
function ValidatorEnable(val, enable) {
    val.enabled = (enable != false);
    ValidatorValidate(val);
    ValidatorUpdateIsValid();
}
function ValidatorOnChange(event) {
    if (!event) {
        event = window.event;
    }
    Page_InvalidControlToBeFocused = null;
    var targetedControl;
    if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
        targetedControl = event.srcElement;
    }
    else {
        targetedControl = event.target;
    }
    var vals;
    if (typeof(targetedControl.Validators) != "undefined") {
        vals = targetedControl.Validators;
    }
    else {
        if (targetedControl.tagName.toLowerCase() == "label") {
            targetedControl = document.getElementById(targetedControl.htmlFor);
            vals = targetedControl.Validators;
        }
    }
    var i;
    for (i = 0; i < vals.length; i++) {
        ValidatorValidate(vals[i], null, event);
    }
    ValidatorUpdateIsValid();
}
function ValidatedTextBoxOnKeyPress(event) {
    if (event.keyCode == 13) {
        ValidatorOnChange(event);
        var vals;
        if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
            vals = event.srcElement.Validators;
        }
        else {
            vals = event.target.Validators;
        }
        return AllValidatorsValid(vals);
    }
    return true;
}
function ValidatedControlOnBlur(event) {
    var control;
    if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
        control = event.srcElement;
    }
    else {
        control = event.target;
    }
    if ((typeof(control) != "undefined") && (control != null) && (Page_InvalidControlToBeFocused == control)) {
        control.focus();
        Page_InvalidControlToBeFocused = null;
    }
}
function ValidatorValidate(val, validationGroup, event) {
    val.isvalid = true;
    if ((typeof(val.enabled) == "undefined" || val.enabled != false) && IsValidationGroupMatch(val, validationGroup)) {
        if (typeof(val.evaluationfunction) == "function") {
            val.isvalid = val.evaluationfunction(val);
            if (!val.isvalid && Page_InvalidControlToBeFocused == null &&
                typeof(val.focusOnError) == "string" && val.focusOnError == "t") {
                ValidatorSetFocus(val, event);
            }
        }
    }
    ValidatorUpdateDisplay(val);
}
function ValidatorSetFocus(val, event) {
    var ctrl;
    if (typeof(val.controlhookup) == "string") {
        var eventCtrl;
        if ((typeof(event) != "undefined") && (event != null)) {
            if ((typeof(event.srcElement) != "undefined") && (event.srcElement != null)) {
                eventCtrl = event.srcElement;
            }
            else {
                eventCtrl = event.target;
            }
        }
        if ((typeof(eventCtrl) != "undefined") && (eventCtrl != null) &&
            (typeof(eventCtrl.id) == "string") &&
            (eventCtrl.id == val.controlhookup)) {
            ctrl = eventCtrl;
        }
    }
    if ((typeof(ctrl) == "undefined") || (ctrl == null)) {
        ctrl = document.getElementById(val.controltovalidate);
    }
    if ((typeof(ctrl) != "undefined") && (ctrl != null) &&
        (ctrl.tagName.toLowerCase() != "table" || (typeof(event) == "undefined") || (event == null)) && 
        ((ctrl.tagName.toLowerCase() != "input") || (ctrl.type.toLowerCase() != "hidden")) &&
        (typeof(ctrl.disabled) == "undefined" || ctrl.disabled == null || ctrl.disabled == false) &&
        (typeof(ctrl.visible) == "undefined" || ctrl.visible == null || ctrl.visible != false) &&
        (IsInVisibleContainer(ctrl))) {
        if ((ctrl.tagName.toLowerCase() == "table" && (typeof(__nonMSDOMBrowser) == "undefined" || __nonMSDOMBrowser)) ||
            (ctrl.tagName.toLowerCase() == "span")) {
            var inputElements = ctrl.getElementsByTagName("input");
            var lastInputElement  = inputElements[inputElements.length -1];
            if (lastInputElement != null) {
                ctrl = lastInputElement;
            }
        }
        if (typeof(ctrl.focus) != "undefined" && ctrl.focus != null) {
            ctrl.focus();
            Page_InvalidControlToBeFocused = ctrl;
        }
    }
}
function IsInVisibleContainer(ctrl) {
    if (typeof(ctrl.style) != "undefined" &&
        ( ( typeof(ctrl.style.display) != "undefined" &&
            ctrl.style.display == "none") ||
          ( typeof(ctrl.style.visibility) != "undefined" &&
            ctrl.style.visibility == "hidden") ) ) {
        return false;
    }
    else if (typeof(ctrl.parentNode) != "undefined" &&
             ctrl.parentNode != null &&
             ctrl.parentNode != ctrl) {
        return IsInVisibleContainer(ctrl.parentNode);
    }
    return true;
}
function IsValidationGroupMatch(control, validationGroup) {
    if ((typeof(validationGroup) == "undefined") || (validationGroup == null)) {
        return true;
    }
    var controlGroup = "";
    if (typeof(control.validationGroup) == "string") {
        controlGroup = control.validationGroup;
    }
    return (controlGroup == validationGroup);
}
function ValidatorOnLoad() {
    if (typeof(Page_Validators) == "undefined")
        return;
    var i, val;
    for (i = 0; i < Page_Validators.length; i++) {
        val = Page_Validators[i];
        if (typeof(val.evaluationfunction) == "string") {
            eval("val.evaluationfunction = " + val.evaluationfunction + ";");
        }
        if (typeof(val.isvalid) == "string") {
            if (val.isvalid == "False") {
                val.isvalid = false;
                Page_IsValid = false;
            }
            else {
                val.isvalid = true;
            }
        } else {
            val.isvalid = true;
        }
        if (typeof(val.enabled) == "string") {
            val.enabled = (val.enabled != "False");
        }
        if (typeof(val.controltovalidate) == "string") {
            ValidatorHookupControlID(val.controltovalidate, val);
        }
        if (typeof(val.controlhookup) == "string") {
            ValidatorHookupControlID(val.controlhookup, val);
        }
    }
    Page_ValidationActive = true;
}
function ValidatorConvert(op, dataType, val) {
    function GetFullYear(year) {
        var twoDigitCutoffYear = val.cutoffyear % 100;
        var cutoffYearCentury = val.cutoffyear - twoDigitCutoffYear;
        return ((year > twoDigitCutoffYear) ? (cutoffYearCentury - 100 + year) : (cutoffYearCentury + year));
    }
    var num, cleanInput, m, exp;
    if (dataType == "Integer") {
        exp = /^\s*[-\+]?\d+\s*$/;
        if (op.match(exp) == null)
            return null;
        num = parseInt(op, 10);
        return (isNaN(num) ? null : num);
    }
    else if(dataType == "Double") {
        exp = new RegExp("^\\s*([-\\+])?(\\d*)\\" + val.decimalchar + "?(\\d*)\\s*$");
        m = op.match(exp);
        if (m == null)
            return null;
        if (m[2].length == 0 && m[3].length == 0)
            return null;
        cleanInput = (m[1] != null ? m[1] : "") + (m[2].length>0 ? m[2] : "0") + (m[3].length>0 ? "." + m[3] : "");
        num = parseFloat(cleanInput);
        return (isNaN(num) ? null : num);
    }
    else if (dataType == "Currency") {
        var hasDigits = (val.digits > 0);
        var beginGroupSize, subsequentGroupSize;
        var groupSizeNum = parseInt(val.groupsize, 10);
        if (!isNaN(groupSizeNum) && groupSizeNum > 0) {
            beginGroupSize = "{1," + groupSizeNum + "}";
            subsequentGroupSize = "{" + groupSizeNum + "}";
        }
        else {
            beginGroupSize = subsequentGroupSize = "+";
        }
        exp = new RegExp("^\\s*([-\\+])?((\\d" + beginGroupSize + "(\\" + val.groupchar + "\\d" + subsequentGroupSize + ")+)|\\d*)"
                        + (hasDigits ? "\\" + val.decimalchar + "?(\\d{0," + val.digits + "})" : "")
                        + "\\s*$");
        m = op.match(exp);
        if (m == null)
            return null;
        if (m[2].length == 0 && hasDigits && m[5].length == 0)
            return null;
        cleanInput = (m[1] != null ? m[1] : "") + m[2].replace(new RegExp("(\\" + val.groupchar + ")", "g"), "") + ((hasDigits && m[5].length > 0) ? "." + m[5] : "");
        num = parseFloat(cleanInput);
        return (isNaN(num) ? null : num);
    }
    else if (dataType == "Date") {
        var yearFirstExp = new RegExp("^\\s*((\\d{4})|(\\d{2}))([-/]|\\. ?)(\\d{1,2})\\4(\\d{1,2})\\.?\\s*$");
        m = op.match(yearFirstExp);
        var day, month, year;
        if (m != null && (m[2].length == 4 || val.dateorder == "ymd")) {
            day = m[6];
            month = m[5];
            year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10))
        }
        else {
            if (val.dateorder == "ymd"){
                return null;
            }
            var yearLastExp = new RegExp("^\\s*(\\d{1,2})([-/]|\\. ?)(\\d{1,2})(?:\\s|\\2)((\\d{4})|(\\d{2}))(?:\\s\u0433\\.)?\\s*$");
            m = op.match(yearLastExp);
            if (m == null) {
                return null;
            }
            if (val.dateorder == "mdy") {
                day = m[3];
                month = m[1];
            }
            else {
                day = m[1];
                month = m[3];
            }
            year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10))
        }
        month -= 1;
        var date = new Date(year, month, day);
        if (year < 100) {
            date.setFullYear(year);
        }
        return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate()) ? date.valueOf() : null;
    }
    else {
        return op.toString();
    }
}
function ValidatorCompare(operand1, operand2, operator, val) {
    var dataType = val.type;
    var op1, op2;
    if ((op1 = ValidatorConvert(operand1, dataType, val)) == null)
        return false;
    if (operator == "DataTypeCheck")
        return true;
    if ((op2 = ValidatorConvert(operand2, dataType, val)) == null)
        return true;
    switch (operator) {
        case "NotEqual":
            return (op1 != op2);
        case "GreaterThan":
            return (op1 > op2);
        case "GreaterThanEqual":
            return (op1 >= op2);
        case "LessThan":
            return (op1 < op2);
        case "LessThanEqual":
            return (op1 <= op2);
        default:
            return (op1 == op2);
    }
}
function CompareValidatorEvaluateIsValid(val) {
    var value = ValidatorGetValue(val.controltovalidate);
    if (ValidatorTrim(value).length == 0)
        return true;
    var compareTo = "";
    if ((typeof(val.controltocompare) != "string") ||
        (typeof(document.getElementById(val.controltocompare)) == "undefined") ||
        (null == document.getElementById(val.controltocompare))) {
        if (typeof(val.valuetocompare) == "string") {
            compareTo = val.valuetocompare;
        }
    }
    else {
        compareTo = ValidatorGetValue(val.controltocompare);
    }
    var operator = "Equal";
    if (typeof(val.operator) == "string") {
        operator = val.operator;
    }
    return ValidatorCompare(value, compareTo, operator, val);
}
function CustomValidatorEvaluateIsValid(val) {
    var value = "";
    if (typeof(val.controltovalidate) == "string") {
        value = ValidatorGetValue(val.controltovalidate);
        if ((ValidatorTrim(value).length == 0) &&
            ((typeof(val.validateemptytext) != "string") || (val.validateemptytext != "true"))) {
            return true;
        }
    }
    var args = { Value:value, IsValid:true };
    if (typeof(val.clientvalidationfunction) == "string") {
        eval(val.clientvalidationfunction + "(val, args) ;");
    }
    return args.IsValid;
}
function RegularExpressionValidatorEvaluateIsValid(val) {
    var value = ValidatorGetValue(val.controltovalidate);
    if (ValidatorTrim(value).length == 0)
        return true;
    var rx = new RegExp(val.validationexpression);
    var matches = rx.exec(value);
    return (matches != null && value == matches[0]);
}
function ValidatorTrim(s) {
    var m = s.match(/^\s*(\S+(\s+\S+)*)\s*$/);
    return (m == null) ? "" : m[1];
}
function RequiredFieldValidatorEvaluateIsValid(val) {
    return (ValidatorTrim(ValidatorGetValue(val.controltovalidate)) != ValidatorTrim(val.initialvalue))
}
function RangeValidatorEvaluateIsValid(val) {
    var value = ValidatorGetValue(val.controltovalidate);
    if (ValidatorTrim(value).length == 0)
        return true;
    return (ValidatorCompare(value, val.minimumvalue, "GreaterThanEqual", val) &&
            ValidatorCompare(value, val.maximumvalue, "LessThanEqual", val));
}
function ValidationSummaryOnSubmit(validationGroup) {
    if (typeof(Page_ValidationSummaries) == "undefined")
        return;
    var summary, sums, s;
    for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
        summary = Page_ValidationSummaries[sums];
        summary.style.display = "none";
        if (!Page_IsValid && IsValidationGroupMatch(summary, validationGroup)) {
            var i;
            if (summary.showsummary != "False") {
                summary.style.display = "";
                if (typeof(summary.displaymode) != "string") {
                    summary.displaymode = "BulletList";
                }
                switch (summary.displaymode) {
                    case "List":
                        headerSep = "<br>";
                        first = "";
                        pre = "";
                        post = "<br>";
                        end = "";
                        break;
                    case "BulletList":
                    default:
                        headerSep = "";
                        first = "<ul>";
                        pre = "<li>";
                        post = "</li>";
                        end = "</ul>";
                        break;
                    case "SingleParagraph":
                        headerSep = " ";
                        first = "";
                        pre = "";
                        post = " ";
                        end = "<br>";
                        break;
                }
                s = "";
                if (typeof(summary.headertext) == "string") {
                    s += summary.headertext + headerSep;
                }
                s += first;
                for (i=0; i<Page_Validators.length; i++) {
                    if (!Page_Validators[i].isvalid && typeof(Page_Validators[i].errormessage) == "string") {
                        s += pre + Page_Validators[i].errormessage + post;
                    }
                }
                s += end;
                summary.innerHTML = s;
                window.scrollTo(0,0);
            }
            if (summary.showmessagebox == "True") {
                s = "";
                if (typeof(summary.headertext) == "string") {
                    s += summary.headertext + "\r\n";
                }
                var lastValIndex = Page_Validators.length - 1;
                for (i=0; i<=lastValIndex; i++) {
                    if (!Page_Validators[i].isvalid && typeof(Page_Validators[i].errormessage) == "string") {
                        switch (summary.displaymode) {
                            case "List":
                                s += Page_Validators[i].errormessage;
                                if (i < lastValIndex) {
                                    s += "\r\n";
                                }
                                break;
                            case "BulletList":
                            default:
                                s += "- " + Page_Validators[i].errormessage;
                                if (i < lastValIndex) {
                                    s += "\r\n";
                                }
                                break;
                            case "SingleParagraph":
                                s += Page_Validators[i].errormessage + " ";
                                break;
                        }
                    }
                }
                alert(s);
            }
        }
    }
}


    </script>

    <meta http-equiv="X-UA-Compatible" content="IE=7" />
   
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
        <div id="success" style="position: absolute; z-index: 300; height: 120px; width: 284px;
            left: 50%; top: 50%; margin-left: -150px; margin-top: -80px;">
            <div id="Layer2" style="position: absolute; z-index: 300; width: 270px; height: 90px;
                background-color: #FFFFFF; border: solid #ddd 1px; font-size: 14px;">
                <div id="Layer4" style="height: 26px; background: #f1f1f1; line-height: 26px; padding: 0px 3px 0px 3px;
                    font-weight: bolder;">
                    操作提示</div>
                <div id="Layer5" style="height: 64px; line-height: 150%; padding: 0px 3px 0px 3px;"
                    align="center">
                    <br />
                    <table>
                        <tr>
                            <td valign="top">
                                <img border="0" src="/Main/Admin/images/ajax_loading.gif" />
                            </td>
                            <td valign="middle" style="font-size: 14px;">
                                正在执行当前操作, 请稍等...<br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
            </div>
            <div id="Layer3" style="position: absolute; width: 270px; height: 90px; z-index: 299;
                left: 4px; top: 5px; background-color: #E8E8E8;">
            </div>
        </div>

        <script> 
document.getElementById('success').style.display = "none"; 
        </script>

        <script type="text/javascript" src="/Main/Admin/js/divcover.js"></script>

        <div id="right">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>
                        网站优化</h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable noshopbtn" style=" border:none;">
                    <tr>
                        <td>
                            <button type="button" class="ManagerButton" onclick="javascript:run();">
                                <img src="../images/submit.gif" />更新所有缓存</button>
                            <ShopNum1:Button ID="ResetAllCache" runat="server" Text="<B>更新所有缓存</B>" ButtonImgUrl="../images/cache_resetall.gif"
                                Visible="false" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonShopSetting" runat="server" Text="<B>更新网站设置缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonShopCatergory" runat="server" Text="<B>更新店铺分类缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonShopShow" runat="server" Text="<B>更新店铺展现缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonProductCategory" runat="server" Text="<B>更新商品分类缓存</B>"
                                ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonProductShow" runat="server" Text="<B>更新商品展现缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonSupplyDemand" runat="server" Text="<B>更新供求分类缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonSupplyShow" runat="server" Text="<B>更新供求展现缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonCategory" runat="server" Text="<B>更新分类缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonCategoryShow" runat="server" Text="<B>更新分类展现缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonArticleCategory" runat="server" Text="<B>更新资讯分类缓存</B>"
                                ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonArticleShow" runat="server" Text="<B>更新资讯展现缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonShopFront" runat="server" Text="<B>更新店铺前台缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonShopBack" runat="server" Text="<B>更新店铺后台缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonShopMeto" runat="server" Text="<B>更新店铺前台Meto缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonSiteMeto" runat="server" Text="<B>更新平台前台Meto缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonOnlineMember" runat="server" Text="<B>更新在线会员缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonOnlineShop" runat="server" Text="<B>更新在线店铺缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ShopNum1:Button ID="ButtonSiteImg" runat="server" Text="<B>更新平台前台广告缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                        <td>
                            <ShopNum1:Button ID="ButtonSiteConfig" runat="server" Text="<B>更新系统缓存</B>" ButtonImgUrl="../images/cache_resetall.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </form>
    </div>
</body>
</html>