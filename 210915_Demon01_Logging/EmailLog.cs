using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace _210915_Demon01_Logging
{
    class EmailLog: IAlbertLog
    {
        //这里面绑定的是什么类，输出的日志就会绑定到什么类上。
        private readonly ILogger<EmailLog> logger;
        public EmailLog(ILogger<EmailLog> logger)
        {
            this.logger = logger;
        }

        public void InitData()
        {
            logger.LogInformation("Start to execute the database.");
        }

        public void OperateDataError()
        {
            logger.LogError("Operate database failed.");
            logger.LogTrace("Tracking error.");
            logger.LogError("Operate database failed.");
            //可以将异常信息写入
            try
            {
                File.ReadAllText("x");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception");
            }                     
        }
    }
}
