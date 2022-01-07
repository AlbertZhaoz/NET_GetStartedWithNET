using CopyDirectoryAsyncProviderNS;


List<string> list = new List<string>();
list.Add(@"\\Redmond\exchange\Build\SUBSTRATE\LATEST\target\dev\Management\Microsoft.Exchange.Management.NetCore\bin\Debug\netcoreapp3.1\,D:\repo\src\target\dev\Management\Microsoft.Exchange.Management.NetCore\bin\Debug\netcoreapp3.1\");
list.Add(@"\\Redmond\exchange\Build\SUBSTRATE\LATEST\dev\Management\Microsoft.Exchange.Management.Recipient.NetCore\bin\Debug\netcoreapp3.1\,D:\repo\src\target\dev\Management\Microsoft.Exchange.Management.Recipient.NetCore\bin\Debug\netcoreapp3.1\");

foreach (var item in list)
{
    await CopyDirectoryAsyncProvider.CopyDirectoryAsync(
                new DirectoryInfo(item.Split(",")[0]),
                new DirectoryInfo(item.Split(",")[1]),
                CancellationToken.None
            );

}


