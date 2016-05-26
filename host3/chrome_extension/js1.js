var getHostName=function(url)
{
	//scheme : // [username [: password] @] hostame [: port] [/ [path] [? query] [# fragment]]*/
	var e = new RegExp('^(?:(?:https?|ftp):)/*(?:[^@]+@)?([^:/#]+)'),
	    matches = e.exec(url);
	return matches ? matches[1] : url;
};
var host_name="???";
chrome.tabs.getSelected(
    null, function(tab) {
        host_name=getHostName(tab.url);
        var div2=document.getElementById("div2");
        div2.innerHTML="<p id=\"hostname\" style=\"font-size:14px\">"+host_name+"</p>\n";
   });



