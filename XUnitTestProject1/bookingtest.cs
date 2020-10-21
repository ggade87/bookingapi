using bookingapi.Classes;
using bookingapi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class bookingtest
    {
        [Fact]
        public void TestgetSeats()
        {
            List<Seats> actual = DAL.getSeats("123");
            Assert.NotEmpty(actual);
        }

    }

}
