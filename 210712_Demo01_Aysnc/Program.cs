using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace _210712_Demo01_Aysnc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(5000);
            await DownloadHtml("https://www.baidu.com", 10000, cancellationTokenSource.Token);
            
        }

        static async Task DownloadHtml(string url,int downloadCtn,CancellationToken cancellationToken)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < downloadCtn; i++)
                {
                    string html = await httpClient.GetStringAsync(url);                   
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    //第二种方式html内容的方式，可能在5s没到就取消请求了，而不需要一直等到请求后才能处理
                    var resp = await httpClient.GetAsync(url, cancellationToken);
                    string htmlTwo = await resp.Content.ReadAsStringAsync();
                    //此种方案无法实现立即取消
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("请求被取消");
                        break;
                    }
                }
            }
        }
    }
}
