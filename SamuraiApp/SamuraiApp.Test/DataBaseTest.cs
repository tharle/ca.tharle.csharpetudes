using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Diagnostics;

namespace SamuraiApp.Test
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDataBase()
        {
            using (var context = new SamuraiContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated(); // To be sure que I'm working with fresh data
                var samurai = new Samurai();
                context.Samurais.Add(samurai);
                Debug.WriteLine($"Before save: {samurai.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {samurai.Id}");

                Assert.AreNotEqual(0, samurai.Id);
            }
        }
    }
}
