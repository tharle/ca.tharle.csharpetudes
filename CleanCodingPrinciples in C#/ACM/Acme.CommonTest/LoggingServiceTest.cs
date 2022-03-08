using System;
using Xunit;
using Xunit.Abstractions;
using Acme.Common;
using System.Collections.Generic;
using ACM.BL;


namespace Acme.CommonTest
{
    public class LoggingServiceTest
    {
        private readonly ITestOutputHelper output;
        public LoggingServiceTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void WriteToFileTest()
        {
            var changedItems = new List<ILoggable>();
            changedItems.Add(new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            });

            changedItems.Add(new Product(2)
            {
                ProductName = "SunFlowers",
                Description = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers.",
                CurrentPrice = 18m,
                HasChanges = true
            });
            
            output.WriteLine(LoggingService.WriteToFile(changedItems).ToString());
        }
    }
}
