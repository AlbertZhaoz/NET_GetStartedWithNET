// See https://aka.ms/new-console-template for more information

//C# 字典排序
using _211118_Demo01_GolangCSharpImplement;
using System.Drawing;
using System.Text.Json;

Dictionary<string, int> dicStuManager = new Dictionary<string, int>();
dicStuManager.Add("AlbertZhao", 15);
dicStuManager.Add("AlbertLi", 14);
dicStuManager.Add("AlbertChen", 13);
dicStuManager.Add("AlbertHuang", 12);

var tempdic = dicStuManager.OrderBy(o => o.Key);//降序排序

foreach (var item in tempdic)
{
    System.Console.WriteLine(item.Key);
}

//写一个程序，统计一个字符串中每个单词出现的次数。比如：”how do you do”中how=1 do=2 you=1。
Dictionary<string,int> dicWords = new Dictionary<string,int>();
var words = "how do you do";
var splictWords = words.Split(' ');
foreach (var word in splictWords)
{
    if (dicWords.ContainsKey(word))
    {
        dicWords[word]++;
    }
    else
    {
        dicWords.Add(word, 1);
    }
}
foreach (var item in dicWords)
{
    Console.WriteLine(item.Key+":"+item.Value);
}


//删除字符串首尾空格
var str = "   This is free city  ";
Console.WriteLine(str.Trim());
string.Intern(str);


//判断字符串是否以指定开头或结尾
var str2 = "This is free city";
Console.WriteLine(str2.StartsWith("This"));
Console.WriteLine(str2.EndsWith("city"));

//格式化输出当前日志
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
Console.WriteLine(DateTime.Now.ToString("hh-mm-ss"));


//Go 需要7s
var strList = "";
var startTime = DateTime.Now;
for (int i = 0; i < 10; i++)
{
    strList += "hello" + i.ToString();
}
var endTime = DateTime.Now;
Console.WriteLine(endTime-startTime);

Cat catOne = new Cat() { Name = "AlberZhao", SubName = "AlbertZhaoMiao", Age = 25, Color = Color.White };
//全部小写转换
var jsonStr = JsonSerializer.Serialize(catOne).ToLower();
//驼峰法转换结合属性  WriteIndented=true开启Json格式化输出
var jsonOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
jsonStr = JsonSerializer.Serialize(catOne, jsonOptions);
Console.WriteLine(jsonStr);

//读取文件extensions
FileExtensions fileExtensions = new FileExtensions("F:\\Repo\\GetStartedWithGolang\\Day1124\\InterfacePractise\\main.go");
await fileExtensions.ReadFileOne();
Console.WriteLine("===================");
fileExtensions.ReadFileByBuffer();
