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
            //Arrange:��������һЩ�Ⱦ����趨�����紴������ʵ�������ݣ�����ȡ�
            var albertCalculate = new Albert_Calculator();
            //Act:������ִ���������벢���ؽ����������÷���������������
            var result = albertCalculate.Add(1, 2, 3);
            //Assert:���������������������ͨ������ʧ�����ֽ����
            Assert.Equal(6, result);
        }
    }
}
