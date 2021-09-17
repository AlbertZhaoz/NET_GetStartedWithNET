using System;
using System.Collections.Generic;
using System.Text;

//获取配置信息
namespace _210720_Demon03_ConfigServiceDLL {
    public interface IConfigService {
        string GetValue(string file);
    }
}
