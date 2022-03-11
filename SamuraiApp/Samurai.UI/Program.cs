using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            // AddSamuraiByName("Shimada", "Okamoto", "Kikuchio", "Hyashida");
            // GetSamurais("After Add: ");
            // GetFirstSamuraiByNameLike("S");
            // GetSamuraiById(1);
            // RetriveAndUpdateSamurai(1, "-san");
            RetriveAndUpdateMultiplesSamurai("-san");
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
        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
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
            var samurai = _context.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Name, $"{name}%"));
            Console.WriteLine(samurai.Name);
        }
        private static void GetSamuraiById(int idSamurai)
        {
            // var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            var samurai = _context.Samurais.Find(idSamurai);
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


    }
}
