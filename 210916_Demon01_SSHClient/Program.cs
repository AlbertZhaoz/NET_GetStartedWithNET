using Renci.SshNet;
using System;


namespace _210916_Demon01_SSHClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionInfo conInfo = new ConnectionInfo("172.23.236.199", 22, "test", new AuthenticationMethod[]
            {
               new PasswordAuthenticationMethod("test", "Shanghai2010")
            });
            using (SshClient client = new SshClient(conInfo))
            {               
                client.Connect();
                var output = client.RunCommand("ls -l");
                Console.WriteLine(output.Result.ToString());
                client.Disconnect();
            }                   
        }
    }
}
