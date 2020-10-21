using bookingapi.Classes;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class logintest
    {
        [Fact]
        public void TestLoginSuccess()
        {
            bool expected = true;
            bool actual = Security.Login("test@gmail.com", "123");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLoginFalied()
        {
            bool expected = false;
            bool actual = Security.Login("tes222t@gmail.com", "123");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestGenerateAuthTokenSuccess()
        {
            string expected = "dGVzdEBnbWFpbC5jb206MTIz";
            string actual = Security.generateAuthToken("test@gmail.com", "123");
            Assert. Equal(expected, actual);
        }

    }
}
