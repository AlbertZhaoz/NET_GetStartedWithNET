using System;
using System.Collections.Generic;
using System.Text;

//获取配置信息
namespace _210910_Demo01_SendEmailByOutlook.AlbertConfig {
    public interface IConfigService
    {
        void EntityToFile();
        string GetValue(string file);
    }
}
