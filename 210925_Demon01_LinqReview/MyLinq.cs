using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class MyLinq
    {
        //实现Linq的Where方法
        public static IEnumerable<int> AlbertWhere(this IEnumerable<int> sources, Func<int, bool> func)
        {
            foreach (var item in sources)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
    }
}
