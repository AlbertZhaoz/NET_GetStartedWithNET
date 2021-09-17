using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _210910_Demo01_SendEmailByOutlook.AlbertLog {
    //用于将日志信息存储进文本
     class TxtLogService : ILogService {
        public void LogErr(string msgErr) {
            var logDir = AppDomain.CurrentDomain.BaseDirectory + "DocumentLog/";
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
            string txtPath = AppDomain.CurrentDomain.BaseDirectory + "logInfo.txt";
            if (!File.Exists(txtPath)) {
                var fs= File.Create(txtPath);
                fs.Close();
            }
            File.WriteAllTextAsync(txtPath, "错误日志:"+msgErr);
        }

        public void LogInfo(string msgInfo) {
            var logDir = AppDomain.CurrentDomain.BaseDirectory + "DocumentLog/";
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
            string txtPath = AppDomain.CurrentDomain.BaseDirectory + "logInfo.txt";
            if (!File.Exists(txtPath)) {
                var fs= File.Create(txtPath);
                fs.Close();
            }
            string txt = File.ReadAllText(txtPath);
            txt = txt +"\n" +msgInfo;
            File.WriteAllTextAsync(txtPath, txt);
        }
    }
}
