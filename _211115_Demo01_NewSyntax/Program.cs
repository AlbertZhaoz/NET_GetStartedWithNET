using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
using _211115_Demo01_NewSyntax;


Dictionary<string,int> dicStuManager = new Dictionary<string, int>();
dicStuManager.Add("AlbertZhao",15);
dicStuManager.Add("AlbertLi",14);
dicStuManager.Add("AlbertChen",13);
dicStuManager.Add("AlbertHuang",12);

var tempdic = dicStuManager.OrderBy(o => o.Key);

foreach (var item in tempdic)
{
    System.Console.WriteLine(item.Key);
}


Console.WriteLine("HelloAlbert");
Article article = new Article();
TestUSINGImplement();
Console.WriteLine("Albert");


//注意USING资源管理陷阱
{
    using var fs = File.OpenWrite("D:/1.txt");
    using var ws = new StreamWriter(fs);
    ws.WriteLine("Albert is very elegant.");
}
string s = File.ReadAllText("D:/1.txt");
Console.WriteLine(s);

Student student = new Student(1,"albert",24);
Student student2 = new Student(1, "albert", 24);
Console.WriteLine(student); //打印出学生的所有信息
Console.WriteLine(student==student2);// True，比对各自含有的信息是否相同

//拷贝的便捷方式with
Student student3 = student;
Console.WriteLine(Object.ReferenceEquals(student,student3));//True


Student student4 = student with { };
Console.WriteLine(student4);//Student { id = 1, name = albert, age = 24, height = 0 }
Console.WriteLine(Object.ReferenceEquals(student,student4));//False

static void TestUSINGImplement()
{
    using Class1 class1 = new Class1();//在作用域内执行完毕，资源被释放
}

public record Student(int id,string name,int age)
{
    public int height { get; set; }
}

