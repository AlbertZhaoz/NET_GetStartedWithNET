
namespace _211115_Demo01_NewSyntax;
internal class Class1 : IDisposable
{
    Article article1 = new Article();

    public void Dispose()
    {
        Console.WriteLine("资源被释放啦");
    }
}

