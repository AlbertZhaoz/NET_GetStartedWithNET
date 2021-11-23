using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _211118_Demo01_GolangCSharpImplement
{
    internal class Cat
    {
        [JsonPropertyName("aGe")]
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? SubName { get; set; }
        public Color Color { get; set; }
    }
}
