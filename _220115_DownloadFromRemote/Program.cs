var remoteFileDir = @"\\Redmond\exchange\Build\SUBSTRATE\15.20.4870.000\Target\dev\data\Microsoft.Exchange.Data.NetCore\retail\amd64\";
var localFileDir = @"F:\TestDownload";
DateTime dt = DateTime.Now;
await CopyDirectory(remoteFileDir, localFileDir);
DateTime dt2 = DateTime.Now;
Console.WriteLine($"Down suceessfully.{dt2-dt}");


static async Task CopyDirectory(string sourcePath, string destPath)
{
    string floderName = Path.GetFileName(sourcePath);
    DirectoryInfo di = Directory.CreateDirectory(Path.Combine(destPath, floderName));
    string[] files = Directory.GetFileSystemEntries(sourcePath);

    foreach (string file in files)
    {
        if (Directory.Exists(file))
        {
            await Task.Run(() => CopyDirectory(file, di.FullName));
        }
        else
        {
            //using (var input = File.OpenRead(file))
            //{
            //    using (var output = Create(Path.Combine(di.FullName, Path.GetFileName(file))))
            //    {
            //        await Task.Run(()=>input.CopyToAsync(output));
            //    }
            //}
            await Task.Run(() => File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)), true));
            //File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)), true);
        }
    }
}

static FileStream Create(string path)
{
    var dir = Directory.GetParent(path).FullName;
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
    return File.Create(path);
}
