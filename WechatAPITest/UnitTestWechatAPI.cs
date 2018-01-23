using System;
using Xunit;

namespace WechatAPITest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("","")]
        public void Login_shouldReturnFailed(string userName,string password)
        {
            var result = Login(userName, password);
            bool exceptValue = false;
            Assert.Equal(exceptValue,result);
        }

        [Theory]
        [InlineData("test", "test123")]
        public void Login_shouldReturnSuccess(string userName,string password)
        {
            var result = Login(userName, password);
            bool exceptValue = true;
            Assert.Equal(exceptValue, result);
        }

        private bool Login(string userName,string password){
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                return true;
            }
            //Get relation data to User, address, validate

            return false;
        }
    }



}
