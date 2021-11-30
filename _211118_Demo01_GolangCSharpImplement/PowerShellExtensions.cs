using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace _211118_Demo01_GolangCSharpImplement
{
    internal class PowerShellExtensions
    {
        public string PowershellPath { get; set; }
        public PowerShellExtensions(string powershellPath)
        {
            this.PowershellPath = powershellPath;
        }
        public void RunPowershell()
        {
            string directory = null;
            List<string> command = new List<string>();
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = directory ?? Directory.GetCurrentDirectory();//工作目录
                process.StartInfo.CreateNoWindow = true;//隐藏窗口运行
                process.StartInfo.RedirectStandardError = true;//重定向错误流
                process.StartInfo.RedirectStandardInput = true;//重定向输入流
                process.StartInfo.RedirectStandardOutput = true;//重定向输出流
                process.StartInfo.UseShellExecute = false;
                //抓取事件
                process.OutputDataReceived += new DataReceivedEventHandler(OutputEventHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorEventHandler);
                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.StandardInput.WriteLine("Powershell F:\\Test\\1.ps1");//输入CMD命令
                process.StandardInput.WriteLine("exit");//结束执行，不可或缺
                process.StandardInput.AutoFlush = true;
                process.WaitForExit();
                process.Close();
            }
        }

        private static void OutputEventHandler(Object sender, DataReceivedEventArgs e) => Console.WriteLine(e.Data);
        private static void ErrorEventHandler(Object sender, DataReceivedEventArgs e) => Console.WriteLine(e.Data);
    }
}
