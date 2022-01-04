using System;
using System.Collections.Generic;
using System.Text;

namespace PowershellExtensions
{
    public static class WechatHelper
    {
        [System.Runtime.InteropServices.DllImport(@"F:\Repo\WeChatRobot\Release\WeChatHelper.dll")]
        public static extern void CheckIsLogin();
    }
}
