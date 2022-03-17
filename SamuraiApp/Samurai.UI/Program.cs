using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        private static SamuraiContextNoTracking _contextNT = new SamuraiContextNoTracking();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            // AddSamuraiByName("Shimada", "Okamoto", "Kikuchio", "Hyashida");
            // AddBattles("Battle of Nagashino", "Battle of Anegawa");
            // GetSamurais("");
            // GetFirstSamuraiByNameLike("S");
            // GetSamuraiById(1);
            // RetriveAndUpdateSamurai(1, "-san");
            // RetriveAndUpdateMultiplesSamurai("-san");
            // QueryAndUpdateBattles_Disconnected(new DateTime(1570, 01, 01), new DateTime(1570, 12, 01));
            // InsertNewSamuraiWithAQuote();
            // AddQuoteToExistingSamuraiWhileTracked(1, "I bet you're happy that I've saved you!");
            // Simpler_AddQuoteToExistingSamuraiNotTracked(1, "Thaks for dinner!");
            // EagerLoadSamuraiWithQuotes();
            // AddHorseToSamurai(1, "Pé de pano");
            // ExplicitLoadQuotes(1);
            // FiteringWithRelatedData("save");
            // ModifyRelatedDataWhenTracked(9, "Did you hear that?");
            // ModifyRelatedDataWhenNotTracked(9, " Did you hear that again?");
            // AddingNewSamuraiToAnExistingBattle("Takeda Shingen");
            // ReturnBattleWithSamurais();
            // AddAllSamuraisToAllBattles();
            // RemoveSamuraiFromABattle(12, 1);
            // RemoveSamuraiFromABattleExplicit(10, 1);
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        private static void AddSamuraiByName(params string[] names)
        {
            foreach (var name in names)
            {
                _context.Samurais.Add(new Samurai{ Name = name });
            }
            
            _context.SaveChanges();
        }
        private static void AddBattles(params string[] names)
        {
            var battles = new List<Battle>();
            foreach (var name in names)
            {
                battles.Add(new Battle { Name = name });
            }
            _context.Battles.AddRange(battles);

            _context.SaveChanges();
        }
        private static void GetSamurais(string text)
        {
            // var samurais = _context.Samurais.ToList();
            var samurais = _contextNT.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine($"({samurai.Id}) - {samurai.Name}");
            }
        }
        private static void GetSamuraisByNameLike(String name)
        {
            // var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, $"{name}%")).ToList();
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
        private static void GetFirstSamuraiByNameLike(String name)
        {
            // var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            //var samurai = _context.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Name, $"{name}%"));
            var samurai = _contextNT.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Name, $"{name}%"));
            Console.WriteLine(samurai.Name);
        }
        private static void GetSamuraiById(int idSamurai)
        {
            // var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            // var samurai = _context.Samurais.Find(idSamurai);
            var samurai = _contextNT.Samurais.Find(idSamurai);
            Console.WriteLine(samurai.Name);
        }
        private static void RetriveAndUpdateSamurai(int idSamurai, string prefixName)
        {
            var samurai  = _context.Samurais.Find(idSamurai);
            verifyAndModifySamuraiPrefixName(samurai, prefixName);
            _context.SaveChanges();
        }
        private static void verifyAndModifySamuraiPrefixName(Samurai samurai, string prefixName)
        {
            if (samurai.Name.Contains(prefixName))
            {
                Console.WriteLine($"{samurai.Name} contains {prefixName}, then remove-it!");
                samurai.Name = samurai.Name.Replace(prefixName, "");
            }
            else
            {
                Console.WriteLine($"{samurai.Name} not contains {prefixName}, then add!");
                samurai.Name += prefixName;
            }
        }
        private static void RetriveAndUpdateMultiplesSamurai(string prefixName)
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => verifyAndModifySamuraiPrefixName(s, prefixName));
            _context.SaveChanges();
        }
        private static void RetriveAndDeleteASamuraiById(int idSamurai) 
        {
            var samurai = _context.Samurais.Find(idSamurai);
            _context.Samurais.Remove(samurai);

        }
        private static void QueryAndUpdateBattles_Disconnected(DateTime startDateBattle, DateTime endDateBattle) 
        {
            List<Battle> disconnectedBattles;
            using (var context1 = new SamuraiContext())
            {
                disconnectedBattles = _context.Battles.ToList();
            } // context1 is disposed

            disconnectedBattles.ForEach(b =>
                {
                    b.StartDate = startDateBattle;
                    b.EndDate = endDateBattle;
                });
            using (var context2 = new SamuraiContext()) 
            {
                context2.UpdateRange(disconnectedBattles);
                context2.SaveChanges();
            }
        }
        private static void InsertNewSamuraiWithAQuote()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "I've come to save you"}
                }
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void InsertNewSamuraiWithManyQuotes()
        {
            var samurai = new Samurai
            {
                Name = "Kyuzo",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "Wath out for my sharp sword!"},
                    new Quote { Text = "I told you to wath out for the sharp sword! Oh well!"}
                }
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiWhileTracked(int idSamurai, string quoteText)
        {
            var samurai = _context.Samurais.Find(idSamurai);
            samurai.Quotes.Add(new Quote { Text = quoteText });
            _context.SaveChanges();
        }
        private static void Simpler_AddQuoteToExistingSamuraiNotTracked(int idSamurai, string quoteText)
        {
            var quote = new Quote { Text = quoteText, SamuraiId = idSamurai };
            using var newContext = new SamuraiContext();
            newContext.Quotes.Add(quote);
            newContext.SaveChanges();
        }
        private static void printSamurais(List<Samurai> samurais)
        {
            samurais.ForEach(s => Console.WriteLine(s.printSamurai()));
        }
        private static void EagerLoadSamuraiWithQuotes() {
            //var samurais = _context.Samurais.Include(s => s.Quotes).ToList();
            // -- Filtered Include Query
            var samurais = _context.Samurais
                .Where(s => s.Name.Contains("Tharle"))
                .Include(s => s.Quotes.Where(q => q.Text.Contains("Thanks"))).ToList();
            printSamurais(samurais);
            
        }
        private static void AddHorseToSamurai(int idSamurai, string nameHorse) 
        {
            _context.Set<Horse>().Add(new Horse { SamuraiId = idSamurai, Name = nameHorse });
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        private static void ExplicitLoadQuotes(int idSamurai) 
        {
            var samurai = _context.Samurais.Find(idSamurai);
            _context.Entry(samurai).Collection(s => s.Quotes).Load(); // Collection
            _context.Entry(samurai).Reference(s => s.Horse).Load(); // Single reference
            Console.WriteLine(samurai.printSamurai());
        }
        private static void FiteringWithRelatedData(string Text)
        {
            var samurais = _context.Samurais
                .Where(s => s.Quotes.Any(q => q.Text.Contains(Text)))
                .ToList();
            printSamurais(samurais);
        }
        private static void ModifyRelatedDataWhenTracked(int idSamurai, string newQuotaText)
        {
            var samurai = _context.Samurais.Include(s => s.Quotes)
                .FirstOrDefault(s => s.Id == idSamurai);
            var quote = samurai.Quotes[0];
            quote.Text = newQuotaText;
            _context.SaveChanges();
        }
        private static void ModifyRelatedDataWhenNotTracked(int idSamurai, string newQuotaText)
        {
            var samurai = _context.Samurais.Include(s => s.Quotes)
                .FirstOrDefault(s => s.Id == idSamurai);
            var quote = samurai.Quotes[0];
            quote.Text = newQuotaText;

            using var newContext = new SamuraiContext();
            // newContext.Quotes.Update(quote); // That will make an update for all objects Related that Quota (Samurai [others samurai's quotes])
            newContext.Entry(quote).State = EntityState.Modified;// that single line will just update for that object, ignoring others relates objects in quota.
            newContext.SaveChanges();
        }
        private static void AddingNewSamuraiToAnExistingBattle(string samuraiName)
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.Samurais.Add(new Samurai { Name = samuraiName });
            _context.SaveChanges();
        }
        private static void ReturnBattleWithSamurais()
        {
            var battle = _context.Battles.Include(b => b.Samurais).FirstOrDefault();
        }
        private static void ReturnAllBattlesWithSamurais()
        {
            var battle = _context.Battles.Include(b => b.Samurais).ToList();
        }
        private static void AddAllSamuraisToAllBattles()
        {
            var battles = _context.Battles.Include(b=>b.Samurais).ToList();
            var samurais = _context.Samurais.ToList();

            foreach (var battle in battles)
            {
                battle.Samurais.AddRange(samurais);
            }
            _context.SaveChanges();
        }
        private static void RemoveSamuraiFromABattle(int idSamurai, int idBattle)
        {
            var battleWithSamurai = _context.Battles
                .Include(b => b.Samurais.Where(s => s.Id == idSamurai))
                .Single(b => b.Id == idBattle);
            var samurai = battleWithSamurai.Samurais[0];
            battleWithSamurai.Samurais.Remove(samurai);
            _context.SaveChanges();
            
        }
        private static void ThatWillNotRemoveSamuraiFromABattle(int idSamurai, int idBattle) {
            var battle = _context.Battles.Find(2);
            var samurai = _context.Samurais.Find(12);
            battle.Samurais.Remove(samurai);
            _context.SaveChanges();// the relationship is not being tracked
        }
        private static void RemoveSamuraiFromABattleExplicit(int idSamurai, int idBattle)
        {
            var b_s = _context.Set<BattleSamurai>()
                .SingleOrDefault(bs => bs.BattleId == idBattle && bs.SamuraiId == idSamurai);

            if(b_s != null)
            {
                _context.Remove(b_s); // _context.Set<BattleSamurai>().Remove [works, too]
                _context.SaveChanges();
            }
        }
    }
}
