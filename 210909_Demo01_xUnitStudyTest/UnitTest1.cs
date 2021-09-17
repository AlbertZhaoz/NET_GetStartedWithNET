using _210909_Demo01_xUnitStudy;
using System;
using Xunit;

namespace _210909_Demo01_xUnitStudyTest
{
    public class UnitTest1
    {
        [Fact]
        public void VertifyAddEqual()
        {
            //Arrange:在这里做一些先决的设定。例如创建对象实例，数据，输入等。
            var albertCalculate = new Albert_Calculator();
            //Act:在这里执行生产代码并返回结果。例如调用方法或者设置属性
            var result = albertCalculate.Add(1, 2, 3);
            //Assert:在这里检查结果，会产生测试通过或者失败两种结果。
            Assert.Equal(6, result);
        }
    }
}
