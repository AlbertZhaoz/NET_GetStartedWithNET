using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211118_Demo01_GolangCSharpImplement
{
    internal interface IUsb
    {
        public string Lan { get; set; }

        void PrintInfo();
    }
}
