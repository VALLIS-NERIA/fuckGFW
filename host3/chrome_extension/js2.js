document.getElementById("btn1").onclick=function () {
    var hostName = "com.venn.pac";
    // chrome.runtime.sendNativeMessage(hostName,{ text: "ok"});
	var port = chrome.runtime.connectNative(hostName);
    port.postMessage(host_name);
//    alert("ok");
};
document.getElementById("btn2").onclick=function () {
    var hostName = "com.venn.pac";
    // chrome.runtime.sendNativeMessage(hostName,{ text: "ok"});
	var port = chrome.runtime.connectNative(hostName);
    port.postMessage("_REMOVE_$"+host_name);
//    alert("ok");
};
document.getElementById("btn0").onclick=function () {
    /([^\.]+)[\.](.+)/.test(host_name); 
    host_name=RegExp.$2;
    div2.innerHTML="<p id=\"hostname\" style=\"font-size:14px\">"+host_name+"</p>\n";
};  