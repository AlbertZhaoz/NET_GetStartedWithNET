using Renci.SshNet;
using System;


namespace _210916_Demon01_SSHClient
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>此处增加评论来验证Github仓库和Gitee仓库。</remarks>
        static void Main(string[] args)
        {
            byte[] expectedFingerPrint = new byte[] {
                                            0x66, 0x31, 0xaf, 0x00, 0x54, 0xb9, 0x87, 0x31,
                                            0xff, 0x58, 0x1c, 0x31, 0xb1, 0xa2, 0x4c, 0x6b
                                        };

            using (var client = new SshClient("sftp.foo.com",8080, "guest", "pwd"))
            {
                client.HostKeyReceived += (sender, e) =>
                {
                    if (expectedFingerPrint.Length == e.FingerPrint.Length)
                    {
                        for (var i = 0; i < expectedFingerPrint.Length; i++)
                        {
                            if (expectedFingerPrint[i] != e.FingerPrint[i])
                            {
                                e.CanTrust = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        e.CanTrust = false;
                    }
                };
                client.Connect();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
