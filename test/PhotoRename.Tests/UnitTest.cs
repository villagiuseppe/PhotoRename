using System;
using Xunit;
using PhotoRename.ClassLib;

namespace PhotoRename.Test
{
    public class UnitTest
    {
        private const string expected = "20181227_165708";

        [Fact]
        public void TestGetDateTakenFromImage()
        {
            var result = string.Format("{0:yyyyMMdd_HHmmss}", Utils.GetDateTakenFromImage(@"..\..\..\data\TestImage.jpg",0));
            //Assert  
            Assert.Equal(expected, result);

        }
        [Fact]
        public void TestGetFileNameTakenFromImage()
        {
            var result =  Utils.GetFileNameTakenFromImage(@"..\..\..\data\TestImage.jpg",0);
            //Assert  
            Assert.Equal(expected, result);

        }

    }
}
