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
            //GetFirstSamuraiByNameLike("S");
            GetSamuraiById(1);
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

        
    }
}
