using _210915_Demon01_Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemService
{
    class CalculateLog: IAlbertLog
    {
        //这里面绑定的是什么类，输出的日志就会绑定到什么类上。
        private readonly ILogger<CalculateLog> logger;
        public CalculateLog(ILogger<CalculateLog> logger)
        {
            this.logger = logger;
        }

        public void InitData()
        {
            logger.LogInformation("Start to execute the database.");
        }

        public void OperateDataError()
        {
            logger.LogError("Operate calculate failed.");
            logger.LogTrace("Tracking error.");
            logger.LogError("Operate database failed.");
            logger.LogInformation("Add a person{@person}", new { name = "Albert", age = 25, email = "szdxzhy@outlook.com" });
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
