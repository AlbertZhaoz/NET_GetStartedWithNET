
var projectReference = @"$(Inetroot)\sources\dev\common\src\Diagnostics.NetCore\Microsoft.Exchange.Diagnostics.NetCore.csproj";
var dirNames = projectReference.Split('\\');
var projDir = dirNames.First(e => e.Contains(".NetCore") || e.Contains(".NetStd"));
Console.WriteLine(projDir);



var remoteFileDir = @"\\Redmond\exchange\Build\SUBSTRATE\15.20.4870.000\Target\dev\data\Microsoft.Exchange.Data.NetCore\retail\amd64\";
var localFileDir = @"F:\TestDownload";
DateTime dt = DateTime.Now;


var tasks = new List<Task>();
CopyDirectory(remoteFileDir, localFileDir, tasks);
Task.WhenAll(tasks).Wait();

DateTime dt2 = DateTime.Now;
Console.WriteLine($"Down suceessfully.{dt2 - dt}");


static void CopyDirectory(string sourcePath, string destPath, List<Task> tasks)
{
    string floderName = Path.GetFileName(sourcePath);
    DirectoryInfo di = Directory.CreateDirectory(Path.Combine(destPath, floderName));
    string[] files = Directory.GetFileSystemEntries(sourcePath);

    foreach (string file in files)
    {
        if (Directory.Exists(file))
        {
            CopyDirectory(file, di.FullName, tasks);
        }
        else
        {

            var task = Task.Run(() => File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)), true));
            tasks.Add(task);
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
