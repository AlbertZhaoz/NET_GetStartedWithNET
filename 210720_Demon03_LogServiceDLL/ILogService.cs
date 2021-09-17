using System;
using System.Collections.Generic;
using System.Text;

namespace _210720_Demon03_LogServiceDLL {
    public interface ILogService {
        void LogErr(string msgErr);
        void LogInfo(string msgInfo);
    }
}
