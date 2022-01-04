using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zack.Commons;

namespace _220104_WebApiLibrary01
{
    //这个类实现Zack.Commons.IModuleInitializer接口
    //完成服务的自注册
    public class ModuleInitializerHelper : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<Student>();
            services.AddScoped<Teacher>();
        }
    }
}
