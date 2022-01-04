using _211210_Demo01_WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _211210_Demo01_WebMVC.Controllers
{
    public class AlbertController : Controller
    {
        public IActionResult Print()
        {
            Student stu = new Student(25,"AlbertZhao",DateTime.Now);
            return View(stu);
        }
    }
}
