# fuckGFW
你需要：
以开发者模式载入chrome_extension
找到这个扩展的id，在chrome_extension/com.venn.pac.json当中加上它的id
新建项HKEY_CURRENT_USER\Software\Google\Chrome\NativeMessagingHosts\com.venn.pac，（默认）值写为上面提到的那个com.venn.pac.json的完整路径
打开host3.sln，修改Program.cs中pac文件的路径
编译，然后修改chrome_extension/com.venn.pac.json中本地程序的路径
