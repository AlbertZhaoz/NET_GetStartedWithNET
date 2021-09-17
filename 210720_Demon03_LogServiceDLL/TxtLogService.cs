using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _210720_Demon03_LogServiceDLL {
    //用于将日志信息存储进文本
     class TxtLogService : ILogService {
        public void LogErr(string msgErr) {
            File.WriteAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + "log.txt", "错误日志:"+msgErr, null);
        }

        public void LogInfo(string msgInfo) {
            string txtPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            if (!File.Exists(txtPath)) {
                File.Create(txtPath);
            }
            string txt = File.ReadAllText(txtPath);
            txt = txt +"\n" +msgInfo;
            File.WriteAllTextAsync(txtPath, txt);
        }
    }
}
